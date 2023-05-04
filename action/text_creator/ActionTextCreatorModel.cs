using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionTextCreatorModel
    {
        public void SetValue(string Value, NameValueCollection QueryString)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (Value == "admin_client_variant" && ccoc.RoleDominantType != "admin")
                return;


            CacheClass cc = new CacheClass();
            string CacheKey = "el_text_creator";
            CacheKey += ":" + Value;
            CacheKey += ":" + QueryString;

            // Set Dynamic Cache To Header
            if (StaticObject.TextCreatorUseClientCache)
            {
                int ClientCacheDuration = StaticObject.TextCreatorClientCacheDuration;

                if (!StaticObject.CheckDynamicPageServerCacheForClientCache)
                {
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
                    HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(ClientCacheDuration));
                    HttpContext.Current.Response.Cache.SetValidUntilExpires(true);
                }
                else
                {
                    string TmpCacheKey = CacheKey + ":client_creation_date";

                    var CreationDate = cc.Exist(StaticObject.TextCreatorCacheType, TmpCacheKey) ? DateTime.Parse(cc.GetMemoryValue(TmpCacheKey)) : DateTime.Now;

                    FileAndDirectory fad = new FileAndDirectory();
                    string Path = HttpContext.Current.Request.RawUrl;
                    string ETag = fad.GetFileETag(Path, CreationDate);

                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
                    HttpContext.Current.Response.Cache.SetMaxAge(new TimeSpan(0, 0, 0, ClientCacheDuration, 0));
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
                    HttpContext.Current.Response.Cache.VaryByHeaders["If-Modified-Since"] = true;
                    HttpContext.Current.Response.Cache.VaryByHeaders["If-None-Match"] = true;
                    HttpContext.Current.Response.Cache.SetLastModified(CreationDate);
                    HttpContext.Current.Response.Cache.SetETag(ETag);


                    if (cc.Exist(StaticObject.TextCreatorCacheType, TmpCacheKey))
                    {
                        HttpContext.Current.Response.StatusCode = 304;
                        HttpContext.Current.Response.StatusDescription = "Not Modified";
                        HttpContext.Current.Response.AddHeader("Content-Length", "0");

                        HttpContext.Current.Response.End();
                        return;
                    }
                    else
                    {
                        cc.InsertToMemory(TmpCacheKey, CreationDate.ToString(), ClientCacheDuration);
                    }
                }
            }


            // Get Cache
            if (StaticObject.TextCreatorUseServerCache)
            {
                if (cc.Exist(StaticObject.TextCreatorCacheType, CacheKey))
                {
                    HttpContext.Current.Response.ContentType = cc.GetValue(StaticObject.TextCreatorCacheType, CacheKey + ":content_type");

                    HttpContext.Current.Response.Write(cc.GetValue(StaticObject.TextCreatorCacheType, CacheKey));
                    return;
                }
            }


            ClientVariantClass cvc = new ClientVariantClass();
            string MainText = "";
            string ContentType = "";

            switch (Value)
            {
                case "site_client_variant":
                    {
                        // Set Mime Type
                        ContentType = "text/javascript";

                        MainText = cvc.GetSiteClientVariantWithBox();
                    }
                    break;
                case "admin_client_variant":
                    {
                        // Set Mime Type
                        ContentType = "text/javascript";

                        MainText = cvc.GetAdminClientVariantWithBox();
                    }
                    break;
                case "current_view_style":
                    {
                        if (string.IsNullOrEmpty(QueryString["site_style_id"]))
                            return;

                        if (!QueryString["site_style_id"].ToString().IsNumber())
                            return;

                        string SiteStyleId = QueryString["site_style_id"].ToString();

                        string BackgroundColor = QueryString["bc"].ToString();
                        string FontSize = QueryString["fs"].ToString();
                        string CommonLightBackgroundColor = QueryString["clbc"].ToString();
                        string CommonLightTextColor = QueryString["cltc"].ToString();
                        string CommonMiddleBackgroundColor = QueryString["cmbc"].ToString();
                        string CommonMiddleTextColor = QueryString["cmtc"].ToString();
                        string CommonDarkBackgroundColor = QueryString["cdbc"].ToString();
                        string CommonDarkTextColor = QueryString["cdtc"].ToString();
                        string NaturalLightBackgroundColor = QueryString["nlbc"].ToString();
                        string NaturalLightTextColor = QueryString["nltc"].ToString();
                        string NaturalMiddleBackgroundColor = QueryString["nmbc"].ToString();
                        string NaturalMiddleTextColor = QueryString["nmtc"].ToString();
                        string NaturalDarkBackgroundColor = QueryString["ndbc"].ToString();
                        string NaturalDarkTextColor = QueryString["ndtc"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetCurrentViewStyleWithBox(SiteStyleId, BackgroundColor, FontSize, CommonLightBackgroundColor, CommonLightTextColor, CommonMiddleBackgroundColor, CommonMiddleTextColor, CommonDarkBackgroundColor, CommonDarkTextColor, NaturalLightBackgroundColor, NaturalLightTextColor, NaturalMiddleBackgroundColor, NaturalMiddleTextColor, NaturalDarkBackgroundColor, NaturalDarkTextColor);
                    }
                    break;
                case "site_view_style":
                    {
                        if (QueryString["site_style_id"] == null || QueryString["view_id"] == null)
                            return;

                        if (!QueryString["site_style_id"].ToString().IsNumber() || !QueryString["view_id"].ToString().IsNumber())
                            return;

                        string SiteStyleId = QueryString["site_style_id"].ToString();
                        string ViewId = QueryString["view_id"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetSiteViewStyleWithBox(SiteStyleId, ViewId);
                    }
                    break;
                case "admin_view_style":
                    {
                        if (QueryString["admin_style_id"] == null || QueryString["view_id"] == null)
                            return;

                        if (!QueryString["admin_style_id"].ToString().IsNumber() || !QueryString["view_id"].ToString().IsNumber())
                            return;

                        string AminStyleId = QueryString["admin_style_id"].ToString();
                        string ViewId = QueryString["view_id"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetAdminViewStyleWithBox(AminStyleId, ViewId);
                    }
                    break;
                case "user_view_style":
                    {
                        if (QueryString["site_style_id"] == null || QueryString["user_id"] == null)
                            return;

                        if (!QueryString["site_style_id"].ToString().IsNumber() || !QueryString["view_id"].ToString().IsNumber())
                            return;

                        string SiteStyleId = QueryString["site_style_id"].ToString();
                        string UserId = QueryString["user_id"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetUserViewStyleWithBox(SiteStyleId, UserId);
                    }
                    break;
                case "site_client_language_variant":
                    {
                        // Set Mime Type
                        ContentType = "text/javascript";

                        MainText = cvc.GetSiteClientLanguageVariantWithBox(StaticObject.GetCurrentSiteGlobalLanguage());
                    }
                    break;
                case "admin_client_language_variant":
                    {
                        // Set Mime Type
                        ContentType = "text/javascript";

                        MainText = cvc.GetAdminClientLanguageVariantWithBox(StaticObject.GetCurrentAdminGlobalLanguage());
                    }
                    break;
            }


            HttpContext.Current.Response.ContentType = ContentType;

            HttpContext.Current.Response.Write(MainText);


            // Set Cache
            if (StaticObject.TextCreatorUseServerCache)
            {
                if (CacheKey.ToFileNameEncode().Length < 230)
                {
                    cc.Insert(StaticObject.TextCreatorCacheType, CacheKey, MainText, StaticObject.TextCreatorServerCacheDuration);
                    cc.Insert(StaticObject.TextCreatorCacheType, CacheKey + ":content_type", ContentType, StaticObject.TextCreatorServerCacheDuration);
                }
            }
        }
    }
}