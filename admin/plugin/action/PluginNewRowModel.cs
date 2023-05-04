using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionPluginNewRowModel
    {
        public string PluginIdValue { get; set; }

        public void SetValue()
        {
            // Set Plugin Template
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = TemplateDocument.SelectSingleNode("template_root/table/plugin/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = TemplateDocument.SelectSingleNode("template_root/table/plugin/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/plugin/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = TemplateDocument.SelectSingleNode("template_root/table/plugin/item");


            DataUse.Plugin dup = new DataUse.Plugin();
            dup.FillCurrentPluginWithReturnDr(PluginIdValue);


            foreach (string Text in ItemList)
            {
                string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", dup.GetReturnDrColumnValue(Text));

                // If Exist More Column For Replace
                if (ItemNode[Text].Attributes["more_column"] != null)
                {
                    char[] DelimiterChars = { ',' };
                    string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                    foreach (string Column in MoreColumnList)
                        TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", dup.GetReturnDrColumnValue(Column));
                }

                SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
            }

            foreach (XmlNode node in ItemNode.ChildNodes)
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value.TrueFalseToBoolean())
                        TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", dup.GetReturnDrColumnValue(node.Name));

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp plugin_id;", dup.ReturnDr["plugin_id"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp plugin_directory_path;", dup.ReturnDr["plugin_directory_path"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp plugin_extension_name;", System.IO.Path.GetExtension(dup.ReturnDr["plugin_physical_name"].ToString()).Remove(0, 1));
            TmpRowBoxTemplate = (dup.ReturnDr["plugin_active"].ToString().TrueFalseToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

            SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

            HttpContext.Current.Response.Write(SumRowBoxTemplate);
        }
    }
}