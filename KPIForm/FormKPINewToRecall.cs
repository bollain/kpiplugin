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
         public FormKPINewToRecall()
        {
            InitializeComponent();
            Lan.F(this);
        }

        private void FormKPINewToRecall_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Today.AddYears(-1); //default one year
            dtpEnd.Value = DateTime.Today;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            DataTable tablePats;
            tablePats = KPINewToRecall.GetNewToRecall(dtpStart.Value, dtpEnd.Value);
      
            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "New to Recall Patients");
            report.AddTitle("Title", Lan.g(this, "New to Recall Patients"));
            report.AddSubTitle("Date", dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name", 150, FieldValueType.String);
            query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Age", 40, FieldValueType.String);
            query.AddColumn("Type of Recall", 100, FieldValueType.String);
            query.AddGroupSummaryField("Patient Count:", "Name", "Type of Recall", SummaryOperation.Count);
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