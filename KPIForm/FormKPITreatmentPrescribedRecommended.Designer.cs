using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace KPIReporting.KPIForm

{

    public partial class FormKPIRecTreatment
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textLName = new System.Windows.Forms.TextBox();
            this.LNameLabel = new System.Windows.Forms.Label();
            this.groupAddPt = new System.Windows.Forms.GroupBox();
            this.butAddAll = new OpenDental.UI.Button();
            this.butAddPt = new OpenDental.UI.Button();
            this.butOK = new OpenDental.UI.Button();
            this.butCancel = new OpenDental.UI.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DateRangeCheck = new System.Windows.Forms.CheckBox();
            this.DateEndLabel = new System.Windows.Forms.Label();
            this.DateStartLabel = new System.Windows.Forms.Label();
            this.dateEndPick = new System.Windows.Forms.DateTimePicker();
            this.dateStartPick = new System.Windows.Forms.DateTimePicker();
            this.ProcCodeLabel = new System.Windows.Forms.Label();
            this.cmbProc = new System.Windows.Forms.ComboBox();
            this.textFName = new System.Windows.Forms.TextBox();
            this.FNameLabel = new System.Windows.Forms.Label();
            this.procedurecodeBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.opendentalDataSet1 = new OpenDental.opendentalDataSet1();
            this.textRegKey = new System.Windows.Forms.TextBox();
            this.comboClinic = new System.Windows.Forms.ComboBox();
            this.labelClinic = new System.Windows.Forms.Label();
            this.textCountry = new System.Windows.Forms.TextBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textSubscriberID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboSite = new System.Windows.Forms.ComboBox();
            this.labelSite = new System.Windows.Forms.Label();
            this.comboBillingType = new System.Windows.Forms.ComboBox();
            this.textBirthdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkShowArchived = new System.Windows.Forms.CheckBox();
            this.textChartNumber = new System.Windows.Forms.TextBox();
            this.textSSN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textPatNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textState = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkGuarantors = new System.Windows.Forms.CheckBox();
            this.checkHideInactive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textHmPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.procedurecodeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.opendentalDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opendentalDataSet = new OpenDental.opendentalDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkRefresh = new System.Windows.Forms.CheckBox();
            this.butSearch = new OpenDental.UI.Button();
            this.gridMain = new OpenDental.UI.ODGrid();
            this.contrKeyboard1 = new OpenDental.User_Controls.ContrKeyboard();
            this.procedurecodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.procedurecodeTableAdapter = new OpenDental.opendentalDataSetTableAdapters.procedurecodeTableAdapter();
            this.procedurecodeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.procedurecodeTableAdapter1 = new OpenDental.opendentalDataSet1TableAdapters.procedurecodeTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.SELECTNAME = new System.Windows.Forms.Label();
            this.SELECTPROC = new System.Windows.Forms.Label();
            this.SELECTDATE = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendentalDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendentalDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendentalDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource2)).BeginInit();
            this.SuspendLayout();
            //
            // textLName
            //
            this.textLName.Location = new System.Drawing.Point(130, 17);
            this.textLName.Name = "textLName";
            this.textLName.Size = new System.Drawing.Size(178, 20);
            this.textLName.TabIndex = 0;
            this.textLName.TextChanged += new System.EventHandler(this.textLName_TextChanged);
            this.textLName.Enter += new System.EventHandler(this.textBox_Enter);
            this.textLName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textLName_KeyDown);
            this.textLName.Leave += new System.EventHandler(this.textBox_Leave);
            //
            // LNameLabel
            //
            this.LNameLabel.Location = new System.Drawing.Point(21, 19);
            this.LNameLabel.Name = "LNameLabel";
            this.LNameLabel.Size = new System.Drawing.Size(76, 17);
            this.LNameLabel.TabIndex = 3;
            this.LNameLabel.Text = "Last Name";
            this.LNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // groupAddPt
            //
            this.groupAddPt.Location = new System.Drawing.Point(0, 0);
            this.groupAddPt.Name = "groupAddPt";
            this.groupAddPt.Size = new System.Drawing.Size(200, 100);
            this.groupAddPt.TabIndex = 22;
            this.groupAddPt.TabStop = false;
            //
            // butAddAll
            //
            this.butAddAll.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butAddAll.Autosize = true;
            this.butAddAll.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butAddAll.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butAddAll.CornerRadius = 4F;
            this.butAddAll.Location = new System.Drawing.Point(0, 0);
            this.butAddAll.Name = "butAddAll";
            this.butAddAll.Size = new System.Drawing.Size(75, 23);
            this.butAddAll.TabIndex = 0;
            //
            // butAddPt
            //
            this.butAddPt.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butAddPt.Autosize = true;
            this.butAddPt.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butAddPt.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butAddPt.CornerRadius = 4F;
            this.butAddPt.Location = new System.Drawing.Point(0, 0);
            this.butAddPt.Name = "butAddPt";
            this.butAddPt.Size = new System.Drawing.Size(75, 23);
            this.butAddPt.TabIndex = 0;
            //
            // butOK
            //
            this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Autosize = true;
            this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butOK.CornerRadius = 4F;
            this.butOK.Location = new System.Drawing.Point(766, 493);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(76, 26);
            this.butOK.TabIndex = 20;
            this.butOK.Text = "&OK";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            //
            // butCancel
            //
            this.butCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Autosize = true;
            this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butCancel.CornerRadius = 4F;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(894, 493);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(76, 26);
            this.butCancel.TabIndex = 21;
            this.butCancel.Text = "&Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            //
            // groupBox2
            //
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DateRangeCheck);
            this.groupBox2.Controls.Add(this.DateEndLabel);
            this.groupBox2.Controls.Add(this.DateStartLabel);
            this.groupBox2.Controls.Add(this.dateEndPick);
            this.groupBox2.Controls.Add(this.dateStartPick);
            this.groupBox2.Controls.Add(this.ProcCodeLabel);
            this.groupBox2.Controls.Add(this.cmbProc);
            this.groupBox2.Controls.Add(this.textFName);
            this.groupBox2.Controls.Add(this.FNameLabel);
            this.groupBox2.Controls.Add(this.textLName);
            this.groupBox2.Controls.Add(this.LNameLabel);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(712, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 178);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by:";
            //
            // DateRangeCheck
            //
            this.DateRangeCheck.AutoSize = true;
            this.DateRangeCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DateRangeCheck.Location = new System.Drawing.Point(24, 96);
            this.DateRangeCheck.Name = "DateRangeCheck";
            this.DateRangeCheck.Size = new System.Drawing.Size(106, 17);
            this.DateRangeCheck.TabIndex = 87;
            this.DateRangeCheck.Text = "Use Date Range";
            this.DateRangeCheck.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DateRangeCheck.UseVisualStyleBackColor = true;
            this.DateRangeCheck.CheckedChanged += new System.EventHandler(this.DateRangeCheck_CheckedChanged);
            //
            // DateEndLabel
            //
            this.DateEndLabel.AutoSize = true;
            this.DateEndLabel.Location = new System.Drawing.Point(21, 148);
            this.DateEndLabel.Name = "DateEndLabel";
            this.DateEndLabel.Size = new System.Drawing.Size(52, 13);
            this.DateEndLabel.TabIndex = 23;
            this.DateEndLabel.Text = "Date End";
            //
            // DateStartLabel
            //
            this.DateStartLabel.AutoSize = true;
            this.DateStartLabel.Location = new System.Drawing.Point(21, 121);
            this.DateStartLabel.Name = "DateStartLabel";
            this.DateStartLabel.Size = new System.Drawing.Size(55, 13);
            this.DateStartLabel.TabIndex = 85;
            this.DateStartLabel.Text = "Date Start";
            this.DateStartLabel.Click += new System.EventHandler(this.label15_Click);
            //
            // dateEndPick
            //
            this.dateEndPick.Location = new System.Drawing.Point(130, 144);
            this.dateEndPick.Name = "dateEndPick";
            this.dateEndPick.Size = new System.Drawing.Size(178, 20);
            this.dateEndPick.TabIndex = 84;
            this.dateEndPick.ValueChanged += new System.EventHandler(this.dateEndPick_ValueChanged);
            //
            // dateStartPick
            //
            this.dateStartPick.Location = new System.Drawing.Point(130, 118);
            this.dateStartPick.Name = "dateStartPick";
            this.dateStartPick.Size = new System.Drawing.Size(178, 20);
            this.dateStartPick.TabIndex = 83;
            this.dateStartPick.ValueChanged += new System.EventHandler(this.dateStartPick_ValueChanged);
            //
            // ProcCodeLabel
            //
            this.ProcCodeLabel.AutoSize = true;
            this.ProcCodeLabel.Location = new System.Drawing.Point(21, 74);
            this.ProcCodeLabel.Name = "ProcCodeLabel";
            this.ProcCodeLabel.Size = new System.Drawing.Size(84, 13);
            this.ProcCodeLabel.TabIndex = 82;
            this.ProcCodeLabel.Text = "Procedure Code";
            this.ProcCodeLabel.Click += new System.EventHandler(this.label14_Click);
            //
            // cmbProc
            //
            this.cmbProc.DisplayMember = "pc";
            this.cmbProc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProc.FormattingEnabled = true;
            this.cmbProc.Location = new System.Drawing.Point(130, 69);
            this.cmbProc.Name = "cmbProc";
            this.cmbProc.Size = new System.Drawing.Size(178, 21);
            this.cmbProc.TabIndex = 81;
            this.cmbProc.ValueMember = "pc";
            this.cmbProc.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cmbProc.SelectedValueChanged += new System.EventHandler(this.combobox1_SelectedValueChanged);
            //
            // textFName
            //
            this.textFName.Location = new System.Drawing.Point(130, 43);
            this.textFName.Name = "textFName";
            this.textFName.Size = new System.Drawing.Size(178, 20);
            this.textFName.TabIndex = 1;
            this.textFName.TextChanged += new System.EventHandler(this.textFName_TextChanged);
            this.textFName.Enter += new System.EventHandler(this.textBox_Enter);
            this.textFName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textFName_KeyDown);
            //
            // FNameLabel
            //
            this.FNameLabel.Location = new System.Drawing.Point(21, 44);
            this.FNameLabel.Name = "FNameLabel";
            this.FNameLabel.Size = new System.Drawing.Size(76, 16);
            this.FNameLabel.TabIndex = 5;
            this.FNameLabel.Text = "First Name";
            this.FNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // procedurecodeBindingSource3
            //
            this.procedurecodeBindingSource3.DataMember = "procedurecode";
            this.procedurecodeBindingSource3.DataSource = this.opendentalDataSet1;
            //
            // opendentalDataSet1
            //
            this.opendentalDataSet1.DataSetName = "opendentalDataSet1";
            this.opendentalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            //
            // textRegKey
            //
            this.textRegKey.Location = new System.Drawing.Point(872, 0);
            this.textRegKey.Name = "textRegKey";
            this.textRegKey.Size = new System.Drawing.Size(10, 20);
            this.textRegKey.TabIndex = 49;
            this.textRegKey.Visible = false;
            this.textRegKey.TextChanged += new System.EventHandler(this.textRegKey_TextChanged);
            //
            // comboClinic
            //
            this.comboClinic.Location = new System.Drawing.Point(872, 0);
            this.comboClinic.Name = "comboClinic";
            this.comboClinic.Size = new System.Drawing.Size(10, 21);
            this.comboClinic.TabIndex = 51;
            //
            // labelClinic
            //
            this.labelClinic.Location = new System.Drawing.Point(872, 0);
            this.labelClinic.Name = "labelClinic";
            this.labelClinic.Size = new System.Drawing.Size(10, 23);
            this.labelClinic.TabIndex = 52;
            //
            // textCountry
            //
            this.textCountry.Location = new System.Drawing.Point(872, 0);
            this.textCountry.Name = "textCountry";
            this.textCountry.Size = new System.Drawing.Size(10, 20);
            this.textCountry.TabIndex = 53;
            //
            // labelCountry
            //
            this.labelCountry.Location = new System.Drawing.Point(872, 0);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(10, 23);
            this.labelCountry.TabIndex = 54;
            //
            // textEmail
            //
            this.textEmail.Location = new System.Drawing.Point(872, 0);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(10, 20);
            this.textEmail.TabIndex = 53;
            //
            // labelEmail
            //
            this.labelEmail.Location = new System.Drawing.Point(872, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(10, 23);
            this.labelEmail.TabIndex = 54;
            //
            // textSubscriberID
            //
            this.textSubscriberID.Location = new System.Drawing.Point(872, 0);
            this.textSubscriberID.Name = "textSubscriberID";
            this.textSubscriberID.Size = new System.Drawing.Size(10, 20);
            this.textSubscriberID.TabIndex = 55;
            //
            // label13
            //
            this.label13.Location = new System.Drawing.Point(872, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 23);
            this.label13.TabIndex = 56;
            //
            // comboSite
            //
            this.comboSite.Location = new System.Drawing.Point(872, 0);
            this.comboSite.Name = "comboSite";
            this.comboSite.Size = new System.Drawing.Size(10, 21);
            this.comboSite.TabIndex = 57;
            //
            // labelSite
            //
            this.labelSite.Location = new System.Drawing.Point(872, 0);
            this.labelSite.Name = "labelSite";
            this.labelSite.Size = new System.Drawing.Size(10, 23);
            this.labelSite.TabIndex = 58;
            //
            // comboBillingType
            //
            this.comboBillingType.Location = new System.Drawing.Point(872, 0);
            this.comboBillingType.Name = "comboBillingType";
            this.comboBillingType.Size = new System.Drawing.Size(10, 21);
            this.comboBillingType.TabIndex = 59;
            //
            // textBirthdate
            //
            this.textBirthdate.Location = new System.Drawing.Point(872, 0);
            this.textBirthdate.Name = "textBirthdate";
            this.textBirthdate.Size = new System.Drawing.Size(10, 20);
            this.textBirthdate.TabIndex = 60;
            //
            // label2
            //
            this.label2.Location = new System.Drawing.Point(872, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 23);
            this.label2.TabIndex = 61;
            //
            // checkShowArchived
            //
            this.checkShowArchived.Location = new System.Drawing.Point(872, 0);
            this.checkShowArchived.Name = "checkShowArchived";
            this.checkShowArchived.Size = new System.Drawing.Size(10, 24);
            this.checkShowArchived.TabIndex = 62;
            //
            // textChartNumber
            //
            this.textChartNumber.Location = new System.Drawing.Point(872, 0);
            this.textChartNumber.Name = "textChartNumber";
            this.textChartNumber.Size = new System.Drawing.Size(10, 20);
            this.textChartNumber.TabIndex = 63;
            //
            // textSSN
            //
            this.textSSN.Location = new System.Drawing.Point(872, 0);
            this.textSSN.Name = "textSSN";
            this.textSSN.Size = new System.Drawing.Size(10, 20);
            this.textSSN.TabIndex = 64;
            //
            // label12
            //
            this.label12.Location = new System.Drawing.Point(872, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 23);
            this.label12.TabIndex = 65;
            //
            // label11
            //
            this.label11.Location = new System.Drawing.Point(872, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 23);
            this.label11.TabIndex = 66;
            //
            // label10
            //
            this.label10.Location = new System.Drawing.Point(872, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 23);
            this.label10.TabIndex = 67;
            //
            // textPatNum
            //
            this.textPatNum.Location = new System.Drawing.Point(872, 0);
            this.textPatNum.Name = "textPatNum";
            this.textPatNum.Size = new System.Drawing.Size(10, 20);
            this.textPatNum.TabIndex = 68;
            //
            // label9
            //
            this.label9.Location = new System.Drawing.Point(872, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 23);
            this.label9.TabIndex = 69;
            //
            // textState
            //
            this.textState.Location = new System.Drawing.Point(872, 0);
            this.textState.Name = "textState";
            this.textState.Size = new System.Drawing.Size(10, 20);
            this.textState.TabIndex = 70;
            //
            // label8
            //
            this.label8.Location = new System.Drawing.Point(872, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 23);
            this.label8.TabIndex = 71;
            //
            // textCity
            //
            this.textCity.Location = new System.Drawing.Point(872, 0);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(10, 20);
            this.textCity.TabIndex = 72;
            //
            // label7
            //
            this.label7.Location = new System.Drawing.Point(872, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 23);
            this.label7.TabIndex = 73;
            //
            // checkGuarantors
            //
            this.checkGuarantors.Location = new System.Drawing.Point(872, 0);
            this.checkGuarantors.Name = "checkGuarantors";
            this.checkGuarantors.Size = new System.Drawing.Size(10, 24);
            this.checkGuarantors.TabIndex = 74;
            //
            // checkHideInactive
            //
            this.checkHideInactive.Location = new System.Drawing.Point(872, 0);
            this.checkHideInactive.Name = "checkHideInactive";
            this.checkHideInactive.Size = new System.Drawing.Size(10, 24);
            this.checkHideInactive.TabIndex = 75;
            //
            // label6
            //
            this.label6.Location = new System.Drawing.Point(872, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 23);
            this.label6.TabIndex = 76;
            //
            // textAddress
            //
            this.textAddress.Location = new System.Drawing.Point(872, 0);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(10, 20);
            this.textAddress.TabIndex = 77;
            //
            // label5
            //
            this.label5.Location = new System.Drawing.Point(872, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 23);
            this.label5.TabIndex = 78;
            //
            // textHmPhone
            //
            this.textHmPhone.Location = new System.Drawing.Point(872, 0);
            this.textHmPhone.Name = "textHmPhone";
            this.textHmPhone.Size = new System.Drawing.Size(10, 20);
            this.textHmPhone.TabIndex = 79;
            //
            // label4
            //
            this.label4.Location = new System.Drawing.Point(872, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 23);
            this.label4.TabIndex = 80;
            //
            // procedurecodeBindingSource1
            //
            this.procedurecodeBindingSource1.DataMember = "procedurecode";
            this.procedurecodeBindingSource1.DataSource = this.opendentalDataSetBindingSource;
            //
            // opendentalDataSetBindingSource
            //
            this.opendentalDataSetBindingSource.DataSource = this.opendentalDataSet;
            this.opendentalDataSetBindingSource.Position = 0;
            //
            // opendentalDataSet
            //
            this.opendentalDataSet.DataSetName = "opendentalDataSet";
            this.opendentalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkRefresh);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(715, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 49);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
            //
            // checkRefresh
            //
            this.checkRefresh.Location = new System.Drawing.Point(6, 19);
            this.checkRefresh.Name = "checkRefresh";
            this.checkRefresh.Size = new System.Drawing.Size(145, 19);
            this.checkRefresh.TabIndex = 72;
            this.checkRefresh.Text = "Refresh while typing";
            this.checkRefresh.UseVisualStyleBackColor = true;
            this.checkRefresh.Click += new System.EventHandler(this.checkRefresh_Click);
            //
            // butSearch
            //
            this.butSearch.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butSearch.Autosize = true;
            this.butSearch.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butSearch.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butSearch.CornerRadius = 4F;
            this.butSearch.Location = new System.Drawing.Point(1010, 46);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(53, 23);
            this.butSearch.TabIndex = 33;
            this.butSearch.Text = "&Search";
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            //
            // gridMain
            //
            this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMain.HasAddButton = false;
            this.gridMain.HasMultilineHeaders = false;
            this.gridMain.HeaderHeight = 15;
            this.gridMain.HScrollVisible = true;
            this.gridMain.Location = new System.Drawing.Point(3, 2);
            this.gridMain.Name = "gridMain";
            this.gridMain.ScrollValue = 0;
            this.gridMain.Size = new System.Drawing.Size(703, 536);
            this.gridMain.TabIndex = 9;
            this.gridMain.Title = "Select Patient";
            this.gridMain.TitleHeight = 18;
            this.gridMain.TranslationName = "FormKPIRecTreatment";
            this.gridMain.WrapText = false;
            this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
            this.gridMain.CellClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellClick);
            this.gridMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridMain_KeyDown);
            //
            // contrKeyboard1
            //
            this.contrKeyboard1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contrKeyboard1.Location = new System.Drawing.Point(712, 0);
            this.contrKeyboard1.Name = "contrKeyboard1";
            this.contrKeyboard1.Size = new System.Drawing.Size(323, 100);
            this.contrKeyboard1.TabIndex = 10;
            this.contrKeyboard1.KeyClick += new OpenDental.User_Controls.KeyboardClickEventHandler(this.contrKeyboard1_KeyClick);
            this.contrKeyboard1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.contrKeyboard1_MouseDown);
            //
            // procedurecodeBindingSource
            //
            this.procedurecodeBindingSource.DataMember = "procedurecode";
            this.procedurecodeBindingSource.DataSource = this.opendentalDataSetBindingSource;
            //
            // procedurecodeTableAdapter
            //
            this.procedurecodeTableAdapter.ClearBeforeFill = true;
            //
            // procedurecodeBindingSource2
            //
            this.procedurecodeBindingSource2.DataMember = "procedurecode";
            this.procedurecodeBindingSource2.DataSource = this.opendentalDataSet;
            //
            // procedurecodeTableAdapter1
            //
            this.procedurecodeTableAdapter1.ClearBeforeFill = true;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(718, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 81;
            this.label1.Text = "SELECTED:";
            //
            // SELECTNAME
            //
            this.SELECTNAME.AutoSize = true;
            this.SELECTNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SELECTNAME.Location = new System.Drawing.Point(733, 359);
            this.SELECTNAME.Name = "SELECTNAME";
            this.SELECTNAME.Size = new System.Drawing.Size(137, 17);
            this.SELECTNAME.TabIndex = 82;
            this.SELECTNAME.Text = "Name: (Default ALL)";
            //
            // SELECTPROC
            //
            this.SELECTPROC.AutoSize = true;
            this.SELECTPROC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SELECTPROC.Location = new System.Drawing.Point(733, 376);
            this.SELECTPROC.Name = "SELECTPROC";
            this.SELECTPROC.Size = new System.Drawing.Size(203, 17);
            this.SELECTPROC.TabIndex = 83;
            this.SELECTPROC.Text = "Procedure Code: (Default ALL)";
            this.SELECTPROC.Click += new System.EventHandler(this.label14_Click_1);
            //
            // SELECTDATE
            //
            this.SELECTDATE.AutoSize = true;
            this.SELECTDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SELECTDATE.Location = new System.Drawing.Point(733, 393);
            this.SELECTDATE.Name = "SELECTDATE";
            this.SELECTDATE.Size = new System.Drawing.Size(176, 17);
            this.SELECTDATE.TabIndex = 84;
            this.SELECTDATE.Text = "Date Range: (Default ALL)";
            //
            // FormKPIRecTreatment
            //
            this.AcceptButton = this.butOK;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(1035, 545);
            this.Controls.Add(this.SELECTDATE);
            this.Controls.Add(this.SELECTPROC);
            this.Controls.Add(this.SELECTNAME);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contrKeyboard1);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.gridMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.groupAddPt);
            this.Controls.Add(this.textRegKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboClinic);
            this.Controls.Add(this.textHmPhone);
            this.Controls.Add(this.labelClinic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textCountry);
            this.Controls.Add(this.textAddress);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.checkHideInactive);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.checkGuarantors);
            this.Controls.Add(this.textSubscriberID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textCity);
            this.Controls.Add(this.comboSite);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelSite);
            this.Controls.Add(this.textState);
            this.Controls.Add(this.comboBillingType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBirthdate);
            this.Controls.Add(this.textPatNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkShowArchived);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textChartNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textSSN);
            this.Name = "FormKPIRecTreatment";
            this.ShowInTaskbar = false;
            this.Text = "Treatments Recommended/Prescribed";
            this.Load += new System.EventHandler(this.FormSelectPatient_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendentalDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendentalDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendentalDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedurecodeBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label labelTO;
        private System.Windows.Forms.Label ProcCodeLabel;
        private System.Windows.Forms.ComboBox cmbProc;
        private System.Windows.Forms.DateTimePicker dateEndPick;
        private System.Windows.Forms.DateTimePicker dateStartPick;
        private System.Windows.Forms.Label DateEndLabel;
        private System.Windows.Forms.Label DateStartLabel;
        private System.Windows.Forms.CheckBox DateRangeCheck;
        private System.Windows.Forms.BindingSource opendentalDataSetBindingSource;
        private opendentalDataSet opendentalDataSet;
        private System.Windows.Forms.BindingSource procedurecodeBindingSource;
        private opendentalDataSetTableAdapters.procedurecodeTableAdapter procedurecodeTableAdapter;
        private System.Windows.Forms.BindingSource procedurecodeBindingSource1;
        private System.Windows.Forms.BindingSource procedurecodeBindingSource2;
        private opendentalDataSet1 opendentalDataSet1;
        private System.Windows.Forms.BindingSource procedurecodeBindingSource3;
        private opendentalDataSet1TableAdapters.procedurecodeTableAdapter procedurecodeTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SELECTNAME;
        private System.Windows.Forms.Label SELECTPROC;
        private System.Windows.Forms.Label SELECTDATE;
    }
}
#endregion
