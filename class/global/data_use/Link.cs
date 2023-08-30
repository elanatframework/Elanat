using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Link : IDisposable
    {
        public string LinkId = "";
        public string LinkValue = "";
        public string LinkTitle = "";
        public string LinkHref = "";
        public string LinkRel = "";
        public string LinkTarget = "";
        public string LinkSortIndex = "";
        public string LinkActive = "";
        public string LinkProtocol = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_link", "@link_id", LinkId);
        }

        public void Inactive(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_link", "@link_id", LinkId);
        }

        public void Delete(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_link", "@link_id", LinkId);
        }

        public void DeleteMenuLink(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu_link", "@link_id", LinkId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_link", new List<string>() { "@link_href", "@link_protocol", "@link_sort_index", "@link_target", "@link_title", "@link_rel", "@link_value", "@link_active" }, new List<string>() { LinkHref, LinkProtocol, LinkSortIndex, LinkTarget, LinkTitle, LinkRel, LinkValue, LinkActive });

            dbdr.dr.Read();

            LinkId = dbdr.dr["link_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_link", new List<string>() { "@link_href", "@link_protocol", "@link_sort_index", "@link_target", "@link_title", "@link_rel", "@link_value", "@link_active" }, new List<string>() { LinkHref, LinkProtocol, LinkSortIndex, LinkTarget, LinkTitle, LinkRel, LinkValue, LinkActive });

            ReturnDr.Read();

            LinkId = ReturnDr["link_id"].ToString();
        }

        public void AddMenuLink(string LinkId, List<ListItem> MenuLinkListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuLinkListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_link", new List<string>() { "@menu_id", "@link_id" }, new List<string>() { item.Value, LinkId });
        }

        // Overload
        public void AddMenuLink(List<ListItem> MenuLinkListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuLinkListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_link", new List<string>() { "@menu_id", "@link_id" }, new List<string>() { item.Value, LinkId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_link", new List<string>() { "@link_id", "@link_href", "@link_protocol", "@link_sort_index", "@link_target", "@link_title", "@link_rel", "@link_value", "@link_active" }, new List<string>() { LinkId, LinkHref, LinkProtocol, LinkSortIndex, LinkTarget, LinkTitle, LinkRel, LinkValue, LinkActive });
        }

        public void FillCurrentLink(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_link", "@link_id", LinkId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.LinkId = dbdr.dr["link_id"].ToString();
            LinkValue = dbdr.dr["link_value"].ToString();
            LinkTitle = dbdr.dr["link_title"].ToString();
            LinkHref = dbdr.dr["link_href"].ToString();
            LinkRel = dbdr.dr["link_rel"].ToString();
            LinkTarget = dbdr.dr["link_target"].ToString();
            LinkSortIndex = dbdr.dr["link_sort_index"].ToString();
            LinkActive = dbdr.dr["link_active"].ToString().TrueFalseToZeroOne();
            LinkProtocol = dbdr.dr["link_protocol"].ToString();

            db.Close();
        }

        public void FillCurrentLinkWithReturnDr(string LinkId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_link", "@link_id", LinkId);

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
                case "link_id": return LinkId;
                case "link_value": return LinkValue;
                case "link_title": return LinkTitle;
                case "link_href": return LinkHref;
                case "link_rel": return LinkRel;
                case "link_target": return LinkTarget;
                case "link_sort_index": return LinkSortIndex;
                case "link_active": return LinkActive;
                case "link_protocol": return LinkProtocol;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            LinkId = "";
            LinkValue = "";
            LinkTitle = "";
            LinkHref = "";
            LinkRel = "";
            LinkTarget = "";
            LinkSortIndex = "";
            LinkActive = "";
            LinkProtocol = "";

            ReturnDr.Close();
        }

        public string GetLinkCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_link", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string LinkCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return LinkCount;
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