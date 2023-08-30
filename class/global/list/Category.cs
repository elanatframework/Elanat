namespace Elanat.ListClass
{
    public class Category
    {
        // Get Category Access Show List Item
        public List<ListItem> CategoryAccessShowListItem = new List<ListItem>();
        public void FillCategoryAccessShowListItem(string CategoryId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_category_access_show", "@category_id", CategoryId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["category_id"].ToString();
                    TmpListItem.Value = dbdr.dr["role_id"].ToString();
                    TmpListItem.Selected = true;

                    CategoryAccessShowListItem.Add(TmpListItem);
                }

            db.Close();
        }

        public static List<string> GetParentCategory(string CategoryId)
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_parent_category", "@category_id", CategoryId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    list.Add(dbdr.dr["parent_category"].ToString());
                    list.Add(dbdr.dr["category_name"].ToString());
                }

            db.Close();

            return list;
        }

        // Get Category List Item
        public List<ListItem> CategoryListItemTree = new List<ListItem>();
        public List<ListItem> CategoryListItemTreeWithoutSpace = new List<ListItem>();
        public List<ListItem> CategoryListItemOnlySpace = new List<ListItem>();
        public void FillCategoryListItemTree(string SiteId, string Space = "")
        {
            List<string> CategoryId = new List<string>();
            List<string> CategoryName = new List<string>();
            List<string> ParentCategory = new List<string>();
            List<string> TmpList = new List<string>();


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_category_list_by_site_id", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    CategoryName.Add(dbdr.dr["category_name"].ToString());
                    CategoryId.Add(dbdr.dr["category_id"].ToString());
                    ParentCategory.Add(dbdr.dr["parent_category"].ToString());
                }

            db.Close();

            int i, j;
            string TreeString = "";
            while (CategoryId.Count > 0)
            {
                CategoryListItemTree.Add(CategoryName[0], CategoryId[0]);
                CategoryListItemTreeWithoutSpace.Add(CategoryName[0], CategoryId[0]);
                CategoryListItemOnlySpace.Add("", CategoryId[0]);

                TmpList.Add(CategoryId[0]);

                CategoryName.RemoveAt(0);
                CategoryId.RemoveAt(0);
                ParentCategory.RemoveAt(0);

                while (TmpList.Count > 0)
                {
                    i = 0;
                    j = TmpList.Count - 1;
                    while (i < CategoryId.Count)
                    {
                        if (ParentCategory[i] == TmpList[j])
                        {
                            TreeString = "";
                            foreach (string tmp in TmpList)
                                TreeString += Space;

                            CategoryListItemTree.Add(TreeString + CategoryName[i], CategoryId[i]);
                            CategoryListItemTreeWithoutSpace.Add(CategoryName[i], CategoryId[i]);
                            CategoryListItemOnlySpace.Add(TreeString, CategoryId[i]);

                            TmpList.Add(CategoryId[i]);
                            j++;

                            CategoryName.RemoveAt(i);
                            CategoryId.RemoveAt(i);
                            ParentCategory.RemoveAt(i);

                            i = -1;
                        }
                        i++;
                    }
                    TmpList.RemoveAt(j);
                }
            }
        }
    }
}