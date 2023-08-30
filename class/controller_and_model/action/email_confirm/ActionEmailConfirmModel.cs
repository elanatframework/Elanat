using CodeBehind;
using Microsoft.AspNetCore.Http.Extensions;

namespace Elanat
{
    public partial class ActionEmailConfirmModel : CodeBehindModel
    {
        public void SetValue(HttpContext context, string UserNameOrUserEmail)
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


            if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId)))
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId), true);

            // Create Directory And File
            Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId));
            File.Create(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId + "/confirm_email.ini")).Dispose();

            string[] Lines = new string[2];
            Lines[0] = "[email_code]";
            Lines[1] = sc.GetHash(RandomText);
            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId + "/confirm_email.ini"), Lines);


            // Set Email Template
            string EmailBodyTemplate = Template.GetSiteTemplate("email/confirm_email");
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp site_url;", context.Request.GetDisplayUrl().Replace(context.Request.GetEncodedPathAndQuery(), ""));
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp site_path;", StaticObject.SitePath);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp user_id;", UserId);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp random_text;", RandomText);
            EmailBodyTemplate = EmailBodyTemplate.Replace("$_asp local_date;", dat.GetLocalDate(ccoc.Calendar, DateAndTime.GetDate("yyyy/MM/dd")));

            string EmailBody = EmailBodyTemplate;
            string EmailTitle = Language.GetLanguage("confirm_email", StaticObject.GetCurrentSiteGlobalLanguage());

            ec.SendMail(UserEmail, EmailTitle, EmailBodyTemplate, true, true);

            Write(GlobalClass.AlertStoredLanguageVariant("email_has_been_send_you_can_open_email_and_click_to_link_for_confirm_email", StaticObject.GetCurrentSiteGlobalLanguage()));
        }
    }
}