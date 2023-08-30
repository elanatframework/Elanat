using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class AdminTemplate : IDisposable
    {
        public string AdminTemplateId= "";
        public string AdminTemplateName = "";
        public string AdminTemplatePhysicalName = "";
        public string AdminTemplateDirectoryPath = "";
        public string AdminTemplateTemplate = "";
        public string AdminTemplateLoadTag = "";
        public string AdminTemplateStaticHead = "";
        public string AdminTemplateActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string AdminTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_admin_template", "@admin_template_id", AdminTemplateId);
        }

        public void Inactive(string AdminTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_admin_template", "@admin_template_id", AdminTemplateId);
        }

        public void Delete(string AdminTemplateId)
        {
            DataUse.AdminTemplate duat = new AdminTemplate();
            duat.FillCurrentAdminTemplate(AdminTemplateId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_admin_template", "@admin_template_id", AdminTemplateId);


            // Delete All Root File List
            string Path = "template/admin/" + duat.AdminTemplateDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            // Delete Physical Directory
            List<string> ParentDirectoryList = duat.AdminTemplateDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_admin_template", new List<string>() { "@admin_template_name", "@admin_template_directory_path", "@admin_template_physical_name", "@admin_template_load_tag", "@admin_template_static_head", "@admin_template_active" }, new List<string>() { AdminTemplateName, AdminTemplateDirectoryPath, AdminTemplatePhysicalName, AdminTemplateLoadTag, AdminTemplateStaticHead, AdminTemplateActive });

            dbdr.dr.Read();

            AdminTemplateId = dbdr.dr["admin_template_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_admin_template", new List<string>() { "@admin_template_name", "@admin_template_directory_path", "@admin_template_physical_name", "@admin_template_load_tag", "@admin_template_static_head", "@admin_template_active" }, new List<string>() { AdminTemplateName, AdminTemplateDirectoryPath, AdminTemplatePhysicalName, AdminTemplateLoadTag, AdminTemplateStaticHead, AdminTemplateActive });

            ReturnDr.Read();

            AdminTemplateId = ReturnDr["admin_template_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_admin_template", new List<string>() { "@admin_template_id", "@admin_template_name", "@admin_template_directory_path", "@admin_template_physical_name", "@admin_template_load_tag", "@admin_template_static_head", "@admin_template_active" }, new List<string>() { AdminTemplateId, AdminTemplateName, AdminTemplateDirectoryPath, AdminTemplatePhysicalName, AdminTemplateLoadTag, AdminTemplateStaticHead, AdminTemplateActive });
        }
        
        public void FillCurrentAdminTemplate(string AdminTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_admin_template", "@admin_template_id", AdminTemplateId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.AdminTemplateId = dbdr.dr["admin_template_id"].ToString();
            AdminTemplateName = dbdr.dr["admin_template_name"].ToString();
            AdminTemplatePhysicalName = dbdr.dr["admin_template_physical_name"].ToString();
            AdminTemplateDirectoryPath = dbdr.dr["admin_template_directory_path"].ToString();
            AdminTemplateLoadTag = dbdr.dr["admin_template_load_tag"].ToString();
            AdminTemplateStaticHead = dbdr.dr["admin_template_static_head"].ToString();
            AdminTemplateActive = dbdr.dr["admin_template_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentAdminTemplateWithReturnDr(string AdminTemplateId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_admin_template", "@admin_template_id", AdminTemplateId);

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
                case "admin_template_id": return AdminTemplateId;
                case "admin_template_name": return AdminTemplateName;
                case "admin_template_physical_name": return AdminTemplatePhysicalName;
                case "admin_template_directory_path": return AdminTemplateDirectoryPath;
                case "admin_template_load_tag": return AdminTemplateLoadTag;
                case "admin_template_static_head": return AdminTemplateStaticHead;
                case "admin_template_active": return AdminTemplateActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            AdminTemplateId= "";
            AdminTemplateName = "";
            AdminTemplatePhysicalName = "";
            AdminTemplateDirectoryPath = "";
            AdminTemplateLoadTag = "";
            AdminTemplateStaticHead = "";
            AdminTemplateActive = "";

            ReturnDr.Close();
        }

        public string GetAdminTemplateIdByAdminTemplateName(string AdminTemplateName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_template_id_by_admin_template_name", "@admin_template_name", AdminTemplateName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string AdminTemplateId = dbdr.dr["admin_template_id"].ToString();

                db.Close();

                return AdminTemplateId;
            }

            db.Close();

            return null;
        }

        public string GetTemplatePhysicalPath(string AdminTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_template_physical_path", "@admin_template_id", AdminTemplateId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string AdminTemplatePhysicalPath = dbdr.dr["admin_template_physical_path"].ToString();

            db.Close();

            return AdminTemplatePhysicalPath;
        }

        public List<ListItem> GetActiveTemplatePhysicalPathNameNumber()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_admin_template_physical_path_list", new List<string>(), new List<string>(), false);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            List<ListItem> TemplatePhysicalPathNameNumber = new List<ListItem>();

            int i = 0;

            while (dbdr.dr.Read())
                TemplatePhysicalPathNameNumber.Add(dbdr.dr["admin_template_physical_path"].ToString(), (i++).ToString());

            db.Close();

            return TemplatePhysicalPathNameNumber;
        }

        public List<XmlDocument> SetTemplatePhysicalPathDocumentList(List<ListItem> TemplatePhysicalPathNameNumber)
        {
            List<XmlDocument> TemplatePhysicalPathDocumentList = new List<XmlDocument>();

            foreach (ListItem item in TemplatePhysicalPathNameNumber)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + item.Text));

                TemplatePhysicalPathDocumentList.Add(doc);
            }

            return TemplatePhysicalPathDocumentList;
        }

        public string GetAdminTemplateCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_template", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string AdminTemplateCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return AdminTemplateCount;
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