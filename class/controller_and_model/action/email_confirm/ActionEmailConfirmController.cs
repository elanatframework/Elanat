﻿using CodeBehind;

namespace Elanat
{
    public partial class ActionEmailConfirmController : CodeBehindController
    {
        public ActionEmailConfirmModel model = new ActionEmailConfirmModel();

        public void PageLoad(HttpContext context)
        {
            System.Threading.Thread.Sleep(int.Parse(ElanatConfig.GetNode("delay/show_protection_content").Attributes["value"].Value) * 1000);

            if (string.IsNullOrEmpty(context.Request.Query["user_name_or_user_email"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Query["captcha"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (context.Session.GetString("el_captcha") == null)
            {
                IgnoreViewAndModel = true;
                return;
            }

            if (!context.Request.Query["captcha"].ToString().MatchByCaptcha())
            {
                // Set Random Number To Captcha Session For Security
                Random rand = new Random();
                context.Session.SetString("el_captcha", rand.Next(int.MaxValue).ToString());

                IgnoreViewAndModel |= true;
                return;
            }

            string UserNameOrUserEmail = context.Request.Query["user_name_or_user_email"].ToString().ProtectSqlInjection();

            model.SetValue(context, UserNameOrUserEmail);
            
            View(model);
        }
    }
}