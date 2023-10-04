using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class Access
    {
        public bool DirectAccessComponent { get; private set; }
        public string CurrentComponentName { get; private set; }
        public string CurrentComponentColumnId { get; private set; }
        public bool FindDynamicExtensionInUploadDirectory { get; private set; }
        public bool IsAttachment { get; private set; }

        public bool RolePathAccessCheck(string Path, string FormValue, bool BreakAppDataPath = false)
        {
            if (Path.GetTextBeforeValue("?").Contains(@"\"))
                return false;

            if (!BreakAppDataPath)
                if (Path.GetTextBeforeValue("?").ToLower().Contains("/app_data"))
                    return false;

            if (Path[0] == '~')
                Path = Path.Remove(0, 1);

            if (FindDenyRoleGroupPathAccess(Path, FormValue))
                return false;

            if (FindAllowRoleGroupPathAccess(Path, FormValue))
                return true;

            string QueryStringValue = Path.GetTextAfterValue("?");

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            FileAndDirectory fad = new FileAndDirectory();
            string FirstDirectory = fad.GetFirstDirectory(Path);
            string AfterFirstDirectory = fad.GetAfterFirstDirectory(Path);
            string SecondDirectory = fad.GetSecondDirectory(Path);
            string AfterSecondDirectory = fad.GetAfterSecondDirectory(Path);
            string ThirdDirectory = fad.GetThirdDirectory(Path);
            string AfterThirdDirectory = fad.GetAfterThirdDirectory(Path);
            string FileName = fad.GetFileName(Path);

            if (FirstDirectory.ToLower() == "app_data" || FirstDirectory.ToLower() == "bin")
            {
                return false;
            }

            if (FirstDirectory == StaticObject.AdminDirectoryPath)
            {
                DirectAccessComponent = true;
                CurrentComponentName = "component";

                if (ccoc.RoleDominantType != "admin")
                    return false;

                if (string.IsNullOrEmpty(SecondDirectory))
                    return true;

                ComponentPathAccess access = new ComponentPathAccess();

                if (access.PathAccessToComponent(AfterFirstDirectory, QueryStringValue, FormValue))
                {
                    CurrentComponentColumnId = access.CurrentComponentId;
                    return true;
                }
                else
                    return false;
            }

            switch (FirstDirectory)
            {
                case "action":
                    {
                        if (string.IsNullOrEmpty(SecondDirectory))
                            return false;

                        if (SecondDirectory == "member" && (ccoc.RoleDominantType != "admin" && ccoc.RoleDominantType != "member"))
                            return false;

                        if (SecondDirectory == "admin" && ccoc.RoleDominantType != "admin")
                            return false;

                        if (SecondDirectory == "system_access")
                            return Security.IsSystemAccess(Path);

                        return true;
                    }

                case "add_on":
                    {
                        if (string.IsNullOrEmpty(SecondDirectory))
                            return false;

                        switch (SecondDirectory)
                        {
                            case "module":
                                {
                                    DirectAccessComponent = true;
                                    CurrentComponentName = "module";

                                    if (string.IsNullOrEmpty(ThirdDirectory))
                                        return false;

                                    ModulePathAccess access = new ModulePathAccess();

                                    if (access.PathAccessToModule(AfterSecondDirectory, QueryStringValue, FormValue))
                                    {
                                        CurrentComponentColumnId = access.CurrentModuleId;
                                        return true;
                                    }
                                    else
                                        return false;
                                };

                            case "plugin":
                                {
                                    DirectAccessComponent = true;
                                    CurrentComponentName = "plugin";

                                    if (string.IsNullOrEmpty(ThirdDirectory))
                                        return false;

                                    PluginPathAccess access = new PluginPathAccess();

                                    if (access.PathAccessToPlugin(AfterSecondDirectory, QueryStringValue, FormValue))
                                    {
                                        CurrentComponentColumnId = access.CurrentPluginId;

                                        return true;
                                    }
                                    else
                                        return false;
                                };

                            case "editor_template":
                                {
                                    DirectAccessComponent = true;
                                    CurrentComponentName = "editor_template";

                                    if (string.IsNullOrEmpty(ThirdDirectory))
                                        return false;

                                    EditorTemplatePathAccessShow access = new EditorTemplatePathAccessShow();

                                    if (access.PathAccessToEditorTemplate(AfterSecondDirectory))
                                    {
                                        CurrentComponentColumnId = access.CurrentEditorTemplateId;
                                        return true;
                                    }
                                    else
                                        return false;
                                };

                            case "extra_helper":
                                {
                                    DirectAccessComponent = true;
                                    CurrentComponentName = "extra_helper";

                                    if (string.IsNullOrEmpty(ThirdDirectory))
                                        return false;

                                    ExtraHelperPathAccessShow access = new ExtraHelperPathAccessShow();

                                    if (access.PathAccessToExtraHelper(AfterSecondDirectory))
                                    {
                                        CurrentComponentColumnId = access.CurrentExtraHelperId;
                                        return true;
                                    }
                                    else
                                        return false;
                                };

                            case "fetch":
                                {
                                    DirectAccessComponent = true;
                                    CurrentComponentName = "fetch";

                                    if (ccoc.RoleDominantType != "admin")
                                        return false;

                                    ComponentPathAccess access = new ComponentPathAccess();

                                    if (access.PathAccessToFetchComponent())
                                    {
                                        CurrentComponentColumnId = access.CurrentComponentId;
                                        return true;
                                    }
                                    else
                                        return false;
                                };

                            case "patch":
                                {
                                    DirectAccessComponent = true;
                                    CurrentComponentName = "patch";

                                    if (ccoc.RoleDominantType != "admin")
                                        return false;

                                    ComponentPathAccess access = new ComponentPathAccess();

                                    if (access.PathAccessToPatchComponent())
                                    {
                                        CurrentComponentColumnId = access.CurrentComponentId;
                                        return true;
                                    }
                                    else
                                        return false;
                                };
                        }
                    }
                    break;

                case "backup":
                    {
                        CurrentComponentName = "backup";

                        if (ccoc.RoleDominantType != "admin")
                            return false;

                        ComponentPathAccess access = new ComponentPathAccess();

                        if (access.PathAccessToComponent(CurrentComponentName, QueryStringValue, FormValue))
                        {
                            CurrentComponentColumnId = access.CurrentComponentId;
                            return true;
                        }
                        else
                            return false;
                    }

                case "database":
                    {
                        return false;
                    }

                case "member":
                    {
                        if (ccoc.RoleDominantType != "admin" && ccoc.RoleDominantType != "member")
                            return false;

                        if (string.IsNullOrEmpty(SecondDirectory))
                            return true;
                    }
                    break;

                case "page":
                    {
                        DirectAccessComponent = true;
                        CurrentComponentName = "page";

                        if (string.IsNullOrEmpty(SecondDirectory))
                            return false;

                        if (SecondDirectory == "member" && (ccoc.RoleDominantType != "admin" && ccoc.RoleDominantType != "member"))
                            return false;

                        if (SecondDirectory == "admin" && ccoc.RoleDominantType != "admin")
                            return false;

                        PagePathAccessShow access = new PagePathAccessShow();

                        if (access.PathAccessToPage(AfterFirstDirectory))
                        {
                            CurrentComponentColumnId = access.CurrentPageId;
                            return true;
                        }
                        else
                            return false;
                    }

                case "upload":
                    {
                        if (string.IsNullOrEmpty(AfterFirstDirectory))
                            return true;

                        if (string.IsNullOrEmpty(SecondDirectory))
                            return true;

                        if (fad.FileIsDynamic(AfterFirstDirectory.GetTextBeforeValue("?")))
                            FindDynamicExtensionInUploadDirectory = true;

                        if (SecondDirectory == "attachment")
                        {
                            IsAttachment = true;

                            AttachmentPathAccessShow access = new AttachmentPathAccessShow();

                            if (access.PathAccessToAttachment(AfterSecondDirectory))
                            {
                                CurrentComponentColumnId = access.CurrentAttachmentId;
                                return true;
                            }
                            else
                                return false;
                        }

                        return true;
                    }
            }

            return true;
        }

        public string RoleAllowAccessReason = "";
        public bool FindAllowRolePathAccess(string Path, string FormValue, string RoleName)
        {
            XmlNodeList NodeList = StaticObject.RoleAllwoPathAccessNodeList[StaticObject.RoleNameNumber.GetValue(RoleName).ToNumber()];

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"].Value != "true")
                    continue;

                string CheckValue = Path;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            goto Return;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            goto Return;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                goto Return;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            goto Return;
                    }


                continue;

            Return:
                try
                {
                    RoleAllowAccessReason = node.Attributes["reason"].Value;
                    return true;
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }
            }

            return false;
        }

        public bool FindAllowRoleGroupPathAccess(string Path, string FormValue)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            bool FindAllowAccess = false;

            foreach (string Text in ccoc.GetRoleNameList())
            {
                if (FindAllowRolePathAccess(Path, FormValue, Text))
                    FindAllowAccess = true;
                else
                    return false;
            }

            return FindAllowAccess;
        }

        public string RoleDenyAccessReason = "";
        public bool FindDenyRolePathAccess(string Path, string FormValue, string RoleName)
        {
            XmlNodeList NodeList = StaticObject.RoleDenyPathAccessNodeList[StaticObject.RoleNameNumber.GetValue(RoleName).ToNumber()];

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["active"].Value != "true")
                    continue;

                string CheckValue = Path;
                if (node.Attributes["type"].Value == "form")
                    CheckValue = FormValue;

                if (node.Attributes["exist"] != null)
                    if (node.Attributes["exist"].Value == "true")
                        if (CheckValue.Contains(node["path_value"].InnerText))
                            goto Return;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            goto Return;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                goto Return;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            goto Return;
                    }


                continue;

            Return:
                try
                {
                    RoleDenyAccessReason = node.Attributes["reason"].Value;
                    return true;
                }
                catch (Exception ex)
                {
                    Security.SetLogError(ex);
                }
            }

            return false;
        }

        public bool FindDenyRoleGroupPathAccess(string Path, string FormValue)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            bool FindDenyAccess = false;

            foreach (string Text in ccoc.GetRoleNameList())
            {
                if (FindDenyRolePathAccess(Path, FormValue, Text))
                    FindDenyAccess = true;
                else
                    return false;
            }

            return FindDenyAccess;
        }

        public bool ShowComponentAccess(string ComponentName)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            duc.FillComponentRoleAccess(ComponentId);

            return duc.ComponentAccessShow;
        }

        public bool AddComponentAccess(string ComponentName)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            duc.FillComponentRoleAccess(ComponentId);

            return duc.ComponentAccessAdd;
        }

        public bool DeleteOwnComponentAccess(string ComponentName)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            duc.FillComponentRoleAccess(ComponentId);

            return duc.ComponentAccessDeleteOwn;
        }

        public bool EditOwnComponentAccess(string ComponentName)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            duc.FillComponentRoleAccess(ComponentId);

            return duc.ComponentAccessEditOwn;
        }

        public bool DeleteAllComponentAccess(string ComponentName)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            duc.FillComponentRoleAccess(ComponentId);

            return duc.ComponentAccessDeleteAll;
        }

        public bool EditAllComponentAccess(string ComponentName)
        {
            DataUse.Component duc = new DataUse.Component();
            string ComponentId = duc.GetComponentIdByComponentName(ComponentName);

            duc.FillComponentRoleAccess(ComponentId);

            return duc.ComponentAccessEditAll;
        }

        public bool ShowModuleAccess(string ModuleName)
        {
            DataUse.Module dum = new DataUse.Module();
            string ModuleId = dum.GetModuleIdByModuleName(ModuleName);

            dum.FillModuleRoleAccess(ModuleId);

            return dum.ModuleAccessShow;
        }

        public bool AddModuleAccess(string ModuleName)
        {
            DataUse.Module dum = new DataUse.Module();
            string ModuleId = dum.GetModuleIdByModuleName(ModuleName);

            dum.FillModuleRoleAccess(ModuleId);

            return dum.ModuleAccessAdd;
        }

        public bool DeleteOwnModuleAccess(string ModuleName)
        {
            DataUse.Module dum = new DataUse.Module();
            string ModuleId = dum.GetModuleIdByModuleName(ModuleName);

            dum.FillModuleRoleAccess(ModuleId);

            return dum.ModuleAccessDeleteOwn;
        }

        public bool EditOwnModuleAccess(string ModuleName)
        {
            DataUse.Module dum = new DataUse.Module();
            string ModuleId = dum.GetModuleIdByModuleName(ModuleName);

            dum.FillModuleRoleAccess(ModuleId);

            return dum.ModuleAccessEditOwn;
        }

        public bool DeleteAllModuleAccess(string ModuleName)
        {
            DataUse.Module dum = new DataUse.Module();
            string ModuleId = dum.GetModuleIdByModuleName(ModuleName);

            dum.FillModuleRoleAccess(ModuleId);

            return dum.ModuleAccessDeleteAll;
        }

        public bool EditAllModuleAccess(string ModuleName)
        {
            DataUse.Module dum = new DataUse.Module();
            string ModuleId = dum.GetModuleIdByModuleName(ModuleName);

            dum.FillModuleRoleAccess(ModuleId);

            return dum.ModuleAccessEditAll;
        }

        public bool ShowPluginAccess(string PluginName)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            string PluginId = dup.GetPluginIdByPluginName(PluginName);

            dup.FillPluginRoleAccess(PluginId);

            return dup.PluginAccessShow;
        }

        public bool AddPluginAccess(string PluginName)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            string PluginId = dup.GetPluginIdByPluginName(PluginName);

            dup.FillPluginRoleAccess(PluginId);

            return dup.PluginAccessAdd;
        }

        public bool DeleteOwnPluginAccess(string PluginName)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            string PluginId = dup.GetPluginIdByPluginName(PluginName);

            dup.FillPluginRoleAccess(PluginId);

            return dup.PluginAccessDeleteOwn;
        }

        public bool EditOwnPluginAccess(string PluginName)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            string PluginId = dup.GetPluginIdByPluginName(PluginName);

            dup.FillPluginRoleAccess(PluginId);

            return dup.PluginAccessEditOwn;
        }

        public bool DeleteAllPluginAccess(string PluginName)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            string PluginId = dup.GetPluginIdByPluginName(PluginName);

            dup.FillPluginRoleAccess(PluginId);

            return dup.PluginAccessDeleteAll;
        }

        public bool EditAllPluginAccess(string PluginName)
        {
            DataUse.Plugin dup = new DataUse.Plugin();
            string PluginId = dup.GetPluginIdByPluginName(PluginName);

            dup.FillPluginRoleAccess(PluginId);

            return dup.PluginAccessEditAll;
        }

        /// <returns>Return Three Value. Resault : If All Role Bit Aggregation Column Be True, Return 1; If All Role Bit Aggregation Column Be False, Return 0; If Role Bit Aggregation Column Be Difference Between True And False, Return 2;</returns>
        public string AggregationRoleBitColumnAccess(string ColumnName)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Group dug = new DataUse.Group();
            dug.FillCurrentAggregationRole(ccoc.GroupId);

            return dug.GetRoleBitColumnValue(ColumnName);
        }

        public bool RoleActiveCheck(string RoleId)
        {
            DataUse.Role dur = new DataUse.Role();

            return RoleActiveCheck(RoleId);
        }

        public bool ProcedureRoleAccessCheck(string ProcedureName)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            bool ProcedureAccess = true;

            foreach (string Text in ccoc.GetRoleNameList())
            {
                ProcedureAccess = true;

                XmlNodeList NodeList = StaticObject.RoleProcedureFilterNodeList[StaticObject.RoleNameNumber.GetValue(Text).ToNumber()];

                foreach (XmlNode node in NodeList)
                {
                    if (node.Attributes["name"].Value == ProcedureName)
                        if (node.Attributes["active"] != null)
                            if (node.Attributes["active"].Value == "true")
                            {
                                ProcedureAccess = false;
                                break;
                            }
                }

                if (ProcedureAccess)
                    return true;
            }

            return ProcedureAccess;
        }

        public List<List<string>> GetRoleListWithValue(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_role_list");

            List<List<string>> DoubleList = new List<List<string>>();
            List<string> ValueList = new List<string>();
            List<string> NameList = new List<string>();

            while (dbdr.dr.Read())
            {
                ValueList.Add(dbdr.dr["role_id"].ToString());
                NameList.Add(Language.GetLanguage(dbdr.dr["role_name"].ToString(), GlobalLanguage));
            }

            db.Close();

            DoubleList.Add(ValueList);
            DoubleList.Add(NameList);

            return DoubleList;
        }
    }
}