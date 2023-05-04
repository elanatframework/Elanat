using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ExtraHelperRssOptionModel
    {
        public string RssOptionLanguage { get; set; }
        public string FeedCountLanguage { get; set; }
        public string ContentTextLengthLanguage { get; set; }
        public string RssCacheLanguage { get; set; }
        public string UseRemoveHtmlTagLanguage { get; set; }
        public string ActiveAuthorFeedLanguage { get; set; }
        public string ActiveCategoryFeedLanguage { get; set; }
        public string ActiveContentTypeFeedLanguage { get; set; }
        public string SaveRssOptionLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public bool UseRemoveHtmlTagValue { get; set; } = false;
        public bool ActiveAuthorFeedValue { get; set; } = false;
        public bool ActiveCategoryFeedValue { get; set; } = false;
        public bool ActiveContentTypeFeedValue { get; set; } = false;

        public string FeedCountValue { get; set; }
        public string ContentTextLengthValue { get; set; }
        public string RssCacheValue { get; set; }

        public string FeedCountAttribute { get; set; }
        public string ContentTextLengthAttribute { get; set; }
        public string RssCacheAttribute { get; set; }

        public string FeedCountCssClass { get; set; }
        public string ContentTextLengthCssClass { get; set; }
        public string RssCacheCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/rss_option/");
            RssOptionLanguage = aol.GetAddOnsLanguage("rss_option");
            ContentTextLengthLanguage = aol.GetAddOnsLanguage("content_text_length");
            FeedCountLanguage = aol.GetAddOnsLanguage("feed_count");
            RssCacheLanguage = aol.GetAddOnsLanguage("rss_cache");
            UseRemoveHtmlTagLanguage = aol.GetAddOnsLanguage("use_remove_html_tag");
            ActiveAuthorFeedLanguage = aol.GetAddOnsLanguage("active_author_feed");
            ActiveCategoryFeedLanguage = aol.GetAddOnsLanguage("active_category_feed");
            ActiveContentTypeFeedLanguage = aol.GetAddOnsLanguage("active_content_type_feed");
            SaveRssOptionLanguage = aol.GetAddOnsLanguage("save_rss_option");


            // Set Current Value
            if (IsFirstStart)
            {
                XmlDocument RssOptionDocument = new XmlDocument();
                RssOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/rss_option/option/rss_option.xml"));

                XmlNode node = RssOptionDocument.SelectSingleNode("rss_option_root");

                FeedCountValue = node["feed_count"].Attributes["value"].Value;
                ContentTextLengthValue = node["content_text_length"].Attributes["value"].Value;
                RssCacheValue = node["rss_cache"].Attributes["value"].Value;
                UseRemoveHtmlTagValue = (node["use_remove_html_tag"].Attributes["active"].Value == "true");
                ActiveAuthorFeedValue = (node["author_feed"].Attributes["active"].Value == "true");
                ActiveCategoryFeedValue = (node["category_feed"].Attributes["active"].Value == "true");
                ActiveContentTypeFeedValue = (node["content_type_feed"].Attributes["active"].Value == "true");
            }
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_FeedCount", "");
            InputRequest.Add("txt_ContentTextLength", "");
            InputRequest.Add("txt_RssCache", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "add_on/extra_helper/rss_option/");

            FeedCountAttribute += vc.ImportantInputAttribute["txt_FeedCount"];
            ContentTextLengthAttribute += vc.ImportantInputAttribute["txt_ContentTextLength"];
            RssCacheAttribute += vc.ImportantInputAttribute["txt_RssCache"];

            FeedCountCssClass = FeedCountCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FeedCount"]);
            ContentTextLengthCssClass = ContentTextLengthCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ContentTextLength"]);
            RssCacheCssClass = RssCacheCssClass.AddHtmlClass(vc.ImportantInputClass["txt_RssCache"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.SitePath + "add_on/extra_helper/rss_option/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //FeedCountCssClass = FeedCountCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FeedCount"]);
                //ContentTextLengthCssClass = ContentTextLengthCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ContentTextLength"]);
                //RssCacheCssClass = RssCacheCssClass.AddHtmlClass(vc.WarningFieldClass["txt_RssCache"]);
            }
        }

        public void SaveRssOption()
        {
            XmlDocument RssOptionDocument = new XmlDocument();
            RssOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/rss_option/option/rss_option.xml"));

            RssOptionDocument.SelectSingleNode("rss_option_root/feed_count").Attributes["value"].Value = FeedCountValue;
            RssOptionDocument.SelectSingleNode("rss_option_root/content_text_length").Attributes["value"].Value = ContentTextLengthValue;
            RssOptionDocument.SelectSingleNode("rss_option_root/rss_cache").Attributes["value"].Value = RssCacheValue;

            RssOptionDocument.SelectSingleNode("rss_option_root/use_remove_html_tag").Attributes["active"].Value = UseRemoveHtmlTagValue.BooleanToTrueFalse();
            RssOptionDocument.SelectSingleNode("rss_option_root/author_feed").Attributes["active"].Value = ActiveAuthorFeedValue.BooleanToTrueFalse();
            RssOptionDocument.SelectSingleNode("rss_option_root/category_feed").Attributes["active"].Value = ActiveCategoryFeedValue.BooleanToTrueFalse();
            RssOptionDocument.SelectSingleNode("rss_option_root/content_type_feed").Attributes["active"].Value = ActiveContentTypeFeedValue.BooleanToTrueFalse();

            RssOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/rss_option/option/rss_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_rss_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("rss_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/rss_option/"), "success");
        }
    }
}