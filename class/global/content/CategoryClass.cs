using System.Xml;

namespace Elanat
{
    public class CategoryClass
    {
        public string CategoryName { get; set; }

        public List<string> GetParentCategory(string SiteGlobalName, string CategoryId)
        {
            List<string> ParentCategoryList = new List<string>();

            XmlDocument ParentCategoryDocument = new XmlDocument();

            ParentCategoryDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/category_map/category_map.xml"));

            XmlNodeList NodeList = ParentCategoryDocument.SelectNodes("//category[@id='" + CategoryId + "']");

            if (NodeList.Count > 0)
            {
                CategoryName = NodeList.Item(0).Attributes["name"].Value;

                foreach (XmlNode ParentNode in NodeList.Item(0).ChildNodes)
                    ParentCategoryList.Add(ParentNode.Attributes["name"].Value);
            }

            return ParentCategoryList;
        }

        public XmlNode GetSaveCategoryNode(string SiteGlobalName)
        {
            List<string> ParentCategoryList = new List<string>();

            XmlDocument ParentCategoryDocument = new XmlDocument();

            ParentCategoryDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/category_map/category_map.xml"));

            XmlNode Node = ParentCategoryDocument.SelectSingleNode("category_map_root/category_list");

            return Node;
        }
    }
}