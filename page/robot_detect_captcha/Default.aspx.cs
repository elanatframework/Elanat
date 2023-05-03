using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class RobotDetectCaptcha : System.Web.UI.Page
    {
        public RobotDetectCaptchaModel model = new RobotDetectCaptchaModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.RobotDetectionRequestCount > 0)
                return;


            if (!string.IsNullOrEmpty(Request.Form["btn_SetCaptcha"]))
                btn_SetCaptcha_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SetCaptcha_Click(object sender, EventArgs e)
        {
            model.CaptchaTextValue = Request.Form["txt_Captcha"];


            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();
                return;
            }


            model.SetCaptcha();
        }
    }
}