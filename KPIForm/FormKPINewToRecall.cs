using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDentBusiness;
using OpenDental.ReportingComplex;

namespace KPIReporting.KPIForm
{
    public partial class FormKPINewToRecall : Form
    {
        int manualdate = 0;

        public FormKPINewToRecall()
        {
            InitializeComponent();
            Lan.F(this);
        }

        private void FormKPINewToRecall_Load(object sender, EventArgs e)
        {
 
        }

        private void butDateSelec_Click(object sender, EventArgs e)
        {
            manualdate = 1;
            ManualDateSelection();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            DataTable tablePats;
            if (manualdate == 0)
            {
                tablePats = KPINewToRecall.GetNewToRecall(DateTime.Today.AddYears(-1), DateTime.Today);
            } else
            {
                tablePats = KPINewToRecall.GetNewToRecall(dateStart.SelectionStart, dateEnd.SelectionStart);
            }

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "New to Recall Patients");
            report.AddTitle("Title", Lan.g(this, "New to Recall Patients"));
            if (manualdate == 0)
            {
                report.AddSubTitle("Date", DateTime.Today.AddYears(-1).ToShortDateString() + " - " + DateTime.Today.ToShortDateString());
            } else
            {
                report.AddSubTitle("Date", dateStart.SelectionStart.ToShortDateString() + " - " + dateEnd.SelectionStart.ToShortDateString());
            }
            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name", 150, FieldValueType.String);
            query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Age", 40, FieldValueType.String);
            query.AddColumn("Type of Recall", 100, FieldValueType.String);
            //query.AddGroupSummaryField("Patient Count:", "Name", "Provider", SummaryOperation.Count);
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