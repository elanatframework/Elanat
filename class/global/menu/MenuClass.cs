using System.Xml;

namespace Elanat
{
    public class MenuClass
    {
        public string GetAdminMenu(string MenuLocation)
        {
            string MenuBoxTemplate = Template.GetAdminTemplate("html/location/" + MenuLocation + "/box", true);
            string MenuListItemTemplate = Template.GetAdminTemplate("html/location/" + MenuLocation + "/list_item");
            string TmpMenuListItemTemplate = "";
            string SumMenuListItemTemplate = "";

            string LocationMenu = "";

            foreach (XmlNode node in StaticObject.CurrentAdminTemplateDocument().SelectNodes("template_root/html/location/" + MenuLocation + "/static_item")[0].ChildNodes)
            {
                string MenuName = "";
                string TmpMenuBoxTemplate = MenuBoxTemplate;

                if (node.Attributes["menu_name"] != null)
                    MenuName = node.Attributes["menu_name"].Value;

                TmpMenuBoxTemplate = TmpMenuBoxTemplate.Replace("$_asp menu_name;", MenuName);

                TmpMenuListItemTemplate = MenuListItemTemplate;

                TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", node.InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage()));

                if (node.Attributes["use_box"] != null)
                    SumMenuListItemTemplate += TmpMenuBoxTemplate.Replace("$_asp item;", TmpMenuListItemTemplate);
                else
                    SumMenuListItemTemplate += TmpMenuListItemTemplate;
            }

            LocationMenu = SumMenuListItemTemplate;

            LocationMenu = Language.GetLanguageFromContent(LocationMenu, StaticObject.GetCurrentAdminGlobalLanguage());

            return LocationMenu;
        }

        public string GetSiteStaticMenu(string MenuLocation)
        {
            string MenuBoxTemplate = Template.GetSiteTemplate("html/location/" + MenuLocation + "/box", true);
            string MenuListItemTemplate = Template.GetSiteTemplate("html/location/" + MenuLocation + "/list_item", true);
            string TmpMenuListItemTemplate = "";

            string LocationMenu = "";

            foreach (XmlNode node in StaticObject.CurrentSiteTemplateDocument().SelectNodes("template_root/html/location/" + MenuLocation + "/static_item")[0].ChildNodes)
            {
                string MenuName = "";
                string TmpMenuBoxTemplate = MenuBoxTemplate;

                if (node.Attributes["menu_name"] != null)
                    MenuName = node.Attributes["menu_name"].Value;

                TmpMenuBoxTemplate = TmpMenuBoxTemplate.Replace("$_asp menu_name;", MenuName);

                TmpMenuListItemTemplate = MenuListItemTemplate;

                TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", node.InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()));

                string menu = "";

                if (node.Attributes["use_box"] != null)
                    menu = TmpMenuBoxTemplate.Replace("$_asp item;", TmpMenuListItemTemplate);
                else
                    menu = TmpMenuListItemTemplate;

                LocationMenu += menu;

                SetMenuLocationValueList(menu);

                if (node.Attributes["sort_index"] != null)
                {
                    int Order = 0;
                    int.TryParse(node.Attributes["sort_index"].ToString(), out Order);
                    SetMenuLocationOrderList(Order);
                }
                else
                    SetMenuLocationOrderList(0);
            }
            LocationMenu = Language.GetLanguageFromContent(LocationMenu, StaticObject.GetCurrentSiteGlobalLanguage());

            return LocationMenu;
        }

        public string GetSiteGlobalStaticLocationMenu(string MenuLocation)
        {
            string MenuBoxTemplate = Template.GetSiteTemplate("html/location/" + MenuLocation + "/box", true);
            string MenuListItemTemplate = Template.GetSiteTemplate("html/location/" + MenuLocation + "/list_item", true);
            string TmpMenuListItemTemplate = "";

            string LocationMenu = "";

            foreach (XmlNode node in StaticObject.SiteGlobalLocationTemplateDocument.SelectNodes("template_root/location_base/" + MenuLocation + "/static_item")[0].ChildNodes)
            {
                string MenuName = "";
                string TmpMenuBoxTemplate = MenuBoxTemplate;

                if (node.Attributes["menu_name"] != null)
                    MenuName = node.Attributes["menu_name"].Value;

                TmpMenuBoxTemplate = TmpMenuBoxTemplate.Replace("$_asp menu_name;", MenuName);

                TmpMenuListItemTemplate = MenuListItemTemplate;

                TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", node.InnerTextAfterSetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()));

                string menu = "";

                if (node.Attributes["use_box"] != null)
                    menu = TmpMenuBoxTemplate.Replace("$_asp item;", TmpMenuListItemTemplate);
                else
                    menu = TmpMenuListItemTemplate;

                LocationMenu += menu;

                SetMenuLocationValueList(menu);

                if (node.Attributes["sort_index"] != null)
                {
                    int Order = 0;
                    int.TryParse(node.Attributes["sort_index"].ToString(), out Order);
                    SetMenuLocationOrderList(Order);
                }
                else
                    SetMenuLocationOrderList(0);
            }
            LocationMenu = Language.GetLanguageFromContent(LocationMenu, StaticObject.GetCurrentSiteGlobalLanguage());

            return LocationMenu;
        }

