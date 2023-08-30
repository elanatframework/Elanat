using CodeBehind;

namespace Elanat
{
    public partial class ActionEditHandheldLanguageVariantModel : CodeBehindModel
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
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
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

        public void SaveHandheldLanguageEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_handheld_language_variant", StaticObject.AdminPath + "/language/");

            SaveHandheldLanguageEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSaveHandheldLanguageEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void DeleteHandheldLanguageVariantEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_handheld_language_variant", StaticObject.AdminPath + "/language/");

            DeleteHandheldLanguageVariantEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindDeleteHandheldLanguageVariantEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveHandheldLanguageVariant(HttpContext context)
        {
            List<string> LanguageGlobalNameList = ListClass.LanguageList.GetLanguageGlobalNameList();
            string LanguageVariant = HandheldLanguageVariantOptionListSelectedValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = context.Request.Form["txt_HandheldLanguage_Edit_" + LanguageGlobalName];

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
            List<string> LanguageGlobalNameList = ListClass.LanguageList.GetLanguageGlobalNameList();
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