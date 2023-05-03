using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteEmail : System.Web.UI.Page
    {
        public SiteEmailModel model = new SiteEmailModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SendEmail"]))
                btn_SendEmail_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ContentId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["content_id"]))
                    return;

                if (!Request.QueryString["content_id"].IsNumber())
                    return;

                model.ContentIdValue = Request.QueryString["content_id"].ToString(); ;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SendEmail_Click(object sender, EventArgs e)
        {
            model.ContentIdValue = Request.Form["hdn_ContentId"];
            model.YourEmailValue = Request.Form["txt_YourEmail"];
            model.RecipientsEmailValue = Request.Form["txt_RecipientsEmail"];
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


            model.SendEmail();


            model.SuccessView();
        }
    }
}