using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDental.ReportingComplex;

namespace KPIReporting.KPIForm
{
    public partial class FormKPINewPatients : Form {

        public FormKPINewPatients()
        {
            InitializeComponent();
            Lan.F(this);
        }

        private void FormKPINewPatients_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Today.AddMonths(-1); //default one month
            dtpEnd.Value = DateTime.Today;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            DataTable tablePats = KPINewPatients.GetNewPatients(dtpStart.Value, dtpEnd.Value);

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "New Patients");
            report.AddTitle("Title", Lan.g(this, "New Patients"));
            report.AddSubTitle("Date", dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name", 150, FieldValueType.String);
            query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Age", 40, FieldValueType.String);
            query.AddColumn("Date of Service", 100, FieldValueType.String);
            query.AddGroupSummaryField("Patient Count:", "Name", "Date of Service", SummaryOperation.Count);
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