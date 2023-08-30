using System.Xml;

namespace Elanat
{
    public class CategoryMap
    {
        public void CreateCategoryMap(string SiteGlobalName, string SiteId)
        {
            XmlTextWriter writer = new XmlTextWriter(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + SiteGlobalName + "/category_map/category_map.xml"), System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;

            // Set Current Value
            ListClass.Category lcc = new ListClass.Category();
            lcc.FillCategoryListItemTree(SiteId, "$");


            List<ListItem> CategoryList = lcc.CategoryListItemTree;

            int i_CategoryListCount = CategoryList.Count;
            int i_CategoryList = 0;
            writer.WriteStartElement("category_map_root");
            writer.WriteStartElement("category_list");
            while (i_CategoryList < i_CategoryListCount)
            {
                writer.WriteStartElement("category");
                writer.WriteAttributeString("name", CategoryList[i_CategoryList].Text.Replace("$", null));
                writer.WriteAttributeString("id", CategoryList[i_CategoryList].Value);
                int SpaceCount = StringClass.GetNumberOfCharInString(CategoryList[i_CategoryList].Text, "$");

                string CategorySpace = "";
                int i_SpaceCount = SpaceCount;
                while (i_SpaceCount > 0)
                {
                    CategorySpace += "-";
                    i_SpaceCount--;
                }
                writer.WriteAttributeString("space", CategorySpace);

                int i_new_i_CategoryList = i_CategoryList;
                string CategoryPath = CategoryList[i_new_i_CategoryList].Text.Replace("$", null);
                while (SpaceCount > 0 && i_new_i_CategoryList >= 0)
                {
                    if (SpaceCount > StringClass.GetNumberOfCharInString(CategoryList[i_new_i_CategoryList].Text, "$"))
                    {
                        SpaceCount = StringClass.GetNumberOfCharInString(CategoryList[i_new_i_CategoryList].Text, "$");

                        writer.WriteStartElement("parent_category");

                        writer.WriteAttributeString("name", CategoryList[i_new_i_CategoryList].Text.Replace("$", null));
                        writer.WriteAttributeString("id", CategoryList[i_new_i_CategoryList].Value);

                        writer.WriteEndElement();
                    }
                    i_new_i_CategoryList--;
                }

                writer.WriteEndElement();
                i_CategoryList++;
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
        }
    }
}