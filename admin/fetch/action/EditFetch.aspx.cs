using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionEditFetch : System.Web.UI.Page
    {
        public ActionEditFetchModel model = new ActionEditFetchModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveFetch"]))
                btn_SaveFetch_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_GetSqlQueryColumn"]))
                btn_GetSqlQueryColumn_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_FetchId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["fetch_id"]))
                    return;

                if (!Request.QueryString["fetch_id"].ToString().IsNumber())
                    return;

                model.FetchIdValue = Request.QueryString["fetch_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveFetch_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.FetchCategoryValue = Request.Form["txt_FetchCategory"];
            model.FetchActiveValue = Request.Form["cbx_FetchActive"] == "on";
            model.SqlQueryUseLanguageValue = Request.Form["cbx_SqlQueryUseLanguage"] == "on";
            model.SqlQueryUseModuleValue = Request.Form["cbx_SqlQueryUseModule"] == "on";
            model.SqlQueryUsePluginValue = Request.Form["cbx_SqlQueryUsePlugin"] == "on";
            model.SqlQueryUseReplacePartValue = Request.Form["cbx_SqlQueryUseReplacePart"] == "on";
            model.SqlQueryUseFetchValue = Request.Form["cbx_SqlQueryUseFetch"] == "on";
            model.SqlQueryUseItemValue = Request.Form["cbx_SqlQueryUseItem"] == "on";
            model.SqlQueryUseElanatValue = Request.Form["cbx_SqlQueryUseElanat"] == "on";
            model.BoxUseLanguageValue = Request.Form["cbx_BoxUseLanguage"] == "on";
            model.BoxUseModuleValue = Request.Form["cbx_BoxUseModule"] == "on";
            model.BoxUsePluginValue = Request.Form["cbx_BoxUsePlugin"] == "on";
            model.BoxUseReplacePartValue = Request.Form["cbx_BoxUseReplacePart"] == "on";
            model.BoxUseFetchValue = Request.Form["cbx_BoxUseFetch"] == "on";
            model.BoxUseItemValue = Request.Form["cbx_BoxUseItem"] == "on";
            model.BoxUseElanatValue = Request.Form["cbx_BoxUseElanat"] == "on";
            model.ListItemUseLanguageValue = Request.Form["cbx_ListItemUseLanguage"] == "on";
            model.ListItemUseModuleValue = Request.Form["cbx_ListItemUseModule"] == "on";
            model.ListItemUsePluginValue = Request.Form["cbx_ListItemUsePlugin"] == "on";
            model.ListItemUseReplacePartValue = Request.Form["cbx_ListItemUseReplacePart"] == "on";
            model.ListItemUseFetchValue = Request.Form["cbx_ListItemUseFetch"] == "on";
            model.ListItemUseItemValue = Request.Form["cbx_ListItemUseItem"] == "on";
            model.ListItemUseElanatValue = Request.Form["cbx_ListItemUseElanat"] == "on";
            model.FetchCacheDurationValue = Request.Form["txt_FetchCacheDuration"];
            model.FetchCacheParametersValue = Request.Form["txt_FetchCacheParameters"];
            model.FetchSortIndexValue = Request.Form["txt_FetchSortIndex"];
            model.FetchPublicAccessShowValue = Request.Form["cbx_FetchPublicAccessShow"] == "on";
            model.FetchNameValue = Request.Form["txt_FetchName"];
            model.FetchSqlQueryValue = Request.Form["txt_FetchSqlQuery"].Replace(Environment.NewLine, " ");
            model.FetchBoxValue = Request.Form["txt_FetchBox"];
            model.FetchListItemValue = Request.Form["txt_FetchListItem"];
            model.FetchStaticHeadValue = Request.Form["txt_FetchStaticHead"];
            model.FetchLoadTagValue = Request.Form["txt_FetchLoadTag"];
            model.FetchIdValue = Request.Form["hdn_FetchId"];
            model.FetchNameValue = Request.Form["hdn_FetchName"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_SqlQueryColumn$"))
                {
                    ListItem SqlQueryColumn = new ListItem();

                    SqlQueryColumn.Value = Request.Form[name];
                    SqlQueryColumn.Selected = true;

                    model.SqlQueryColumnListItem.Add(SqlQueryColumn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_FetchMenu$"))
                {
                    ListItem FetchMenu = new ListItem();

                    FetchMenu.Value = Request.Form[name];
                    FetchMenu.Selected = true;

                    model.FetchMenuListItem.Add(FetchMenu);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_FetchAccessShow$"))
                {
                    ListItem FetchAccessShow = new ListItem();

                    FetchAccessShow.Value = Request.Form[name];
                    FetchAccessShow.Selected = true;

                    model.FetchAccessShowListItem.Add(FetchAccessShow);
                }


            // Evaluate Field Check
            model.SaveFetchEvaluateField(Request.Form);
            if (model.FindSaveFetchEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SaveFetchEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveFetch();

            model.SuccessView();
        }

        protected void btn_GetSqlQueryColumn_Click(object sender, EventArgs e)
        {
            model.SqlQueryUseLanguageValue = Request.Form["cbx_SqlQueryUseLanguage"] == "on";
            model.SqlQueryUseModuleValue = Request.Form["cbx_SqlQueryUseModule"] == "on";
            model.SqlQueryUsePluginValue = Request.Form["cbx_SqlQueryUsePlugin"] == "on";
            model.SqlQueryUseReplacePartValue = Request.Form["cbx_SqlQueryUseReplacePart"] == "on";
            model.SqlQueryUseFetchValue = Request.Form["cbx_SqlQueryUseFetch"] == "on";
            model.SqlQueryUseItemValue = Request.Form["cbx_SqlQueryUseItem"] == "on";
            model.SqlQueryUseElanatValue = Request.Form["cbx_SqlQueryUseElanat"] == "on";
            model.FetchSqlQueryValue = Request.Form["txt_FetchSqlQuery"].Replace(Environment.NewLine, " ");
            model.FetchIdValue = Request.Form["hdn_FetchId"];


            // Evaluate Field Check
            model.SqlQueryColumnEvaluateField(Request.Form);
            if (model.FindSqlQueryColumnEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SqlQueryColumnEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.GetSqlQueryColumn();
        }
    }
}
