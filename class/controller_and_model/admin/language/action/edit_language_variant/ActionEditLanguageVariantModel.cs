using CodeBehind;

namespace Elanat
{
    public partial class ActionEditLanguageVariantModel : CodeBehindModel
    {
        public string EditLanguageVariantLanguage { get; set; }
        public string AlphabetButtonLanguage { get; set; }
        public string DeleteLanguageVariantLanguage { get; set; }
        public string SaveLanguageVariantLanguage { get; set; }

        public string LanguageInputEditValue { get; set; }

        public string LanguageVariantOptionListValue { get; set; }
        public string LanguageVariantOptionListSelectedValue { get; set; }
        public string LanguageVariantCountValue { get; set; }

        public List<string> SaveLanguageEvaluateErrorList;
        public List<string> DeleteLanguageVariantEvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindSaveLanguageEvaluateError = false;
        public bool FindDeleteLanguageVariantEvaluateError = false;

        public void SetValue()
        {            
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            EditLanguageVariantLanguage = aol.GetAddOnsLanguage("edit_language_variant");
            AlphabetButtonLanguage = aol.GetAddOnsLanguage("alphabet_button");
            DeleteLanguageVariantLanguage = aol.GetAddOnsLanguage("delete_language_variant");
            SaveLanguageVariantLanguage = aol.GetAddOnsLanguage("save_language_variant");
        }

        public void SaveLanguageEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_language_variant", StaticObject.AdminPath + "/language/");

            SaveLanguageEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindSaveLanguageEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void DeleteLanguageVariantEvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_language_variant", StaticObject.AdminPath + "/language/");

            DeleteLanguageVariantEvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindDeleteLanguageVariantEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveLanguageVariant(HttpContext context)
        {
            List<string> LanguageGlobalNameList = ListClass.LanguageList.GetLanguageGlobalNameList();
            string LanguageVariant = LanguageVariantOptionListSelectedValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = context.Request.Form["txt_Language_Edit_" + LanguageGlobalName];

                Language.EditLanguageVariant(LanguageVariant, LanguageValue, LanguageGlobalName);
            }


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_language_variant", LanguageVariant);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("language_variant_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success");
        }

        public void DeleteLanguageVariant()
        {
            List<string> LanguageGlobalNameList = ListClass.LanguageList.GetLanguageGlobalNameList();
            string LanguageVariant = LanguageVariantOptionListSelectedValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
                Language.DeleteLanguageVariant(LanguageVariant, LanguageGlobalName);


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("delete_language_variant", LanguageVariant);


            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddLocalMessage(Language.GetAddOnsLanguage("language_variant_was_delete", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success");
            rf.AddReturnFunction("el_DeleteLanguageListBox()");
            rf.RedirectToResponseFormPage();
        }

        public void SetLanguageNodeList(string LanguageCharacter, string GlobalLanguage)
        {
            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddPageLoad(StaticObject.AdminPath + "/language/action/edit_language_variant/action/SetLanguageVariant.aspx?language_character=" + LanguageCharacter, "div_LanguageVariantList");
            rf.RedirectToResponseFormPage();
        }
    }
}