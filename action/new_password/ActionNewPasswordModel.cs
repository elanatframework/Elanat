using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionNewPasswordModel
    {
        public void SetValue(string UserId, string Value)
        {
            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId)))
                return;

            Security scc = new Security();
            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId + "/new_password_code.ini"));
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
            System.IO.Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/new_password_code/user_" + UserId), true);

            string NewPasswordTemplate = Template.GetSiteTemplate("page/new_password").Replace("$_asp new_password;", NewPassword);
            HttpContext.Current.Response.Write(NewPasswordTemplate);
        }
    }
}