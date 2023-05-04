using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionShowProtectionContentModel
    {
        public void SetValue(string ContentId, string ContentPassword)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Content duc = new DataUse.Content();

            duc.FillCurrentContent(ContentId);

            if (string.IsNullOrEmpty(duc.ContentId))
            {
                HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("content_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }

            if (duc.ContentStatus != "active")
            {
                HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("content_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }


            // Check Content Access Show
            if (!duc.ContentPublicAccessShow.ZeroOneToBoolean())
                if (!duc.GetContentAccessShowCheck(ContentId))
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_content", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }


            DataUse.Category duc2 = new DataUse.Category();

            duc2.FillCurrentCategory(duc.CategoryId);

            if (string.IsNullOrEmpty(duc2.CategoryId))
            {
                HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("category_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }

            if (!duc2.CategoryActive.ZeroOneToBoolean())
            {
                HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("category_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }


            // Check Category Access Show
            if (!duc2.GetCategoryAccessShowCheck(duc.CategoryId))
            {
                HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_category", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }


            ContentClass cc = new ContentClass();
            string Content = cc.GetCurrentContent(ContentId, ccoc.GroupId);

            if (string.IsNullOrEmpty(Content))
            {
                Template.GetSiteTemplate("part/content_not_exist");
                return;
            }


            HttpContext.Current.Response.Write(cc.GetProtectionContentText(ContentId, ContentPassword));
        }
    }
}