using System;
using System.Data;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDental.ReportingComplex;

namespace KPIReporting.KPIForm
{
    public partial class FormKPIDowntime : Form
    {
        public FormKPIDowntime()
        {
            InitializeComponent();
            Lan.F(this);

        }

        private void FormKPIDowntime_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Today.AddYears(-1);
            dtpEnd.Value = DateTime.Today;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            DataTable tableProvs = KPIDowntime.GetDowntime(dtpStart.Value, dtpEnd.Value);

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Provider Down-times");
            report.AddTitle("Title", Lan.g(this, "Provider Down-times"));
            report.AddSubTitle("Date", dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tableProvs, "", "", SplitByKind.None, 0);
            query.AddColumn("Provider Number", 90, FieldValueType.String);
            query.AddColumn("Total Down-time", 100, FieldValueType.String);
            report.AddPageNum();
            if (!report.SubmitQueries())
            { 
                return;
            }
            FormReportComplex FormR = new FormReportComplex(report);
            FormR.ShowDialog();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
