﻿using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionContentReplyNewRowModel : CodeBehindModel
    {
        public string ContentReplyIdValue { get; set; }

        public void SetValue()
        {
            // Set ContentReply Template
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/content_reply/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/content_reply/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/content_reply/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = doc.SelectSingleNode("template_root/table/content_reply/item");


            DataUse.ContentReply ducr = new DataUse.ContentReply();
            ducr.FillCurrentContentReplyWithReturnDr(ContentReplyIdValue);


            foreach (string Text in ItemList)
            {
                string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", ducr.GetReturnDrColumnValue(Text));

                // If Exist More Column For Replace
                if (ItemNode[Text].Attributes["more_column"] != null)
                {
                    char[] DelimiterChars = { ',' };
                    string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                    foreach (string Column in MoreColumnList)
                        TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", ducr.GetReturnDrColumnValue(Column));
                }

                SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
            }

            foreach (XmlNode node in ItemNode.ChildNodes)
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value.TrueFalseToBoolean())
                        TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", ducr.GetReturnDrColumnValue(node.Name));

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp content_reply_id;", ducr.ReturnDr["content_reply_id"].ToString());
            TmpRowBoxTemplate = (ducr.ReturnDr["content_reply_active"].ToString().TrueFalseToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

            SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

            Write(SumRowBoxTemplate);
        }
    }
}