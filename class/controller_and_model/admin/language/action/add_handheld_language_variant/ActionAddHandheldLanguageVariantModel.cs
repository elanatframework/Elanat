using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionAddHandheldLanguageVariantModel : CodeBehindModel
    {
        public string AddHandheldLanguageVariantLanguage { get; set; }
        public string HandheldLanguageVariantLanguage { get; set; }

        public string HandheldLanguageInputAddValue { get; set; }

        public string HandheldLanguageVariantValue { get; set; }

        public string HandheldLanguageVariantAttribute { get; set; }

        public string HandheldLanguageVariantCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            AddHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("add_handheld_language_variant");
            HandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("handheld_language_variant");


            // Set Current Value
            ListClass.LanguageList lcl = new ListClass.LanguageList();

            // Set Language Name Item
            lcl.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            // Add Handheld Language Input For Add
            string HandheldLanguageInputTemplate = doc.SelectSingleNode("template_root/handheld_language_input_for_add").InnerText;
            string SumHandheldLanguageInputTemplate = "";
            string TmpHandheldLanguageInputTemplate = "";

            foreach (ListItem item in lcl.LanguageNameListItem)
            {
                TmpHandheldLanguageInputTemplate = HandheldLanguageInputTemplate;
                TmpHandheldLanguageInputTemplate = TmpHandheldLanguageInputTemplate.Replace("$_asp language_global_name;", item.Value);
                TmpHandheldLanguageInputTemplate = TmpHandheldLanguageInputTemplate.Replace("$_asp language_name;", item.Text);

                SumHandheldLanguageInputTemplate += TmpHandheldLanguageInputTemplate;
            }
            HandheldLanguageInputAddValue = SumHandheldLanguageInputTemplate;
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_HandheldLanguageVariant", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "add_handheld_language_variant");

            HandheldLanguageVariantAttribute += vc.ImportantInputAttribute.GetValue("txt_HandheldLanguageVariant");

            HandheldLanguageVariantCssClass = HandheldLanguageVariantCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_HandheldLanguageVariant"));
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

        public void AddHandheldLanguageVariant(HttpContext context)
        {
            List<string> LanguageGlobalNameList = ListClass.LanguageList.GetLanguageGlobalNameList();
            string LanguageVariant = HandheldLanguageVariantValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = context.Request.Form["txt_HandheldLanguage_Add_" + LanguageGlobalName];

                Language.AddHandheldLanguageVariant(LanguageVariant, LanguageValue, LanguageGlobalName);
            }


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_handheld_language_variant", LanguageVariant);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("handheld_language_variant_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/"), "success");
        }
    }
}