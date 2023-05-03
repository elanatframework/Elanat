using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class SiteContactResponse : System.Web.UI.Page
    {
        public SiteContactResponseModel model = new SiteContactResponseModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_GetContactResponse"]))
                btn_GetContactResponse_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_GetContactResponse_Click(object sender, EventArgs e)
        {
            model.ContactResponseCodeValue = Request.Form["txt_ContactResponseCode"];
            model.CaptchaTextValue = Request.Form["txt_Captcha"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();
                return;
            }


            model.GetContactResponse();
        }
    }
}