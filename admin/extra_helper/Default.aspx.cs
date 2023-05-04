using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminExtraHelper : System.Web.UI.Page
    {
        public AdminExtraHelperModel model = new AdminExtraHelperModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddExtraHelper"]))
                btn_AddExtraHelper_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
       }

        protected void btn_AddExtraHelper_Click(object sender, EventArgs e)
        {
            model.ExtraHelperPathUploadValue = Request.Files["upd_ExtraHelperPath"];
            model.UseExtraHelperPathValue = Request.Form["cbx_UseExtraHelperPath"] == "on";
            model.ExtraHelperPathTextValue = Request.Form["txt_ExtraHelperPath"];
            model.PriorityForExtraHelperValue = Request.Form["cbx_PriorityForExtraHelper"] == "on";
            model.ExtraHelperCategoryValue = Request.Form["txt_ExtraHelperCategory"];
            model.ExtraHelperActiveValue = Request.Form["cbx_ExtraHelperActive"] == "on";
            model.ExtraHelperUseLanguageValue = Request.Form["cbx_ExtraHelperUseLanguage"] == "on";
            model.ExtraHelperUseModuleValue = Request.Form["cbx_ExtraHelperUsModule"] == "on";
            model.ExtraHelperUsePluginValue = Request.Form["cbx_ExtraHelperUsePlugin"] == "on";
            model.ExtraHelperUseReplacePartValue = Request.Form["cbx_ExtraHelperUseReplacePart"] == "on";
            model.ExtraHelperUseFetchValue = Request.Form["cbx_ExtraHelperUseFetch"] == "on";
            model.ExtraHelperUseItemValue = Request.Form["cbx_ExtraHelperUseItem"] == "on";
            model.ExtraHelperUseElanatValue = Request.Form["cbx_ExtraHelperUseElanat"] == "on";
            model.ExtraHelperCacheDurationValue = Request.Form["txt_ExtraHelperCacheDuration"];
            model.ExtraHelperCacheParametersValue = Request.Form["txt_ExtraHelperCacheParameters"];
            model.ExtraHelperSortIndexValue = Request.Form["txt_ExtraHelperSortIndex"];
            model.ExtraHelperPublicAccessShowValue = Request.Form["cbx_ExtraHelperPublicAccessShow"] == "on";

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ExtraHelperAccessShow$"))
                {
                    ListItem ExtraHelperAccessShow = new ListItem();

                    ExtraHelperAccessShow.Value = Request.Form[name];
                    ExtraHelperAccessShow.Selected = true;

                    model.ExtraHelperAccessShowListItem.Add(ExtraHelperAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddExtraHelper();
        }
    }
}