using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace elanat
{
	public class PageLoader
	{
        /// <param name="LoadWith">iframe, ajax, text, server, on_server</param>
        public static string LoadPage(string LoadWith, string Path)
        {
            switch (LoadWith)
            {
                case "iframe": return LoadWithIframe(Path);
                case "ajax": return LoadWithAjax(Path);
                case "text": return LoadWithText(Path);
                case "server": return LoadWithServer(Path);
                case "on_server": return LoadWithOnServer(Path);
            }
            return null;
        }

        public static string LoadWithIframe(string Path, bool UsePhysicalPath = false)
        {
            XmlNode Node = StaticObject.StructDocument.SelectSingleNode("struct_root/page_load/iframe");

            if (Path[0] == '~' && Path[1] == '/')
            {
                Path = Path.Remove(0, 2);
                Path = StaticObject.SitePath + Path;
            }

            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            return Node.InnerText.Replace("$_asp page_path;", Path);
        }

        public static string LoadWithAjax(string Path, bool UsePhysicalPath = false)
        {
            XmlNode Node = StaticObject.StructDocument.SelectSingleNode("struct_root/page_load/ajax");

            if (Path[0] == '~' && Path[1] == '/')
            {
                Path = Path.Remove(0, 2);
                Path = StaticObject.SitePath + Path;
            }

            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            return Node.InnerText.Replace("$_asp page_path;", Path);
        }

        public static string LoadWithText(string Path, bool UsePhysicalPath = false)
        {
            if (Path.Contains("?"))
                Path = Path.GetTextBeforeValue("?");

            if (Path[0] == '~' && Path[1] == '/')
            {
                Path = Path.Remove(0, 2);
                Path = StaticObject.SitePath + Path;
            }

            if (!UsePhysicalPath)
                Path = HttpContext.Current.Server.MapPath(Path);

            var Lines = System.IO.File.OpenText(Path);
            string FileText = Lines.ReadToEnd();
            Lines.Close();

            return FileText;
        }

        /// <param name="UsePhysicalPath">Does Not Support Query String</param>
        public static string LoadWithServer(string Path, bool UsePhysicalPath = false)
        {
            Path = Path.Replace("el_page_handlers_path", "null");

            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }


            try
            {
                if (Path.Contains("el_page_handlers_path"))
                    Path = Path.Replace("el_page_handlers_path", "null");

                string QueryString = "";
                if (Path.Contains("?"))
                {
                    QueryString = "&" + Path.GetTextAfterValue("?");

                    Path = Path.GetTextBeforeValue("?");
                }

                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(StaticObject.SitePath + "PageHandlersLoader.aspx?el_page_handlers_path=" + Path + QueryString, writer, true);

                return writer.ToString();
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
                return null;
            }
        }

        public static string PathLoadWithServer(string Path, bool UsePhysicalPath = false)
        {
            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            try
            {
                if (Path.Contains("el_page_handlers_path"))
                    Path = Path.Replace("el_page_handlers_path", "null");

                string QueryString = "";
                if (Path.Contains("?"))
                {
                    QueryString = "&" + Path.GetTextAfterValue("?");

                    Path = Path.GetTextBeforeValue("?");
                }

                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(StaticObject.SitePath + "PageHandlersLoader.aspx?el_page_handlers_path=" + Path + QueryString, writer, true);

                return writer.ToString();
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
                return null;
            }
        }

        /// <param name="UsePhysicalPath">Does Not Support Query String</param>
        public static string LoadWithServerExecute(string Path, bool UsePhysicalPath = false)
        {
            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }
            try
            {
                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(Path, writer, true);
                
                return writer.ToString();
            }
            catch(Exception ex)
            {
                Security.SetLogError(ex);
                return null;
            }
         }

        /// <summary>
        /// This Method Is Bypass Access, Please Be Careful When Using This Method
        /// </summary>
        public static void LoadWithReleaseAccess(string Path, bool UsePhysicalPath = false)
        {
            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            try
            {
                if (Path.Contains("el_page_handlers_path"))
                    Path = Path.Replace("el_page_handlers_path", "null");

                string QueryString = "";
                if (Path.Contains("?"))
                {
                    QueryString = "&" + Path.GetTextAfterValue("?");

                    Path = Path.GetTextBeforeValue("?");
                }

                string Extension = System.IO.Path.GetExtension(Path);
                if (Extension == ".aspx")
                {
                    System.Web.HttpContext Context = new System.Web.HttpContext(HttpContext.Current.Request, HttpContext.Current.Response);
                    Type type = System.Web.Compilation.BuildManager.GetCompiledType(Path);
                    System.Web.UI.Page page = (System.Web.UI.Page)Activator.CreateInstance(type);
                    page.ProcessRequest(Context);
                }
                else if (Extension == ".dll")
                {
                    HttpContext.Current.Response.Write(NativeDll.NativeMethods.Main(HttpContext.Current.Server.MapPath(Path), HttpContext.Current.Request.Form.AllKeys.ToString(), HttpContext.Current.Request.QueryString.ToString()));
                }
                else if (Extension.IsScriptExtension())
                {
                    FileAndDirectory fad = new FileAndDirectory();

                    fad.FillScriptExtensionInfo(System.IO.Path.GetExtension(Path));

                    // Set Arguments
                    string PackagePath = @fad.ScriptExtensioPackagePath;
                    string RunPathCommand = fad.ScriptExtensioRunPathCommand.Replace("$_asp page_path;", HttpContext.Current.Server.MapPath(Path));


                    System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.Arguments = "/C c:& cd " + PackagePath.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath)) + "& " + RunPathCommand.Replace("$_asp site_path;", HttpContext.Current.Server.MapPath(StaticObject.SitePath));
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.RedirectStandardError = true;
                    cmd.Start();

                    while (!cmd.StandardOutput.EndOfStream)
                    {
                        string line = cmd.StandardOutput.ReadLine();
                        HttpContext.Current.Response.Write(line);
                    }
                }
                else
                {
                    // Get Mime Type
                    FileAndDirectory fad = new FileAndDirectory();
                    HttpContext.Current.Response.ContentType = fad.GetMimeType(Path);
                    HttpContext.Current.Response.WriteFile(Path);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Do Not Use This Method More Than Once, Because Loop May Be Occur
        /// </summary>
        public static string LoadWithOnServer(string Path, bool UsePhysicalPath = false)
        {
            if (Path[0] == '~' && Path[1] == '/')
            {
                Path = Path.Remove(0, 2);
                Path = StaticObject.SitePath + Path;
            }

            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "").ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            string Dir = (Path[0] == '/' || Path[0].ToString() == @"\") ? "/" : System.IO.Path.GetDirectoryName(HttpContext.Current.Request.Url.AbsolutePath) + "/";

            Dir = Dir.Replace(@"\", "/");
            if (Path.Contains("../"))
            {
                List<string> list = StringClass.ExtractFromString(Dir, "/");
                while (Path.Contains("../"))
                {
                    Path = Path.Remove(0, 3);
                    list.RemoveAt(list.Count - 1);
                }
                Dir = StringClass.ExtractFromList(list, "/");
            }


            WebRequest request = WebRequest.Create(GlobalClass.GetSiteMainUrl() + Dir + Path);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return responseFromServer;
        }

        public static string LoadForeignPage(string Path)
        {

            WebRequest request = WebRequest.Create(Path);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return responseFromServer;
        }

        public static string LoadWithProcess(string Path)
        {
            System.Diagnostics.Process.Start(Path);

            return null;
        }
    }
}