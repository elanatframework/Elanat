using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperAdminNoteModel : CodeBehindModel
    {
        public string AdminNotesLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
			// Set Language
			AdminNotesLanguage = Language.GetAddOnsLanguage("admin_notes", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/admin_note/");
			
            string SiteId = StaticObject.GetCurrentAdminSiteId();

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/part/admin_note/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/part/admin_note/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();

            string Where = " where el_content.content_status = 'admin_note' ";
            string TmpWhere = "";
            string Query = "";
            string Count = StaticObject.NumberOfRownMainTable.ToString();

            List<string> ParametersNameList = new List<string>() { "@count" };
            List<string> ParametersValueList = new List<string>() { Count };

            Where += " and (el_site.site_id = " + SiteId + " or el_site.site_id = 0)";

            if (!string.IsNullOrEmpty(QueryString.GetValue("page")))
            {
                Count = StaticObject.NumberOfRowPerTable.ToString();
                int PageNumber = int.Parse(QueryString.GetValue("page"));
                string RowPerTable = StaticObject.NumberOfRowPerTable.ToString();
                int FromNumberRow = ((PageNumber - 1) * int.Parse(RowPerTable)) + 1;
                int UntilNumberRow = (FromNumberRow + int.Parse(RowPerTable)) - 1;

                ParametersNameList.Add("@from_number_row");
                ParametersNameList.Add("@until_number_row");
                ParametersValueList.Add(FromNumberRow.ToString());
                ParametersValueList.Add(UntilNumberRow.ToString());
            }

            ParametersNameList.Add("@inner_attach");
            ParametersValueList.Add(Where);

            ParametersNameList.Add("@outer_attach");
            ParametersValueList.Add(TmpWhere);

            dbdr.dr = db.GetProcedure("get_content", ParametersNameList, ParametersValueList);


            // Get Column List
            XmlDocument ColumnListDocument = new XmlDocument();
            ColumnListDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/admin_note/App_Data/column_list/column_list.xml"));

            XmlNodeList ColumnList = ColumnListDocument.SelectSingleNode("column_root/column_list").ChildNodes;


            string SumRowBoxTemplate = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    string TmpRowListItemTemplate = RowListItemTemplate;

                    foreach (XmlNode column in ColumnList)
                        TmpRowListItemTemplate = TmpRowListItemTemplate.Replace("$_db " + column.InnerText + ";", dbdr.dr[column.InnerText].ToString());

                    TmpRowListItemTemplate = TmpRowListItemTemplate.Replace("$_asp attachment;", GetAttachment(dbdr.dr["content_id"].ToString()));
                    TmpRowListItemTemplate = TmpRowListItemTemplate.Replace("$_asp content_avatar_path;", (!string.IsNullOrEmpty(dbdr.dr["content_avatar_physical_name"].ToString())) ? StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_avatar/" + dbdr.dr["content_avatar_physical_name"].ToString()) : "");
                    TmpRowListItemTemplate = TmpRowListItemTemplate.Replace("$_asp content_icon_path;", (!string.IsNullOrEmpty(dbdr.dr["content_icon_physical_name"].ToString())) ? StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/content_icon/" + dbdr.dr["content_icon_physical_name"].ToString()) : "");


                    SumRowBoxTemplate += RowBoxTemplate.Replace("$_asp item;", TmpRowListItemTemplate);
                }

            db.Close();


            // Get Content Count
            DataUse.Content duc = new DataUse.Content();
            string RowCount = duc.GetContentCountByAttach(Where, TmpWhere);

            int CurrentPage = 0;
            if (!string.IsNullOrEmpty(QueryString.GetValue("page")))
                CurrentPage = int.Parse(QueryString.GetValue("page"));

            ContentValue = SumRowBoxTemplate + InnerModuleClass.PageNumbers(int.Parse(RowCount), Query, CurrentPage);
        }

        public string GetAttachment(string ContentId)
        {
            string AttachmentTemplateBox = Template.GetAdminTemplate("part/admin_note_attachment/box");
            string AttachmentTemplateListItem = Template.GetAdminTemplate("part/admin_note_attachment/list_item");
            string TmpAttachmentTemplateListItem = "";
            string SumAttachmentTemplateListItem = "";


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_attachment", "@content_id", ContentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return "";
            }

            while (dbdr.dr.Read())
            {
                TmpAttachmentTemplateListItem = AttachmentTemplateListItem;

                // If Attachment Protection By Password
                if (!string.IsNullOrEmpty(dbdr.dr["attachment_password"].ToString()))
                    TmpAttachmentTemplateListItem = Template.GetSiteGlobalTemplate("part/show_protection_attachment_by_password").Replace("$_asp attachment_id;", dbdr.dr["attachment_id"].ToString()).Replace("$_asp captcha;", Security.GetCaptchaImage());
                else
                {
                    for (int i = 0; i < dbdr.dr.FieldCount; i++)
                    {
                        string ColumnName = dbdr.dr.GetName(i);
                        TmpAttachmentTemplateListItem = TmpAttachmentTemplateListItem.Replace("$_db " + ColumnName + ";", dbdr.dr[ColumnName].ToString());
                    }

                    TmpAttachmentTemplateListItem = TmpAttachmentTemplateListItem.Replace("$_asp attachment_extension_icon;", Path.GetExtension(dbdr.dr["attachment_physical_name"].ToString()).Remove(0, 1));

                }

                SumAttachmentTemplateListItem += TmpAttachmentTemplateListItem;
            }

            db.Close();

            return AttachmentTemplateBox.Replace("$_asp item;", SumAttachmentTemplateListItem);
        }
    }
}