using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteRssWriterModel : CodeBehindModel
    {
        public void SetValue(List<ListItem> QueryString)
        {
            // Rss Extra Helper Active Check
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
            string RssExtraHelperId = dueh.GetExtraHelperIdByExtraHelperName("rss_option");
            dueh.FillCurrentExtraHelper(RssExtraHelperId);

            if (!dueh.ExtraHelperActive.ZeroOneToBoolean())
            {
                Write(Language.GetLanguage("page_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage()));
                return;
            }


            // Get Rss Cache
            string CacheKey = "el_rss";

            if (!string.IsNullOrEmpty(QueryString.GetValue("site")))
                CacheKey += ":" + QueryString.GetValue("site");

            if (!string.IsNullOrEmpty(QueryString.GetValue("user_id")))
                CacheKey += ":" + QueryString.GetValue("user_id");

            if (!string.IsNullOrEmpty(QueryString.GetValue("category_name")))
                CacheKey += ":" + QueryString.GetValue("category_name");

            if (!string.IsNullOrEmpty(QueryString.GetValue("content_type")))
                CacheKey += ":" + QueryString.GetValue("content_type");

            CacheClass cc = new CacheClass();

            if (cc.ExistInDisk(CacheKey))
            {
                Write(cc.GetValue("disk", CacheKey));
                return;
            }


            // Set Value
            XmlDocument RssOptionDocument = new XmlDocument();
            RssOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/rss_option/option/rss_option.xml"));

            XmlNode node = RssOptionDocument.SelectSingleNode("rss_option_root");

            string FeedCount = node["feed_count"].Attributes["value"].Value;
            int ContentTextCount = int.Parse(node["content_text_length"].Attributes["value"].Value);
            int RssCache = int.Parse(node["rss_cache"].Attributes["value"].Value);
            bool UseRemoveHtmlTag = node["use_remove_html_tag"].Attributes["active"].Value == "true";
            bool ActiveAuthorFeed = node["author_feed"].Attributes["active"].Value == "true";
            bool ActiveCategoryFeed = node["category_feed"].Attributes["active"].Value == "true";
            bool ActiveContentTypeFeed = node["content_type_feed"].Attributes["active"].Value == "true";


            // Set Struct
            string RssBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/rss/box").InnerText;
            string RssListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/rss/list_item").InnerText;
            string TmpRssListItemStruct = "";
            string SumRssListItemStruct = "";


            // Set Rss Box Struct Value
            string LastBuildDate = DateAndTime.GetDate("ddd, dd MMM yyyy HH:mm:ss zzz");
            string CurrentDateYear = DateAndTime.GetDate("yyyy");

            DataUse.Site dus = new DataUse.Site();
            string SiteDateYear = dus.GetSiteDateCreate(StaticObject.GetCurrentSiteSiteId()).Substring(0, 4);


            RssBoxStruct = RssBoxStruct.Replace("$_asp site_date_year;", SiteDateYear);
            RssBoxStruct = RssBoxStruct.Replace("$_asp current_date_year;", CurrentDateYear);
            RssBoxStruct = RssBoxStruct.Replace("$_asp last_build_date;", LastBuildDate);
            RssBoxStruct = RssBoxStruct.Replace("$_lang _rss_title;", Language.GetLanguage("_rss_title", StaticObject.GetCurrentSiteGlobalLanguage()));
            RssBoxStruct = RssBoxStruct.Replace("$_lang _rss_description;", Language.GetLanguage("_rss_description", StaticObject.GetCurrentSiteGlobalLanguage()));
            RssBoxStruct = RssBoxStruct.Replace("$_asp language_global_name;", StaticObject.GetCurrentSiteGlobalLanguage());
            RssBoxStruct = RssBoxStruct.Replace("$_lang copyright;", Language.GetLanguage("copyright", StaticObject.GetCurrentSiteGlobalLanguage()));
            RssBoxStruct = RssBoxStruct.Replace("$_lang some_rights_reserved;", Language.GetLanguage("some_rights_reserved", StaticObject.GetCurrentSiteGlobalLanguage()));
            RssBoxStruct = RssBoxStruct.Replace("$_lang elanat_rss_feed;", Language.GetLanguage("elanat_rss_feed", StaticObject.GetCurrentSiteGlobalLanguage()));



            string InnerAttach = "where el_site.site_id=" + StaticObject.GetCurrentSiteSiteId();
            string OuterAttach = "order by content_date_create desc,content_time_create desc";


            // Set Site Feed
            if (!string.IsNullOrEmpty(QueryString.GetValue("site")) && ActiveAuthorFeed)
                if (QueryString.GetValue("site").IsNumber())
                {
                    string SiteId = dus.GetSiteIdBySiteGlobalName(QueryString.GetValue("site").ProtectSqlInjection());

                    InnerAttach = "where el_site.site_id=" + SiteId;
                }

            // Set Content Type Feed
            if (!string.IsNullOrEmpty(QueryString.GetValue("content_type")) && ActiveContentTypeFeed)
            {
                string ContentType = QueryString.GetValue("content_type").ProtectSqlInjection();

                InnerAttach += " and el_content.content_type='" + ContentType + "'";
            }

            // Set Author Feed
            if (!string.IsNullOrEmpty(QueryString.GetValue("user_id")) && ActiveAuthorFeed)
                if (QueryString.GetValue("user_id").IsNumber())
                {
                    string Author = QueryString.GetValue("user_id").ProtectSqlInjection();

                    InnerAttach += " and el_user.user_id=" + Author;
                }

            DataUse.Category duc = new DataUse.Category();

            // Set Category Feed
            if (!string.IsNullOrEmpty(QueryString.GetValue("category_name")) && ActiveCategoryFeed)
            {
                string CategoryName = QueryString.GetValue("category_name").ProtectSqlInjection();

                string CategoryId = duc.GetCategoryIdByCategoryName(CategoryName);

                if (!string.IsNullOrEmpty(CategoryId))
                {
                    InnerAttach += " and el_category.category_id=" + CategoryId;
                }
            }

            InnerAttach += " and el_category.category_active=1 and el_content.content_status='active'";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content", new List<string>() { "@inner_attach", "@outer_attach", "@count" }, new List<string>() { InnerAttach, OuterAttach, FeedCount.ToString() });

            string ReadMoreRssText = Template.GetSiteTemplate("part/read_more_rss_text");
            string SitePath = GetCurrentPath() + StaticObject.SitePath;
            bool whileFirstChecker = true;

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    // Set Extra Content Url Value
                    ExtraValue evc = new ExtraValue();

                    evc.SiteGlobalName = dbdr.dr["site_global_name"].ToString();
                    evc.SiteName = dbdr.dr["site_name"].ToString();
                    evc.ContentId = dbdr.dr["content_id"].ToString();
                    evc.ContentTitle = dbdr.dr["content_title"].ToString();
                    evc.CategoryId = dbdr.dr["category_id"].ToString();

                    CategoryClass category = new CategoryClass();

                    evc.ParrentCategory = category.GetParentCategory(dbdr.dr["site_global_name"].ToString(), dbdr.dr["category_id"].ToString());
                    evc.CategoryName = category.CategoryName;


                    TmpRssListItemStruct = RssListItemStruct;

                    // If Content Protection By Password
                    string ContentText = (string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? dbdr.dr["content_text"].ToString().Replace("<hr class=\"el_read_more\">", null).Replace("&gt;", ">").Replace("&lt;", "<") : Template.GetSiteTemplate("part/password_protection/protection_content_by_password");

                    if (UseRemoveHtmlTag)
                    {
                        ContentText = StringClass.RemoveHtmlTags(ContentText);

                        if (ContentText.Length > ContentTextCount)
                        {
                            ContentText = ContentText.Substring(0, ContentTextCount) + ReadMoreRssText;
                        }
                    }

                    string ContentPublishDate = string.Format("{0:ddd, dd MMM yyyy HH:mm:ss zzz}", DateTime.Parse(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString()));

                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_db content_title;", StringClass.RemoveIllegalCharacters(dbdr.dr["content_title"].ToString()));
                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_db content_text;", StringClass.RemoveIllegalCharacters(ContentText));
                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_asp content_date_publish;", ContentPublishDate);
                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_db user_site_name;", StringClass.RemoveIllegalCharacters(dbdr.dr["user_site_name"].ToString()));
                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_asp site_path;", SitePath);

                    TmpRssListItemStruct = TmpRssListItemStruct.Replace("$_asp extra_content_url_value;", evc.GetContentUrlValue());

                    SumRssListItemStruct += TmpRssListItemStruct;


                    // Set Rss Publish Date
                    if (whileFirstChecker)
                    {
                        RssBoxStruct = RssBoxStruct.Replace("$_asp publish_date;", ContentPublishDate);
                        whileFirstChecker = false;
                    }
                }

            db.Close();

            // If Is Not Exist Content
            RssBoxStruct = RssBoxStruct.Replace("$_asp publish_date;", LastBuildDate);

            string RssContent = RssBoxStruct.Replace("$_asp item;", SumRssListItemStruct);

            Write(RssContent);

            new HttpContextAccessor().HttpContext.Response.ContentType = "text/xml";

            // Set Rss Cache
            cc.Insert("disk", CacheKey, RssContent, RssCache);
        }

        private string GetCurrentPath()
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            string Path = context.Request.Scheme + @"://" + context.Request.Host + context.Request.PathBase;

            return Path;
        }
    }
}