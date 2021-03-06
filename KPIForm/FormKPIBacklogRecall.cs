﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenDental.ReportingComplex;
using KPIReporting.KPI;
using OpenDental;

namespace KPIReporting.KPIForm
{
    public partial class FormKPIBacklogRecall : Form
    {
        public FormKPIBacklogRecall()
        {
            InitializeComponent();
            Lan.F(this);
        }

        private void FormKPIBacklogRecall_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Today.AddYears(-1);
            dtpEnd.Value = DateTime.Today;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            DataTable tablePats = KPIRecallBacklog.GetRecallBacklog(dtpStart.Value, dtpEnd.Value);

            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Backlog of Recall Patients");
            report.AddTitle("Title", Lan.g(this, "Backlog of Recall Patients"));
            report.AddSubTitle("Date", dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Name", 90, FieldValueType.String);
            query.AddColumn("Gender", 60, FieldValueType.String);
            query.AddColumn("Contact Method", 100, FieldValueType.String);
            query.AddColumn("Phone", 100, FieldValueType.String);
            query.AddColumn("Email", 120, FieldValueType.String);
            query.AddColumn("Hygienist ID (Last Appt)", 60, FieldValueType.String);
            query.AddColumn("Date of Last Recall", 90, FieldValueType.String);
            query.AddColumn("Due Date", 90, FieldValueType.String);
            query.AddGroupSummaryField("Patient Count", "Gender", "Name", SummaryOperation.Count);
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
