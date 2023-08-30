using CodeBehind;

namespace Elanat
{
    public partial class ActionNewPasswordModel : CodeBehindModel
    {
        public void SetValue(string UserId, string Value)
        {
            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId)))
                return;

            Security scc = new Security();
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId + "/new_password_code.ini"));
            CodeSocket code = new CodeSocket();
            if (code.DeCoder(scc.GetHash(Value)) != code.DeCoder(Lines[1]))
                return;

            // Get New Password Length
            StringClass strc = new StringClass();
            int NewPasswordLength = int.Parse(ElanatConfig.GetNode("security/new_password_length").Attributes["value"].Value);

            string NewPassword = strc.GetCleanRandomText(NewPasswordLength);

            // Change User Password
            DataUse.User duu = new DataUse.User();
            duu.ChangeUserPassword(UserId, scc.GetHash(NewPassword));

            // Delete Directory
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId), true);

            string NewPasswordTemplate = Template.GetSiteTemplate("page/new_password").Replace("$_asp new_password;", NewPassword);
            Write(NewPasswordTemplate);
        }
    }
}