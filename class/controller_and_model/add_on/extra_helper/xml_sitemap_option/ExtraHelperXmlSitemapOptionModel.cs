using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperXmlSitemapOptionModel : CodeBehindModel
    {
        public string XmlSitemapOptionLanguage { get; set; }
        public string XmlSitemapCountLanguage { get; set; }
        public string XmlSitemapCacheLanguage { get; set; }
        public string SaveXmlSitemapOptionLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public string XmlSitemapCountValue { get; set; }
        public string XmlSitemapCacheValue { get; set; }

        public string XmlSitemapCountAttribute { get; set; }
        public string XmlSitemapCacheAttribute { get; set; }

        public string XmlSitemapCountCssClass { get; set; }
        public string XmlSitemapCacheCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/");
            XmlSitemapOptionLanguage = aol.GetAddOnsLanguage("xml_sitemap_option");
            XmlSitemapCountLanguage = aol.GetAddOnsLanguage("xml_sitemap_count");
            XmlSitemapCacheLanguage = aol.GetAddOnsLanguage("xml_sitemap_cache");
            SaveXmlSitemapOptionLanguage = aol.GetAddOnsLanguage("save_xml_sitemap_option");

            // Set Current Value
            if (IsFirstStart)
            {
                XmlDocument XmlSitemapOptionDocument = new XmlDocument();
                XmlSitemapOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/option/xml_sitemap_option.xml"));

                XmlNode node = XmlSitemapOptionDocument.SelectSingleNode("xml_sitemap_option_root");

                XmlSitemapCountValue = node["xml_sitemap_count"].Attributes["value"].Value;
                XmlSitemapCacheValue = node["xml_sitemap_cache"].Attributes["value"].Value;
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_XmlSitemapCount", "");
            InputRequest.Add("txt_XmlSitemapCache", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/");

            XmlSitemapCountAttribute += vc.ImportantInputAttribute.GetValue("txt_XmlSitemapCount");
            XmlSitemapCacheAttribute += vc.ImportantInputAttribute.GetValue("txt_XmlSitemapCache");

            XmlSitemapCountCssClass = XmlSitemapCountCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_XmlSitemapCount"));
            XmlSitemapCacheCssClass = XmlSitemapCacheCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_XmlSitemapCache"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveXmlSitemapOption()
        {
            XmlDocument XmlSitemapOptionDocument = new XmlDocument();
            XmlSitemapOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/option/xml_sitemap_option.xml"));

            XmlSitemapOptionDocument.SelectSingleNode("xml_sitemap_option_root/xml_sitemap_count").Attributes["value"].Value = XmlSitemapCountValue;
            XmlSitemapOptionDocument.SelectSingleNode("xml_sitemap_option_root/xml_sitemap_cache").Attributes["value"].Value = XmlSitemapCacheValue;

            XmlSitemapOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/option/xml_sitemap_option.xml"));

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_xml_sitemap_option", "_");

            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("xml_sitemap_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/xml_sitemap_option/"), "success");
        }
    }
}