using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyTypeModel : CodeBehindModel
    {
        public string TypeLanguage { get; set; }

        public string ContentReplyTypeValue { get; set; }

        public string TypeOptionListValue { get; set; }
        public string TypeOptionListSelectedValue { get; set; }

        public string TypeAttribute { get; set; }

        public string TypeCssClass { get; set; }

        public void SetValue()
        {
            // Set Language
            TypeLanguage = Language.GetAddOnsLanguage("type", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/content_reply/");


            // Set Type Item
            ListClass.ContentReply lccr = new ListClass.ContentReply();
            lccr.FillContentReplyTypeListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            TypeOptionListValue += lccr.ContentReplyTypeListItem.HtmlInputToOptionTag(TypeOptionListSelectedValue);


            if (!string.IsNullOrEmpty(ContentReplyTypeValue))
                if (!TypeOptionListValue.HtmlInputExistValueFromSingleSelectStringCheck(ContentReplyTypeValue))
                    TypeOptionListSelectedValue = ContentReplyTypeValue;

            if (!string.IsNullOrEmpty(TypeOptionListSelectedValue))
                TypeOptionListValue = TypeOptionListValue.HtmlInputSetSelectValue(TypeOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_Type", TypeOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/content_reply/");

            TypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_Type");

            TypeAttribute = TypeAttribute.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_Type"));
        }
    }
}