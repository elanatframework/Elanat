using CodeBehind;

namespace Elanat
{
    public partial class ActionEditHandheldLanguageVariantController : CodeBehindController
    {
        public ActionEditHandheldLanguageVariantModel model = new ActionEditHandheldLanguageVariantModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveHandheldLanguageVariant"]))
            {
                btn_SaveHandheldLanguageVariant_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_DeleteHandheldLanguageVariant"]))
            {
                btn_DeleteHandheldLanguageVariant_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowOtherHandheldCharacter"]))
            {
                btn_ShowOtherHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowAHandheldCharacter"]))
            {
                btn_ShowAHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowBHandheldCharacter"]))
            {
                btn_ShowBHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowCHandheldCharacter"]))
            {
                btn_ShowCHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowDHandheldCharacter"]))
            {
                btn_ShowDHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowEHandheldCharacter"]))
            {
                btn_ShowEHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowFHandheldCharacter"]))
            {
                btn_ShowFHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowGHandheldCharacter"]))
            {
                btn_ShowGHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowHHandheldCharacter"]))
            {
                btn_ShowHHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowIHandheldCharacter"]))
            {
                btn_ShowIHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowJHandheldCharacter"]))
            {
                btn_ShowJHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowKHandheldCharacter"]))
            {
                btn_ShowKHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowLHandheldCharacter"]))
            {
                btn_ShowLHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowMHandheldCharacter"]))
            {
                btn_ShowMHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowNHandheldCharacter"]))
            {
                btn_ShowNHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowOHandheldCharacter"]))
            {
                btn_ShowOHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowPHandheldCharacter"]))
            {
                btn_ShowPHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowQHandheldCharacter"]))
            {
                btn_ShowQHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowRHandheldCharacter"]))
            {
                btn_ShowRHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowSHandheldCharacter"]))
            {
                btn_ShowSHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowTHandheldCharacter"]))
            {
                btn_ShowTHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowUHandheldCharacter"]))
            {
                btn_ShowUHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowVHandheldCharacter"]))
            {
                btn_ShowVHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowWHandheldCharacter"]))
            {
                btn_ShowWHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowXHandheldCharacter"]))
            {
                btn_ShowXHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowYHandheldCharacter"]))
            {
                btn_ShowYHandheldCharacter_Click();
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_ShowZHandheldCharacter"]))
            {
                btn_ShowZHandheldCharacter_Click();
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveHandheldLanguageVariant_Click(HttpContext context)
        {
            model.HandheldLanguageVariantOptionListSelectedValue = context.Request.Form["lstx_HandheldLanguageVariant"];


            // Evaluate Field Check
            model.SaveHandheldLanguageEvaluateField(context.Request.Form);
            if (model.FindSaveHandheldLanguageEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.SaveHandheldLanguageEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.SaveHandheldLanguageVariant(context);

            View(model);
        }

        protected void btn_DeleteHandheldLanguageVariant_Click(HttpContext context)
        {
            model.HandheldLanguageVariantOptionListSelectedValue = context.Request.Form["lstx_HandheldLanguageVariant"];


            // Evaluate Field Check
            model.DeleteHandheldLanguageVariantEvaluateField(context.Request.Form);
            if (model.FindDeleteHandheldLanguageVariantEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.DeleteHandheldLanguageVariantEvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }

            model.DeleteHandheldLanguageVariant();

            View(model);
        }

        protected void btn_ShowOtherHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("_", "en");

            View(model);
        }

        protected void btn_ShowAHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("a", "en");

            View(model);
        }

        protected void btn_ShowBHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("b", "en");

            View(model);
        }

        protected void btn_ShowCHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("c", "en");

            View(model);
        }

        protected void btn_ShowDHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("d", "en");

            View(model);
        }

        protected void btn_ShowEHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("e", "en");

            View(model);
        }

        protected void btn_ShowFHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("f", "en");

            View(model);
        }

        protected void btn_ShowGHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("g", "en");

            View(model);
        }

        protected void btn_ShowHHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("h", "en");

            View(model);
        }

        protected void btn_ShowIHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("i", "en");

            View(model);
        }

        protected void btn_ShowJHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("j", "en");

            View(model);
        }

        protected void btn_ShowKHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("k", "en");

            View(model);
        }

        protected void btn_ShowLHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("l", "en");

            View(model);
        }

        protected void btn_ShowMHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("m", "en");

            View(model);
        }

        protected void btn_ShowNHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("n", "en");

            View(model);
        }

        protected void btn_ShowOHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("o", "en");

            View(model);
        }

        protected void btn_ShowPHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("p", "en");

            View(model);
        }

        protected void btn_ShowQHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("q", "en");

            View(model);
        }

        protected void btn_ShowRHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("r", "en");

            View(model);
        }

        protected void btn_ShowSHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("s", "en");

            View(model);
        }

        protected void btn_ShowTHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("t", "en");

            View(model);
        }

        protected void btn_ShowUHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("u", "en");

            View(model);
        }

        protected void btn_ShowVHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("v", "en");

            View(model);
        }

        protected void btn_ShowWHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("w", "en");

            View(model);
        }

        protected void btn_ShowXHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("x", "en");

            View(model);
        }

        protected void btn_ShowYHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("y", "en");

            View(model);
        }

        protected void btn_ShowZHandheldCharacter_Click()
        {
            model.SetHandheldLanguageNodeList("z", "en");

            View(model);
        }
    }
}