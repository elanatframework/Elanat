using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class SiteStyle : IDisposable
    {
        public string SiteStyleId= "";
        public string SiteStyleName = "";
        public string SiteStylePhysicalName = "";
        public string SiteStyleDirectoryPath = "";
        public string SiteStyleTemplate = "";
        public string SiteStyleLoadTag = "";
        public string SiteStyleStaticHead = "";
        public string SiteStyleActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string SiteStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_site_style", "@site_style_id", SiteStyleId);
        }

        public void Inactive(string SiteStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_site_style", "@site_style_id", SiteStyleId);
        }

        public void Delete(string SiteStyleId)
        {
            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            duss.FillCurrentSiteStyle(SiteStyleId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_site_style", "@site_style_id", SiteStyleId);


            // Delete All Root File List
            string Path = "client/style/site/" + duss.SiteStyleDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            // Delete Physical Directory
            List<string> ParentDirectoryList = duss.SiteStyleDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_site_style", new List<string>() { "@site_style_name", "@site_style_directory_path", "@site_style_physical_name", "@site_style_template", "@site_style_load_tag", "@site_style_static_head", "@site_style_active" }, new List<string>() { SiteStyleName, SiteStyleDirectoryPath, SiteStylePhysicalName, SiteStyleTemplate, SiteStyleLoadTag, SiteStyleStaticHead, SiteStyleActive });

            dbdr.dr.Read();

            SiteStyleId = dbdr.dr["site_style_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_site_style", new List<string>() { "@site_style_name", "@site_style_directory_path", "@site_style_physical_name", "@site_style_template", "@site_style_load_tag", "@site_style_static_head", "@site_style_active" }, new List<string>() { SiteStyleName, SiteStyleDirectoryPath, SiteStylePhysicalName, SiteStyleTemplate, SiteStyleLoadTag, SiteStyleStaticHead, SiteStyleActive });

            ReturnDr.Read();

            SiteStyleId = ReturnDr["site_style_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_site_style", new List<string>() { "@site_style_id", "@site_style_name", "@site_style_directory_path", "@site_style_physical_name", "@site_style_template", "@site_style_load_tag", "@site_style_static_head", "@site_style_active" }, new List<string>() { SiteStyleId, SiteStyleName, SiteStyleDirectoryPath, SiteStylePhysicalName, SiteStyleTemplate, SiteStyleLoadTag, SiteStyleStaticHead, SiteStyleActive });
        }
        
        public void FillCurrentSiteStyle(string SiteStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_site_style", "@site_style_id", SiteStyleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.SiteStyleId = dbdr.dr["site_style_id"].ToString();
            SiteStyleName = dbdr.dr["site_style_name"].ToString();
            SiteStylePhysicalName = dbdr.dr["site_style_physical_name"].ToString();
            SiteStyleDirectoryPath = dbdr.dr["site_style_directory_path"].ToString();
            SiteStyleTemplate = dbdr.dr["site_style_template"].ToString();
            SiteStyleLoadTag = dbdr.dr["site_style_load_tag"].ToString();
            SiteStyleStaticHead = dbdr.dr["site_style_static_head"].ToString();
            SiteStyleActive = dbdr.dr["site_style_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentSiteStyleWithReturnDr(string SiteStyleId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_site_style", "@site_style_id", SiteStyleId);

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
                case "site_style_id": return SiteStyleId;
                case "site_style_name": return SiteStyleName;
                case "site_style_physical_name": return SiteStylePhysicalName;
                case "site_style_directory_path": return SiteStyleDirectoryPath;
                case "site_style_template": return SiteStyleTemplate;
                case "site_style_load_tag": return SiteStyleLoadTag;
                case "site_style_static_head": return SiteStyleStaticHead;
                case "site_style_active": return SiteStyleActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            SiteStyleId= "";
            SiteStyleName = "";
            SiteStylePhysicalName = "";
            SiteStyleDirectoryPath = "";
            SiteStyleTemplate = "";
            SiteStyleLoadTag = "";
            SiteStyleStaticHead = "";
            SiteStyleActive = "";

            ReturnDr.Close();
        }

        public string GetSiteStyleIdBySiteStyleName(string SiteStyleName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_style_id_by_site_style_name", "@site_style_name", SiteStyleName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string SiteStyleId = dbdr.dr["site_style_id"].ToString();

                db.Close();

                return SiteStyleId;
            }

            db.Close();

            return null;
        }

        public string GetStyleDirectoryPath(string SiteStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_style_directory_path", "@site_style_id", SiteStyleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string SiteStyleDirectoryPath = dbdr.dr["site_style_directory_path"].ToString();

            db.Close();

            return SiteStyleDirectoryPath;
        }

        public string GetStylePhysicalPath(string SiteStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_style_physical_path", "@site_style_id", SiteStyleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string SiteStylePhysicalPath = dbdr.dr["site_style_physical_path"].ToString();

            db.Close();

            return SiteStylePhysicalPath;
        }

        public string GetSiteStyleCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_style", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string SiteStyleCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return SiteStyleCount;
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