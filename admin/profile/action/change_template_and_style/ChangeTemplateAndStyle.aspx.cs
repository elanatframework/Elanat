using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace elanat
{
    public partial class ActionChangeTemplateAndStyle : System.Web.UI.Page
    {
        public ActionChangeTemplateAndStyleModel model = new ActionChangeTemplateAndStyleModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeTemplateAndStyle"]))
                btn_ChangeTemplateAndStyle_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_ChangeTemplateAndStyle_Click(object sender, EventArgs e)
        {
            model.SiteStyleOptionListSelectedValue = Request.Form["ddlst_UserSiteStyle"];
            model.SiteTemplateOptionListSelectedValue = Request.Form["ddlst_UserSiteTemplate"];
            model.AdminStyleOptionListSelectedValue = Request.Form["ddlst_UserAdminStyle"];
            model.AdminTemplateOptionListSelectedValue = Request.Form["ddlst_UserAdminTemplate"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.ChangeTemplateAndStyle();

            model.SuccessView();
        }
    }
}