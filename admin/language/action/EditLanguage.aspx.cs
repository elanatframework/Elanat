using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditLanguage : System.Web.UI.Page
    {
        public ActionEditLanguageModel model = new ActionEditLanguageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveLanguage"]))
                btn_SaveLanguage_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_LanguageId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["language_id"]))
                    return;

                if (!Request.QueryString["language_id"].ToString().IsNumber())
                    return;

                model.LanguageIdValue = Request.QueryString["language_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveLanguage_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.LanguageActiveValue = Request.Form["cbx_LanguageActive"] == "on";
            model.ShowLinkInSiteValue = Request.Form["cbx_ShowLinkInSite"] == "on";
            model.LanguageDefaultSiteOptionListSelectedValue = Request.Form["ddlst_LanguageDefaultSite"];
            model.LanguageIdValue = Request.Form["hdn_LanguageId"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveLanguage();

            model.SuccessView();
        }
    }
}