using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat.DataUse
{
    public class TemplateAndStyle
    {
        public void ChangeUserTemplateAndStyle(string UserId, string SiteStyleId, string SiteTemplateId, string AdminStyleId, string AdminTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("change_user_template_and_style", new List<string>() { "@user_id", "@site_style_id", "@site_template_id", "@admin_style_id", "@admin_template_id" }, new List<string>() { UserId, SiteStyleId, SiteTemplateId, AdminStyleId, AdminTemplateId });
        }
    }
}