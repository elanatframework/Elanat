using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteRssModel : CodeBehindModel
    {
        public void SetValue()
        {
            XmlNode RssItemNode = Template.GetXmlNodeFromSiteTemplate("part/rss/item");

            List<string> ItemList = new List<string>();
            List<string> BoxList = new List<string>();

            foreach (XmlNode ChildNode in RssItemNode.ChildNodes)
            {
                ItemList.Add(ChildNode.Name);
                BoxList.Add(null);
            }

            string RssBoxTemplate = Template.GetSiteTemplate("part/rss/box");
            string RssListItemTemplate = Template.GetSiteTemplate("part/rss/list_item");

            string SumRssListItemTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            List<string> list = new List<string>();

            // Set Value
            XmlDocument RssOptionDocument = new XmlDocument();
            RssOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/rss_option/option/rss_option.xml"));

            XmlNode node = RssOptionDocument.SelectSingleNode("rss_option_root");

            bool ActiveCategoryFeed = node["category_feed"].Attributes["active"].Value == "true";
            bool ActiveContentTypeFeed = node["content_type_feed"].Attributes["active"].Value == "true";

            // Set Site
            string RssSiteBoxTemplate = Template.GetSiteTemplate("part/rss/static_item/site/box");
            string RssSiteListItemTemplate = Template.GetSiteTemplate("part/rss/static_item/site/list_item");

            string TmpRssSiteListItemTemplate = "";
            string SumRssSiteListItemTemplate = "";

            dbdr.dr = db.GetProcedure("get_site_name_and_global_name_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpRssSiteListItemTemplate = RssSiteListItemTemplate;

                    TmpRssSiteListItemTemplate = TmpRssSiteListItemTemplate.Replace("$_asp site_global_name;", dbdr.dr["site_global_name"].ToString());
                    TmpRssSiteListItemTemplate = TmpRssSiteListItemTemplate.Replace("$_asp site_name;", Language.GetHandheldLanguage(dbdr.dr["site_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));

                    SumRssSiteListItemTemplate += TmpRssSiteListItemTemplate;
                }

            db.Close();

            BoxList[ItemList.IndexOf("site")] = RssSiteBoxTemplate.Replace("$_asp item;", SumRssSiteListItemTemplate);


            if (ActiveContentTypeFeed)
            {
                // Set Content Type
                string RssContentTypeBoxTemplate = Template.GetSiteTemplate("part/rss/static_item/content_type/box");
                string RssContentTypeListItemTemplate = Template.GetSiteTemplate("part/rss/static_item/content_type/list_item");

                string TmpRssContentTypeListItemTemplate = "";
                string SumRssContentTypeListItemTemplate = "";

                // Set Content Type Item
                ListClass.Content lcc = new ListClass.Content();
                lcc.FillContentTypeListItem(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (ListItem item in lcc.ContentTypeListItem)
                {
                    TmpRssContentTypeListItemTemplate = RssContentTypeListItemTemplate;

                    TmpRssContentTypeListItemTemplate = TmpRssContentTypeListItemTemplate.Replace("$_asp content_type_value;", item.Value);
                    TmpRssContentTypeListItemTemplate = TmpRssContentTypeListItemTemplate.Replace("$_asp content_type_name;", item.Text);

                    SumRssContentTypeListItemTemplate += TmpRssContentTypeListItemTemplate;
                }

                BoxList[ItemList.IndexOf("content_type")] = RssContentTypeBoxTemplate.Replace("$_asp item;", SumRssContentTypeListItemTemplate);
            }


            if (ActiveCategoryFeed)
            {
                // Set Category
                string RssCategoryBoxTemplate = Template.GetSiteTemplate("part/rss/static_item/category/box");
                string RssCategoryListItemTemplate = Template.GetSiteTemplate("part/rss/static_item/category/list_item");

                string TmpRssCategoryListItemTemplate = "";
                string SumRssCategoryListItemTemplate = "";

                string SpaceTemplate = Template.GetSiteTemplate("part/space");

                // Set Category Item
                ListClass.Category lcc = new ListClass.Category();
                lcc.FillCategoryListItemTree(StaticObject.GetCurrentSiteSiteId(), SpaceTemplate);

                DataUse.Category duc = new DataUse.Category();

                int CategoryIndexer = 0;
                foreach (ListItem item in lcc.CategoryListItemTree)
                {
                    TmpRssCategoryListItemTemplate = RssCategoryListItemTemplate;

                    TmpRssCategoryListItemTemplate = TmpRssCategoryListItemTemplate.Replace("$_asp category_name;", lcc.CategoryListItemOnlySpace[CategoryIndexer].Text + Language.GetHandheldLanguage(lcc.CategoryListItemTreeWithoutSpace[CategoryIndexer].Text, StaticObject.GetCurrentSiteGlobalLanguage()));
                    TmpRssCategoryListItemTemplate = TmpRssCategoryListItemTemplate.Replace("$_asp category_id;", item.Value);

                    TmpRssCategoryListItemTemplate = TmpRssCategoryListItemTemplate.Replace("$_asp category_value;", duc.GetCategoryName(item.Value));

                    SumRssCategoryListItemTemplate += TmpRssCategoryListItemTemplate;

                    CategoryIndexer++;
                }
                BoxList[ItemList.IndexOf("category")] = RssCategoryBoxTemplate.Replace("$_asp item;", SumRssCategoryListItemTemplate);
            }

            foreach (string Text in BoxList)
                SumRssListItemTemplate += Text;

            Write(RssBoxTemplate.Replace("$_asp item;", SumRssListItemTemplate));
        }
    }
}