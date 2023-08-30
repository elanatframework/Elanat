using CodeBehind;

namespace Elanat
{
    public partial class SiteCommentTypeModel : CodeBehindModel
    {
        public string TypeLanguage { get; set; }

        public string CommentTypeValue { get; set; }

        public string TypeOptionListValue { get; set; }
        public string TypeOptionListSelectedValue { get; set; }

        public string TypeAttribute { get; set; }

        public string TypeCssClass { get; set; }

        public void SetValue()
        {
            // Set Language
            TypeLanguage = Language.GetAddOnsLanguage("type", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/comment/");


            // Set Type Item
            ListClass.Comment lcc = new ListClass.Comment();
            lcc.FillCommentTypeListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            TypeOptionListValue += lcc.CommentTypeListItem.HtmlInputToOptionTag(TypeOptionListSelectedValue);


            if (!string.IsNullOrEmpty(CommentTypeValue))
                if (!TypeOptionListValue.HtmlInputExistValueFromSingleSelectStringCheck(CommentTypeValue))
                    TypeOptionListSelectedValue = CommentTypeValue;

            if (!string.IsNullOrEmpty(TypeOptionListSelectedValue))
                TypeOptionListValue = TypeOptionListValue.HtmlInputSetSelectValue(TypeOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("ddlst_Type", TypeOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/comment/");

            TypeAttribute += vc.ImportantInputAttribute.GetValue("ddlst_Type");

            TypeAttribute = TypeAttribute.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_Type"));
        }
    }
}