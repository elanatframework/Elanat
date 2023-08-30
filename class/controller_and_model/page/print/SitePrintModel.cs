using CodeBehind;

namespace Elanat
{
    public partial class SitePrintModel : CodeBehindModel
    {
        public string PrintLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(string ContentId)
        {
			// Set Language
			PrintLanguage = Language.GetAddOnsLanguage("print", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/print/");


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_content", "@content_id", ContentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            string PrintTemplate = Template.GetSiteTemplate("page/print");

            PrintTemplate = PrintTemplate.Replace("$_asp content_id;", dbdr.dr["content_id"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp user_id;", dbdr.dr["user_id"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp category_name;", dbdr.dr["category_name"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp content_title;", dbdr.dr["content_title"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp content_date_create;", dbdr.dr["content_date_create"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp content_time_create;", dbdr.dr["content_time_create"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp content_type;", Language.GetLanguage(dbdr.dr["content_type"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));
            PrintTemplate = PrintTemplate.Replace("$_asp content_icon_physical_name;", dbdr.dr["content_icon_physical_name"].ToString());
            PrintTemplate = PrintTemplate.Replace("$_asp content_avatar_physical_name;", dbdr.dr["content_avatar_physical_name"].ToString());

            // If Content Protection By Password
            string ContentText = (string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? dbdr.dr["content_text"].ToString().Replace("<hr class=\"el_read_more\">", null).Replace("&gt;", ">").Replace("&lt;", "<") : Template.GetSiteGlobalTemplate("part/show_protection_content_by_password").Replace("$_asp content_id;", dbdr.dr["content_id"].ToString()).Replace("$_asp captcha;", Security.GetCaptchaImage());
            PrintTemplate = PrintTemplate.Replace("$_asp content_text;", ContentText);

            db.Close();


            // Set Content Keywords
            ContentClass cc = new ContentClass();
            PrintTemplate = PrintTemplate.Replace("$_asp content_keywords;", cc.GetContentKeywords(ContentId));


            ContentValue = PrintTemplate;
        }
    }
}