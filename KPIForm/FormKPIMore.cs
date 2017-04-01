using System;
using System.Windows.Forms;
using OpenDental;

namespace KPIReporting.KPIForm
{
    /// <summary>
    /// Summary description for FormKPIMore.
    /// </summary>
    public class FormKPIMore : System.Windows.Forms.Form
    {
        private OpenDental.UI.Button butClose;
        private Label lblNewPat;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private OpenDental.UI.ListBoxClickable lBCNewPat;
        private OpenDental.UI.ListBoxClickable lBCRecall;
        private OpenDental.UI.ListBoxClickable lBCTreatmentCases;
        private Label lblRecall;
        private Label lblProductivity;
        private Label lblTreatmentCases;
        private OpenDental.UI.ListBoxClickable lBCProductivity;

        ///<summary></summary>
        public FormKPIMore()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Lan.F(this);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.lblNewPat = new System.Windows.Forms.Label();
            this.lBCProductivity = new OpenDental.UI.ListBoxClickable();
            this.butClose = new OpenDental.UI.Button();
            this.lBCNewPat = new OpenDental.UI.ListBoxClickable();
            this.lBCRecall = new OpenDental.UI.ListBoxClickable();
            this.lBCTreatmentCases = new OpenDental.UI.ListBoxClickable();
            this.lblRecall = new System.Windows.Forms.Label();
            this.lblProductivity = new System.Windows.Forms.Label();
            this.lblTreatmentCases = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNewPat
            // 
            this.lblNewPat.Location = new System.Drawing.Point(29, 9);
            this.lblNewPat.Name = "lblNewPat";
            this.lblNewPat.Size = new System.Drawing.Size(118, 18);
            this.lblNewPat.TabIndex = 2;
            this.lblNewPat.Text = "New Patients";
            this.lblNewPat.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lBCProductivity
            // 
            this.lBCProductivity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lBCProductivity.FormattingEnabled = true;
            this.lBCProductivity.ItemHeight = 15;
            this.lBCProductivity.Location = new System.Drawing.Point(32, 128);
            this.lBCProductivity.Name = "lBCProductivity";
            this.lBCProductivity.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lBCProductivity.Size = new System.Drawing.Size(204, 79);
            this.lBCProductivity.TabIndex = 1;
            this.lBCProductivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listProductivity_MouseDown);
            // 
            // butClose
            // 
            this.butClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.Autosize = true;
            this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
            this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
            this.butClose.CornerRadius = 4F;
            this.butClose.Location = new System.Drawing.Point(409, 221);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 26);
            this.butClose.TabIndex = 0;
            this.butClose.Text = "Close";
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // lBCNewPat
            // 
            this.lBCNewPat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lBCNewPat.FormattingEnabled = true;
            this.lBCNewPat.ItemHeight = 15;
            this.lBCNewPat.Location = new System.Drawing.Point(32, 30);
            this.lBCNewPat.Name = "lBCNewPat";
            this.lBCNewPat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lBCNewPat.Size = new System.Drawing.Size(204, 64);
            this.lBCNewPat.TabIndex = 3;
            this.lBCNewPat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listNewPat_MouseDown);
            // 
            // lBCRecall
            // 
            this.lBCRecall.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lBCRecall.FormattingEnabled = true;
            this.lBCRecall.ItemHeight = 15;
            this.lBCRecall.Location = new System.Drawing.Point(272, 30);
            this.lBCRecall.Name = "lBCRecall";
            this.lBCRecall.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lBCRecall.Size = new System.Drawing.Size(204, 64);
            this.lBCRecall.TabIndex = 4;
            this.lBCRecall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listRecall_MouseDown);
            // 
            // lBCTreatmentCases
            // 
            this.lBCTreatmentCases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lBCTreatmentCases.FormattingEnabled = true;
            this.lBCTreatmentCases.ItemHeight = 15;
            this.lBCTreatmentCases.Location = new System.Drawing.Point(272, 128);
            this.lBCTreatmentCases.Name = "lBCTreatmentCases";
            this.lBCTreatmentCases.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lBCTreatmentCases.Size = new System.Drawing.Size(204, 79);
            this.lBCTreatmentCases.TabIndex = 5;
            this.lBCTreatmentCases.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listTreatments_MouseDown);
            // 
            // lblRecall
            // 
            this.lblRecall.Location = new System.Drawing.Point(269, 9);
            this.lblRecall.Name = "lblRecall";
            this.lblRecall.Size = new System.Drawing.Size(118, 18);
            this.lblRecall.TabIndex = 6;
            this.lblRecall.Text = "Recall";
            this.lblRecall.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblProductivity
            // 
            this.lblProductivity.Location = new System.Drawing.Point(29, 106);
            this.lblProductivity.Name = "lblProductivity";
            this.lblProductivity.Size = new System.Drawing.Size(118, 18);
            this.lblProductivity.TabIndex = 7;
            this.lblProductivity.Text = "Productivity";
            this.lblProductivity.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTreatmentCases
            // 
            this.lblTreatmentCases.Location = new System.Drawing.Point(269, 106);
            this.lblTreatmentCases.Name = "lblTreatmentCases";
            this.lblTreatmentCases.Size = new System.Drawing.Size(118, 18);
            this.lblTreatmentCases.TabIndex = 8;
            this.lblTreatmentCases.Text = "Treatment Cases";
            this.lblTreatmentCases.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FormKPIMore
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(506, 271);
            this.Controls.Add(this.lblTreatmentCases);
            this.Controls.Add(this.lblProductivity);
            this.Controls.Add(this.lblRecall);
            this.Controls.Add(this.lBCTreatmentCases);
            this.Controls.Add(this.lBCRecall);
            this.Controls.Add(this.lBCNewPat);
            this.Controls.Add(this.lBCProductivity);
            this.Controls.Add(this.lblNewPat);
            this.Controls.Add(this.butClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKPIMore";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Performance Indicators";
            this.Load += new System.EventHandler(this.FormKPIMore_Load);
            this.ResumeLayout(false);

        }

        private void listNewPat_MouseDown(object sender, MouseEventArgs e)
        {
            int selected = lBCNewPat.IndexFromPoint(e.Location);
            if (selected == -1)
            {
                return;
            }

            switch (selected)
            {
                case 0://New patients
                    FormKPINewPatients FormAR7 = new FormKPINewPatients();
                    FormAR7.ShowDialog();
                    break;
                case 1://New patients by referral source
                    FormKPIByReferralSource FormAR8 = new FormKPIByReferralSource();
                    FormAR8.ShowDialog();
                    break;
                case 2://New patients to recall patients
                    FormKPINewToRecall FormAR9 = new FormKPINewToRecall();
                    FormAR9.ShowDialog();
                    break;
                default:
                    return;
            }
        }

        private void listRecall_MouseDown(object sender, MouseEventArgs e)
        {
            int selected = lBCRecall.IndexFromPoint(e.Location);
            if (selected == -1)
            {
                return;
            }

            switch (selected)
            {
                case 0://Patients on Active Recall
                    FormKPIActiveRecall FormAR = new FormKPIActiveRecall();
                    FormAR.ShowDialog();
                    break;
                case 1://Patients on Perio Recall
                    FormKPIPerioRecall FormPR = new FormKPIPerioRecall();
                    FormPR.ShowDialog();
                    break;
                case 2://Backlog of recall patients
                    FormKPIBacklogRecall FormBR = new FormKPIBacklogRecall();
                    FormBR.ShowDialog();
                    break;
                default:
                    return;
            }
        }

        private void listTreatments_MouseDown(object sender, MouseEventArgs e)
        {
            int selected = lBCTreatmentCases.IndexFromPoint(e.Location);
            if (selected == -1)
            {
                return;
            }

            switch (selected)
            {
                case 0://Case Presentation
                    FormKPIRecTreatment FormAR10 = new FormKPIRecTreatment();
                    FormAR10.ShowDialog();
                    break;
                case 1: //Conversion Rate
                    FormKPIConversionRate FormAR11 = new FormKPIConversionRate();
                    FormAR11.ShowDialog();
                    break;
                case 2://ROB
                    break;
                case 3://ROB
                    break;
                default:
                    return;
            }
        }

        private void listProductivity_MouseDown(object sender, MouseEventArgs e)
        {
            int selected = lBCProductivity.IndexFromPoint(e.Location);
            if (selected == -1)
            {
                return;
            }

            switch (selected)
            {
                case 0: //Patients who did not show for their appt
                    FormKPINoShowAppt FormNSA = new FormKPINoShowAppt();
                    FormNSA.ShowDialog();
                    break;
                case 1:  //Patients who cancelled short notice
                    FormKPICancel FormC = new FormKPICancel();
                    FormC.ShowDialog();
                    break;
                case 2: //Non-productive practice time
                    FormKPINonProductivePracticeTime FormNPPT = new FormKPINonProductivePracticeTime();
                    FormNPPT.ShowDialog();
                    break;
                case 3: //Downtime
                    FormKPIDowntime FormDT = new FormKPIDowntime();
                    FormDT.ShowDialog();
                    break;
                default:
                    return;
            }
        }
        #endregion

        private void FormKPIMore_Load(object sender, EventArgs e)
        {
            lBCProductivity.Items.AddRange(new string[] { //Delete this comment on deliver: STEP 1 Add report to list
                Lan.g(this, "Patients who missed their appointment"),
                Lan.g(this, "Patients who cancelled short notice"),
                Lan.g(this, "Total Non-Productive Practice Time"),
                Lan.g(this, "Downtime for Each Provider")
            });

            lBCRecall.Items.AddRange(new string[] {
                Lan.g(this, "Patients on Active Recall"),
                Lan.g(this, "Patients on Perio Recall"),
                Lan.g(this, "Backlog of Recall Patients")
            });

            lBCTreatmentCases.Items.AddRange(new string[] {
                Lan.g(this, "Case Presentation"),
                Lan.g(this, "Conversion Rate"),
                Lan.g(this, "ROB"),
                Lan.g(this, "ROB")
            });

            lBCNewPat.Items.AddRange(new string[] {
                Lan.g(this,"List of New Patients"),
                Lan.g(this,"New Patients by Referral Source"),
                Lan.g(this,"New Patients to Recall Patients")
            });
        }

        private void butClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void listKPI_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}