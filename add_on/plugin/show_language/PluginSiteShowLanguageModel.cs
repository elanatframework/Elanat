using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PluginSiteShowLanguageModel
    {
        public void SetValue()
        {
            string PathBoxTemplate = Template.GetSiteTemplate("view/language/box");
            string PathListItemTemplate = Template.GetSiteTemplate("view/language/list_item");

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_language_list");

            string TmpPathListItemTemplate = "";
            string SumPathListItemTemplate = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpPathListItemTemplate = PathListItemTemplate;
                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_asp language_global_name;", dbdr.dr["language_global_name"].ToString());
                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_asp language_name;", dbdr.dr["language_name"].ToString() + "(" + dbdr.dr["language_global_name"].ToString() + ")");

                    SumPathListItemTemplate += TmpPathListItemTemplate;
                }

            db.Close();

            HttpContext.Current.Response.Write(PathBoxTemplate.Replace("$_asp item;", SumPathListItemTemplate).Replace("$_asp site_path;", StaticObject.SitePath));
        }
    }
}