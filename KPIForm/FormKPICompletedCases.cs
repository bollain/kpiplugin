using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental.ReportingComplex;

namespace OpenDental.KPI_Reports
{
    public partial class FormKPICompletedCases : Form
    {

        public FormKPICompletedCases()
        {
            InitializeComponent();
            Lan.F(this);
        }

        private void FormKPICompletedCases_Load(object sender, EventArgs e)
        {
            //dateStart.SelectionStart = DateTime.Today.AddYears(-1);
            //dateEnd.SelectionStart = DateTime.Today;
            dtpStart.Value = DateTime.Today.AddYears(-1);
            dtpEnd.Value = DateTime.Today;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Completed Cases");
            report.AddTitle("Title", Lan.g(this, "Completed Cases"));
            // report.AddSubTitle("Date", dateStart.SelectionStart.ToShortDateString() + " - " + dateEnd.SelectionStart.ToShortDateString());
            report.AddSubTitle("Date", dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());

            DataTable tablePats;
            // tablePats = KPICompletedCases.GetCompletedCases(dateStart.SelectionStart, dateEnd.SelectionStart);
            String patQuery = @"
				SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM opendental.procedurelog pl
                JOIN opendental.appointment a ON pl.PlannedAptNum = a.AptNum
                JOIN opendental.procedurecode pc ON pc.CodeNum = pl.CodeNum
                JOIN opendental.patient p ON p.PatNum = pl.PatNum
                WHERE a.AptStatus = 6
                AND pl.ProcStatus = 2            
            ";


           // tablePats = StretchKPICustomForm.GetPatients(dateStart.SelectionStart, dateEnd.SelectionStart, patQuery);
           // tablePats = KPICompletedCases.GetCompletedCasesPats(dateStart.SelectionStart, dateEnd.SelectionStart);
            tablePats = KPICompletedCases.GetCompletedCasesPats(dtpStart.Value, dtpEnd.Value);

                for (int i = 0; i < tablePats.Rows.Count; i++)
            {
                DataTable onePat = new DataTable();
                DataTable localPat = tablePats.Clone();

                DataRow iPat = tablePats.Rows[i];
                //onePat.ImportRow(iPat);
                // localPat.Clear();
                localPat.ImportRow(iPat);

                QueryObject query = report.AddQuery(localPat, "", "", SplitByKind.None, 0);
                // query.AddColumn("PatNum", 90, FieldValueType.Number);
                query.AddColumn("PatNum", 60, FieldValueType.String);
                query.AddColumn("Name", 150, FieldValueType.String);
                query.AddColumn("Home Phone", 80, FieldValueType.String);
                query.AddColumn("Work Phone", 80, FieldValueType.String);
                query.AddColumn("Cell Phone", 80, FieldValueType.String);
                query.AddColumn("Email", 150, FieldValueType.String);

                String iPatNum = iPat["PatNum"].ToString();

                // DataTable procsForPat = KPICompletedCases.GetCompletedCasesPerPat(dateStart.SelectionStart,
                //     dateEnd.SelectionStart, iPatNum);
                DataTable procsForPat = KPICompletedCases.GetCompletedCasesPerPat(dtpStart.Value, dtpEnd.Value, iPatNum);

                QueryObject procsQ = report.AddQuery(procsForPat, "", "", SplitByKind.None, 0);
                procsQ.AddColumn("Date of Service", 100, FieldValueType.String);
                procsQ.AddColumn("Treatment Code", 100, FieldValueType.String);
                procsQ.AddColumn("Treatment Completed", 350, FieldValueType.String);
                procsQ.AddColumn("Billed", 50, FieldValueType.Number);

            //    procsQ.AddGroupSummaryField("Number of Completed Cases for "+ iPat["Name"] + ":", "Date of Service", 
            //        "Treatment Code", SummaryOperation.Count);
            //    procsQ.AddGroupSummaryField("TOTAL:", "Billed", "Billed", SummaryOperation.Count);


                report.AddLine("line", AreaSectionType.GroupFooter, Color.AliceBlue, 20,
                    LineOrientation.Horizontal, LinePosition.Center, 25, 0, 0);

            }

            /*
            // OLDER FORM:
            DataTable tablePats = KPICompletedCases.GetCompletedCases(dateStart.SelectionStart, dateEnd.SelectionStart);
            ReportComplex report = new ReportComplex(true, false);            
            report.ReportName = Lan.g(this, "Completed Cases");
            report.AddTitle("Title", Lan.g(this, "Completed Cases"));
            report.AddSubTitle("Date", dateStart.SelectionStart.ToShortDateString() + " - " + dateEnd.SelectionStart.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name", 150, FieldValueType.String);

            query.AddColumn("Date of Service", 100, FieldValueType.String);
            query.AddColumn("Treatment Code", 80, FieldValueType.String);
            query.AddColumn("Treatment Completed", 280, FieldValueType.String);
            query.AddColumn("Billed", 50, FieldValueType.String);
            //        query.AddColumn("Birthdate", 80, FieldValueType.String);
            //        query.AddColumn("Sex", 150, FieldValueType.String);
            //        query.AddColumn("Postal Code", 90, FieldValueType.String);
            //        query.AddColumn("Date of Service", 100, FieldValueType.String);
            //        query.AddColumn("Primary Provider", 40, FieldValueType.String);
            //        query.AddGroupSummaryField("Number of Completed Cases:", "Name", "Provider", SummaryOperation.Count);

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