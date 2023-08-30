using CodeBehind;

namespace Elanat
{
    public partial class ActionCreateContentTypeValueModel : CodeBehindModel
    {
        private string ContentTypeValue { get; set; } = "";

        public void SetValue(string ContentType)
        {
            if (StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/content_type/" + ContentType) != null)
                ContentTypeValue = StaticObject.GlobalTemplateDocument.SelectSingleNode("template_root/content_type/" + ContentType).SetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage()).InnerText;


            Write(ContentTypeValue);
        }
    }
}