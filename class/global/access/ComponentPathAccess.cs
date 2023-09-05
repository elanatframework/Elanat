using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class ComponentPathAccess
    {
        public string CurrentComponentId { get; private set; }

        public string GetComponentIdByComponentDirectoryPath(string ComponentDirectoryPath)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentDirectoryPath(ComponentDirectoryPath);

            return ComponentId;
        }

        public string GetComponentDirectoryPathFromPath(string Path)
        {
            if (!Path.Contains('/'))
                return Path;

            FileAndDirectory fad = new FileAndDirectory();

            string ComponentDirectoryPath = "";
            ComponentDirectoryPath = fad.GetCleanDirectoryPathFromPath(Path);

            string[] ComponentDirectoryPathArray = ComponentDirectoryPath.Split('/');

            int ComponentDirectoryPathArrayLength = ComponentDirectoryPathArray.Length;

            for (int i = 0; i < ComponentDirectoryPathArrayLength; i++)
            {
                ComponentDirectoryPath = string.Join("/", ComponentDirectoryPathArray);

                if (File.Exists(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + string.Join("/", ComponentDirectoryPathArray) + "/catalog.xml")))
                    return ComponentDirectoryPath;

                // Delete Last Item From Array
                ComponentDirectoryPathArray = ComponentDirectoryPathArray.Take(ComponentDirectoryPathArray.Count() - 1).ToArray();
            }

            return "";
        }

        public bool IsComponentAccessAddPath(string ComponentDirectoryPath, string Path, string QueryString, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("component_catalog_root/component_add_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterComponentPath = Path.GetTextAfterValue(ComponentDirectoryPath);

                string CheckValue = AfterComponentPath;
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

        private bool IsUserAccessToComponentPathForEditOwn = false;
        private bool FindMatchAccessToComponentPathForEditOwn = false;
        public bool IsComponentAccessEditOwnPath(string ComponentDirectoryPath, string Path, string QueryString, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("component_catalog_root/component_edit_own_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterComponentPath = Path.GetTextAfterValue(ComponentDirectoryPath);

                string CheckValue = AfterComponentPath;
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
                    FindMatchAccessToComponentPathForEditOwn = true;

                    string LoadValueCheck = node["load_value_check"].InnerText.Replace("$_asp add_on_path;", StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/");
                    char FirstCharacter = (LoadValueCheck.Contains('?')) ? '&' : '?';
                    string CheckType = node["load_value_check"].Attributes["check_type"].Value;

                    if (CheckType == "page")
                    {
                        int ParameterListCount = 0;

                        if (node["parameter_send_list"] != null)
                        {
                            ParameterListCount = node["parameter_send_list"].ChildNodes.Count;
                        }

                        string[] NewQueryString = new string[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_send_list"].ChildNodes)
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
                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "path=" + AfterComponentPath : NewName + "=" + AfterComponentPath;

                                        break;
                                    };

                                case "query_string":
                                    {
                                        string TmpQueryString = QueryString;

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
                            IsUserAccessToComponentPathForEditOwn = true;
                        }
                        else
                        {
                            IsUserAccessToComponentPathForEditOwn = false;
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
                            ParameterListCount = node["parameter_send_list"].ChildNodes.Count;
                        }

                        object[] ObjectParameters = new object[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_send_list"].ChildNodes)
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
                                        ObjectParameters[i] = AfterComponentPath;

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
                            IsUserAccessToComponentPathForEditOwn = true;
                        }
                        else
                        {
                            IsUserAccessToComponentPathForEditOwn = false;
                            break;
                        }
                    }
                }
                 catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }
            }

            return FindMatchAccessToComponentPathForEditOwn;
        }

        public bool IsComponentAccessEditAllPath(string ComponentDirectoryPath, string Path, string QueryString, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("component_catalog_root/component_edit_all_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterComponentPath = Path.GetTextAfterValue(ComponentDirectoryPath);

                string CheckValue = AfterComponentPath;
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

        private bool IsUserAccessToComponentPathForDeleteOwn = false;
        private bool FindMatchAccessToComponentPathForDeleteOwn = false;
        public bool IsComponentAccessDeleteOwnPath(string ComponentDirectoryPath, string Path, string QueryString, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("component_catalog_root/component_delete_own_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterComponentPath = Path.GetTextAfterValue(ComponentDirectoryPath);

                string CheckValue = AfterComponentPath;
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
                    FindMatchAccessToComponentPathForDeleteOwn = true;

                    string LoadValueCheck = node["load_value_check"].InnerText.Replace("$_asp add_on_path;", StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/");
                    char FirstCharacter = (LoadValueCheck.Contains('?')) ? '&' : '?';
                    string CheckType = node["load_value_check"].Attributes["check_type"].Value;

                    if (CheckType == "page")
                    {
                        int ParameterListCount = 0;

                        if (node["parameter_send_list"] != null)
                        {
                            ParameterListCount = node["parameter_send_list"].ChildNodes.Count;
                        }

                        string[] NewQueryString = new string[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_send_list"].ChildNodes)
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
                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "path=" + AfterComponentPath : NewName + "=" + AfterComponentPath;

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
                            IsUserAccessToComponentPathForDeleteOwn = true;
                        }
                        else
                        {
                            IsUserAccessToComponentPathForDeleteOwn = false;
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
                            ParameterListCount = node["parameter_send_list"].ChildNodes.Count;
                        }

                        object[] ObjectParameters = new object[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_send_list"].ChildNodes)
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
                                        ObjectParameters[i] = AfterComponentPath;

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
                            IsUserAccessToComponentPathForDeleteOwn = true;
                        }
                        else
                        {
                            IsUserAccessToComponentPathForDeleteOwn = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }

            }

            return FindMatchAccessToComponentPathForDeleteOwn;
        }

        public bool IsComponentAccessDeleteAllPath(string ComponentDirectoryPath, string Path, string QueryString, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + ComponentDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("component_catalog_root/component_delete_all_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterComponentPath = Path.GetTextAfterValue(ComponentDirectoryPath);

                string CheckValue = AfterComponentPath;
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

        public bool PathAccessToComponent(string Path, string QueryStringValue, string FormValue)
        {
            string ComponentDirectoryPath = GetComponentDirectoryPathFromPath(Path);

            if (string.IsNullOrEmpty(ComponentDirectoryPath))
                return false;

            string ComponentId = GetComponentIdByComponentDirectoryPath(ComponentDirectoryPath);

            CurrentComponentId = ComponentId;

            if (string.IsNullOrEmpty(ComponentId))
                return false;

            DataUse.Component duc = new DataUse.Component();

            duc.FillComponentRoleAccess(ComponentId);

            if (!duc.ComponentAccessShow)
                return false;

            if (IsComponentAccessAddPath(ComponentDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ComponentAccessAdd)
                    return false;
            }

            if (IsComponentAccessEditOwnPath(ComponentDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ComponentAccessEditOwn && !duc.ComponentAccessEditAll)
                    return false;

                if (!IsUserAccessToComponentPathForEditOwn && !duc.ComponentAccessEditAll)
                    return false;
            }

            if (IsComponentAccessEditAllPath(ComponentDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ComponentAccessEditAll)
                    return false;
            }

            if (IsComponentAccessDeleteOwnPath(ComponentDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ComponentAccessDeleteOwn && !duc.ComponentAccessDeleteAll)
                    return false;

                if (!IsUserAccessToComponentPathForDeleteOwn && !duc.ComponentAccessDeleteAll)
                    return false;
            }

            if (IsComponentAccessDeleteAllPath(ComponentDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ComponentAccessDeleteAll)
                    return false;
            }

            return true;
        }

        public bool PathAccessToFetchComponent()
        {
            string ComponentId = GetComponentIdByComponentDirectoryPath("fetch");

            CurrentComponentId = ComponentId;

            if (string.IsNullOrEmpty(ComponentId))
                return false;

            DataUse.Component duc = new DataUse.Component();

            duc.FillComponentRoleAccess(ComponentId);

            if (!duc.ComponentAccessShow)
                return false;

            return true;
        }

        public bool PathAccessToPatchComponent()
        {
            string ComponentId = GetComponentIdByComponentDirectoryPath("patch");

            CurrentComponentId = ComponentId;

            if (string.IsNullOrEmpty(ComponentId))
                return false;

            DataUse.Component duc = new DataUse.Component();

            duc.FillComponentRoleAccess(ComponentId);

            if (!duc.ComponentAccessShow)
                return false;

            return true;
        }
    }
}