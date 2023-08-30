using CodeBehind;

namespace Elanat
{
    public partial class ActionEditAttachmentController : CodeBehindController
    {
        public ActionEditAttachmentModel model = new ActionEditAttachmentModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveAttachment"]))
            {
                btn_SaveAttachment_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_AttachmentId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["attachment_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["attachment_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.AttachmentIdValue = context.Request.Query["attachment_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveAttachment_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.AttachmentActiveValue = context.Request.Form["cbx_AttachmentActive"] == "on";
            model.AttachmentPublicAccessShowValue = context.Request.Form["cbx_AttachmentPublicAccessShow"] == "on";
            model.AttachmentNameValue = context.Request.Form["txt_AttachmentName"];
            model.AttachmentPasswordValue = context.Request.Form["txt_AttachmentPassword"];
            model.AttachmentAboutValue = context.Request.Form["txt_AttachmentAbout"];
            model.AttachmentContentValue = context.Request.Form["txt_AttachmentContent"];
            model.AttachmentIdValue = context.Request.Form["hdn_AttachmentId"];
            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_AttachmentAccessShow$"))
                {
                    ListItem AttachmentAccessShow = new ListItem();

                    AttachmentAccessShow.Value = context.Request.Form[name];
                    AttachmentAccessShow.Selected = true;

                    model.AttachmentAccessShowListItem.Add(AttachmentAccessShow);
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


            model.SaveAttachment();

            model.SuccessView();

            View(model);
        }
    }
}