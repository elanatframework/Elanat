using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperSearchOption : System.Web.UI.Page
    {
        public ExtraHelperSearchOptionModel model = new ExtraHelperSearchOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveSearchOption"]))
                btn_SaveSearchOption_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveSearchOption_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.MinimumSearchCharacterValue = Request.Form["txt_MinimumSearchCharacter"];
            model.SearchedPerPageValue = Request.Form["txt_SearchedPerPage"];
            model.NextSearchDelayValue = Request.Form["txt_NextSearchDelay"];
            model.ActiveTitleTextSearchValue = Request.Form["cbx_ActiveTitleTextSearch"] == "on";
            model.ActiveDateSearchValue = Request.Form["cbx_ActiveDateSearch"] == "on";
            model.ActiveCategorySearchValue = Request.Form["cbx_ActiveCategorySearch"] == "on";
            model.SaveSearchedTextToFootPrintValue = Request.Form["cbx_SaveSearchedTextToFootPrint"] == "on";


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveSearchOption();
        }
    }
}