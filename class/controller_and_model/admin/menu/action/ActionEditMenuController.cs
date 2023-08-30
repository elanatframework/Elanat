using CodeBehind;

namespace Elanat
{
    public partial class ActionEditMenuController : CodeBehindController
    {
        public ActionEditMenuModel model = new ActionEditMenuModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveMenu"]))
            {
                btn_SaveMenu_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_MenuId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["menu_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["menu_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.MenuIdValue = context.Request.Query["menu_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveMenu_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.MenuNameValue = context.Request.Form["txt_MenuName"];
            model.MenuLocationOptionListSelectedValue = context.Request.Form["ddlst_MenuLocation"];
            model.MenuSiteOptionListSelectedValue = context.Request.Form["ddlst_MenuSite"];
            model.MenuUseBoxValue = context.Request.Form["cbx_MenuUseBox"] == "on";
            model.MenuActiveValue = context.Request.Form["cbx_MenuActive"] == "on";
            model.MenuSortIndexValue = context.Request.Form["txt_MenuSortIndex"];
            model.MenuPublicAccessShowValue = context.Request.Form["cbx_MenuPublicAccessShow"] == "on";
            model.MenuIdValue = context.Request.Form["hdn_MenuId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_MenuAccessShow$"))
                {
                    ListItem MenuAccessShow = new ListItem();

                    MenuAccessShow.Value = context.Request.Form[name];
                    MenuAccessShow.Selected = true;

                    model.MenuAccessShowListItem.Add(MenuAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            DataUse.Menu dum = new DataUse.Menu();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_menu", "menu_name", model.MenuNameValue, dum.GetMenuName(model.MenuIdValue)))
            {
                model.MenuNameCssClass = model.MenuNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                View(model);

                return;
            }


            model.SaveMenu();

            model.SuccessView();

            View(model);
        }
    }
}