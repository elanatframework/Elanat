namespace Elanat.ListClass
{
    public class PageLoadType
    {
        // Get Page Load Type List Item
        public List<ListItem> PageLoadTypeListItem = new List<ListItem>();
        public void FillPageLoadTypeListItem(string GlobalLanguage)
        {
            PageLoadTypeListItem.Add(Language.GetLanguage("ajax", GlobalLanguage), "ajax");
            PageLoadTypeListItem.Add(Language.GetLanguage("iframe", GlobalLanguage), "iframe");
            PageLoadTypeListItem.Add(Language.GetLanguage("server", GlobalLanguage), "server");
            PageLoadTypeListItem.Add(Language.GetLanguage("on_server", GlobalLanguage), "on_server");
            PageLoadTypeListItem.Add(Language.GetLanguage("text", GlobalLanguage), "text");
        }

        // Get Dynamic Server Page Load Type List Item
        public List<ListItem> DynamicServerPageLoadTypeListItem = new List<ListItem>();
        public void FillDynamicServerPageLoadTypeListItem(string GlobalLanguage)
        {
            DynamicServerPageLoadTypeListItem.Add(Language.GetLanguage("ajax", GlobalLanguage), "ajax");
            DynamicServerPageLoadTypeListItem.Add(Language.GetLanguage("iframe", GlobalLanguage), "iframe");
            DynamicServerPageLoadTypeListItem.Add(Language.GetLanguage("server", GlobalLanguage), "server");
            DynamicServerPageLoadTypeListItem.Add(Language.GetLanguage("on_server", GlobalLanguage), "on_server");
        }
    }
}