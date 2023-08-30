using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSqlQueryColumnController : CodeBehindController
    {
        public ActionGetSqlQueryColumnModel model = new ActionGetSqlQueryColumnModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["fetch_sql_query"]))
            {
                IgnoreViewAndModel = true;
                return;
            }


            model.FetchSqlQueryValue = context.Request.Query["fetch_sql_query"].ToString().Replace("$_asp sql_query_amp;", "&");

            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_language"]))
                model.SqlQueryUseLanguageValue = context.Request.Query["sql_query_use_language"] == "true";
            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_module"]))
                model.SqlQueryUseModuleValue = context.Request.Query["sql_query_use_module"] == "true";
            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_plugin"]))
                model.SqlQueryUsePluginValue = context.Request.Query["sql_query_use_plugin"] == "true";
            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_replace_part"]))
                model.SqlQueryUseReplacePartValue = context.Request.Query["sql_query_use_replace_part"] == "true";
            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_fetch"]))
                model.SqlQueryUseFetchValue = context.Request.Query["sql_query_use_fetch"] == "true";
            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_item"]))
                model.SqlQueryUseItemValue = context.Request.Query["sql_query_use_item"] == "true";
            if (string.IsNullOrEmpty(context.Request.Query["sql_query_use_elanat"]))
                model.SqlQueryUseElanatValue = context.Request.Query["sql_query_use_elanat"] == "true";


            model.SetValue();

            View(model);
        }
    }
}