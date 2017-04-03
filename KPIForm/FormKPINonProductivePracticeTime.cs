using System;
using System.Data;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDental.ReportingComplex;

namespace KPIReporting.KPIForm
{
    public partial class FormKPINonProductivePracticeTime : Form
    {
        public FormKPINonProductivePracticeTime()
        {
            InitializeComponent();
            Lan.F(this);
        }
        private void FormKPINonProductivePracticeTime_Load(object sender, EventArgs e)
        {
            dateStart.Value = DateTime.Today.AddYears(-1);
            dateEnd.Value = DateTime.Today;
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            DataTable tableProvs = KPINonProductivePracticeTime.GetNonProductivePracticeTime(dateStart.Value, dateEnd.Value);

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Total Non-Productive Practice Time");
            report.AddTitle("Title", Lan.g(this, "Total Non-Productive Practice Time"));
            report.AddSubTitle("Date", dateStart.Value.ToShortDateString() + " - " + dateEnd.Value.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tableProvs, "", "", SplitByKind.None, 0);
            query.AddColumn("Time (Hours:Min:Seconds)", 200, FieldValueType.String);
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
