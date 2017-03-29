using OpenDental;

namespace KPIReporting.KPIForm
{
   partial class FormKPIByReferralSource
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRpActivePatients));
            this.butOK = new OpenDental.UI.Button();
            this.butCancel = new OpenDental.UI.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.labelDTPStart = new System.Windows.Forms.Label();
            this.labelDTPEnd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Autosize = true;
            this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butOK.CornerRadius = 4F;
            this.butOK.Location = new System.Drawing.Point(129, 94);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 24);
            this.butOK.TabIndex = 3;
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
            this.butCancel.Location = new System.Drawing.Point(210, 94);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 24);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "&Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(85, 67);
            this.dtpEnd.Name = "dateEnd";
            this.dtpEnd.TabIndex = 57;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(85, 37);
            this.dtpStart.Name = "dateStart";
            this.dtpStart.TabIndex = 56;
            // 
            // labelDTPEnd
            // 
            this.labelDTPEnd.Location = new System.Drawing.Point(12, 70);
            this.labelDTPEnd.Name = "labelDTPEnd";
            this.labelDTPEnd.Size = new System.Drawing.Size(72, 23);
            this.labelDTPEnd.TabIndex = 58;
            this.labelDTPEnd.Text = "End date:";
            this.labelDTPEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelDTPStart
            // 
            this.labelDTPStart.Location = new System.Drawing.Point(12, 40);
            this.labelDTPStart.Name = "labelDTPStart";
            this.labelDTPStart.Size = new System.Drawing.Size(72, 23);
            this.labelDTPStart.TabIndex = 59;
            this.labelDTPStart.Text = "Start date:";
            this.labelDTPStart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(492, 16);
            this.label3.TabIndex = 72;
            this.label3.Text = "Used to get a list of all new patients by referral source within the" +
    " date range.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FormKPINewPatients
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(347, 140);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.labelDTPStart);
            this.Controls.Add(this.labelDTPEnd);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butCancel);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(347, 140);
            this.Name = "FormKPIByReferralSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Patients by Referral Source";
            this.Load += new System.EventHandler(this.FormKPIByReferralSource_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenDental.UI.Button butOK;
        private OpenDental.UI.Button butCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label labelDTPStart;
        private System.Windows.Forms.Label labelDTPEnd;
    }
}