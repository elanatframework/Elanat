using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class Component : IDisposable
    {
        public string ComponentId = "";
        public string ComponentName = "";
        public string ComponentActive = "";
        public string ComponentDirectoryPath = "";
        public string ComponentPhysicalName = "";
        public string ComponentLoadType = "";
        public string ComponentUseLanguage = "";
        public string ComponentUseModule = "";
        public string ComponentUsePlugin = "";
        public string ComponentUseReplacePart = "";
        public string ComponentUseFetch = "";
        public string ComponentUseItem = "";
        public string ComponentUseElanat = "";
        public string ComponentCacheDuration = "";
        public string ComponentCacheParameters = "";
        public string ComponentPublicAccessAdd = "";
        public string ComponentPublicAccessEditOwn = "";
        public string ComponentPublicAccessDeleteOwn = "";
        public string ComponentPublicAccessEditAll = "";
        public string ComponentPublicAccessDeleteAll = "";
        public string ComponentPublicAccessShow = "";
        public string ComponentSortIndex = "";
        public string ComponentCategory = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_component", "@component_id", ComponentId);
        }

        public void Inactive(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_component", "@component_id", ComponentId);
        }

        public void Delete(string ComponentId)
        {
            DataUse.Component duc = new DataUse.Component();
            duc.FillCurrentComponent(ComponentId);


            // Run Uninstall Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + StaticObject.AdminPath + "/" + duc.ComponentDirectoryPath + "/catalog.xml"));
            XmlNode ComponentCatalog = CatalogDocument.SelectSingleNode("/component_catalog_root");

            if (!string.IsNullOrEmpty(ComponentCatalog["component_uninstall_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.AdminPath + "/" + duc.ComponentDirectoryPath + "/" + ComponentCatalog["component_uninstall_path"].Attributes["value"].Value, false);


            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_component", "@component_id", ComponentId);


            // Delete All Root File List
            string Path = StaticObject.AdminPath + "/" + duc.ComponentDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            DeletePhysicalDirectory(duc.ComponentDirectoryPath);
        }

        public void DeletePhysicalDirectory(string ComponentDirectoryPath)
        {
            List<string> ParentDirectoryList = ComponentDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void DeleteComponentRoleAccess(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_component_role_access", "@component_id", ComponentId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_component", new List<string>() { "@component_name", "@component_directory_path", "@component_physical_name", "@component_load_type", "@component_use_language", "@component_use_module", "@component_use_plugin", "@component_use_replace_part", "@component_use_fetch", "@component_use_item", "@component_use_elanat", "@component_cache_duration", "@component_cache_parameters", "@component_public_access_add", "@component_public_access_edit_own", "@component_public_access_delete_own", "@component_public_access_edit_all", "@component_public_access_delete_all", "@component_public_access_show", "@component_sort_index", "@component_category", "@component_active" }, new List<string>() { ComponentName, ComponentDirectoryPath, ComponentPhysicalName, ComponentLoadType, ComponentUseLanguage, ComponentUseModule, ComponentUsePlugin, ComponentUseReplacePart, ComponentUseFetch, ComponentUseItem, ComponentUseElanat, ComponentCacheDuration, ComponentCacheParameters, ComponentPublicAccessAdd, ComponentPublicAccessEditOwn, ComponentPublicAccessDeleteOwn, ComponentPublicAccessEditAll, ComponentPublicAccessDeleteAll, ComponentPublicAccessShow, ComponentSortIndex, ComponentCategory, ComponentActive });

            dbdr.dr.Read();

            ComponentId = dbdr.dr["component_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_component", new List<string>() { "@component_name", "@component_directory_path", "@component_physical_name", "@component_load_type", "@component_use_language", "@component_use_module", "@component_use_plugin", "@component_use_replace_part", "@component_use_fetch", "@component_use_item", "@component_use_elanat", "@component_cache_duration", "@component_cache_parameters", "@component_public_access_add", "@component_public_access_edit_own", "@component_public_access_delete_own", "@component_public_access_edit_all", "@component_public_access_delete_all", "@component_public_access_show", "@component_sort_index", "@component_category", "@component_active" }, new List<string>() { ComponentName, ComponentDirectoryPath, ComponentPhysicalName, ComponentLoadType, ComponentUseLanguage, ComponentUseModule, ComponentUsePlugin, ComponentUseReplacePart, ComponentUseFetch, ComponentUseItem, ComponentUseElanat, ComponentCacheDuration, ComponentCacheParameters, ComponentPublicAccessAdd, ComponentPublicAccessEditOwn, ComponentPublicAccessDeleteOwn, ComponentPublicAccessEditAll, ComponentPublicAccessDeleteAll, ComponentPublicAccessShow, ComponentSortIndex, ComponentCategory, ComponentActive });

            ReturnDr.Read();

            ComponentId = ReturnDr["component_id"].ToString();
        }

        public void SetComponentRoleAccess(string ComponentId, List<ListItem> ComponentAccessShow, List<ListItem> ComponentAccessAdd, List<ListItem> ComponentAccessEditOwn, List<ListItem> ComponentAccessDeleteOwn, List<ListItem> ComponentAccessEditAll, List<ListItem> ComponentAccessDeleteAll)
        {
            DataBaseSocket db = new DataBaseSocket();

            // Set User Role
            ListClass.User lcr = new ListClass.User();
            lcr.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcr.UserRoleListItem)
            {
                string RoleId = item.Value;

                string TmpComponentAccessShow = "0";
                if (ComponentAccessShow.FindByValue(item.Value) != null)
                    TmpComponentAccessShow = ComponentAccessShow.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessAdd = "0";
                if (ComponentAccessAdd.FindByValue(item.Value) != null)
                    TmpComponentAccessAdd = ComponentAccessAdd.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessEditOwn = "0";
                if (ComponentAccessEditOwn.FindByValue(item.Value) != null)
                    TmpComponentAccessEditOwn = ComponentAccessEditOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessDeleteOwn = "0";
                if (ComponentAccessDeleteOwn.FindByValue(item.Value) != null)
                    TmpComponentAccessDeleteOwn = ComponentAccessDeleteOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessEditAll = "0";
                if (ComponentAccessEditAll.FindByValue(item.Value) != null)
                    TmpComponentAccessEditAll = ComponentAccessEditAll.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessDeleteAll = "0";
                if (ComponentAccessDeleteAll.FindByValue(item.Value) != null)
                    TmpComponentAccessDeleteAll = ComponentAccessDeleteAll.FindByValue(item.Value).Selected.BooleanToZeroOne();

                if ((TmpComponentAccessShow.ZeroOneToBoolean() || TmpComponentAccessAdd.ZeroOneToBoolean() || TmpComponentAccessEditOwn.ZeroOneToBoolean() || TmpComponentAccessDeleteOwn.ZeroOneToBoolean() || TmpComponentAccessEditAll.ZeroOneToBoolean() || TmpComponentAccessDeleteAll.ZeroOneToBoolean()))
                    db.SetProcedure("set_component_role_access", new List<string>() { "@component_id", "@role_id", "@access_show", "@access_add", "@access_edit_own", "@access_delete_own", "@access_edit_all", "@access_delete_all" }, new List<string>() { ComponentId, RoleId, TmpComponentAccessShow, TmpComponentAccessAdd, TmpComponentAccessEditOwn, TmpComponentAccessDeleteOwn, TmpComponentAccessEditAll, TmpComponentAccessDeleteAll });
            }
        }

        // Overload
        public void SetComponentRoleAccess(List<ListItem> ComponentAccessShow, List<ListItem> ComponentAccessAdd, List<ListItem> ComponentAccessEditOwn, List<ListItem> ComponentAccessDeleteOwn, List<ListItem> ComponentAccessEditAll, List<ListItem> ComponentAccessDeleteAll)
        {
            DataBaseSocket db = new DataBaseSocket();

            // Set User Role
            ListClass.User lcr = new ListClass.User();
            lcr.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcr.UserRoleListItem)
            {
                string RoleId = item.Value;

                string TmpComponentAccessShow = "0";
                if (ComponentAccessShow.FindByValue(item.Value) != null)
                    TmpComponentAccessShow = ComponentAccessShow.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessAdd = "0";
                if (ComponentAccessAdd.FindByValue(item.Value) != null)
                    TmpComponentAccessAdd = ComponentAccessAdd.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessEditOwn = "0";
                if (ComponentAccessEditOwn.FindByValue(item.Value) != null)
                    TmpComponentAccessEditOwn = ComponentAccessEditOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessDeleteOwn = "0";
                if (ComponentAccessDeleteOwn.FindByValue(item.Value) != null)
                    TmpComponentAccessDeleteOwn = ComponentAccessDeleteOwn.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessEditAll = "0";
                if (ComponentAccessEditAll.FindByValue(item.Value) != null)
                    TmpComponentAccessEditAll = ComponentAccessEditAll.FindByValue(item.Value).Selected.BooleanToZeroOne();
                string TmpComponentAccessDeleteAll = "0";
                if (ComponentAccessDeleteAll.FindByValue(item.Value) != null)
                    TmpComponentAccessDeleteAll = ComponentAccessDeleteAll.FindByValue(item.Value).Selected.BooleanToZeroOne();

                if ((TmpComponentAccessShow.ZeroOneToBoolean() || TmpComponentAccessAdd.ZeroOneToBoolean() || TmpComponentAccessEditOwn.ZeroOneToBoolean() || TmpComponentAccessDeleteOwn.ZeroOneToBoolean() || TmpComponentAccessEditAll.ZeroOneToBoolean() || TmpComponentAccessDeleteAll.ZeroOneToBoolean()))
                    db.SetProcedure("set_component_role_access", new List<string>() { "@component_id", "@role_id", "@access_show", "@access_add", "@access_edit_own", "@access_delete_own", "@access_edit_all", "@access_delete_all" }, new List<string>() { ComponentId, RoleId, TmpComponentAccessShow, TmpComponentAccessAdd, TmpComponentAccessEditOwn, TmpComponentAccessDeleteOwn, TmpComponentAccessEditAll, TmpComponentAccessDeleteAll });
            }
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_component", new List<string>() { "@component_id", "@component_load_type", "@component_use_language", "@component_use_module", "@component_use_plugin", "@component_use_replace_part", "@component_use_fetch", "@component_use_item", "@component_use_elanat", "@component_cache_duration", "@component_cache_parameters", "@component_public_access_add", "@component_public_access_edit_own", "@component_public_access_delete_own", "@component_public_access_edit_all", "@component_public_access_delete_all", "@component_public_access_show", "@component_sort_index", "@component_category", "@component_active" }, new List<string>() { ComponentId, ComponentLoadType, ComponentUseLanguage, ComponentUseModule, ComponentUsePlugin, ComponentUseReplacePart, ComponentUseFetch, ComponentUseItem, ComponentUseElanat, ComponentCacheDuration, ComponentCacheParameters, ComponentPublicAccessAdd, ComponentPublicAccessEditOwn, ComponentPublicAccessDeleteOwn, ComponentPublicAccessEditAll, ComponentPublicAccessDeleteAll, ComponentPublicAccessShow, ComponentSortIndex, ComponentCategory, ComponentActive });
        }

        public void FillCurrentComponent(string ComponentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_component", "@component_id", ComponentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ComponentId = dbdr.dr["component_id"].ToString();
            ComponentName = dbdr.dr["component_name"].ToString();
            ComponentActive = dbdr.dr["component_active"].ToString().TrueFalseToZeroOne();
            ComponentDirectoryPath = dbdr.dr["component_directory_path"].ToString();
            ComponentPhysicalName = dbdr.dr["component_physical_name"].ToString();
            ComponentLoadType = dbdr.dr["component_load_type"].ToString();
            ComponentUseLanguage = dbdr.dr["component_use_language"].ToString().TrueFalseToZeroOne();
            ComponentUseModule = dbdr.dr["component_use_module"].ToString().TrueFalseToZeroOne();
            ComponentUsePlugin = dbdr.dr["component_use_plugin"].ToString().TrueFalseToZeroOne();
            ComponentUseReplacePart = dbdr.dr["component_use_replace_part"].ToString().TrueFalseToZeroOne();
            ComponentUseFetch = dbdr.dr["component_use_fetch"].ToString().TrueFalseToZeroOne();
            ComponentUseItem = dbdr.dr["component_use_item"].ToString().TrueFalseToZeroOne();
            ComponentUseElanat = dbdr.dr["component_use_elanat"].ToString().TrueFalseToZeroOne();
            ComponentCacheDuration = dbdr.dr["component_cache_duration"].ToString();
            ComponentCacheParameters = dbdr.dr["component_cache_parameters"].ToString();
            ComponentPublicAccessAdd = dbdr.dr["component_public_access_add"].ToString().TrueFalseToZeroOne();
            ComponentPublicAccessEditOwn = dbdr.dr["component_public_access_edit_own"].ToString().TrueFalseToZeroOne();
            ComponentPublicAccessDeleteOwn = dbdr.dr["component_public_access_delete_own"].ToString().TrueFalseToZeroOne();
            ComponentPublicAccessEditAll = dbdr.dr["component_public_access_edit_all"].ToString().TrueFalseToZeroOne();
            ComponentPublicAccessDeleteAll = dbdr.dr["component_public_access_delete_all"].ToString().TrueFalseToZeroOne();
            ComponentPublicAccessShow = dbdr.dr["component_public_access_show"].ToString().TrueFalseToZeroOne();
            ComponentSortIndex = dbdr.dr["component_sort_index"].ToString();
            ComponentCategory = dbdr.dr["component_category"].ToString();

            db.Close();
        }

        public void FillCurrentComponentWithReturnDr(string ComponentId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_component", "@component_id", ComponentId);

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
                case "component_id": return ComponentId;
                case "component_name": return ComponentName;
                case "component_active": return ComponentActive;
                case "component_directory_path": return ComponentDirectoryPath;
                case "component_physical_name": return ComponentPhysicalName;
                case "component_load_type": return ComponentLoadType;
                case "component_use_language": return ComponentUseLanguage;
                case "component_use_module": return ComponentUseModule;
                case "component_use_plugin": return ComponentUsePlugin;
                case "component_use_replace_part": return ComponentUseReplacePart;
                case "component_use_fetch": return ComponentUseFetch;
                case "component_use_item": return ComponentUseItem;
                case "component_use_elanat": return ComponentUseElanat;
                case "component_cache_duration": return ComponentCacheDuration;
                case "component_cache_parameters": return ComponentCacheParameters;
                case "component_public_access_add": return ComponentPublicAccessAdd;
                case "component_public_access_edit_own": return ComponentPublicAccessEditOwn;
                case "component_public_access_delete_own": return ComponentPublicAccessDeleteOwn;
                case "component_public_access_edit_all": return ComponentPublicAccessEditAll;
                case "component_public_access_delete_all": return ComponentPublicAccessDeleteAll;
                case "component_public_access_show": return ComponentPublicAccessShow;
                case "component_sort_index": return ComponentSortIndex;
                case "component_category": return ComponentCategory;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ComponentId = "";
            ComponentName = "";
            ComponentActive = "";
            ComponentDirectoryPath = "";
            ComponentPhysicalName = "";
            ComponentLoadType = "";
            ComponentUseLanguage = "";
            ComponentUseModule = "";
            ComponentUsePlugin = "";
            ComponentUseReplacePart = "";
            ComponentUseFetch = "";
            ComponentUseItem = "";
            ComponentUseElanat = "";
            ComponentCacheDuration = "";
            ComponentCacheParameters = "";
            ComponentPublicAccessAdd = "";
            ComponentPublicAccessEditOwn = "";
            ComponentPublicAccessDeleteOwn = "";
            ComponentPublicAccessEditAll = "";
            ComponentPublicAccessDeleteAll = "";
            ComponentPublicAccessShow = "";
            ComponentSortIndex = "";
            ComponentCategory = "";

            ReturnDr.Close();
        }

        public string GetComponentIdByComponentName(string ComponentName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_id_by_component_name", "@component_name", ComponentName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ComponentId = dbdr.dr["component_id"].ToString();

                db.Close();

                return ComponentId;
            }

            db.Close();

            return null;
        }

        public string GetComponentIdByComponentDirectoryPath(string ComponentDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_id_by_component_directory_path", new List<string>() { "@component_directory_path" }, new List<string>() { ComponentDirectoryPath });

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ComponentId = dbdr.dr["component_id"].ToString();

                db.Close();

                return ComponentId;
            }

            db.Close();

            return null;
        }

        public bool ComponentAccessShow;
        public bool ComponentAccessAdd;
        public bool ComponentAccessDeleteAll;
        public bool ComponentAccessEditAll;
        public bool ComponentAccessDeleteOwn;
        public bool ComponentAccessEditOwn;
        public void FillComponentRoleAccess(string ComponentId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component_role_access_check_by_group_id", new List<string>() { "@component_id", "@group_id" }, new List<string>() { ComponentId, ccoc.GroupId });

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            ComponentAccessShow = dbdr.dr["component_access_show"].ToString().TrueFalseToBoolean();
            ComponentAccessAdd = dbdr.dr["component_access_add"].ToString().TrueFalseToBoolean();
            ComponentAccessDeleteAll = dbdr.dr["component_access_delete_all"].ToString().TrueFalseToBoolean();
            ComponentAccessEditAll = dbdr.dr["component_access_edit_all"].ToString().TrueFalseToBoolean();
            ComponentAccessDeleteOwn = dbdr.dr["component_access_delete_own"].ToString().TrueFalseToBoolean();
            ComponentAccessEditOwn = dbdr.dr["component_access_edit_own"].ToString().TrueFalseToBoolean();

            db.Close();
        }

        public string GetComponentCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ComponentCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ComponentCount;
        }

        public bool CheckComponentAccessShowByComponentName(string GroupId, string ComponentName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("check_component_access_by_component_name", new List<string>() { "@group_id", "@component_name" }, new List<string>() { GroupId, ComponentName });

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return false;
            }

            dbdr.dr.Read();

            bool ComponentShow = dbdr.dr["component_show"].ToString().TrueFalseToBoolean();

            db.Close();

            return ComponentShow;
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