using CodeBehind;
using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;
using System.Xml;

namespace Elanat
{
    public class PageLoader
    {
        /// <param name="LoadWith">iframe, ajax, text, server, on_server</param>
        public static string LoadPage(string LoadWith, string Path, bool CheckAccess = true)
        {
            if (CheckAccess && ((LoadWith != "iframe") && (LoadWith != "ajax")))
            {
                HttpContext context = new HttpContextAccessor().HttpContext;

                // Check Role Path Access
                Access acs = new Access();
                if (!acs.RolePathAccessCheck(Path, context.Request.Form.GetString()))
                    return null;
            }

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
                Path = Path.Remove(0, StaticObject.ServerMapPath(StaticObject.SitePath + "").ToString().Length - 1);
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
                Path = Path.Remove(0, StaticObject.ServerMapPath(StaticObject.SitePath).ToString().Length - 1);
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
                Path = StaticObject.ServerMapPath(Path);

            string FileText = null;

            using (FileStream TmpFileStream = File.Open(Path, FileMode.Open, FileAccess.Read))
            {
                FileText = new StreamReader(TmpFileStream).ReadToEnd();
            }

            return FileText;
        }


        /// <param name="UsePhysicalPath">Does Not Support Query String</param>
        public static string LoadWithServer(string Path, bool UsePhysicalPath = false)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            string Extension = System.IO.Path.GetExtension(Path.GetTextBeforeValue("?").ToLower());
            if (Extension != ".aspx")
                return LoadPath(Path);


            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, StaticObject.ServerMapPath(StaticObject.SitePath).ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            QueryString OldQueryString = context.Request.QueryString;