        private List<string> TmpMenuLocationValueList = new List<string>();
        public List<string> MenuLocationValueList
        {
            get { return TmpMenuLocationValueList; }
        }
        private void SetMenuLocationValueList(string Value)
        {
            TmpMenuLocationValueList.Add(Value);
        }
        private void EmptyMenuLocationValueList()
        {
            TmpMenuLocationValueList = new List<string>();
        }

        private List<int> TmpMenuLocationOrderList = new List<int>();
        public List<int> MenuLocationOrderList
        {
            get { return TmpMenuLocationOrderList; }
        }
        private void SetMenuLocationOrderList(int Order)
        {
            TmpMenuLocationOrderList.Add(Order);
        }
        private void EmptyMenuLocationOrderList()
        {
            TmpMenuLocationOrderList = new List<int>();
        }

        public string GetDataBaseMenu(string MenuLocation, string GroupId, string GlobalLanguage, string CurrentQueryString = null)
        {
            string MenuBoxTemplate = Template.GetSiteTemplate("html/location/" + MenuLocation + "/box");
            string MenuListItemTemplate = Template.GetSiteTemplate("html/location/" + MenuLocation + "/list_item");
            string TmpMenuBoxTemplate = "";
            string TmpMenuListItemTemplate = "";
            string SumMenuListItemTemplate = "";

            string LocationMenu = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_list_by_location", new List<string>() { "@location", "@group_id" }, new List<string>() { MenuLocation, GroupId });

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    string MenuId = dbdr.dr["menu_id"].ToString();
                    SumMenuListItemTemplate = "";

                    TmpMenuBoxTemplate = MenuBoxTemplate;
                    TmpMenuBoxTemplate = TmpMenuBoxTemplate.Replace("$_asp menu_name;", dbdr.dr["menu_name"].ToString());
                    TmpMenuListItemTemplate = MenuListItemTemplate;

                    // Get Menu Plugin
                    string Plugin = GetPlugin(MenuId, GroupId, GlobalLanguage, CurrentQueryString);
                    if (!string.IsNullOrEmpty(Plugin))
                    {
                        TmpMenuListItemTemplate = MenuListItemTemplate;
                        TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", Plugin);
                        SumMenuListItemTemplate += TmpMenuListItemTemplate;
                    }

                    // Get Menu Module
                    string Module = GetModule(MenuId, GroupId, GlobalLanguage, CurrentQueryString);
                    if (!string.IsNullOrEmpty(Module))
                    {
                        TmpMenuListItemTemplate = MenuListItemTemplate;
                        TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", Module);
                        SumMenuListItemTemplate += TmpMenuListItemTemplate;
                    }

                    // Get Menu Fetch
                    string Fetch = GetFetch(MenuId, GroupId, GlobalLanguage);
                    if (!string.IsNullOrEmpty(Fetch))
                    {
                        TmpMenuListItemTemplate = MenuListItemTemplate;
                        TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", Fetch);
                        SumMenuListItemTemplate += TmpMenuListItemTemplate;
                    }

                    // Get Menu Item
                    string Item = GetItem(MenuId, GroupId, GlobalLanguage);
                    if (!string.IsNullOrEmpty(Item))
                    {
                        TmpMenuListItemTemplate = MenuListItemTemplate;
                        TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", Item);
                        SumMenuListItemTemplate += TmpMenuListItemTemplate;
                    }

                    // Get Menu link
                    string Link = GetLink(MenuId);
                    if (!string.IsNullOrEmpty(Link))
                    {
                        TmpMenuListItemTemplate = MenuListItemTemplate;
                        TmpMenuListItemTemplate = TmpMenuListItemTemplate.Replace("$_asp value;", Link);
                        SumMenuListItemTemplate += TmpMenuListItemTemplate;
                    }

                    if (!string.IsNullOrEmpty(SumMenuListItemTemplate))
                    {
                        TmpMenuBoxTemplate = ((bool)dbdr.dr["menu_use_box"] == true) ? TmpMenuBoxTemplate.Replace("$_asp item;", SumMenuListItemTemplate) : SumMenuListItemTemplate;

                        LocationMenu += TmpMenuBoxTemplate;

                        SetMenuLocationValueList(TmpMenuBoxTemplate);

                        int Order = int.Parse(dbdr.dr["menu_sort_index"].ToString());
                        SetMenuLocationOrderList(Order);
                    }

                }

