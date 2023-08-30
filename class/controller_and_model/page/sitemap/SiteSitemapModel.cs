using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteSitemapModel : CodeBehindModel
    {
        public void SetValue()
        {
            // Set Value
            XmlDocument SitemapOptionDocument = new XmlDocument();
            SitemapOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/sitemap_option/option/sitemap_option.xml"));

            XmlNode SitemapOptionNode = SitemapOptionDocument.SelectSingleNode("sitemap_option_root");

            bool ActiveLanguage = SitemapOptionNode["language"].Attributes["active"].Value == "true";
            bool ActiveSite = SitemapOptionNode["site"].Attributes["active"].Value == "true";
            bool ActivePage = SitemapOptionNode["page"].Attributes["active"].Value == "true";
            bool ActiveContentType = SitemapOptionNode["content_type"].Attributes["active"].Value == "true";
            bool ActiveCategory = SitemapOptionNode["category"].Attributes["active"].Value == "true";
            bool ActiveLink = SitemapOptionNode["link"].Attributes["active"].Value == "true";

            XmlNode SiteMapItemNode = Template.GetXmlNodeFromSiteTemplate("part/sitemap/item");

            List<string> ItemList = new List<string>();
            List<string> BoxList = new List<string>();

            foreach (XmlNode ChildNode in SiteMapItemNode.ChildNodes)
            {
                ItemList.Add(ChildNode.Name);
                BoxList.Add(null);
            }

            string SiteMapBoxTemplate = Template.GetSiteTemplate("part/sitemap/box");
            string SiteMapListItemTemplate = Template.GetSiteTemplate("part/sitemap/list_item");

            string SumSiteMapListItemTemplate = "";


            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = null;
            List<string> list = new List<string>();

            if (ActiveSite)
            {
                // Set Site
                string SiteMapSiteBoxTemplate = Template.GetSiteTemplate("part/sitemap/static_item/site/box");
                string SiteMapSiteListItemTemplate = Template.GetSiteTemplate("part/sitemap/static_item/site/list_item");

                string TmpSiteMapSiteListItemTemplate = "";
                string SumSiteMapSiteListItemTemplate = "";

                DataBaseSocket db1 = new DataBaseSocket();

                dbdr.dr = db1.GetProcedure("get_site_name_and_global_name_list");

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpSiteMapSiteListItemTemplate = SiteMapSiteListItemTemplate;

                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp site_global_name;", dbdr.dr["site_global_name"].ToString());
                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp site_name;", Language.GetHandheldLanguage(dbdr.dr["site_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));

                        SumSiteMapSiteListItemTemplate += TmpSiteMapSiteListItemTemplate;
                    }

                db1.Close();

                BoxList[ItemList.IndexOf("site")] = SiteMapSiteBoxTemplate.Replace("$_asp item;", SumSiteMapSiteListItemTemplate);
            }

            if (ActiveContentType)
            {
                // Set Content Type
                string SiteMapContentTypeBoxTemplate = Template.GetSiteTemplate("part/sitemap/static_item/content_type/box");
                string SiteMapContentTypeListItemTemplate = Template.GetSiteTemplate("part/sitemap/static_item/content_type/list_item");

                string TmpSiteMapContentTypeListItemTemplate = "";
                string SumSiteMapContentTypeListItemTemplate = "";

                // Set Content Type Item
                ListClass.Content lcc = new ListClass.Content();
                lcc.FillContentTypeListItem(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (ListItem item in lcc.ContentTypeListItem)
                {
                    TmpSiteMapContentTypeListItemTemplate = SiteMapContentTypeListItemTemplate;

                    TmpSiteMapContentTypeListItemTemplate = TmpSiteMapContentTypeListItemTemplate.Replace("$_asp content_type_value;", item.Value);
                    TmpSiteMapContentTypeListItemTemplate = TmpSiteMapContentTypeListItemTemplate.Replace("$_asp content_type_name;", item.Text);

                    SumSiteMapContentTypeListItemTemplate += TmpSiteMapContentTypeListItemTemplate;
                }

                BoxList[ItemList.IndexOf("content_type")] = SiteMapContentTypeBoxTemplate.Replace("$_asp item;", SumSiteMapContentTypeListItemTemplate);
            }


            if (ActiveCategory)
            {
                // Set Category
                string SiteMapCategoryBoxTemplate = Template.GetSiteTemplate("part/sitemap/static_item/category/box");
                string SiteMapCategoryListItemTemplate = Template.GetSiteTemplate("part/sitemap/static_item/category/list_item");

                string TmpSiteMapCategoryListItemTemplate = "";
                string SumSiteMapCategoryListItemTemplate = "";

                string SpaceTemplate = Template.GetSiteTemplate("part/space");

                // Set Category Item
                ListClass.Category lcc = new ListClass.Category();
                lcc.FillCategoryListItemTree(StaticObject.GetCurrentSiteSiteId(), SpaceTemplate);


                // Set Extra Catgory Url Value
                ExtraValue evc = new ExtraValue();

                evc.SiteGlobalName = StaticObject.GetCurrentSiteSiteGlobalName();

                DataUse.Site dus = new DataUse.Site();
                evc.SiteName = dus.GetSiteNameBySiteId(StaticObject.GetCurrentSiteSiteId());

                DataUse.Category duc = new DataUse.Category();

                int CategoryIndexer = 0;
                foreach (ListItem item in lcc.CategoryListItemTree)
                {
                    evc.CategoryId = item.Value;

                    CategoryClass cc = new CategoryClass();
                    evc.ParrentCategory = cc.GetParentCategory(StaticObject.GetCurrentSiteSiteGlobalName(), item.Value);
                    evc.CategoryName = duc.GetCategoryName(item.Value);


                    TmpSiteMapCategoryListItemTemplate = SiteMapCategoryListItemTemplate;

                    TmpSiteMapCategoryListItemTemplate = TmpSiteMapCategoryListItemTemplate.Replace("$_asp category_name;", lcc.CategoryListItemOnlySpace[CategoryIndexer].Text + Language.GetHandheldLanguage(lcc.CategoryListItemTreeWithoutSpace[CategoryIndexer].Text, StaticObject.GetCurrentSiteGlobalLanguage()));
                    TmpSiteMapCategoryListItemTemplate = TmpSiteMapCategoryListItemTemplate.Replace("$_asp category_id;", item.Value);

                    TmpSiteMapCategoryListItemTemplate = TmpSiteMapCategoryListItemTemplate.Replace("$_asp category_value;", duc.GetCategoryName(item.Value));

                    TmpSiteMapCategoryListItemTemplate = TmpSiteMapCategoryListItemTemplate.Replace("$_asp extra_category_url_value;", evc.GetCategoryUrlValue());

                    SumSiteMapCategoryListItemTemplate += TmpSiteMapCategoryListItemTemplate;

                    CategoryIndexer++;
                }
                BoxList[ItemList.IndexOf("category")] = SiteMapCategoryBoxTemplate.Replace("$_asp item;", SumSiteMapCategoryListItemTemplate);
            }


            if (ActivePage)
            {
                // Set Page
                string SiteMapSiteBoxTemplate = Template.GetSiteTemplate("part/sitemap/static_item/page/box");
                string SiteMapSiteListItemTemplate = Template.GetSiteTemplate("part/sitemap/static_item/page/list_item");

                string TmpSiteMapSiteListItemTemplate = "";
                string SumSiteMapSiteListItemTemplate = "";

                DataBaseSocket db2 = new DataBaseSocket();
                dbdr.dr = db2.GetProcedure("get_page");


                // Set Extra Page Url Value
                ExtraValue evc = new ExtraValue();
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                evc.SiteGlobalName = ccoc.SiteSiteGlobalName;

                DataUse.Site dus = new DataUse.Site();
                evc.SiteName = dus.GetSiteNameBySiteId(ccoc.SiteId);


                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        // Page Exception
                        switch (dbdr.dr["page_global_name"].ToString())
                        {
                            case "error": continue;
                            case "logout": continue;
                            case "print": continue;
                            case "content_reply": continue;
                            case "comment_reply": continue;
                        }

                        if (ccoc.RoleDominantType == "guest" && dbdr.dr["page_category"].ToString() == "member")
                            continue;

                        if (!dbdr.dr["page_show_link_in_site"].ToString().TrueFalseToBoolean())
                            continue;


                        evc.PageId = dbdr.dr["page_id"].ToString();
                        evc.PageTitle = dbdr.dr["page_title"].ToString();
                        evc.PageGlobalName = dbdr.dr["page_global_name"].ToString();


                        TmpSiteMapSiteListItemTemplate = SiteMapSiteListItemTemplate;

                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp page_global_name;", dbdr.dr["page_global_name"].ToString());
                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp page_name;", Language.GetHandheldLanguage(dbdr.dr["page_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));

                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp extra_page_url_value;", evc.GetPageUrlValue());

                        SumSiteMapSiteListItemTemplate += TmpSiteMapSiteListItemTemplate;
                    }

                db2.Close();

                BoxList[ItemList.IndexOf("page")] = SiteMapSiteBoxTemplate.Replace("$_asp item;", SumSiteMapSiteListItemTemplate);
            }

            if (ActiveLanguage)
            {
                // Set Language
                string SiteMapSiteBoxTemplate = Template.GetSiteTemplate("part/sitemap/static_item/language/box");
                string SiteMapSiteListItemTemplate = Template.GetSiteTemplate("part/sitemap/static_item/language/list_item");

                string TmpSiteMapSiteListItemTemplate = "";
                string SumSiteMapSiteListItemTemplate = "";

                DataBaseSocket db3 = new DataBaseSocket();
                dbdr.dr = db3.GetProcedure("get_active_language_name_and_global_name_list");

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpSiteMapSiteListItemTemplate = SiteMapSiteListItemTemplate;

                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp language_global_name;", dbdr.dr["language_global_name"].ToString());
                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp language_name;", Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));

                        SumSiteMapSiteListItemTemplate += TmpSiteMapSiteListItemTemplate;
                    }

                db3.Close();

                BoxList[ItemList.IndexOf("language")] = SiteMapSiteBoxTemplate.Replace("$_asp item;", SumSiteMapSiteListItemTemplate);
            }

            if (ActiveLink)
            {
                // Set Link
                string SiteMapSiteBoxTemplate = Template.GetSiteTemplate("part/sitemap/static_item/link/box");
                string SiteMapSiteListItemTemplate = Template.GetSiteTemplate("part/sitemap/static_item/link/list_item");

                string TmpSiteMapSiteListItemTemplate = "";
                string SumSiteMapSiteListItemTemplate = "";

                DataBaseSocket db4 = new DataBaseSocket();
                dbdr.dr = db4.GetProcedure("get_link_value_and_title_and_href_list");

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpSiteMapSiteListItemTemplate = SiteMapSiteListItemTemplate;

                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp link_value;", dbdr.dr["link_value"].ToString());
                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp link_title;", dbdr.dr["link_title"].ToString());
                        TmpSiteMapSiteListItemTemplate = TmpSiteMapSiteListItemTemplate.Replace("$_asp link_href;", dbdr.dr["link_href"].ToString());

                        SumSiteMapSiteListItemTemplate += TmpSiteMapSiteListItemTemplate;
                    }

                db4.Close();

                BoxList[ItemList.IndexOf("link")] = SiteMapSiteBoxTemplate.Replace("$_asp item;", SumSiteMapSiteListItemTemplate);
            }

            foreach (string Text in BoxList)
                SumSiteMapListItemTemplate += Text;

            Write(SiteMapBoxTemplate.Replace("$_asp item;", SumSiteMapListItemTemplate));
        }
    }
}