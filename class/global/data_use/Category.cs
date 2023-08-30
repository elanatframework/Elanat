using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Category : IDisposable
    {
        public string CategoryId = "";
        public string SiteId = "";
        public string CategoryName = "";
        public string RequireApproval = "";
        public string ParentCategory = "";
        public string SiteStyleId = "";
        public string SiteTemplateId = "";
        public string CategoryPublicAccessShow = "";
        public string CategoryActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_category", "@category_id", CategoryId);
        }

        public void Inactive(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_category", "@category_id", CategoryId);
        }

        public void Delete(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_category", "@category_id", CategoryId);
        }

        public bool GetCategoryAccessShowCheck(string CategoryId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();

            bool ReturnValue = false;

            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("category_access_show_check_by_group_id", new List<string>() { "@category_id", "@group_id" }, new List<string>() { CategoryId, ccoc.GroupId });

            dbdr.dr.Read();

            string CategoryAccessShow = dbdr.dr["category_access_show"].ToString();

            if (CategoryAccessShow == "1")
            {
                dbdr.dr.NextResult();

                dbdr.dr.Read();

                string ParentCategory = dbdr.dr["parent_category"].ToString();

                if (ParentCategory == "0")
                    ReturnValue = true;
                else
                    ReturnValue = GetCategoryAccessShowCheck(ParentCategory); // Set Recursive
            }
            else
                return false;

            db.Close();

            return ReturnValue;
        }

        public void DeleteCategoryAccessShow(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_category_access_show", "@category_id", CategoryId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_category", new List<string>() { "@site_id", "@category_name", "@require_approval", "@parent_category", "@site_style_id", "@site_template_id", "@category_active", "@category_public_access_show" }, new List<string>() { SiteId, CategoryName, RequireApproval, ParentCategory, SiteStyleId, SiteTemplateId, CategoryActive, CategoryPublicAccessShow });

            dbdr.dr.Read();

            CategoryId = dbdr.dr["category_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_category", new List<string>() { "@site_id", "@category_name", "@require_approval", "@parent_category", "@site_style_id", "@site_template_id", "@category_active", "@category_public_access_show" }, new List<string>() { SiteId, CategoryName, RequireApproval, ParentCategory, SiteStyleId, SiteTemplateId, CategoryActive, CategoryPublicAccessShow });

            ReturnDr.Read();

            CategoryId = ReturnDr["category_id"].ToString();
        }

        public void SetCategoryAccessShow(string CategoryId, List<ListItem> CategoryAccessShowListCategory)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in CategoryAccessShowListCategory)
                if (item.Selected)
                    db.SetProcedure("set_category_access_show", new List<string>() { "@role_id", "@category_id" }, new List<string>() { item.Value, CategoryId });
        }

        // Overload
        public void SetCategoryAccessShow(List<ListItem> CategoryAccessShowListCategory)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in CategoryAccessShowListCategory)
                if (item.Selected)
                    db.SetProcedure("set_category_access_show", new List<string>() { "@role_id", "@category_id" }, new List<string>() { item.Value, CategoryId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_category", new List<string>() { "@category_id", "@site_id", "@category_name", "@require_approval", "@parent_category", "@site_style_id", "@site_template_id", "@category_active", "@category_public_access_show" }, new List<string>() { CategoryId, SiteId, CategoryName, RequireApproval, ParentCategory, SiteStyleId, SiteTemplateId, CategoryActive, CategoryPublicAccessShow });
        }

        public void FillCurrentCategory(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_category", "@category_id", CategoryId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.CategoryId = dbdr.dr["category_id"].ToString();
            SiteId = dbdr.dr["site_id"].ToString();
            CategoryName = dbdr.dr["category_name"].ToString();
            RequireApproval = dbdr.dr["require_approval"].ToString().TrueFalseToZeroOne();
            ParentCategory = dbdr.dr["parent_category"].ToString();
            SiteStyleId = dbdr.dr["site_style_id"].ToString();
            SiteTemplateId = dbdr.dr["site_template_id"].ToString();
            CategoryPublicAccessShow = dbdr.dr["category_public_access_show"].ToString().TrueFalseToZeroOne();
            CategoryActive = dbdr.dr["category_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentCategoryWithReturnDr(string CategoryId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_category", "@category_id", CategoryId);

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
                case "category_id": return CategoryId;
                case "site_id": return SiteId;
                case "category_name": return CategoryName;
                case "require_approval": return RequireApproval;
                case "parent_category": return ParentCategory;
                case "site_style_id": return SiteStyleId;
                case "site_template_id": return SiteTemplateId;
                case "category_public_access_show": return CategoryPublicAccessShow;
                case "category_active": return CategoryActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            CategoryId = "";
            SiteId = "";
            CategoryName = "";
            RequireApproval = "";
            ParentCategory = "";
            SiteStyleId = "";
            SiteTemplateId = "";
            CategoryPublicAccessShow = "";
            CategoryActive = "";

            ReturnDr.Close();
        }

        public string GetCategoryCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_category_count");

            dbdr.dr.Read();

            string CategoryCount = dbdr.dr["category_count"].ToString();

            db.Close();

            return CategoryCount;
        }

        public string GetCategoryCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_category", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string CategoryCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return CategoryCount;
        }

        public string GetCategoryIdByCategoryName(string CategoryName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_category_id_by_category_name", "@category_name", CategoryName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string CategoryId = dbdr.dr["category_id"].ToString();

                db.Close();

                return CategoryId;
            }

            db.Close();

            return null;
        }

        public string GetCategoryName(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_category_name", "@category_id", CategoryId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string CategoryName = dbdr.dr["category_name"].ToString();

                db.Close();

                return CategoryName;
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