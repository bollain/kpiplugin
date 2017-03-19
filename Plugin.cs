using System.Windows.Forms;
using KPIReporting.KPIForm;
using OpenDentBusiness;

namespace KPIReporting
{//The namespace for this class must match the dll filename, including capitalization.  All other classes will typically belong to the same namespace too, but that's not a requirement.
 /// <summary>Required class.  Don't change the name.</summary>
    public class Plugin : PluginBase
    {

        private Form host;

        ///<summary></summary>
        public override Form Host
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }

        public override bool HookAddCode(object sender, string hookName, params object[] parameters)
        {//required method
            switch (hookName)
            {
                default:
                    return false;
            }
        }

        public override void LaunchToolbarButton(long patNum)
        {
            FormKPIMore form = new FormKPIMore();
            form.ShowDialog();
        }

    }
}
