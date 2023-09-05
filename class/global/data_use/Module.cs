using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class Module : IDisposable
    {
        public string ModuleId = "";
        public string ModuleName = "";
        public string ModuleActive = "";
        public string ModuleDirectoryPath = "";
        public string ModulePhysicalName = "";
        public string ModuleLoadType = "";
        public string ModuleUseLanguage = "";
        public string ModuleUseModule = "";
        public string ModuleUsePlugin = "";
        public string ModuleUseReplacePart = "";
        public string ModuleUseFetch = "";
        public string ModuleUseItem = "";
        public string ModuleUseElanat = "";
        public string ModuleCacheDuration = "";
        public string ModuleCacheParameters = "";
        public string ModulePublicAccessAdd = "";
        public string ModulePublicAccessEditOwn = "";
        public string ModulePublicAccessDeleteOwn = "";
        public string ModulePublicAccessEditAll = "";
        public string ModulePublicAccessDeleteAll = "";
        public string ModulePublicAccessShow = "";
        public string ModuleSortIndex = "";
        public string ModuleCategory = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_module", "@module_id", ModuleId);
        }

        public void Inactive(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_module", "@module_id", ModuleId);
        }

        public void Delete(string ModuleId)
        {
            DataUse.Module dum = new DataUse.Module();
            dum.FillCurrentModule(ModuleId);


            // Run Uninstall Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + dum.ModuleDirectoryPath + "/catalog.xml"));
            XmlNode ModuleCatalog = CatalogDocument.SelectSingleNode("/module_catalog_root");

            if (!string.IsNullOrEmpty(ModuleCatalog["module_uninstall_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/module/" + dum.ModuleDirectoryPath + "/" + ModuleCatalog["module_uninstall_path"].Attributes["value"].Value, false);

            
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_module", "@module_id", ModuleId);


            // Delete All Root File List
            string Path = "add_on/module/" + dum.ModuleDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            DeletePhysicalDirectory(dum.ModuleDirectoryPath);
        }

        public void DeletePhysicalDirectory(string ModuleDirectoryPath)
        {
            List<string> ParentDirectoryList = ModuleDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void DeleteMenuModule(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu_module", "@module_id", ModuleId);
        }

        public void DeleteModuleRoleAccess(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_module_role_access", "@module_id", ModuleId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_module", new List<string>() { "@module_name", "@module_directory_path", "@module_physical_name", "@module_load_type", "@module_use_language", "@module_use_module", "@module_use_plugin", "@module_use_replace_part", "@module_use_fetch", "@module_use_item", "@module_use_elanat", "@module_cache_duration", "@module_cache_parameters", "@module_public_access_add", "@module_public_access_edit_own", "@module_public_access_delete_own", "@module_public_access_edit_all", "@module_public_access_delete_all", "@module_public_access_show", "@module_sort_index", "@module_category", "@module_active" }, new List<string>() { ModuleName, ModuleDirectoryPath, ModulePhysicalName, ModuleLoadType, ModuleUseLanguage, ModuleUseModule, ModuleUsePlugin, ModuleUseReplacePart, ModuleUseFetch, ModuleUseItem, ModuleUseElanat, ModuleCacheDuration, ModuleCacheParameters, ModulePublicAccessAdd, ModulePublicAccessEditOwn, ModulePublicAccessDeleteOwn, ModulePublicAccessEditAll, ModulePublicAccessDeleteAll, ModulePublicAccessShow, ModuleSortIndex, ModuleCategory, ModuleActive });

            dbdr.dr.Read();

            ModuleId = dbdr.dr["module_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_module", new List<string>() { "@module_name", "@module_directory_path", "@module_physical_name", "@module_load_type", "@module_use_language", "@module_use_module", "@module_use_plugin", "@module_use_replace_part", "@module_use_fetch", "@module_use_item", "@module_use_elanat", "@module_cache_duration", "@module_cache_parameters", "@module_public_access_add", "@module_public_access_edit_own", "@module_public_access_delete_own", "@module_public_access_edit_all", "@module_public_access_delete_all", "@module_public_access_show", "@module_sort_index", "@module_category", "@module_active" }, new List<string>() { ModuleName, ModuleDirectoryPath, ModulePhysicalName, ModuleLoadType, ModuleUseLanguage, ModuleUseModule, ModuleUsePlugin, ModuleUseReplacePart, ModuleUseFetch, ModuleUseItem, ModuleUseElanat, ModuleCacheDuration, ModuleCacheParameters, ModulePublicAccessAdd, ModulePublicAccessEditOwn, ModulePublicAccessDeleteOwn, ModulePublicAccessEditAll, ModulePublicAccessDeleteAll, ModulePublicAccessShow, ModuleSortIndex, ModuleCategory, ModuleActive });

            ReturnDr.Read();

            ModuleId = ReturnDr["module_id"].ToString();
        }


        public void AddMenuModule(string ModuleId, List<ListItem> MenuModuleListItem, List<string> ModuleQueryString)
        {
            DataBaseSocket db = new DataBaseSocket();

            int i = 0;

            foreach (ListItem item in MenuModuleListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_module", new List<string>() { "@menu_id", "@module_id", "@menu_module_query_string" }, new List<string>() { item.Value, ModuleId, ModuleQueryString[i++] });
        }

        // Overload
        public void AddMenuModule(List<ListItem> MenuModuleListItem, List<string> ModuleQueryString)
        {
            DataBaseSocket db = new DataBaseSocket();

            int i = 0;

            foreach (ListItem item in MenuModuleListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_module", new List<string>() { "@menu_id", "@module_id", "@menu_module_query_string" }, new List<string>() { item.Value, ModuleId, ModuleQueryString[i++] });
        }

        public void SetModuleRoleAccess(string ModuleId, List<ListItem> ModuleAccessShow, List<ListItem> ModuleAccessAdd, List<ListItem> ModuleAccessEditOwn, List<ListItem> ModuleAccessDeleteOwn, List<ListItem> ModuleAccessEditAll, List<ListItem> ModuleAccessDeleteAll)
        {
            DataBaseSocket db = new DataBaseSocket();

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcu.UserRoleListItem)
            {
                string RoleId = item.Value;

                string TmpModuleAccessShow = "0";
                if (ModuleAccessShow.FindByValue(item.Value) != null)
                    TmpModuleAccessShow = ModuleAccessShow.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessAdd = "0";
                if (ModuleAccessAdd.FindByValue(item.Value) != null)
                    TmpModuleAccessAdd = ModuleAccessAdd.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessEditOwn = "0";
                if (ModuleAccessEditOwn.FindByValue(item.Value) != null)
                    TmpModuleAccessEditOwn = ModuleAccessEditOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessDeleteOwn = "0";
                if (ModuleAccessDeleteOwn.FindByValue(item.Value) != null)
                    TmpModuleAccessDeleteOwn = ModuleAccessDeleteOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessEditAll = "0";
                if (ModuleAccessEditAll.FindByValue(item.Value) != null)
                    TmpModuleAccessEditAll = ModuleAccessEditAll.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessDeleteAll = "0";
                if (ModuleAccessDeleteAll.FindByValue(item.Value) != null)
                    TmpModuleAccessDeleteAll = ModuleAccessDeleteAll.FindByValue(item.Value).Selected.BooleanToZeroOne();

                if ((TmpModuleAccessShow.ZeroOneToBoolean() || TmpModuleAccessAdd.ZeroOneToBoolean() || TmpModuleAccessEditOwn.ZeroOneToBoolean() || TmpModuleAccessDeleteOwn.ZeroOneToBoolean() || TmpModuleAccessEditAll.ZeroOneToBoolean() || TmpModuleAccessDeleteAll.ZeroOneToBoolean()))
                    db.SetProcedure("set_module_role_access", new List<string>() { "@module_id", "@role_id", "@access_show", "@access_add", "@access_edit_own", "@access_delete_own", "@access_edit_all", "@access_delete_all" }, new List<string>() { ModuleId, RoleId, TmpModuleAccessShow, TmpModuleAccessAdd, TmpModuleAccessEditOwn, TmpModuleAccessDeleteOwn, TmpModuleAccessEditAll, TmpModuleAccessDeleteAll });
            }
        }

        // Overload
        public void SetModuleRoleAccess(List<ListItem> ModuleAccessShow, List<ListItem> ModuleAccessAdd, List<ListItem> ModuleAccessEditOwn, List<ListItem> ModuleAccessDeleteOwn, List<ListItem> ModuleAccessEditAll, List<ListItem> ModuleAccessDeleteAll)
        {
            DataBaseSocket db = new DataBaseSocket();

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcu.UserRoleListItem)
            {
                string RoleId = item.Value;

                string TmpModuleAccessShow = "0";
                if (ModuleAccessShow.FindByValue(item.Value) != null)
                    TmpModuleAccessShow = ModuleAccessShow.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessAdd = "0";
                if (ModuleAccessAdd.FindByValue(item.Value) != null)
                    TmpModuleAccessAdd = ModuleAccessAdd.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessEditOwn = "0";
                if (ModuleAccessEditOwn.FindByValue(item.Value) != null)
                    TmpModuleAccessEditOwn = ModuleAccessEditOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessDeleteOwn = "0";
                if (ModuleAccessDeleteOwn.FindByValue(item.Value) != null)
                    TmpModuleAccessDeleteOwn = ModuleAccessDeleteOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessEditAll = "0";
                if (ModuleAccessEditAll.FindByValue(item.Value) != null)
                    TmpModuleAccessEditAll = ModuleAccessEditAll.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpModuleAccessDeleteAll = "0";
                if (ModuleAccessDeleteAll.FindByValue(item.Value) != null)
                    TmpModuleAccessDeleteAll = ModuleAccessDeleteAll.FindByValue(item.Value).Selected.BooleanToZeroOne();

                if ((TmpModuleAccessShow.ZeroOneToBoolean() || TmpModuleAccessAdd.ZeroOneToBoolean() || TmpModuleAccessEditOwn.ZeroOneToBoolean() || TmpModuleAccessDeleteOwn.ZeroOneToBoolean() || TmpModuleAccessEditAll.ZeroOneToBoolean() || TmpModuleAccessDeleteAll.ZeroOneToBoolean()))
                    db.SetProcedure("set_module_role_access", new List<string>() { "@module_id", "@role_id", "@access_show", "@access_add", "@access_edit_own", "@access_delete_own", "@access_edit_all", "@access_delete_all" }, new List<string>() { ModuleId, RoleId, TmpModuleAccessShow, TmpModuleAccessAdd, TmpModuleAccessEditOwn, TmpModuleAccessDeleteOwn, TmpModuleAccessEditAll, TmpModuleAccessDeleteAll });
            }
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_module", new List<string>() { "@module_id", "@module_load_type", "@module_use_language", "@module_use_module", "@module_use_plugin", "@module_use_replace_part", "@module_use_fetch", "@module_use_item", "@module_use_elanat", "@module_cache_duration", "@module_cache_parameters", "@module_public_access_add", "@module_public_access_edit_own", "@module_public_access_delete_own", "@module_public_access_edit_all", "@module_public_access_delete_all", "@module_public_access_show", "@module_sort_index", "@module_category", "@module_active" }, new List<string>() { ModuleId, ModuleLoadType, ModuleUseLanguage, ModuleUseModule, ModuleUsePlugin, ModuleUseReplacePart, ModuleUseFetch, ModuleUseItem, ModuleUseElanat, ModuleCacheDuration, ModuleCacheParameters, ModulePublicAccessAdd, ModulePublicAccessEditOwn, ModulePublicAccessDeleteOwn, ModulePublicAccessEditAll, ModulePublicAccessDeleteAll, ModulePublicAccessShow, ModuleSortIndex, ModuleCategory, ModuleActive });
        }

        public void FillCurrentModule(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_module", "@module_id", ModuleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ModuleId = dbdr.dr["module_id"].ToString();
            ModuleName = dbdr.dr["module_name"].ToString();
            ModuleActive = dbdr.dr["module_active"].ToString().TrueFalseToZeroOne();
            ModuleDirectoryPath = dbdr.dr["module_directory_path"].ToString();
            ModulePhysicalName = dbdr.dr["module_physical_name"].ToString();
            ModuleLoadType = dbdr.dr["module_load_type"].ToString();
            ModuleUseLanguage = dbdr.dr["module_use_language"].ToString().TrueFalseToZeroOne();
            ModuleUseModule = dbdr.dr["module_use_module"].ToString().TrueFalseToZeroOne();
            ModuleUsePlugin = dbdr.dr["module_use_plugin"].ToString().TrueFalseToZeroOne();
            ModuleUseReplacePart = dbdr.dr["module_use_replace_part"].ToString().TrueFalseToZeroOne();
            ModuleUseFetch= dbdr.dr["module_use_fetch"].ToString().TrueFalseToZeroOne();
            ModuleUseItem= dbdr.dr["module_use_item"].ToString().TrueFalseToZeroOne();
            ModuleUseElanat = dbdr.dr["module_use_elanat"].ToString().TrueFalseToZeroOne();
            ModuleCacheDuration = dbdr.dr["module_cache_duration"].ToString();
            ModuleCacheParameters = dbdr.dr["module_cache_parameters"].ToString();
            ModulePublicAccessAdd = dbdr.dr["module_public_access_add"].ToString().TrueFalseToZeroOne();
            ModulePublicAccessEditOwn = dbdr.dr["module_public_access_edit_own"].ToString().TrueFalseToZeroOne();
            ModulePublicAccessDeleteOwn = dbdr.dr["module_public_access_delete_own"].ToString().TrueFalseToZeroOne();
            ModulePublicAccessEditAll = dbdr.dr["module_public_access_edit_all"].ToString().TrueFalseToZeroOne();
            ModulePublicAccessDeleteAll = dbdr.dr["module_public_access_delete_all"].ToString().TrueFalseToZeroOne();
            ModulePublicAccessShow = dbdr.dr["module_public_access_show"].ToString().TrueFalseToZeroOne();
            ModuleSortIndex = dbdr.dr["module_sort_index"].ToString();
            ModuleCategory = dbdr.dr["module_category"].ToString();

            db.Close();
        }

        public void FillCurrentModuleWithReturnDr(string ModuleId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_module", "@module_id", ModuleId);

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
                case "module_id": return ModuleId;
                case "module_name": return ModuleName;
                case "module_active": return ModuleActive;
                case "module_directory_path": return ModuleDirectoryPath;
                case "module_physical_name": return ModulePhysicalName;
                case "module_load_type": return ModuleLoadType;
                case "module_use_language" : return ModuleUseLanguage;
                case "module_use_module" : return ModuleUseModule;
                case "module_use_plugin" : return ModuleUsePlugin;
                case "module_use_replace_part": return ModuleUseReplacePart;
                case "module_use_fetch": return ModuleUseFetch;
                case "module_use_item": return ModuleUseItem;
                case "module_use_elanat": return ModuleUseElanat;
                case "module_cache_duration": return ModuleCacheDuration;
                case "module_cache_parameters": return ModuleCacheParameters;
                case "module_public_access_add": return ModulePublicAccessAdd;
                case "module_public_access_edit_own": return ModulePublicAccessEditOwn;
                case "module_public_access_delete_own": return ModulePublicAccessDeleteOwn;
                case "module_public_access_edit_all": return ModulePublicAccessEditAll;
                case "module_public_access_delete_all": return ModulePublicAccessDeleteAll;
                case "module_public_access_show": return ModulePublicAccessShow;
                case "module_sort_index": return ModuleSortIndex;
                case "module_category": return ModuleCategory;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ModuleId = "";
            ModuleName = "";
            ModuleActive = "";
            ModuleDirectoryPath = "";
            ModulePhysicalName = "";
            ModuleLoadType = "";
            ModuleUseLanguage = "";
            ModuleUseModule = "";
            ModuleUsePlugin = "";
            ModuleUseReplacePart = "";
            ModuleUseFetch = "";
            ModuleUseItem = "";
            ModuleUseElanat = "";
            ModuleCacheDuration = "";
            ModuleCacheParameters = "";
            ModulePublicAccessAdd = "";
            ModulePublicAccessEditOwn = "";
            ModulePublicAccessDeleteOwn = "";
            ModulePublicAccessEditAll = "";
            ModulePublicAccessDeleteAll = "";
            ModulePublicAccessShow = "";
            ModuleSortIndex = "";
            ModuleCategory = "";

            ReturnDr.Close();
        }

        public string GetModuleIdByModuleName(string ModuleName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_id_by_module_name", "@module_name", ModuleName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ModuleId = dbdr.dr["module_id"].ToString();

                db.Close();

                return ModuleId;
            }

            db.Close();

            return null;
        }

        public string GetModuleIdByModuleDirectoryPath(string ModuleDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_id_by_module_directory_path", "@module_directory_path", ModuleDirectoryPath);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ModuleId = dbdr.dr["module_id"].ToString();

                db.Close();

                return ModuleId;
            }

            db.Close();

            return null;
        }

        public bool ModuleAccessShow;
        public bool ModuleAccessAdd;
        public bool ModuleAccessDeleteAll;
        public bool ModuleAccessEditAll;
        public bool ModuleAccessDeleteOwn;
        public bool ModuleAccessEditOwn;

        public void FillModuleRoleAccess(string ModuleId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module_role_access_check_by_group_id", new List<string>() { "@module_id", "@group_id" }, new List<string>() { ModuleId, ccoc.GroupId });

            dbdr.dr.Read();

            ModuleAccessShow = dbdr.dr["module_access_show"].ToString().TrueFalseToBoolean();
            ModuleAccessAdd = dbdr.dr["module_access_add"].ToString().TrueFalseToBoolean();
            ModuleAccessDeleteAll = dbdr.dr["module_access_delete_all"].ToString().TrueFalseToBoolean();
            ModuleAccessEditAll = dbdr.dr["module_access_edit_all"].ToString().TrueFalseToBoolean();
            ModuleAccessDeleteOwn = dbdr.dr["module_access_delete_own"].ToString().TrueFalseToBoolean();
            ModuleAccessEditOwn = dbdr.dr["module_access_edit_own"].ToString().TrueFalseToBoolean();

            db.Close();
        }

        public string GetModuleCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ModuleCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ModuleCount;
        }

        public void SetModuleValueTransfer(string ModuleDirectoryPath, string CacheKey, int CacheDuration)
        {
            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);

            // Get Cache
            if (cc.Exist(CacheType, "el_module_static_head_" + ModuleId + CacheKey)) // Or cc.Exist(CacheType, "el_module_load_tag_" + ModuleId + CacheKey)
            {
                string ModuleStaticHead = cc.GetValue(CacheType, "el_module_static_head_" + ModuleId + CacheKey);
                string ModuleLoadTag = cc.GetValue(CacheType, "el_module_load_tag_" + ModuleId + CacheKey);


                // Set Page Value Transfer
                PageValueTransfer transfer = new PageValueTransfer();

                if (!string.IsNullOrEmpty(ModuleStaticHead))
                {
                    if (!string.IsNullOrEmpty(transfer.Head))
                    {
                        if (!transfer.Head.Contains(ModuleStaticHead))
                            transfer.Head += ModuleStaticHead;
                    }
                    else
                        transfer.Head += ModuleStaticHead;
                }

                if (!string.IsNullOrEmpty(ModuleLoadTag))
                {
                    if (!string.IsNullOrEmpty(transfer.LoadTag))
                    {
                        if (!transfer.LoadTag.Contains(ModuleLoadTag))
                            transfer.LoadTag += ModuleLoadTag;
                    }
                    else
                        transfer.LoadTag += ModuleLoadTag;
                }
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

                string ModuleStaticHead = doc.SelectSingleNode("module_catalog_root/module_static_head").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath);
                string ModuleLoadTag = doc.SelectSingleNode("module_catalog_root/module_load_tag").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath);


                // Set Page Value Transfer
                PageValueTransfer transfer = new PageValueTransfer();

                if (!string.IsNullOrEmpty(ModuleStaticHead))
                {
                    if (!string.IsNullOrEmpty(transfer.Head))
                    {
                        if (!transfer.Head.Contains(ModuleStaticHead))
                            transfer.Head += ModuleStaticHead;
                    }
                    else
                        transfer.Head += ModuleStaticHead;
                }

                if (!string.IsNullOrEmpty(ModuleLoadTag))
                {
                    if (!string.IsNullOrEmpty(transfer.LoadTag))
                    {
                        if (!transfer.LoadTag.Contains(ModuleLoadTag))
                            transfer.LoadTag += ModuleLoadTag;
                    }
                    else
                        transfer.LoadTag += ModuleLoadTag;
                }


                // Set Cache
                cc.Insert(CacheType, "el_module_static_head_" + ModuleId + CacheKey, ModuleStaticHead, CacheDuration);
                cc.Insert(CacheType, "el_module_load_tag_" + ModuleId + CacheKey, ModuleLoadTag, CacheDuration);
            }
        }

        // Overload
        public void SetModuleValueTransfer(string ModuleDirectoryPath)
        {
            SetModuleValueTransfer(ModuleDirectoryPath, "", 0);
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