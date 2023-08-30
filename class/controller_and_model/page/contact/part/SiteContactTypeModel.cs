using CodeBehind;

namespace Elanat
{
    public partial class SiteContactTypeModel : CodeBehindModel
    {
        public string TypeLanguage { get; set; }

        public string TypeOptionListValue { get; set; }
        public string TypeOptionListSelectedValue { get; set; }

        public string TypeAttribute { get; set; }

        public string TypeCssClass { get; set; }

        public void SetValue()
        {
            // Set Language
            TypeLanguage = Language.GetAddOnsLanguage("type", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");


            // Set Type Item
            ListClass.Contact lcc = new ListClass.Contact();
            lcc.FillContactTypeListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            TypeOptionListValue += lcc.ContactTypeListItem.HtmlInputToOptionTag(TypeOptionListSelectedValue);

            if (!string.IsNullOrEmpty(TypeOptionListSelectedValue))
                TypeOptionListValue = TypeOptionListValue.HtmlInputSetSelectValue(TypeOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_Type", TypeOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");

            TypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_Type");

            TypeAttribute = TypeAttribute.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_Type"));
        }
    }
}