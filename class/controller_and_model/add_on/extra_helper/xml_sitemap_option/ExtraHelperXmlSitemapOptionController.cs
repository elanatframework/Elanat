using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperXmlSitemapOptionController : CodeBehindController
    {
        public ExtraHelperXmlSitemapOptionModel model = new ExtraHelperXmlSitemapOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveXmlSitemapOption"]))
            {
                btn_SaveXmlSitemapOption_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveXmlSitemapOption_Click(HttpContext context)
        {
            model.IsFirstStart = false;

            model.XmlSitemapCountValue = context.Request.Form["txt_XmlSitemapCount"];
            model.XmlSitemapCacheValue = context.Request.Form["txt_XmlSitemapCache"];


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveXmlSitemapOption();

            View(model);
        }
    }
}