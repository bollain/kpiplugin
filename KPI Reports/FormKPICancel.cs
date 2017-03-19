using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental.ReportingComplex;

namespace OpenDental {
	public partial class FormKPICancel:Form {

		public FormKPICancel() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormKPICancel_Load(object sender,EventArgs e) {
			dateStart.SelectionStart=DateTime.Today.AddYears(-1);
			dateEnd.SelectionStart=DateTime.Today;
		}

		private void butOK_Click(object sender,EventArgs e) {
			DataTable tablePats=KPICancel.GetCancel(dateStart.SelectionStart,dateEnd.SelectionStart);

            ReportComplex report=new ReportComplex(true,false);
			report.ReportName=Lan.g(this,"Patients who cancelled short notice");
			report.AddTitle("Title",Lan.g(this, "Patients who cancelled short notice"));
			report.AddSubTitle("Date",dateStart.SelectionStart.ToShortDateString()+" - "+dateEnd.SelectionStart.ToShortDateString());
			QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name",150,FieldValueType.String);
			query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Age", 40, FieldValueType.String);
            query.AddColumn("Postal Code",90,FieldValueType.String);
			query.AddColumn("Date of Service",100,FieldValueType.String);
			query.AddColumn("Primary Provider",80,FieldValueType.String);
            query.AddColumn("Procedure Description", 100, FieldValueType.String);
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