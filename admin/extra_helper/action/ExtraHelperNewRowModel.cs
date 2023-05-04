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
    public class ActionExtraHelperNewRowModel
    {
        public string ExtraHelperIdValue { get; set; }

        public void SetValue()
        {
            // Set Extra Helper Template
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = TemplateDocument.SelectSingleNode("template_root/table/extra_helper/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = TemplateDocument.SelectSingleNode("template_root/table/extra_helper/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/extra_helper/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = TemplateDocument.SelectSingleNode("template_root/table/extra_helper/item");


            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
            dueh.FillCurrentExtraHelperWithReturnDr(ExtraHelperIdValue);


            foreach (string Text in ItemList)
            {
                string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", dueh.GetReturnDrColumnValue(Text));

                // If Exist More Column For Replace
                if (ItemNode[Text].Attributes["more_column"] != null)
                {
                    char[] DelimiterChars = { ',' };
                    string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                    foreach (string Column in MoreColumnList)
                        TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", dueh.GetReturnDrColumnValue(Column));
                }

                SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
            }

            foreach (XmlNode node in ItemNode.ChildNodes)
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value.TrueFalseToBoolean())
                        TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", dueh.GetReturnDrColumnValue(node.Name));

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp extra_helper_id;", dueh.ReturnDr["extra_helper_id"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp extra_helper_directory_path;", dueh.ReturnDr["extra_helper_directory_path"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp extra_helper_extension_name;", System.IO.Path.GetExtension(dueh.ReturnDr["extra_helper_physical_path"].ToString()).Remove(0, 1));
            TmpRowBoxTemplate = (dueh.ReturnDr["extra_helper_active"].ToString().TrueFalseToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

            SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

            HttpContext.Current.Response.Write(SumRowBoxTemplate);
        }
    }
}