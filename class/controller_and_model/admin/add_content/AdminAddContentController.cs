using CodeBehind;

namespace Elanat
{
    public partial class AdminAddContentController : CodeBehindController
    {
        public AdminAddContentModel model = new AdminAddContentModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddContent"]))
            {
                btn_AddContent_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_DraftContent"]))
            {
                btn_DraftContent_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveContent"]))
            {
                btn_SaveContent_Click(context);
                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Query["content_id"]))
                if (context.Request.Query["content_id"].ToString().IsNumber())
                {
                    model.ContentIdValue = context.Request.Query["content_id"].ToString();

                    model.UseFillContent = true;

                    if (!string.IsNullOrEmpty(context.Request.Query["is_edit"]))
                        if (context.Request.Query["is_edit"].ToString() == "true")
                            model.IsEdit = true;
                }

            if (!string.IsNullOrEmpty(context.Request.Query["content_type"]))
                model.ContentTypeOptionListSelectedValue = context.Request.Query["content_type"].ToString();


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddContent_Click(HttpContext context)
        {
            model.ContentFreeCommentsValue = context.Request.Form["cbx_ContentFreeComments"] == "on";
            model.ContentAlwaysOnTopValue = context.Request.Form["cbx_ContentAlwaysOnTop"] == "on";
            model.UseDelayPublishValue = context.Request.Form["cbx_UseDelayPublish"] == "on";
            model.ContentPublicAccessShowValue = context.Request.Form["cbx_ContentPublicAccessShow"] == "on";
            model.ContentTitleValue = context.Request.Form["txt_ContentTitle"];
            model.ContentTextValue = context.Request.Form["txt_ContentText"];
            model.ContentStatusOptionListSelectedValue = context.Request.Form["ddlst_ContentStatus"];
            model.CategoryOptionListSelectedValue = context.Request.Form["ddlst_Category"];
            model.ContentTypeOptionListSelectedValue = context.Request.Form["ddlst_ContentType"];
            model.MetaKeywordsValue = context.Request.Form["txt_MetaKeywords"];
            model.ContentSourceValue = context.Request.Form["txt_ContentSource"];
            model.ContentPasswordValue = context.Request.Form["txt_ContentPassword"];
            model.DatePublishValue = context.Request.Form["txt_DatePublish"];
            model.TimePublishValue = context.Request.Form["txt_TimePublish"];
            model.ContentIconOptionListSelectedValue = context.Request.Form["ddlst_ContentIcon"];
            model.ContentAvatarValue = context.Request.Form["hdn_ContentAvatar"];
            model.ContentIdValue = context.Request.Form["hdn_ContentId"];
            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ContentAccessShow$"))
                {
                    ListItem ContentAccessShow = new ListItem();

                    ContentAccessShow.Value = context.Request.Form[name];
                    ContentAccessShow.Selected = true;

                    model.ContentAccessShowListItem.Add(ContentAccessShow);
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


            model.AddContent("active");

            model.SuccessView("add");

            View(model);
        }

        protected void btn_DraftContent_Click(HttpContext context)
        {
            model.ContentFreeCommentsValue = context.Request.Form["cbx_ContentFreeComments"] == "on";
            model.ContentAlwaysOnTopValue = context.Request.Form["cbx_ContentAlwaysOnTop"] == "on";
            model.UseDelayPublishValue = context.Request.Form["cbx_UseDelayPublish"] == "on";
            model.ContentPublicAccessShowValue = context.Request.Form["cbx_ContentPublicAccessShow"] == "on";
            model.ContentTitleValue = context.Request.Form["txt_ContentTitle"];
            model.ContentTextValue = context.Request.Form["txt_ContentText"];
            model.ContentStatusOptionListSelectedValue = context.Request.Form["ddlst_ContentStatus"];
            model.CategoryOptionListSelectedValue = context.Request.Form["ddlst_Category"];
            model.ContentTypeOptionListSelectedValue = context.Request.Form["ddlst_ContentType"];
            model.MetaKeywordsValue = context.Request.Form["txt_MetaKeywords"];
            model.ContentSourceValue = context.Request.Form["txt_ContentSource"];
            model.ContentPasswordValue = context.Request.Form["txt_ContentPassword"];
            model.DatePublishValue = context.Request.Form["txt_DatePublish"];
            model.TimePublishValue = context.Request.Form["txt_TimePublish"];
            model.ContentIconOptionListSelectedValue = context.Request.Form["ddlst_ContentIcon"];
            model.ContentAvatarValue = context.Request.Form["hdn_ContentAvatar"];
            model.ContentIdValue = context.Request.Form["hdn_ContentId"];
            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ContentAccessShow$"))
                {
                    ListItem ContentAccessShow = new ListItem();

                    ContentAccessShow.Value = context.Request.Form[name];
                    ContentAccessShow.Selected = true;

                    model.ContentAccessShowListItem.Add(ContentAccessShow);
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


            model.AddContent("draft");

            model.SuccessView("add");

            View(model);
        }

        protected void btn_SaveContent_Click(HttpContext context)
        {
            model.ContentFreeCommentsValue = context.Request.Form["cbx_ContentFreeComments"] == "on";
            model.ContentAlwaysOnTopValue = context.Request.Form["cbx_ContentAlwaysOnTop"] == "on";
            model.UseDelayPublishValue = context.Request.Form["cbx_UseDelayPublish"] == "on";
            model.ContentPublicAccessShowValue = context.Request.Form["cbx_ContentPublicAccessShow"] == "on";
            model.ContentTitleValue = context.Request.Form["txt_ContentTitle"];
            model.ContentTextValue = context.Request.Form["txt_ContentText"];
            model.ContentStatusOptionListSelectedValue = context.Request.Form["ddlst_ContentStatus"];
            model.CategoryOptionListSelectedValue = context.Request.Form["ddlst_Category"];
            model.ContentTypeOptionListSelectedValue = context.Request.Form["ddlst_ContentType"];
            model.MetaKeywordsValue = context.Request.Form["txt_MetaKeywords"];
            model.ContentSourceValue = context.Request.Form["txt_ContentSource"];
            model.ContentPasswordValue = context.Request.Form["txt_ContentPassword"];
            model.DatePublishValue = context.Request.Form["txt_DatePublish"];
            model.TimePublishValue = context.Request.Form["txt_TimePublish"];
            model.ContentIconOptionListSelectedValue = context.Request.Form["ddlst_ContentIcon"];
            model.ContentAvatarValue = context.Request.Form["hdn_ContentAvatar"];
            model.ContentIdValue = context.Request.Form["hdn_ContentId"];
            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ContentAccessShow$"))
                {
                    ListItem ContentAccessShow = new ListItem();

                    ContentAccessShow.Value = context.Request.Form[name];
                    ContentAccessShow.Selected = true;

                    model.ContentAccessShowListItem.Add(ContentAccessShow);
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


            model.SaveContent();

            model.SuccessView("edit");

            View(model);
        }
    }
}