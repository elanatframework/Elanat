using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowQuickSrearchModel : CodeBehindModel
    {
        public void SetValue()
        {
            string QuickSearchTemplate = Template.GetSiteTemplate("part/quick_search");

            Write(QuickSearchTemplate);
        }
    }
}