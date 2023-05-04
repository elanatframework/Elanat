﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionAddHandheldLanguageVariantModel
    {
        public string AddHandheldLanguageVariantLanguage { get; set; }
        public string HandheldLanguageVariantLanguage { get; set; }

        public string HandheldLanguageInputAddValue { get; set; }

        public string HandheldLanguageVariantValue { get; set; }

        public string HandheldLanguageVariantAttribute { get; set; }

        public string HandheldLanguageVariantCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/language/");
            AddHandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("add_handheld_language_variant");
            HandheldLanguageVariantLanguage = aol.GetAddOnsLanguage("handheld_language_variant");


            // Set Current Value
            ListClass lc = new ListClass();

            // Set Language Name Item
            lc.FillLanguageNameListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/language/template/text_box.xml"));

            // Add Handheld Language Input For Add
            string HandheldLanguageInputTemplate = doc.SelectSingleNode("template_root/handheld_language_input_for_add").InnerText;
            string SumHandheldLanguageInputTemplate = "";
            string TmpHandheldLanguageInputTemplate = "";

            foreach (ListItem item in lc.LanguageNameListItem)
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
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_HandheldLanguageVariant", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/language/", "add_handheld_language_variant");

            HandheldLanguageVariantAttribute += vc.ImportantInputAttribute["txt_HandheldLanguageVariant"];

            HandheldLanguageVariantCssClass = HandheldLanguageVariantCssClass.AddHtmlClass(vc.ImportantInputClass["txt_HandheldLanguageVariant"]);
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

                //HandheldLanguageVariantCssClass = HandheldLanguageVariantCssClass.AddHtmlClass(vc.WarningFieldClass["txt_HandheldLanguageVariant"]);
            }
        }

        public void AddHandheldLanguageVariant()
        {
            List<string> LanguageGlobalNameList = ListClass.GetLanguageGlobalNameList();
            string LanguageVariant = HandheldLanguageVariantValue;

            foreach (string LanguageGlobalName in LanguageGlobalNameList)
            {
                string LanguageValue = HttpContext.Current.Request.Form["txt_HandheldLanguage_Add_" + LanguageGlobalName];

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