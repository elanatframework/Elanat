using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace elanat
{
    public partial class AdminGroup : System.Web.UI.Page
    {
        public AdminGroupModel model = new AdminGroupModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddGroup"]))
                btn_AddGroup_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddGroup_Click(object sender, EventArgs e)
        {
            model.GroupNameValue = Request.Form["txt_GroupName"];
            model.GroupActiveValue = Request.Form["cbx_GroupActive"] == "on";

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_GroupRole$"))
                {
                    ListItem GroupRole = new ListItem();

                    GroupRole.Value = Request.Form[name];
                    GroupRole.Selected = true;

                    model.GroupRoleListItem.Add(GroupRole);
                }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddGroup();
        }
    }
}