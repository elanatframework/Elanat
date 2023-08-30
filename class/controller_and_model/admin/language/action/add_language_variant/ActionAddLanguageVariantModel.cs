using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionAddLanguageVariantModel : CodeBehindModel
    {
        public string AddLanguageVariantLanguage { get; set; }
        public string LanguageVariantLanguage { get; set; }

        public string LanguageInputAddValue { get; set; }

        public string LanguageVariantValue { get; set; }

        public string LanguageVariantAttribute { get; set; }

        public string LanguageVariantCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            AddLanguageVariantLanguage = aol.GetAddOnsLanguage("add_language_variant");
            LanguageVariantLanguage = aol.GetAddOnsLanguage("language_variant");


            // Set Current Value
            ListClass.LanguageList lcl = new ListClass.LanguageList();

            // Set Language Name Item
            lcl.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            // Add  Language Input For Add
            string LanguageInputTemplate = doc.SelectSingleNode("template_root/language_input_for_add").InnerText;
            string SumLanguageInputTemplate = "";
            string TmpLanguageInputTemplate = "";

            foreach (ListItem item in lcl.LanguageNameListItem)
            {
                TmpLanguageInputTemplate = LanguageInputTemplate;
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_global_name;", item.Value);
                TmpLanguageInputTemplate = TmpLanguageInputTemplate.Replace("$_asp language_name;", item.Text);

                SumLanguageInputTemplate += TmpLanguageInputTemplate;
            }
            LanguageInputAddValue = SumLanguageInputTemplate;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_LanguageVariant", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "add_handheld_language_variant");

            LanguageVariantAttribute += vc.ImportantInputAttribute.GetValue("txt_LanguageVariant");

            LanguageVariantCssClass = LanguageVariantCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LanguageVariant"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "add_handheld_language_variant", StaticObject.AdminPath + "/language/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void AddLanguageVariant(HttpContext context)
        {
            List<string> LanguageGlobalNameList = ListClass.LanguageList.GetLanguageGlobalNameList();
            string LanguageVariant = LanguageVariantValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = context.Request.Form["txt_Language_Add_" + LanguageGlobalName];

                Language.AddLanguageVariant(LanguageVariant, LanguageValue, LanguageGlobalName);
            }


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_language_variant", LanguageVariant);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("language_variant_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success");
        }
    }
}