            try
            {
                if (Path.Contains('?'))
                {
                    string QueryString = Path.GetTextAfterValue("?");
                    string[] NameAndValue = QueryString.Split('&');
                    foreach (string text in NameAndValue)
                    {
                        string[] NameValue = text.Split('=');

                        if (string.IsNullOrEmpty(context.Request.Query[NameValue[0]]))
                            context.Request.QueryString = (NameValue.Length > 1) ? context.Request.QueryString.Add(NameValue[0], NameValue[1]) : context.Request.QueryString = context.Request.QueryString.Add(NameValue[0], "");
                    }
                }


                string OldPath = context.Request.Path;
                context.Request.Path = Path.GetTextBeforeValue("?");

                CodeBehindExecute execute = new CodeBehindExecute();
                string ReturnValue = execute.Run(context);

                context.Request.QueryString = OldQueryString;
                context.Request.Path = OldPath;

                return ReturnValue;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Do Not Use This Method More Than Once, Because Loop May Be Occur
        /// </summary>
        public static string LoadWithOnServer(string Path, bool UsePhysicalPath = false)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            if (Path[0] == '~' && Path[1] == '/')
            {
                Path = Path.Remove(0, 2);
                Path = StaticObject.SitePath + Path;
            }

            if (UsePhysicalPath)
            {
                Path = Path.Remove(0, StaticObject.ServerMapPath(StaticObject.SitePath).ToString().Length - 1);
                Path = Path.Replace(@"\", "/");
            }

            string Dir = (Path[0] == '/' || Path[0].ToString() == @"\") ? "/" : System.IO.Path.GetDirectoryName(context.Request.GetDisplayUrl()) + "/";

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


            HttpClient webClient = new HttpClient();
            string DataValue = webClient.GetStringAsync(GlobalClass.GetSiteMainUrl() + Dir + Path).Result;

            return DataValue;
        }

        public static string LoadPath(string Path, bool CheckAccess = true)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            if (CheckAccess)
            {
                // Check Role Path Access
                Access acs = new Access();
                if (!acs.RolePathAccessCheck(Path, context.Request.Form.GetString()))
                    return null;
            }


            // Is Repeated
            FileAndDirectory fad = new FileAndDirectory();

            string DataValue = "";
            string QueryString = (Path.Contains("?")) ? "?" + Path.GetTextAfterValue("?") : "";
            string Extension = System.IO.Path.GetExtension(Path.GetTextBeforeValue("?").ToLower());

            if (Extension == ".aspx")
            {
                DataValue = LoadWithServer(Path);
            }
            else if (Extension == ".dll")
            {
                DataValue = NativeDll.NativeMethods.Main(StaticObject.ServerMapPath(Path.GetTextBeforeValue("?")), context.Request.Form.GetString(), QueryString);
            }
            else if (Extension.IsScriptExtension())
            {
                fad.FillScriptExtensionInfo(Extension);

                // Set Arguments
                string PackagePath = @fad.ScriptExtensioPackagePath;
                string RunPathCommand = fad.ScriptExtensioRunPathCommand;

                PackagePath = PackagePath.Replace("$_asp quotation_mark;", "\"");
                PackagePath = PackagePath.Replace("$_asp site_path;", StaticObject.ServerMapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp quotation_mark;", "\"");
                RunPathCommand = RunPathCommand.Replace("$_asp site_path;", StaticObject.ServerMapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp page_path;", StaticObject.ServerMapPath(Path.GetTextBeforeValue("?")));
                RunPathCommand = RunPathCommand.Replace("$_asp query_string;", Path.GetTextAfterValue("?").Replace("\"", "$_asp quotation_mark;"));
                RunPathCommand = RunPathCommand.Replace("$_asp form_data;", context.Request.Form.GetString().Replace("\"", "$_asp quotation_mark;"));
                RunPathCommand = RunPathCommand.Replace("$_asp session;", context.Session.GetString().Replace("\"", "$_asp quotation_mark;"));
                RunPathCommand = RunPathCommand.Replace("$_asp cookie;", context.Request.Cookies.GetString().Replace("\"", "$_asp quotation_mark;"));


                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd";
                cmd.StartInfo.Arguments = "/C c:& cd " + PackagePath + "& " + RunPathCommand;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.Start();

                while (!cmd.StandardOutput.EndOfStream)
                {
                    string line = cmd.StandardOutput.ReadLine();
                    DataValue += line;
                }

                context.Response.ContentType = "text/html; charset=utf-8";
            }
            else
            {
                using (FileStream TmpFileStream = File.Open(StaticObject.ServerMapPath(Path.GetTextBeforeValue("?")), FileMode.Open, FileAccess.Read))
                {
                    DataValue = new StreamReader(TmpFileStream).ReadToEnd();
                }
            }

            return DataValue;
        }

        public static string LoadPathInSystemStart(string Path)
        {
            FileAndDirectory fad = new FileAndDirectory();

            string DataValue = null;
            string QueryString = (Path.Contains("?")) ? "?" + Path.GetTextAfterValue("?") : "";
            string Extension = System.IO.Path.GetExtension(Path.GetTextBeforeValue("?").ToLower());

            if (Extension == ".aspx")
            {
                CodeBehindExecute execute = new CodeBehindExecute();
                DataValue = execute.Run(Path.GetTextBeforeValue("?"));
            }
            else if (Extension == ".dll")
            {
                DataValue = NativeDll.NativeMethods.Main(StaticObject.ServerMapPath(Path.GetTextBeforeValue("?")), "", QueryString);
            }
            else if (Extension.IsScriptExtension())
            {
                fad.FillScriptExtensionInfo(Extension);

                // Set Arguments
                string PackagePath = @fad.ScriptExtensioPackagePath;
                string RunPathCommand = fad.ScriptExtensioRunPathCommand;

                PackagePath = PackagePath.Replace("$_asp quotation_mark;", "\"");
                PackagePath = PackagePath.Replace("$_asp site_path;", StaticObject.ServerMapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp quotation_mark;", "\"");
                RunPathCommand = RunPathCommand.Replace("$_asp site_path;", StaticObject.ServerMapPath(StaticObject.SitePath));
                RunPathCommand = RunPathCommand.Replace("$_asp page_path;", StaticObject.ServerMapPath(Path.GetTextBeforeValue("?")));
                RunPathCommand = RunPathCommand.Replace("$_asp query_string;", QueryString.Replace("\"", "$_asp quotation_mark;"));
                RunPathCommand = RunPathCommand.Replace("$_asp form_data;", "");


                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.Arguments = "/C c:& cd " + PackagePath + "& " + RunPathCommand;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.Start();

                while (!cmd.StandardOutput.EndOfStream)
                {
                    string line = cmd.StandardOutput.ReadLine();
                    DataValue += line;
                }
            }
            else
            {
                using (FileStream TmpFileStream = File.Open(StaticObject.ServerMapPath(Path.GetTextBeforeValue("?")), FileMode.Open, FileAccess.Read))
                {
                    DataValue = new StreamReader(TmpFileStream).ReadToEnd();
                }
            }


            return DataValue;
        }

        public static string LoadForeignPage(string Path)
        {
            HttpClient webClient = new HttpClient();
            string DataValue = webClient.GetStringAsync(Path).Result;

            return DataValue;
        }

        public static string LoadWithProcess(string Path)
        {
            Process.Start(Path);

            return null;
        }
    }
}