using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net;
using System.Text;

namespace Elanat
{
    public class PathAccessHandler
    {
        public string ContentValue = "";
        public void ProcessRequest(HttpContext context)
        {
            string CurrentPath = WebUtility.UrlDecode(context.Request.GetEncodedPathAndQuery());
            string Path = CurrentPath;
            string PagePhysicalExtension = "";

            // Set Current Client Object Value
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();


            // Check Inaccess Ip
            Security sc = new Security();

            if (!sc.IpIsSecure(Security.GetUserIp()))
            {
                ContentValue = GlobalClass.AlertLanguageVariant("you_do_not_access_to_get_service_from_this_server", StaticObject.GetCurrentSiteGlobalLanguage(), "warning");

                return;
            }


            // Is Repeated
            // Check Robot Detection
            if (StaticObject.UseRobotDetection)
            {
                if (ProcessKeeper.ClientRobotIpIsBlocked == "true")
                    return;

                RobotIpBlock rib = new RobotIpBlock();

                if ((ccoc.RobotDetectionDateTimeLong + StaticObject.RobotDetectionResetTimeDuration) <= DateAndTime.GetDateAndTimeLong())
                    rib.ResetRequest();

                if ((ccoc.RobotDetectionRequestCount < 1) && (Security.GetUserIp() != Security.GetServerIp()))
                {
                    if (ccoc.RobotDetectionRequestAfterShowCaptchaCount < 1)
                    {
                        ProcessKeeper.ClientRobotIpIsBlocked = "true";

                        rib.AddRobotIpBlock();

                        return;
                    }

                    ccoc.RobotDetectionRequestAfterShowCaptchaCount--;
                    ccoc.CaptchaReleaseCount = 0;

                    context.Response.Redirect(StaticObject.SitePath + "page/robot_detect_captcha/Default.aspx");

                    return;
                }

                ccoc.RobotDetectionRequestCount = ccoc.RobotDetectionRequestCount - ccoc.IpSessionCount;
            }


            // Start Scheduled Tasks
            if (!StaticObject.ScheduledTasksHasABeenImplemented)
            {
                ScheduledTasks st = new ScheduledTasks();
                st.Start("load");
            }


            FileAndDirectory fad = new FileAndDirectory();
            CacheClass cc = new CacheClass();

            if (!string.IsNullOrEmpty(context.Request.Query["javascript_active"]))
                if (context.Request.Query["javascript_active"] == "false")
                    ccoc.JavaScriptIsActive = false;

            // Set Dependent Objects
            string CacheKey = "";
            CacheKey += ":" + ccoc.JavaScriptIsActive.BooleanToZeroOne();
            CacheKey += ":" + ccoc.UserId;
            CacheKey += ":" + Path;


            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);
            IMemoryCache Cache = context.RequestServices.GetService<IMemoryCache>();

