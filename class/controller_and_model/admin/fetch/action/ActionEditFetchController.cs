using CodeBehind;

namespace Elanat
{
    public partial class ActionEditFetchController : CodeBehindController
    {
        public ActionEditFetchModel model = new ActionEditFetchModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveFetch"]))
            {
                btn_SaveFetch_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_GetSqlQueryColumn"]))
            {
                btn_GetSqlQueryColumn_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_FetchId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["fetch_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["fetch_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.FetchIdValue = context.Request.Query["fetch_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveFetch_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.FetchCategoryValue = context.Request.Form["txt_FetchCategory"];
            model.FetchActiveValue = context.Request.Form["cbx_FetchActive"] == "on";
            model.SqlQueryUseLanguageValue = context.Request.Form["cbx_SqlQueryUseLanguage"] == "on";
            model.SqlQueryUseModuleValue = context.Request.Form["cbx_SqlQueryUseModule"] == "on";
            model.SqlQueryUsePluginValue = context.Request.Form["cbx_SqlQueryUsePlugin"] == "on";
            model.SqlQueryUseReplacePartValue = context.Request.Form["cbx_SqlQueryUseReplacePart"] == "on";
            model.SqlQueryUseFetchValue = context.Request.Form["cbx_SqlQueryUseFetch"] == "on";
            model.SqlQueryUseItemValue = context.Request.Form["cbx_SqlQueryUseItem"] == "on";
            model.SqlQueryUseElanatValue = context.Request.Form["cbx_SqlQueryUseElanat"] == "on";
            model.BoxUseLanguageValue = context.Request.Form["cbx_BoxUseLanguage"] == "on";
            model.BoxUseModuleValue = context.Request.Form["cbx_BoxUseModule"] == "on";
            model.BoxUsePluginValue = context.Request.Form["cbx_BoxUsePlugin"] == "on";
            model.BoxUseReplacePartValue = context.Request.Form["cbx_BoxUseReplacePart"] == "on";
            model.BoxUseFetchValue = context.Request.Form["cbx_BoxUseFetch"] == "on";
            model.BoxUseItemValue = context.Request.Form["cbx_BoxUseItem"] == "on";
            model.BoxUseElanatValue = context.Request.Form["cbx_BoxUseElanat"] == "on";
            model.ListItemUseLanguageValue = context.Request.Form["cbx_ListItemUseLanguage"] == "on";
            model.ListItemUseModuleValue = context.Request.Form["cbx_ListItemUseModule"] == "on";
            model.ListItemUsePluginValue = context.Request.Form["cbx_ListItemUsePlugin"] == "on";
            model.ListItemUseReplacePartValue = context.Request.Form["cbx_ListItemUseReplacePart"] == "on";
            model.ListItemUseFetchValue = context.Request.Form["cbx_ListItemUseFetch"] == "on";
            model.ListItemUseItemValue = context.Request.Form["cbx_ListItemUseItem"] == "on";
            model.ListItemUseElanatValue = context.Request.Form["cbx_ListItemUseElanat"] == "on";
            model.FetchCacheDurationValue = context.Request.Form["txt_FetchCacheDuration"];
            model.FetchCacheParametersValue = context.Request.Form["txt_FetchCacheParameters"];
            model.FetchSortIndexValue = context.Request.Form["txt_FetchSortIndex"];
            model.FetchPublicAccessShowValue = context.Request.Form["cbx_FetchPublicAccessShow"] == "on";
            model.FetchNameValue = context.Request.Form["txt_FetchName"];
            model.FetchSqlQueryValue = context.Request.Form["txt_FetchSqlQuery"].ToString().Replace(Environment.NewLine, " ");
            model.FetchBoxValue = context.Request.Form["txt_FetchBox"];
            model.FetchListItemValue = context.Request.Form["txt_FetchListItem"];
            model.FetchStaticHeadValue = context.Request.Form["txt_FetchStaticHead"];
            model.FetchLoadTagValue = context.Request.Form["txt_FetchLoadTag"];
            model.FetchIdValue = context.Request.Form["hdn_FetchId"];
            model.FetchNameValue = context.Request.Form["hdn_FetchName"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_SqlQueryColumn$"))
                {
                    ListItem SqlQueryColumn = new ListItem();

                    SqlQueryColumn.Value = context.Request.Form[name];
                    SqlQueryColumn.Selected = true;

                    model.SqlQueryColumnListItem.Add(SqlQueryColumn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_FetchMenu$"))
                {
                    ListItem FetchMenu = new ListItem();

                    FetchMenu.Value = context.Request.Form[name];
                    FetchMenu.Selected = true;

                    model.FetchMenuListItem.Add(FetchMenu);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_FetchAccessShow$"))
                {
                    ListItem FetchAccessShow = new ListItem();

                    FetchAccessShow.Value = context.Request.Form[name];
                    FetchAccessShow.Selected = true;

                    model.FetchAccessShowListItem.Add(FetchAccessShow);
                }


            // Evaluate Field Check
            model.SaveFetchEvaluateField(context.Request.Form);
            if (model.FindSaveFetchEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SaveFetchEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveFetch();

            model.SuccessView();

            View(model);
        }

        protected void btn_GetSqlQueryColumn_Click(HttpContext context)
        {
            model.SqlQueryUseLanguageValue = context.Request.Form["cbx_SqlQueryUseLanguage"] == "on";
            model.SqlQueryUseModuleValue = context.Request.Form["cbx_SqlQueryUseModule"] == "on";
            model.SqlQueryUsePluginValue = context.Request.Form["cbx_SqlQueryUsePlugin"] == "on";
            model.SqlQueryUseReplacePartValue = context.Request.Form["cbx_SqlQueryUseReplacePart"] == "on";
            model.SqlQueryUseFetchValue = context.Request.Form["cbx_SqlQueryUseFetch"] == "on";
            model.SqlQueryUseItemValue = context.Request.Form["cbx_SqlQueryUseItem"] == "on";
            model.SqlQueryUseElanatValue = context.Request.Form["cbx_SqlQueryUseElanat"] == "on";
            model.FetchSqlQueryValue = context.Request.Form["txt_FetchSqlQuery"].ToString().Replace(Environment.NewLine, " ");
            model.FetchIdValue = context.Request.Form["hdn_FetchId"];


            // Evaluate Field Check
            model.SqlQueryColumnEvaluateField(context.Request.Form);
            if (model.FindSqlQueryColumnEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SqlQueryColumnEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.GetSqlQueryColumn();

            View(model);
        }
    }
}