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
    public partial class AdminMenu : System.Web.UI.Page
    {
        public AdminMenuModel model = new AdminMenuModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddMenu"]))
                btn_AddMenu_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddMenu_Click(object sender, EventArgs e)
        {
            model.MenuNameValue = Request.Form["txt_MenuName"];
            model.MenuLocationOptionListSelectedValue = Request.Form["ddlst_MenuLocation"];
            model.MenuSiteOptionListSelectedValue = Request.Form["ddlst_MenuSite"];
            model.MenuUseBoxValue = Request.Form["cbx_MenuUseBox"] == "on";
            model.MenuActiveValue = Request.Form["cbx_MenuActive"] == "on";
            model.MenuSortIndexValue = Request.Form["txt_MenuSortIndex"];
            model.MenuPublicAccessShowValue = Request.Form["cbx_MenuPublicAccessShow"] == "on";

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_MenuAccessShow$"))
                {
                    ListItem MenuAccessShow = new ListItem();

                    MenuAccessShow.Value = Request.Form[name];
                    MenuAccessShow.Selected = true;

                    model.MenuAccessShowListItem.Add(MenuAccessShow);
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


            model.AddMenu();
        }
    }
}