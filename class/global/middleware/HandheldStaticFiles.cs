using Microsoft.AspNetCore.Http.Extensions;
using System.Net;

namespace Elanat
{
    public class HandheldStaticFiles
    {
        private readonly RequestDelegate _next;

        public HandheldStaticFiles(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string Path = WebUtility.UrlDecode(context.Request.GetEncodedPathAndQuery());
            string TmpContentType = context.Request.ContentType;

            string Extension = System.IO.Path.GetExtension(Path.GetTextBeforeValue("?"));

            if (Extension == ".aspx" || string.IsNullOrEmpty(Extension))
            {
                await _next(context);
                return;
            }

            if (Extension == ".exe" || Extension == ".html" || Extension == ".htm" || Extension == ".dll")
            {
                // Is Repeated
                if (context.Request.ContentType == null)
                    context.Request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

                PathAccessHandler pah = new PathAccessHandler();
                pah.ProcessRequest(context);

                await context.Response.WriteAsync(pah.ContentValue);
                await context.Response.CompleteAsync();

                return;
            }


            // Set Current Client Object Value
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();


            // Check Inaccess Ip
            Security sc = new Security();

            if (!sc.IpIsSecure(Security.GetUserIp()))
            {
                context.Response.StatusCode = 403;
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

                        context.Response.StatusCode = 403;
                        return;
                    }

                    ccoc.RobotDetectionRequestAfterShowCaptchaCount--;
                    ccoc.CaptchaReleaseCount = 0;

                    context.Response.Redirect(StaticObject.SitePath + "page/robot_detect_captcha/Default.aspx");

                    return;
                }

                ccoc.RobotDetectionRequestCount = ccoc.RobotDetectionRequestCount - ccoc.IpSessionCount;
            }

            // Set Reference
            context.Request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

            ReferenceClass reference = new ReferenceClass();
            reference.StartBeforeLoadPath(Path, context.Request.Form.GetString());
            if (!reference.AllowAccessPath)
            {
                // Clear Cache
                context.Response.Headers["Expires"] = DateTime.UtcNow.AddMinutes(-1).ToString("R");
                context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Response.Headers["Pragma"] = "no-cache";


                context.Response.StatusCode = 403;
                return;
            }

            context.Request.ContentType = TmpContentType;


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
            redirect.Start(context.Request.Path);


            // Set Url Rewrite
            UrlRewriteClass rewrite = new UrlRewriteClass();
            context.Request.Path = rewrite.Start(context.Request.Path);


            // Set Reference
            context.Request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

            reference.StartAfterLoadPath(Path, context.Request.Form.GetString());

            context.Request.ContentType = TmpContentType;


            await _next(context);
        }
    }
}