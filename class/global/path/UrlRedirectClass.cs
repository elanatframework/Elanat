using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class UrlRedirectClass
    {
        public void Start(string Path)
        {
            XmlNodeList NodeList = StaticObject.UrlRedirectNodeList;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"].Value != "true")
                    continue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (Path.Contains(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath)))
                            goto StartRedirectPath;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (Path.TextStartMathByValueCheck(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath)))
                            goto StartRedirectPath;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath).Length <= Path.Length)
                        {
                            string TmpPath = Path;

                            TmpPath = TmpPath.GetTextBeforeValue("?");

                            if (TmpPath.TextEndMathByValueCheck(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath)))
                                goto StartRedirectPath;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath), RegexOptions.IgnoreCase);

                        if (re.IsMatch(Path))
                            goto StartRedirectPath;
                    }


                continue;

                StartRedirectPath:
                try
                {
                    string RedirectValue = node["redirect_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath);

                    new HttpContextAccessor().HttpContext.Response.Redirect(RedirectValue);

                    break;
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex, StaticObject.GetCurrentSiteGlobalLanguage());
                }
            }
        }
    }
}