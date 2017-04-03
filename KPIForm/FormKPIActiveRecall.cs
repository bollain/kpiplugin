using System;
using System.Data;
using System.Windows.Forms;
using KPIReporting.KPI;
using OpenDental;
using OpenDental.ReportingComplex;

namespace KPIReporting.KPIForm {
	public partial class FormKPIActiveRecall:Form {

		public FormKPIActiveRecall() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormKPIActiveRecall_Load(object sender,EventArgs e) {
            dtpStart.Value = DateTime.Today.AddYears(-1);
			dtpEnd.Value = DateTime.Today;
        }

		private void butOK_Click(object sender,EventArgs e) {
			DataTable tablePats=KPIActiveRecall.GetActiveRecall(dtpStart.Value, dtpEnd.Value);

            ReportComplex report=new ReportComplex(true,false);
			report.ReportName=Lan.g(this,"Patients on Active Recall");
			report.AddTitle("Title",Lan.g(this, "Patients on Active Recall"));
			report.AddSubTitle("Date", dtpStart.Value.ToShortDateString()+" - "+ dtpEnd.Value.ToShortDateString());
			QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name",150,FieldValueType.String);
			query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Age", 40, FieldValueType.String);
            query.AddColumn("Postal Code",90,FieldValueType.String);
			query.AddColumn("Date of Service",100,FieldValueType.String);
            query.AddColumn("Frequency", 90, FieldValueType.String);
            query.AddColumn("Primary Provider",80,FieldValueType.String);
			query.AddGroupSummaryField("Patient Count:","Name", "Provider", SummaryOperation.Count);
			report.AddPageNum();
			if(!report.SubmitQueries()) {
				return;
			}
			FormReportComplex FormR=new FormReportComplex(report);
			FormR.ShowDialog();
			//DialogResult=DialogResult.OK;		
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
    }
}