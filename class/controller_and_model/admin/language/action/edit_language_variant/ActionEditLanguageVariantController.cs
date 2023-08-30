using CodeBehind;

namespace Elanat
{
    public partial class ActionEditLanguageVariantController : CodeBehindController
    {
        public ActionEditLanguageVariantModel model = new ActionEditLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveLanguageVariant"]))
            {
                btn_SaveLanguageVariant_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_DeleteLanguageVariant"]))
            {
                btn_DeleteLanguageVariant_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowOtherCharacter"]))
            {
                btn_ShowOtherCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowACharacter"]))
            {
                btn_ShowACharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowBCharacter"]))
            {
                btn_ShowBCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowCCharacter"]))
            {
                btn_ShowCCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowDCharacter"]))
            {
                btn_ShowDCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowECharacter"]))
            {
                btn_ShowECharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowFCharacter"]))
            {
                btn_ShowFCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowGCharacter"]))
            {
                btn_ShowGCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowHCharacter"]))
            {
                btn_ShowHCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowICharacter"]))
            {
                btn_ShowICharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowJCharacter"]))
            {
                btn_ShowJCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowKCharacter"]))
            {
                btn_ShowKCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowLCharacter"]))
            {
                btn_ShowLCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowMCharacter"]))
            {
                btn_ShowMCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowNCharacter"]))
            {
                btn_ShowNCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowOCharacter"]))
            {
                btn_ShowOCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowPCharacter"]))
            {
                btn_ShowPCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowQCharacter"]))
            {
                btn_ShowQCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowRCharacter"]))
            {
                btn_ShowRCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowSCharacter"]))
            {
                btn_ShowSCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowTCharacter"]))
            {
                btn_ShowTCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowUCharacter"]))
            {
                btn_ShowUCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowVCharacter"]))
            {
                btn_ShowVCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowWCharacter"]))
            {
                btn_ShowWCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowXCharacter"]))
            {
                btn_ShowXCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowYCharacter"]))
            {
                btn_ShowYCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowZCharacter"]))
            {
                btn_ShowZCharacter_Click();
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveLanguageVariant_Click(HttpContext context)
        {
            model.LanguageVariantOptionListSelectedValue = context.Request.Form["lstx_LanguageVariant"];


            // Evaluate Field Check
            model.SaveLanguageEvaluateField(context.Request.Form);
            if (model.FindSaveLanguageEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SaveLanguageEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.SaveLanguageVariant(context);

            View(model);
        }

        protected void btn_DeleteLanguageVariant_Click(HttpContext context)
        {
            model.LanguageVariantOptionListSelectedValue = context.Request.Form["lstx_LanguageVariant"];


            // Evaluate Field Check
            model.DeleteLanguageVariantEvaluateField(context.Request.Form);
            if (model.FindDeleteLanguageVariantEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DeleteLanguageVariantEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.DeleteLanguageVariant();

            View(model);
        }

        protected void btn_ShowOtherCharacter_Click()
        {
            model.SetLanguageNodeList("_", "en");

            View(model);
        }

        protected void btn_ShowACharacter_Click()
        {
            model.SetLanguageNodeList("a", "en");

            View(model);
        }

        protected void btn_ShowBCharacter_Click()
        {
            model.SetLanguageNodeList("b", "en");

            View(model);
        }

        protected void btn_ShowCCharacter_Click()
        {
            model.SetLanguageNodeList("c", "en");

            View(model);
        }

        protected void btn_ShowDCharacter_Click()
        {
            model.SetLanguageNodeList("d", "en");

            View(model);
        }

        protected void btn_ShowECharacter_Click()
        {
            model.SetLanguageNodeList("e", "en");

            View(model);
        }

        protected void btn_ShowFCharacter_Click()
        {
            model.SetLanguageNodeList("f", "en");

            View(model);
        }

        protected void btn_ShowGCharacter_Click()
        {
            model.SetLanguageNodeList("g", "en");

            View(model);
        }

        protected void btn_ShowHCharacter_Click()
        {
            model.SetLanguageNodeList("h", "en");

            View(model);
        }

        protected void btn_ShowICharacter_Click()
        {
            model.SetLanguageNodeList("i", "en");

            View(model);
        }

        protected void btn_ShowJCharacter_Click()
        {
            model.SetLanguageNodeList("j", "en");

            View(model);
        }

        protected void btn_ShowKCharacter_Click()
        {
            model.SetLanguageNodeList("k", "en");

            View(model);
        }

        protected void btn_ShowLCharacter_Click()
        {
            model.SetLanguageNodeList("l", "en");

            View(model);
        }

        protected void btn_ShowMCharacter_Click()
        {
            model.SetLanguageNodeList("m", "en");

            View(model);
        }

        protected void btn_ShowNCharacter_Click()
        {
            model.SetLanguageNodeList("n", "en");

            View(model);
        }

        protected void btn_ShowOCharacter_Click()
        {
            model.SetLanguageNodeList("o", "en");

            View(model);
        }

        protected void btn_ShowPCharacter_Click()
        {
            model.SetLanguageNodeList("p", "en");

            View(model);
        }

        protected void btn_ShowQCharacter_Click()
        {
            model.SetLanguageNodeList("q", "en");

            View(model);
        }

        protected void btn_ShowRCharacter_Click()
        {
            model.SetLanguageNodeList("r", "en");

            View(model);
        }

        protected void btn_ShowSCharacter_Click()
        {
            model.SetLanguageNodeList("s", "en");

            View(model);
        }

        protected void btn_ShowTCharacter_Click()
        {
            model.SetLanguageNodeList("t", "en");

            View(model);
        }

        protected void btn_ShowUCharacter_Click()
        {
            model.SetLanguageNodeList("u", "en");

            View(model);
        }

        protected void btn_ShowVCharacter_Click()
        {
            model.SetLanguageNodeList("v", "en");

            View(model);
        }

        protected void btn_ShowWCharacter_Click()
        {
            model.SetLanguageNodeList("w", "en");

            View(model);
        }

        protected void btn_ShowXCharacter_Click()
        {
            model.SetLanguageNodeList("x", "en");

            View(model);
        }

        protected void btn_ShowYCharacter_Click()
        {
            model.SetLanguageNodeList("y", "en");

            View(model);
        }

        protected void btn_ShowZCharacter_Click()
        {
            model.SetLanguageNodeList("z", "en");

            View(model);
        }
    }
}