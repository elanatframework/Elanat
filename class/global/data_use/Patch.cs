using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class Patch : IDisposable
    {
        public string PatchId = "";
        public string PatchName = "";
        public string PatchActive = "";
        public string PatchDirectoryPath = "";
        public string PatchCategory = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string PatchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_patch", "@patch_id", PatchId);
        }

        public void Inactive(string PatchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_patch", "@patch_id", PatchId);
        }

        public void Delete(string PatchId)
        {
            DataUse.Patch dup = new DataUse.Patch();
            dup.FillCurrentPatch(PatchId);


            // Run Uninstall Page
            if (dup.PatchActive.ZeroOneToBoolean())
            {
                XmlDocument CatalogDocument = new XmlDocument();
                CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + dup.PatchDirectoryPath + "/catalog.xml"));
                XmlNode PatchCatalog = CatalogDocument.SelectSingleNode("/patch_catalog_root");

                if (!string.IsNullOrEmpty(PatchCatalog["patch_uninstall_path"].Attributes["value"].Value))
                    PageLoader.LoadPath(StaticObject.SitePath + "add_on/patch/" + dup.PatchDirectoryPath + "/" + PatchCatalog["patch_uninstall_path"].Attributes["value"].Value, false);
            }


            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_patch", "@patch_id", PatchId);


            // Delete All Root File List
            string Path = "add_on/patch/" + dup.PatchDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            DeletePhysicalDirectory(dup.PatchDirectoryPath);
        }

        public void DeletePhysicalDirectory(string PatchDirectoryPath)
        {
            // Delete Physical Directory
            List<string> ParentDirectoryList = PatchDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_patch", new List<string>() { "@patch_name", "@patch_directory_path", "@patch_category", "@patch_active" }, new List<string>() { PatchName, PatchDirectoryPath, PatchCategory, PatchActive });

            dbdr.dr.Read();

            PatchId = dbdr.dr["patch_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_patch", new List<string>() { "@patch_name", "@patch_directory_path", "@patch_category", "@patch_active" }, new List<string>() { PatchName, PatchDirectoryPath, PatchCategory, PatchActive });

            ReturnDr.Read();

            PatchId = ReturnDr["patch_id"].ToString();
        }
      
        public void FillCurrentPatch(string PatchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_patch", "@patch_id", PatchId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.PatchId = dbdr.dr["patch_id"].ToString();
            PatchName = dbdr.dr["patch_name"].ToString();
            PatchActive = dbdr.dr["patch_active"].ToString().TrueFalseToZeroOne();
            PatchDirectoryPath = dbdr.dr["patch_directory_path"].ToString();
            PatchCategory = dbdr.dr["patch_category"].ToString();

            db.Close();
        }
        
        public void FillCurrentPatchWithReturnDr(string PatchId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_patch", "@patch_id", PatchId);

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
                case "patch_id": return PatchId;
                case "patch_name": return PatchName;
                case "patch_active": return PatchActive;
                case "patch_directory_path": return PatchDirectoryPath;
                case "patch_category": return PatchCategory;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            PatchId = "";
            PatchName = "";
            PatchActive = "";
            PatchDirectoryPath = "";
            PatchCategory = "";

            ReturnDr.Close();
        }

        public string GetPatchIdByPatchName(string PatchName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_patch_id_by_patch_name", "@patch_name", PatchName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PatchId = dbdr.dr["patch_id"].ToString();

                db.Close();

                return PatchId;
            }

            db.Close();

            return null;
        }

        public string GetPatchIdByPatchDirectoryPath(string PatchDirectoryPath)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_patch_id_by_patch_directory_path", "@patch_directory_path", PatchDirectoryPath);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PatchId = dbdr.dr["patch_id"].ToString();

                db.Close();

                return PatchId;
            }

            db.Close();

            return null;
        }

        public string GetPatchCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_patch", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string PatchCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return PatchCount;
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