            db.Close();

            return LocationMenu;
        }

        public string GetSiteMenu(string MenuLocation, string GroupId, string GlobalLanguage, string CurrentQueryString = null)
        {
            EmptyMenuLocationValueList();
            EmptyMenuLocationOrderList();

            // Get Global Static Menu
            GetSiteGlobalStaticLocationMenu(MenuLocation);

            // Get Static Menu
            GetSiteStaticMenu(MenuLocation);

            // Get DataBase Menu
            GetDataBaseMenu(MenuLocation, GroupId, GlobalLanguage);

            ListClass.Common lcc = new ListClass.Common();

            List<string> TmpMenuLocationValueList = new List<string>();
            List<int> TmpMenuLocationOrderList = new List<int>();

            lcc.SetOrderListValue(MenuLocationValueList, MenuLocationOrderList, out TmpMenuLocationValueList, out TmpMenuLocationOrderList);

            string LocationMenu = "";
            foreach (string MenuValue in TmpMenuLocationValueList)
                LocationMenu += MenuValue;

            return LocationMenu;
        }

        public string GetPlugin(string MenuId, string GroupId, string GlobalLanguage, string CurrentQueryString = null)
        {
            if (!string.IsNullOrEmpty(CurrentQueryString))
                CurrentQueryString = "?" + CurrentQueryString;

            string PluginBoxTemplate = Template.GetGlobalTemplate("part/plugin/box", GlobalLanguage);
            string PluginListItemTemplate = Template.GetGlobalTemplate("part/plugin/list_item", GlobalLanguage);
            string TmpPluginListItemTemplate = "";
            string SumPluginListItemTemplate = "";

            AttributeReader ar = new AttributeReader();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_plugin_by_group_id", new List<string>() { "@menu_id", "@group_id" }, new List<string>() { MenuId, GroupId });

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpPluginListItemTemplate = PluginListItemTemplate;

                    string MenuPluginQueryString = dbdr.dr["menu_plugin_query_string"].ToString();
                    if (!string.IsNullOrEmpty(MenuPluginQueryString))
                        if (!string.IsNullOrEmpty(CurrentQueryString))
                            CurrentQueryString += "&" + MenuPluginQueryString;
                        else
                            CurrentQueryString = "?" + MenuPluginQueryString;

                    string PluginValue = ar.GetPlugin(dbdr.dr["plugin_id"].ToString() + "{" + CurrentQueryString + "}", GlobalLanguage);

                    TmpPluginListItemTemplate = TmpPluginListItemTemplate.Replace("$_asp value;", PluginValue);

                    SumPluginListItemTemplate += TmpPluginListItemTemplate;

                    // Set Plugin Value Transfer
                    DataUse.Plugin dup = new DataUse.Plugin();
                    dup.SetPluginValueTransfer(dbdr.dr["plugin_directory_path"].ToString());
                }

            db.Close();

            if (!string.IsNullOrEmpty(SumPluginListItemTemplate))
                return PluginBoxTemplate.Replace("$_asp item;",SumPluginListItemTemplate);

