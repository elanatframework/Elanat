using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class Language : IDisposable
    {
        public string LanguageId = "";
        public string LanguageName = "";
        public string LanguageGlobalName = "";
        public string LanguageIsRightToLeft = "";
        public string LanguageShowLinkInSite = "";
        public string LanguageActive = "";
        public string SiteId = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string LanguageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_language", "@language_id", LanguageId);
        }

        public void Inactive(string LanguageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_language", "@language_id", LanguageId);
        }

        public void Delete(string LanguageId)
        {
            DataUse.Language dul = new DataUse.Language();
            dul.FillCurrentLanguage(LanguageId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_language", "@language_id", LanguageId);


            // Delete All Root File List
            string Path = "language/" + dul.LanguageGlobalName;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            // Delete Physical Directory
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + dul.LanguageGlobalName + "/"), true);
        }
        
        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_language", new List<string>() { "@language_name", "@language_global_name", "@language_is_right_to_left", "@language_show_link_in_site", "@language_active", "@site_id" }, new List<string>() { LanguageName, LanguageGlobalName, LanguageIsRightToLeft, LanguageShowLinkInSite, LanguageActive, SiteId });

            dbdr.dr.Read();

            LanguageId = dbdr.dr["language_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_language", new List<string>() { "@language_name", "@language_global_name", "@language_is_right_to_left", "@language_show_link_in_site", "@language_active", "@site_id" }, new List<string>() { LanguageName, LanguageGlobalName, LanguageIsRightToLeft, LanguageShowLinkInSite, LanguageActive, SiteId });

            ReturnDr.Read();

            LanguageId = ReturnDr["language_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_language", new List<string>() { "@language_id", "@language_show_link_in_site", "@language_active", "@site_id" }, new List<string>() { LanguageId, LanguageShowLinkInSite, LanguageActive, SiteId });
        }
        
        public void FillCurrentLanguage(string LanguageId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_language", "@language_id", LanguageId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.LanguageId = dbdr.dr["language_id"].ToString();
            LanguageName = dbdr.dr["language_name"].ToString();
            LanguageGlobalName = dbdr.dr["language_global_name"].ToString();
            LanguageIsRightToLeft = dbdr.dr["language_is_right_to_left"].ToString().TrueFalseToZeroOne();
            LanguageShowLinkInSite = dbdr.dr["language_show_link_in_site"].ToString().TrueFalseToZeroOne();
            LanguageActive = dbdr.dr["language_active"].ToString().TrueFalseToZeroOne();
            SiteId = dbdr.dr["site_id"].ToString();

            db.Close();
        }

        public void FillCurrentLanguageWithReturnDr(string LanguageId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_language", "@language_id", LanguageId);

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
                case "language_id": return LanguageId;
                case "language_name": return LanguageName;
                case "language_global_name": return LanguageGlobalName;
                case "language_is_right_to_left": return LanguageIsRightToLeft;
                case "language_show_link_in_site": return LanguageShowLinkInSite;
                case "language_active": return LanguageActive;
                case "site_id": return SiteId;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            LanguageId = "";
            LanguageName = "";
            LanguageGlobalName = "";
            LanguageIsRightToLeft = "";
            LanguageShowLinkInSite = "";
            LanguageActive = "";
            SiteId = "";

            ReturnDr.Close();
        }

        public string GetLanguageIdByLanguageGlobalName(string LanguageGlobalName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_language_id_by_language_global_name", "@language_global_name", LanguageGlobalName);
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string LanguageId = dbdr.dr["language_id"].ToString();

                db.Close();

                return LanguageId;
            }

            db.Close();

            return null;
        }

        public List<ListItem> GetActiveLanguageGlobalNameNumber()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_language_global_name", new List<string>(), new List<string>(), false);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            List<ListItem> LanguageGlobalNameNumber = new List<ListItem>();

            int i = 0;

            while (dbdr.dr.Read())
                LanguageGlobalNameNumber.Add(dbdr.dr["language_global_name"].ToString(), (i++).ToString());

            db.Close();

            return LanguageGlobalNameNumber;
        }

        public List<XmlDocument> SetLanguageGlobalNameDocumentList(List<ListItem> LanguageGlobalNameNumber)
        {
            List<XmlDocument> LanguageGlobalNameDocumentList = new List<XmlDocument>();

            foreach (ListItem item in LanguageGlobalNameNumber)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + item.Text + "/" + item.Text + ".xml"));

                LanguageGlobalNameDocumentList.Add(doc);
            }

            return LanguageGlobalNameDocumentList;
        }

        public List<XmlDocument> SetHandheldLanguageGlobalNameDocumentList(List<ListItem> LanguageGlobalNameNumber)
        {
            List<XmlDocument> HandheldLanguageGlobalNameDocumentList = new List<XmlDocument>();

            foreach (ListItem item in LanguageGlobalNameNumber)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + item.Text + "/handheld.xml"));

                HandheldLanguageGlobalNameDocumentList.Add(doc);
            }

            return HandheldLanguageGlobalNameDocumentList;
        }

        public string GetLanguageCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_language", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string LanguageCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return LanguageCount;
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