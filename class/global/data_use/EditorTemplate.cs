using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class EditorTemplate : IDisposable
    {
        public string EditorTemplateId = "";
        public string EditorTemplateName = "";
        public string EditorTemplateDirectoryPath = "";
        public string EditorTemplatePhysicalName = "";
        public string EditorTemplateUseLanguage = "";
        public string EditorTemplateUseModule = "";
        public string EditorTemplateUsePlugin = "";
        public string EditorTemplateUseReplacePart = "";
        public string EditorTemplateUseFetch = "";
        public string EditorTemplateUseItem = "";
        public string EditorTemplateUseElanat = "";
        public string EditorTemplateCacheDuration = "";
        public string EditorTemplateCacheParameters = "";
        public string EditorTemplatePublicAccessShow = "";
        public string EditorTemplateSortIndex = "";
        public string EditorTemplateCategory = "";
        public string EditorTemplateActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string EditorTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_editor_template", "@editor_template_id", EditorTemplateId);
        }

        public void Inactive(string EditorTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_editor_template", "@editor_template_id", EditorTemplateId);
        }

        public void Delete(string EditorTemplateId)
        {
            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();
            duet.FillCurrentEditorTemplate(EditorTemplateId);


            // Run Uninstall Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + duet.EditorTemplateDirectoryPath + "/catalog.xml"));
            XmlNode EditorTemplateCatalog = CatalogDocument.SelectSingleNode("/editor_template_catalog_root");

            if (!string.IsNullOrEmpty(EditorTemplateCatalog["editor_template_uninstall_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/editor_template/" + duet.EditorTemplateDirectoryPath + "/" + EditorTemplateCatalog["editor_template_uninstall_path"].Attributes["value"].Value, false);


            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_editor_template", "@editor_template_id", EditorTemplateId);


            // Delete All Root File List
            string Path = "add_on/editor_template/" + duet.EditorTemplateDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);

            DeletePhysicalDirectory(duet.EditorTemplateDirectoryPath);
        }
        
        public void DeletePhysicalDirectory(string EditorTemplateDirectoryPath)
        {
            List<string> ParentDirectoryList = EditorTemplateDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }
        
        public void DeleteEditorTemplateAccessShow(string EditorTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_editor_template_access_show", "@editor_template_id", EditorTemplateId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_editor_template", new List<string>() { "@editor_template_name", "@editor_template_directory_path", "@editor_template_physical_name", "@editor_template_use_language", "@editor_template_use_module", "@editor_template_use_plugin", "@editor_template_use_replace_part", "@editor_template_use_fetch", "@editor_template_use_item", "@editor_template_use_elanat", "@editor_template_cache_duration", "@editor_template_cache_parameters", "@editor_template_public_access_show", "@editor_template_sort_index", "@editor_template_category", "@editor_template_active" }, new List<string>() { EditorTemplateName, EditorTemplateDirectoryPath, EditorTemplatePhysicalName, EditorTemplateUseLanguage, EditorTemplateUseModule, EditorTemplateUsePlugin, EditorTemplateUseReplacePart, EditorTemplateUseFetch, EditorTemplateUseItem, EditorTemplateUseElanat, EditorTemplateCacheDuration, EditorTemplateCacheParameters, EditorTemplatePublicAccessShow, EditorTemplateSortIndex, EditorTemplateCategory, EditorTemplateActive });

            dbdr.dr.Read();

            EditorTemplateId = dbdr.dr["editor_template_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            DataBaseSocket db = new DataBaseSocket();
            ReturnDr = db.GetProcedure("add_editor_template", new List<string>() { "@editor_template_name", "@editor_template_directory_path", "@editor_template_physical_name", "@editor_template_use_language", "@editor_template_use_module", "@editor_template_use_plugin", "@editor_template_use_replace_part", "@editor_template_use_fetch", "@editor_template_use_item", "@editor_template_use_elanat", "@editor_template_cache_duration", "@editor_template_cache_parameters", "@editor_template_public_access_show", "@editor_template_sort_index", "@editor_template_category", "@editor_template_active" }, new List<string>() { EditorTemplateName, EditorTemplateDirectoryPath, EditorTemplatePhysicalName, EditorTemplateUseLanguage, EditorTemplateUseModule, EditorTemplateUsePlugin, EditorTemplateUseReplacePart, EditorTemplateUseFetch, EditorTemplateUseItem, EditorTemplateUseElanat, EditorTemplateCacheDuration, EditorTemplateCacheParameters, EditorTemplatePublicAccessShow, EditorTemplateSortIndex, EditorTemplateCategory, EditorTemplateActive });

            ReturnDr.Read();

            EditorTemplateId = ReturnDr["editor_template_id"].ToString();
        }
        
        public void SetEditorTemplateAccessShow(string EditorTemplateId, List<ListItem> EditorTemplateAccessShowListEditorTemplate)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in EditorTemplateAccessShowListEditorTemplate)
                if (item.Selected)
                    db.SetProcedure("set_editor_template_access_show", new List<string>() { "@role_id", "@editor_template_id" }, new List<string>() { item.Value, EditorTemplateId });
        }

        // Overload
        public void SetEditorTemplateAccessShow(List<ListItem> EditorTemplateAccessShowListEditorTemplate)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in EditorTemplateAccessShowListEditorTemplate)
                if (item.Selected)
                    db.SetProcedure("set_editor_template_access_show", new List<string>() { "@role_id", "@editor_template_id" }, new List<string>() { item.Value, EditorTemplateId });
        }
        
        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_editor_template", new List<string>() { "@editor_template_id", "@editor_template_use_language", "@editor_template_use_module", "@editor_template_use_plugin", "@editor_template_use_replace_part", "@editor_template_use_fetch", "@editor_template_use_item", "@editor_template_use_elanat", "@editor_template_cache_duration", "@editor_template_cache_parameters", "@editor_template_public_access_show", "@editor_template_sort_index", "@editor_template_category", "@editor_template_active" }, new List<string>() { EditorTemplateId, EditorTemplateUseLanguage, EditorTemplateUseModule, EditorTemplateUsePlugin, EditorTemplateUseReplacePart, EditorTemplateUseFetch, EditorTemplateUseItem, EditorTemplateUseElanat, EditorTemplateCacheDuration, EditorTemplateCacheParameters, EditorTemplatePublicAccessShow, EditorTemplateSortIndex, EditorTemplateCategory, EditorTemplateActive });
        }
        
        public void FillCurrentEditorTemplate(string EditorTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_editor_template", "@editor_template_id", EditorTemplateId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.EditorTemplateId = dbdr.dr["editor_template_id"].ToString();
            EditorTemplateName = dbdr.dr["editor_template_name"].ToString();
            EditorTemplateDirectoryPath = dbdr.dr["editor_template_directory_path"].ToString();
            EditorTemplatePhysicalName = dbdr.dr["editor_template_physical_name"].ToString();
            EditorTemplateUseLanguage = dbdr.dr["editor_template_use_language"].ToString().TrueFalseToZeroOne();
            EditorTemplateUseModule = dbdr.dr["editor_template_use_module"].ToString().TrueFalseToZeroOne();
            EditorTemplateUsePlugin = dbdr.dr["editor_template_use_plugin"].ToString().TrueFalseToZeroOne();
            EditorTemplateUseReplacePart = dbdr.dr["editor_template_use_replace_part"].ToString().TrueFalseToZeroOne();
            EditorTemplateUseFetch= dbdr.dr["editor_template_use_fetch"].ToString().TrueFalseToZeroOne();
            EditorTemplateUseItem= dbdr.dr["editor_template_use_item"].ToString().TrueFalseToZeroOne();
            EditorTemplateUseElanat = dbdr.dr["editor_template_use_elanat"].ToString().TrueFalseToZeroOne();
            EditorTemplateCacheDuration = dbdr.dr["editor_template_cache_duration"].ToString();
            EditorTemplateCacheParameters = dbdr.dr["editor_template_cache_parameters"].ToString();
            EditorTemplatePublicAccessShow = dbdr.dr["editor_template_public_access_show"].ToString().TrueFalseToZeroOne();
            EditorTemplateSortIndex = dbdr.dr["editor_template_sort_index"].ToString();
            EditorTemplateCategory = dbdr.dr["editor_template_category"].ToString();
            EditorTemplateActive = dbdr.dr["editor_template_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentEditorTemplateWithReturnDr(string EditorTemplateId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_editor_template", "@editor_template_id", EditorTemplateId);

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
                case "editor_template_id": return EditorTemplateId;
                case "editor_template_name": return EditorTemplateName;
                case "editor_template_directory_path": return EditorTemplateDirectoryPath;
                case "editor_template_physical_name": return EditorTemplatePhysicalName;
                case "editor_template_use_language" : return EditorTemplateUseLanguage;
                case "editor_template_use_module" : return EditorTemplateUseModule;
                case "editor_template_use_plugin" : return EditorTemplateUsePlugin;
                case "editor_template_use_replace_part": return EditorTemplateUseReplacePart;
                case "editor_template_use_fetch": return EditorTemplateUseFetch;
                case "editor_template_use_item": return EditorTemplateUseItem;
                case "editor_template_use_elanat": return EditorTemplateUseElanat;
                case "editor_template_cache_duration": return EditorTemplateCacheDuration;
                case "editor_template_cache_parameters": return EditorTemplateCacheParameters;
                case "editor_template_public_access_show": return EditorTemplatePublicAccessShow;
                case "editor_template_sort_index": return EditorTemplateSortIndex;
                case "editor_template_category": return EditorTemplateCategory;
                case "editor_template_active": return EditorTemplateActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            EditorTemplateId = "";
            EditorTemplateName = "";
            EditorTemplateDirectoryPath = "";
            EditorTemplatePhysicalName = "";
            EditorTemplateUseLanguage = "";
            EditorTemplateUseModule = "";
            EditorTemplateUsePlugin = "";
            EditorTemplateUseReplacePart = "";
            EditorTemplateUseFetch = "";
            EditorTemplateUseItem = "";
            EditorTemplateUseElanat = "";
            EditorTemplateCacheDuration = "";
            EditorTemplateCacheParameters = "";
            EditorTemplatePublicAccessShow = "";
            EditorTemplateSortIndex = "";
            EditorTemplateCategory = "";
            EditorTemplateActive = "";

            ReturnDr.Close();
        }
        
        public string GetEditorTemplateIdByEditorTemplateDirectoryPath(string EditorTemplateDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_editor_template_id_by_editor_template_directory_path", "@editor_template_directory_path", EditorTemplateDirectoryPath);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string EditorTemplateId = dbdr.dr["editor_template_id"].ToString();

                db.Close();

                return EditorTemplateId;
            }

            db.Close();

            return null;
        }

        public bool GetEditorTemplateAccessShowCheck(string EditorTemplateId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("editor_template_access_show_check_by_group_id", new List<string>() { "@editor_template_id", "@group_id" }, new List<string>() { EditorTemplateId, ccoc.GroupId });

            dbdr.dr.Read();

            string EditorTemplateAccessShow = dbdr.dr["editor_template_access_show"].ToString();

            db.Close();

            return (EditorTemplateAccessShow == "1");
        }

        public string GetEditorTemplateCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_editor_template", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string EditorTemplateCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return EditorTemplateCount;
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