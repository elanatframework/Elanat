using System.Xml;

namespace Elanat.wwwroot 
{
    public class Root
    {
        public Root() { }
    }
}

namespace Elanat
{
    public class GlobalClass
    {
        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string Alert(string Text, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Text);
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            return AlertTemplate;
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string AlertWithReplace(string Text, string OldString, string NewString, string Priority = "none")
        {
            return Alert(Text.Replace(OldString, NewString), Priority);
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string AlertStoredLanguageVariant(string Text, string GlobalLanguage, string Priority = "none") 
        {
            return Template.GetGlobalTemplate("part/alert", GlobalLanguage).Replace("$_asp priority;", Priority).Replace("$_asp alert_text;", Language.GetLanguage(Text, GlobalLanguage));
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string AlertAddOnsLanguageVariant(string Text, string GlobalLanguage, string Priority = "none", string Path = null)
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Language.GetAddOnsLanguage(Text, GlobalLanguage, Path));
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            return AlertTemplate;
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string AlertLanguageVariant( string Text, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Language.GetLanguage(Text, GlobalLanguage));
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            return AlertTemplate;
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string AlertLanguageVariantWithReplace(string Text, string OldString, string NewString, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Language.GetLanguage(Text, GlobalLanguage).Replace(OldString, NewString));
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            return AlertTemplate;
        }

        public static string Confirm(string Text, string ClientOnClickFunction)
        {
            return ElanatConfig.GetNode("part/confirm").InnerText.Replace("$_asp alert_text;", Text);
        }

        public static string ConfirmStoredText(string Text, string ClientOnClickFunction)
        {
            return ElanatConfig.GetNode("part/confirm").InnerText.Replace("$_asp alert_text;", Language.GetLanguage(Text, StaticObject.GetCurrentAdminGlobalLanguage()));
        }

        public static string GetSitePath()
        {
            string SitePath = ElanatConfig.GetNode("properties/site_path").InnerText;

            return SitePath;
        }

        public static string GetSiteMainUrl()
        {
            return new HttpContextAccessor().HttpContext.Request.Scheme + @"://" + new HttpContextAccessor().HttpContext.Request.Host.Value;
        }

        public static List<string> GetSearchedItemList(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);

            XmlNodeList NodeList = doc.SelectNodes("item_view_root/item_search_list/column");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText);

            return list;
        }

        public static string GetSearchedItemListWhereQuery(string Path, string SearchedItem, bool IsAnd = false)
        {
            List<string> ColumnItemList = GetSearchedItemList(Path);

            if (ColumnItemList.Count == 0)
                return "";

            string Where = (IsAnd)? " and (" : "where (";

            foreach (string column in ColumnItemList)
                Where += column + " like '%" + SearchedItem + "%' or ";

            // Remove Last Or
            Where = Where.Remove(Where.Length - 4, 3) + ")";

            return Where;
        }

        public static List<string> GetItemViewList(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNodeList NodeList = doc.SelectNodes("item_view_root/item_view_list/view_table/column");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText);
            
            return list;
        }

        public static List<string> GetItemViewMoreList(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(Path + "App_Data/item_view/item_view.xml"));
            XmlNodeList NodeList = doc.SelectNodes("item_view_root/item_view_list/view_more/column");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText); GlobalClass dc = new GlobalClass();

            return list;
        }
    }
}