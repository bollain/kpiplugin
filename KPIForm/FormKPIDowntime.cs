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
            dateStart.Value = DateTime.Today.AddYears(-1);
            dateEnd.Value = DateTime.Today;
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            DataTable tableProvs = KPIDowntime.GetDowntime(dateStart.Value, dateEnd.Value);

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Provider Down-times");
            report.AddTitle("Title", Lan.g(this, "Provider Down-times"));
            report.AddSubTitle("Date", dateStart.Value.ToShortDateString() + " - " + dateEnd.Value.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tableProvs, "", "", SplitByKind.None, 0);
            query.AddColumn("Provider Number", 90, FieldValueType.String);
            query.AddColumn("Total Down-time", 100, FieldValueType.String);
            query.AddColumn("Patients with Broken Appointments", 100, FieldValueType.String);
            report.AddPageNum();
            if (!report.SubmitQueries())
            { 
                return;
            }
            FormReportComplex FormR = new FormReportComplex(report);
            FormR.ShowDialog();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
