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

namespace OpenDental
{
    ///<summary>All this dialog does is set the patnum and it is up to the calling form to do an immediate refresh, or possibly just change the patnum back to what it was.  So the other patient fields must remain intact during all logic in this form, especially if SelectionModeOnly.</summary>
    public partial class FormKPIRecTreatment : ODForm
    {
        private System.Windows.Forms.Label LNameLabel;
        private Patients Patients;
        private OpenDental.UI.Button butOK;
        private OpenDental.UI.Button butCancel;
        /// <summary>Use when you want to specify a patient without changing the current patient.  If true, then the Add Patient button will not be visible.</summary>
        public bool SelectionModeOnly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label FNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textLName;
        private System.Windows.Forms.TextBox textFName;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textHmPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkHideInactive;
        private System.Windows.Forms.GroupBox groupAddPt;
        private System.Windows.Forms.CheckBox checkGuarantors;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textPatNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textChartNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textSSN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private OpenDental.UI.Button butSearch;
        ///<summary>When closing the form, this indicates whether a new patient was added from within this form.</summary>
        public bool NewPatientAdded;
        ///<summary>Only used when double clicking blank area in Appts. Sets this value to the currently selected pt.  That patient will come up on the screen already selected and user just has to click OK. Or they can select a different pt or add a new pt.  If 0, then no initial patient is selected.</summary>
        public long InitialPatNum;
        private DataTable PtDataTable;
        private OpenDental.UI.ODGrid gridMain;
        private OpenDental.User_Controls.ContrKeyboard contrKeyboard1;
        ///<summary>When closing the form, this will hold the value of the newly selected PatNum.</summary>
        public long SelectedPatNum;
        private CheckBox checkShowArchived;
        private TextBox textBirthdate;
        private Label label2;
        private ComboBox comboBillingType;
        private CheckBox checkRefresh;
        private OpenDental.UI.Button butAddAll;
        private ComboBox comboSite;
        private Label labelSite;
        private TextBox selectedTxtBox;
        private TextBox textSubscriberID;
        private Label label13;
        private TextBox textEmail;
        private Label labelEmail;
        private TextBox textCountry;
        private Label labelCountry;
        private ComboBox comboClinic;
        private Label labelClinic;
        private List<DisplayField> fields;
        private TextBox textRegKey;
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
        private int pnum;
        private string pc;
        private string dsVAL;
        private string deVAL;
        ///<summary></summary>
        public FormKPIRecTreatment() : this(null)
        {
        }

        ///<summary>This takes a partially built patient object and uses it to prefill textboxes to assist in searching.
        ///Currently only implements FName,LName.</summary>
        public FormKPIRecTreatment(Patient pat)
        {
            InitializeComponent();//required first
                                  //tb2.CellClicked += new OpenDental.ContrTable.CellEventHandler(tb2_CellClicked);
                                  //tb2.CellDoubleClicked += new OpenDental.ContrTable.CellEventHandler(tb2_CellDoubleClicked);
            Patients = new Patients();
            Lan.F(this);
            if (pat != null)
            {
                PreFillSearchBoxes(pat);
            }
        }

        private Patient preselectedPatient;
        private Button butAddPt;

        public Patient PreselectedPatient
        {
            get { return preselectedPatient; }
        }

        public void PreselectPatient(Patient value)
        {
            preselectedPatient = value;
            textLName.Text = value.LName;
            textFName.Text = value.FName;
            textCity.Text = value.City;
            butSearch_Click(this, EventArgs.Empty);
        }

