using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionAddHandheldLanguageVariant : System.Web.UI.Page
    {
        public ActionAddHandheldLanguageVariantModel model = new ActionAddHandheldLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddHandheldLanguageVariant"]))
                btn_AddHandheldLanguageVariant_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddHandheldLanguageVariant_Click(object sender, EventArgs e)
        {
            model.HandheldLanguageVariantValue = Request.Form["txt_HandheldLanguageVariant"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddHandheldLanguageVariant();
        }
    }
}