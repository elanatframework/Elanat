using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminExtraHelperGroupModel : CodeBehindModel
    {
        public void SetValue(HttpContext context)
        {
            string BoxTemplate = Template.GetAdminTemplate("part/extra_helper_group/box");
            string ListItemTemplate = Template.GetAdminTemplate("part/extra_helper_group/list_item");
            string TmpListItemTemplate;
            string SumListItemTemplate = "";
            string TmpBoxTemplate = "";
            string SumBoxTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_extra_helper", "@outer_attach", "where extra_helper_category <> N'' or extra_helper_category is not null order by extra_helper_category asc, extra_helper_sort_index asc, extra_helper_name asc");

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            string ExtraHelperEmptyCategory = GetEmptyCategoryFromExtraHlper();
            List<string> CategoryFill = new List<string>();

            string CategoryName = "$";

            while (dbdr.dr.Read())
            {
                if (!dbdr.dr["extra_helper_active"].ToString().TrueFalseToBoolean())
                    continue;

                if (CategoryName == "$")
                    CategoryName = dbdr.dr["extra_helper_category"].ToString();

                if (CategoryName != dbdr.dr["extra_helper_category"].ToString())
                {
                    TmpBoxTemplate = BoxTemplate;

                    TmpBoxTemplate = TmpBoxTemplate.Replace("$_db extra_helper_category;", CategoryName);
                    TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", ExtraHelperEmptyCategory + SumListItemTemplate);

                    SumBoxTemplate += TmpBoxTemplate;
                    SumListItemTemplate = "";

                    CategoryName = dbdr.dr["extra_helper_category"].ToString();
                    CategoryFill.Add(CategoryName);
                }

                if (string.IsNullOrEmpty(dbdr.dr["extra_helper_category"].ToString()))
                    continue;

                TmpListItemTemplate = ListItemTemplate;

                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_helper_local_name;", Language.GetHandheldLanguage(dbdr.dr["extra_helper_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp admin_path;", StaticObject.AdminPath);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_id;", dbdr.dr["extra_helper_id"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_name;", dbdr.dr["extra_helper_name"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_physical_path;", dbdr.dr["extra_helper_physical_path"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_directory_path;", dbdr.dr["extra_helper_directory_path"].ToString());

                SumListItemTemplate += TmpListItemTemplate;
            }

            db.Close();

            // Set Last Category
            if (CategoryName != "$")
            {
                TmpBoxTemplate = BoxTemplate;

                TmpBoxTemplate = TmpBoxTemplate.Replace("$_db extra_helper_category;", CategoryName);
                TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", ExtraHelperEmptyCategory + SumListItemTemplate);

                SumBoxTemplate += TmpBoxTemplate;

                CategoryFill.Add(CategoryName);
            }


            // Fill Other System
            // Set Current Value
            ListClass.System lcs = new ListClass.System();
            lcs.FillSystemListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            foreach (ListItem item in lcs.SystemListItem)
            {
                foreach (string category in CategoryFill)
                    if (item.Value == category)
                        continue;

                TmpBoxTemplate = BoxTemplate;

                TmpBoxTemplate = TmpBoxTemplate.Replace("$_db extra_helper_category;", item.Value);
                TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", ExtraHelperEmptyCategory);

                SumBoxTemplate += TmpBoxTemplate;
            }

            Write(SumBoxTemplate);
        }

        private string GetEmptyCategoryFromExtraHlper()
        {
            string ListItemTemplate = Template.GetAdminTemplate("part/extra_helper_group/list_item");
            string TmpListItemTemplate;
            string SumListItemTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_extra_helper", "@outer_attach", "where extra_helper_category = N'' or extra_helper_category is null  order by extra_helper_sort_index asc, extra_helper_name asc");

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            while (dbdr.dr.Read())
            {
                if (!dbdr.dr["extra_helper_active"].ToString().TrueFalseToBoolean())
                    continue;

                TmpListItemTemplate = ListItemTemplate;

                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_helper_local_name;", Language.GetHandheldLanguage(dbdr.dr["extra_helper_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp admin_path;", StaticObject.AdminPath);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_id;", dbdr.dr["extra_helper_id"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_name;", dbdr.dr["extra_helper_name"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_physical_path;", dbdr.dr["extra_helper_physical_path"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db extra_helper_directory_path;", dbdr.dr["extra_helper_directory_path"].ToString());

                SumListItemTemplate += TmpListItemTemplate;
            }

            db.Close();

            return SumListItemTemplate;
        }
    }
}