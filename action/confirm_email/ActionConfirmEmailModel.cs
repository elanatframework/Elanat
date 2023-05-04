using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionConfirmEmailModel
    {
        public void SetValue(string UserId, string Value)
        {
            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId)))
                return;

            Security scc = new Security();
            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId + "/confirm_email.txt"));
            CodeSocket code = new CodeSocket();
            if (code.DeCoder(scc.GetHash(Value)) != code.DeCoder(Lines[0]))
                return;

            // Active User Confirm 
            DataUse.User duu = new DataUse.User();
            duu.ActiveUserEmailConfirm(UserId);

            // Delete Directory
            System.IO.Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/confirm_email/user_" + UserId), true);

            string EmailConfirmationTemplate = Template.GetSiteTemplate("page/email_confirm");
            HttpContext.Current.Response.Write(EmailConfirmationTemplate);
        }
    }
}