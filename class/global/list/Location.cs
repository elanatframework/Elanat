namespace Elanat.ListClass
{
    public class Location
    {
        // Get Before After Location List Item
        public List<ListItem> BeforeAfterLocationListItem = new List<ListItem>();
        public void FillBeforeAfterLocationListItem(string GlobalLanguage)
        {
            BeforeAfterLocationListItem.Add(Language.GetLanguage("before", GlobalLanguage), "before");
            BeforeAfterLocationListItem.Add(Language.GetLanguage("after", GlobalLanguage), "after");
        }
    }
}