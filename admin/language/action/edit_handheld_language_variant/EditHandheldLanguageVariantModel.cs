using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionEditHandheldLanguageVariantModel
    {
        public string EditHandheldLanguageVariantLanguage { get; set; }
        public string HandheldAlphabetButtonLanguage { get; set; }
        public string DeleteHandheldLanguageVariantLanguage { get; set; }
        public string SaveHandheldLanguageVariantLanguage { get; set; }

        public string HandheldLanguageInputEditValue { get; set; }

        public string HandheldLanguageVariantOptionListValue { get; set; }
        public string HandheldLanguageVariantOptionListSelectedValue { get; set; }
        public string HandheldLanguageVariantCountValue { get; set; }

        public List<string> SaveHandheldLanguageEvaluateErrorList;
        public List<string> DeleteHandheldLanguageVariantEvaluateErrorList;
        public bool FindSaveHandheldLanguageEvaluateError = false;
        public bool FindDeleteHandheldLanguageVariantEvaluateError = false;

        public void SetValue()
        {            
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            EditHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("edit_handheld_language_variant");
            HandheldAlphabetButtonLanguage = aol.GetAddOnsLanguage("handheld_alphabet_button");
            DeleteHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("delete_handheld_language_variant");
            SaveHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("save_handheld_language_variant");
        }

        public void SaveHandheldLanguageEvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_handheld_language_variant", StaticObject.AdminPath + "/language/");

            SaveHandheldLanguageEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSaveHandheldLanguageEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //HandheldLanguageVariantCssClass = HandheldLanguageVariantCssClass.AddHtmlClass(vc.WarningFieldClass["lstx_HandheldLanguageVariant"]);
            }
        }

        public void DeleteHandheldLanguageVariantEvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_handheld_language_variant", StaticObject.AdminPath + "/language/");

            DeleteHandheldLanguageVariantEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindDeleteHandheldLanguageVariantEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //HandheldLanguageVariantCssClass = HandheldLanguageVariantCssClass.AddHtmlClass(vc.WarningFieldClass["lstx_HandheldLanguageVariant"]);
            }
        }

        public void SaveHandheldLanguageVariant()
        {
            List<string> LanguageGlobalNameList = ListClass.GetLanguageGlobalNameList();
            string LanguageVariant = HandheldLanguageVariantOptionListSelectedValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = HttpContext.Current.Request.Form["txt_HandheldLanguage_Edit_" + LanguageGlobalName];

                Language.EditHandheldLanguageVariant(LanguageVariant, LanguageValue, LanguageGlobalName);
            }


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_handheld_language_variant", LanguageVariant);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("handheld_language_variant_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success");
        }

        public void DeleteHandheldLanguageVariant()
        {
            List<string> LanguageGlobalNameList = ListClass.GetLanguageGlobalNameList();
            string LanguageVariant = HandheldLanguageVariantOptionListSelectedValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
                Language.DeleteHandheldLanguageVariant(LanguageVariant, LanguageGlobalName);


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_handheld_language_variant", LanguageVariant);


            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddLocalMessage(Language.GetAddOnsLanguage("handheld_language_variant_was_delete", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success");
            rf.AddReturnFunction("el_DeleteHandheldLanguageListBox()");
            rf.RedirectToResponseFormPage();
        }

        public void SetHandheldLanguageNodeList(string HandheldLanguageCharacter, string GlobalLanguage)
        {
            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddPageLoad(StaticObject.AdminPath + "/language/action/edit_handheld_language_variant/action/SetHandheldLanguageVariant.aspx?handheld_language_character=" + HandheldLanguageCharacter, "div_HandheldLanguageVariantList");
            rf.RedirectToResponseFormPage();
        }
    }
}