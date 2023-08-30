using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleLastDataModel : CodeBehindModel
    {
        public string LastDataLanguage { get; set; }
        public string AreYouSureWantToActiveLanguage { get; set; }
        public string AreYouSureWantToRestoreLanguage { get; set; }
        public string AreYouSureWantToInctiveLanguage { get; set; }
        public string AreYouSureWantToDeleteLanguage { get; set; }

        public string LastContacValue { get; set; } = "";
        public string LastCommentValue { get; set; } = "";
        public string LastAttachmentValue { get; set; } = "";
        public string LastActiveUsersValue { get; set; } = "";
        public string LastContentValue { get; set; } = "";
        public string LastFootPrintValue { get; set; } = "";
        public string LastUserSignUpValue { get; set; } = "";

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/last_data/");
            LastDataLanguage = aol.GetAddOnsLanguage("last_data");
			AreYouSureWantToActiveLanguage = aol.GetAddOnsLanguage("are_you_sure_want_to_active");
			AreYouSureWantToRestoreLanguage = aol.GetAddOnsLanguage("are_you_sure_want_to_restore");
			AreYouSureWantToInctiveLanguage = aol.GetAddOnsLanguage("are_you_sure_want_to_inactive");
			AreYouSureWantToDeleteLanguage = aol.GetAddOnsLanguage("are_you_sure_want_to_delete");
			
			
            // Set Current Value
            XmlDocument LastDataOptionDocument = new XmlDocument();
            LastDataOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/last_data/option/last_data_option.xml"));

            XmlNode node = LastDataOptionDocument.SelectSingleNode("last_data_option_root");

            DataBaseDataReader dbdr = new DataBaseDataReader();

            // Set Comment Value
            if (node["last_comment"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["last_comment"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_comment/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_comment/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang last_comment;", aol.GetAddOnsLanguage("last_comment"));

                DataBaseSocket db1 = new DataBaseSocket();
                dbdr.dr = db1.GetProcedure("get_comment", new List<string>() { "@outer_attach", "@count" }, new List<string>() { "order by comment_date_send desc, comment_time_send desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db comment_id;", dbdr.dr["comment_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db comment_title;", dbdr.dr["comment_title"].ToString());
                        TmpListItemTemplate = (bool)dbdr.dr["comment_active"] ? TmpListItemTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpListItemTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                        if (string.IsNullOrEmpty(dbdr.dr["comment_title"].ToString()))
                        {
                            string ContentText = (dbdr.dr["comment_text"].ToString().Length > 100) ? dbdr.dr["comment_text"].ToString().Substring(0, 100) : dbdr.dr["comment_text"].ToString();

                            TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp comment_text_to_title;", ContentText);
                        }
                        else
                            TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp comment_text_to_title;", "");

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                LastCommentValue = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);

                db1.Close();
            }

            // Set Content Value
            if (node["last_content"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["last_content"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_trash_content/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_trash_content/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang last_content;", aol.GetAddOnsLanguage("content"));

                DataBaseSocket db2 = new DataBaseSocket();
                dbdr.dr = db2.GetProcedure("get_content", new List<string>() { "@inner_attach", "@outer_attach", "@count", }, new List<string>() { "where el_content.content_status='trash'", "order by content_date_create desc, content_time_create desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db content_title;", dbdr.dr["content_title"].ToString());

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db2.Close();

                string TrashContent = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);


                BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_draft_content/box");
                ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_draft_content/list_item");
                TmpListItemTemplate = "";
                SumListItemTemplate = "";

                DataBaseSocket db3 = new DataBaseSocket();
                dbdr.dr = db3.GetProcedure("get_content", new List<string>() { "@inner_attach", "@outer_attach", "@count", }, new List<string>() { "where el_content.content_status='draft'", "order by content_date_create desc, content_time_create desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db content_title;", dbdr.dr["content_title"].ToString());
                        TmpListItemTemplate = (dbdr.dr["content_status"].ToString() == "active") ? TmpListItemTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpListItemTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db3.Close();

                string DraftContent = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);


                BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_inactive_content/box");
                ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_inactive_content/list_item");
                TmpListItemTemplate = "";
                SumListItemTemplate = "";

                DataBaseSocket db4 = new DataBaseSocket();
                dbdr.dr = db4.GetProcedure("get_content", new List<string>() { "@inner_attach", "@outer_attach", "@count" }, new List<string>() { "where el_content.content_status='inactive'", "order by content_date_create desc, content_time_create desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db content_title;", dbdr.dr["content_title"].ToString());
                        TmpListItemTemplate = (dbdr.dr["content_status"].ToString() == "active") ? TmpListItemTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpListItemTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db4.Close();

                string InactiveContent = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);


                string ContentBoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_content/box");

                ContentBoxTemplate = ContentBoxTemplate.Replace("$_asp_lang last_content;", aol.GetAddOnsLanguage("last_content"));

                ContentBoxTemplate = ContentBoxTemplate.Replace("$_asp content_trash_list;", TrashContent);
                ContentBoxTemplate = ContentBoxTemplate.Replace("$_asp content_draft_list;", DraftContent);
                ContentBoxTemplate = ContentBoxTemplate.Replace("$_asp content_inactive_list;", InactiveContent);

                LastContentValue = ContentBoxTemplate;
            }

            // Set Contact Value
            if (node["last_contact"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["last_contact"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_contact/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_contact/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang last_contact;", aol.GetAddOnsLanguage("last_contact"));

                DataBaseSocket db5 = new DataBaseSocket();
                dbdr.dr = db5.GetProcedure("get_contact", new List<string>() { "@outer_attach", "@count" }, new List<string>() { "order by contact_date_send desc, contact_time_send desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db contact_id;", dbdr.dr["contact_id"].ToString());
                        if (string.IsNullOrEmpty(dbdr.dr["contact_title"].ToString()))
                        {
                            if (dbdr.dr["contact_text"].ToString().Length > 60)
                                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db contact_title;", "[" + dbdr.dr["contact_text"].ToString().Substring(0, 60) + "...]");
                            else
                                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db contact_title;", "[" + dbdr.dr["contact_text"].ToString() + "]");
                        }
                        else
                            TmpListItemTemplate = TmpListItemTemplate.Replace("$_db contact_title;", dbdr.dr["contact_title"].ToString());

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db5.Close();

                LastCommentValue = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);
            }

            // Set Attachment Value
            if (node["last_attachment"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["last_attachment"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_attachment/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_attachment/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang last_attachment;", aol.GetAddOnsLanguage("last_attachment"));

                DataBaseSocket db6 = new DataBaseSocket();
                dbdr.dr = db6.GetProcedure("get_attachment", new List<string>() { "@outer_attach", "@count" }, new List<string>() { "order by attachment_id desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        if (FileAndDirectory.IsImageExtension(Path.GetExtension(dbdr.dr["attachment_physical_name"].ToString())))
                            TmpListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_attachment/list_item_image");

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db attachment_id;", dbdr.dr["attachment_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp attachment_extension;", Path.GetExtension(dbdr.dr["attachment_physical_name"].ToString()).Remove(0, 1));
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db attachment_directory_path;", dbdr.dr["attachment_directory_path"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db attachment_physical_name;", dbdr.dr["attachment_physical_name"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db attachment_name;", dbdr.dr["attachment_name"].ToString());
                        TmpListItemTemplate = (bool)dbdr.dr["attachment_active"] ? TmpListItemTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpListItemTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db6.Close();

                LastAttachmentValue = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);
            }

            // Set Foot Print Value
            if (node["last_foot_print"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["last_foot_print"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_foot_print/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_foot_print/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang user_foot_print;", aol.GetAddOnsLanguage("user_foot_print"));

                DataBaseSocket db7 = new DataBaseSocket();
                dbdr.dr = db7.GetProcedure("get_foot_print", new List<string>() { "@outer_attach", "@count" }, new List<string>() { "order by foot_print_date_action desc, foot_print_time_action desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db foot_print_user_event_value;", dbdr.dr["foot_print_user_event_value"].ToString());

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db7.Close();

                LastFootPrintValue = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);
            }

            // Set User Sign Up Value
            if (node["last_user_sign_up"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["last_user_sign_up"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_user_sign_up/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/last_user_sign_up/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang last_user_sign_up;", aol.GetAddOnsLanguage("last_user_sign_up"));

                DataBaseSocket db8 = new DataBaseSocket();
                dbdr.dr = db8.GetProcedure("get_user", new List<string>() { "@outer_attach", "@count" }, new List<string>() { "order by user_id desc, user_date_create desc", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db user_id;", dbdr.dr["user_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db user_name;", dbdr.dr["user_name"].ToString());
                        TmpListItemTemplate = (bool)dbdr.dr["user_active"] ? TmpListItemTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpListItemTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db8.Close();

                LastUserSignUpValue = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);
            }

            // Set Active User Value
            if (node["active_users_in_last_24_hours"].Attributes["active"].InnerText == "true")
            {
                string ItemCount = node["active_users_in_last_24_hours"].Attributes["item_count"].InnerText;

                string BoxTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/active_users_in_last_24_hours/box");
                string ListItemTemplate = Template.GetAdminTemplate("part/dashboard_item/last_data/active_users_in_last_24_hours/list_item");
                string TmpListItemTemplate = "";
                string SumListItemTemplate = "";

                // Set Language
                BoxTemplate = BoxTemplate.Replace("$_asp_lang active_users_in_last_24_hours;", aol.GetAddOnsLanguage("active_users_in_last_24_hours"));

                DataBaseSocket db9 = new DataBaseSocket();
                dbdr.dr = db9.GetProcedure("get_user", new List<string>() { "@inner_attach", "@count" }, new List<string>() { "where el_user.user_last_login >= '" + DateAndTime.GetDate("yyyy/MM/dd", -1) + "-" + DateAndTime.GetTime("HH:mm:ss") + "'", ItemCount });

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        TmpListItemTemplate = ListItemTemplate;

                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db user_id;", dbdr.dr["user_id"].ToString());
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db user_name;", dbdr.dr["user_name"].ToString());
                        TmpListItemTemplate = (bool)dbdr.dr["user_active"] ? TmpListItemTemplate.Replace("$_asp check_active_inactive;", "active").Replace("$_asp check_Active_Inactive;", "Inactive") : TmpListItemTemplate.Replace("$_asp check_active_inactive;", "inactive").Replace("$_asp check_Active_Inactive;", "Active");

                        SumListItemTemplate += TmpListItemTemplate;
                    }

                db9.Close();

                LastActiveUsersValue = BoxTemplate.Replace("$_asp item;", SumListItemTemplate);
            }
        }
    }
}