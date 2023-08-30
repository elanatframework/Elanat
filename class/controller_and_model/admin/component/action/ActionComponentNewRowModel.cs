using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionComponentNewRowModel : CodeBehindModel
    {
        public string ComponentIdValue { get; set; }

        public void SetValue()
        {
            // Set Component Template
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = TemplateDocument.SelectSingleNode("template_root/table/component/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = TemplateDocument.SelectSingleNode("template_root/table/component/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/component/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = TemplateDocument.SelectSingleNode("template_root/table/component/item");


            DataUse.Component duc = new DataUse.Component();
            duc.FillCurrentComponentWithReturnDr(ComponentIdValue);


            foreach (string Text in ItemList)
            {
                string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", duc.GetReturnDrColumnValue(Text));

                // If Exist More Column For Replace
                if (ItemNode[Text].Attributes["more_column"] != null)
                {
                    char[] DelimiterChars = { ',' };
                    string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                    foreach (string Column in MoreColumnList)
                        TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", duc.GetReturnDrColumnValue(Column));
                }

                SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
            }

            foreach (XmlNode node in ItemNode.ChildNodes)
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value.TrueFalseToBoolean())
                        TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", duc.GetReturnDrColumnValue(node.Name));

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp component_id;", duc.ReturnDr["component_id"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp component_directory_path;", duc.ReturnDr["component_directory_path"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp component_extension_name;", Path.GetExtension(duc.ReturnDr["component_physical_path"].ToString()).Remove(0, 1));
            TmpRowBoxTemplate = (duc.ReturnDr["component_active"].ToString().TrueFalseToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

            SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

            Write(SumRowBoxTemplate);
        }
    }
}