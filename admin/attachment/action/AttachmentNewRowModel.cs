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
    public class ActionAttachmentNewRowModel
    {
        public string AttachmentIdValue { get; set; }

        public void SetValue()
        {
            // Set Attachment Template
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/attachment/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/attachment/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/attachment/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = doc.SelectSingleNode("template_root/table/attachment/item");


            DataUse.Attachment dua = new DataUse.Attachment();
            dua.FillCurrentAttachmentWithReturnDr(AttachmentIdValue);


            foreach (string Text in ItemList)
            {
                string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
                string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_db " + Text + ";", dua.ReturnDr[Text].ToString());

                // If Exist More Column For Replace
                if (ItemNode[Text].Attributes["more_column"] != null)
                {
                    char[] DelimiterChars = { ',' };
                    string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                    foreach (string Column in MoreColumnList)
                        TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_db " + Column + ";", dua.ReturnDr[Column].ToString());
                }

                SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
            }

            foreach (XmlNode node in ItemNode.ChildNodes)
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value.TrueFalseToBoolean())
                        TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_db " + node.Name + ";", dua.ReturnDr[node.Name].ToString());

            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp attachment_id;", dua.ReturnDr["attachment_id"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp attachment_directory_path;", dua.ReturnDr["attachment_directory_path"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp attachment_physical_name;", dua.ReturnDr["attachment_physical_name"].ToString());
            TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp attachment_extension_name;", System.IO.Path.GetExtension(dua.ReturnDr["attachment_physical_name"].ToString()).Remove(0, 1));
            TmpRowBoxTemplate = (dua.ReturnDr["attachment_active"].ToString().TrueFalseToBoolean()) ? TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpRowBoxTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

            SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);

            HttpContext.Current.Response.Write(SumRowBoxTemplate);
        }
    }
}