            // Set Static Cache To Header
            if (!fad.FileIsDynamic(StaticObject.ServerMapPath(StaticObject.SitePath + Path.GetTextBeforeValue("?"))))
            {
                if (StaticObject.UseClientCacheForStaticPage)
                {
                    int ClientCacheDuration = StaticObject.StaticPageClientCacheDuration;

                    if (!StaticObject.CheckStaticPageLastModifiedForClientCache)
                    {
                        context.Response.Headers["Cache-Control"] = "private";
                        context.Response.Headers["Expires"] = DateTime.Now.AddSeconds(ClientCacheDuration).ToString("R");
                        context.Response.Headers["Vary"] = "If-Modified-Since, If-None-Match";
                    }
                    else
                    {
                        var TmpFileInfo = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + Path));

                        var CreationDate = TmpFileInfo.CreationTime;

                        string ETag = fad.GetFileETag(Path, CreationDate);

                        context.Response.Headers["Cache-Control"] = "private";
                        context.Response.Headers["Cache-Control"] += ", max-age=" + (ClientCacheDuration * 60).ToString();
                        context.Response.Headers["Vary"] = "If-Modified-Since, If-None-Match";
                        context.Response.Headers["Last-Modified"] = CreationDate.ToString("R");
                        context.Response.Headers["ETag"] = ETag;


                        if (!fad.IsFileModified(Path, CreationDate, ETag, context.Request))
                        {
                            context.Response.StatusCode = 304;
                            context.Response.Headers.Add("Content-Length", "0");

                            return;
                        }
                    }
                }
            } // Set Dynamic Cache To Header
            else if (StaticObject.UseClientCacheForDynamicPage)
            {
                int ClientCacheDuration = StaticObject.DynamicPageClientCacheDuration;

                if (!StaticObject.CheckDynamicPageServerCacheForClientCache)
                {
                    context.Response.Headers["Cache-Control"] = "private";
                    context.Response.Headers["Expires"] = DateTime.Now.AddSeconds(ClientCacheDuration).ToString("R");
                    context.Response.Headers["Vary"] = "If-Modified-Since, If-None-Match";
                }
                else
                {
                    string TmpCacheKey = "el_handler_client_" + CacheKey + ":" + context.Session.Id;

                    var CreationDate = cc.Exist(CacheType, TmpCacheKey) ? DateTime.Parse(cc.GetMemoryValue(TmpCacheKey)) : DateTime.Now;

                    string ETag = fad.GetFileETag(Path, CreationDate);

                    context.Response.Headers["Cache-Control"] = "private";
                    context.Response.Headers["Cache-Control"] += ", max-age=" + (ClientCacheDuration * 60).ToString();
                    context.Response.Headers["Vary"] = "If-Modified-Since, If-None-Match";
                    context.Response.Headers["Last-Modified"] = CreationDate.ToString("R");
                    context.Response.Headers["ETag"] = ETag;


                    if (cc.Exist(CacheType, TmpCacheKey))
                    {
                        context.Response.StatusCode = 304;
                        context.Response.Headers.Add("Content-Length", "0");

                        return;
                    }
                    else
                    {
                        cc.InsertToMemory(TmpCacheKey, CreationDate.ToString(), ClientCacheDuration);
                    }
                }
            }


            // Set Reference
            ReferenceClass reference = new ReferenceClass();
            reference.StartBeforeLoadPath(Path, context.Request.Form.GetString());
            if (!reference.AllowAccessPath)
            {
                // Clear Cache
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Response.Headers["Pragma"] = "no-cache";


                ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetHandheldLanguage(reference.DenyAccessReason, StaticObject.GetCurrentSiteGlobalLanguage()));

                return;
            }


            // Check Secure Login
            if (!Security.IsSecureLogin())
            {
                // Clear Cache
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Response.Headers["Pragma"] = "no-cache";


                Security.ExitUser();

                context.Response.Redirect(StaticObject.SitePath + "page/error/403");

                return;
            }


            // Check Role Path Access
            Access acs = new Access();
            if (!acs.RolePathAccessCheck(Path, context.Request.Form.GetString()))
            {
                // Clear Cache
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Response.Headers["Pragma"] = "no-cache";


                context.Response.Redirect(StaticObject.SitePath + "page/error/401");

                return;
            }


            // Set Url Redirect
            UrlRedirectClass redirect = new UrlRedirectClass();
            redirect.Start(Path);


            // Set Url Rewrite
            UrlRewriteClass rewrite = new UrlRewriteClass();
            Path = rewrite.Start(Path);


            string AbsolutePath = WebUtility.UrlDecode(Path.GetTextBeforeValue("?"));
            string PagePhysicalName = System.IO.Path.GetFileName(AbsolutePath);
            string QueryString = (Path.Contains("?")) ? "?" + Path.GetTextAfterValue("?") : "";
            List<ListItem> QueryStringCollection = new List<ListItem>();

            if (Path.Contains("?"))
            {
                string TmpQueryString = Path.GetTextAfterValue("?");

                if (!string.IsNullOrEmpty(TmpQueryString))
                    foreach (string NameValue in TmpQueryString.Split('&'))
                        if (NameValue.Contains("="))
                            QueryStringCollection.Add(NameValue.GetTextBeforeValue("="), NameValue.GetTextAfterValue("="));
            }


            // Set Current Site And Current Language
            string TmpPath = Path;
            bool IsAdminPath = false;

            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue("site")))
                ccoc.SetSite(QueryStringCollection.GetValue("site"));

            if (TmpPath.Length >= StaticObject.AdminDirectoryPath.Length)
            {
                while (TmpPath.Length > 1)
                    if (TmpPath[0] == '/')
                        TmpPath = TmpPath.Remove(0, 1);
                    else
                        break;

                if (TmpPath.Length >= StaticObject.AdminDirectoryPath.Length)
                    if (TmpPath.Substring(0, StaticObject.AdminDirectoryPath.Length) == StaticObject.AdminDirectoryPath)
                    {
                        if (!string.IsNullOrEmpty(QueryStringCollection.GetValue("language")))
                            ccoc.SetAdminLanguage(QueryStringCollection.GetValue("language"));

                        IsAdminPath = true;
                    }
            }

            if (!IsAdminPath)
            {
                if (!string.IsNullOrEmpty(QueryStringCollection.GetValue("language")))
                    ccoc.SetSiteLanguage(QueryStringCollection.GetValue("language"));
            }


            bool PathHasFileName = Path.ExistFileInPath();


            if (string.IsNullOrEmpty(PagePhysicalName))
            {
                PagePhysicalName = fad.GetDefaultPage(Path);
                AbsolutePath = AbsolutePath + PagePhysicalName;
            }

            PagePhysicalExtension = System.IO.Path.GetExtension(PagePhysicalName);


            // File Exist Check
            if (!string.IsNullOrEmpty(PagePhysicalName))
                if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + Path.GetTextBeforeValue("?"))))
                {
                    if (string.IsNullOrEmpty(fad.GetDefaultPage(Path)))
                    {
                        // Clear Cache
                        context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                        context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                        context.Response.Headers["Pragma"] = "no-cache";

                        context.Response.StatusCode = 404;

                        context.Response.Redirect(StaticObject.SitePath + "page/error/404");

                        return;
                    }
                }


            // Check Authorized Extension
            if (!string.IsNullOrEmpty(PagePhysicalName))
                if (!Security.CheckAuthorizedExtension(PagePhysicalExtension))
                {
                    // Clear Cache
                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                    context.Response.Headers["Pragma"] = "no-cache";

                    return;
                }


            // Site Is Inactive Check
            if (ElanatConfig.GetNode("security/inactive_site").Attributes["active"].Value == "true")
            {
                // Clear Cache
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Response.Headers["Pragma"] = "no-cache";


                if (ccoc.RoleDominantType != "admin")
                    context.Response.Redirect(StaticObject.SitePath + "page/site_is_inactive/Default.aspx");

                return;
            }


            if (!string.IsNullOrEmpty(AbsolutePath))
            {
                if (!AbsolutePath.ExistFileInPath())
                {
                    if (AbsolutePath[AbsolutePath.Length - 1] == '/')
                    {
                        if (AbsolutePath.Length > 1)
                        {
                            if (!string.IsNullOrEmpty(System.IO.Path.GetExtension(AbsolutePath.Substring(0, AbsolutePath.Length - 2))))
                                AbsolutePath.Remove(AbsolutePath.Length - 2, 1);
                            else
                            {
                                AbsolutePath += fad.GetDefaultPage(Path);
                            }
                        }
                        else
                        {
                            AbsolutePath += fad.GetDefaultPage(Path);
                        }
                    }
                    else
                    {
                        if (!AbsolutePath.ExistFileInPath())
                        {
                            AbsolutePath += "/" + fad.GetDefaultPage(Path);
                        }
                    }
                }
            }
            else
            {
                AbsolutePath += "/" + fad.GetDefaultPage(Path);
            }

            Path = AbsolutePath + QueryString;

            // Rewrite Path
            context.Request.Path = Path.GetTextBeforeValue("?");


            // Download Dynamic Extension
            if (acs.FindDynamicExtensionInUploadDirectory)
            {
                if (acs.IsAttachment)
                {
                    DataUse.Attachment dua = new DataUse.Attachment();

                    // Check Active
                    if (!dua.AttachmentIsActive(acs.CurrentComponentColumnId))
                    {
                        // Clear Cache
                        context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                        context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                        context.Response.Headers["Pragma"] = "no-cache";

                        return;
                    }
                }


                // Clear Cache
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Response.Headers["Pragma"] = "no-cache";


                var FilePath = StaticObject.ServerMapPath(Path);
                long FileSize = new FileInfo(FilePath).Length;
                var response = context.Response;
                response.Headers.Add("Content-Length", FileSize.ToString());
                response.ContentType = "application/octet-stream";
                response.Headers.Add("Content-Disposition", $"attachment; filename=\"{System.IO.Path.GetFileName(FilePath)}\"");
                using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var bufferSize = 64 * 1024; // 64KB
                    var buffer = new byte[bufferSize];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        try
                        {
                            response.Body.WriteAsync(buffer, 0, bytesRead);
                            response.Body.FlushAsync();
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
                    }
                }

                return;
            }


            if (acs.IsAttachment)
            {
                DataUse.Attachment dua = new DataUse.Attachment();

                // Check Active
                if (!dua.AttachmentIsActive(acs.CurrentComponentColumnId))
                {
                    // Clear Cache
                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                    context.Response.Headers["Pragma"] = "no-cache";

                    return;
                }
            }


            // Load AddOn Path
            bool IsAddOnPath = false;

            if (acs.DirectAccessComponent)
            {
                string ComponentContent = "";

                if (!string.IsNullOrEmpty(acs.CurrentComponentName) && !string.IsNullOrEmpty(acs.CurrentComponentColumnId))
                    switch (acs.CurrentComponentName)
                    {
                        case "page":
                            {
                                DataUse.Page dup = new DataUse.Page();
                                dup.FillCurrentPage(acs.CurrentComponentColumnId);

                                if (string.IsNullOrEmpty(dup.PageId))
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("page_is_not_existed", ccoc.SiteLanguageGlobalName));

                                    return;
                                }

                                // Check Active
                                if (!dup.PageActive.ZeroOneToBoolean())
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("page_is_inactive", ccoc.SiteLanguageGlobalName));

                                    return;
                                }


                                string PagePhysicalPath = dup.PageDirectoryPath + "/" + dup.PagePhysicalName;

                                if (CurrentPath.Length > PagePhysicalPath.Length)
                                    if (CurrentPath.Substring(CurrentPath.Length - PagePhysicalPath.Length, PagePhysicalPath.Length) == PagePhysicalPath)
                                    {
                                        IsAddOnPath = true;

                                        // Set Cache Key
                                        string PageCacheKey = "";
                                        foreach (string key in dup.PageCacheParameters.Split(','))
                                            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                                                PageCacheKey += ":" + QueryStringCollection.GetValue(key);

                                        // Get Cache
                                        if (cc.Exist(CacheType, "el_page_" + dup.PageId + PageCacheKey))
                                        {
                                            ComponentContent = cc.GetValue(CacheType, "el_page_" + dup.PageId + PageCacheKey);
                                            break;
                                        }


                                        if (CurrentPath.Length >= 14)
                                            if (CurrentPath.Substring(0, 14) == "/page_content/")
                                                CurrentPath = "/page/" + CurrentPath.Remove(0, 14);


                                        // Get Page Content
                                        ComponentContent = PageLoader.LoadPath(Path, false);


                                        AttributeReader ar = new AttributeReader();

                                        if (dup.PageUseLanguage.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadLanguage(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PageUseModule.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadModule(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PageUsePlugin.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadPlugin(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PageUseReplacePart.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadReplacePart(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PageUseFetch.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadFetch(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PageUseItem.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadItem(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PageUseElanat.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadElanat(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());


                                        // Set Cache
                                        cc.Insert(CacheType, "el_page_" + dup.PageId + PageCacheKey, ComponentContent, int.Parse(dup.PageCacheDuration));
                                    }

                            }; break;

                        case "component":
                            {
                                DataUse.Component duc = new DataUse.Component();
                                duc.FillCurrentComponent(acs.CurrentComponentColumnId);

                                if (string.IsNullOrEmpty(duc.ComponentId))
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("component_is_not_existed", ccoc.AdminLanguageGlobalName));

                                    return;
                                }

                                // Check Active
                                if (!duc.ComponentActive.ZeroOneToBoolean())
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("component_is_inactive", ccoc.AdminLanguageGlobalName));

                                    return;
                                }


                                string ComponentPhysicalPath = duc.ComponentDirectoryPath + "/" + duc.ComponentPhysicalName;

                                if (CurrentPath.Length > ComponentPhysicalPath.Length)
                                    if (CurrentPath.Substring(CurrentPath.Length - ComponentPhysicalPath.Length, ComponentPhysicalPath.Length) == ComponentPhysicalPath)
                                    {
                                        IsAddOnPath = true;

                                        // Set Cache Key
                                        string ComponentCacheKey = "";
                                        foreach (string key in duc.ComponentCacheParameters.Split(','))
                                            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                                                ComponentCacheKey += ":" + QueryStringCollection.GetValue(key);

                                        // Get Cache
                                        if (cc.Exist(CacheType, "el_component_" + duc.ComponentId + ComponentCacheKey))
                                        {
                                            ComponentContent = cc.GetValue(CacheType, "el_component_" + duc.ComponentId + ComponentCacheKey);
                                            break;
                                        }


                                        // Get Component Content
                                        ComponentContent = PageLoader.LoadPath(Path, false);


                                        AttributeReader ar = new AttributeReader();

                                        if (duc.ComponentUseLanguage.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadLanguage(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duc.ComponentUseModule.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadModule(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duc.ComponentUsePlugin.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadPlugin(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duc.ComponentUseReplacePart.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadReplacePart(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duc.ComponentUseFetch.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadFetch(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duc.ComponentUseItem.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadItem(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duc.ComponentUseElanat.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadElanat(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());


                                        // Set Cache
                                        cc.Insert(CacheType, "el_component_" + duc.ComponentId + ComponentCacheKey, ComponentContent, int.Parse(duc.ComponentCacheDuration));
                                    }

                            }; break;

                        case "module":
                            {
                                DataUse.Module dum = new DataUse.Module();
                                dum.FillCurrentModule(acs.CurrentComponentColumnId);

                                if (string.IsNullOrEmpty(dum.ModuleId))
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("module_is_not_existed", ccoc.SiteLanguageGlobalName));

                                    return;
                                }

                                // Check Active
                                if (!dum.ModuleActive.ZeroOneToBoolean())
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("module_is_inactive", ccoc.SiteLanguageGlobalName));

                                    return;
                                }


                                string ModulePhysicalPath = dum.ModuleDirectoryPath + "/" + dum.ModulePhysicalName;

                                if (CurrentPath.Length > ModulePhysicalPath.Length)
                                    if (CurrentPath.Substring(CurrentPath.Length - ModulePhysicalPath.Length, ModulePhysicalPath.Length) == ModulePhysicalPath)
                                    {
                                        IsAddOnPath = true;

                                        // Set Cache Key
                                        string ModuleCacheKey = "";
                                        foreach (string key in dum.ModuleCacheParameters.Split(','))
                                            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                                                ModuleCacheKey += ":" + QueryStringCollection.GetValue(key);

                                        // Get Cache
                                        if (cc.Exist(CacheType, "el_module_" + dum.ModuleId + ModuleCacheKey))
                                        {
                                            ComponentContent = cc.GetValue(CacheType, "el_module_" + dum.ModuleId + ModuleCacheKey);
                                            break;
                                        }


                                        // Get Module Content
                                        ComponentContent = PageLoader.LoadPath(Path, false);


                                        AttributeReader ar = new AttributeReader();

                                        if (dum.ModuleUseLanguage.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadLanguage(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dum.ModuleUseModule.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadModule(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dum.ModuleUsePlugin.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadPlugin(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dum.ModuleUseReplacePart.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadReplacePart(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dum.ModuleUseFetch.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadFetch(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dum.ModuleUseItem.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadItem(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dum.ModuleUseElanat.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadElanat(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());


                                        // Set Cache
                                        cc.Insert(CacheType, "el_module_" + dum.ModuleId + ModuleCacheKey, ComponentContent, int.Parse(dum.ModuleCacheDuration));
                                    }

                            }; break;

                        case "plugin":
                            {
                                DataUse.Plugin dup = new DataUse.Plugin();
                                dup.FillCurrentPlugin(acs.CurrentComponentColumnId);

                                if (string.IsNullOrEmpty(dup.PluginId))
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("plugin_is_not_existed", ccoc.SiteLanguageGlobalName));

                                    return;
                                }

                                // Check Active
                                if (!dup.PluginActive.ZeroOneToBoolean())
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("plugin_is_inactive", ccoc.SiteLanguageGlobalName));

                                    return;
                                }


                                string PluginPhysicalPath = dup.PluginDirectoryPath + "/" + dup.PluginPhysicalName;

                                if (CurrentPath.Length > PluginPhysicalPath.Length)
                                    if (CurrentPath.Substring(CurrentPath.Length - PluginPhysicalPath.Length, PluginPhysicalPath.Length) == PluginPhysicalPath)
                                    {
                                        IsAddOnPath = true;

                                        // Set Cache Key
                                        string PluginCacheKey = "";
                                        foreach (string key in dup.PluginCacheParameters.Split(','))
                                            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                                                PluginCacheKey += ":" + QueryStringCollection.GetValue(key);

                                        // Get Cache
                                        if (cc.Exist(CacheType, "el_plugin_" + dup.PluginId + PluginCacheKey))
                                        {
                                            ComponentContent = cc.GetValue(CacheType, "el_plugin_" + dup.PluginId + PluginCacheKey);
                                            break;
                                        }


                                        // Get Plugin Content
                                        ComponentContent = PageLoader.LoadPath(Path, false);


                                        AttributeReader ar = new AttributeReader();

                                        if (dup.PluginUseLanguage.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadLanguage(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PluginUseModule.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadModule(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PluginUsePlugin.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadPlugin(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PluginUseReplacePart.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadReplacePart(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PluginUseFetch.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadFetch(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PluginUseItem.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadItem(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());

                                        if (dup.PluginUseElanat.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadElanat(ComponentContent, StaticObject.GetCurrentSiteSiteGlobalName());


                                        // Set Cache
                                        cc.Insert(CacheType, "el_plugin_" + dup.PluginId + PluginCacheKey, ComponentContent, int.Parse(dup.PluginCacheDuration));
                                    }

                            }; break;

                        case "extra_helper":
                            {
                                DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();
                                dueh.FillCurrentExtraHelper(acs.CurrentComponentColumnId);

                                if (string.IsNullOrEmpty(dueh.ExtraHelperId))
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("extra_helper_is_not_existed", ccoc.AdminLanguageGlobalName));

                                    return;
                                }

                                // Check Active
                                if (!dueh.ExtraHelperActive.ZeroOneToBoolean())
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("extra_helper_is_inactive", ccoc.AdminLanguageGlobalName));

                                    return;
                                }


                                string ExtraHelperPhysicalPath = dueh.ExtraHelperDirectoryPath + "/" + dueh.ExtraHelperPhysicalName;

                                if (CurrentPath.Length > ExtraHelperPhysicalPath.Length)
                                    if (CurrentPath.Substring(CurrentPath.Length - ExtraHelperPhysicalPath.Length, ExtraHelperPhysicalPath.Length) == ExtraHelperPhysicalPath)
                                    {
                                        IsAddOnPath = true;

                                        // Set Cache Key
                                        string ExtraHelperCacheKey = "";
                                        foreach (string key in dueh.ExtraHelperCacheParameters.Split(','))
                                            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                                                ExtraHelperCacheKey += ":" + QueryStringCollection.GetValue(key);

                                        // Get Cache
                                        if (cc.Exist(CacheType, "el_extra_helper_" + dueh.ExtraHelperId + ExtraHelperCacheKey))
                                        {
                                            ComponentContent = cc.GetValue(CacheType, "el_extra_helper_" + dueh.ExtraHelperId + ExtraHelperCacheKey);
                                            break;
                                        }


                                        // Get Extra Helper Content
                                        ComponentContent = PageLoader.LoadPath(Path, false);


                                        AttributeReader ar = new AttributeReader();

                                        if (dueh.ExtraHelperUseLanguage.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadLanguage(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (dueh.ExtraHelperUseModule.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadModule(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (dueh.ExtraHelperUsePlugin.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadPlugin(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (dueh.ExtraHelperUseReplacePart.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadReplacePart(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (dueh.ExtraHelperUseFetch.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadFetch(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (dueh.ExtraHelperUseItem.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadItem(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (dueh.ExtraHelperUseElanat.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadElanat(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());


                                        // Set Cache
                                        cc.Insert(CacheType, "el_extra_helper_" + dueh.ExtraHelperId + ExtraHelperCacheKey, ComponentContent, int.Parse(dueh.ExtraHelperCacheDuration));
                                    }

                            }; break;

                        case "editor_template":
                            {
                                DataUse.EditorTemplate duet = new DataUse.EditorTemplate();
                                duet.FillCurrentEditorTemplate(acs.CurrentComponentColumnId);


                                if (string.IsNullOrEmpty(duet.EditorTemplateId))
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("editor_template_is_not_existed", ccoc.AdminLanguageGlobalName));

                                    return;
                                }

                                // Check Active
                                if (!duet.EditorTemplateActive.ZeroOneToBoolean())
                                {
                                    // Clear Cache
                                    context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                                    context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                                    context.Response.Headers["Pragma"] = "no-cache";


                                    ContentValue = Template.GetAdminTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("editor_template_is_inactive", ccoc.AdminLanguageGlobalName));

                                    return;
                                }


                                string EditorTemplatePhysicalPath = duet.EditorTemplateDirectoryPath + "/" + duet.EditorTemplatePhysicalName;

                                if (CurrentPath.Length > EditorTemplatePhysicalPath.Length)
                                    if (CurrentPath.Substring(CurrentPath.Length - EditorTemplatePhysicalPath.Length, EditorTemplatePhysicalPath.Length) == EditorTemplatePhysicalPath)
                                    {
                                        IsAddOnPath = true;

                                        // Set Cache Key
                                        string EditorTemplateCacheKey = "";
                                        foreach (string key in duet.EditorTemplateCacheParameters.Split(','))
                                            if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                                                EditorTemplateCacheKey += ":" + QueryStringCollection.GetValue(key);

                                        // Get Cache
                                        if (cc.Exist(CacheType, "el_editor_template_" + duet.EditorTemplateId + EditorTemplateCacheKey))
                                        {
                                            ComponentContent = cc.GetValue(CacheType, "el_editor_template_" + duet.EditorTemplateId + EditorTemplateCacheKey);
                                            break;
                                        }


                                        // Get Editor Template Content
                                        ComponentContent = PageLoader.LoadPath(Path, false);


                                        AttributeReader ar = new AttributeReader();

                                        if (duet.EditorTemplateUseLanguage.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadLanguage(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duet.EditorTemplateUseModule.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadModule(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duet.EditorTemplateUsePlugin.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadPlugin(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duet.EditorTemplateUseReplacePart.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadReplacePart(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duet.EditorTemplateUseFetch.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadFetch(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duet.EditorTemplateUseItem.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadItem(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());

                                        if (duet.EditorTemplateUseElanat.ZeroOneToBoolean())
                                            ComponentContent = ar.ReadElanat(ComponentContent, StaticObject.GetCurrentAdminGlobalLanguage());


                                        // Set Cache
                                        cc.Insert(CacheType, "el_editor_template_" + duet.EditorTemplateId + EditorTemplateCacheKey, ComponentContent, int.Parse(duet.EditorTemplateCacheDuration));
                                    }

                            }; break;

                    }

                if (IsAddOnPath)
                    ContentValue = ComponentContent;
            }

            if (!IsAddOnPath)
            {
                string Extension = System.IO.Path.GetExtension(AbsolutePath);
                if (Extension == ".aspx")
                {
                    context.Response.ContentType = fad.GetMimeType(AbsolutePath);

                    ContentValue = PageLoader.LoadWithServer(Path);
                }
                else if (Extension == ".dll")
                {
                    ContentValue = NativeDll.NativeMethods.Main(StaticObject.ServerMapPath(AbsolutePath), context.Request.Form.GetString(), QueryString);
                }
                else if (Extension.IsScriptExtension())
                {
                    fad.FillScriptExtensionInfo(System.IO.Path.GetExtension(AbsolutePath));

                    // Set Arguments
                    string PackagePath = @fad.ScriptExtensioPackagePath;
                    string RunPathCommand = fad.ScriptExtensioRunPathCommand;

                    PackagePath = PackagePath.Replace("$_asp quotation_mark;", "\"");
                    PackagePath = PackagePath.Replace("$_asp site_path;", StaticObject.ServerMapPath(StaticObject.SitePath));
                    RunPathCommand = RunPathCommand.Replace("$_asp quotation_mark;", "\"");
                    RunPathCommand = RunPathCommand.Replace("$_asp site_path;", StaticObject.ServerMapPath(StaticObject.SitePath));
                    RunPathCommand = RunPathCommand.Replace("$_asp page_path;", StaticObject.ServerMapPath(AbsolutePath));
                    RunPathCommand = RunPathCommand.Replace("$_asp query_string;", QueryString.Replace("\"", "$_asp quotation_mark;"));
                    RunPathCommand = RunPathCommand.Replace("$_asp form_data;", context.Request.Form.GetString().Replace("\"", "$_asp quotation_mark;"));
                    RunPathCommand = RunPathCommand.Replace("$_asp session;", context.Session.GetString().Replace("\"", "$_asp quotation_mark;"));
                    RunPathCommand = RunPathCommand.Replace("$_asp cookie;", context.Request.Cookies.GetString().Replace("\"", "$_asp quotation_mark;"));


                    System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.Arguments = "/C c:& cd " + PackagePath + "& " + RunPathCommand;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.RedirectStandardError = true;
                    cmd.Start();

                    while (!cmd.StandardOutput.EndOfStream)
                    {
                        string line = cmd.StandardOutput.ReadLine();
                        ContentValue += line;
                    }

                    context.Response.ContentType = "text/html; charset=utf-8";
                }
                else
                {
                    // Get Mime Type
                    context.Response.ContentType = fad.GetMimeType(AbsolutePath);

                    using (FileStream TmpFileStream = File.Open(StaticObject.ServerMapPath(AbsolutePath), FileMode.Open, FileAccess.Read))
                    {
                        ContentValue = new StreamReader(TmpFileStream).ReadToEnd();
                    }
                }
            }


            // Set Reference
            reference.StartAfterLoadPath(Path, context.Request.Form.GetString());


            // Set Finally Mime Type
            if (PathHasFileName && (!System.IO.Path.GetExtension(AbsolutePath).IsExecuteExtension()))
                context.Response.ContentType = fad.GetMimeType(AbsolutePath);
        }
    }
}