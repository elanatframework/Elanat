using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ExtraHelperShowExtraHelperListModel
    {
        public void SetValue()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ListItemTemplate = doc.SelectSingleNode("template_root/box_load/extra_helper/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string TmpListItemTemplate;
            string SumListItemTemplate = "";

            string ExtraHelperCategorySeparateTemplate = doc.SelectSingleNode("template_root/box_load/extra_helper/category_separate").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_extra_helper_list");

            string ExtraHelperCategorySeparate = "";
            string LastExtraHelperCategory = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    if (dbdr.dr["extra_helper_category"].ToString() != LastExtraHelperCategory)
                    {
                        ExtraHelperCategorySeparate = ExtraHelperCategorySeparateTemplate.Replace("$_asp extra_helper_category;", dbdr.dr["extra_helper_category"].ToString());
                        ExtraHelperCategorySeparate = ExtraHelperCategorySeparateTemplate.Replace("$_asp extra_helper_local_category_name;", Language.GetHandheldLanguage(dbdr.dr["extra_helper_category"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));
                    }
                    else
                        ExtraHelperCategorySeparate = "";

                    LastExtraHelperCategory = dbdr.dr["extra_helper_category"].ToString();

                    TmpListItemTemplate = ListItemTemplate;
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_helper_id;", dbdr.dr["extra_helper_id"].ToString());
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_helper_name;", dbdr.dr["extra_helper_name"].ToString());
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_helper_local_name;", Language.GetHandheldLanguage(dbdr.dr["extra_helper_name"].ToString(), StaticObject.GetCurrentAdminGlobalLanguage()));
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_helper_directory_path;", dbdr.dr["extra_helper_directory_path"].ToString());
                    SumListItemTemplate += ExtraHelperCategorySeparate + TmpListItemTemplate;
                }

            db.Close();

            HttpContext.Current.Response.Write(SumListItemTemplate);
        }
    }
}