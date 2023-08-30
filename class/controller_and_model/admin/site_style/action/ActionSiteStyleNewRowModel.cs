﻿using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionSiteStyleNewRowModel : CodeBehindModel
    {
        public string SiteStyleIdValue { get; set; }

        public void SetValue()
        {
            // Set Site Style Template
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/site_style/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/site_style/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/site_style/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = doc.SelectSingleNode("template_root/table/site_style/item");


            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            duss.FillCurrentSiteStyleWithReturnDr(SiteStyleIdValue);


            foreach (string Text in ItemList)
            {
                string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", duss.GetReturnDrColumnValue(Text));

                // If Exist More Column For Replace
                if (ItemNode[Text].Attributes["more_column"] != null)
                {
                    char[] DelimiterChars = { ',' };
                    string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                    foreach (string Column in MoreColumnList)
                        TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", duss.GetReturnDrColumnValue(Column));
                }

                SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
            }

            foreach (XmlNode node in ItemNode.ChildNodes)
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value.TrueFalseToBoolean())
                        TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", duss.GetReturnDrColumnValue(node.Name));

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp site_style_id;", duss.ReturnDr["site_style_id"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp site_style_extension_name;", Path.GetExtension(duss.ReturnDr["site_style_physical_path"].ToString()).Remove(0, 1));
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp site_style_directory_path;", duss.ReturnDr["site_style_directory_path"].ToString());
            TmpRowBoxTemplate = (duss.ReturnDr["site_style_active"].ToString().TrueFalseToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

            SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

            Write(SumRowBoxTemplate);
        }
    }
}