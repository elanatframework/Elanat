using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionSearchModel : CodeBehindModel
    {
        public string SearchLanguage { get; set; }
        public string SearchTermLanguage { get; set; }
        public string ResultsLanguage { get; set; }

        public string TitleOrTextPartValue { get; set; }
        public string DatePartValue { get; set; }
        public string CategoryPartValue { get; set; }
        public string SearchTermValue { get; set; }
        public string ContentValue { get; set; }

        public string CategoryOptionListSelectedValue { get; set; }
        public string TitleOrTextOptionListSelectedValue { get; set; }
        public string SearchFromValue { get; set; }
        public string SearchUntilValue { get; set; }

        public string SearchValue { get; set; }

        public string SearchAttribute { get; set; }

        public string SearchCssClass { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
            SearchLanguage = aol.GetAddOnsLanguage("search");
            SearchTermLanguage = aol.GetAddOnsLanguage("search_term");
            ResultsLanguage = aol.GetAddOnsLanguage("results");


            DataUse.Content duc = new DataUse.Content();

            // Set Value
            XmlDocument RssOptionDocument = new XmlDocument();
            RssOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/search_option/option/search_option.xml"));

            XmlNode node = RssOptionDocument.SelectSingleNode("search_option_root");

            int MnimumSearchCharacter = node["minimum_search_character"].Attributes["value"].Value.ToNumber();
            int SearchedPerPage = int.Parse(node["searched_per_page"].Attributes["value"].Value);
            bool SaveSearchedTextToFootPrint = node["save_searched_text_to_foot_print"].Attributes["active"].Value == "true";

            
            if (string.IsNullOrEmpty(QueryString.GetValue("type")))
                return;

            if (string.IsNullOrEmpty(QueryString.GetValue("search")))
                return;


            if (MnimumSearchCharacter > QueryString.GetValue("search").Length)
            {
                ResponseForm.WriteLocalAlone(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", StaticObject.GetCurrentSiteGlobalLanguage()).Replace("$_asp field_name;", SearchLanguage).Replace("$_asp minimum_count;", MnimumSearchCharacter.ToString()), "problem");

                return;
            }


            // Set Result Value
            string TitleOrText = "";
            string Where = "";
            string Search = QueryString.GetValue("search").Trim().ProtectSqlInjection(true);

            int PageIndex = 1;
            if (!string.IsNullOrEmpty(QueryString.GetValue("page")))
                PageIndex = int.Parse(QueryString.GetValue("page"));

            int FromNumberRow = ((PageIndex - 1) * SearchedPerPage) + 1;
            int UntilNumberRow = (FromNumberRow + SearchedPerPage) - 1;

            // Set Search Type Query
            if (!string.IsNullOrEmpty(QueryString.GetValue("type")))
            {
                switch (QueryString.GetValue("type"))
                {
                    case "both": Where = "where (el_content.content_text like N'%" + Search + "%' or el_content.content_title like N'%" + Search + "%') and el_content.content_status='active'"; TitleOrText = "both"; break;
                    case "text": Where = "where el_content.content_text like N'%" + Search + "%' and el_content.content_status='active'"; TitleOrText = "text"; break;
                    case "title": Where = "where el_content.content_title like N'%" + Search + "%' and el_content.content_status='active'"; TitleOrText = "title"; break;

                    default: Where = "where (el_content.content_text like N'%" + Search + "%' or el_content.content_title like N'%" + Search + "%') and el_content.content_status='active'"; TitleOrText = "both"; break;
                }
            }
            else
            {
                Where = "where (el_content.content_text like N'%" + Search + "%' or el_content.content_title like N'%" + Search + "%') and el_content.content_status='active'";
                TitleOrText = "both";
            }


            if (!string.IsNullOrEmpty(QueryString.GetValue("from_date")))
                Where += " and el_content.content_date_create >= '" + QueryString.GetValue("from_date").Replace("-", "/").ProtectSqlInjection() + "'";


            if (!string.IsNullOrEmpty(QueryString.GetValue("until_date")))
                Where += " and el_content.content_date_create <= '" + QueryString.GetValue("until_date").Replace("-", "/").ProtectSqlInjection() + "'";


            if (!string.IsNullOrEmpty(QueryString.GetValue("category")))
            {
                if (QueryString.GetValue("category") != "all")
                    if (QueryString.GetValue("category").IsNumber())
                        Where = " and el_content.category_id=" + QueryString.GetValue("category").ProtectSqlInjection();
            }

            Where += " and el_site.site_id=" + StaticObject.GetCurrentSiteSiteId();


            SearchTermValue = Search;
            SearchValue = Search;

            string ListItemTemplate = Template.GetSiteTemplate("page/search/list_item");
            string TmpListItemTemplate = "";
            string SumListItemTemplate = "";

            ListItemTemplate = ListItemTemplate.Replace("$_asp site_path;", StaticObject.SitePath);

            XmlNode ColumnNode = Template.GetXmlNodeFromSiteTemplate("page/search/column_list");

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content", new List<string>() { "@inner_attach", "@count", "@from_number_row", "@until_number_row" }, new List<string>() { Where, SearchedPerPage.ToString(), FromNumberRow.ToString(), UntilNumberRow.ToString() });

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                ContentValue = aol.GetAddOnsLanguage("not_fonud");

                db.Close();
                return;
            }

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    // Set Extra Content Url Value
                    ExtraValue evc = new ExtraValue();

                    evc.SiteGlobalName = dbdr.dr["site_global_name"].ToString();
                    evc.SiteName = dbdr.dr["site_name"].ToString();
                    evc.ContentId = dbdr.dr["content_id"].ToString();
                    evc.ContentTitle = dbdr.dr["content_title"].ToString();
                    evc.CategoryId = dbdr.dr["category_id"].ToString();

                    CategoryClass cc = new CategoryClass();
                    evc.ParrentCategory = cc.GetParentCategory(dbdr.dr["site_global_name"].ToString(), dbdr.dr["category_id"].ToString());
                    evc.CategoryName = cc.CategoryName;


                    TmpListItemTemplate = ListItemTemplate;

                    string ContentText = dbdr.dr["content_text"].ToString();
                    string AdjustTextSearch = GetAdjustSearchContent(ContentText, Search);

                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp content_text;", AdjustTextSearch);
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp extra_content_url_value;", evc.GetContentUrlValue());

                    foreach (XmlNode chlid in ColumnNode.ChildNodes)
                        TmpListItemTemplate = TmpListItemTemplate.Replace("$_db " + chlid.Name + ";", dbdr.dr[chlid.Name].ToString());

                    SumListItemTemplate += TmpListItemTemplate;

                    ContentValue = SumListItemTemplate;
                }

            db.Close();

            // Set Page Number
            int PageNumber = 0;
            if (!string.IsNullOrEmpty(QueryString.GetValue("page")))
            {
                int ParsedValue;
                if (int.TryParse(QueryString.GetValue("page"), out ParsedValue))
                    PageNumber = int.Parse(QueryString.GetValue("page"));
            }

            int ContentCount = int.Parse(duc.GetContentCountByAttach(Where));

            string CategorySelectedIndex = "&category=" + "all";
            if (!string.IsNullOrEmpty(QueryString.GetValue("category")))
                CategorySelectedIndex = "&category=" + QueryString.GetValue("category");

            string FromDate = "";
            if (!string.IsNullOrEmpty(QueryString.GetValue("from_date")))
                FromDate = "&from_date=" + QueryString.GetValue("from_date");

            string UntilDate = "";
            if (!string.IsNullOrEmpty(QueryString.GetValue("until_date")))
                UntilDate = "&until_date=" + QueryString.GetValue("until_date");

            TitleOrText = "&type=" + TitleOrText;
            string SearchWithQueryString = "?search=" + Search;

            string TmpQueryString = "/page_content/search/" + SearchWithQueryString + CategorySelectedIndex + TitleOrText + FromDate + UntilDate;

            string PageNumberTemplate = InnerModuleClass.PageNumbers(ContentCount, TmpQueryString, PageNumber);

            ContentValue += PageNumberTemplate;


            // Add Reference
            if (SaveSearchedTextToFootPrint)
            {
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("searched_text", Search);
            }
        }

        private string GetAdjustSearchContent(string Text, string Serched)
        {
            if (string.IsNullOrEmpty(Text))
                return null;

            if (string.IsNullOrEmpty(Serched))
                return null;

            // Remove Html Tags
            Text = StringClass.RemoveHtmlTags(Text);

            string HighlightsSerchedTemplate = Template.GetSiteTemplate("page/search/highlights_searched");
            HighlightsSerchedTemplate = HighlightsSerchedTemplate.Replace("$_asp serched;", Serched);


            string AdjustSearch = "";

            int SearchedCount = Serched.Length;
            int BeforeLength = 50;
            int AfterLength = 50;
            int TextLength = Text.Length;

            int i = 0;
            while (Text.Contains(Serched) && i < 5)
            {
                int SerchedIndex = Text.IndexOf(Serched);

                BeforeLength = (SerchedIndex > 50) ? 50 : SerchedIndex;

                AfterLength = ((Text.Length - SerchedIndex) > 50) ? 50 : Text.Length - SerchedIndex;

                AdjustSearch += " ..." + Text.Substring(SerchedIndex - BeforeLength).Substring(0, BeforeLength + AfterLength) + "... ";
                Text = Text.Replace(Text.Substring(SerchedIndex - BeforeLength).Substring(0, BeforeLength + AfterLength), null);
                i++;
            }

            return AdjustSearch.Replace(Serched, HighlightsSerchedTemplate);
        }
    }
}