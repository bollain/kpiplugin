namespace KPIReporting.KPIForm
{

    public partial class FormKPIConversionRate
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
            this.butAddAll = new OpenDental.UI.Button();
            this.butAddPt = new OpenDental.UI.Button();
            this.butOK = new OpenDental.UI.Button();
            this.butCancel = new OpenDental.UI.Button();
            this.dateStartPick = new System.Windows.Forms.DateTimePicker();
            this.dateEndPick = new System.Windows.Forms.DateTimePicker();
            this.DateStartLabel = new System.Windows.Forms.Label();
            this.DateEndLabel = new System.Windows.Forms.Label();
            this.TreatCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.butOK.Location = new System.Drawing.Point(118, 210);
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
            this.butCancel.Location = new System.Drawing.Point(246, 210);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(76, 26);
            this.butCancel.TabIndex = 21;
            this.butCancel.Text = "&Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // dateStartPick
            // 
            this.dateStartPick.Location = new System.Drawing.Point(122, 62);
            this.dateStartPick.Name = "dateStartPick";
            this.dateStartPick.Size = new System.Drawing.Size(200, 20);
            this.dateStartPick.TabIndex = 22;
            this.dateStartPick.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateEndPick
            // 
            this.dateEndPick.Location = new System.Drawing.Point(122, 88);
            this.dateEndPick.Name = "dateEndPick";
            this.dateEndPick.Size = new System.Drawing.Size(200, 20);
            this.dateEndPick.TabIndex = 23;
            this.dateEndPick.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // DateStartLabel
            // 
            this.DateStartLabel.AutoSize = true;
            this.DateStartLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DateStartLabel.Location = new System.Drawing.Point(57, 66);
            this.DateStartLabel.Name = "DateStartLabel";
            this.DateStartLabel.Size = new System.Drawing.Size(55, 13);
            this.DateStartLabel.TabIndex = 25;
            this.DateStartLabel.Text = "Date Start";
            this.DateStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateEndLabel
            // 
            this.DateEndLabel.AutoSize = true;
            this.DateEndLabel.Location = new System.Drawing.Point(60, 91);
            this.DateEndLabel.Name = "DateEndLabel";
            this.DateEndLabel.Size = new System.Drawing.Size(52, 13);
            this.DateEndLabel.TabIndex = 26;
            this.DateEndLabel.Text = "Date End";
            // 
            // TreatCode
            // 
            this.TreatCode.AutoSize = true;
            this.TreatCode.Location = new System.Drawing.Point(29, 115);
            this.TreatCode.Name = "TreatCode";
            this.TreatCode.Size = new System.Drawing.Size(83, 13);
            this.TreatCode.TabIndex = 27;
            this.TreatCode.Text = "Treatment Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(104, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 31);
            this.label1.TabIndex = 28;
            this.label1.Text = "Conversion Rate";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbProc
            // 
            this.cmbProc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProc.FormattingEnabled = true;
            this.cmbProc.Location = new System.Drawing.Point(122, 112);
            this.cmbProc.Name = "cmbProc";
            this.cmbProc.Size = new System.Drawing.Size(200, 21);
            this.cmbProc.TabIndex = 29;
            this.cmbProc.SelectedIndexChanged += new System.EventHandler(this.cmbProc_SelectedIndexChanged);

            // 
            // FormKPIConversionRate
            // 
            this.AcceptButton = this.butOK;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(399, 248);
            this.Controls.Add(this.cmbProc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TreatCode);
            this.Controls.Add(this.DateEndLabel);
            this.Controls.Add(this.DateStartLabel);
            this.Controls.Add(this.dateEndPick);
            this.Controls.Add(this.dateStartPick);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butCancel);
            this.Name = "FormKPIConversionRate";
            this.ShowInTaskbar = false;
            this.Text = "Appointment Conversion Rate";
            this.Load += new System.EventHandler(this.FormSelectPatient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label labelTO;
        private System.Windows.Forms.DateTimePicker dateStartPick;
        private System.Windows.Forms.DateTimePicker dateEndPick;
        private System.Windows.Forms.Label DateStartLabel;
        private System.Windows.Forms.Label DateEndLabel;
        private System.Windows.Forms.Label TreatCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProc;
    }
}
#endregion
