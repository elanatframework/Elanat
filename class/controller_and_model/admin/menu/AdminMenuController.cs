using CodeBehind;

namespace Elanat
{
    public partial class AdminMenuController : CodeBehindController
    {
        public AdminMenuModel model = new AdminMenuModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddMenu"]))
            {
                btn_AddMenu_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddMenu_Click(HttpContext context)
        {
            model.MenuNameValue = context.Request.Form["txt_MenuName"];
            model.MenuLocationOptionListSelectedValue = context.Request.Form["ddlst_MenuLocation"];
            model.MenuSiteOptionListSelectedValue = context.Request.Form["ddlst_MenuSite"];
            model.MenuUseBoxValue = context.Request.Form["cbx_MenuUseBox"] == "on";
            model.MenuActiveValue = context.Request.Form["cbx_MenuActive"] == "on";
            model.MenuSortIndexValue = context.Request.Form["txt_MenuSortIndex"];
            model.MenuPublicAccessShowValue = context.Request.Form["cbx_MenuPublicAccessShow"] == "on";

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


            model.AddMenu();

            View(model);
        }
    }
}