using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class ModulePathAccess
    {
        public string CurrentModuleId { get; private set; }

        public string GetModuleIdByModuleDirectoryPath(string ModuleDirectoryPath)
        {
            DataUse.Module duc = new DataUse.Module();
            string ModuleId = duc.GetModuleIdByModuleDirectoryPath(ModuleDirectoryPath);

            return ModuleId;
        }

        public string GetModuleDirectoryPathFromPath(string Path)
        {
            FileAndDirectory fad = new FileAndDirectory();

            string ModuleDirectoryPath = "";
            ModuleDirectoryPath = fad.GetCleanDirectoryPathFromPath(Path);

            string[] ModuleDirectoryPathArray = ModuleDirectoryPath.Split('/');

            int ModuleDirectoryPathArrayLength = ModuleDirectoryPathArray.Length;

            for (int i = 0; i < ModuleDirectoryPathArrayLength; i++)
            {
                ModuleDirectoryPath = string.Join("/", ModuleDirectoryPathArray);

                if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + string.Join("/", ModuleDirectoryPathArray) + "/catalog.xml")))
                    return ModuleDirectoryPath;

                // Delete Last Item From Array
                ModuleDirectoryPathArray = ModuleDirectoryPathArray.Take(ModuleDirectoryPathArray.Count() - 1).ToArray();
            }

            return "";
        }

        public bool IsModuleAccessAddPath(string ModuleDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("module_catalog_root/module_add_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterModulePath = Path.GetTextAfterValue(ModuleDirectoryPath);

                string CheckValue = AfterModulePath;
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

        private bool IsUserAccessToModulePathForEditOwn = false;
        private bool FindMatchAccessToModulePathForEditOwn = false;
        public bool IsModuleAccessEditOwnPath(string ModuleDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("module_catalog_root/module_edit_own_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterModulePath = Path.GetTextAfterValue(ModuleDirectoryPath);

                string CheckValue = AfterModulePath;
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
                    FindMatchAccessToModulePathForEditOwn = true;

                    string LoadValueCheck = node["load_value_check"].InnerText.Replace("$_asp add_on_path;", StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/");
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
                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "path=" + AfterModulePath : NewName + "=" + AfterModulePath;

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
                            IsUserAccessToModulePathForEditOwn = true;
                        }
                        else
                        {
                            IsUserAccessToModulePathForEditOwn = false;
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
                                        ObjectParameters[i] = AfterModulePath;

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
                            IsUserAccessToModulePathForEditOwn = true;
                        }
                        else
                        {
                            IsUserAccessToModulePathForEditOwn = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }

            }

            return FindMatchAccessToModulePathForEditOwn;
        }

        public bool IsModuleAccessEditAllPath(string ModuleDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("module_catalog_root/module_edit_all_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterModulePath = Path.GetTextAfterValue(ModuleDirectoryPath);

                string CheckValue = AfterModulePath;
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

        private bool IsUserAccessToModulePathForDeleteOwn = false;
        private bool FindMatchAccessToModulePathForDeleteOwn = false;
        public bool IsModuleAccessDeleteOwnPath(string ModuleDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("module_catalog_root/module_delete_own_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterModulePath = Path.GetTextAfterValue(ModuleDirectoryPath);

                string CheckValue = AfterModulePath;
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
                    FindMatchAccessToModulePathForDeleteOwn = true;

                    string LoadValueCheck = node["load_value_check"].InnerText.Replace("$_asp add_on_path;", StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/");
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
                                        NewQueryString[i] = (string.IsNullOrEmpty(NewName)) ? "path=" + AfterModulePath : NewName + "=" + AfterModulePath;

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
                            IsUserAccessToModulePathForDeleteOwn = true;
                        }
                        else
                        {
                            IsUserAccessToModulePathForDeleteOwn = false;
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
                                        ObjectParameters[i] = AfterModulePath;

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
                            IsUserAccessToModulePathForDeleteOwn = true;
                        }
                        else
                        {
                            IsUserAccessToModulePathForDeleteOwn = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }

            }

            return FindMatchAccessToModulePathForDeleteOwn;
        }

        public bool IsModuleAccessDeleteAllPath(string ModuleDirectoryPath, string Path, string QueryStringValue, string FormValue)
        {
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/catalog.xml"));

            XmlNodeList NodeList = CatalogDocument.SelectSingleNode("module_catalog_root/module_delete_all_access_path").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"] != null)
                    if (node.Attributes["active"].Value != "true")
                        continue;

                string AfterModulePath = Path.GetTextAfterValue(ModuleDirectoryPath);

                string CheckValue = AfterModulePath;
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

        public bool PathAccessToModule(string Path, string QueryStringValue, string FormValue)
        {
            string ModuleDirectoryPath = GetModuleDirectoryPathFromPath(Path);

            if (string.IsNullOrEmpty(ModuleDirectoryPath))
                return false;

            string ModuleId = GetModuleIdByModuleDirectoryPath(ModuleDirectoryPath);

            CurrentModuleId = ModuleId;

            if (string.IsNullOrEmpty(ModuleId))
                return false;

            DataUse.Module duc = new DataUse.Module();

            duc.FillModuleRoleAccess(ModuleId);

            if (!duc.ModuleAccessShow)
                return false;

            if (IsModuleAccessAddPath(ModuleDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ModuleAccessAdd)
                    return false;
            }

            if (IsModuleAccessEditOwnPath(ModuleDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ModuleAccessEditOwn && !duc.ModuleAccessEditAll)
                    return false;

                if (!IsUserAccessToModulePathForEditOwn && !duc.ModuleAccessEditAll)
                    return false;
            }

            if (IsModuleAccessEditAllPath(ModuleDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ModuleAccessEditAll)
                    return false;
            }

            if (IsModuleAccessDeleteOwnPath(ModuleDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ModuleAccessDeleteOwn && !duc.ModuleAccessDeleteAll)
                    return false;

                if (!IsUserAccessToModulePathForDeleteOwn && !duc.ModuleAccessDeleteAll)
                    return false;
            }

            if (IsModuleAccessDeleteAllPath(ModuleDirectoryPath, Path, QueryStringValue, FormValue))
            {
                if (!duc.ModuleAccessDeleteAll)
                    return false;
            }

            return true;
        }
    }
}