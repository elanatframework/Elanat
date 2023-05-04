using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionConfigurationSetConfig : System.Web.UI.Page
    {
        public ActionConfigurationSetConfigModel model = new ActionConfigurationSetConfigModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["config_name"]))
                return;

            model.ConfigNameValue = Request.QueryString["config_name"].ToString();


            // Role Bit Column Access Check
            Access ac = new Access();
            if (ac.AggregationRoleBitColumnAccess("role_" + model.ConfigNameValue + "_configuration") == "0")
            {
                GlobalClass.Alert(Language.GetAddOnsLanguage("you_do_not_have_access_to_this_file", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/configuration/"), "warning");
                return;
            }

            model.SetValue();
        }
    }
}