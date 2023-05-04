using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperRssOption : System.Web.UI.Page
    {
        public ExtraHelperRssOptionModel model = new ExtraHelperRssOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveRssOption"]))
                btn_SaveRssOption_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveRssOption_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.FeedCountValue = Request.Form["txt_FeedCount"];
            model.ContentTextLengthValue = Request.Form["txt_ContentTextLength"];
            model.RssCacheValue = Request.Form["txt_RssCache"];
            model.UseRemoveHtmlTagValue = Request.Form["cbx_UseRemoveHtmlTag"] == "on";
            model.ActiveAuthorFeedValue = Request.Form["cbx_ActiveAuthorFeed"] == "on";
            model.ActiveCategoryFeedValue = Request.Form["cbx_ActiveCategoryFeed"] == "on";
            model.ActiveContentTypeFeedValue = Request.Form["cbx_ActiveContentTypeFeed"] == "on";


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveRssOption();
        }
    }
}