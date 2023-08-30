using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Menu : IDisposable
    {
        public string MenuId = "";
        public string SiteId = "";
        public string MenuName = "";
        public string MenuLocation = "";
        public string MenuSortIndex = "";
        public string MenuUseBox = "";
        public string MenuPublicAccessShow = "";
        public string MenuActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_menu", "@menu_id", MenuId);
        }

        public void Inactive(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_menu", "@menu_id", MenuId);
        }

        public void Delete(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu", "@menu_id", MenuId);
        }

        public void DeleteMenuAccessShow(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu_access_show", "@menu_id", MenuId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_menu", new List<string>() { "@site_id", "@menu_name", "@menu_location", "@menu_sort_index", "@menu_use_box", "@menu_public_access_show", "@menu_active" }, new List<string>() { SiteId, MenuName, MenuLocation, MenuSortIndex, MenuUseBox, MenuPublicAccessShow, MenuActive });

            dbdr.dr.Read();

            MenuId = dbdr.dr["menu_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_menu", new List<string>() { "@site_id", "@menu_name", "@menu_location", "@menu_sort_index", "@menu_use_box", "@menu_public_access_show", "@menu_active" }, new List<string>() { SiteId, MenuName, MenuLocation, MenuSortIndex, MenuUseBox, MenuPublicAccessShow, MenuActive });

            ReturnDr.Read();

            MenuId = ReturnDr["menu_id"].ToString();
        }

        public void SetMenuAccessShow(string MenuId, List<ListItem> MenuAccessShowListMenu)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuAccessShowListMenu)
                if (item.Selected)
                    db.SetProcedure("set_menu_access_show", new List<string>() { "@role_id", "@menu_id" }, new List<string>() { item.Value, MenuId });
        }

        // Overload
        public void SetMenuAccessShow(List<ListItem> MenuAccessShowListMenu)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuAccessShowListMenu)
                if (item.Selected)
                    db.SetProcedure("set_menu_access_show", new List<string>() { "@role_id", "@menu_id" }, new List<string>() { item.Value, MenuId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_menu", new List<string>() { "@menu_id", "@site_id", "@menu_name", "@menu_location", "@menu_sort_index", "@menu_use_box", "@menu_public_access_show", "@menu_active" }, new List<string>() { MenuId, SiteId, MenuName, MenuLocation, MenuSortIndex, MenuUseBox, MenuPublicAccessShow, MenuActive });
        }

        public void FillCurrentMenu(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_menu", "@menu_id", MenuId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.MenuId = dbdr.dr["menu_id"].ToString();
            SiteId = dbdr.dr["site_id"].ToString();
            MenuName = dbdr.dr["menu_name"].ToString();
            MenuLocation = dbdr.dr["menu_location"].ToString();
            MenuSortIndex = dbdr.dr["menu_sort_index"].ToString();
            MenuUseBox = dbdr.dr["menu_use_box"].ToString().TrueFalseToZeroOne();
            MenuPublicAccessShow = dbdr.dr["menu_public_access_show"].ToString().TrueFalseToZeroOne();
            MenuActive = dbdr.dr["menu_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentMenuWithReturnDr(string MenuId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_menu", "@menu_id", MenuId);

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
                case "menu_id": return MenuId;
                case "site_id": return SiteId;
                case "menu_name": return MenuName;
                case "menu_location": return MenuLocation;
                case "menu_sort_index": return MenuSortIndex;
                case "menu_use_box": return MenuUseBox;
                case "menu_public_access_show": return MenuPublicAccessShow;
                case "menu_active": return MenuActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            MenuId = "";
            SiteId = "";
            MenuName = "";
            MenuLocation = "";
            MenuSortIndex = "";
            MenuUseBox = "";
            MenuPublicAccessShow = "";
            MenuActive = "";

            ReturnDr.Close();
        }

        public string GetMenuCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string MenuCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return MenuCount;
        }

        public string GetMenuName(string MenuId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_menu_name", "@menu_id", MenuId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string MenuName = dbdr.dr["menu_name"].ToString();

                db.Close();

                return MenuName;
            }

            db.Close();

            return null;
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