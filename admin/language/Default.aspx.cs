using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminLanguage : System.Web.UI.Page
    {
        public AdminLanguageModel model = new AdminLanguageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddLanguage"]))
                btn_AddLanguage_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddLanguage_Click(object sender, EventArgs e)
        {
            model.LanguagePathUploadValue = Request.Files["upd_LanguagePath"];
            model.UseLanguagePathValue = Request.Form["cbx_UseLanguagePath"] == "on";
            model.LanguagePathTextValue = Request.Form["txt_LanguagePath"];
            model.LanguageActiveValue = Request.Form["cbx_LanguageActive"] == "on";
            model.ShowLinkInSiteValue = Request.Form["cbx_ShowLinkInSite"] == "on";
            model.LanguageDefaultSiteOptionListSelectedValue = Request.Form["ddlst_LanguageDefaultSite"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddLanguagePackage();
        }
    }
}