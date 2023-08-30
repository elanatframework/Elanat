using CodeBehind;

namespace Elanat
{
    public partial class AdminFetchController : CodeBehindController
    {
        public AdminFetchModel model = new AdminFetchModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddFetch"]))
            {
                btn_AddFetch_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_GetSqlQueryColumn"]))
            {
                btn_GetSqlQueryColumn_Click(context);
                return;
            }

            
            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddFetch_Click(HttpContext context)
        {
            model.FetchPathUploadValue = context.Request.Form.Files["upd_FetchPath"];
            model.UseFetchPathValue = context.Request.Form["cbx_UseFetchPath"] == "on";
            model.FetchPathTextValue = context.Request.Form["txt_FetchPath"];
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


            if (!model.FetchPathUploadValue.HtmlInputHasFile() || (model.UseFetchPathValue && !string.IsNullOrEmpty(model.FetchPathTextValue)))
            {
                // Evaluate Field Check
                model.AddFetchEvaluateField(context.Request.Form);
                if (model.FindAddFetchEvaluateError)
                {
                    ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                    foreach (string EvaluateError in model.AddFetchEvaluateErrorList)
                        rf.AddLocalMessage(EvaluateError, "problem");

                    rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                    rf.RedirectToResponseFormPage();

                    IgnoreViewAndModel = true;

                    return;
                }
            }
            else
            {
                // Evaluate Field Check
                model.UploadFetchEvaluateField(context.Request.Form);
                if (model.FindUploadFetchEvaluateError)
                {
                    ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                    foreach (string EvaluateError in model.UploadFetchEvaluateErrorList)
                        rf.AddLocalMessage(EvaluateError, "problem");

                    rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                    rf.RedirectToResponseFormPage();

                    IgnoreViewAndModel = true;

                    return;
                }
            }


            model.AddFetch();

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