using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditLanguageVariant : System.Web.UI.Page
    {
        public ActionEditLanguageVariantModel model = new ActionEditLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveLanguageVariant"]))
                btn_SaveLanguageVariant_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_DeleteLanguageVariant"]))
                btn_DeleteLanguageVariant_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowOtherCharacter"]))
                btn_ShowOtherCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowACharacter"]))
                btn_ShowACharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowBCharacter"]))
                btn_ShowBCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowCCharacter"]))
                btn_ShowCCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowDCharacter"]))
                btn_ShowDCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowECharacter"]))
                btn_ShowECharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowFCharacter"]))
                btn_ShowFCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowGCharacter"]))
                btn_ShowGCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowHCharacter"]))
                btn_ShowHCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowICharacter"]))
                btn_ShowICharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowJCharacter"]))
                btn_ShowJCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowKCharacter"]))
                btn_ShowKCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowLCharacter"]))
                btn_ShowLCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowMCharacter"]))
                btn_ShowMCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowNCharacter"]))
                btn_ShowNCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowOCharacter"]))
                btn_ShowOCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowPCharacter"]))
                btn_ShowPCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowQCharacter"]))
                btn_ShowQCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowRCharacter"]))
                btn_ShowRCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowSCharacter"]))
                btn_ShowSCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowTCharacter"]))
                btn_ShowTCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowUCharacter"]))
                btn_ShowUCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowVCharacter"]))
                btn_ShowVCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowWCharacter"]))
                btn_ShowWCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowXCharacter"]))
                btn_ShowXCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowYCharacter"]))
                btn_ShowYCharacter_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_ShowZCharacter"]))
                btn_ShowZCharacter_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveLanguageVariant_Click(object sender, EventArgs e)
        {
            model.LanguageVariantOptionListSelectedValue = Request.Form["lstx_LanguageVariant"];


            // Evaluate Field Check
            model.SaveLanguageEvaluateField(Request.Form);
            if (model.FindSaveLanguageEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SaveLanguageEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.SaveLanguageVariant();
        }

        protected void btn_DeleteLanguageVariant_Click(object sender, EventArgs e)
        {
            model.LanguageVariantOptionListSelectedValue = Request.Form["lstx_LanguageVariant"];


            // Evaluate Field Check
            model.DeleteLanguageVariantEvaluateField(Request.Form);
            if (model.FindDeleteLanguageVariantEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DeleteLanguageVariantEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }

            model.DeleteLanguageVariant();
        }

        protected void btn_ShowOtherCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("_", "en");
        }

        protected void btn_ShowACharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("a", "en");
        }

        protected void btn_ShowBCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("b", "en");
        }

        protected void btn_ShowCCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("c", "en");
        }

        protected void btn_ShowDCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("d", "en");
        }

        protected void btn_ShowECharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("e", "en");
        }

        protected void btn_ShowFCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("f", "en");
        }

        protected void btn_ShowGCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("g", "en");
        }

        protected void btn_ShowHCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("h", "en");
        }

        protected void btn_ShowICharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("i", "en");
        }

        protected void btn_ShowJCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("j", "en");
        }

        protected void btn_ShowKCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("k", "en");
        }

        protected void btn_ShowLCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("l", "en");
        }

        protected void btn_ShowMCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("m", "en");
        }

        protected void btn_ShowNCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("n", "en");
        }

        protected void btn_ShowOCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("o", "en");
        }

        protected void btn_ShowPCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("p", "en");
        }

        protected void btn_ShowQCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("q", "en");
        }

        protected void btn_ShowRCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("r", "en");
        }

        protected void btn_ShowSCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("s", "en");
        }

        protected void btn_ShowTCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("t", "en");
        }

        protected void btn_ShowUCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("u", "en");
        }

        protected void btn_ShowVCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("v", "en");
        }

        protected void btn_ShowWCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("w", "en");
        }

        protected void btn_ShowXCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("x", "en");
        }

        protected void btn_ShowYCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("y", "en");
        }

        protected void btn_ShowZCharacter_Click(object sender, EventArgs e)
        {
            model.SetLanguageNodeList("z", "en");
        }
    }
}