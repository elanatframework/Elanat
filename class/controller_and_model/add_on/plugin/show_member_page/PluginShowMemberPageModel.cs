using CodeBehind;

namespace Elanat
{
    public partial class PluginShowMemberPageModel : CodeBehindModel
    {
        public void SetValue()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Load Member Page List
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_member_page");

            string MemberPageBoxTemplate = Template.GetSiteTemplate("view/member_page/box");
            string MemberPageListItemTemplate = Template.GetSiteTemplate("view/member_page/list_item");

            string TmpMemberPageListItemTemplate = "";
            string SumMemberPageListItemTemplate = "";

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

                    TmpMemberPageListItemTemplate = MemberPageListItemTemplate;
                    TmpMemberPageListItemTemplate = TmpMemberPageListItemTemplate.Replace("$_db page_name;", dbdr.dr["page_name"].ToString());
                    TmpMemberPageListItemTemplate = TmpMemberPageListItemTemplate.Replace("$_db page_title;", dbdr.dr["page_title"].ToString());
                    TmpMemberPageListItemTemplate = TmpMemberPageListItemTemplate.Replace("$_asp page_local_name;", Language.GetHandheldLanguageWithoutNullLanguageSuffix(dbdr.dr["page_global_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));
                    TmpMemberPageListItemTemplate = TmpMemberPageListItemTemplate.Replace("$_asp page_local_title;", Language.GetHandheldLanguageWithoutNullLanguageSuffix(dbdr.dr["page_title"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage()));
                    TmpMemberPageListItemTemplate = TmpMemberPageListItemTemplate.Replace("$_asp member_page_value;", dbdr.dr["page_global_name"].ToString());

                    TmpMemberPageListItemTemplate = TmpMemberPageListItemTemplate.Replace("$_asp extra_page_url_value;", evc.GetPageUrlValue());

                    SumMemberPageListItemTemplate += TmpMemberPageListItemTemplate;
                }

            Write(MemberPageBoxTemplate.Replace("$_asp item;", SumMemberPageListItemTemplate).Replace("$_asp site_path;", StaticObject.SitePath));
        }
    }
}