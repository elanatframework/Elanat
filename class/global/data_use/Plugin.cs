using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class Plugin : IDisposable
    {
        public string PluginId = "";
        public string PluginName = "";
        public string PluginActive = "";
        public string PluginDirectoryPath = "";
        public string PluginPhysicalName = "";
        public string PluginLoadType = "";
        public string PluginUseLanguage = "";
        public string PluginUseModule = "";
        public string PluginUsePlugin = "";
        public string PluginUseReplacePart = "";
        public string PluginUseFetch = "";
        public string PluginUseItem = "";
        public string PluginUseElanat = "";
        public string PluginCacheDuration = "";
        public string PluginCacheParameters = "";
        public string PluginPublicAccessAdd = "";
        public string PluginPublicAccessEditOwn = "";
        public string PluginPublicAccessDeleteOwn = "";
        public string PluginPublicAccessEditAll = "";
        public string PluginPublicAccessDeleteAll = "";
        public string PluginPublicAccessShow = "";
        public string PluginSortIndex = "";
        public string PluginCategory = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_plugin", "@plugin_id", PluginId);
        }

        public void Inactive(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_plugin", "@plugin_id", PluginId);
        }

        public void Delete(string PluginId)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            dup.FillCurrentPlugin(PluginId);


            // Run Uninstall Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + dup.PluginDirectoryPath + "/catalog.xml"));
            XmlNode PluginCatalog = CatalogDocument.SelectSingleNode("/plugin_catalog_root");

            if (!string.IsNullOrEmpty(PluginCatalog["plugin_uninstall_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/plugin/" + dup.PluginDirectoryPath + "/" + PluginCatalog["plugin_uninstall_path"].Attributes["value"].Value, false);


            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_plugin", "@plugin_id", PluginId);


            // Delete All Root File List
            string Path = "add_on/plugin/" + dup.PluginDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);

            
            DeletePhysicalDirectory(dup.PluginDirectoryPath);
        }

        public void DeletePhysicalDirectory(string PluginDirectoryPath)
        {
            List<string> ParentDirectoryList = PluginDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void DeleteMenuPlugin(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu_plugin", "@plugin_id", PluginId);
        }

        public void DeletePluginRoleAccess(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_plugin_role_access", "@plugin_id", PluginId);
        }
        
        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_plugin", new List<string>() { "@plugin_name", "@plugin_directory_path", "@plugin_physical_name", "@plugin_load_type", "@plugin_use_language", "@plugin_use_module", "@plugin_use_plugin", "@plugin_use_replace_part", "@plugin_use_fetch", "@plugin_use_item", "@plugin_use_elanat", "@plugin_cache_duration", "@plugin_cache_parameters", "@plugin_public_access_add", "@plugin_public_access_edit_own", "@plugin_public_access_delete_own", "@plugin_public_access_edit_all", "@plugin_public_access_delete_all", "@plugin_public_access_show", "@plugin_sort_index", "@plugin_category", "@plugin_active" }, new List<string>() { PluginName, PluginDirectoryPath, PluginPhysicalName, PluginLoadType, PluginUseLanguage, PluginUseModule, PluginUsePlugin, PluginUseReplacePart, PluginUseFetch, PluginUseItem, PluginUseElanat, PluginCacheDuration, PluginCacheParameters, PluginPublicAccessAdd, PluginPublicAccessEditOwn, PluginPublicAccessDeleteOwn, PluginPublicAccessEditAll, PluginPublicAccessDeleteAll, PluginPublicAccessShow, PluginSortIndex, PluginCategory, PluginActive });

            dbdr.dr.Read();

            PluginId = dbdr.dr["plugin_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_plugin", new List<string>() { "@plugin_name", "@plugin_directory_path", "@plugin_physical_name", "@plugin_load_type", "@plugin_use_language", "@plugin_use_module", "@plugin_use_plugin", "@plugin_use_replace_part", "@plugin_use_fetch", "@plugin_use_item", "@plugin_use_elanat", "@plugin_cache_duration", "@plugin_cache_parameters", "@plugin_public_access_add", "@plugin_public_access_edit_own", "@plugin_public_access_delete_own", "@plugin_public_access_edit_all", "@plugin_public_access_delete_all", "@plugin_public_access_show", "@plugin_sort_index", "@plugin_category", "@plugin_active" }, new List<string>() { PluginName, PluginDirectoryPath, PluginPhysicalName, PluginLoadType, PluginUseLanguage, PluginUseModule, PluginUsePlugin, PluginUseReplacePart, PluginUseFetch, PluginUseItem, PluginUseElanat, PluginCacheDuration, PluginCacheParameters, PluginPublicAccessAdd, PluginPublicAccessEditOwn, PluginPublicAccessDeleteOwn, PluginPublicAccessEditAll, PluginPublicAccessDeleteAll, PluginPublicAccessShow, PluginSortIndex, PluginCategory, PluginActive });

            ReturnDr.Read();

            PluginId = ReturnDr["plugin_id"].ToString();
        }

        public void AddMenuPlugin(string PluginId, List<ListItem> MenuPluginListItem, List<string> PluginQueryString)
        {
            DataBaseSocket db = new DataBaseSocket();

            int i = 0;

            foreach (ListItem item in MenuPluginListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_plugin", new List<string>() { "@menu_id", "@plugin_id", "@menu_plugin_query_string" }, new List<string>() { item.Value, PluginId, PluginQueryString[i++] });
        }

        // Overload
        public void AddMenuPlugin(List<ListItem> MenuPluginListItem, List<string> PluginQueryString)
        {
            DataBaseSocket db = new DataBaseSocket();

            int i = 0;

            foreach (ListItem item in MenuPluginListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_plugin", new List<string>() { "@menu_id", "@plugin_id", "@menu_plugin_query_string" }, new List<string>() { item.Value, PluginId, PluginQueryString[i++] });
        }

        public void SetPluginRoleAccess(string PluginId, List<ListItem> PluginAccessShow, List<ListItem> PluginAccessAdd, List<ListItem> PluginAccessEditOwn, List<ListItem> PluginAccessDeleteOwn, List<ListItem> PluginAccessEditAll, List<ListItem> PluginAccessDeleteAll)
        {
            DataBaseSocket db = new DataBaseSocket();

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcu.UserRoleListItem)
            {
                string RoleId = item.Value;

                string TmpPluginAccessShow = "0";
                if (PluginAccessShow.FindByValue(item.Value) != null)
                    TmpPluginAccessShow = PluginAccessShow.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessAdd = "0";
                if (PluginAccessAdd.FindByValue(item.Value) != null)
                    TmpPluginAccessAdd = PluginAccessAdd.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessEditOwn = "0";
                if (PluginAccessEditOwn.FindByValue(item.Value) != null)
                    TmpPluginAccessEditOwn = PluginAccessEditOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessDeleteOwn = "0";
                if (PluginAccessDeleteOwn.FindByValue(item.Value) != null)
                    TmpPluginAccessDeleteOwn = PluginAccessDeleteOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessEditAll = "0";
                if (PluginAccessEditAll.FindByValue(item.Value) != null)
                    TmpPluginAccessEditAll = PluginAccessEditAll.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessDeleteAll = "0";
                if (PluginAccessDeleteAll.FindByValue(item.Value) != null)
                    TmpPluginAccessDeleteAll = PluginAccessDeleteAll.FindByValue(item.Value).Selected.BooleanToZeroOne();

                if ((TmpPluginAccessShow.ZeroOneToBoolean() || TmpPluginAccessAdd.ZeroOneToBoolean() || TmpPluginAccessEditOwn.ZeroOneToBoolean() || TmpPluginAccessDeleteOwn.ZeroOneToBoolean() || TmpPluginAccessEditAll.ZeroOneToBoolean() || TmpPluginAccessDeleteAll.ZeroOneToBoolean()))
                    db.SetProcedure("set_plugin_role_access", new List<string>() { "@plugin_id", "@role_id", "@access_show", "@access_add", "@access_edit_own", "@access_delete_own", "@access_edit_all", "@access_delete_all" }, new List<string>() { PluginId, RoleId, TmpPluginAccessShow, TmpPluginAccessAdd, TmpPluginAccessEditOwn, TmpPluginAccessDeleteOwn, TmpPluginAccessEditAll, TmpPluginAccessDeleteAll });
            }
        }

        // Overload
        public void SetPluginRoleAccess(List<ListItem> PluginAccessShow, List<ListItem> PluginAccessAdd, List<ListItem> PluginAccessEditOwn, List<ListItem> PluginAccessDeleteOwn, List<ListItem> PluginAccessEditAll, List<ListItem> PluginAccessDeleteAll)
        {
            DataBaseSocket db = new DataBaseSocket();

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcu.UserRoleListItem)
            {
                string RoleId = item.Value;

                string TmpPluginAccessShow = "0";
                if (PluginAccessShow.FindByValue(item.Value) != null)
                    TmpPluginAccessShow = PluginAccessShow.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessAdd = "0";
                if (PluginAccessAdd.FindByValue(item.Value) != null)
                    TmpPluginAccessAdd = PluginAccessAdd.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessEditOwn = "0";
                if (PluginAccessEditOwn.FindByValue(item.Value) != null)
                    TmpPluginAccessEditOwn = PluginAccessEditOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessDeleteOwn = "0";
                if (PluginAccessDeleteOwn.FindByValue(item.Value) != null)
                    TmpPluginAccessDeleteOwn = PluginAccessDeleteOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessEditAll = "0";
                if (PluginAccessEditAll.FindByValue(item.Value) != null)
                    TmpPluginAccessEditAll = PluginAccessEditAll.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpPluginAccessDeleteAll = "0";
                if (PluginAccessDeleteAll.FindByValue(item.Value) != null)
                    TmpPluginAccessDeleteAll = PluginAccessDeleteAll.FindByValue(item.Value).Selected.BooleanToZeroOne();

                if ((TmpPluginAccessShow.ZeroOneToBoolean() || TmpPluginAccessAdd.ZeroOneToBoolean() || TmpPluginAccessEditOwn.ZeroOneToBoolean() || TmpPluginAccessDeleteOwn.ZeroOneToBoolean() || TmpPluginAccessEditAll.ZeroOneToBoolean() || TmpPluginAccessDeleteAll.ZeroOneToBoolean()))
                    db.SetProcedure("set_plugin_role_access", new List<string>() { "@plugin_id", "@role_id", "@access_show", "@access_add", "@access_edit_own", "@access_delete_own", "@access_edit_all", "@access_delete_all" }, new List<string>() { PluginId, RoleId, TmpPluginAccessShow, TmpPluginAccessAdd, TmpPluginAccessEditOwn, TmpPluginAccessDeleteOwn, TmpPluginAccessEditAll, TmpPluginAccessDeleteAll });
            }
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_plugin", new List<string>() { "@plugin_id", "@plugin_load_type", "@plugin_use_language", "@plugin_use_module", "@plugin_use_plugin", "@plugin_use_replace_part", "@plugin_use_fetch", "@plugin_use_item", "@plugin_use_elanat", "@plugin_cache_duration", "@plugin_cache_parameters",  "@plugin_public_access_add", "@plugin_public_access_edit_own", "@plugin_public_access_delete_own", "@plugin_public_access_edit_all", "@plugin_public_access_delete_all", "@plugin_public_access_show", "@plugin_sort_index", "@plugin_category", "@plugin_active" }, new List<string>() { PluginId, PluginLoadType, PluginUseLanguage, PluginUseModule, PluginUsePlugin, PluginUseReplacePart, PluginUseFetch, PluginUseItem, PluginUseElanat, PluginCacheDuration, PluginCacheParameters, PluginPublicAccessAdd, PluginPublicAccessEditOwn, PluginPublicAccessDeleteOwn, PluginPublicAccessEditAll, PluginPublicAccessDeleteAll, PluginPublicAccessShow, PluginSortIndex, PluginCategory, PluginActive });
        }
        
        public void FillCurrentPlugin(string PluginId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_plugin", "@plugin_id", PluginId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.PluginId = dbdr.dr["plugin_id"].ToString();
            PluginName = dbdr.dr["plugin_name"].ToString();
            PluginActive = dbdr.dr["plugin_active"].ToString().TrueFalseToZeroOne();
            PluginDirectoryPath = dbdr.dr["plugin_directory_path"].ToString();
            PluginPhysicalName = dbdr.dr["plugin_physical_name"].ToString();
            PluginLoadType = dbdr.dr["plugin_load_type"].ToString();
            PluginUseLanguage = dbdr.dr["plugin_use_language"].ToString().TrueFalseToZeroOne();
            PluginUseModule = dbdr.dr["plugin_use_module"].ToString().TrueFalseToZeroOne();
            PluginUsePlugin = dbdr.dr["plugin_use_plugin"].ToString().TrueFalseToZeroOne();
            PluginUseReplacePart = dbdr.dr["plugin_use_replace_part"].ToString().TrueFalseToZeroOne();
            PluginUseFetch= dbdr.dr["plugin_use_fetch"].ToString().TrueFalseToZeroOne();
            PluginUseItem= dbdr.dr["plugin_use_item"].ToString().TrueFalseToZeroOne();
            PluginUseElanat = dbdr.dr["plugin_use_elanat"].ToString().TrueFalseToZeroOne();
            PluginCacheDuration = dbdr.dr["plugin_cache_duration"].ToString();
            PluginCacheParameters = dbdr.dr["plugin_cache_parameters"].ToString();
            PluginPublicAccessAdd = dbdr.dr["plugin_public_access_add"].ToString().TrueFalseToZeroOne();
            PluginPublicAccessEditOwn = dbdr.dr["plugin_public_access_edit_own"].ToString().TrueFalseToZeroOne();
            PluginPublicAccessDeleteOwn = dbdr.dr["plugin_public_access_delete_own"].ToString().TrueFalseToZeroOne();
            PluginPublicAccessEditAll = dbdr.dr["plugin_public_access_edit_all"].ToString().TrueFalseToZeroOne();
            PluginPublicAccessDeleteAll = dbdr.dr["plugin_public_access_delete_all"].ToString().TrueFalseToZeroOne();
            PluginPublicAccessShow = dbdr.dr["plugin_public_access_show"].ToString().TrueFalseToZeroOne();
            PluginSortIndex = dbdr.dr["plugin_sort_index"].ToString();
            PluginCategory = dbdr.dr["plugin_category"].ToString();

            db.Close();
        }
        
        public void FillCurrentPluginWithReturnDr(string PluginId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_plugin", "@plugin_id", PluginId);

            if (ReturnDr == null || !ReturnDr.HasRows)
            {
                ReturnDb.Close();
                return;
            }

            ReturnDr.Read();
        }
        
        public string GetColumnValue(string ColumnName)
        {
            switch (ColumnName)
            {
                case "plugin_id": return PluginId;
                case "plugin_name": return PluginName;
                case "plugin_active": return PluginActive;
                case "plugin_directory_path": return PluginDirectoryPath;
                case "plugin_physical_name": return PluginPhysicalName;
                case "plugin_load_type": return PluginLoadType;
                case "plugin_use_language" : return PluginUseLanguage;
                case "plugin_use_module" : return PluginUseModule;
                case "plugin_use_plugin" : return PluginUsePlugin;
                case "plugin_use_replace_part": return PluginUseReplacePart;
                case "plugin_use_fetch": return PluginUseFetch;
                case "plugin_use_item": return PluginUseItem;
                case "plugin_use_elanat": return PluginUseElanat;
                case "plugin_cache_duration": return PluginCacheDuration;
                case "plugin_cache_parameters": return PluginCacheParameters;
                case "plugin_public_access_add": return PluginPublicAccessAdd;
                case "plugin_public_access_edit_own": return PluginPublicAccessEditOwn;
                case "plugin_public_access_delete_own": return PluginPublicAccessDeleteOwn;
                case "plugin_public_access_edit_all": return PluginPublicAccessEditAll;
                case "plugin_public_access_delete_all": return PluginPublicAccessDeleteAll;
                case "plugin_public_access_show": return PluginPublicAccessShow;
                case "plugin_sort_index": return PluginSortIndex;
                case "plugin_category": return PluginCategory;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            PluginId = "";
            PluginName = "";
            PluginActive = "";
            PluginDirectoryPath = "";
            PluginPhysicalName = "";
            PluginLoadType = "";
            PluginUseLanguage = "";
            PluginUseModule = "";
            PluginUsePlugin = "";
            PluginUseReplacePart = "";
            PluginUseFetch = "";
            PluginUseItem = "";
            PluginUseElanat = "";
            PluginCacheDuration = "";
            PluginCacheParameters = "";
            PluginPublicAccessAdd = "";
            PluginPublicAccessEditOwn = "";
            PluginPublicAccessDeleteOwn = "";
            PluginPublicAccessEditAll = "";
            PluginPublicAccessDeleteAll = "";
            PluginPublicAccessShow = "";
            PluginSortIndex = "";
            PluginCategory = "";

            ReturnDr.Close();
        }

        public string GetPluginIdByPluginName(string PluginName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_id_by_plugin_name", "@plugin_name", PluginName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PluginId = dbdr.dr["plugin_id"].ToString();

                db.Close();

                return PluginId;
            }

            db.Close();

            return null;
        }

        public string GetPluginIdByPluginDirectoryPath(string PluginDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_id_by_plugin_directory_path", "@plugin_directory_path",PluginDirectoryPath);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PluginId = dbdr.dr["plugin_id"].ToString();

                db.Close();

                return PluginId;
            }

            db.Close();

            return null;
        }

        public bool PluginAccessShow;
        public bool PluginAccessAdd;
        public bool PluginAccessDeleteAll;
        public bool PluginAccessEditAll;
        public bool PluginAccessDeleteOwn;
        public bool PluginAccessEditOwn;
        public void FillPluginRoleAccess(string PluginId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin_role_access_check_by_group_id", new List<string>() { "@plugin_id", "@group_id" }, new List<string>() { PluginId, ccoc.GroupId });

            dbdr.dr.Read();

            PluginAccessShow = dbdr.dr["plugin_access_show"].ToString().TrueFalseToBoolean();
            PluginAccessAdd = dbdr.dr["plugin_access_add"].ToString().TrueFalseToBoolean();
            PluginAccessDeleteAll = dbdr.dr["plugin_access_delete_all"].ToString().TrueFalseToBoolean();
            PluginAccessEditAll = dbdr.dr["plugin_access_edit_all"].ToString().TrueFalseToBoolean();
            PluginAccessDeleteOwn = dbdr.dr["plugin_access_delete_own"].ToString().TrueFalseToBoolean();
            PluginAccessEditOwn = dbdr.dr["plugin_access_edit_own"].ToString().TrueFalseToBoolean();

            db.Close();
        }

        public string GetPluginCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_plugin", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();
            string PluginCount = "0";

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                PluginCount = dbdr.dr["row_count"].ToString();
            }

            db.Close();

            return PluginCount;
        }

        public void SetPluginValueTransfer(string PluginDirectoryPath, string CacheKey, int CacheDuration)
        {
            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);

            // Get Cache
            if (cc.Exist(CacheType, "el_plugin_static_head_" + PluginId + CacheKey)) // Or cc.Exist(CacheType, "el_plugin_load_tag_" + PluginId + CacheKey)
            {
                string PluginStaticHead = cc.GetValue(CacheType, "el_plugin_static_head_" + PluginId + CacheKey);
                string PluginLoadTag = cc.GetValue(CacheType, "el_plugin_load_tag_" + PluginId + CacheKey);


                // Set Page Value Transfer
                PageValueTransfer transfer = new PageValueTransfer();

                if (!string.IsNullOrEmpty(PluginStaticHead))
                {
                    if (!string.IsNullOrEmpty(transfer.Head))
                    {
                        if (!transfer.Head.Contains(PluginStaticHead))
                            transfer.Head += PluginStaticHead;
                    }
                    else
                        transfer.Head += PluginStaticHead;
                }

                if (!string.IsNullOrEmpty(PluginLoadTag))
                {
                    if (!string.IsNullOrEmpty(transfer.LoadTag))
                    {
                        if (!transfer.LoadTag.Contains(PluginLoadTag))
                            transfer.LoadTag += PluginLoadTag;
                    }
                    else
                        transfer.LoadTag += PluginLoadTag;
                }
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

                string PluginStaticHead = doc.SelectSingleNode("plugin_catalog_root/plugin_static_head").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath);
                string PluginLoadTag = doc.SelectSingleNode("plugin_catalog_root/plugin_load_tag").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath);


                // Set Page Value Transfer
                PageValueTransfer transfer = new PageValueTransfer();

                if (!string.IsNullOrEmpty(PluginStaticHead))
                {
                    if (!string.IsNullOrEmpty(transfer.Head))
                    {
                        if (!transfer.Head.Contains(PluginStaticHead))
                            transfer.Head += PluginStaticHead;
                    }
                    else
                        transfer.Head += PluginStaticHead;
                }

                if (!string.IsNullOrEmpty(PluginLoadTag))
                {
                    if (!string.IsNullOrEmpty(transfer.LoadTag))
                    {
                        if (!transfer.LoadTag.Contains(PluginLoadTag))
                            transfer.LoadTag += PluginLoadTag;
                    }
                    else
                        transfer.LoadTag += PluginLoadTag;
                }


                // Set Cache
                cc.Insert(CacheType, "el_plugin_static_head_" + PluginId + CacheKey, PluginStaticHead, CacheDuration);
                cc.Insert(CacheType, "el_plugin_load_tag_" + PluginId + CacheKey, PluginLoadTag, CacheDuration);
            }
        }

        // Overload
        public void SetPluginValueTransfer(string PluginDirectoryPath)
        {
            SetPluginValueTransfer(PluginDirectoryPath, "", 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Refresh();
                ReturnDb.Close();
                ReturnDb.Dispose();
            }
        }
    }
}