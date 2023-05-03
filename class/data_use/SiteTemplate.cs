using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat.DataUse
{
    public class SiteTemplate : IDisposable
    {
        public string SiteTemplateId= "";
        public string SiteTemplateName = "";
        public string SiteTemplatePhysicalName = "";
        public string SiteTemplateDirectoryPath = "";
        public string SiteTemplateLoadTag = "";
        public string SiteTemplateStaticHead = "";
        public string SiteTemplateActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string SiteTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_site_template", "@site_template_id", SiteTemplateId);
        }

        public void Inactive(string SiteTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_site_template", "@site_template_id", SiteTemplateId);
        }

        public void Delete(string SiteTemplateId)
        {
            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();
            dust.FillCurrentSiteTemplate(SiteTemplateId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_site_template", "@site_template_id", SiteTemplateId);


            // Delete All Root File List
            string Path = "template/site/" + dust.SiteTemplateDirectoryPath;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            // Delete Physical Directory
            List<string> ParentDirectoryList = dust.SiteTemplateDirectoryPath.Split('/').ToList();
            bool IsLastDirectory = true;

            while (ParentDirectoryList.Count >= 1)
            {
                string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                    break;

                System.IO.Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/site/" + TmpPath + "/"), IsLastDirectory);
                ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                IsLastDirectory = false;
            }
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_site_template", new List<string>() { "@site_template_name", "@site_template_directory_path", "@site_template_physical_name", "@site_template_load_tag", "@site_template_static_head", "@site_template_active" }, new List<string>() { SiteTemplateName, SiteTemplateDirectoryPath, SiteTemplatePhysicalName, SiteTemplateLoadTag, SiteTemplateStaticHead, SiteTemplateActive });

            dbdr.dr.Read();

            SiteTemplateId = dbdr.dr["site_template_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_site_template", new List<string>() { "@site_template_name", "@site_template_directory_path", "@site_template_physical_name", "@site_template_load_tag", "@site_template_static_head", "@site_template_active" }, new List<string>() { SiteTemplateName, SiteTemplateDirectoryPath, SiteTemplatePhysicalName, SiteTemplateLoadTag, SiteTemplateStaticHead, SiteTemplateActive });

            ReturnDr.Read();

            SiteTemplateId = ReturnDr["site_template_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_site_template", new List<string>() { "@site_template_id", "@site_template_name", "@site_template_directory_path", "@site_template_physical_name", "@site_template_load_tag", "@site_template_static_head", "@site_template_active" }, new List<string>() { SiteTemplateId, SiteTemplateName, SiteTemplateDirectoryPath, SiteTemplatePhysicalName, SiteTemplateLoadTag, SiteTemplateStaticHead, SiteTemplateActive });
        }
        
        public void FillCurrentSiteTemplate(string SiteTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_site_template", "@site_template_id", SiteTemplateId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.SiteTemplateId = dbdr.dr["site_template_id"].ToString();
            SiteTemplateName = dbdr.dr["site_template_name"].ToString();
            SiteTemplatePhysicalName = dbdr.dr["site_template_physical_name"].ToString();
            SiteTemplateDirectoryPath = dbdr.dr["site_template_directory_path"].ToString();
            SiteTemplateLoadTag = dbdr.dr["site_template_load_tag"].ToString();
            SiteTemplateStaticHead = dbdr.dr["site_template_static_head"].ToString();
            SiteTemplateActive = dbdr.dr["site_template_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentSiteTemplateWithReturnDr(string SiteTemplateId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_site_template", "@site_template_id", SiteTemplateId);

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
                case "site_template_id": return SiteTemplateId;
                case "site_template_name": return SiteTemplateName;
                case "site_template_physical_name": return SiteTemplatePhysicalName;
                case "site_template_directory_path": return SiteTemplateDirectoryPath;
                case "site_template_load_tag": return SiteTemplateLoadTag;
                case "site_template_static_head": return SiteTemplateStaticHead;
                case "site_template_active": return SiteTemplateActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            SiteTemplateId= "";
            SiteTemplateName = "";
            SiteTemplatePhysicalName = "";
            SiteTemplateDirectoryPath = "";
            SiteTemplateLoadTag = "";
            SiteTemplateStaticHead = "";
            SiteTemplateActive = "";

            ReturnDr.Close();
        }

        public string GetSiteTemplateIdBySiteTemplateName(string SiteTemplateName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_template_id_by_site_template_name", "@site_template_name", SiteTemplateName);
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string SiteTemplateId = dbdr.dr["site_template_id"].ToString();

                db.Close();

                return SiteTemplateId;
            }

            db.Close();

            return null;
        }

        public string GetTemplatePhysicalPath(string SiteTemplateId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_template_physical_path", "@site_template_id", SiteTemplateId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string SiteTemplatePhysicalPath = dbdr.dr["site_template_physical_path"].ToString();

            db.Close();

            return SiteTemplatePhysicalPath;
        }
        
        public NameValueCollection GetActiveTemplatePhysicalPathNameNumber()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_site_template_physical_path_list", new List<string>(), new List<string>(), false);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            NameValueCollection TemplatePhysicalPathNameNumber = new NameValueCollection();

            int i = 0;

            while (dbdr.dr.Read())
                TemplatePhysicalPathNameNumber.Add(dbdr.dr["site_template_physical_path"].ToString(), (i++).ToString());

            db.Close();

            return TemplatePhysicalPathNameNumber;
        }

        public List<XmlDocument> SetTemplatePhysicalPathDocumentList(NameValueCollection TemplatePhysicalPathNameNumber)
        {
            List<XmlDocument> TemplatePhysicalPathDocumentList = new List<XmlDocument>();

            foreach (string text in TemplatePhysicalPathNameNumber)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/site/" + text));

                TemplatePhysicalPathDocumentList.Add(doc);
            }

            return TemplatePhysicalPathDocumentList;
        }

        public string GetSiteTemplateCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_template", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string SiteTemplateCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return SiteTemplateCount;
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