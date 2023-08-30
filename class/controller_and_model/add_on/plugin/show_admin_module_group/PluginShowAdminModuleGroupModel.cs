using CodeBehind;

namespace Elanat
{
    public partial class PluginShowAdminModuleGroupModel : CodeBehindModel
    {
        public void SetValue()
        {
            string BoxTemplate = Template.GetAdminTemplate("part/module_group/box");
            string ListItemTemplate = Template.GetAdminTemplate("part/module_group/list_item");
            string TmpListItemTemplate;
            string SumListItemTemplate = "";
            string TmpBoxTemplate = "";
            string SumBoxTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_module", "@outer_attach", "order by module_category asc, module_name asc");

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            string CategoryName = "$";

            while (dbdr.dr.Read())
            {
                if (CategoryName == "$")
                    CategoryName = dbdr.dr["module_category"].ToString();

                if (CategoryName != dbdr.dr["module_category"].ToString())
                {
                    TmpBoxTemplate = BoxTemplate;

                    TmpBoxTemplate = TmpBoxTemplate.Replace("$_db module_category;", CategoryName);
                    TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", SumListItemTemplate);

                    SumBoxTemplate += TmpBoxTemplate;
                    SumListItemTemplate = "";

                    CategoryName = dbdr.dr["module_category"].ToString();
                }

                if (string.IsNullOrEmpty(dbdr.dr["module_category"].ToString()))
                    continue;

                TmpListItemTemplate = ListItemTemplate;

                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp module_local_name;", Language.GetHandheldLanguage(dbdr.dr["module_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp site_path;", StaticObject.SitePath);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db module_id;", dbdr.dr["module_id"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db module_name;", dbdr.dr["module_name"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db module_physical_path;", dbdr.dr["module_physical_path"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db module_directory_path;", dbdr.dr["module_directory_path"].ToString());

                SumListItemTemplate += TmpListItemTemplate;
            }

            db.Close();


            // Set Last Category
            if (CategoryName != "$")
            {
                TmpBoxTemplate = BoxTemplate;

                TmpBoxTemplate = TmpBoxTemplate.Replace("$_db module_category;", CategoryName);
                TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", SumListItemTemplate);

                SumBoxTemplate += TmpBoxTemplate;
            }

            Write(SumBoxTemplate);
        }
    }
}