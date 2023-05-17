using System;
using System.Web;
using System.IO;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.Caching;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace elanat
{
    public class ZoneHandler : IHttpHandlerFactory
    {
        public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            Object Obj = null;

            try
            {
                Obj = Activator.CreateInstance(Type.GetType("elanat.PathZoneHandler"));
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, StaticObject.GetCurrentSiteGlobalLanguage());
                return null;
            }

            return (IHttpHandler)Obj;
        }

        public virtual void ReleaseHandler(IHttpHandler handler)
        {
            return;
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    public class PathZoneHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string Path = context.Request.RawUrl;
            string PagePhysicalExtension = "";

            FileAndDirectory fad = new FileAndDirectory();

            string AbsolutePath = HttpContext.Current.Server.UrlDecode(Path.GetTextBeforeValue("?"));
            string PagePhysicalName = System.IO.Path.GetFileName(HttpContext.Current.Server.UrlDecode(Path));
            string QueryString = (Path.Contains("?")) ? "?" + Path.GetTextAfterValue("?") : null;
            NameValueCollection QueryStringCollection = new NameValueCollection();

            if (Path.Contains("?"))
            {
                string TmpQueryString = Path.GetTextAfterValue("?");

                if (!string.IsNullOrEmpty(TmpQueryString))
                    foreach (string NameValue in TmpQueryString.Split('&'))
                        if (NameValue.Contains("="))
                            QueryStringCollection.Add(NameValue.GetTextBeforeValue("="), NameValue.GetTextAfterValue("="));
            }

            bool PathHasFileName = Path.ExistFileInPath();


            if (string.IsNullOrEmpty(PagePhysicalName))
            {
                PagePhysicalName = fad.GetDefaultPage(Path);
            }

            PagePhysicalExtension = System.IO.Path.GetExtension(PagePhysicalName);


            // File Exist Check
            if (!string.IsNullOrEmpty(PagePhysicalName))
                if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + Path.GetTextBeforeValue("?"))))
                {
                    if (string.IsNullOrEmpty(fad.GetDefaultPage(Path)))
                    {
                        context.Response.StatusCode = 404;

                        return;
                    }
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

            string Extension = System.IO.Path.GetExtension(AbsolutePath);
            if (Extension == ".aspx")
            {
                Type type = BuildManager.GetCompiledType(AbsolutePath);
                Page page = (Page)Activator.CreateInstance(type);
                page.ProcessRequest(HttpContext.Current);
            }
            else if (Extension == ".dll")
            {
                context.Response.Write(NativeDll.NativeMethods.Main(HttpContext.Current.Server.MapPath(AbsolutePath), context.Request.Form.ToString(), QueryString));
            }
            else if (Extension.IsScriptExtension())
            {
                fad.FillScriptExtensionInfo(System.IO.Path.GetExtension(AbsolutePath));

                // Set Arguments
                string PackagePath = @fad.ScriptExtensioPackagePath;
                string RunPathCommand = fad.ScriptExtensioRunPathCommand;

                PackagePath = PackagePath.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp page_path;", HttpContext.Current.Server.MapPath(AbsolutePath));
                RunPathCommand = RunPathCommand.Replace("$_asp query_string;", QueryString);
                RunPathCommand = RunPathCommand.Replace("$_asp form_data;", context.Request.Form.ToString());


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
                    context.Response.Write(line);
                }

                context.Response.ContentType = "text/html";
            }
            else
            {
                // Get Mime Type
                context.Response.ContentType = fad.GetMimeType(AbsolutePath);
                context.Response.WriteFile(AbsolutePath);
            }


            // Set Finally Mime Type
            if (PathHasFileName && !System.IO.Path.GetExtension(AbsolutePath).IsScriptExtension())
                context.Response.ContentType = fad.GetMimeType(AbsolutePath);


            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
