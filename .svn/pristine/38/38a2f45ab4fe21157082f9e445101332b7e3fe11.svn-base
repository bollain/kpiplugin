using System;
using System.Collections.Generic;
using System.Text;
using OpenDentBusiness;

namespace PluginExample {
	class ContrFamilyP {
		public static void gridPat_CellDoubleClick(OpenDental.ContrFamily sender,Patient PatCur) {//again, named much like the original
			FormPatientEditP FormP=new FormPatientEditP();
			FormP.PatCur=PatCur;
			FormP.ShowDialog();
			sender.ModuleSelected(PatCur.PatNum);
		}
	}
}
