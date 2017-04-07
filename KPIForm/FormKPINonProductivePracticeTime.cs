using System;
using System.Data;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDental.ReportingComplex;
using System.Collections.Generic;

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
            List<object> tableProvs = KPINonProductivePracticeTime.GetNonProductivePracticeTime(dateStart.Value, dateEnd.Value);
            DataTable queryToAdd = (DataTable)tableProvs[0];
            string total = (string)tableProvs[1];

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Non-Productive Practice Time");
            report.AddTitle("Title", Lan.g(this, "Non-Productive Practice Time"));
            report.AddSubTitle("Date", dateStart.Value.ToShortDateString() + " - " + dateEnd.Value.ToShortDateString());
            report.AddSubTitle("Total time", "TOTAL TIME = " + total);
            QueryObject query;
            query = report.AddQuery(queryToAdd, "", "", SplitByKind.None, 0);
            query.AddColumn("Name", 150, FieldValueType.String);
            query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Age", 40, FieldValueType.String);
            query.AddColumn("Postal Code", 90, FieldValueType.String);
            query.AddColumn("Date of Service", 100, FieldValueType.String);
            query.AddColumn("Primary Provider", 80, FieldValueType.String);
            query.AddColumn("Procedure Description", 100, FieldValueType.String);
            query.AddColumn("Time (Hours:Min:Seconds)", 100, FieldValueType.String);
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
