using CodeBehind;
using System.Web;

namespace Elanat
{
    public partial class PluginShowAdminComponentGroupModel : CodeBehindModel
    {
        public void SetValue()
        {
            string BoxTemplate = Template.GetAdminTemplate("part/component_group/box");
            string ListItemTemplate = Template.GetAdminTemplate("part/component_group/list_item");
            string TmpListItemTemplate;
            string SumListItemTemplate = "";
            string TmpBoxTemplate = "";
            string SumBoxTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_component", "@outer_attach", "order by component_category asc, component_name asc");

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            string CategoryName = "$";

            while (dbdr.dr.Read())
            {
                if (CategoryName == "$")
                    CategoryName = dbdr.dr["component_category"].ToString();

                if (CategoryName != dbdr.dr["component_category"].ToString())
                {
                    TmpBoxTemplate = BoxTemplate;

                    TmpBoxTemplate = TmpBoxTemplate.Replace("$_db component_category;", CategoryName);
                    TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", SumListItemTemplate);

                    SumBoxTemplate += TmpBoxTemplate;
                    SumListItemTemplate = "";

                    CategoryName = dbdr.dr["component_category"].ToString();
                }

                if (string.IsNullOrEmpty(dbdr.dr["component_category"].ToString()))
                    continue;

                TmpListItemTemplate = ListItemTemplate;

                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp component_load_struct;", Struct.GetNode("component_tag_attribute_load/" + dbdr.dr["component_load_type"].ToString()).InnerText);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp admin_path;", StaticObject.AdminPath);
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db component_id;", dbdr.dr["component_id"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db component_name;", dbdr.dr["component_name"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db component_category;", dbdr.dr["component_category"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp component_local_category_name;", dbdr.dr["component_category"].ToString().ToUpperFirstChar());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db component_physical_path;", dbdr.dr["component_physical_path"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_db component_directory_path;", dbdr.dr["component_directory_path"].ToString());
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp component_local_name;", Language.GetHandheldLanguage(dbdr.dr["component_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));
                TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp component_category_local_name;", Language.GetHandheldLanguage(dbdr.dr["component_category"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));

                SumListItemTemplate += TmpListItemTemplate;
            }

            db.Close();


            // Set Last Category
            if (CategoryName != "$")
            {
                TmpBoxTemplate = BoxTemplate;

                TmpBoxTemplate = TmpBoxTemplate.Replace("$_db component_category;", CategoryName);
                TmpBoxTemplate = TmpBoxTemplate.Replace("$_asp item;", SumListItemTemplate);

                SumBoxTemplate += TmpBoxTemplate;
            }

            Write(SumBoxTemplate);
        }
    }
}