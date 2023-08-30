using System.Xml;

namespace Elanat.ListClass
{
    public class Include
    {
        // Get Include Box List Item
        public List<ListItem> IncludeBoxListItem = new List<ListItem>();
        public void FillIncludeBoxListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/box_list/box.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("box_root/box_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    IncludeBoxListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }

        // Get Include Calendar List Item
        public List<ListItem> IncludeCalendarListItem = new List<ListItem>();
        public void FillIncludeCalendarListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("calendar_root/calendar_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    IncludeCalendarListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }

        // Get Include Captcha List Item
        public List<ListItem> IncludeCaptchaListItem = new List<ListItem>();
        public void FillIncludeCaptchaListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/captcha_list/captcha.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("captcha_root/captcha_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    IncludeCaptchaListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }

        // Get Include File Viewer List Item
        public List<ListItem> IncludeFileViewerListItem = new List<ListItem>();
        public void FillIncludeFileViewerListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/file_viewer_list/file_viewer.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("file_viewer_root/file_viewer_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    IncludeFileViewerListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }

        // Get Include Wysiwyg List Item
        public List<ListItem> IncludeWysiwygListItem = new List<ListItem>();
        public void FillIncludeWysiwygListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("wysiwyg_root/wysiwyg_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    IncludeWysiwygListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }
    }
}