using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditHandheldLanguageVariant : System.Web.UI.Page
    {
        public ActionEditHandheldLanguageVariantModel model = new ActionEditHandheldLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveHandheldLanguageVariant"]))
                btn_SaveHandheldLanguageVariant_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_DeleteHandheldLanguageVariant"]))
                btn_DeleteHandheldLanguageVariant_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowOtherHandheldCharacter"]))
                btn_ShowOtherHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowAHandheldCharacter"]))
                btn_ShowAHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowBHandheldCharacter"]))
                btn_ShowBHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowCHandheldCharacter"]))
                btn_ShowCHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowDHandheldCharacter"]))
                btn_ShowDHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowEHandheldCharacter"]))
                btn_ShowEHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowFHandheldCharacter"]))
                btn_ShowFHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowGHandheldCharacter"]))
                btn_ShowGHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowHHandheldCharacter"]))
                btn_ShowHHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowIHandheldCharacter"]))
                btn_ShowIHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowJHandheldCharacter"]))
                btn_ShowJHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowKHandheldCharacter"]))
                btn_ShowKHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowLHandheldCharacter"]))
                btn_ShowLHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowMHandheldCharacter"]))
                btn_ShowMHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowNHandheldCharacter"]))
                btn_ShowNHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowOHandheldCharacter"]))
                btn_ShowOHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowPHandheldCharacter"]))
                btn_ShowPHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowQHandheldCharacter"]))
                btn_ShowQHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowRHandheldCharacter"]))
                btn_ShowRHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowSHandheldCharacter"]))
                btn_ShowSHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowTHandheldCharacter"]))
                btn_ShowTHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowUHandheldCharacter"]))
                btn_ShowUHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowVHandheldCharacter"]))
                btn_ShowVHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowWHandheldCharacter"]))
                btn_ShowWHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowXHandheldCharacter"]))
                btn_ShowXHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowYHandheldCharacter"]))
                btn_ShowYHandheldCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowZHandheldCharacter"]))
                btn_ShowZHandheldCharacter_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveHandheldLanguageVariant_Click(object sender, EventArgs e)
        {
            model.HandheldLanguageVariantOptionListSelectedValue = Request.Form["lstx_HandheldLanguageVariant"];


            // Evaluate Field Check
            model.SaveHandheldLanguageEvaluateField(Request.Form);
            if (model.FindSaveHandheldLanguageEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SaveHandheldLanguageEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.SaveHandheldLanguageVariant();
        }

        protected void btn_DeleteHandheldLanguageVariant_Click(object sender, EventArgs e)
        {
            model.HandheldLanguageVariantOptionListSelectedValue = Request.Form["lstx_HandheldLanguageVariant"];


            // Evaluate Field Check
            model.DeleteHandheldLanguageVariantEvaluateField(Request.Form);
            if (model.FindDeleteHandheldLanguageVariantEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DeleteHandheldLanguageVariantEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.DeleteHandheldLanguageVariant();
        }

        protected void btn_ShowOtherHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("_", "en");
        }

        protected void btn_ShowAHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("a", "en");
        }

        protected void btn_ShowBHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("b", "en");
        }

        protected void btn_ShowCHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("c", "en");
        }

        protected void btn_ShowDHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("d", "en");
        }

        protected void btn_ShowEHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("e", "en");
        }

        protected void btn_ShowFHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("f", "en");
        }

        protected void btn_ShowGHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("g", "en");
        }

        protected void btn_ShowHHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("h", "en");
        }

        protected void btn_ShowIHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("i", "en");
        }

        protected void btn_ShowJHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("j", "en");
        }

        protected void btn_ShowKHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("k", "en");
        }

        protected void btn_ShowLHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("l", "en");
        }

        protected void btn_ShowMHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("m", "en");
        }

        protected void btn_ShowNHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("n", "en");
        }

        protected void btn_ShowOHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("o", "en");
        }

        protected void btn_ShowPHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("p", "en");
        }

        protected void btn_ShowQHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("q", "en");
        }

        protected void btn_ShowRHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("r", "en");
        }

        protected void btn_ShowSHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("s", "en");
        }

        protected void btn_ShowTHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("t", "en");
        }

        protected void btn_ShowUHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("u", "en");
        }

        protected void btn_ShowVHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("v", "en");
        }

        protected void btn_ShowWHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("w", "en");
        }

        protected void btn_ShowXHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("x", "en");
        }

        protected void btn_ShowYHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("y", "en");
        }

        protected void btn_ShowZHandheldCharacter_Click(object sender, EventArgs e)
        {
            model.SetHandheldLanguageNodeList("z", "en");
        }
    }
}