        ///<summary></summary>
        public void FormRecTreatment_Load(object sender, System.EventArgs e)
        {
            if (!PrefC.GetBool(PrefName.DockPhonePanelShow))
            {
                labelCountry.Visible = false;
                textCountry.Visible = false;
            }
            if (!PrefC.GetBool(PrefName.DistributorKey))
            {
                textRegKey.Visible = false;
            }
            if (SelectionModeOnly)
            {
                groupAddPt.Visible = false;
            }
            //Cannot add new patients from OD select patient interface.  Patient must be added from HL7 message.
            if (HL7Defs.IsExistingHL7Enabled())
            {
                HL7Def def = HL7Defs.GetOneDeepEnabled();
                if (def.ShowDemographics != HL7ShowDemographics.ChangeAndAdd)
                {
                    groupAddPt.Visible = false;
                }
            }
            else
            {
                if (Programs.UsingEcwTightOrFullMode())
                {
                    groupAddPt.Visible = false;
                }
            }
            comboBillingType.Items.Add(Lan.g(this, "All"));
            comboBillingType.SelectedIndex = 0;
            for (int i = 0; i < DefC.Short[(int)DefCat.BillingTypes].Length; i++)
            {
                comboBillingType.Items.Add(DefC.Short[(int)DefCat.BillingTypes][i].ItemName);
            }
            if (PrefC.GetBool(PrefName.EasyHidePublicHealth))
            {
                comboSite.Visible = false;
                labelSite.Visible = false;
            }
            else
            {
                comboSite.Items.Add(Lan.g(this, "All"));
                comboSite.SelectedIndex = 0;
                for (int i = 0; i < SiteC.List.Length; i++)
                {
                    comboSite.Items.Add(SiteC.List[i].Description);
                }
            }
            if (PrefC.GetBool(PrefName.EasyNoClinics))
            {
                labelClinic.Visible = false;
                comboClinic.Visible = false;
            }
            else
            {
                //if the current user is restricted to a clinic (or in the future many clinics), All will refer to only those clinics the user has access to. May only be one clinic.
                comboClinic.Items.Add(Lan.g(this, "All"));
                comboClinic.SelectedIndex = 0;
                _listClinics = Clinics.GetForUserod(Security.CurUser);//could be only one if the user is restricted
                for (int i = 0; i < _listClinics.Count; i++)
                {
                    comboClinic.Items.Add(_listClinics[i].Abbr);
                    if (Clinics.ClinicNum == _listClinics[i].ClinicNum)
                    {
                        comboClinic.SelectedIndex = i + 1;
                    }
                }
            }
            FillSearchOption();
            SetGridCols();
            if (ExplicitPatNums != null && ExplicitPatNums.Count > 0)
            {
                FillGrid(false, ExplicitPatNums);
                return;
            }
            if (InitialPatNum != 0)
            {
                Patient iPatient = Patients.GetLim(InitialPatNum);
                textLName.Text = iPatient.LName;
                FillGrid(false);
                /*if(grid2.CurrentRowIndex>-1){
					grid2.UnSelect(grid2.CurrentRowIndex);
				}
				for(int i=0;i<PtDataTable.Rows.Count;i++){
					if(PIn.PInt(PtDataTable.Rows[i][0].ToString())==InitialPatNum){
						grid2.CurrentRowIndex=i;
						grid2.Select(i);
						break;
					}
				}*/
                return;
            }
            //Always fillGrid if _isPreFilledLoad.  Since the first name and last name are pre-filled, the results should be minimal.
            if (checkRefresh.Checked || _isPreFillLoad)
            {
                FillGrid(true);
                _isPreFillLoad = false;
            }

            if (cmbProc.Items.Count == 0)
            {
                fill_cmbProc();
            }
           if (pc != "") { pc = "";}
           if (SelectedPatNum != 0)
            {
                SelectedPatNum = 0;
            }

            dateStartPick.Value = DateTime.Today.AddYears(-1);
            dsVAL = dateStartPick.Value.ToShortDateString();
            deVAL = dateEndPick.Value.ToShortDateString();

        }

