using CodeBehind;

namespace Elanat
{
    public partial class ActionConfirmEmailModel : CodeBehindModel
    {
        public void SetValue(string UserId, string Value)
        {
            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId)))
                return;
            
            Security scc = new Security();
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId + "/confirm_email.txt"));
            CodeSocket code = new CodeSocket();
            if (code.DeCoder(scc.GetHash(Value)) != code.DeCoder(Lines[0]))
                return;

            // Active User Confirm 
            DataUse.User duu = new DataUse.User();
            duu.ActiveUserEmailConfirm(UserId);

            // Delete Directory
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId), true);

            string EmailConfirmationTemplate = Template.GetSiteTemplate("page/email_confirm");
            Write(EmailConfirmationTemplate);
        }
    }
}