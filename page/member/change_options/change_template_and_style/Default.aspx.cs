using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class MemberChangeTemplateAndStyle : System.Web.UI.Page
    {
        public MemberChangeTemplateAndStyleModel model = new MemberChangeTemplateAndStyleModel();

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
            model.IsFirstStart = false;

            model.SiteStyleOptionListSelectedValue = Request.Form["ddlst_UserSiteStyle"];
            model.SiteTemplateOptionListSelectedValue = Request.Form["ddlst_UserSiteTemplate"];
            model.AdminStyleOptionListSelectedValue = Request.Form["ddlst_UserAdminStyle"];
            model.AdminTemplateOptionListSelectedValue = Request.Form["ddlst_UserAdminTemplate"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.ChangeTemplateAndStyle();

            model.SuccessView();
        }
    }
}