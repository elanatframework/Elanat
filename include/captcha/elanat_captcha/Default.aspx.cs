using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class IncludeCaptcha : System.Web.UI.Page
    {
        public IncludeCaptchaModel model = new IncludeCaptchaModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime DateTimeNow = DateTime.Now;

            // Get Captcha Repeat Time
            if (Session["el_last_captcha_time"] != null && Session["el_image_content"] != null)
            {
                if (DateAndTime.GetDateTimeSecondsDifference(DateTimeNow, Convert.ToDateTime(Session["el_last_captcha_time"])) <= int.Parse(ElanatConfig.GetNode("security/captcha_repeat_time").Attributes["value"].Value))
                {
                    Response.Clear();
                    Response.ContentType = "image/png";


                    byte[] TmpImage = (byte[])Session["el_image_content"];
                    Response.ContentType = "image/png";
                    System.IO.MemoryStream ms2 = new System.IO.MemoryStream(TmpImage);
                    ms2.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();

                    return;
                }
            }


            model.SetValue();
        }
    }
}