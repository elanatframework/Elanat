using CodeBehind;

namespace Elanat
{
    public partial class AdminAttachmentController : CodeBehindController
    {
        public AdminAttachmentModel model = new AdminAttachmentModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddAttachment"]))
            {
                btn_AddAttachment_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddAttachment_Click(HttpContext context)
        {
            model.AttachmentPathUploadValue = context.Request.Form.Files["upd_AttachmentPath"];
            model.UseAttachmentPathValue = context.Request.Form["cbx_UseAttachmentPath"] == "on";
            model.AttachmentPathTextValue = context.Request.Form["txt_AttachmentPath"];
            model.AttachmentActiveValue = context.Request.Form["cbx_AttachmentActive"] == "on";
            model.AttachmentPublicAccessShowValue = context.Request.Form["cbx_AttachmentPublicAccessShow"] == "on";
            model.AttachmentPathTextValue = context.Request.Form["txt_AttachmentPath"];
            model.AttachmentNameValue = context.Request.Form["txt_AttachmentName"];
            model.AttachmentPasswordValue = context.Request.Form["txt_AttachmentPassword"];
            model.AttachmentAboutValue = context.Request.Form["txt_AttachmentAbout"];
            model.AttachmentContentValue = context.Request.Form["txt_AttachmentContent"];
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


            model.AddAttachment();

            View(model);
        }
    }
}