using System.Xml;

namespace Elanat
{
    public class HtmlCheckBoxList
    {
        private string BoxTemplate = "";
        private string ListItemTemplate = "";
        private string SumListItemTemplate = "";
        private string List = "";
        private int ListCount = 0;

        public XmlDocument doc = new XmlDocument();

        public HtmlCheckBoxList(string CheckBoxListXmlPath, string GlobalLanguage)
        {
            doc.Load(CheckBoxListXmlPath);
            BoxTemplate = doc.SelectSingleNode("template_root/check_box_list/box").InnerTextAfterSetNodeVariant(GlobalLanguage);
            ListItemTemplate = doc.SelectSingleNode("template_root/check_box_list/list_item").InnerTextAfterSetNodeVariant(GlobalLanguage);

            if (doc.SelectSingleNode("template_root/check_box_list").Attributes["name"] != null)
            {
                string HtmlCheckBoxName = doc.SelectSingleNode("template_root/check_box_list").Attributes["name"].Value;

                if (!string.IsNullOrEmpty(HtmlCheckBoxName))
                {
                    BoxTemplate = BoxTemplate.Replace("$_asp name_attribute;", HtmlCheckBoxName);
                    ListItemTemplate = ListItemTemplate.Replace("$_asp name_attribute;", HtmlCheckBoxName);
                }
            }
        }

        // Overload
        public HtmlCheckBoxList(string CheckBoxListXmlPath, string GlobalLanguage, string CheckBoxListName)
        {
            doc.Load(CheckBoxListXmlPath);
            BoxTemplate = doc.SelectSingleNode("template_root/check_box_list[@name='" + CheckBoxListName + "']/box").InnerTextAfterSetNodeVariant(GlobalLanguage);
            ListItemTemplate = doc.SelectSingleNode("template_root/check_box_list[@name='" + CheckBoxListName + "']/list_item").InnerTextAfterSetNodeVariant(GlobalLanguage);

            if (doc.SelectSingleNode("template_root/check_box_list[@name='" + CheckBoxListName + "']").Attributes["name"] != null)
            {
                string HtmlCheckBoxName = CheckBoxListName;

                if (!string.IsNullOrEmpty(HtmlCheckBoxName))
                {
                    BoxTemplate = BoxTemplate.Replace("$_asp name_attribute;", HtmlCheckBoxName);
                    ListItemTemplate = ListItemTemplate.Replace("$_asp name_attribute;", HtmlCheckBoxName);
                }
            }
        }

        public void Add(string name, string value)
        {
            string TmpListItemTemplate = ListItemTemplate;

            TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp name;", name);
            TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp value;", value);
            TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp indexer;", ListCount.ToString());

            SumListItemTemplate += TmpListItemTemplate;

            List += (string.IsNullOrEmpty(List))? name + "=" + value : "$" + name + "=" + value;

            ListCount++;
        }

        public void AddRange(List<ListItem> ListItemCollection)
        {
            foreach (ListItem item in ListItemCollection)
                Add(item.Text, item.Value);
        }

        public string GetValue()
        {
            BoxTemplate = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);

            return BoxTemplate;
        }

        public string GetList()
        {
            return List;
        }

        public int GetListCount()
        {
            return ListCount;
        }
    }
}