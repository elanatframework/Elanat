using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetSqlQueryColumn : System.Web.UI.Page
    {
        public ActionGetSqlQueryColumnModel model = new ActionGetSqlQueryColumnModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["fetch_sql_query"]))
                return;


            model.FetchSqlQueryValue = Request.QueryString["fetch_sql_query"].ToString().Replace("$_asp sql_query_amp;", "&");

            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_language"]))
                model.SqlQueryUseLanguageValue = Request.QueryString["sql_query_use_language"] == "true";
            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_module"]))
                model.SqlQueryUseModuleValue = Request.QueryString["sql_query_use_module"] == "true";
            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_plugin"]))
                model.SqlQueryUsePluginValue = Request.QueryString["sql_query_use_plugin"] == "true";
            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_replace_part"]))
                model.SqlQueryUseReplacePartValue = Request.QueryString["sql_query_use_replace_part"] == "true";
            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_fetch"]))
                model.SqlQueryUseFetchValue = Request.QueryString["sql_query_use_fetch"] == "true";
            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_item"]))
                model.SqlQueryUseItemValue = Request.QueryString["sql_query_use_item"] == "true";
            if (string.IsNullOrEmpty(Request.QueryString["sql_query_use_elanat"]))
                model.SqlQueryUseElanatValue = Request.QueryString["sql_query_use_elanat"] == "true";


            model.SetValue();
        }
    }
}