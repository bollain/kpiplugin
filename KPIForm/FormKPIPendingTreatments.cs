using System;
using System.Data;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDental.ReportingComplex;

namespace KPIReporting.KPIForm
{
    public partial class FormKPIPendingTreatments : Form
    {

        public FormKPIPendingTreatments()
        {
            InitializeComponent();
            Lan.F(this);
        }

        private void FormKPIPendingTreatments_Load(object sender, EventArgs e)
        {
            // dateStart.SelectionStart = DateTime.Today;
            // dateEnd.SelectionStart = DateTime.Today.AddYears(1);
            dtpStart.Value = DateTime.Today.AddYears(-1);
            dtpEnd.Value = DateTime.Today;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Pending Treatments");
            report.AddTitle("Title", Lan.g(this, "Pending Treatments"));
            // report.AddSubTitle("Date", dateStart.SelectionStart.ToShortDateString() + " - " + dateEnd.SelectionStart.ToShortDateString());
	    report.AddSubTitle("Date", dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            DataTable tablePats;
            // tablePats = KPIPendingTreatments.GetPendingTreatmentPats(dateStart.SelectionStart, dateEnd.SelectionStart);
            String patQuery = @"
				SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM procedurelog pl
                JOIN procedurecode pc ON pl.CodeNum = pc.CodeNum
                JOIN appointment a ON a.AptNum = pl.PlannedAptNum
                JOIN patient p ON a.PatNum = p.PatNum
                WHERE pl.AptNum = 0
                AND a.AptStatus = 6
                AND pc.ProcCode != 01202
            ";


            //   tablePats = StretchKPICustomForm.GetPatients(dateStart.SelectionStart, dateEnd.SelectionStart, patQuery);
            tablePats = StretchKPICustomForm.GetPatients(dtpStart.Value, dtpEnd.Value, patQuery);

            for (int i = 0; i < tablePats.Rows.Count; i++)
            {
                DataTable onePat = new DataTable();
                DataTable localPat = tablePats.Clone();
                

                DataRow iPat = tablePats.Rows[i];
                //onePat.ImportRow(iPat);
                // localPat.Clear();
                localPat.ImportRow(iPat);

                

                //report.AddLine("test", AreaSectionType.None, Color.AliceBlue, 20, LineOrientation.Horizontal,
                //    LinePosition.West, 100, 0, 0);

                

                QueryObject query = report.AddQuery(localPat, "", "", SplitByKind.None, 0);
                // query.AddColumn("PatNum", 90, FieldValueType.Number);
                query.AddColumn("PatNum", 60, FieldValueType.String);
                query.AddColumn("Name", 150, FieldValueType.String);
                query.AddColumn("Home Phone", 80, FieldValueType.String);
                query.AddColumn("Work Phone", 80, FieldValueType.String);
                query.AddColumn("Cell Phone", 80, FieldValueType.String);
                query.AddColumn("Email", 150, FieldValueType.String);


                String iPatNum = iPat["PatNum"].ToString();

                //   DataTable procsForPat = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(dateStart.SelectionStart, 
                //         dateEnd.SelectionStart, iPatNum);

                   DataTable procsForPat = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(dtpStart.Value, dtpEnd.Value, iPatNum);


                QueryObject procsQ = report.AddQuery(procsForPat, "", "", SplitByKind.None, 0);
                procsQ.AddColumn("Procedure Code", 100, FieldValueType.String);
                procsQ.AddColumn("Treatment Planned", 500, FieldValueType.String);

            }



            /*
            // OLDER FORM:
            DataTable tablePats = KPIPendingTreatments.GetPendingTreatments(dateStart.SelectionStart, dateEnd.SelectionStart);
            ReportComplex report = new ReportComplex(true, false);            

            report.ReportName = Lan.g(this, "Pending Treatments");
            report.AddTitle("Title", Lan.g(this, "Pending Treatments"));
            // report.AddSubTitle("Date", dateStart.SelectionStart.ToShortDateString() + " - " + dateEnd.SelectionStart.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            // query.AddColumn("PatNum", 90, FieldValueType.Number);
            query.AddColumn("Name", 150, FieldValueType.String);
            query.AddColumn("Home Phone", 50, FieldValueType.String);
            query.AddColumn("Work Phone", 50, FieldValueType.String);
            query.AddColumn("Wireless Phone", 70, FieldValueType.String);
            query.AddColumn("Email", 100, FieldValueType.String);

            query.AddColumn("Procedure Code", 80, FieldValueType.String);
            query.AddColumn("Treatment Planned", 280, FieldValueType.String);

            // query.AddColumn("Birthdate", 80, FieldValueType.String);
            // query.AddColumn("Sex", 150, FieldValueType.String);
            // query.AddColumn("Postal Code", 90, FieldValueType.String);
            // query.AddColumn("Date of Service", 100, FieldValueType.String);
            // query.AddColumn("Primary Provider", 40, FieldValueType.String);
            // query.AddGroupSummaryField("Patient Count:", "Name", "Provider", SummaryOperation.Count);
            report.AddPageNum();

            */
	    report.AddPageNum();
            if (!report.SubmitQueries())
            {
                return;
            }
            FormReportComplex FormR = new FormReportComplex(report);
            FormR.ShowDialog();
            //DialogResult=DialogResult.OK;		
            



        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
