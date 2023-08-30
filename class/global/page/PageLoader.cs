using CodeBehind;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Elanat
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

            var Lines = File.OpenText(Path);
            string FileText = Lines.ReadToEnd();
            Lines.Close();

            return FileText;
        }


        /// <param name="UsePhysicalPath">Does Not Support Query String</param>
        public static string LoadWithServer(string Path, bool UsePhysicalPath = false)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

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