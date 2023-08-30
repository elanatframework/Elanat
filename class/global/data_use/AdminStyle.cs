using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class AdminStyle : IDisposable
    {
        public string AdminStyleId= "";
        public string AdminStyleName = "";
        public string AdminStylePhysicalName = "";
        public string AdminStyleDirectoryPath = "";
        public string AdminStyleTemplate = "";
        public string AdminStyleLoadTag = "";
        public string AdminStyleStaticHead = "";
        public string AdminStyleActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;
 
        public void Active(string AdminStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_admin_style", "@admin_style_id", AdminStyleId);
        }

        public void Inactive(string AdminStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_admin_style", "@admin_style_id", AdminStyleId);
        }

        public void Delete(string AdminStyleId)
        {
            DataUse.AdminStyle duas = new AdminStyle();
            duas.FillCurrentAdminStyle(AdminStyleId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_admin_style", "@admin_style_id", AdminStyleId);


            // Delete All Root File List
            string Path = "client/style/admin/" + duas.AdminStyleDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            // Delete Physical Directory
            List<string> ParentDirectoryList = duas.AdminStyleDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/admin/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_admin_style", new List<string>() { "@admin_style_name", "@admin_style_directory_path", "@admin_style_physical_name", "@admin_style_template", "@admin_style_load_tag", "@admin_style_static_head", "@admin_style_active" }, new List<string>() { AdminStyleName, AdminStyleDirectoryPath, AdminStylePhysicalName, AdminStyleTemplate, AdminStyleLoadTag, AdminStyleStaticHead, AdminStyleActive });

            dbdr.dr.Read();

            AdminStyleId = dbdr.dr["admin_style_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_admin_style", new List<string>() { "@admin_style_name", "@admin_style_directory_path", "@admin_style_physical_name", "@admin_style_template", "@admin_style_load_tag", "@admin_style_static_head", "@admin_style_active" }, new List<string>() { AdminStyleName, AdminStyleDirectoryPath, AdminStylePhysicalName, AdminStyleTemplate, AdminStyleLoadTag, AdminStyleStaticHead, AdminStyleActive });
            
            ReturnDr.Read();

            AdminStyleId = ReturnDr["admin_style_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_admin_style", new List<string>() { "@admin_style_id", "@admin_style_name", "@admin_style_directory_path", "@admin_style_physical_name", "@admin_style_template", "@admin_style_load_tag", "@admin_style_static_head", "@admin_style_active" }, new List<string>() { AdminStyleId, AdminStyleName, AdminStyleDirectoryPath, AdminStylePhysicalName, AdminStyleTemplate, AdminStyleLoadTag, AdminStyleStaticHead, AdminStyleActive });
        }
        
        public void FillCurrentAdminStyle(string AdminStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_admin_style", "@admin_style_id", AdminStyleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.AdminStyleId = dbdr.dr["admin_style_id"].ToString();
            AdminStyleName = dbdr.dr["admin_style_name"].ToString();
            AdminStylePhysicalName = dbdr.dr["admin_style_physical_name"].ToString();
            AdminStyleDirectoryPath = dbdr.dr["admin_style_directory_path"].ToString();
            AdminStyleTemplate = dbdr.dr["admin_style_template"].ToString();
            AdminStyleLoadTag = dbdr.dr["admin_style_load_tag"].ToString();
            AdminStyleStaticHead = dbdr.dr["admin_style_static_head"].ToString();
            AdminStyleActive = dbdr.dr["admin_style_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentAdminStyleWithReturnDr(string AdminStyleId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_admin_style", "@admin_style_id", AdminStyleId);

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
                case "admin_style_id": return AdminStyleId;
                case "admin_style_name": return AdminStyleName;
                case "admin_style_physical_name": return AdminStylePhysicalName;
                case "admin_style_directory_path": return AdminStyleDirectoryPath;
                case "admin_style_template": return AdminStyleTemplate;
                case "admin_style_load_tag": return AdminStyleLoadTag;
                case "admin_style_static_head": return AdminStyleStaticHead;
                case "admin_style_active": return AdminStyleActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            AdminStyleId= "";
            AdminStyleName = "";
            AdminStylePhysicalName = "";
            AdminStyleDirectoryPath = "";
            AdminStyleTemplate = "";
            AdminStyleLoadTag = "";
            AdminStyleStaticHead = "";
            AdminStyleActive = "";

            ReturnDr.Close();
        }

        public string GetStyleDirectoryPath(string AdminStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_style_directory_path", "@admin_style_id", AdminStyleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string AdminStyleDirectoryPath = dbdr.dr["admin_style_directory_path"].ToString();

            db.Close();

            return AdminStyleDirectoryPath;
        }

        public string GetStylePhysicalPath(string AdminStyleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_style_physical_path", "@admin_style_id", AdminStyleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string AdminStylePhysicalPath = dbdr.dr["admin_style_physical_path"].ToString();

            db.Close();

            return AdminStylePhysicalPath;
        }

        public string GetAdminStyleIdByAdminStyleName(string AdminStyleName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_style_id_by_admin_style_name", "@admin_style_name", AdminStyleName);
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string AdminStyleId = dbdr.dr["admin_style_id"].ToString();

                db.Close();

                return AdminStyleId;
            }

            db.Close();

            return null;
        }

        public string GetAdminStyleCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_style", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string AdminStyleCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return AdminStyleCount;
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