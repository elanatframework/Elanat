using CodeBehind;
using System.Web;

namespace Elanat
{
    public partial class PluginSiteShowPageModel : CodeBehindModel
    {
        public void SetValue()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string PageBoxTemplate = Template.GetSiteTemplate("view/page/box");
            string PageListItemTemplate = Template.GetSiteTemplate("view/page/list_item");

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_page_list_by_site_id", new List<string>() { "@site_id", "@group_id" }, new List<string>() { ccoc.SiteId, ccoc.GroupId });

            string TmpPathListItemTemplate = "";
            string SumPathListItemTemplate = "";

            // Set Extra Page Url Value
            ExtraValue evc = new ExtraValue();

            evc.SiteGlobalName = ccoc.SiteSiteGlobalName;

            DataUse.Site dus = new DataUse.Site();
            evc.SiteName = dus.GetSiteNameBySiteId(ccoc.SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    evc.PageId = dbdr.dr["page_id"].ToString();
                    evc.PageTitle = dbdr.dr["page_title"].ToString();
                    evc.PageGlobalName = dbdr.dr["page_global_name"].ToString();

                    TmpPathListItemTemplate = PageListItemTemplate;
                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_db page_name;", dbdr.dr["page_name"].ToString());
                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_db page_title;", dbdr.dr["page_title"].ToString());
                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_asp page_local_name;", Language.GetHandheldLanguageWithoutNullLanguageSuffix(dbdr.dr["page_global_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));
                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_asp page_local_title;", Language.GetHandheldLanguageWithoutNullLanguageSuffix(dbdr.dr["page_title"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));

                    TmpPathListItemTemplate = TmpPathListItemTemplate.Replace("$_asp extra_page_url_value;", evc.GetPageUrlValue());

                    SumPathListItemTemplate += TmpPathListItemTemplate;
                }

            db.Close();

            Write(PageBoxTemplate.Replace("$_asp item;", SumPathListItemTemplate).Replace("$_asp site_path;", StaticObject.SitePath));
        }
    }
}