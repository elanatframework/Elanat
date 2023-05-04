using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditMenu : System.Web.UI.Page
    {
        public ActionEditMenuModel model = new ActionEditMenuModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveMenu"]))
                btn_SaveMenu_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_MenuId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["menu_id"]))
                    return;

                if (!Request.QueryString["menu_id"].ToString().IsNumber())
                    return;

                model.MenuIdValue = Request.QueryString["menu_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveMenu_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.MenuNameValue = Request.Form["txt_MenuName"];
            model.MenuLocationOptionListSelectedValue = Request.Form["ddlst_MenuLocation"];
            model.MenuSiteOptionListSelectedValue = Request.Form["ddlst_MenuSite"];
            model.MenuUseBoxValue = Request.Form["cbx_MenuUseBox"] == "on";
            model.MenuActiveValue = Request.Form["cbx_MenuActive"] == "on";
            model.MenuSortIndexValue = Request.Form["txt_MenuSortIndex"];
            model.MenuPublicAccessShowValue = Request.Form["cbx_MenuPublicAccessShow"] == "on";
            model.MenuIdValue = Request.Form["hdn_MenuId"];

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


            DataUse.Menu dum = new DataUse.Menu();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_menu", "menu_name", model.MenuNameValue, dum.GetMenuName(model.MenuIdValue)))
            {
                model.MenuNameCssClass = model.MenuNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                return;
            }


            model.SaveMenu();

            model.SuccessView();
        }
    }
}