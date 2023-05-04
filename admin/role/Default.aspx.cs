using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;

namespace elanat
{
    public partial class AdminRole : System.Web.UI.Page
    {
        public AdminRoleModel model = new AdminRoleModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddRole"]))
                btn_AddRole_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddRole_Click(object sender, EventArgs e)
        {
            model.RoleNameValue = Request.Form["txt_RoleName"];
            model.RoleActiveValue = Request.Form["cbx_RoleActive"] == "on";
            model.RoleTypeOptionListSelectedValue = Request.Form["ddlst_RoleType"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_RoleBitColumnAccess$"))
                {
                    ListItem RoleBitColumnAccess = new ListItem();

                    RoleBitColumnAccess.Value = Request.Form[name];
                    RoleBitColumnAccess.Selected = true;

                    model.RoleBitColumnAccessListItem.Add(RoleBitColumnAccess);
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


            model.AddRole();
        }
    }
}