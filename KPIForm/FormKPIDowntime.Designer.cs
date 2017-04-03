using OpenDental;

namespace KPIReporting.KPIForm
{
    partial class FormKPIDowntime
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
            this.butOK = new OpenDental.UI.Button();
            this.butCancel = new OpenDental.UI.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label_title = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.labelDTPStart = new System.Windows.Forms.Label();
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

            // label_title
            // 
            this.label_title.Location = new System.Drawing.Point(12, 7);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(492, 16);
            this.label_title.TabIndex = 6;
            this.label_title.Text = "Used to calculate provider down-time within the date range.";
            // 
            // label_to
            // 
            this.label_to.Location = new System.Drawing.Point(12, 70);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(72, 23);
            this.label_to.TabIndex = 58;
            this.label_to.Text = "End Date";
            this.label_to.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // labelDTPStart
            // 
            this.labelDTPStart.Location = new System.Drawing.Point(12, 40);
            this.labelDTPStart.Name = "labelDTPStart";
            this.labelDTPStart.Size = new System.Drawing.Size(72, 23);
            this.labelDTPStart.TabIndex = 59;
            this.labelDTPStart.Text = "Start date:";
            this.labelDTPStart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 


            // 
            // FormKPIDowntime
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 140);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.labelDTPStart);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.MinimumSize = new System.Drawing.Size(347, 140);
            this.Name = "FormKPIDowntime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Provider Down-time";
            this.Load += new System.EventHandler(this.FormKPIDowntime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenDental.UI.Button butOK;
        private OpenDental.UI.Button butCancel;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.Label labelDTPStart;

    }
}