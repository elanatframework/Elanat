using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class ExtraHelper : IDisposable
    {
        public string ExtraHelperId = "";
        public string ExtraHelperName = "";
        public string ExtraHelperDirectoryPath = "";
        public string ExtraHelperPhysicalName = "";
        public string ExtraHelperUseLanguage = "";
        public string ExtraHelperUseModule = "";
        public string ExtraHelperUsePlugin = "";
        public string ExtraHelperUseReplacePart = "";
        public string ExtraHelperUseFetch = "";
        public string ExtraHelperUseItem = "";
        public string ExtraHelperUseElanat = "";
        public string ExtraHelperCacheDuration = "";
        public string ExtraHelperCacheParameters = "";
        public string ExtraHelperPublicAccessShow = "";
        public string ExtraHelperSortIndex = "";
        public string ExtraHelperCategory = "";
        public string ExtraHelperActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string ExtraHelperId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_extra_helper", "@extra_helper_id", ExtraHelperId);
        }

        public void Inactive(string ExtraHelperId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_extra_helper", "@extra_helper_id", ExtraHelperId);
        }

        public void Delete(string ExtraHelperId)
        {
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
            dueh.FillCurrentExtraHelper(ExtraHelperId);


            // Run Uninstall Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + dueh.ExtraHelperDirectoryPath + "/catalog.xml"));
            XmlNode ExtraHelperCatalog = CatalogDocument.SelectSingleNode("/extra_helper_catalog_root");

            if (!string.IsNullOrEmpty(ExtraHelperCatalog["extra_helper_uninstall_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/extra_helper/" + dueh.ExtraHelperDirectoryPath + "/" + ExtraHelperCatalog["extra_helper_uninstall_path"].Attributes["value"].Value, false);


            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_extra_helper", "@extra_helper_id", ExtraHelperId);


            // Delete All Root File List
            string Path = "add_on/extra_helper/" + dueh.ExtraHelperDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            DeletePhysicalDirectory(dueh.ExtraHelperDirectoryPath);
        }

        public void DeletePhysicalDirectory(string ExtraHelperDirectoryPath)
        {
            List<string> ParentDirectoryList = ExtraHelperDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void DeleteExtraHelperAccessShow(string ExtraHelperId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_extra_helper_access_show", "@extra_helper_id", ExtraHelperId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_extra_helper", new List<string>() { "@extra_helper_name", "@extra_helper_directory_path", "@extra_helper_physical_name", "@extra_helper_use_language", "@extra_helper_use_module", "@extra_helper_use_plugin", "@extra_helper_use_replace_part", "@extra_helper_use_fetch", "@extra_helper_use_item", "@extra_helper_use_elanat", "@extra_helper_cache_duration", "@extra_helper_cache_parameters", "@extra_helper_public_access_show", "@extra_helper_sort_index", "@extra_helper_category", "@extra_helper_active" }, new List<string>() { ExtraHelperName, ExtraHelperDirectoryPath, ExtraHelperPhysicalName, ExtraHelperUseLanguage, ExtraHelperUseModule, ExtraHelperUsePlugin, ExtraHelperUseReplacePart, ExtraHelperUseFetch, ExtraHelperUseItem, ExtraHelperUseElanat, ExtraHelperCacheDuration, ExtraHelperCacheParameters, ExtraHelperPublicAccessShow, ExtraHelperSortIndex, ExtraHelperCategory, ExtraHelperActive });

            dbdr.dr.Read();

            ExtraHelperId = dbdr.dr["extra_helper_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_extra_helper", new List<string>() { "@extra_helper_name", "@extra_helper_directory_path", "@extra_helper_physical_name", "@extra_helper_use_language", "@extra_helper_use_module", "@extra_helper_use_plugin", "@extra_helper_use_replace_part", "@extra_helper_use_fetch", "@extra_helper_use_item", "@extra_helper_use_elanat", "@extra_helper_cache_duration", "@extra_helper_cache_parameters", "@extra_helper_public_access_show", "@extra_helper_sort_index", "@extra_helper_category", "@extra_helper_active" }, new List<string>() { ExtraHelperName, ExtraHelperDirectoryPath, ExtraHelperPhysicalName, ExtraHelperUseLanguage, ExtraHelperUseModule, ExtraHelperUsePlugin, ExtraHelperUseReplacePart, ExtraHelperUseFetch, ExtraHelperUseItem, ExtraHelperUseElanat, ExtraHelperCacheDuration, ExtraHelperCacheParameters, ExtraHelperPublicAccessShow, ExtraHelperSortIndex, ExtraHelperCategory, ExtraHelperActive });

            ReturnDr.Read();

            ExtraHelperId = ReturnDr["extra_helper_id"].ToString();
        }

        public void SetExtraHelperAccessShow(string ExtraHelperId, List<ListItem> ExtraHelperAccessShowListExtraHelper)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in ExtraHelperAccessShowListExtraHelper)
                if (item.Selected)
                    db.SetProcedure("set_extra_helper_access_show", new List<string>() { "@role_id", "@extra_helper_id" }, new List<string>() { item.Value, ExtraHelperId });
        }

        // Overload
        public void SetExtraHelperAccessShow(List<ListItem> ExtraHelperAccessShowListExtraHelper)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in ExtraHelperAccessShowListExtraHelper)
                if (item.Selected)
                    db.SetProcedure("set_extra_helper_access_show", new List<string>() { "@role_id", "@extra_helper_id" }, new List<string>() { item.Value, ExtraHelperId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_extra_helper", new List<string>() { "@extra_helper_id", "@extra_helper_use_language", "@extra_helper_use_module", "@extra_helper_use_plugin", "@extra_helper_use_replace_part", "@extra_helper_use_fetch", "@extra_helper_use_item", "@extra_helper_use_elanat", "@extra_helper_cache_duration", "@extra_helper_cache_parameters", "@extra_helper_public_access_show", "@extra_helper_sort_index", "@extra_helper_category", "@extra_helper_active" }, new List<string>() { ExtraHelperId, ExtraHelperUseLanguage, ExtraHelperUseModule, ExtraHelperUsePlugin, ExtraHelperUseReplacePart, ExtraHelperUseFetch, ExtraHelperUseItem, ExtraHelperUseElanat, ExtraHelperCacheDuration, ExtraHelperCacheParameters, ExtraHelperPublicAccessShow, ExtraHelperSortIndex, ExtraHelperCategory, ExtraHelperActive });
        }

        public void FillCurrentExtraHelper(string ExtraHelperId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_extra_helper", "@extra_helper_id", ExtraHelperId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ExtraHelperId = dbdr.dr["extra_helper_id"].ToString();
            ExtraHelperName = dbdr.dr["extra_helper_name"].ToString();
            ExtraHelperDirectoryPath = dbdr.dr["extra_helper_directory_path"].ToString();
            ExtraHelperPhysicalName = dbdr.dr["extra_helper_physical_name"].ToString();
            ExtraHelperUseLanguage = dbdr.dr["extra_helper_use_language"].ToString().TrueFalseToZeroOne();
            ExtraHelperUseModule = dbdr.dr["extra_helper_use_module"].ToString().TrueFalseToZeroOne();
            ExtraHelperUsePlugin = dbdr.dr["extra_helper_use_plugin"].ToString().TrueFalseToZeroOne();
            ExtraHelperUseReplacePart = dbdr.dr["extra_helper_use_replace_part"].ToString().TrueFalseToZeroOne();
            ExtraHelperUseFetch= dbdr.dr["extra_helper_use_fetch"].ToString().TrueFalseToZeroOne();
            ExtraHelperUseItem= dbdr.dr["extra_helper_use_item"].ToString().TrueFalseToZeroOne();
            ExtraHelperUseElanat = dbdr.dr["extra_helper_use_elanat"].ToString().TrueFalseToZeroOne();
            ExtraHelperCacheDuration = dbdr.dr["extra_helper_cache_duration"].ToString();
            ExtraHelperCacheParameters = dbdr.dr["extra_helper_cache_parameters"].ToString();
            ExtraHelperPublicAccessShow = dbdr.dr["extra_helper_public_access_show"].ToString().TrueFalseToZeroOne();
            ExtraHelperSortIndex = dbdr.dr["extra_helper_sort_index"].ToString();
            ExtraHelperCategory = dbdr.dr["extra_helper_category"].ToString();
            ExtraHelperActive = dbdr.dr["extra_helper_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentExtraHelperWithReturnDr(string ExtraHelperId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_extra_helper", "@extra_helper_id", ExtraHelperId);

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
                case "extra_helper_id": return ExtraHelperId;
                case "extra_helper_name": return ExtraHelperName;
                case "extra_helper_directory_path": return ExtraHelperDirectoryPath;
                case "extra_helper_physical_name": return ExtraHelperPhysicalName;
                case "extra_helper_use_language" : return ExtraHelperUseLanguage;
                case "extra_helper_use_module" : return ExtraHelperUseModule;
                case "extra_helper_use_plugin" : return ExtraHelperUsePlugin;
                case "extra_helper_use_replace_part": return ExtraHelperUseReplacePart;
                case "extra_helper_use_fetch": return ExtraHelperUseFetch;
                case "extra_helper_use_item": return ExtraHelperUseItem;
                case "extra_helper_use_elanat": return ExtraHelperUseElanat;
                case "extra_helper_cache_duration": return ExtraHelperCacheDuration;
                case "extra_helper_cache_parameters": return ExtraHelperCacheParameters;
                case "extra_helper_public_access_show": return ExtraHelperPublicAccessShow;
                case "extra_helper_sort_index": return ExtraHelperSortIndex;
                case "extra_helper_category": return ExtraHelperCategory;
                case "extra_helper_active": return ExtraHelperActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ExtraHelperId = "";
            ExtraHelperName = "";
            ExtraHelperDirectoryPath = "";
            ExtraHelperPhysicalName = "";
            ExtraHelperUseLanguage = "";
            ExtraHelperUseModule = "";
            ExtraHelperUsePlugin = "";
            ExtraHelperUseReplacePart = "";
            ExtraHelperUseFetch = "";
            ExtraHelperUseItem = "";
            ExtraHelperUseElanat = "";
            ExtraHelperCacheDuration = "";
            ExtraHelperCacheParameters = "";
            ExtraHelperPublicAccessShow = "";
            ExtraHelperSortIndex = "";
            ExtraHelperCategory = "";
            ExtraHelperActive = "";

            ReturnDr.Close();
        }

        public string GetExtraHelperIdByExtraHelperName(string ExtraHelperName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_extra_helper_id_by_extra_helper_name", "@extra_helper_name", ExtraHelperName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ExtraHelperId = dbdr.dr["extra_helper_id"].ToString();

                db.Close();

                return ExtraHelperId;
            }

            db.Close();

            return null;
        }

        public string GetExtraHelperIdByExtraHelperDirectoryPath(string ExtraHelperDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_extra_helper_id_by_extra_helper_directory_path", "@extra_helper_directory_path", ExtraHelperDirectoryPath);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ExtraHelperId = dbdr.dr["extra_helper_id"].ToString();

                db.Close();

                return ExtraHelperId;
            }

            db.Close();

            return null;
        }

        public bool GetExtraHelperAccessShowCheck(string ExtraHelperId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("extra_helper_access_show_check_by_group_id", new List<string>() { "@extra_helper_id", "@group_id" }, new List<string>() { ExtraHelperId, ccoc.GroupId });

            dbdr.dr.Read();

            string ExtraHelperAccessShow = dbdr.dr["extra_helper_access_show"].ToString();

            db.Close();

            return (ExtraHelperAccessShow == "1");
        }

        public string GetExtraHelperCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_extra_helper", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ExtraHelperCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ExtraHelperCount;
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