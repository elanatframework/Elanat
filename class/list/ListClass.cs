using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ListClass
    {
        // Get Page Load Type List Item
        public ListItem[] PageLoadTypeListItem = new ListItem[5];
        public void FillPageLoadTypeListItem(string GlobalLanguage)
        {
            PageLoadTypeListItem[0] = new ListItem(Language.GetLanguage("ajax", GlobalLanguage), "ajax");
            PageLoadTypeListItem[1] = new ListItem(Language.GetLanguage("iframe", GlobalLanguage), "iframe");
            PageLoadTypeListItem[2] = new ListItem(Language.GetLanguage("server", GlobalLanguage), "server");
            PageLoadTypeListItem[3] = new ListItem(Language.GetLanguage("on_server", GlobalLanguage), "on_server");
            PageLoadTypeListItem[4] = new ListItem(Language.GetLanguage("text", GlobalLanguage), "text");
        }

        // Get Dynamic Server Page Load Type List Item
        public ListItem[] DynamicServerPageLoadTypeListItem = new ListItem[4];
        public void FillDynamicServerPageLoadTypeListItem(string GlobalLanguage)
        {
            DynamicServerPageLoadTypeListItem[0] = new ListItem(Language.GetLanguage("ajax", GlobalLanguage), "ajax");
            DynamicServerPageLoadTypeListItem[1] = new ListItem(Language.GetLanguage("iframe", GlobalLanguage), "iframe");
            DynamicServerPageLoadTypeListItem[2] = new ListItem(Language.GetLanguage("server", GlobalLanguage), "server");
            DynamicServerPageLoadTypeListItem[3] = new ListItem(Language.GetLanguage("on_server", GlobalLanguage), "on_server");
        }

        // Get Link Target List Item
        public ListItem[] LinkTargetListItem = new ListItem[4];
        public void FillLinkTargetListItem(string GlobalLanguage)
        {
            LinkTargetListItem[0] = new ListItem(Language.GetLanguage("blank", GlobalLanguage), "_blank");
            LinkTargetListItem[1] = new ListItem(Language.GetLanguage("parent", GlobalLanguage), "_parent");
            LinkTargetListItem[2] = new ListItem(Language.GetLanguage("self", GlobalLanguage), "_self");
            LinkTargetListItem[3] = new ListItem(Language.GetLanguage("top", GlobalLanguage), "_top");
        }

        // Get View Match Type List Item
        public ListItem[] ViewMatchTypeListItem = new ListItem[7];
        public void FillViewMatchTypeListItem(string GlobalLanguage)
        {
            ViewMatchTypeListItem[0] = new ListItem(Language.GetLanguage("full_match", GlobalLanguage), "full_match");
            ViewMatchTypeListItem[1] = new ListItem(Language.GetLanguage("none_query", GlobalLanguage), "none_query");
            ViewMatchTypeListItem[2] = new ListItem(Language.GetLanguage("all_query", GlobalLanguage), "all_query");
            ViewMatchTypeListItem[3] = new ListItem(Language.GetLanguage("exist", GlobalLanguage), "exist");
            ViewMatchTypeListItem[4] = new ListItem(Language.GetLanguage("start_by", GlobalLanguage), "start_by");
            ViewMatchTypeListItem[5] = new ListItem(Language.GetLanguage("end_by", GlobalLanguage), "end_by");
            ViewMatchTypeListItem[6] = new ListItem(Language.GetLanguage("regex", GlobalLanguage), "regex");
        }

        // Get Link Protocol List Item
        public ListItem[] LinkProtocolListItem;
        public void FillLinkProtocolListItem()
        {
            List<string> LinkProtocolList = GetLinkProtocolList();

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (string Protocol in LinkProtocolList)
                ListListItem.Add(new ListItem(Protocol, Protocol));

            LinkProtocolListItem = ListListItem.ToArray();
        }

        // Get Group Role List Item
        public ListItem[] GroupRoleListItem;
        public void FillGroupRoleListItem(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_group_role", "@group_id", GroupId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["group_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            GroupRoleListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Link Menu List Item
        public ListItem[] LinkMenuListItem;
        public void FillLinkMenuListItem(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_link_menu", "@link_id", LinkId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["link_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            LinkMenuListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Fetch Menu List Item
        public ListItem[] FetchMenuListItem;
        public void FillFetchMenuListItem(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_fetch_menu", "@fetch_id", FetchId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["fetch_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            FetchMenuListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Menu List Item
        public ListItem[] ModuleMenuListItem;
        public ListItem[] ModuleMenuQueryStringListItem;
        public void FillModuleMenuListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_menu", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();
            List<ListItem> ListQueryStringListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);

                    ListQueryStringListItem.Add(new ListItem(dbdr.dr["menu_module_query_string"].ToString(), dbdr.dr["menu_id"].ToString()));
                }

            ModuleMenuListItem = ListListItem.ToArray();
            ModuleMenuQueryStringListItem = ListQueryStringListItem.ToArray();

            db.Close();
        }

        // Get Plugin Menu List Item
        public ListItem[] PluginMenuListItem;
        public ListItem[] PluginMenuQueryStringListItem;
        public void FillPluginMenuListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_menu", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();
            List<ListItem> ListQueryStringListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);

                    ListQueryStringListItem.Add(new ListItem(dbdr.dr["menu_plugin_query_string"].ToString(), dbdr.dr["menu_id"].ToString()));
                }

            PluginMenuListItem = ListListItem.ToArray();
            PluginMenuQueryStringListItem = ListQueryStringListItem.ToArray();

            db.Close();
        }

        // Get Item Menu List Item
        public ListItem[] ItemMenuListItem;
        public void FillItemMenuListItem(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_item_menu", "@item_id", ItemId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["item_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ItemMenuListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Item Access Show List Item
        public ListItem[] ItemAccessShowListItem;
        public void FillItemAccessShowListItem(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_item_access_show", "@item_id", ItemId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["item_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ItemAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Menu Access Show List Item
        public ListItem[] MenuAccessShowListItem;
        public void FillMenuAccessShowListItem(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_access_show", "@menu_id", MenuId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            MenuAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Fetch Access Show List Item
        public ListItem[] FetchAccessShowListItem;
        public void FillFetchAccessShowListItem(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_fetch_access_show", "@fetch_id", FetchId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["fetch_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            FetchAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get EditorT emplate Access Show List Item
        public ListItem[] EditorTemplateAccessShowListItem;
        public void FillEditorTemplateAccessShowListItem(string EditorTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_editor_template_access_show", "@editor_template_id", EditorTemplateId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["editor_template_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            EditorTemplateAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get ExtraHelper Access Show List Item
        public ListItem[] ExtraHelperAccessShowListItem;
        public void FillExtraHelperAccessShowListItem(string ExtraHelperId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_extra_helper_access_show", "@extra_helper_id", ExtraHelperId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["extra_helper_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ExtraHelperAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Attachment Access Show List Item
        public ListItem[] AttachmentAccessShowListItem;
        public void FillAttachmentAccessShowListItem(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_attachment_access_show", "@attachment_id", AttachmentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["attachment_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            AttachmentAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Access Show List Item
        public ListItem[] SiteAccessShowListItem;
        public void FillSiteAccessShowListItem(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_access_show", "@site_id", SiteId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["site_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            SiteAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Content Access Show List Item
        public ListItem[] ContentAccessShowListItem;
        public void FillContentAccessShowListItem(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_access_show", "@content_id", ContentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ContentAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Page Access Show List Item
        public ListItem[] PageAccessShowListItem;
        public void FillPageAccessShowListItem(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_access_show", "@page_id", PageId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["page_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PageAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Category Access Show List Item
        public ListItem[] CategoryAccessShowListItem;
        public void FillCategoryAccessShowListItem(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_category_access_show", "@category_id", CategoryId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["category_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            CategoryAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }
        
        // Get Component Access Show List Item
        public ListItem[] ComponentAccessShowListItem;
        public void FillComponentAccessShowListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_access_show", "@component_id", ComponentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ComponentAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Component Access Add List Item
        public ListItem[] ComponentAccessAddListItem;
        public void FillComponentAccessAddListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_access_add", "@component_id", ComponentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ComponentAccessAddListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Component Access Delete Own List Item
        public ListItem[] ComponentAccessDeleteOwnListItem;
        public void FillComponentAccessDeleteOwnListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_access_delete_own", "@component_id", ComponentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ComponentAccessDeleteOwnListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Component Access Delete All List Item
        public ListItem[] ComponentAccessDeleteAllListItem;
        public void FillComponentAccessDeleteAllListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_access_delete_all", "@component_id", ComponentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ComponentAccessDeleteAllListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Component Access Edit Own List Item
        public ListItem[] ComponentAccessEditOwnListItem;
        public void FillComponentAccessEditOwnListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_access_edit_own", "@component_id", ComponentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ComponentAccessEditOwnListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Component Access Edit All List Item
        public ListItem[] ComponentAccessEditAllListItem;
        public void FillComponentAccessEditAllListItem(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_access_edit_all", "@component_id", ComponentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["component_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ComponentAccessEditAllListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Access Show List Item
        public ListItem[] ModuleAccessShowListItem;
        public void FillModuleAccessShowListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_access_show", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ModuleAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Access Add List Item
        public ListItem[] ModuleAccessAddListItem;
        public void FillModuleAccessAddListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_access_add", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ModuleAccessAddListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Access Delete Own List Item
        public ListItem[] ModuleAccessDeleteOwnListItem;
        public void FillModuleAccessDeleteOwnListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_access_delete_own", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ModuleAccessDeleteOwnListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Access Delete All List Item
        public ListItem[] ModuleAccessDeleteAllListItem;
        public void FillModuleAccessDeleteAllListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_access_delete_all", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ModuleAccessDeleteAllListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Access Edit Own List Item
        public ListItem[] ModuleAccessEditOwnListItem;
        public void FillModuleAccessEditOwnListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_access_edit_own", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ModuleAccessEditOwnListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Module Access Edit All List Item
        public ListItem[] ModuleAccessEditAllListItem;
        public void FillModuleAccessEditAllListItem(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_access_edit_all", "@module_id", ModuleId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["module_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ModuleAccessEditAllListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Plugin Access Show List Item
        public ListItem[] PluginAccessShowListItem;
        public void FillPluginAccessShowListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_access_show", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PluginAccessShowListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Plugin Access Add List Item
        public ListItem[] PluginAccessAddListItem;
        public void FillPluginAccessAddListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_access_add", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PluginAccessAddListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Plugin Access Delete Own List Item
        public ListItem[] PluginAccessDeleteOwnListItem;
        public void FillPluginAccessDeleteOwnListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_access_delete_own", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PluginAccessDeleteOwnListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Plugin Access Delete All List Item
        public ListItem[] PluginAccessDeleteAllListItem;
        public void FillPluginAccessDeleteAllListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_access_delete_all", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PluginAccessDeleteAllListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Plugin Access Edit Own List Item
        public ListItem[] PluginAccessEditOwnListItem;
        public void FillPluginAccessEditOwnListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_access_edit_own", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PluginAccessEditOwnListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Plugin Access Edit All List Item
        public ListItem[] PluginAccessEditAllListItem;
        public void FillPluginAccessEditAllListItem(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_access_edit_all", "@plugin_id", PluginId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["plugin_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PluginAccessEditAllListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Page Site List Item
        public ListItem[] PageSiteListItem;
        public void FillPageSiteListItem(string PageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_site", "@page_id", PageId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["page_id"].ToString();
                    TmpListItem.Value = dbdr.dr["site_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            PageSiteListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Content Meta Keywords List Item
        public ListItem[] ContentMetaKeywordsListItem;
        public void FillContentMetaKeywordsListItem(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_keywords", "@content_id", ContentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_keywords_text"].ToString();
                    TmpListItem.Value = dbdr.dr["content_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ContentMetaKeywordsListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Content Meta Keywords List Item
        public ListItem[] ContentSourceListItem;
        public void FillContentSourceListItem(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_source", "@content_id", ContentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_source_text"].ToString();
                    TmpListItem.Value = dbdr.dr["content_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ContentSourceListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Attachment  Content List Item
        public ListItem[] AttachmentContentListItem;
        public void FillAttachmentContentListItem(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_attachment_content", "@attachment_id", AttachmentId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["content_id"].ToString();
                    TmpListItem.Value = dbdr.dr["attachment_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            AttachmentContentListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get View Query String List Item
        public ListItem[] ViewQueryStringListItem;
        public void FillViewQueryStringListItem(string ViewId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_view_query_string", "@view_id", ViewId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["view_query_string"].ToString();
                    TmpListItem.Value = dbdr.dr["view_id"].ToString();
                    TmpListItem.Selected = true;

                    ListListItem.Add(TmpListItem);
                }

            ViewQueryStringListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get System List Item
        public ListItem[] SystemListItem;
        public void FillSystemListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_system_list");

            List<ListItem> ListListItem = new List<ListItem>();

            // Get System List Document
            XmlDocument SystemListDocument = new XmlDocument();
            SystemListDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/system_list/system.xml"));
            XmlNodeList System = SystemListDocument.SelectSingleNode("system_root/system_list").ChildNodes;


            foreach (XmlNode node in System)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage).ToUpperFirstChar(), node.Attributes["name"].Value));

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    foreach (XmlNode node in System)
                        if ((dbdr.dr["system_name"].ToString() == node.Attributes["name"].Value) || string.IsNullOrEmpty(dbdr.dr["system_name"].ToString()))
                            goto WhileContinue;

                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["system_name"].ToString(), GlobalLanguage).ToUpperFirstChar(), dbdr.dr["system_name"].ToString()));

                    WhileContinue:
                        continue;
                }

            SystemListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site List Item
        public ListItem[] SiteListItem;
        public void FillSiteListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["site_global_name"].ToString() + "(" + dbdr.dr["site_name"].ToString() + ")", dbdr.dr["site_id"].ToString()));

            SiteListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Name List Item
        public ListItem[] SiteNameListItem;
        public void FillSiteNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["site_name"].ToString(), dbdr.dr["site_global_name"].ToString()));

            SiteNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Global Name List Item
        public ListItem[] SiteGlobalNameListItem;
        public void FillSiteGlobalNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["site_global_name"].ToString(), dbdr.dr["site_id"].ToString()));

            SiteGlobalNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Style List Item
        public ListItem[] SiteStyleListItem;
        public void FillSiteStyleListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_style_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["site_style_name"].ToString(), dbdr.dr["site_style_id"].ToString()));

            SiteStyleListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Style Name List Item
        public ListItem[] SiteStyleNameListItem;
        public void FillSiteStyleNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_style_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["site_style_name"].ToString(), GlobalLanguage), dbdr.dr["site_style_name"].ToString()));

            SiteStyleNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Admin Template List Item
        public ListItem[] SiteTemplateListItem;
        public void FillSiteTemplateListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_template_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["site_template_name"].ToString(), dbdr.dr["site_template_id"].ToString()));

            SiteTemplateListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Template Name List Item
        public ListItem[] SiteTemplateNameListItem;
        public void FillSiteTemplateNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_template_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["site_template_name"].ToString(), GlobalLanguage), dbdr.dr["site_template_name"].ToString()));

            SiteTemplateNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Admin Style List Item
        public ListItem[] AdminStyleListItem;
        public void FillAdminStyleListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_style_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["admin_style_name"].ToString(), dbdr.dr["admin_style_id"].ToString()));

            AdminStyleListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Admin Style Name List Item
        public ListItem[] AdminStyleNameListItem;
        public void FillAdminStyleNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_style_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["admin_style_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()), dbdr.dr["admin_style_name"].ToString()));

            AdminStyleNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Admin Template List Item
        public ListItem[] AdminTemplateListItem;
        public void FillAdminTemplateListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_template_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["admin_template_name"].ToString(), dbdr.dr["admin_template_id"].ToString()));

            AdminTemplateListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Admin Template Name List Item
        public ListItem[] AdminTemplateNameListItem;
        public void FillAdminTemplateNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_template_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["admin_template_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()), dbdr.dr["admin_template_name"].ToString()));

            AdminTemplateNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Page List Item
        public ListItem[] PageListItem;
        public void FillPageListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_id"].ToString()));

            PageListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Page Name List Item
        public ListItem[] PageNameListItem;
        public void FillPageNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_global_name"].ToString()));

            PageNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Page Name List Item
        public ListItem[] SitePageNameListItem;
        public void FillSitePageNameListItem(string SiteId, string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_all_page_list_by_site_id", "@site_id", SiteId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_global_name"].ToString()));

            SitePageNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Site Page Name Show In Site List Item
        public ListItem[] SitePageNameShowInSiteListItem;
        public void FillSitePageNameShowInSiteListItem(string SiteId, string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_all_page_list_by_site_id", "@site_id", SiteId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    if (dbdr.dr["page_show_link_in_site"].ToString().TrueFalseToBoolean())
                        ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["page_global_name"].ToString(), GlobalLanguage), dbdr.dr["page_global_name"].ToString()));
                }

            SitePageNameShowInSiteListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Language List Item
        public ListItem[] LanguageListItem;
        public void FillLanguageListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_language_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_id"].ToString()));

            LanguageListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Language List Item
        public ListItem[] ActiveLanguageListItem;
        public void FillActiveLanguageListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_active_language_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_id"].ToString()));

            ActiveLanguageListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Language Name List Item
        public ListItem[] LanguageNameListItem;
        public void FillLanguageNameListItem(string GlobalLanguage)
        {
            // Get Language Name And Language Global Name

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_language_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_global_name"].ToString()));

            LanguageNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Language Name List Item
        public ListItem[] ActiveLanguageNameListItem;
        public void FillActiveLanguageNameListItem(string GlobalLanguage)
        {
            // Get Language Name And Language Global Name

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_active_language_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_global_name"].ToString()));

            ActiveLanguageNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Menu List Item
        public ListItem[] MenuListItem;
        public void FillMenuListItem(string SiteId)
        {
            // Get Menu Name And Menu Global Name

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_list_by_site_id", "@site_id", SiteId);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["menu_name"].ToString(), dbdr.dr["menu_id"].ToString()));

            MenuListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get User Role List Item
        public ListItem[] UserRoleListItem;
        public void FillUserRoleListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_role_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["role_name"].ToString(), GlobalLanguage), dbdr.dr["role_id"].ToString()));

            UserRoleListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Role List Item
        public ListItem[] ActiveRoleNameListItem;
        public void FillActiveRoleNameListItem()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_role_list", new List<string>(), new List<string>(), false);

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(dbdr.dr["role_name"].ToString(), dbdr.dr["role_id"].ToString()));

            ActiveRoleNameListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get User Group List Item
        public ListItem[] UserGroupListItem;
        public void FillUserGroupListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_group_list");

            List<ListItem> ListListItem = new List<ListItem>();

            string GuestGroupName = StaticObject.GuestGroup;

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["group_name"].ToString(), GlobalLanguage), dbdr.dr["group_id"].ToString()));

            UserGroupListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get User Group List Item Without Guest Group
        public ListItem[] UserGroupListItemWithoutGuestGroup;
        public void FillUserGroupListItemWithoutGuestGroup(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_group_list");

            List<ListItem> ListListItem = new List<ListItem>();

            string GuestGroupName = StaticObject.GuestGroup;

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    if (dbdr.dr["group_name"].ToString() != GuestGroupName)
                        ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["group_name"].ToString(), GlobalLanguage), dbdr.dr["group_id"].ToString()));

            UserGroupListItemWithoutGuestGroup = ListListItem.ToArray();

            db.Close();
        }

        // Get Role Bit Column Access List Item
        public ListItem[] RoleBitColumnAccessListItem;
        public void FillRoleBitColumnAccessListItem()
        {
            XmlNodeList NodeList = StaticObject.RoleBitColumnAccessNodeList;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, StaticObject.GetCurrentAdminGlobalLanguage()), node.Attributes["name"].Value));


            RoleBitColumnAccessListItem = ListListItem.ToArray();
        }

        // Get Role Type List Item
        public ListItem[] RoleTypeListItem = new ListItem[3];
        public void FillRoleTypeListItem(string GlobalLanguage)
        {
            RoleTypeListItem[0] = new ListItem(Language.GetLanguage("admin", GlobalLanguage), "admin");
            RoleTypeListItem[1] = new ListItem(Language.GetLanguage("member", GlobalLanguage), "member");
            RoleTypeListItem[2] = new ListItem(Language.GetLanguage("guest", GlobalLanguage), "guest");
        }

        // Get Role Cache Type List Item
        public ListItem[] RoleCacheTypeListItem = new ListItem[2];
        public void FillRoleCacheTypeListItem(string GlobalLanguage)
        {
            RoleCacheTypeListItem[0] = new ListItem(Language.GetLanguage("memory", GlobalLanguage), "memory");
            RoleCacheTypeListItem[1] = new ListItem(Language.GetLanguage("disk", GlobalLanguage), "disk");
        }

        // Get Component List Item
        public ListItem[] ComponentListItem;
        public void FillComponentListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["component_name"].ToString(), GlobalLanguage), dbdr.dr["component_id"].ToString()));

            ComponentListItem = ListListItem.ToArray();

            db.Close();
        }

        // Get Component Name List Item
        public ListItem[] ComponentNameListItem;
        public void FillComponentNameListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_list");

            List<ListItem> ListListItem = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(dbdr.dr["component_name"].ToString(), GlobalLanguage), dbdr.dr["component_name"].ToString()));

            ComponentNameListItem = ListListItem.ToArray();

            db.Close();
        }
      
        // Get Category List Item
        public ListItem[] CategoryListItemTree;
        public ListItem[] CategoryListItemTreeWithoutSpace;
        public ListItem[] CategoryListItemOnlySpace;
        public void FillCategoryListItemTree(string SiteId, string Space = "")
        {
            List<ListItem> ListListItem = new List<ListItem>();
            List<ListItem> ListListItemWithoutSpace = new List<ListItem>();
            List<ListItem> ListListItemOnlySpace = new List<ListItem>();
            List<string> CategoryId = new List<string>();
            List<string> CategoryName = new List<string>();
            List<string> ParentCategory = new List<string>();
            List<string> TmpList = new List<string>();


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_category_list_by_site_id", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    CategoryName.Add(dbdr.dr["category_name"].ToString());
                    CategoryId.Add(dbdr.dr["category_id"].ToString());
                    ParentCategory.Add(dbdr.dr["parent_category"].ToString());
                }

            db.Close();

            int i, j;
            string TreeString = "";
            while (CategoryId.Count > 0)
            {
                ListListItem.Add(new ListItem(CategoryName[0], CategoryId[0]));
                ListListItemWithoutSpace.Add(new ListItem(CategoryName[0], CategoryId[0]));
                ListListItemOnlySpace.Add(new ListItem("", CategoryId[0]));

                TmpList.Add(CategoryId[0]);

                CategoryName.RemoveAt(0);
                CategoryId.RemoveAt(0);
                ParentCategory.RemoveAt(0);

                while (TmpList.Count > 0)
                {
                    i = 0;
                    j = TmpList.Count - 1;
                    while (i < CategoryId.Count)
                    {
                        if (ParentCategory[i] == TmpList[j])
                        {
                            TreeString = "";
                            foreach (string tmp in TmpList)
                                TreeString += Space;

                            ListListItem.Add(new ListItem(TreeString + CategoryName[i], CategoryId[i]));
                            ListListItemWithoutSpace.Add(new ListItem(CategoryName[i], CategoryId[i]));
                            ListListItemOnlySpace.Add(new ListItem(TreeString, CategoryId[i]));

                            TmpList.Add(CategoryId[i]);
                            j++;

                            CategoryName.RemoveAt(i);
                            CategoryId.RemoveAt(i);
                            ParentCategory.RemoveAt(i);

                            i = -1;
                        }
                        i++;
                    }
                    TmpList.RemoveAt(j);
                }
            }

            CategoryListItemTree = ListListItem.ToArray();
            CategoryListItemTreeWithoutSpace = ListListItemWithoutSpace.ToArray();
            CategoryListItemOnlySpace = ListListItemOnlySpace.ToArray();
        }

        // Get Icon List Item
        public ListItem[] IconListItem;
        public void FillIconListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/icon_list/icon.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("icon_root/icon_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            IconListItem = ListListItem.ToArray();
        }

        // Get Content Type List Item
        public ListItem[] ContentTypeListItem;
        public void FillContentTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/content").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value));

            ContentTypeListItem = ListListItem.ToArray();
        }

        // Get Content Reply Type List Item
        public ListItem[] ContentReplyTypeListItem;
        public void FillContentReplyTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/content_reply").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value));

            ContentReplyTypeListItem = ListListItem.ToArray();
        }

        // Get Comment Type List Item
        public ListItem[] CommentTypeListItem;
        public void FillCommentTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/comment").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value));

            CommentTypeListItem = ListListItem.ToArray();
        }

        // Get Contact Type List Item
        public ListItem[] ContactTypeListItem;
        public void FillContactTypeListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("type_root/type_list/contact").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["value"].Value));

            ContactTypeListItem = ListListItem.ToArray();
        }

        // Get Content Status List Item
        public ListItem[] ContentStatusListItem = new ListItem[6];
        public void FillContentStatusListItem(string GlobalLanguage)
        {
            ContentStatusListItem[0] = new ListItem(Language.GetLanguage("active", GlobalLanguage), "active");
            ContentStatusListItem[1] = new ListItem(Language.GetLanguage("inactive", GlobalLanguage), "inactive");
            ContentStatusListItem[2] = new ListItem(Language.GetLanguage("draft", GlobalLanguage), "draft");
            ContentStatusListItem[3] = new ListItem(Language.GetLanguage("trash", GlobalLanguage), "trash");
            ContentStatusListItem[4] = new ListItem(Language.GetLanguage("delay", GlobalLanguage), "delay");
            ContentStatusListItem[5] = new ListItem(Language.GetLanguage("admin_note", GlobalLanguage), "admin_note");
        }

        // Get Calendar List Item
        public ListItem[] CalendarListItem;
        public void FillCalendarListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("calendar_root/calendar_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            CalendarListItem = ListListItem.ToArray();
        }

        // Get Day Of Weak List Item
        public ListItem[] DayOfWeakListItem = new ListItem[7];
        public void FillDayOfWeakListItem(string GlobalLanguage)
        {
            DayOfWeakListItem[0] = new ListItem(Language.GetLanguage("sunday", GlobalLanguage), "1");
            DayOfWeakListItem[1] = new ListItem(Language.GetLanguage("monday", GlobalLanguage), "2");
            DayOfWeakListItem[2] = new ListItem(Language.GetLanguage("tuesday", GlobalLanguage), "3");
            DayOfWeakListItem[3] = new ListItem(Language.GetLanguage("wednesday", GlobalLanguage), "4");
            DayOfWeakListItem[4] = new ListItem(Language.GetLanguage("thursday", GlobalLanguage), "5");
            DayOfWeakListItem[5] = new ListItem(Language.GetLanguage("friday", GlobalLanguage), "6");
            DayOfWeakListItem[6] = new ListItem(Language.GetLanguage("saturday", GlobalLanguage), "7");
        }
        
        // Get Persian Day Of Weak List Item
        public ListItem[] PersianDayOfWeakListItem = new ListItem[7];
        public void FillPersianDayOfWeakListItem(string GlobalLanguage)
        {
            PersianDayOfWeakListItem[0] = new ListItem(Language.GetLanguage("saturday", GlobalLanguage), "1");
            PersianDayOfWeakListItem[1] = new ListItem(Language.GetLanguage("sunday", GlobalLanguage), "2");
            PersianDayOfWeakListItem[2] = new ListItem(Language.GetLanguage("monday", GlobalLanguage), "3");
            PersianDayOfWeakListItem[3] = new ListItem(Language.GetLanguage("tuesday", GlobalLanguage), "4");
            PersianDayOfWeakListItem[4] = new ListItem(Language.GetLanguage("wednesday", GlobalLanguage), "5");
            PersianDayOfWeakListItem[5] = new ListItem(Language.GetLanguage("thursday", GlobalLanguage), "6");
            PersianDayOfWeakListItem[6] = new ListItem(Language.GetLanguage("friday", GlobalLanguage), "7");
        }

        // Get Mount List Item
        public ListItem[] MountListItem = new ListItem[12];
        public void FillMountListItem(string GlobalLanguage)
        {
            MountListItem[0] = new ListItem(Language.GetLanguage("january", GlobalLanguage), "1");
            MountListItem[1] = new ListItem(Language.GetLanguage("february", GlobalLanguage), "2");
            MountListItem[2] = new ListItem(Language.GetLanguage("march", GlobalLanguage), "3");
            MountListItem[3] = new ListItem(Language.GetLanguage("april", GlobalLanguage), "4");
            MountListItem[4] = new ListItem(Language.GetLanguage("may", GlobalLanguage), "5");
            MountListItem[5] = new ListItem(Language.GetLanguage("june", GlobalLanguage), "6");
            MountListItem[6] = new ListItem(Language.GetLanguage("july", GlobalLanguage), "7");
            MountListItem[7] = new ListItem(Language.GetLanguage("august", GlobalLanguage), "8");
            MountListItem[8] = new ListItem(Language.GetLanguage("september", GlobalLanguage), "9");
            MountListItem[9] = new ListItem(Language.GetLanguage("october", GlobalLanguage), "10");
            MountListItem[10] = new ListItem(Language.GetLanguage("november", GlobalLanguage), "11");
            MountListItem[11] = new ListItem(Language.GetLanguage("december", GlobalLanguage), "12");
        }
        
        // Get Persian Mount List Item
        public ListItem[] PersianMountListItem = new ListItem[12];
        public void FillPersianMountListItem(string GlobalLanguage)
        {
            PersianMountListItem[0] = new ListItem(Language.GetLanguage("farvardin", GlobalLanguage), "1");
            PersianMountListItem[1] = new ListItem(Language.GetLanguage("ordibehesht", GlobalLanguage), "2");
            PersianMountListItem[2] = new ListItem(Language.GetLanguage("khordad", GlobalLanguage), "3");
            PersianMountListItem[3] = new ListItem(Language.GetLanguage("tir", GlobalLanguage), "4");
            PersianMountListItem[4] = new ListItem(Language.GetLanguage("mordad", GlobalLanguage), "5");
            PersianMountListItem[5] = new ListItem(Language.GetLanguage("shahrivar", GlobalLanguage), "6");
            PersianMountListItem[6] = new ListItem(Language.GetLanguage("mehr", GlobalLanguage), "7");
            PersianMountListItem[7] = new ListItem(Language.GetLanguage("aban", GlobalLanguage), "8");
            PersianMountListItem[8] = new ListItem(Language.GetLanguage("azar", GlobalLanguage), "9");
            PersianMountListItem[9] = new ListItem(Language.GetLanguage("dey", GlobalLanguage), "10");
            PersianMountListItem[10] = new ListItem(Language.GetLanguage("bahman", GlobalLanguage), "11");
            PersianMountListItem[11] = new ListItem(Language.GetLanguage("esfand", GlobalLanguage), "12");
        }

        // Get Persian Mount List Item
        public ListItem[] PersianMountListItemByCalendarLanguage = new ListItem[12];
        public void FillPersianMountListItemByCalendarLanguage(string GlobalLanguage)
        {
            AddOnsLanguage aol = new AddOnsLanguage(GlobalLanguage, StaticObject.SitePath + "include/calendar/persian/");

            PersianMountListItemByCalendarLanguage[0] = new ListItem(aol.GetAddOnsLanguage("farvardin"), "1");
            PersianMountListItemByCalendarLanguage[1] = new ListItem(aol.GetAddOnsLanguage("ordibehesht"), "2");
            PersianMountListItemByCalendarLanguage[2] = new ListItem(aol.GetAddOnsLanguage("khordad"), "3");
            PersianMountListItemByCalendarLanguage[3] = new ListItem(aol.GetAddOnsLanguage("tir"), "4");
            PersianMountListItemByCalendarLanguage[4] = new ListItem(aol.GetAddOnsLanguage("mordad"), "5");
            PersianMountListItemByCalendarLanguage[5] = new ListItem(aol.GetAddOnsLanguage("shahrivar"), "6");
            PersianMountListItemByCalendarLanguage[6] = new ListItem(aol.GetAddOnsLanguage("mehr"), "7");
            PersianMountListItemByCalendarLanguage[7] = new ListItem(aol.GetAddOnsLanguage("aban"), "8");
            PersianMountListItemByCalendarLanguage[8] = new ListItem(aol.GetAddOnsLanguage("azar"), "9");
            PersianMountListItemByCalendarLanguage[9] = new ListItem(aol.GetAddOnsLanguage("dey"), "10");
            PersianMountListItemByCalendarLanguage[10] = new ListItem(aol.GetAddOnsLanguage("bahman"), "11");
            PersianMountListItemByCalendarLanguage[11] = new ListItem(aol.GetAddOnsLanguage("esfand"), "12");
        }

        // Get Persian Mount List Item
        public ListItem[] HijriMountListItemByCalendarLanguage = new ListItem[12];
        public void FillHijriMountListItemByCalendarLanguage(string GlobalLanguage)
        {
            AddOnsLanguage aol = new AddOnsLanguage(GlobalLanguage, StaticObject.SitePath + "include/calendar/hijri/");

            HijriMountListItemByCalendarLanguage[0] = new ListItem(aol.GetAddOnsLanguage("muharram"), "1");
            HijriMountListItemByCalendarLanguage[1] = new ListItem(aol.GetAddOnsLanguage("safar"), "2");
            HijriMountListItemByCalendarLanguage[2] = new ListItem(aol.GetAddOnsLanguage("rabi_al_awwal"), "3");
            HijriMountListItemByCalendarLanguage[3] = new ListItem(aol.GetAddOnsLanguage("rabi_ath_thani"), "4");
            HijriMountListItemByCalendarLanguage[4] = new ListItem(aol.GetAddOnsLanguage("jumada_al_awwal"), "5");
            HijriMountListItemByCalendarLanguage[5] = new ListItem(aol.GetAddOnsLanguage("jumada_ath_thaniyah"), "6");
            HijriMountListItemByCalendarLanguage[6] = new ListItem(aol.GetAddOnsLanguage("rajab"), "7");
            HijriMountListItemByCalendarLanguage[7] = new ListItem(aol.GetAddOnsLanguage("shaban"), "8");
            HijriMountListItemByCalendarLanguage[8] = new ListItem(aol.GetAddOnsLanguage("ramadan"), "9");
            HijriMountListItemByCalendarLanguage[9] = new ListItem(aol.GetAddOnsLanguage("shawwal"), "10");
            HijriMountListItemByCalendarLanguage[10] = new ListItem(aol.GetAddOnsLanguage("zu_al_qadah"), "11");
            HijriMountListItemByCalendarLanguage[11] = new ListItem(aol.GetAddOnsLanguage("zu_al_hijjah"), "12");
        }

        // Get Time Zone List Item
        public ListItem[] TimeZoneListItem = new ListItem[32];
        public void FillTimeZoneListItem(string GlobalLanguage)
        {
            TimeZoneListItem[0] = new ListItem("GMT +13", "13");
            TimeZoneListItem[1] = new ListItem("GMT +12", "12");
            TimeZoneListItem[2] = new ListItem("GMT +11", "11");
            TimeZoneListItem[3] = new ListItem("GMT +10", "10");
            TimeZoneListItem[4] = new ListItem("GMT +9.5", "9.5");
            TimeZoneListItem[5] = new ListItem("GMT +9", "9");
            TimeZoneListItem[6] = new ListItem("GMT +8", "8");
            TimeZoneListItem[7] = new ListItem("GMT +7", "7");
            TimeZoneListItem[8] = new ListItem("GMT +6.5", "6.5");
            TimeZoneListItem[9] = new ListItem("GMT +6", "6");
            TimeZoneListItem[10] = new ListItem("GMT +5.5", "5.5");
            TimeZoneListItem[11] = new ListItem("GMT +5", "5");
            TimeZoneListItem[12] = new ListItem("GMT +4.5", "4.5");
            TimeZoneListItem[13] = new ListItem("GMT +4", "4");
            TimeZoneListItem[14] = new ListItem("GMT +3.5", "3.5");
            TimeZoneListItem[15] = new ListItem("GMT +3", "3");
            TimeZoneListItem[16] = new ListItem("GMT +2", "2");
            TimeZoneListItem[17] = new ListItem("GMT +1", "1");
            TimeZoneListItem[18] = new ListItem("GMT", "0");
            TimeZoneListItem[19] = new ListItem("GMT -1", "-1");
            TimeZoneListItem[20] = new ListItem("GMT -2", "-2");
            TimeZoneListItem[21] = new ListItem("GMT -3", "-3");
            TimeZoneListItem[22] = new ListItem("GMT -3.5", "-3.5");
            TimeZoneListItem[23] = new ListItem("GMT -4", "-4");
            TimeZoneListItem[24] = new ListItem("GMT -5", "-5");
            TimeZoneListItem[25] = new ListItem("GMT -6", "-6");
            TimeZoneListItem[26] = new ListItem("GMT -7", "-7");
            TimeZoneListItem[27] = new ListItem("GMT -8", "-8");
            TimeZoneListItem[28] = new ListItem("GMT -9", "-9");
            TimeZoneListItem[29] = new ListItem("GMT -10", "-10");
            TimeZoneListItem[30] = new ListItem("GMT -11", "-11");
            TimeZoneListItem[31] = new ListItem("GMT -12", "-12");
        }

        // Get Birthday List Item
        public ListItem[] BirthdayDayListItem = new ListItem[31];
        public ListItem[] BirthdayMountListItem = new ListItem[12];
        public ListItem[] BirthdayYearListItem;
        public void FillBirthdayListItem(string GlobalLanguage)
        {
            for (int i = 0; i < 31; i++)
                BirthdayDayListItem[i] = new ListItem((i + 1).ToString("00"), (i + 1).ToString("00"));

            for (int i = 0; i < 12; i++)
                BirthdayMountListItem[i] = new ListItem((i + 1).ToString("00"), (i + 1).ToString("00"));

            List<ListItem> ListListItem = new List<ListItem>();
            int CurrentYear = DateTime.Now.Year;

            for (int i = 1900; i <= CurrentYear; i++)
                ListListItem.Add(new ListItem(i.ToString(), i.ToString()));

            BirthdayYearListItem = ListListItem.ToArray();
        }

        // Get Site Birthday List Item
        public ListItem[] SiteBirthdayDayListItem = new ListItem[31];
        public ListItem[] SiteBirthdayMountListItem = new ListItem[12];
        public ListItem[] SiteBirthdayYearListItem;
        public void FillSiteBirthdayListItem(string GlobalLanguage)
        {
            for (int i = 0; i < 31; i++)
                SiteBirthdayDayListItem[i] = new ListItem((i + 1).ToString("00"), (i + 1).ToString("00"));

            for (int i = 0; i < 12; i++)
                SiteBirthdayMountListItem[i] = new ListItem((i + 1).ToString("00"), (i + 1).ToString("00"));

            List<ListItem> ListListItem = new List<ListItem>();
            int CurrentYear = DateTime.Now.Year;
            string SiteBirthday = ElanatConfig.GetNode("date_and_time/site_birthday").InnerText;

            string SiteBirthdayDay = SiteBirthday.Substring(8, 2);
            string SiteBirthdayMount = SiteBirthday.Substring(5, 2);
            string SiteBirthdayYear = SiteBirthday.Substring(0, 4);

            for (int i = int.Parse(SiteBirthdayYear); i <= CurrentYear; i++)
                ListListItem.Add(new ListItem(i.ToString(), i.ToString()));

            SiteBirthdayYearListItem = ListListItem.ToArray();
        }

        // Get Menu Location List Item
        public ListItem[] MenuLocationListItem;
        public void FillMenuLocationListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/page_location_list/page_location.xml"));

            XmlNodeList PageLocation = doc.SelectSingleNode("page_location_root/page_location_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in PageLocation)
            {
                string Value = node.Attributes["value"].Value;
                string Name = Language.GetHandheldLanguage(Value, StaticObject.GetCurrentAdminGlobalLanguage());

                ListListItem.Add(new ListItem(Name, Value));
            }

            MenuLocationListItem = ListListItem.ToArray();
        }

        // Get Read More Status List Item
        public ListItem[] ReadMoreStatusListItem = new ListItem[3];
        public void FillReadMoreStatusListItem(string GlobalLanguage)
        {
            ReadMoreStatusListItem[0] = new ListItem(Language.GetLanguage("ajax", GlobalLanguage), "ajax");
            ReadMoreStatusListItem[1] = new ListItem(Language.GetLanguage("save", GlobalLanguage), "save");
            ReadMoreStatusListItem[2] = new ListItem(Language.GetLanguage("new_page", GlobalLanguage), "new_page");
        }

        // Get Content Page Number Location List Item
        public ListItem[] ContentPageNumberLocationListItem = new ListItem[3];
        public void FillContentPageNumberLocationListItem(string GlobalLanguage)
        {
            ContentPageNumberLocationListItem[0] = new ListItem(Language.GetLanguage("before", GlobalLanguage), "before");
            ContentPageNumberLocationListItem[1] = new ListItem(Language.GetLanguage("after", GlobalLanguage), "after");
            ContentPageNumberLocationListItem[2] = new ListItem(Language.GetLanguage("both", GlobalLanguage), "both");
        }

        // Get Before After Location List Item
        public ListItem[] BeforeAfterLocationListItem = new ListItem[2];
        public void FillBeforeAfterLocationListItem(string GlobalLanguage)
        {
            BeforeAfterLocationListItem[0] = new ListItem(Language.GetLanguage("before", GlobalLanguage), "before");
            BeforeAfterLocationListItem[1] = new ListItem(Language.GetLanguage("after", GlobalLanguage), "after");
        }

        public void SetOrderListValue(List<string> ValueList, List<int> OrderList, out List<string> OutValueList, out List<int> OutOrderList)
        {
            List<string> TmpValueList = ValueList;
            List<int> TmpOrderList = OrderList;
            List<string> TmpValueListSort = TmpValueList;
            List<int> TmpOrderListSort = TmpOrderList;
            TmpOrderListSort.Sort();

            for (int i = 0; i < TmpOrderListSort.Count; i++)
            {
                foreach(int Order in TmpOrderList)
                {
                    int iOrder = 0;
                    if (Order == TmpOrderListSort[i])
                    {
                        TmpValueListSort.Add(TmpValueList[iOrder]);
                        TmpValueList.RemoveAt(iOrder);
                    }
                        iOrder++;
                }
            }

            OutValueList = TmpValueList;
            OutOrderList = TmpOrderList;
        }

        public static List<string> GetLinkProtocolList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/link_protocol/link_protocol.xml"));
            XmlNodeList NodeList = doc.SelectNodes("link_protocol_root/link_protocol_list/protocol");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText);

            return list;
        }

        public static List<string> GetStyleList()
        {
            List<string> list = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(@StaticObject.SitePath + "client/style/site/"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.css", SearchOption.TopDirectoryOnly);
            list.Add(null);
            foreach (FileInfo fi in fileInfo)
            {
                list.Add(fi.Name.ToString());
            }
            return list;
        }

        public static List<string> GetTemplateList()
        {
            List<string> list = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(@StaticObject.SitePath + "template/site/"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
            list.Add(null);
            foreach (FileInfo fi in fileInfo)
            {
                list.Add(fi.Name.ToString());
            }
            return list;
        }

        public static List<string> GetUserRoleWithValue()
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_role_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    list.Add(dbdr.dr["role_name"].ToString());
                    list.Add(dbdr.dr["role_id"].ToString());
                }

            db.Close();
            return list;
        }

        public static List<string> GetLanguageNameList()
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    list.Add(dbdr.dr["language_name"].ToString() + "(" + dbdr.dr["language_global_name"].ToString() + ")");

            db.Close();

            return list;
        }

        public static List<string> GetParentCategory(string CategoryId)
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_parent_category", "@category_id", CategoryId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    list.Add(dbdr.dr["parent_category"].ToString());
                    list.Add(dbdr.dr["category_name"].ToString());
                }

            db.Close();

            return list;
        }

        public static List<string> GetAuthorizedExtensionList()
        {
            XmlNodeList NodeList = StaticObject.AuthorizedExtensionDocument.SelectNodes("authorized_extension_root/authorized_extension_list/authorized_extension");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
            {
                list.Add(node.InnerText);
            }
            return list;
        }

        public static List<string> GetUnauthorizedExtensionList()
        {
            XmlNodeList NodeList = StaticObject.AuthorizedExtensionDocument.SelectNodes("authorized_extension_root/authorized_extension_list/unauthorized_extension");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
            {
                list.Add(node.InnerText);
            }
            return list;
        }

        public static List<List<string>> GetPagePartListWithValue(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/page_location_list/page_location.xml"));
            XmlNodeList NodeList = doc.SelectNodes("page_location_root/page_location_list/page_location");

            List<List<string>> DoubleList = new List<List<string>>();
            List<string> ValueList = new List<string>();
            List<string> NameList = new List<string>();

            foreach (XmlNode node in NodeList)
            {
                ValueList.Add(node.Attributes["value"].InnerText);
                NameList.Add(Language.GetLanguage(node.Attributes["value"].InnerText, GlobalLanguage));
            }
            DoubleList.Add(ValueList);
            DoubleList.Add(NameList);

            return DoubleList;
        }

        public static List<List<string>> GetContentReplyTypeListWithValue(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectNodes("type_root/type_list/content_reply/type");

            List<List<string>> DoubleList = new List<List<string>>();
            List<string> ValueList = new List<string>();
            List<string> NameList = new List<string>();

            foreach (XmlNode node in NodeList)
            {
                ValueList.Add(node.Attributes["value"].InnerText);
                NameList.Add(Language.GetHandheldLanguage(node.Attributes["name"].InnerText, GlobalLanguage));
            }
            DoubleList.Add(ValueList);
            DoubleList.Add(NameList);

            return DoubleList;
        }

        public static List<List<string>> GetContactTypeListWithValue(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/type_list/type.xml"));
            XmlNodeList NodeList = doc.SelectNodes("type_root/type_list/contact/type");

            List<List<string>> DoubleList = new List<List<string>>();
            List<string> ValueList = new List<string>();
            List<string> NameList = new List<string>();

            foreach (XmlNode node in NodeList)
            {
                ValueList.Add(node.Attributes["value"].InnerText);
                NameList.Add(Language.GetHandheldLanguage(node.Attributes["name"].InnerText, GlobalLanguage));
            }
            DoubleList.Add(ValueList);
            DoubleList.Add(NameList);

            return DoubleList;
        }

        // Get Include Box List Item
        public ListItem[] IncludeBoxListItem;
        public void FillIncludeBoxListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/box_list/box.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("box_root/box_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            IncludeBoxListItem = ListListItem.ToArray();
        }

        // Get Include Calendar List Item
        public ListItem[] IncludeCalendarListItem;
        public void FillIncludeCalendarListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("calendar_root/calendar_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            IncludeCalendarListItem = ListListItem.ToArray();
        }

        // Get Include Captcha List Item
        public ListItem[] IncludeCaptchaListItem;
        public void FillIncludeCaptchaListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/captcha_list/captcha.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("captcha_root/captcha_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            IncludeCaptchaListItem = ListListItem.ToArray();
        }

        // Get Include File Viewer List Item
        public ListItem[] IncludeFileViewerListItem;
        public void FillIncludeFileViewerListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/file_viewer_list/file_viewer.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("file_viewer_root/file_viewer_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            IncludeFileViewerListItem = ListListItem.ToArray();
        }

        // Get Include Wysiwyg List Item
        public ListItem[] IncludeWysiwygListItem;
        public void FillIncludeWysiwygListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("wysiwyg_root/wysiwyg_list").ChildNodes;

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (XmlNode node in NodeList)
                if (node.Attributes["active"].Value == "true")
                    ListListItem.Add(new ListItem(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value));

            IncludeWysiwygListItem = ListListItem.ToArray();
        }

        public static List<string> GetLanguageGlobalNameList()
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    list.Add(dbdr.dr["language_global_name"].ToString());

            db.Close();

            return list;
        }
    }
}
