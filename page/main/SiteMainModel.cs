﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class SiteMainModel
    {
        public void SetValue(NameValueCollection QueryString)
        {
            int PageNumber = 0;

            if (!string.IsNullOrEmpty(QueryString["page"]))
                if (QueryString["page"].IsNumber())
                    PageNumber = int.Parse(QueryString["page"]);


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string SiteId = ccoc.SiteId;

            string TmpQueryString = "";

            string DataBaseQuery = "where el_content.content_status = 'active'";
            DataBaseQuery += " and el_category.category_active = 1";
            DataBaseQuery += " and el_site.site_active = 1";


            if (!string.IsNullOrEmpty(QueryString["tag"]))
            {
                string TagName = QueryString["tag"].ToString().Replace("_", " ").ProtectSqlInjection();

                DataBaseQuery = "left join el_content_keywords on el_content.content_id = el_content_keywords.content_id " + DataBaseQuery;
                DataBaseQuery += " and el_content_keywords.content_keywords_text = N'" + TagName + "'";
            }

            if (!string.IsNullOrEmpty(QueryString["category"]))
            {
                DataUse.Category duc = new DataUse.Category();

                string CategoryName = QueryString["category"].ToString().ProtectSqlInjection();

                string CategoryId = duc.GetCategoryIdByCategoryName(CategoryName);

                duc.FillCurrentCategory(CategoryId);

                if (string.IsNullOrEmpty(duc.CategoryId))
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("category_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }

                if (!duc.CategoryActive.ZeroOneToBoolean())
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("category_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }


                // Check Category Access Show
                if (!duc.GetCategoryAccessShowCheck(CategoryId))
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_category", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }

                TmpQueryString += "/category/" + CategoryName;

                // Get Sub Category
                if (ElanatConfig.GetNode("properties/show_all_sub_category_when_select_father_category").Attributes["active"].Value.TrueFalseToBoolean())
                {
                    DataBaseQuery += " and (el_content.category_id=" + CategoryId;

                    XmlDocument doc = new XmlDocument();
                    doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/site_data/" + ccoc.SiteSiteGlobalName + "/category_map/category_map.xml"));

                    XmlNodeList NodeList = doc.SelectSingleNode("category_map_root/category_list").ChildNodes;

                    foreach (XmlNode node in NodeList)
                    {
                        if (!node.HasChildNodes)
                            continue;

                        foreach (XmlNode parent in node)
                            if (parent.Attributes["id"].Value == CategoryId)
                            {
                                DataBaseQuery += " or el_content.category_id=" + node.Attributes["id"].Value;

                                break;
                            }
                    }

                    DataBaseQuery += ")";
                }
                else
                {
                    DataBaseQuery += " and el_content.category_id=" + CategoryId;
                }
            }

            if (!string.IsNullOrEmpty(QueryString["site"]))
            {
                DataUse.Site dus = new DataUse.Site();

                string SiteName = QueryString["site"].ToString().ProtectSqlInjection();

                SiteId = dus.GetSiteIdBySiteGlobalName(SiteName);

                dus.FillCurrentSite(SiteId);

                if (string.IsNullOrEmpty(dus.SiteId))
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_is_not_existed", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }

                if (!dus.SiteActive.ZeroOneToBoolean())
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("site_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }


                // Check Site Access Show
                if (!dus.GetSiteAccessShowCheck(SiteId))
                {
                    HttpContext.Current.Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_site", StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }

                TmpQueryString += "/site/" + SiteName;

                DataBaseQuery += " and el_category.site_id=" + SiteId;
            }

            if (!string.IsNullOrEmpty(QueryString["content_type"]))
            {
                string ContentType = QueryString["content_type"].ToString().ProtectSqlInjection();

                TmpQueryString += "/content_type/" + ContentType;

                DataBaseQuery += " and el_content.content_type='" + ContentType + "'";
            }


            string BeforeContentPageNumberTemplate = "";
            string AfterContentPageNumberTemplate = "";
            if (ElanatConfig.GetNode("properties/content_page_number").Attributes["active"].Value == "true")
            {
                DataUse.Content duc = new DataUse.Content();

                int ContentCount = int.Parse(duc.GetContentCountByAttach(DataBaseQuery));

                string PageNumberTemplate = InnerModuleClass.PageNumbers(ContentCount, TmpQueryString, PageNumber, StaticObject.NumberOfContentPerPage, StaticObject.SitePath + "content_page/");

                switch (ElanatConfig.GetNode("properties/content_page_number").Attributes["location"].Value)
                {
                    case "before": BeforeContentPageNumberTemplate = PageNumberTemplate; break;
                    case "after": AfterContentPageNumberTemplate = PageNumberTemplate; break;
                    case "both": BeforeContentPageNumberTemplate = PageNumberTemplate; AfterContentPageNumberTemplate = PageNumberTemplate; break;
                }
            }

            ContentClass cc = new ContentClass();
            string Content = cc.GetContent(ccoc.GroupId, DataBaseQuery + " and (el_category.site_id=" + SiteId + " or el_category.site_id=0)", PageNumber);

            HttpContext.Current.Response.Write(BeforeContentPageNumberTemplate);
            HttpContext.Current.Response.Write(Content);
            HttpContext.Current.Response.Write(AfterContentPageNumberTemplate);
        }
    }
}