using CodeBehind;

namespace Elanat
{
    public partial class ModuleLastDataOptionController : CodeBehindController
    {
        public ModuleLastDataOptionModel model = new ModuleLastDataOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveLastDataOption"]))
            {
                btn_SaveLastDataOption_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveLastDataOption_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.ActiveContactValue = context.Request.Form["cbx_ActiveContact"] == "on";
            model.ActiveCommentValue = context.Request.Form["cbx_ActiveComment"] == "on";
            model.ActiveAttachmentValue = context.Request.Form["cbx_ActiveAttachment"] == "on";
            model.ActiveContentValue = context.Request.Form["cbx_ActiveContent"] == "on";
            model.ActiveFootPrintValue = context.Request.Form["cbx_ActiveFootPrint"] == "on";
            model.ActiveUserSignUpValue = context.Request.Form["cbx_ActiveUserSignUp"] == "on";
            model.ActiveActiveUserValue = context.Request.Form["cbx_ActiveActiveUser"] == "on";
            model.ContactCountValue = context.Request.Form["txt_ContactCount"];
            model.CommentCountValue = context.Request.Form["txt_CommentCount"];
            model.AttachmentCountValue = context.Request.Form["txt_AttachmentCount"];
            model.ContentCountValue = context.Request.Form["txt_ContentCount"];
            model.FootPrintCountValue = context.Request.Form["txt_FootPrintCount"];
            model.UserSignUpCountValue = context.Request.Form["txt_UserSignUpCount"];
            model.ActiveUserCountValue = context.Request.Form["txt_ActiveUserCount"];


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


            model.SaveLastDataOption();

            View(model);
        }
    }
}