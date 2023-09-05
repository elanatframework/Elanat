using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class PluginPathAccess
    {
        public string CurrentPluginId { get; private set; }

        public string GetPluginIdByPluginDirectoryPath(string PluginDirectoryPath)
        {
            DataUse.Plugin duc = new DataUse.Plugin();
            string PluginId = duc.GetPluginIdByPluginDirectoryPath(PluginDirectoryPath);

            return PluginId;
        }

        public string GetPluginDirectoryPathFromPath(string Path)
        {
            FileAndDirectory fad = new FileAndDirectory();

            string PluginDirectoryPath = "";
            PluginDirectoryPath = fad.GetCleanDirectoryPathFromPath(Path);

            string[] PluginDirectoryPathArray = PluginDirectoryPath.Split('/');

            int PluginDirectoryPathArrayLength = PluginDirectoryPathArray.Length;

            for (int i = 0; i < PluginDirectoryPathArrayLength; i++)
            {
                PluginDirectoryPath = string.Join("/", PluginDirectoryPathArray);

                if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + string.Join("/", PluginDirectoryPathArray) + "/catalog.xml")))
                    return PluginDirectoryPath;

                // Delete Last Item From Array
                PluginDirectoryPathArray = PluginDirectoryPathArray.Take(PluginDirectoryPathArray.Count() - 1).ToArray();
            }

            return "";
        }

        public bool IsPluginAccessAddPath(string PluginDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_add_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterPluginPath = Path.GetTextAfterValue(PluginDirectoryPath);

                string CheckValue = AfterPluginPath;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            return true;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            return true;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                return true;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            return true;
                    }
            }

            return false;
        }

        private bool IsUserAccessToPluginPathForEditOwn = false;
        private bool FindMatchAccessToPluginPathForEditOwn = false;
        public bool IsPluginAccessEditOwnPath(string PluginDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_edit_own_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterPluginPath = Path.GetTextAfterValue(PluginDirectoryPath);

                string CheckValue = AfterPluginPath;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            goto LoadValueCheck;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            goto LoadValueCheck;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                goto LoadValueCheck;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            goto LoadValueCheck;
                    }

                continue;

            LoadValueCheck:
                try
                {
                    FindMatchAccessToPluginPathForEditOwn = true;

                    string LoadValueCheck = node["load_value_check"].InnerText.Replace("$_asp add_on_path;", StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/");
                    char FirstCharacter = (LoadValueCheck.Contains('?')) ? '&' : '?';
                    string CheckType = node["load_value_check"].Attributes["check_type"].Value;

                    if (CheckType == "page")
                    {
                        int ParameterListCount = 0;

                        if (node["parameter_send_list"] != null)
                        {
                            ParameterListCount = node["parameter_list"].ChildNodes.Count;
                        }

                        string[] NewQueryString = new string[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_list"].ChildNodes)
                        {
                            string ParameterType = "";
                            if (Parameter.Attributes["type"] != null)
                                ParameterType = Parameter.Attributes["type"].Value;

                            string Name = "";
                            if (Parameter.Attributes["name"] != null)
                                Name = Parameter.Attributes["name"].Value;

                            string NewName = "";
                            if (Parameter.Attributes["new_name"] != null)
                                NewName = Parameter.Attributes["new_name"].Value;

                            switch (ParameterType)
                            {
                                case "user_id":
                                    {
                                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "user_id=" + ccoc.UserId : NewName + "=" + ccoc.UserId;

                                        break;
                                    };

                                case "path":
                                    {
                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "path=" + AfterPluginPath : NewName + "=" + AfterPluginPath;

                                        break;
                                    };

                                case "query_string":
                                    {
                                        string TmpQueryString = Path.GetTextAfterValue("?");

                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            NewQueryString[i] = TmpQueryString;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(TmpQueryString, Name);

                                            NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? Name + "=" + PathParameterValue : NewName + "=" + PathParameterValue;
                                        }

                                        break;

                                    };

                                case "form":
                                    {
                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            NewQueryString[i] = FormValue;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(FormValue, Name);

                                            NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? Name + "=" + PathParameterValue : NewName + "=" + PathParameterValue;
                                        }

                                        break;
                                    };

                                default:
                                    {
                                        NewQueryString[i] = Parameter.InnerText;

                                        break;
                                    };
                            }

                            i++;
                        }

                        string ReturnValue = PageLoader.LoadPath(LoadValueCheck + FirstCharacter + string.Join("&", NewQueryString), false);
                        if (ReturnValue == "true")
                        {
                            IsUserAccessToPluginPathForEditOwn = true;
                        }
                        else
                        {
                            IsUserAccessToPluginPathForEditOwn = false;
                            break;
                        }
                    }

                    if (CheckType == "method")
                    {
                        string DllType = node["load_value_check"].Attributes["dll_type"].Value;
                        string DllMethod = node["load_value_check"].Attributes["dll_method"].Value;

                        bool IsNonPublic = false;
                        if (node["load_value_check"].Attributes["is_non_public"] != null)
                            IsNonPublic = (node["load_value_check"].Attributes["is_non_public"].Value == "true");

                        int ParameterListCount = 0;

                        if (node["parameter_send_list"] != null)
                        {
                            ParameterListCount = node["parameter_list"].ChildNodes.Count;
                        }

                        object[] ObjectParameters = new object[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_list"].ChildNodes)
                        {
                            string ParameterType = "";
                            if (Parameter.Attributes["type"] != null)
                                ParameterType = Parameter.Attributes["type"].Value;

                            string Name = "";
                            if (Parameter.Attributes["name"] != null)
                                Name = Parameter.Attributes["name"].Value;

                            switch (ParameterType)
                            {
                                case "user_id":
                                    {
                                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                                        ObjectParameters[i] = ccoc.UserId;

                                        break;
                                    };

                                case "path":
                                    {
                                        ObjectParameters[i] = AfterPluginPath;

                                        break;
                                    };

                                case "query_string":
                                    {
                                        string TmpQueryString = Path.GetTextAfterValue("?");

                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            ObjectParameters[i] = TmpQueryString;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(TmpQueryString, Name);

                                            ObjectParameters[i] = PathParameterValue;
                                        }

                                        break;

                                    };

                                case "form":
                                    {
                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            ObjectParameters[i] = FormValue;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(FormValue, Name);

                                            ObjectParameters[i] = PathParameterValue;
                                        }

                                        break;
                                    };

                                default:
                                    {
                                        ObjectParameters[i] = Parameter.InnerText;

                                        break;
                                    };
                            }

                            i++;
                        }

                        MethodLoader ml = new MethodLoader();

                        string ReturnValue = ml.Start(StaticObject.ServerMapPath(LoadValueCheck), DllType, DllMethod, ObjectParameters, IsNonPublic);
                        if (ReturnValue == "true")
                        {
                            IsUserAccessToPluginPathForEditOwn = true;
                        }
                        else
                        {
                            IsUserAccessToPluginPathForEditOwn = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }

            }

            return FindMatchAccessToPluginPathForEditOwn;
        }

        public bool IsPluginAccessEditAllPath(string PluginDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_edit_all_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterPluginPath = Path.GetTextAfterValue(PluginDirectoryPath);

                string CheckValue = AfterPluginPath;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            return true;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            return true;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                return true;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            return true;
                    }
            }

            return false;
        }

        private bool IsUserAccessToPluginPathForDeleteOwn = false;
        private bool FindMatchAccessToPluginPathForDeleteOwn = false;
        public bool IsPluginAccessDeleteOwnPath(string PluginDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_delete_own_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterPluginPath = Path.GetTextAfterValue(PluginDirectoryPath);

                string CheckValue = AfterPluginPath;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            goto LoadValueCheck;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            goto LoadValueCheck;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                goto LoadValueCheck;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            goto LoadValueCheck;
                    }

                continue;

            LoadValueCheck:
                try
                {
                    FindMatchAccessToPluginPathForDeleteOwn = true;

                    string LoadValueCheck = node["load_value_check"].InnerText.Replace("$_asp add_on_path;", StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/");
                    char FirstCharacter = (LoadValueCheck.Contains('?')) ? '&' : '?';
                    string CheckType = node["load_value_check"].Attributes["check_type"].Value;

                    if (CheckType == "page")
                    {
                        int ParameterListCount = 0;

                        if (node["parameter_send_list"] != null)
                        {
                            ParameterListCount = node["parameter_list"].ChildNodes.Count;
                        }

                        string[] NewQueryString = new string[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_list"].ChildNodes)
                        {
                            string ParameterType = "";
                            if (Parameter.Attributes["type"] != null)
                                ParameterType = Parameter.Attributes["type"].Value;

                            string Name = "";
                            if (Parameter.Attributes["name"] != null)
                                Name = Parameter.Attributes["name"].Value;

                            string NewName = "";
                            if (Parameter.Attributes["new_name"] != null)
                                NewName = Parameter.Attributes["new_name"].Value;

                            switch (ParameterType)
                            {
                                case "user_id":
                                    {
                                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "user_id=" + ccoc.UserId : NewName + "=" + ccoc.UserId;

                                        break;
                                    };

                                case "path":
                                    {
                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "path=" + AfterPluginPath : NewName + "=" + AfterPluginPath;

                                        break;
                                    };

                                case "query_string":
                                    {
                                        string TmpQueryString = Path.GetTextAfterValue("?");

                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            NewQueryString[i] = TmpQueryString;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(TmpQueryString, Name);

                                            NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? Name + "=" + PathParameterValue : NewName + "=" + PathParameterValue;
                                        }

                                        break;

                                    };

                                case "form":
                                    {
                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            NewQueryString[i] = FormValue;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(FormValue, Name);

                                            NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? Name + "=" + PathParameterValue : NewName + "=" + PathParameterValue;
                                        }

                                        break;
                                    };

                                default:
                                    {
                                        NewQueryString[i] = Parameter.InnerText;

                                        break;
                                    };
                            }

                            i++;
                        }

                        string ReturnValue = PageLoader.LoadPath(LoadValueCheck + FirstCharacter + string.Join("&", NewQueryString), false);
                        if (ReturnValue == "true")
                        {
                            IsUserAccessToPluginPathForDeleteOwn = true;
                        }
                        else
                        {
                            IsUserAccessToPluginPathForDeleteOwn = false;
                            break;
                        }
                    }

                    if (CheckType == "method")
                    {
                        string DllType = node["load_value_check"].Attributes["dll_type"].Value;
                        string DllMethod = node["load_value_check"].Attributes["dll_method"].Value;

                        bool IsNonPublic = false;
                        if (node["load_value_check"].Attributes["is_non_public"] != null)
                            IsNonPublic = (node["load_value_check"].Attributes["is_non_public"].Value == "true");

                        int ParameterListCount = 0;

                        if (node["parameter_send_list"] != null)
                        {
                            ParameterListCount = node["parameter_list"].ChildNodes.Count;
                        }

                        object[] ObjectParameters = new object[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_list"].ChildNodes)
                        {
                            string ParameterType = "";
                            if (Parameter.Attributes["type"] != null)
                                ParameterType = Parameter.Attributes["type"].Value;

                            string Name = "";
                            if (Parameter.Attributes["name"] != null)
                                Name = Parameter.Attributes["name"].Value;

                            switch (ParameterType)
                            {
                                case "user_id":
                                    {
                                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                                        ObjectParameters[i] = ccoc.UserId;

                                        break;
                                    };

                                case "path":
                                    {
                                        ObjectParameters[i] = AfterPluginPath;

                                        break;
                                    };

                                case "query_string":
                                    {
                                        string TmpQueryString = Path.GetTextAfterValue("?");

                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            ObjectParameters[i] = TmpQueryString;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(TmpQueryString, Name);

                                            ObjectParameters[i] = PathParameterValue;
                                        }

                                        break;

                                    };

                                case "form":
                                    {
                                        if (string.IsNullOrEmpty(Name))
                                        {
                                            ObjectParameters[i] = FormValue;
                                        }
                                        else
                                        {
                                            StringClass sc = new StringClass();

                                            string PathParameterValue = sc.GetPathParameterValue(FormValue, Name);

                                            ObjectParameters[i] = PathParameterValue;
                                        }

                                        break;
                                    };

                                default:
                                    {
                                        ObjectParameters[i] = Parameter.InnerText;

                                        break;
                                    };
                            }

                            i++;
                        }

                        MethodLoader ml = new MethodLoader();

                        string ReturnValue = ml.Start(StaticObject.ServerMapPath(LoadValueCheck), DllType, DllMethod, ObjectParameters, IsNonPublic);
                        if (ReturnValue == "true")
                        {
                            IsUserAccessToPluginPathForDeleteOwn = true;
                        }
                        else
                        {
                            IsUserAccessToPluginPathForDeleteOwn = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }

            }

            return FindMatchAccessToPluginPathForDeleteOwn;
        }

        public bool IsPluginAccessDeleteAllPath(string PluginDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + PluginDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("plugin_catalog_root/plugin_delete_all_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterPluginPath = Path.GetTextAfterValue(PluginDirectoryPath);

                string CheckValue = AfterPluginPath;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            return true;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            return true;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                return true;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            return true;
                    }
            }

            return false;
        }

        public bool PathAccessToPlugin(string Path, string QueryStringValue, string FormValue)
        {
            string PluginDirectoryPath = GetPluginDirectoryPathFromPath(Path);

            if (string.IsNullOrEmpty(PluginDirectoryPath))
                return false;

            string PluginId = GetPluginIdByPluginDirectoryPath(PluginDirectoryPath);

            CurrentPluginId = PluginId;

            if (string.IsNullOrEmpty(PluginId))
                return false;

            DataUse.Plugin duc = new DataUse.Plugin();

            duc.FillPluginRoleAccess(PluginId);

            if (!duc.PluginAccessShow)
                return false;

            if (IsPluginAccessAddPath(PluginDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.PluginAccessAdd)
                    return false;
            }

            if (IsPluginAccessEditOwnPath(PluginDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.PluginAccessEditOwn && !duc.PluginAccessEditAll)
                    return false;

                if (!IsUserAccessToPluginPathForEditOwn && !duc.PluginAccessEditAll)
                    return false;
            }

            if (IsPluginAccessEditAllPath(PluginDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.PluginAccessEditAll)
                    return false;
            }

            if (IsPluginAccessDeleteOwnPath(PluginDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.PluginAccessDeleteOwn && !duc.PluginAccessDeleteAll)
                    return false;

                if (!IsUserAccessToPluginPathForDeleteOwn && !duc.PluginAccessDeleteAll)
                    return false;
            }

            if (IsPluginAccessDeleteAllPath(PluginDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.PluginAccessDeleteAll)
                    return false;
            }

            return true;
        }
    }
}