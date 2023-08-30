using CodeBehind;

namespace Elanat
{
    public partial class AdminLinkController : CodeBehindController
    {
        public AdminLinkModel model = new AdminLinkModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddLink"]))
            {
                btn_AddLink_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddLink_Click(HttpContext context)
        {
            model.LinkActiveValue = context.Request.Form["cbx_LinkActive"] == "on";
            model.LinkValueValue = context.Request.Form["txt_LinkValue"];
            model.LinkTitleValue = context.Request.Form["txt_LinkTitle"];
            model.LinkHrefValue = context.Request.Form["txt_LinkHref"];
            model.LinkRelValue = context.Request.Form["txt_LinkRel"];
            model.LinkProtocolOptionListSelectedValue = context.Request.Form["ddlst_LinkProtocol"];
            model.LinkTargetOptionListSelectedValue = context.Request.Form["ddlst_LinkTarget"];
            model.LinkSortIndexValue = context.Request.Form["txt_LinkSortIndex"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_LinkMenu$"))
                {
                    ListItem LinkMenu = new ListItem();

                    LinkMenu.Value = context.Request.Form[name];
                    LinkMenu.Selected = true;

                    model.LinkMenuListItem.Add(LinkMenu);
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


            model.AddLink();

            View(model);
        }
    }
}