        ///<summary>This used to be called all the time, now only needs to be called on load.</summary>
        private void FillSearchOption()
        {
            _computerPref = ComputerPrefs.LocalComputer;  //This is the computerprefs for this local computer.
            switch (_computerPref.PatSelectSearchMode)
            {
                case SearchMode.Default:
                    checkRefresh.Checked = !PrefC.GetBool(PrefName.PatientSelectUsesSearchButton);//Use global preference
                    break;
                case SearchMode.RefreshWhileTyping:
                    checkRefresh.Checked = true;
                    break;
                case SearchMode.UseSearchButton:
                default:
                    checkRefresh.Checked = false;
                    break;
            }
        }

        private void SetGridCols()
        {
            //This pattern is wrong.
            gridMain.BeginUpdate();
            gridMain.Columns.Clear();
            ODGridColumn col;
            fields = DisplayFields.GetForCategory(DisplayFieldCategory.PatientSelect);
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Description == "")
                {
                    col = new ODGridColumn(fields[i].InternalName, fields[i].ColumnWidth);
                }
                else
                {
                    col = new ODGridColumn(fields[i].Description, fields[i].ColumnWidth);
                }
                gridMain.Columns.Add(col);
            }
            gridMain.EndUpdate();
        }

        ///<summary>The pat must not be null.  Takes a partially built patient object and uses it to fill the search by textboxes.
        ///Currently only implements FName,LName.</summary>
        public void PreFillSearchBoxes(Patient pat)
        {
            _isPreFillLoad = true; //Set to true to stop FillGrid from being called as a result of textChanged events
            if (pat.LName != "")
            {
                textLName.Text = pat.LName;
            }
            if (pat.FName != "")
            {
                textFName.Text = pat.FName;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            selectedTxtBox = (TextBox)sender;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            //selectedTxtBox=null;
        }

        private void contrKeyboard1_MouseDown(object sender, MouseEventArgs e)
        {
            //this happens before contrKeyboard gets focus
            /*foreach(Control control in this.Controls) {
				if(control.){
					if(control.GetType()==typeof(TextBox)) {
						selectedTxtBox=(TextBox)control;
					}
				}
			}*/
        }

        private void contrKeyboard1_KeyClick(object sender, OpenDental.User_Controls.KeyboardClickEventArgs e)
        {
            //MessageBox.Show(contrKeyboard1.CanFocus.ToString());
            //get the control with focus
            /*Control ctrl=null;
			foreach(Control control in this.Controls) {
				if(control.Focused) {
					ctrl=control;
				}
			}*/
            if (selectedTxtBox == null)
            {
                return;
            }
            //if(ctrl.GetType()!=typeof(TextBox)) {
            //	return;
            //}
            //this is all quick and dirty, totally ignoring the cursor position
            if (e.KeyData == Keys.Back)
            {
                if (selectedTxtBox.Text.Length > 0)
                {
                    selectedTxtBox.Text = selectedTxtBox.Text.Remove(selectedTxtBox.Text.Length - 1);
                }
            }
            else
            {
                if (selectedTxtBox.Text.Length == 0)
                {
                    selectedTxtBox.Text = selectedTxtBox.Text + e.Txt;
                }
                else
                {
                    selectedTxtBox.Text = selectedTxtBox.Text + e.Txt.ToLower();
                }
            }
            selectedTxtBox.Focus();
            selectedTxtBox.Select(selectedTxtBox.Text.Length, 0);//the end
        }

        private void textLName_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textFName_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textHmPhone_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textWkPhone_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textAddress_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textCity_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textState_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textSSN_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textPatNum_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textChartNumber_TextChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void textBirthdate_TextChanged(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void textSubscriberID_TextChanged(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void textCountry_TextChanged(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void textRegKey_TextChanged(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void comboBillingType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void comboSite_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void comboClinic_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void checkGuarantors_CheckedChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void checkHideInactive_CheckedChanged(object sender, System.EventArgs e)
        {
            OnDataEntered();
        }

        private void checkShowArchived_CheckedChanged(object sender, EventArgs e)
        {
            OnDataEntered();
        }

        private void textLName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }


        private void textFName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void gridMain_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textHmPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textSSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textPatNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textChartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textBirthdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void textCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(sender, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void checkRefresh_Click(object sender, EventArgs e)
        {
            if (checkRefresh.Checked)
            {
                _computerPref.PatSelectSearchMode = SearchMode.RefreshWhileTyping;
                FillGrid(true);
            }
            else
            {
                _computerPref.PatSelectSearchMode = SearchMode.UseSearchButton;
            }
            ComputerPrefs.Update(_computerPref);
        }

        private void butSearch_Click(object sender, System.EventArgs e)
        {
            FillGrid(true);
        }

        private void butGetAll_Click(object sender, EventArgs e)
        {
            FillGrid(false);
        }




        private void OnDataEntered()
        {
            //Do not call FillGrid unless _isPreFillLoad=false.  Since the first name and last name are pre-filled, the results should be minimal.
            if (checkRefresh.Checked && !_isPreFillLoad)
            {
                FillGrid(true);
            }
        }

        private void FillGrid(bool limit, List<long> explicitPatNums = null)
        {
            _dateTimeLastRequest = DateTime.Now;
            if (_fillGridThread != null)
            {
                return;
            }
            _dateTimeLastSearch = _dateTimeLastRequest;
            long billingType = 0;
            if (comboBillingType.SelectedIndex != 0)
            {
                billingType = DefC.Short[(int)DefCat.BillingTypes][comboBillingType.SelectedIndex - 1].DefNum;
            }
            long siteNum = 0;
            if (!PrefC.GetBool(PrefName.EasyHidePublicHealth) && comboSite.SelectedIndex != 0)
            {
                siteNum = SiteC.List[comboSite.SelectedIndex - 1].SiteNum;
            }

            DateTime birthdate = PIn.Date(textBirthdate.Text); //this will frequently be minval.
            if (birthdate == null)
            {
                return;
            }
            string clinicNums = "";
            if (!PrefC.GetBool(PrefName.EasyNoClinics))
            {
                if (comboClinic.SelectedIndex == 0)
                {
                    for (int i = 0; i < _listClinics.Count; i++)
                    {
                        if (i > 0)
                        {
                            clinicNums += ",";
                        }
                        clinicNums += _listClinics[i].ClinicNum;
                    }
                }
                else
                {
                    clinicNums = _listClinics[comboClinic.SelectedIndex - 1].ClinicNum.ToString();
                }
            }
            _fillGridThread = new ODThread(new ODThread.WorkerDelegate((ODThread o) => {
                PtDataTable = Patients.GetPtDataTable(limit, textLName.Text, textFName.Text, textHmPhone.Text,
                    textAddress.Text, checkHideInactive.Checked, textCity.Text, textState.Text,
                    textSSN.Text, textPatNum.Text, textChartNumber.Text, billingType,
                    checkGuarantors.Checked, checkShowArchived.Checked,
                    birthdate, siteNum, textSubscriberID.Text, textEmail.Text, textCountry.Text, textRegKey.Text, clinicNums, explicitPatNums, InitialPatNum);
            }));
            _fillGridThread.AddThreadExitHandler(new ODThread.WorkerDelegate((ODThread o) => {
                _fillGridThread = null;
                try
                {
                    this.BeginInvoke((Action)(() => {
                        FillGridFinal(limit);
                    }));
                }
                catch (Exception) { } //do nothing. Usually just a race condition trying to invoke from a disposed form.
            }));
            _fillGridThread.AddExceptionHandler(new ODThread.ExceptionDelegate((e) => {
                try
                {
                    this.BeginInvoke((Action)(() => {
                        MessageBox.Show(e.Message);
                    }));
                }
                catch (Exception) { } //do nothing. Usually just a race condition trying to invoke from a disposed form.
            }));
            _fillGridThread.Start(true);
        }

        private void FillGridFinal(bool limit)
        {
            //long billingType=0;
            //if(comboBillingType.SelectedIndex!=0) {
            //	billingType=DefC.Short[(int)DefCat.BillingTypes][comboBillingType.SelectedIndex-1].DefNum;
            //}
            //long siteNum=0;
            //if(!PrefC.GetBool(PrefName.EasyHidePublicHealth) && comboSite.SelectedIndex!=0) {
            //	siteNum=SiteC.List[comboSite.SelectedIndex-1].SiteNum;
            //}
            //DateTime birthdate=PIn.Date(textBirthdate.Text); //this will frequently be minval.
            //string clinicNums="";
            //if(!PrefC.GetBool(PrefName.EasyNoClinics)) {
            //	if(comboClinic.SelectedIndex==0) {
            //		for(int i=0;i<_listClinics.Count;i++) {
            //			if(i>0) {
            //				clinicNums+=",";
            //			}
            //			clinicNums+=_listClinics[i].ClinicNum;
            //		}
            //	}
            //	else {
            //		clinicNums=_listClinics[comboClinic.SelectedIndex-1].ClinicNum.ToString();
            //	}
            //}
            //	PtDataTable=Patients.GetPtDataTable(limit,textLName.Text,textFName.Text,textHmPhone.Text,
            //		textAddress.Text,checkHideInactive.Checked,textCity.Text,textState.Text,
            //		textSSN.Text,textPatNum.Text,textChartNumber.Text,billingType,
            //		checkGuarantors.Checked,checkShowArchived.Checked,
            //		birthdate,siteNum,textSubscriberID.Text,textEmail.Text,textCountry.Text,textRegKey.Text,clinicNums,explicitPatNums);
            if (InitialPatNum != 0 && limit)
            {
                //The InitialPatNum will be at the top, so resort the list alphabetically
                DataView ptDataView = PtDataTable.DefaultView;
                ptDataView.Sort = "LName,FName";
                PtDataTable = ptDataView.ToTable();
            }
            gridMain.BeginUpdate();
            gridMain.Rows.Clear();
            ODGridRow row;
            for (int i = 0; i < PtDataTable.Rows.Count; i++)
            {
                row = new ODGridRow();
                for (int f = 0; f < fields.Count; f++)
                {
                    switch (fields[f].InternalName)
                    {
                        case "LastName":
                            row.Cells.Add(PtDataTable.Rows[i]["LName"].ToString());
                            break;
                        case "First Name":
                            row.Cells.Add(PtDataTable.Rows[i]["FName"].ToString());
                            break;
                        case "MI":
                            row.Cells.Add(PtDataTable.Rows[i]["MiddleI"].ToString());
                            break;
                        case "Pref Name":
                            row.Cells.Add(PtDataTable.Rows[i]["Preferred"].ToString());
                            break;
                        case "Age":
                            row.Cells.Add(PtDataTable.Rows[i]["age"].ToString());
                            break;
                        case "SSN":
                            row.Cells.Add(PtDataTable.Rows[i]["SSN"].ToString());
                            break;
                        case "Hm Phone":
                            row.Cells.Add(PtDataTable.Rows[i]["HmPhone"].ToString());
                            if (Programs.GetCur(ProgramName.DentalTekSmartOfficePhone).Enabled)
                            {
                                row.Cells[row.Cells.Count - 1].ColorText = Color.Blue;
                                row.Cells[row.Cells.Count - 1].Underline = YN.Yes;
                            }
                            break;
                        case "Wk Phone":
                            row.Cells.Add(PtDataTable.Rows[i]["WkPhone"].ToString());
                            if (Programs.GetCur(ProgramName.DentalTekSmartOfficePhone).Enabled)
                            {
                                row.Cells[row.Cells.Count - 1].ColorText = Color.Blue;
                                row.Cells[row.Cells.Count - 1].Underline = YN.Yes;
                            }
                            break;
                        case "PatNum":
                            row.Cells.Add(PtDataTable.Rows[i]["PatNum"].ToString());
                            break;
                        case "ChartNum":
                            row.Cells.Add(PtDataTable.Rows[i]["ChartNumber"].ToString());
                            break;
                        case "Address":
                            row.Cells.Add(PtDataTable.Rows[i]["Address"].ToString());
                            break;
                        case "Status":
                            row.Cells.Add(PtDataTable.Rows[i]["PatStatus"].ToString());
                            break;
                        case "Bill Type":
                            row.Cells.Add(PtDataTable.Rows[i]["BillingType"].ToString());
                            break;
                        case "City":
                            row.Cells.Add(PtDataTable.Rows[i]["City"].ToString());
                            break;
                        case "State":
                            row.Cells.Add(PtDataTable.Rows[i]["State"].ToString());
                            break;
                        case "Pri Prov":
                            row.Cells.Add(PtDataTable.Rows[i]["PriProv"].ToString());
                            break;
                        case "Clinic":
                            row.Cells.Add(PtDataTable.Rows[i]["clinic"].ToString());
                            break;
                        case "Birthdate":
                            row.Cells.Add(PtDataTable.Rows[i]["Birthdate"].ToString());
                            break;
                        case "Site":
                            row.Cells.Add(PtDataTable.Rows[i]["site"].ToString());
                            break;
                        case "Email":
                            row.Cells.Add(PtDataTable.Rows[i]["Email"].ToString());
                            break;
                        case "Country":
                            row.Cells.Add(PtDataTable.Rows[i]["Country"].ToString());
                            break;
                        case "RegKey":
                            row.Cells.Add(PtDataTable.Rows[i]["RegKey"].ToString());
                            break;
                        case "OtherPhone": //will only be available if OD HQ
                            row.Cells.Add(PtDataTable.Rows[i]["OtherPhone"].ToString());
                            break;
                        case "Wireless Ph":
                            row.Cells.Add(PtDataTable.Rows[i]["WirelessPhone"].ToString());
                            if (Programs.GetCur(ProgramName.DentalTekSmartOfficePhone).Enabled)
                            {
                                row.Cells[row.Cells.Count - 1].ColorText = Color.Blue;
                                row.Cells[row.Cells.Count - 1].Underline = YN.Yes;
                            }
                            break;
                        case "Sec Prov":
                            row.Cells.Add(PtDataTable.Rows[i]["SecProv"].ToString());
                            break;
                        case "LastVisit":
                            row.Cells.Add(PtDataTable.Rows[i]["lastVisit"].ToString());
                            break;
                        case "NextVisit":
                            row.Cells.Add(PtDataTable.Rows[i]["nextVisit"].ToString());
                            break;
                    }
                }
                gridMain.Rows.Add(row);
            }
            gridMain.EndUpdate();
            if (_dateTimeLastSearch != _dateTimeLastRequest)
            {
                FillGrid(limit);//in case data was entered while thread was running.
            }
           gridMain.SetSelected(0, true);
            for (int i = 0; i < PtDataTable.Rows.Count; i++)
            {
                if (PIn.Long(PtDataTable.Rows[i][0].ToString()) == InitialPatNum)
                {
                    gridMain.SetSelected(i, true);
                    break;
                }
            }
        }

        private void gridMain_CellDoubleClick(object sender, ODGridClickEventArgs e)
        {
            PatSelected();
        }

        private void gridMain_CellClick(object sender, ODGridClickEventArgs e)
        {
            ODGridCell gridCellCur = gridMain.Rows[e.Row].Cells[e.Col];
            //Only grid cells with phone numbers are blue and underlined.
            if (gridCellCur.ColorText == Color.Blue && gridCellCur.Underline == YN.Yes && Programs.GetCur(ProgramName.DentalTekSmartOfficePhone).Enabled)
            {
                DentalTek.PlaceCall(gridCellCur.Text);
            }

        }

        private void OnArrowsUpDown(System.Windows.Forms.KeyEventArgs e)
        {
            //I don't know if this is doing anything.
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                gridMain_KeyDown(this, e);
                gridMain.Invalidate();
                e.Handled = true;
            }
        }

        private void FormSelectPatient_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            OnArrowsUpDown(e);
        }





        private void PatSelected()
        {
            if (_fillGridThread != null)
            {
                return;//still filtering results (rarely happens)
            }
            //SelectedPatNum=PIn.PInt(PtDataTable.Rows[grid2.CurrentRowIndex][0].ToString());
            SelectedPatNum = PIn.Long(PtDataTable.Rows[gridMain.GetSelectedIndex()][0].ToString());
            SELECTNAME.Text = "Name: " + PIn.String(PtDataTable.Rows[gridMain.GetSelectedIndex()][2].ToString()) + " " + PIn.String(PtDataTable.Rows[gridMain.GetSelectedIndex()][1].ToString());


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
            DataTable tablePats = new DataTable();
            System.Diagnostics.Debug.WriteLine("SelectedPatNum is : " + SelectedPatNum);
            if (DateRangeCheck.Checked == false)
            {
                System.Diagnostics.Debug.WriteLine("No Date");
                if (SelectedPatNum != 0)
                {
                    System.Diagnostics.Debug.WriteLine("Using PatNum");
                    System.Diagnostics.Debug.WriteLine("SelectedPatNum is NOT zero : " + SelectedPatNum);



                    if (pc != "")
                    {
                        //NYY
                        System.Diagnostics.Debug.WriteLine("Using ProcCode");
                        tablePats = KPIRecTreatment.GetRecTreatmentNYY(SelectedPatNum, pc);
                    }

                    else if (pc == "")
                    {
                        //NYN
                        System.Diagnostics.Debug.WriteLine("No ProcCode");
                        tablePats = KPIRecTreatment.GetRecTreatmentNYN(SelectedPatNum);
                    }
                }
                else if (SelectedPatNum == 0)
                
                {
                    System.Diagnostics.Debug.WriteLine("No PatNum");
                    System.Diagnostics.Debug.WriteLine("SelectedPatNum is zero : " + SelectedPatNum);


                    if (pc != "")
                    {
                        // NNY
                        System.Diagnostics.Debug.WriteLine("Using ProcCode");
                        tablePats = KPIRecTreatment.GetRecTreatmentNNY(pc);

                    }

                    else if (pc == "")
                    {
                        // NNN
                        System.Diagnostics.Debug.WriteLine("Nothing");
                        tablePats = KPIRecTreatment.GetRecTreatmentNNN();

                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Using Date");
                System.Diagnostics.Debug.WriteLine("SelectedPatNum is : " + SelectedPatNum);


                if (SelectedPatNum != 0)
                {
                    System.Diagnostics.Debug.WriteLine("Using PatNum");
                    System.Diagnostics.Debug.WriteLine("SelectedPatNum is NOT zero : " + SelectedPatNum);


                    if (pc != "")
                    {
                        // YYY
                        System.Diagnostics.Debug.WriteLine("Using ProcCode");
                        System.Diagnostics.Debug.WriteLine("SelectedPatNum is : " + SelectedPatNum);

                        tablePats = KPIRecTreatment.GetRecTreatmentYYY(dateStartPick.Value.Date, dateEndPick.Value.Date,
                            pc, SelectedPatNum);
                    }
                    else if (pc == "")
                    {
                        // YYN
                        System.Diagnostics.Debug.WriteLine("No ProcCode");
                        tablePats = KPIRecTreatment.GetRecTreatmentYYN(dateStartPick.Value.Date, dateEndPick.Value.Date,
                            SelectedPatNum);
                    }
                }

                else if (SelectedPatNum == 0)
                {
                    System.Diagnostics.Debug.WriteLine("No PatNum");
                    System.Diagnostics.Debug.WriteLine("SelectedPatNum is zero : " + SelectedPatNum);


                    if (pc != "")
                    {
                        // YNY
                        System.Diagnostics.Debug.WriteLine("Using ProcCode");
                        tablePats = KPIRecTreatment.GetRecTreatmentYNY(dateStartPick.Value.Date, dateEndPick.Value.Date,
                            pc);
                    }

                    else if (pc == "")
                    {
                        // YNN
                        System.Diagnostics.Debug.WriteLine("No ProcCode");
                        tablePats = KPIRecTreatment.GetRecTreatmentYNN(dateStartPick.Value.Date, dateEndPick.Value.Date);
                    }
                }
            }
        


            ReportComplex report = new ReportComplex(true, false);
            report.ReportName = Lan.g(this, "Types of Treatment Prescribed/Recommended");
            report.AddTitle("Title", Lan.g(this, "Types of Treatment Prescribed/Recommended"));

            if (DateRangeCheck.Checked == false)
            { report.AddSubTitle("No Date Selected", "ALL DATES"); }

            else if (DateRangeCheck.Checked == true)
            {
                report.AddSubTitle("Date", SELECTDATE.Text);

            }
            if (SelectedPatNum != 0)
            {
                report.AddSubTitle("Name", SELECTNAME.Text);
            }

            else if (SelectedPatNum == 0)
            {
                report.AddSubTitle("Name", "ALL PATIENTS");
            }

            if (pc != "")
            {
                report.AddSubTitle("ProcedureCode", SELECTPROC.Text);
            }

            else if (pc =="")
            {
                report.AddSubTitle("ProcedureCode", "ALL PROCEDURES");
            }

            QueryObject query;
            query = report.AddQuery(tablePats, "", "", SplitByKind.None, 0);
            query.AddColumn("Date of Service", 100, FieldValueType.String);
            query.AddColumn("Name", 150, FieldValueType.String);
            query.AddColumn("Procedure", 40, FieldValueType.String);
            query.AddColumn("Priority", 90, FieldValueType.String);
            query.AddColumn("Status of Pre-Authorization", 80, FieldValueType.String);
            report.AddPageNum();
            if (!report.SubmitQueries())
            {
                return;
            }
            FormReportComplex FormR = new FormReportComplex(report);
            FormR.ShowDialog();
            DialogResult=DialogResult.OK;
            
        }

        private void butCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            // procedure code combobox
        {
                pc = cmbProc.SelectedItem.ToString();
                SELECTPROC.Text = "Procedure Code: " + cmbProc.SelectedItem.ToString();
        }

        private void combobox1_SelectedValueChanged(object sender, EventArgs e)
        {
            pc = cmbProc.SelectedItem.ToString();
            SELECTPROC.Text = "Procedure Code: " + cmbProc.SelectedItem.ToString();
        }

        private void dateStartPick_ValueChanged(object sender, EventArgs e)
        {
            if (dateEndPick.Value < dateStartPick.Value)
            {
                MessageBox.Show("Date End cannot be before Date Start");

            }
            else if (DateRangeCheck.Checked == true && dateEndPick.Value > dateStartPick.Value)
            {
                dsVAL = dateStartPick.Value.ToShortDateString();
                SELECTDATE.Text = "Date Range: " + dsVAL + " - " + deVAL;
            }

            else
            {
                dsVAL = dateStartPick.Value.ToShortDateString();
            }


        }

        private void dateEndPick_ValueChanged(object sender, EventArgs e)
        {
            if (dateEndPick.Value < dateStartPick.Value)
            {
                MessageBox.Show("Date End cannot be before Date Start");

            }
            else if (DateRangeCheck.Checked == true && dateEndPick.Value > dateStartPick.Value)
            {
                deVAL = dateEndPick.Value.ToShortDateString();
                SELECTDATE.Text = "Date Range: " + dsVAL + " - " + deVAL;
            }
            else
            {
                deVAL = dateEndPick.Value.ToShortDateString();
            }

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void DateRangeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DateRangeCheck.Checked == true)
            {
                SELECTDATE.Text = "Date Range: " + dsVAL + " - " + deVAL;

            }
            else
            {
                SELECTDATE.Text = "Date Range: (DEFAULT ALL)";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
