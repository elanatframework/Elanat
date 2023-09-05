using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteSitemapWriterModel : CodeBehindModel
    {
        public void SetValue(HttpContext context)
        {
            // Xml Sitemap Extra Helper Active Check
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
            string XmlSitemapExtraHelperId = dueh.GetExtraHelperIdByExtraHelperName("xml_sitemap_option");
            dueh.FillCurrentExtraHelper(XmlSitemapExtraHelperId);

            if (!dueh.ExtraHelperActive.ZeroOneToBoolean())
            {
                Write(Language.GetLanguage("page_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage()));
                return;
            }


            // Get Xml Sitemap Cache
            string CacheKey = "el_xml_sitemap";

            if (!string.IsNullOrEmpty(context.Request.Query["site"]))
                CacheKey += ":" + context.Request.Query["site"].ToString();

            CacheClass cc = new CacheClass();

            if (cc.ExistInDisk(CacheKey))
            {
                Write(cc.GetValue("disk", CacheKey));
                return;
            }


            // Set Value
            XmlDocument XmlSitemapOptionDocument = new XmlDocument();
            XmlSitemapOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/option/xml_sitemap_option.xml"));

            XmlNode XmlSitemapNode = XmlSitemapOptionDocument.SelectSingleNode("xml_sitemap_option_root");

            int XmlSitemapCount = int.Parse(XmlSitemapNode["xml_sitemap_count"].Attributes["value"].Value);
            int XmlSitemapCache = int.Parse(XmlSitemapNode["xml_sitemap_cache"].Attributes["value"].Value);


            string siteMainUrl = GlobalClass.GetSiteMainUrl();

            string SiteGlobalName = "";
            if (!string.IsNullOrEmpty(context.Request.Query["site"]))
                SiteGlobalName = context.Request.Query["site"].ToString();

            string SitemapBoxStruct = Struct.GetNode("site_map/sitemap_box").InnerText;
            string SiteListItemStruct = Struct.GetNode("site_map/list_item/site").InnerText;
            string TmpSiteListItemStruct = "";
            string SumSiteListItemStruct = "";


            // Set Current Value
            ListClass.Site lcs = new ListClass.Site();

            DataUse.Site dus = new DataUse.Site();


            // Set Site Struct
            if (string.IsNullOrEmpty(SiteGlobalName))
            {
                lcs.FillSiteGlobalNameListItem();

                foreach (ListItem item in lcs.SiteGlobalNameListItem)
                {
                    string LastContentDateTimeCreate = dus.GetLastContentDateTimeCreateFromSiteId(item.Value);

                    if (string.IsNullOrEmpty(LastContentDateTimeCreate))
                        continue;

                    string SiteLastMod = string.Format("{0:yyyy-MM-ddTHH:mm:sszzz}", DateTime.Parse(LastContentDateTimeCreate));

                    TmpSiteListItemStruct = SiteListItemStruct;

                    TmpSiteListItemStruct = TmpSiteListItemStruct.Replace("$_asp site_url_path;", siteMainUrl);
                    TmpSiteListItemStruct = TmpSiteListItemStruct.Replace("$_asp site_global_name;", item.Text);
                    TmpSiteListItemStruct = TmpSiteListItemStruct.Replace("$_asp date_time;", SiteLastMod);

                    SumSiteListItemStruct += TmpSiteListItemStruct;

                    XmlSitemapCount--;
                }

                SitemapBoxStruct = SitemapBoxStruct.Replace("$_asp item;", SumSiteListItemStruct);
                Write(SitemapBoxStruct);

                return;
            }

            string SiteId = dus.GetSiteIdBySiteGlobalName(SiteGlobalName);

            if (string.IsNullOrEmpty(SiteId))
                return;

            string UrlBoxStruct = Struct.GetNode("site_map/url_box").InnerText;
            string PageListItemStruct = Struct.GetNode("site_map/list_item/page").InnerText;
            string CategoryListItemStruct = Struct.GetNode("site_map/list_item/category").InnerText;
            string ContentListItemStruct = Struct.GetNode("site_map/list_item/content").InnerText;
            string TmpPageListItemStruct = "";
            string SumPageListItemStruct = "";
            string TmpCategoryListItemStruct = "";
            string SumCategoryListItemStruct = "";
            string TmpContentListItemStruct = "";
            string SumContentListItemStruct = "";


            // Set Page Struct
            string DefaultPageId = dus.GetSiteDefaultPage(SiteId);

            lcs.FillSitePageNameShowInSiteListItem(SiteId, StaticObject.GetCurrentSiteGlobalLanguage());

            // Set Default Page
            TmpPageListItemStruct = PageListItemStruct;

            TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp site_url_path;", siteMainUrl);

            if (ElanatConfig.GetNode("properties/default_site").Attributes["value"].Value == SiteGlobalName)
            {
                TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp extra_page_url_value;", "");
                TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp priority;", "1");
            }
            else
            {
                TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp extra_page_url_value;", "site/" + SiteGlobalName + "/");
                TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp priority;", "0.9");
            }

            SumPageListItemStruct += TmpPageListItemStruct;

            XmlSitemapCount--;


            if ((XmlSitemapCount - lcs.SitePageNameShowInSiteListItem.Count) >= 0)
            {
                // Set Extra Page Url Value
                ExtraValue evc = new ExtraValue();
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                evc.SiteGlobalName = ccoc.SiteSiteGlobalName;
                evc.SiteName = dus.GetSiteNameBySiteId(ccoc.SiteId);

                DataUse.Page dup = new DataUse.Page();
                string DefaultPageGlobalName = dup.GetPageGlobalName(DefaultPageId);

                foreach (ListItem item in lcs.SitePageNameShowInSiteListItem)
                {
                    if (item.Value == DefaultPageGlobalName)
                        continue;

                    evc.PageId = dup.GetPageIdByPageGlobalName(item.Value);
                    evc.PageTitle = dup.GetPageTitleByPageId(evc.PageId);

                    evc.PageGlobalName = item.Value;


                    TmpPageListItemStruct = PageListItemStruct;

                    TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp site_url_path;", siteMainUrl);
                    TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp page_global_name;", item.Value);
                    TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp priority;", "0.7");
                    TmpPageListItemStruct = TmpPageListItemStruct.Replace("$_asp extra_page_url_value;", evc.GetPageUrlValue());

                    SumPageListItemStruct += TmpPageListItemStruct;

                    XmlSitemapCount--;
                }
            }


            // Set Category Struct
            CategoryClass cc2 = new CategoryClass();
            XmlNode CategoryNode = cc2.GetSaveCategoryNode(SiteGlobalName);

            if ((XmlSitemapCount - CategoryNode.ChildNodes.Count) >= 0)
            {
                // Set Extra Catgory Url Value
                ExtraValue evc = new ExtraValue();

                evc.SiteGlobalName = SiteGlobalName;

                DataUse.Site dus2 = new DataUse.Site();
                evc.SiteName = dus2.GetSiteNameBySiteId(SiteId);

                foreach (XmlNode node in CategoryNode.ChildNodes)
                {
                    evc.CategoryId = node.Attributes["id"].Value;

                    evc.ParrentCategory = cc2.GetParentCategory(StaticObject.GetCurrentSiteSiteGlobalName(), node.Attributes["id"].Value);
                    evc.CategoryName = node.Attributes["name"].Value;


                    TmpCategoryListItemStruct = CategoryListItemStruct;

                    TmpCategoryListItemStruct = TmpCategoryListItemStruct.Replace("$_asp site_url_path;", siteMainUrl);
                    TmpCategoryListItemStruct = TmpCategoryListItemStruct.Replace("$_asp category_name;", node.Attributes["name"].Value);
                    TmpCategoryListItemStruct = TmpCategoryListItemStruct.Replace("$_asp date_time;", CategoryLastMod(node.Attributes["id"].Value));
                    TmpCategoryListItemStruct = TmpCategoryListItemStruct.Replace("$_asp change_freq;", GetCategoryChangeFreq(node.Attributes["id"].Value));
                    TmpCategoryListItemStruct = TmpCategoryListItemStruct.Replace("$_asp priority;", GetSubCategoryPriority(node.Attributes["space"].Value.Length.ToString()));

                    TmpCategoryListItemStruct = TmpCategoryListItemStruct.Replace("$_asp extra_category_url_value;", evc.GetCategoryUrlValue());


                    SumCategoryListItemStruct += TmpCategoryListItemStruct;

                    XmlSitemapCount--;
                }
            }


            // Set Content Struct
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content", "@inner_attach", "where el_site.site_id = " + SiteId);

            if ((XmlSitemapCount - CategoryNode.ChildNodes.Count) >= 0)
            {
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


                        TmpContentListItemStruct = ContentListItemStruct;

                        TmpContentListItemStruct = TmpContentListItemStruct.Replace("$_asp site_url_path;", siteMainUrl);
                        TmpContentListItemStruct = TmpContentListItemStruct.Replace("$_asp content_id;", dbdr.dr["content_id"].ToString());
                        TmpContentListItemStruct = TmpContentListItemStruct.Replace("$_asp content_title;", dbdr.dr["content_title"].ToString());
                        TmpContentListItemStruct = TmpContentListItemStruct.Replace("$_asp priority;", "0.15");

                        TmpContentListItemStruct = TmpContentListItemStruct.Replace("$_asp extra_content_url_value;", evc.GetContentUrlValue());

                        SumContentListItemStruct += TmpContentListItemStruct;

                        XmlSitemapCount--;
                    }

                db.Close();
            }

            UrlBoxStruct = UrlBoxStruct.Replace("$_asp item;", SumPageListItemStruct + SumCategoryListItemStruct + SumContentListItemStruct);

            Write(UrlBoxStruct);

            new HttpContextAccessor().HttpContext.Response.ContentType = "text/xml";

            // Set Xml Sitemap Cache
            cc.Insert("disk", CacheKey, UrlBoxStruct, XmlSitemapCache);
        }

        private string CategoryLastMod(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_last_content_category_date_time", "@category_id", CategoryId);

            string CategoryLastMod = "";

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                CategoryLastMod = string.Format("{0:yyyy-MM-ddTHH:mm:sszzz}", DateTime.Parse(ElanatConfig.GetNode("date_and_time/site_birthday").InnerText));

                db.Close();
                return CategoryLastMod;
            }

            dbdr.dr.Read();

            CategoryLastMod = string.Format("{0:yyyy-MM-ddTHH:mm:sszzz}", DateTime.Parse(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString()));

            db.Close();

            return CategoryLastMod;
        }

        private string GetCategoryChangeFreq(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_three_last_content_category_date", "@category_id", CategoryId);

            List<string> LastDate = new List<string>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    LastDate.Add(dbdr.dr["content_date_create"].ToString());

            db.Close();

            if (LastDate.Count > 2)
                return GetContentFreqTime(LastDate[0], LastDate[1], LastDate[2]);
            if (LastDate.Count == 2)
                return GetContentFreqTime(LastDate[0], LastDate[1], DateAndTime.GetDate("yyyy/MM/dd"));
            if (LastDate.Count == 1)
                return GetContentFreqTime(ElanatConfig.GetNode("date_and_time/site_birthday").InnerText, LastDate[0], DateAndTime.GetDate("yyyy/MM/dd"));

            return "never";
        }

        private string GetSubCategoryPriority(string CategorySubCategoryCount)
        {
            float Space = float.Parse(CategorySubCategoryCount) + 1;
            return "0." + Math.Round(10 + (50 / Space)).ToString();
        }

        private string GetContentFreqTime(string Date1, string Date2, string Date3)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_date_range", new List<string>() { "@date1", "@date2", "@date3" }, new List<string>() { Date1, Date2, Date3 });

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            DateTime DateT1 = Convert.ToDateTime(Date1);
            DateTime DateT2 = Convert.ToDateTime(Date2);
            DateTime DateT3 = Convert.ToDateTime(Date3);
            DateTime DateNow = Convert.ToDateTime(DateAndTime.GetDate("yyyy/MM/dd"));

            int TimeCount = Convert.ToInt32(dbdr.dr["date_range_count"].ToString());

            long TimeDiff = DateT2.Subtract(DateT1).Days + DateT3.Subtract(DateT2).Days + DateNow.Subtract(DateT3).Days;

            db.Close();

            if (TimeCount > 24 && TimeDiff == 0)
                return "always";

            if (TimeCount > 24 && TimeDiff <= 2)
                return "hourly";

            if (TimeCount >= 3 && TimeDiff <= 2)
                return "daily";

            if (TimeCount >= 1 && TimeDiff <= 7)
                return "weekly";

            if (TimeCount >= 1 && TimeDiff <= 31)
                return "monthly";

            if (TimeCount >= 1 && TimeDiff <= 365)
                return "yearly";

            return "never";
        }
    }
}