using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class UrlRewriteClass
    {
        public string Start(string Path)
        {
            XmlNodeList NodeList = StaticObject.UrlRewriteNodeList;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"].Value != "true")
                    continue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (Path.Contains(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath)))
                            goto StartRewritePath;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (Path.TextStartMathByValueCheck(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath)))
                            goto StartRewritePath;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath).Length <= Path.Length)
                        {
                            string TmpPath = Path;

                            TmpPath = TmpPath.GetTextBeforeValue("?");

                            if (TmpPath.TextEndMathByValueCheck(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath)))
                                goto StartRewritePath;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["url_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath), RegexOptions.IgnoreCase);

                        if (re.IsMatch(Path))
                            goto StartRewritePath;
                    }

                continue;

                StartRewritePath:

                string RewritePath = node["rewrite_value"].InnerText.Replace("$_asp admin_path;", StaticObject.AdminDirectoryPath);

                string[] SectionArray = Path.Split('/');
                int i = 0;

                foreach (string Section in SectionArray)
                    RewritePath = RewritePath.Replace("$_asp section_" + i++ + ";", Section);

                if (RewritePath.Contains("$_asp query_string;"))
                    if (Path.Contains("?"))
                        RewritePath = RewritePath.Replace("$_asp query_string;", (RewritePath.Contains("?") ? "&" + Path.GetTextAfterValue("?") : "?" + Path.GetTextAfterValue("?")));
                    else
                        RewritePath = RewritePath.Replace("$_asp query_string;", "");

                return RewritePath;
            }

            return Path;
        }
    }
}