            return null;
        }

        public string GetModule(string MenuId, string GroupId, string GlobalLanguage, string CurrentQueryString = null)
        {
            if (!string.IsNullOrEmpty(CurrentQueryString))
                CurrentQueryString = "?" + CurrentQueryString;

            string ModuleBoxTemplate = Template.GetGlobalTemplate("part/module/box", GlobalLanguage);
            string ModuleListItemTemplate = Template.GetGlobalTemplate("part/module/list_item", GlobalLanguage);
            string TmpModuleListItemTemplate = "";
            string SumModuleListItemTemplate = "";

            AttributeReader ar = new AttributeReader();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_module_by_group_id", new List<string>() { "@menu_id", "@group_id" }, new List<string>() { MenuId, GroupId });

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpModuleListItemTemplate = ModuleListItemTemplate;

                    string MenuModuleQueryString = dbdr.dr["menu_module_query_string"].ToString();
                    if (!string.IsNullOrEmpty(MenuModuleQueryString))
                        if (!string.IsNullOrEmpty(CurrentQueryString))
                            CurrentQueryString += "&" + MenuModuleQueryString;
                        else
                            CurrentQueryString = "?" + MenuModuleQueryString;

                    string ModuleValue = ar.GetModule(dbdr.dr["module_id"].ToString() + "{" + CurrentQueryString + "}", GlobalLanguage);

                    TmpModuleListItemTemplate = TmpModuleListItemTemplate.Replace("$_asp value;", ModuleValue);

                    SumModuleListItemTemplate += TmpModuleListItemTemplate;

                    // Set Module Value Transfer
                    DataUse.Module dum = new DataUse.Module();
                    dum.SetModuleValueTransfer(dbdr.dr["module_directory_path"].ToString());
                }

            db.Close();

            if (!string.IsNullOrEmpty(SumModuleListItemTemplate))
                return ModuleBoxTemplate.Replace("$_asp item;", SumModuleListItemTemplate);

            return null;
        }

        public string GetFetch(string MenuId, string GroupID, string GlobalLanguage)
        {
            string FetchBoxTemplate = Template.GetGlobalTemplate("part/fetch/box", GlobalLanguage);
            string FetchListItemTemplate = Template.GetGlobalTemplate("part/fetch/list_item", GlobalLanguage);
            string TmpFetchListItemTemplate = "";
            string SumFetchListItemTemplate = "";

            AttributeReader ar = new AttributeReader();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_fetch_by_group_id", new List<string>() { "@menu_id", "@group_id" }, new List<string>() { MenuId, GroupID });

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpFetchListItemTemplate = FetchListItemTemplate;

                    string FetchValue = ar.GetFetch(dbdr.dr["fetch_name"].ToString(), GlobalLanguage);

                    TmpFetchListItemTemplate = TmpFetchListItemTemplate.Replace("$_asp value;", FetchValue);

                    SumFetchListItemTemplate += TmpFetchListItemTemplate;
                }

            db.Close();

            if (!string.IsNullOrEmpty(SumFetchListItemTemplate))
                return FetchBoxTemplate.Replace("$_asp item;", SumFetchListItemTemplate);

            return null;
        }

        public string GetItem(string MenuId, string GroupId, string GlobalLanguage)
        {
            string ItemBoxTemplate = Template.GetGlobalTemplate("part/item/box", GlobalLanguage);
            string ItemListItemTemplate = Template.GetGlobalTemplate("part/item/list_item", GlobalLanguage);
            string TmpItemListItemTemplate = "";
            string SumItemListItemTemplate = "";

            AttributeReader ar = new AttributeReader();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_item_by_group_id", new List<string>() { "@menu_id", "@group_id" }, new List<string>() { MenuId, GroupId });

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpItemListItemTemplate = ItemListItemTemplate;

                    TmpItemListItemTemplate = TmpItemListItemTemplate.Replace("$_asp value;", ar.GetItem(dbdr.dr["item_id"].ToString(), GlobalLanguage));

                    SumItemListItemTemplate += TmpItemListItemTemplate;
                }

            db.Close();

            if (!string.IsNullOrEmpty(SumItemListItemTemplate))
                return ItemBoxTemplate.Replace("$_asp item;", SumItemListItemTemplate);

            return null;
        }

        public string GetLink(string MenuId)
        {
            string LinkBoxTemplate = Template.GetGlobalTemplate("part/link/box", StaticObject.GetCurrentSiteGlobalLanguage());
            string LinkListItemTemplate = Template.GetGlobalTemplate("part/link/list_item", StaticObject.GetCurrentSiteGlobalLanguage());
            string TmpLinkListItemTemplate = "";
            string SumLinkListItemTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_link", "@menu_id", MenuId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpLinkListItemTemplate = LinkListItemTemplate;

                    TmpLinkListItemTemplate = TmpLinkListItemTemplate.Replace("$_db link_value;", dbdr.dr["link_value"].ToString());
                    TmpLinkListItemTemplate = TmpLinkListItemTemplate.Replace("$_db link_href;", dbdr.dr["link_href"].ToString());
                    TmpLinkListItemTemplate = TmpLinkListItemTemplate.Replace("$_db link_title;", dbdr.dr["link_title"].ToString());
                    TmpLinkListItemTemplate = TmpLinkListItemTemplate.Replace("$_db link_rel;", dbdr.dr["link_rel"].ToString());
                    TmpLinkListItemTemplate = TmpLinkListItemTemplate.Replace("$_db link_target;", dbdr.dr["link_target"].ToString());
                    TmpLinkListItemTemplate = TmpLinkListItemTemplate.Replace("$_db link_protocol;", dbdr.dr["link_protocol"].ToString());

                    SumLinkListItemTemplate += TmpLinkListItemTemplate;
                }

            db.Close();

            if (!string.IsNullOrEmpty(SumLinkListItemTemplate))
                return LinkBoxTemplate.Replace("$_asp item;", SumLinkListItemTemplate);

            return null;
        }
    }
}