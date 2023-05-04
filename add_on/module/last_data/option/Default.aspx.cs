using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleLastDataOption : System.Web.UI.Page
    {
        public ModuleLastDataOptionModel model = new ModuleLastDataOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveLastDataOption"]))
                btn_SaveLastDataOption_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveLastDataOption_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.ActiveContactValue = Request.Form["cbx_ActiveContact"] == "on";
            model.ActiveCommentValue = Request.Form["cbx_ActiveComment"] == "on";
            model.ActiveAttachmentValue = Request.Form["cbx_ActiveAttachment"] == "on";
            model.ActiveContentValue = Request.Form["cbx_ActiveContent"] == "on";
            model.ActiveFootPrintValue = Request.Form["cbx_ActiveFootPrint"] == "on";
            model.ActiveUserSignUpValue = Request.Form["cbx_ActiveUserSignUp"] == "on";
            model.ActiveActiveUserValue = Request.Form["cbx_ActiveActiveUser"] == "on";
            model.ContactCountValue = Request.Form["txt_ContactCount"];
            model.CommentCountValue = Request.Form["txt_CommentCount"];
            model.AttachmentCountValue = Request.Form["txt_AttachmentCount"];
            model.ContentCountValue = Request.Form["txt_ContentCount"];
            model.FootPrintCountValue = Request.Form["txt_FootPrintCount"];
            model.UserSignUpCountValue = Request.Form["txt_UserSignUpCount"];
            model.ActiveUserCountValue = Request.Form["txt_ActiveUserCount"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveLastDataOption();
        }
    }
}