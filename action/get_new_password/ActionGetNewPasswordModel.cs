using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionGetNewPasswordModel
    {
        public void SetValue(string UserNameOrUserEmail)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_id_by_user_name_or_user_email", "@user_name_or_user_email", UserNameOrUserEmail);

            string UserId = "";
            string UserEmail = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                UserId = dbdr.dr["user_id"].ToString();
                UserEmail = dbdr.dr["user_email"].ToString();

                db.Close();
            }
            else
            {
                db.Close();
                return;
            }

            EmailClass ec = new EmailClass();
            Security sc = new Security();
            StringClass strc = new StringClass();
            DateAndTime dat = new DateAndTime();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            int NewRandomTextValueCount = int.Parse(ElanatConfig.GetNode("security/new_random_text_value_count").Attributes["value"].Value);
            string RandomText = strc.GetCleanRandomText(NewRandomTextValueCount);


            if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId)))
                System.IO.Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId), true);

            // Create Directory And File
            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId));
            System.IO.File.Create(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId + "/new_password_code.ini")).Dispose();

            string[] Lines = new string[2];
            Lines[0] = "[password_code]";
            Lines[1] = sc.GetHash(RandomText);
            System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId + "/new_password_code.ini"), Lines);


            // Set Email Template
            string EmailBodyTemplate = Template.GetSiteTemplate("email/new_password");
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp site_url;", HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, ""));
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp site_path;", StaticObject.SitePath);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp user_id;", UserId);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp random_text;", RandomText);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp local_date;", dat.GetLocalDate(ccoc.Calendar, DateAndTime.GetDate("yyyy/MM/dd")));

            string EmailBody = EmailBodyTemplate;
            string EmailTitle = Language.GetLanguage("new_password", StaticObject.GetCurrentSiteGlobalLanguage());

            ec.SendMail(UserEmail, EmailTitle, EmailBodyTemplate, true, true);

            GlobalClass.AlertStoredLanguageVariant("email_has_been_send_you_can_open_email_and_click_to_link_for_show_new_password", StaticObject.GetCurrentSiteGlobalLanguage());
        }
    }
}