using CodeBehind;

namespace Elanat
{
    public partial class ActionEditLinkController : CodeBehindController
    {
        public ActionEditLinkModel model = new ActionEditLinkModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveLink"]))
            {
                btn_SaveLink_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_linkId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["link_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["link_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.LinkIdValue = context.Request.Query["link_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveLink_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.LinkActiveValue = context.Request.Form["cbx_LinkActive"] == "on";
            model.LinkValueValue = context.Request.Form["txt_LinkValue"];
            model.LinkTitleValue = context.Request.Form["txt_LinkTitle"];
            model.LinkHrefValue = context.Request.Form["txt_LinkHref"];
            model.LinkRelValue = context.Request.Form["txt_LinkRel"];
            model.LinkProtocolOptionListSelectedValue = context.Request.Form["ddlst_LinkProtocol"];
            model.LinkTargetOptionListSelectedValue = context.Request.Form["ddlst_LinkTarget"];
            model.LinkSortIndexValue = context.Request.Form["txt_LinkSortIndex"];
            model.LinkIdValue = context.Request.Form["hdn_LinkId"];

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


            model.SaveLink();

            model.SuccessView();

            View(model);
        }
    }
}