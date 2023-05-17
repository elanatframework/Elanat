using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class PageHandlersLoader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["el_page_handlers_path"]))
                return;

            if (Request.QueryString["el_page_handlers_path"].ToString().Contains("PageHandlersLoader.aspx"))
                return;


            string Path = Request.QueryString["el_page_handlers_path"].ToString();
            string PagePhysicalName = System.IO.Path.GetFileName(Path);
            string PagePhysicalExtension = "";


            // First Start
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();


            // Check Inaccess Ip
            Security sc = new Security();

            if (!sc.IpIsSecure(Security.GetUserIp()))
            {
                GlobalClass.AlertLanguageVariant("you_do_not_access_to_get_service_from_this_server", StaticObject.GetCurrentSiteGlobalLanguage(), "warning");
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

                    HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/robot_detect_captcha/Default.aspx");
                }

                ccoc.RobotDetectionRequestCount = ccoc.RobotDetectionRequestCount - ccoc.IpSessionCount;
            }


            // Check Secure Login
            if (!Security.IsSecureLogin())
            {
                Security.ExitUser();

                HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/error/403");

                return;
            }


            // Check Role Path Access
            Access acs = new Access();

            string TmpPath = (string.IsNullOrEmpty(Request.QueryString["el_system_access_code"])) ? Path : (Path.Contains("?")) ? Path + "&el_system_access_code=" + Request.QueryString["el_system_access_code"].ToString() : Path + "?el_system_access_code=" + Request.QueryString["el_system_access_code"].ToString();

            if (!acs.RolePathAccessCheck(TmpPath, Request.Form.ToString()))
                return;


            // Check Xss Injection Attack
            if (!StaticObject.RoleWriteScriptCheck() && (Request.QueryString.ToString().ExistXssInjection() || Request.Form.ToString().ExistXssInjection()))
            {
                GlobalClass.AlertLanguageVariant("find_xss_injection_attack", StaticObject.GetCurrentSiteGlobalLanguage(), "warning");
                return;
            }


            // Check Html Input
            if (!StaticObject.RoleWriteHtmlCheck() && (Request.QueryString.ToString().ExistHtml() || Request.Form.ToString().ExistHtml()))
            {
                GlobalClass.AlertLanguageVariant("you_can_not_write_html", StaticObject.GetCurrentSiteGlobalLanguage(), "problem");
                return;
            }


            if (string.IsNullOrEmpty(PagePhysicalName))
            {
                FileAndDirectory fad = new FileAndDirectory();

                PagePhysicalName = fad.GetDefaultPage(Path);
            }

            PagePhysicalExtension = System.IO.Path.GetExtension(PagePhysicalName);


            // File Exist Check
            if (!string.IsNullOrEmpty(PagePhysicalName))
            {
                TmpPath = Path;
                if (TmpPath[0] == '~' && TmpPath[1] == '/')
                {
                    TmpPath = TmpPath.Remove(0, 2);
                    TmpPath = StaticObject.SitePath + TmpPath;
                }

                if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + System.IO.Path.GetDirectoryName(TmpPath.GetTextBeforeValue("?") + "/" + PagePhysicalName))))
                    return;
            }


            // Check Authorized Extension
            if (!Security.CheckAuthorizedExtension(PagePhysicalExtension))
                return;


            ReferenceClass reference = new ReferenceClass();

            bool IsReference = false;

            if (Path.Length >= 32)
                if (Path.Substring(0, 32) == "/action/system_access/reference/")
                    IsReference = true;

            if (!IsReference)
            {
                reference.StartBeforeLoadPath(Path, Request.Form.ToString());
                if (!reference.AllowAccessPath)
                {
                    Response.Write(Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetHandheldLanguage(reference.DenyAccessReason, StaticObject.GetCurrentSiteGlobalLanguage())));
                    return;
                }
            }


            string Extension = System.IO.Path.GetExtension(Path);
            if (Extension == ".aspx")
            {
                Type type = System.Web.Compilation.BuildManager.GetCompiledType(Path);
                System.Web.UI.Page page = (System.Web.UI.Page)Activator.CreateInstance(type);
                page.ProcessRequest(Context);
            }
            else if (Extension == ".dll")
            {
                Response.Write(NativeDll.NativeMethods.Main(HttpContext.Current.Server.MapPath(Path), Request.Form.ToString(), Request.QueryString.ToString()));
            }
            else if (Extension.IsScriptExtension())
            {
                FileAndDirectory fad = new FileAndDirectory();

                fad.FillScriptExtensionInfo(System.IO.Path.GetExtension(Path));

                // Set Arguments
                string PackagePath = @fad.ScriptExtensioPackagePath;
                string RunPathCommand = fad.ScriptExtensioRunPathCommand;

                PackagePath = PackagePath.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp page_path;", HttpContext.Current.Server.MapPath(Path));
                RunPathCommand = RunPathCommand.Replace("$_asp query_string;", Request.QueryString.ToString());
                RunPathCommand = RunPathCommand.Replace("$_asp form_data;", Request.Form.ToString());


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
                    Response.Write(line);
                }

                Response.ContentType = "text/html";
            }
            else
            {
                // Get Mime Type
                FileAndDirectory fad = new FileAndDirectory();
                Response.ContentType = fad.GetMimeType(Path);
                Response.WriteFile(Path);
            }


            if (!IsReference)
                reference.StartAfterLoadPath(Path, Request.Form.ToString());
        }
    }
}
