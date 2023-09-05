namespace Elanat
{
    public class CreateHtmlForPartPage
    {
        private string CurrentLoadTag { get; set; } = "";
        private string CurrentHead { get; set; } = "";

        public string GetValue(string PageId, List<ListItem> QueryString)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            DataUse.Page dup = new DataUse.Page();

            // Page Access Check
            if (!dup.GetPageAccessShowCheck(PageId))
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/401");
                return "";
            }


            dup.FillCurrentPage(PageId);


            // Check Active
            if (!dup.PageActive.TrueFalseToBoolean())
                return "";


            if (string.IsNullOrEmpty(dup.PageId))
                return "";


            // Set Cache Key
            string PageCacheKey = "";
            foreach (string key in (dup.PageCacheParameters.Split(',')))
                if (!string.IsNullOrEmpty(QueryString.GetValue(key)))
                    PageCacheKey += ":" + QueryString.GetValue(key);

            // Get Cache
            if (cc.Exist(CacheType, "el_alone_page_" + PageId + PageCacheKey))
            {
                string TmpAlonePageValue = cc.GetValue(CacheType, "el_alone_page_" + PageId + PageCacheKey);
                context.Response.WriteAsync(TmpAlonePageValue);

                return "";
            }


            // Set Elanat Value
            string ElanatMetaGenerator = StaticObject.ApplicationName;
            string ElanatMetaAapplicationName = StaticObject.ApplicationName;


            string HtmlForPartPageStruct = Struct.GetNode("html_for_part_page").InnerText;


            // Load Page
            string PagePhysicalPath = StaticObject.SitePath + "page/" + dup.PageDirectoryPath + "/" + dup.PagePhysicalName;
            string TmpQueryString = (!string.IsNullOrEmpty(dup.PageQueryString)) ? "?" + dup.PageQueryString : "";
            string CurrentPageContent = PageLoader.LoadPage(dup.PageLoadType, PagePhysicalPath + TmpQueryString);
            CurrentLoadTag += (dup.PageUseLoadTag.ZeroOneToBoolean()) ? dup.PageLoadTag.Replace("$_asp site_path;", StaticObject.SitePath) : "";
            CurrentHead += (dup.PageUseStaticHead.ZeroOneToBoolean()) ? dup.PageStaticHead.Replace("$_asp site_path;", StaticObject.SitePath) : "";

            // Set Replace Value
            if (dup.PageLoadType != "iframe" && dup.PageLoadType != "ajax")
            {
                AttributeReader ar = new AttributeReader();

                if (dup.PageUseLanguage.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadLanguage(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());

                if (dup.PageUseModule.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadModule(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());

                if (dup.PageUsePlugin.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadPlugin(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());

                if (dup.PageUseReplacePart.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadReplacePart(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());

                if (dup.PageUseFetch.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadFetch(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());

                if (dup.PageUseItem.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadItem(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());

                if (dup.PageUseElanat.ZeroOneToBoolean())
                    CurrentPageContent = ar.ReadElanat(CurrentPageContent, StaticObject.GetCurrentSiteGlobalLanguage());
            }


            // Set Box Head
            IncludeClass ic = new IncludeClass();
            string BoxStaticHead = ic.GetBoxHead(StaticObject.GetCurrentSiteSiteGlobalName());


            // Set Site Style Value
            DataUse.SiteStyle duss = new DataUse.SiteStyle();

            string CurrentStyleId = (dup.SiteStyleId == "0") ? ccoc.SiteStyleId : dup.SiteStyleId;

            duss.FillCurrentSiteStyle(CurrentStyleId);

            if (string.IsNullOrEmpty(duss.SiteStyleId))
            {
                context.Response.WriteAsync(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_style_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                return "";
            }

            if (!duss.SiteStyleActive.ZeroOneToBoolean())
            {
                context.Response.WriteAsync(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_style_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                return "";
            }

            string CurrentSiteStylePhysicalPath = duss.SiteStyleDirectoryPath + "/" + duss.SiteStylePhysicalName;

            CurrentLoadTag += duss.SiteStyleLoadTag.Replace("$_asp site_path;", StaticObject.SitePath);
            CurrentHead += duss.SiteStyleStaticHead.Replace("$_asp site_path;", StaticObject.SitePath);


            // Set Page Dynamic Head
            Head.SiteDynamicHead hsdh = new Head.SiteDynamicHead();
            hsdh.ShowDynamicMetaAapplicationName = dup.PageUseApplicationNameMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaClassification = dup.PageUseClassificationMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaCopyright = dup.PageUseCopyrightMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaDescription = dup.PageUseDescriptionMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaGenerator = dup.PageUseGeneratorMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaJavascriptInactiveRefresh = dup.PageUseJavascriptInactiveRefreshMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaKeywords = dup.PageUseKeywordsMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaLanguage = dup.PageUseLanguageMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaRevisitAfter = dup.PageUseRevisitAfterMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaRight = dup.PageUseRightsMeta.ZeroOneToBoolean();
            hsdh.ShowDynamicMetaRobots = dup.PageUseRobotsMeta.ZeroOneToBoolean();

            hsdh.DynamicMetaAapplicationNameValue = ElanatMetaAapplicationName;
            hsdh.DynamicMetaClassificationValue = dup.PageClassificationMeta;
            hsdh.DynamicMetaCopyrightValue = dup.PageCopyrightMeta;
            hsdh.DynamicMetaDescriptionValue = dup.PageDescriptionMeta;
            hsdh.DynamicMetaGeneratorValue = ElanatMetaGenerator;
            hsdh.DynamicMetaKeywordsValue = dup.PageKeywordsMeta;
            hsdh.DynamicMetaLanguageValue = StaticObject.GetCurrentSiteGlobalLanguage();
            hsdh.DynamicMetaRevisitAfterValue = dup.PageRevisitAfterMeta;
            hsdh.DynamicMetaRightValue = dup.PageRightsMeta;
            hsdh.DynamicMetaRobotsValue = dup.PageRobotsMeta;
            hsdh.DynamicStyleValue = CurrentSiteStylePhysicalPath;
            hsdh.DynamicBoxHeadValue = BoxStaticHead;


            HtmlForPartPageStruct = HtmlForPartPageStruct.Replace("$_asp title;", dup.PageTitle);
            HtmlForPartPageStruct = HtmlForPartPageStruct.Replace("$_asp load_tag;", CurrentLoadTag);
            HtmlForPartPageStruct = HtmlForPartPageStruct.Replace("$_asp static_head;", CurrentHead);
            HtmlForPartPageStruct = HtmlForPartPageStruct.Replace("$_asp dynamic_head;", hsdh.Get());
            HtmlForPartPageStruct = HtmlForPartPageStruct.Replace("$_asp body;", CurrentPageContent);


            // Set Cache
            cc.Insert(CacheType, "el_alone_page_" + dup.PageId + PageCacheKey, HtmlForPartPageStruct, int.Parse(dup.PageCacheDuration));


            return HtmlForPartPageStruct;
        }
    }
}