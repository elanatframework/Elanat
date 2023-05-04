using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PluginShowAdminUserMenuModel
    {
        public void SetValue()
        {
            string UserMenuTemplate = Template.GetAdminTemplate("part/user_menu");

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            UserMenuTemplate = UserMenuTemplate.Replace("$_asp user_id;", ccoc.UserId);
            UserMenuTemplate = UserMenuTemplate.Replace("$_asp user_name;", ccoc.UserName);
            UserMenuTemplate = UserMenuTemplate.Replace("$_asp_lang group_name;", Language.GetHandheldLanguage(ccoc.GroupName, StaticObject.GetCurrentAdminGlobalLanguage()));

            DataUse.Content duc = new DataUse.Content();
            UserMenuTemplate = UserMenuTemplate.Replace("$_asp unapproval_content_count;", duc.GetInactiveContentCount());

            UserMenuTemplate = (duc.GetInactiveContentCount() != "0") ? UserMenuTemplate.Replace("$_asp exist_unapproval_content;", "exist") : UserMenuTemplate.Replace("$_asp exist_unapproval_content;", "zone");


            DataUse.Comment duc2 = new DataUse.Comment();
            UserMenuTemplate = UserMenuTemplate.Replace("$_asp unapproval_comment_count;", duc2.GetInactiveCommentCount());

            UserMenuTemplate = (duc2.GetInactiveCommentCount() != "0") ? UserMenuTemplate.Replace("$_asp exist_unapproval_comment;", "exist") : UserMenuTemplate.Replace("$_asp exist_unapproval_comment;", "zone");


            HttpContext.Current.Response.Write(UserMenuTemplate);
        }
    }
}