using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperXmlSitemapOption : System.Web.UI.Page
    {
        public ExtraHelperXmlSitemapOptionModel model = new ExtraHelperXmlSitemapOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveXmlSitemapOption"]))
                btn_SaveXmlSitemapOption_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveXmlSitemapOption_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.XmlSitemapCountValue = Request.Form["txt_XmlSitemapCount"];
            model.XmlSitemapCacheValue = Request.Form["txt_XmlSitemapCache"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveXmlSitemapOption();
        }
    }
}