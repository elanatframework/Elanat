using CodeBehind;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Elanat
{
    public partial class IncludeElanatCaptchaController : CodeBehindController
    {
        public IncludeElanatCaptchaModel model = new IncludeElanatCaptchaModel();

        public void PageLoad(HttpContext context)
        {
            DateTime DateTimeNow = DateTime.Now;

            // Get Captcha Repeat Time
            if (context.Session.GetString("el_last_captcha_time") != null && context.Session.Get("el_image_content") != null)
            {
                if (DateAndTime.GetDateTimeSecondsDifference(DateTimeNow, Convert.ToDateTime(context.Session.GetString("el_last_captcha_time"))) <= int.Parse(ElanatConfig.GetNode("security/captcha_repeat_time").Attributes["value"].Value))
                {
                    context.Response.Clear();
                    context.Response.ContentType = "image/png";


                    byte[] TmpImage = (byte[])context.Session.Get("el_image_content");
                    context.Response.ContentType = "image/png";
                    MemoryStream ms = new MemoryStream(TmpImage);

                    context.Response.Body.WriteAsync(ms.ToArray());
                    context.Response.Body.FlushAsync();

                    IgnoreViewAndModel = true;

                    return;
                }
            }


            model.SetValue(context);

            View(model);
        }
    }
}