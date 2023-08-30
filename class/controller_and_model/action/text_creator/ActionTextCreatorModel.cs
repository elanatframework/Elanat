using CodeBehind;
using Microsoft.AspNetCore.Http.Features;

namespace Elanat
{
    public partial class ActionTextCreatorModel : CodeBehindModel
    {
        public void SetValue(string Value, List<ListItem> QueryString)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (Value == "admin_client_variant" && ccoc.RoleDominantType != "admin")
                return;


            CacheClass cc = new CacheClass();
            string CacheKey = "el_text_creator";
            CacheKey += ":" + Value;
            CacheKey += ":" + QueryString.ToQueryString();

            // Set Dynamic Cache To Header
            if (StaticObject.TextCreatorUseClientCache)
            {
                int ClientCacheDuration = StaticObject.TextCreatorClientCacheDuration;

                if (!StaticObject.CheckDynamicPageServerCacheForClientCache)
                {
                    context.Response.Headers["Cache-Control"] = "private";
                    context.Response.Headers["Expires"] = DateTime.Now.AddSeconds(ClientCacheDuration).ToString("R");
                    context.Response.Headers["Vary"] = "If-Modified-Since, If-None-Match";
                }
                else
                {
                    string TmpCacheKey = CacheKey + ":client_creation_date";

                    var CreationDate = cc.Exist(StaticObject.TextCreatorCacheType, TmpCacheKey) ? DateTime.Parse(cc.GetMemoryValue(TmpCacheKey)) : DateTime.Now;

                    FileAndDirectory fad = new FileAndDirectory();
                    string Path = context.Request.Path + context.Request.QueryString;
                    string ETag = fad.GetFileETag(Path, CreationDate);


                    context.Response.Headers["Cache-Control"] = "private";
                    context.Response.Headers["Cache-Control"] += ", max-age=" + (ClientCacheDuration * 60).ToString();
                    context.Response.Headers["Vary"] = "If-Modified-Since, If-None-Match";
                    context.Response.Headers["Last-Modified"] = CreationDate.ToString("R");
                    context.Response.Headers["ETag"] = ETag;


                    if (cc.Exist(StaticObject.TextCreatorCacheType, TmpCacheKey))
                    {
                        context.Response.StatusCode = 304;
                        context.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Modified";
                        context.Response.Headers["Content-Length"] = "0";

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
                    context.Response.ContentType = cc.GetValue(StaticObject.TextCreatorCacheType, CacheKey + ":content_type");

                    Write(cc.GetValue(StaticObject.TextCreatorCacheType, CacheKey));
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
                        if (string.IsNullOrEmpty(context.Request.Query["site_style_id"]))
                            return;

                        if (!context.Request.Query["site_style_id"].ToString().IsNumber())
                            return;

                        string SiteStyleId = context.Request.Query["site_style_id"].ToString();

                        string BackgroundColor = context.Request.Query["bc"].ToString();
                        string FontSize = context.Request.Query["fs"].ToString();
                        string CommonLightBackgroundColor = context.Request.Query["clbc"].ToString();
                        string CommonLightTextColor = context.Request.Query["cltc"].ToString();
                        string CommonMiddleBackgroundColor = context.Request.Query["cmbc"].ToString();
                        string CommonMiddleTextColor = context.Request.Query["cmtc"].ToString();
                        string CommonDarkBackgroundColor = context.Request.Query["cdbc"].ToString();
                        string CommonDarkTextColor = context.Request.Query["cdtc"].ToString();
                        string NaturalLightBackgroundColor = context.Request.Query["nlbc"].ToString();
                        string NaturalLightTextColor = context.Request.Query["nltc"].ToString();
                        string NaturalMiddleBackgroundColor = context.Request.Query["nmbc"].ToString();
                        string NaturalMiddleTextColor = context.Request.Query["nmtc"].ToString();
                        string NaturalDarkBackgroundColor = context.Request.Query["ndbc"].ToString();
                        string NaturalDarkTextColor = context.Request.Query["ndtc"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetCurrentViewStyleWithBox(SiteStyleId, BackgroundColor, FontSize, CommonLightBackgroundColor, CommonLightTextColor, CommonMiddleBackgroundColor, CommonMiddleTextColor, CommonDarkBackgroundColor, CommonDarkTextColor, NaturalLightBackgroundColor, NaturalLightTextColor, NaturalMiddleBackgroundColor, NaturalMiddleTextColor, NaturalDarkBackgroundColor, NaturalDarkTextColor);
                    }
                    break;
                case "site_view_style":
                    {
                        if (string.IsNullOrEmpty(context.Request.Query["site_style_id"]) || string.IsNullOrEmpty(context.Request.Query["view_id"]))
                            return;

                        if (!context.Request.Query["site_style_id"].ToString().IsNumber() || !context.Request.Query["view_id"].ToString().IsNumber())
                            return;

                        string SiteStyleId = context.Request.Query["site_style_id"].ToString();
                        string ViewId = context.Request.Query["view_id"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetSiteViewStyleWithBox(SiteStyleId, ViewId);
                    }
                    break;
                case "admin_view_style":
                    {
                        if (string.IsNullOrEmpty(context.Request.Query["admin_style_id"]) || string.IsNullOrEmpty(context.Request.Query["view_id"]))
                            return;

                        if (!context.Request.Query["admin_style_id"].ToString().IsNumber() || !context.Request.Query["view_id"].ToString().IsNumber())
                            return;

                        string AminStyleId = context.Request.Query["admin_style_id"].ToString();
                        string ViewId = context.Request.Query["view_id"].ToString();

                        // Set Mime Type
                        ContentType = "text/css";

                        MainText = cvc.GetAdminViewStyleWithBox(AminStyleId, ViewId);
                    }
                    break;
                case "user_view_style":
                    {
                        if (string.IsNullOrEmpty(context.Request.Query["site_style_id"]) || string.IsNullOrEmpty(context.Request.Query["user_id"]))
                            return;

                        if (!context.Request.Query["site_style_id"].ToString().IsNumber() || !context.Request.Query["view_id"].ToString().IsNumber())
                            return;

                        string SiteStyleId = context.Request.Query["site_style_id"].ToString();
                        string UserId = context.Request.Query["user_id"].ToString();

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


            context.Response.ContentType = ContentType;

            Write(MainText);


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