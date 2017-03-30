/*=============================================================================================================
Open Dental GPL license Copyright (C) 2003  Jordan Sparks, DMD.  http://www.open-dent.com,  www.docsparks.com
See header in FormOpenDental.cs for complete text.  Redistributions must retain this text.
===============================================================================================================*/
//#define TRIALONLY //Do not set here because ContrChart.ProcButtonClicked and FormOpenDental also need to test this value.
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using OpenDental.UI;
using OpenDental.Bridges;
using OpenDentBusiness;
using OpenDental;
using OpenDental.ReportingComplex;
using Button = OpenDental.UI.Button;
using CodeBase;
using KPIReporting.KPI;


namespace KPIReporting.KPIForm
{
    ///<summary>All this dialog does is set the patnum and it is up to the calling form to do an immediate refresh, or possibly just change the patnum back to what it was.  So the other patient fields must remain intact during all logic in this form, especially if SelectionModeOnly.</summary>
    public partial class FormKPIConversionRate : ODForm
    {
        private OpenDental.UI.Button butOK;
        private OpenDental.UI.Button butCancel;
        /// <summary>Use when you want to specify a patient without changing the current patient.  If true, then the Add Patient button will not be visible.</summary>
        public bool SelectionModeOnly;
        ///<summary>When closing the form, this indicates whether a new patient was added from within this form.</summary>
        public bool NewPatientAdded;
        ///<summary>Only used when double clicking blank area in Appts. Sets this value to the currently selected pt.  That patient will come up on the screen already selected and user just has to click OK. Or they can select a different pt or add a new pt.  If 0, then no initial patient is selected.</summary>
        public long InitialPatNum;
        private DataTable PtDataTable;
        ///<summary>When closing the form, this will hold the value of the newly selected PatNum.</summary>
        public long SelectedPatNum;
        private OpenDental.UI.Button butAddAll;
        private TextBox selectedTxtBox;
        private List<DisplayField> fields;
        private DateTimePicker dateStart;
        ///<summary>List of all the clinics this userod has access to.  When comboClinic.SelectedIndex=0 it refers to all clinics in this list.  Otherwise their selected clinic will always be _listClinics[comboClinic.SelectedIndex-1].</summary>
        private List<Clinic> _listClinics;
        ///<summary>Set to true if constructor passed in patient object to prefill text boxes.  Used to make sure fillGrid is not called
        ///before FormSelectPatient_Load.</summary>
        private bool _isPreFillLoad = false;
        ///<summary>If set, initial patient list will be set to these patients.</summary>
        public List<long> ExplicitPatNums;
        private ODThread _fillGridThread = null;
        private DateTime _dateTimeLastSearch;
        private DateTime _dateTimeLastRequest;
        private ComputerPref _computerPref;
        private int _pnum;
        private string _pc;
        private float _percentage;
        public FormKPIConversionRate() : this(null)
        {
        }

        public FormKPIConversionRate(Patient pat)
        {
            InitializeComponent();
            Lan.F(this);
   
        }

        private Button butAddPt;

  

        ///<summary></summary>
        public void FormSelectPatient_Load(object sender, System.EventArgs e)
        {

            if (cmbProc.Items.Count == 0)
            {
                fill_cmbProc();
            }

            _percentage = 0;
            dateStartPick.Value = DateTime.Today.AddYears(-1);

        }

        private void fill_cmbProc()
        {

            DataTable table = new DataTable();
            table.Columns.Add("Procedure Code");


            DataRow row;

            string command = @"
				SELECT ProcCode
                FROM procedurecode";

            DataTable raw = ReportsComplex.GetTable(command);

            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                row["Procedure Code"] = raw.Rows[i]["ProcCode"].ToString();
            }

            for (int i = 0; i < raw.Rows.Count; i++)
            {
                cmbProc.Items.Add(raw.Rows[i]["ProcCode"].ToString());
            }

        }


        private void butOK_Click(object sender, System.EventArgs e)
        {
            if (_pc == null)
            {
                MessageBox.Show("Please Select a Procedure Code.");
            }
            else {
                _percentage = KPIConversionRate.GetConversionRate(dateStartPick.Value.Date, dateEndPick.Value.Date, _pc);
                if (_percentage == 9999)
                {
                    MessageBox.Show("No Procedures to query");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Conversion rate for " + _pc + " between " + dateStartPick.Value.ToShortDateString() + " and " + dateEndPick.Value.ToShortDateString() + " is: " + _percentage
                           + Environment.NewLine + "Press Ctrl + C to copy this value.");
                    DialogResult = DialogResult.OK;

                }

            }
            
        }

        private void butCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

       

        private void cmbProc_SelectedValueChanged(object sender, EventArgs e)
        {
            _pc = cmbProc.SelectedItem.ToString();
        }

       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateEndPick.Value < dateStartPick.Value)
            {
                MessageBox.Show("Date End cannot be before Date Start");

            } 
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateEndPick.Value < dateStartPick.Value)
            {
                MessageBox.Show("Date End cannot be before Date Start");

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pc = cmbProc.SelectedItem.ToString();

        }
    }
}
