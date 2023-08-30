using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetContentTextModel : CodeBehindModel
    {
        public void SetValue(string ContentId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Content duc = new DataUse.Content();

            duc.FillCurrentContent(ContentId);

            if (string.IsNullOrEmpty(duc.ContentId))
            {
                Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("content_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }

            if (duc.ContentStatus != "active")
            {
                Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("content_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }


            // Check Content Access Show
            if (!duc.ContentPublicAccessShow.ZeroOneToBoolean())
                if (!duc.GetContentAccessShowCheck(ContentId))
                {
                    Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_content", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }


            DataUse.Category duc2 = new DataUse.Category();

            duc2.FillCurrentCategory(duc.CategoryId);

            if (string.IsNullOrEmpty(duc2.CategoryId))
            {
                Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("category_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }

            if (!duc2.CategoryActive.ZeroOneToBoolean())
            {
                Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("category_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }


            // Check Category Access Show
            if (!duc2.GetCategoryAccessShowCheck(duc.CategoryId))
            {
                Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_category", StaticObject.GetCurrentSiteGlobalLanguage())));
                return;
            }

            ContentClass cc = new ContentClass();
            string Content = cc.GetCurrentContent(ContentId, ccoc.GroupId);

            if (string.IsNullOrEmpty(Content))
            {
                Template.GetSiteTemplate("part/content_not_exist");
                return;
            }


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_content_text", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();


                // If Content Protection By Password
                string ContentText = (string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? dbdr.dr["content_text"].ToString().Replace("<hr class=\"el_read_more\">", null).Replace("&gt;", ">").Replace("&lt;", "<") : Template.GetSiteGlobalTemplate("part/show_protection_content_by_password").Replace("$_asp content_id;", dbdr.dr["content_id"].ToString()).Replace("$_asp captcha;", Security.GetCaptchaImage());

                Write(ContentText);
            }

            db.Close();
        }
    }
}