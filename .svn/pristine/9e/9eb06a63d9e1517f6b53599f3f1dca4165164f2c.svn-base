using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental;

namespace PluginExample {
	public partial class FormPatientEditP:Form {
		public Patient PatCur;
		private Patient patOld;

		public FormPatientEditP() {
			InitializeComponent();
		}

		private void FormPatientEdit_Load(object sender,EventArgs e) {
			patOld=PatCur.Copy();
			textPreferred.Text=PatCur.Preferred;
		}

		private void butOK_Click(object sender,EventArgs e) {
			PatCur.Preferred=textPreferred.Text;
			Patients.Update(PatCur,patOld);
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}
