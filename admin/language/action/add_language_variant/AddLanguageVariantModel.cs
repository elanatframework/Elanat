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
    public class ActionAddLanguageVariantModel
    {
        public string AddLanguageVariantLanguage { get; set; }
        public string LanguageVariantLanguage { get; set; }

        public string LanguageInputAddValue { get; set; }

        public string LanguageVariantValue { get; set; }

        public string LanguageVariantAttribute { get; set; }

        public string LanguageVariantCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            AddLanguageVariantLanguage = aol.GetAddOnsLanguage("add_language_variant");
            LanguageVariantLanguage = aol.GetAddOnsLanguage("language_variant");


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Language Name Item
            lc.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            // Add  Language Input For Add
            string LanguageInputTemplate = doc.SelectSingleNode("template_root/language_input_for_add").InnerText;
            string SumLanguageInputTemplate = "";
            string TmpLanguageInputTemplate = "";

            foreach (ListItem item in lc.LanguageNameListItem)
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
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_LanguageVariant", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "add_handheld_language_variant");

            LanguageVariantAttribute += vc.ImportantInputAttribute["txt_LanguageVariant"];

            LanguageVariantCssClass = LanguageVariantCssClass.AddHtmlClass(vc.ImportantInputClass["txt_LanguageVariant"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "add_handheld_language_variant", StaticObject.AdminPath + "/language/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //LanguageVariantCssClass = LanguageVariantCssClass.AddHtmlClass(vc.WarningFieldClass["txt_LanguageVariant"]);
            }
        }

        public void AddLanguageVariant()
        {
            List<string> LanguageGlobalNameList = ListClass.GetLanguageGlobalNameList();
            string LanguageVariant = LanguageVariantValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = HttpContext.Current.Request.Form["txt_Language_Add_" + LanguageGlobalName];

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