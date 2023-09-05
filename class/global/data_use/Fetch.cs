using System.Data.SqlClient;
using System.Xml;

namespace Elanat.DataUse
{
    public class Fetch : IDisposable
    {
        public string FetchId = "";
        public string FetchName = "";
        public string FetchCategory = "";
        public string FetchCacheDuration = "";
        public string FetchSortIndex = "";
        public string FetchActive = "";
        public string FetchPublicAccessShow = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_fetch", "@fetch_id", FetchId);
        }

        public void Inactive(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_fetch", "@fetch_id", FetchId);
        }

        public void Delete(string FetchId)
        {
            DataUse.Fetch duf = new DataUse.Fetch();
            duf.FillCurrentFetch(FetchId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_fetch", "@fetch_id", FetchId);


            // Delete All Root File List
            string Path = "add_on/fetch/" + duf.FetchName;
            FileAndDirectory fad = new FileAndDirectory();
            fad.DeleteFileFromUninstallXmlFileList(Path);


            // Delete Physical Directory
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + duf.FetchName + "/"), true);
        }

        public bool GetFetchAccessShowCheck(string FetchId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("fetch_access_show_check_by_group_id", new List<string>() { "@fetch_id", "@group_id" }, new List<string>() { FetchId, ccoc.GroupId });

            dbdr.dr.Read();

            string FetchAccessShow = dbdr.dr["fetch_access_show"].ToString();

            db.Close();

            return (FetchAccessShow == "1");
        }

        public void DeleteFetchAccessShow(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_fetch_access_show", "@fetch_id", FetchId);
        }

        public void DeleteMenuFetch(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu_fetch", "@fetch_id", FetchId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_fetch", new List<string>() { "@fetch_name", "@fetch_category", "@fetch_cache_duration", "@fetch_sort_index", "@fetch_active", "@fetch_public_access_show" }, new List<string>() { FetchName, FetchCategory, FetchCacheDuration, FetchSortIndex, FetchActive, FetchPublicAccessShow });

            dbdr.dr.Read();

            FetchId = dbdr.dr["fetch_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_fetch", new List<string>() { "@fetch_name", "@fetch_category", "@fetch_cache_duration", "@fetch_sort_index", "@fetch_active", "@fetch_public_access_show" }, new List<string>() { FetchName, FetchCategory, FetchCacheDuration, FetchSortIndex, FetchActive, FetchPublicAccessShow });

            ReturnDr.Read();

            FetchId = ReturnDr["fetch_id"].ToString();
        }

        public void SetFetchAccessShow(string FetchId, List<ListItem> FetchAccessShowListFetch)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in FetchAccessShowListFetch)
                if (item.Selected)
                    db.SetProcedure("set_fetch_access_show", new List<string>() { "@role_id", "@fetch_id" }, new List<string>() { item.Value, FetchId });
        }

        // Overload
        public void SetFetchAccessShow(List<ListItem> FetchAccessShowListFetch)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in FetchAccessShowListFetch)
                if (item.Selected)
                    db.SetProcedure("set_fetch_access_show", new List<string>() { "@role_id", "@fetch_id" }, new List<string>() { item.Value, FetchId });
        }

        public void AddMenuFetch(string FetchId, List<ListItem> MenuFetchListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuFetchListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_fetch", new List<string>() { "@menu_id", "@fetch_id" }, new List<string>() { item.Value, FetchId });
        }

        // Overload
        public void AddMenuFetch(List<ListItem> MenuFetchListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuFetchListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_fetch", new List<string>() { "@menu_id", "@fetch_id" }, new List<string>() { item.Value, FetchId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_fetch", new List<string>() { "@fetch_id", "@fetch_category", "@fetch_cache_duration", "@fetch_sort_index", "@fetch_active", "@fetch_public_access_show" }, new List<string>() { FetchId, FetchCategory, FetchCacheDuration, FetchSortIndex, FetchActive, FetchPublicAccessShow });
        }

        public void FillCurrentFetch(string FetchId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_fetch", "@fetch_id", FetchId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.FetchId = dbdr.dr["fetch_id"].ToString();
            FetchName = dbdr.dr["fetch_name"].ToString();
            FetchCategory = dbdr.dr["fetch_category"].ToString();
            FetchCacheDuration = dbdr.dr["fetch_cache_duration"].ToString();
            FetchSortIndex = dbdr.dr["fetch_sort_index"].ToString();
            FetchActive = dbdr.dr["fetch_active"].ToString().TrueFalseToZeroOne();
            FetchPublicAccessShow = dbdr.dr["fetch_public_access_show"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentFetchByFetchName(string FetchName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_fetch_by_fetch_name", "@fetch_name", FetchName);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.FetchId = dbdr.dr["fetch_id"].ToString();
            FetchName = dbdr.dr["fetch_name"].ToString();
            FetchCategory = dbdr.dr["fetch_category"].ToString();
            FetchCacheDuration = dbdr.dr["fetch_cache_duration"].ToString();
            FetchSortIndex = dbdr.dr["fetch_sort_index"].ToString();
            FetchActive = dbdr.dr["fetch_active"].ToString().TrueFalseToZeroOne();
            FetchPublicAccessShow = dbdr.dr["fetch_public_access_show"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentFetchWithReturnDr(string FetchId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_fetch", "@fetch_id", FetchId);

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
                case "fetch_id": return FetchId;
                case "fetch_name": return FetchName;
                case "fetch_category": return FetchCategory;
                case "fetch_cache_duration": return FetchCacheDuration;
                case "fetch_sort_index": return FetchSortIndex;
                case "fetch_active": return FetchActive;
                case "fetch_public_access_show": return FetchPublicAccessShow;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            FetchId = "";
            FetchName = "";
            FetchCategory = "";
            FetchCacheDuration = "";
            FetchSortIndex = "";
            FetchActive = "";
            FetchPublicAccessShow = "";

            ReturnDr.Close();
        }

        public string GetFetchCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_fetch", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string FetchCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return FetchCount;
        }

        public string GetFetchValue(string FetchName, string GlobalLanguage)
        {
            AttributeReader ar = new AttributeReader();
            return ar.GetFetch(FetchName, GlobalLanguage);
        }

        public void SetFetchValueTransfer(string FetchName, int CacheDuration)
        {
            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);

            // Get Cache
            if (cc.Exist(CacheType, "el_fetch_static_head_" + FetchName)) // Or cc.Exist(CacheType, "el_fetch_load_tag_" + FetchName)
            {
                string FetchStaticHead = cc.GetValue(CacheType, "el_fetch_static_head_" + FetchName);
                string FetchLoadTag = cc.GetValue(CacheType, "el_fetch_load_tag_" + FetchName);


                // Set Page Value Transfer
                PageValueTransfer transfer = new PageValueTransfer();

                if (!string.IsNullOrEmpty(FetchStaticHead))
                {
                    if (!string.IsNullOrEmpty(transfer.Head))
                    {
                        if (!transfer.Head.Contains(FetchStaticHead))
                            transfer.Head += FetchStaticHead;
                    }
                    else
                        transfer.Head += FetchStaticHead;
                }

                if (!string.IsNullOrEmpty(FetchLoadTag))
                {
                    if (!string.IsNullOrEmpty(transfer.LoadTag))
                    {
                        if (!transfer.LoadTag.Contains(FetchLoadTag))
                            transfer.LoadTag += FetchLoadTag;
                    }
                    else
                        transfer.LoadTag += FetchLoadTag;
                }
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchName + "/fetch.xml"));

                string FetchStaticHead = doc.SelectSingleNode("fetch_root/static_head").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath);
                string FetchLoadTag = doc.SelectSingleNode("fetch_root/load_tag").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "").Replace("$_asp site_path;", StaticObject.SitePath);


                // Set Page Value Transfer
                PageValueTransfer transfer = new PageValueTransfer();

                if (!string.IsNullOrEmpty(FetchStaticHead))
                {
                    if (!string.IsNullOrEmpty(transfer.Head))
                    {
                        if (!transfer.Head.Contains(FetchStaticHead))
                            transfer.Head += FetchStaticHead;
                    }
                    else
                        transfer.Head += FetchStaticHead;
                }

                if (!string.IsNullOrEmpty(FetchLoadTag))
                {
                    if (!string.IsNullOrEmpty(transfer.LoadTag))
                    {
                        if (!transfer.LoadTag.Contains(FetchLoadTag))
                            transfer.LoadTag += FetchLoadTag;
                    }
                    else
                        transfer.LoadTag += FetchLoadTag;
                }


                // Set Cache
                cc.Insert(CacheType, "el_fetch_static_head_" + FetchName, FetchStaticHead, CacheDuration);
                cc.Insert(CacheType, "el_fetch_load_tag_" + FetchName, FetchLoadTag, CacheDuration);
            }
        }

        // Overload
        public void SetFetchValueTransfer(string FetchDirectoryPath)
        {
            SetFetchValueTransfer(FetchDirectoryPath, 0);
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