using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ExtraHelperSearchOptionModel : CodeBehindModel
    {
        public string SearchOptionLanguage { get; set; }
        public string ActiveTitleTextSearchLanguage { get; set; }
        public string ActiveDateSearchLanguage { get; set; }
        public string ActiveCategorySearchLanguage { get; set; }
        public string MinimumSearchCharacterLanguage { get; set; }
        public string SearchedPerPageLanguage { get; set; }
        public string NextSearchDelayLanguage { get; set; }
        public string SaveSearchedTextToFootPrintLanguage { get; set; }
        public string SaveSearchOptionLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;

        public bool ActiveTitleTextSearchValue { get; set; } = false;
        public bool ActiveDateSearchValue { get; set; } = false;
        public bool ActiveCategorySearchValue { get; set; } = false;
        public bool SaveSearchedTextToFootPrintValue { get; set; } = false;

        public string MinimumSearchCharacterValue { get; set; }
        public string SearchedPerPageValue { get; set; }
        public string NextSearchDelayValue { get; set; }

        public string MinimumSearchCharacterAttribute { get; set; }
        public string SearchedPerPageAttribute { get; set; }
        public string NextSearchDelayAttribute { get; set; }

        public string MinimumSearchCharacterCssClass { get; set; }
        public string SearchedPerPageCssClass { get; set; }
        public string NextSearchDelayhCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/search_option/");
            SearchOptionLanguage = aol.GetAddOnsLanguage("search_option");
            MinimumSearchCharacterLanguage = aol.GetAddOnsLanguage("minimum_search_character");
            SearchedPerPageLanguage = aol.GetAddOnsLanguage("searched_per_page");
            NextSearchDelayLanguage = aol.GetAddOnsLanguage("next_search_delay");
            ActiveCategorySearchLanguage = aol.GetAddOnsLanguage("active_category_search");
            ActiveDateSearchLanguage = aol.GetAddOnsLanguage("active_date_search");
            ActiveTitleTextSearchLanguage = aol.GetAddOnsLanguage("active_title_text_search");
            SaveSearchedTextToFootPrintLanguage = aol.GetAddOnsLanguage("save_searched_text_to_foot_print");
            SaveSearchOptionLanguage = aol.GetAddOnsLanguage("save_search_option");


            // Set Current Value
            if (IsFirstStart)
            {
                XmlDocument SearchOptionDocument = new XmlDocument();
                SearchOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/search_option/option/search_option.xml"));

                XmlNode node = SearchOptionDocument.SelectSingleNode("search_option_root");

                NextSearchDelayValue = node["next_search_delay"].Attributes["value"].Value;
                MinimumSearchCharacterValue = node["minimum_search_character"].Attributes["value"].Value;
                SearchedPerPageValue = node["searched_per_page"].Attributes["value"].Value;
                ActiveCategorySearchValue = (node["category_search"].Attributes["active"].Value == "true");
                ActiveDateSearchValue = (node["date_search"].Attributes["active"].Value == "true");
                ActiveTitleTextSearchValue = (node["title_text_search"].Attributes["active"].Value == "true");
                SaveSearchedTextToFootPrintValue = (node["save_searched_text_to_foot_print"].Attributes["active"].Value == "true");
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_MinimumSearchCharacter", "");
            InputRequest.Add("txt_SearchedPerPage", "");
            InputRequest.Add("txt_NextSearchDelay", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "add_on/extra_helper/search_option/");

            MinimumSearchCharacterAttribute += vc.ImportantInputAttribute.GetValue("txt_MinimumSearchCharacter");
            SearchedPerPageAttribute += vc.ImportantInputAttribute.GetValue("txt_SearchedPerPage");
            NextSearchDelayAttribute += vc.ImportantInputAttribute.GetValue("txt_NextSearchDelay");

            MinimumSearchCharacterCssClass = MinimumSearchCharacterCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_MinimumSearchCharacter"));
            SearchedPerPageCssClass = SearchedPerPageCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_SearchedPerPage"));
            NextSearchDelayhCssClass = NextSearchDelayhCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_NextSearchDelay"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.SitePath + "add_on/extra_helper/search_option/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveSearchOption()
        {
            XmlDocument SearchOptionDocument = new XmlDocument();
            SearchOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/search_option/option/search_option.xml"));

            SearchOptionDocument.SelectSingleNode("search_option_root/minimum_search_character").Attributes["value"].Value = MinimumSearchCharacterValue;
            SearchOptionDocument.SelectSingleNode("search_option_root/searched_per_page").Attributes["value"].Value = SearchedPerPageValue;
            SearchOptionDocument.SelectSingleNode("search_option_root/next_search_delay").Attributes["value"].Value = NextSearchDelayValue;

            SearchOptionDocument.SelectSingleNode("search_option_root/category_search").Attributes["active"].Value = ActiveCategorySearchValue.BooleanToTrueFalse();
            SearchOptionDocument.SelectSingleNode("search_option_root/date_search").Attributes["active"].Value = ActiveDateSearchValue.BooleanToTrueFalse();
            SearchOptionDocument.SelectSingleNode("search_option_root/title_text_search").Attributes["active"].Value = ActiveTitleTextSearchValue.BooleanToTrueFalse();
            SearchOptionDocument.SelectSingleNode("search_option_root/save_searched_text_to_foot_print").Attributes["active"].Value = SaveSearchedTextToFootPrintValue.BooleanToTrueFalse();

            SearchOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/search_option/option/search_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_search_option", "_");


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("search_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/extra_helper/search_option/"), "success");
        }
    }
}