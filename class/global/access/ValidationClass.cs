using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class ValidationClass
    {
        public bool TrueContinue = true;
        public List<string> EvaluateErrorList = new List<string>();

        public List<ListItem> WarningFieldClass = new List<ListItem>();

        public void EvaluateField(List<ListItem> FormData, string GlobalLanguage, bool ReadClientInjectionCheck = true, string Category = null, string Path = "")
        {
            XmlDocument ValidationDocument = new XmlDocument();
            ValidationDocument.Load(StaticObject.ServerMapPath(Path + "App_Data/validation_list/validation.xml"));

            XmlNodeList Validation = ValidationDocument.SelectSingleNode("validation_root/validation_list").ChildNodes;

            foreach (XmlNode node in Validation)
            {
                if (node.Attributes["category"] != null)
                {
                    if (node.Attributes["category"].Value != Category)
                        continue;
                }
                else
                {
                    if (!string.IsNullOrEmpty(Category))
                        continue;
                }

                string ControlName = node.Name;

                switch (ControlName)
                {
                    case "TextBox":
                        {
                            EvaluateTextBox(FormData, GlobalLanguage, node, Path);
                        } break;

                    case "CheckBoxList":
                        {
                            EvaluateCheckBoxList(FormData, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "DropDownList":
                        {
                            EvaluateDropDownList(FormData, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "ListBox":
                        {
                            EvaluateListBox(FormData, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "HiddenField":
                        {
                            EvaluateHiddenField(FormData, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;


                    case "FileUpload":
                        {
                            EvaluateFileUpload(FormData, GlobalLanguage, node, Path);
                        } break;
                }
            }

            // Delete Session Data
            if (TrueContinue)
                foreach (XmlNode node in Validation)
                {
                    if (node.Attributes["category"] != null)
                    {
                        if (node.Attributes["category"].Value != Category)
                            continue;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Category))
                            continue;
                    }
                }
        }

        // Overload
        public void EvaluateField(IFormCollection FormData, string GlobalLanguage, bool ReadClientInjectionCheck = true, string Category = null, string Path = "")
        {
            List<ListItem> TmpFormData = new List<ListItem>();

            foreach (string key in FormData.Keys)
                TmpFormData.Add(key, FormData[key]);

            EvaluateField(TmpFormData, GlobalLanguage, ReadClientInjectionCheck, Category, Path);
        }

        private void EvaluateTextBox(List<ListItem> FormData, string GlobalLanguage, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;

            string Label = "a";
            if (node.Attributes["label"] != null)
            {
                Label = node.Attributes["label"].Value;
                Label = Language.GetAddOnsLanguage(Label, GlobalLanguage, Path);
            }
            else
                Label = Language.GetLanguage(Label, GlobalLanguage);

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool IsUnique = false;
            if (node.Attributes["is_unique"] != null)
                IsUnique = (node.Attributes["is_unique"].Value == "true");

            bool UnauthorizedCheck = false;
            if (node.Attributes["unauthorized_check"] != null)
                UnauthorizedCheck = (node.Attributes["unauthorized_check"].Value == "true");

            string Format = "";
            if (node.Attributes["format"] != null)
                Format = node.Attributes["format"].Value;

            foreach (ListItem tc in FormData)
            {
                if (tc.Text != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(tc.Text);

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        WarningFieldClass.Add(tc.Text, " el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(tc.Text);

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass.Add(tc.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (!string.IsNullOrEmpty(Format) && !string.IsNullOrEmpty(FormData.GetValue(tc.Text)))
                {
                    Regex re = new Regex(Format, RegexOptions.IgnoreCase);
                    string Value = FormData.GetValue(tc.Text);

                    if (!re.IsMatch(Value))
                    {
                        string ExampleFormat = Label;
                        if (node.Attributes["format_example"] != null)
                            ExampleFormat = node.Attributes["format_example"].Value;

                        WarningFieldClass.Add(tc.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_value_like_asp_format_to_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp format;", ExampleFormat));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(FormData.GetValue(tc.Text))))
                {
                    WarningFieldClass.Add(tc.Text, "el_warning_field");
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                switch (Type)
                {
                    case "ul_string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            StringClass sc = new StringClass();
                            if (!sc.IsUlString(FormData.GetValue(tc.Text)))
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData.GetValue(tc.Text).Length) && Important) || ((MinCount > FormData.GetValue(tc.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(tc.Text))))
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(tc.Text).Length)
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            if (((MinCount > FormData.GetValue(tc.Text).Length) && Important) || ((MinCount > FormData.GetValue(tc.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(tc.Text))))
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(tc.Text).Length)
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number":
                        {
                            int StartRange = 0;
                            if (node.Attributes["start_range"].Value != null)
                                StartRange = int.Parse(node.Attributes["start_range"].Value);

                            int EndRange = int.MaxValue;
                            if (node.Attributes["end_range"].Value != null)
                                EndRange = int.Parse(node.Attributes["end_range"].Value);

                            StringClass sc = new StringClass();
                            if (!FormData.GetValue(tc.Text).IsNumber())
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData.GetValue(tc.Text)))
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData.GetValue(tc.Text)))
                            {
                                WarningFieldClass.Add(tc.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number_list":
                        {
                            foreach (string text in FormData.GetValue(tc.Text).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                int StartRange = 0;
                                if (node.Attributes["start_range"].Value != null)
                                    StartRange = int.Parse(node.Attributes["start_range"].Value);

                                int EndRange = int.MaxValue;
                                if (node.Attributes["end_range"].Value != null)
                                    EndRange = int.Parse(node.Attributes["end_range"].Value);

                                StringClass sc = new StringClass();
                                if (!FormData.GetValue(tc.Text).IsNumber())
                                {
                                    WarningFieldClass.Add(tc.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (StartRange > int.Parse(FormData.GetValue(tc.Text)))
                                {
                                    WarningFieldClass.Add(tc.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                    TrueContinue = false;
                                }

                                if (EndRange < int.Parse(FormData.GetValue(tc.Text)))
                                {
                                    WarningFieldClass.Add(tc.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                    TrueContinue = false;
                                }

                            }
                        }; break;
                }

                break;
            }
        }

        private void EvaluateCheckBoxList(List<ListItem> FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            string Label = "a";
            if (node.Attributes["label"] != null)
            {
                Label = node.Attributes["label"].Value;
                Label = Language.GetAddOnsLanguage(Label, GlobalLanguage, Path);
            }
            else
                Label = Language.GetLanguage(Label, GlobalLanguage);

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool UnauthorizedCheck = false;
            if (node.Attributes["unauthorized_check"] != null)
                UnauthorizedCheck = (node.Attributes["unauthorized_check"].Value == "true");

            string Format = "";
            if (node.Attributes["format"] != null)
                Format = node.Attributes["format"].Value;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem cbl in FormData)
            {
                if (cbl.Text != Id)
                    continue;

                if (Important && (FormData.GetValue(cbl.Text).Split('$').ToList().Count > 0))
                {
                    bool ImportantListFillChecker = false;

                    foreach (string item in FormData.GetValue(cbl.Text).Split('$').ToList())
                    {
                        ImportantListFillChecker = true;
                        break;
                    }

                    if (!ImportantListFillChecker)
                    {
                        WarningFieldClass.Add(cbl.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;

                    foreach (string item in FormData.GetValue(cbl.Text).Split('$').ToList())
                    {
                        string Value = item;

                        if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                        {
                            WarningFieldClass.Add(cbl.Text, "el_warning_field");
                            EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                            TrueContinue = false;
                            break;
                        }
                    }
                }

                foreach (string item in FormData.GetValue(cbl.Text).Split('$').ToList())
                {
                    switch (Type)
                    {
                        case "ul_string":
                            {
                                int MinCount = 0;
                                if (node.Attributes["min_count"].Value != null)
                                    MinCount = int.Parse(node.Attributes["min_count"].Value);

                                int MaxLength = int.MaxValue;
                                if (node.Attributes["max_length"].Value != null)
                                    MaxLength = int.Parse(node.Attributes["max_length"].Value);

                                StringClass sc = new StringClass();
                                if (!sc.IsUlString(item))
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (((MinCount > item.Length) && Important) || ((MinCount > item.Length) && !Important && !string.IsNullOrEmpty(item)))
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                    TrueContinue = false;
                                }

                                if (MaxLength < item.Length)
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                    TrueContinue = false;
                                }

                            }; break;

                        case "string":
                            {
                                int MinCount = 0;
                                if (node.Attributes["min_count"].Value != null)
                                    MinCount = int.Parse(node.Attributes["min_count"].Value);

                                int MaxLength = int.MaxValue;
                                if (node.Attributes["max_length"].Value != null)
                                    MaxLength = int.Parse(node.Attributes["max_length"].Value);

                                if (((MinCount > item.Length) && Important) || ((MinCount > item.Length) && !Important && !string.IsNullOrEmpty(item)))
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                    TrueContinue = false;
                                }

                                if (MaxLength < item.Length)
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                    TrueContinue = false;
                                }

                            }; break;

                        case "number":
                            {
                                int StartRange = 0;
                                if (node.Attributes["start_range"].Value != null)
                                    StartRange = int.Parse(node.Attributes["start_range"].Value);

                                int EndRange = int.MaxValue;
                                if (node.Attributes["end_range"].Value != null)
                                    EndRange = int.Parse(node.Attributes["end_range"].Value);

                                StringClass sc = new StringClass();
                                if (!item.IsNumber())
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (StartRange > int.Parse(item))
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                    TrueContinue = false;
                                }

                                if (EndRange < int.Parse(item))
                                {
                                    WarningFieldClass.Add(cbl.Text, "el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                    TrueContinue = false;
                                }

                            }; break;
                    }

                    if (!TrueContinue)
                        break;
                }


                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                    {
                        bool InjectionFound = false;

                        if (sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items").Contains("value=" + '"' + FormData.GetValue(cbl.Text) + '"'))
                            InjectionFound = false;

                        if (InjectionFound)
                        {
                            WarningFieldClass.Add(cbl.Text, "el_warning_field");
                            EvaluateErrorList.Add(Language.GetLanguage("found_client_injection_attack_in_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label));
                            TrueContinue = false;
                        }
                    }
                    else
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("change_check_value_does_not_existed", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }
                break;
            }
        }

        private void EvaluateDropDownList(List<ListItem> FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            string Label = "a";
            if (node.Attributes["label"] != null)
            {
                Label = node.Attributes["label"].Value;
                Label = Language.GetAddOnsLanguage(Label, GlobalLanguage, Path);
            }
            else
                Label = Language.GetLanguage(Label, GlobalLanguage);

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool IsUnique = false;
            if (node.Attributes["is_unique"] != null)
                IsUnique = (node.Attributes["is_unique"].Value == "true");

            bool UnauthorizedCheck = false;
            if (node.Attributes["unauthorized_check"] != null)
                UnauthorizedCheck = (node.Attributes["unauthorized_check"].Value == "true");

            string Format = "";
            if (node.Attributes["format"] != null)
                Format = node.Attributes["format"].Value;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem dbl in FormData)
            {
                if (dbl.Text != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(dbl.Text);

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        WarningFieldClass.Add(dbl.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(FormData.GetValue(dbl.Text))))
                {
                    WarningFieldClass.Add(dbl.Text, "el_warning_field");
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(dbl.Text);

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass.Add(dbl.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                switch (Type)
                {
                    case "ul_string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            StringClass sc = new StringClass();
                            if (!sc.IsUlString(FormData.GetValue(dbl.Text)))
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData.GetValue(dbl.Text).Length) && Important) || ((MinCount > FormData.GetValue(dbl.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(dbl.Text))))
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(dbl.Text).Length)
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            if (((MinCount > FormData.GetValue(dbl.Text).Length) && Important) || ((MinCount > FormData.GetValue(dbl.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(dbl.Text))))
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(dbl.Text).Length)
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number":
                        {
                            int StartRange = 0;
                            if (node.Attributes["start_range"].Value != null)
                                StartRange = int.Parse(node.Attributes["start_range"].Value);

                            int EndRange = int.MaxValue;
                            if (node.Attributes["end_range"].Value != null)
                                EndRange = int.Parse(node.Attributes["end_range"].Value);

                            StringClass sc = new StringClass();
                            if (!FormData.GetValue(dbl.Text).IsNumber())
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData.GetValue(dbl.Text)))
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData.GetValue(dbl.Text)))
                            {
                                WarningFieldClass.Add(dbl.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                }

                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                    {
                        bool InjectionFound = true;

                        if (sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items").Contains("value=" + '"' + FormData.GetValue(dbl.Text) + '"'))
                            InjectionFound = false;

                        if (InjectionFound)
                        {
                            WarningFieldClass.Add(dbl.Text, "el_warning_field");
                            EvaluateErrorList.Add(Language.GetLanguage("found_client_injection_attack_in_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label));
                            TrueContinue = false;
                        }
                    }
                    else
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("change_check_value_does_not_existed", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                        continue;
                    }
                }
                break;
            }
        }

        private void EvaluateListBox(List<ListItem> FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            string Label = "a";
            if (node.Attributes["label"] != null)
            {
                Label = node.Attributes["label"].Value;
                Label = Language.GetAddOnsLanguage(Label, GlobalLanguage, Path);
            }
            else
                Label = Language.GetLanguage(Label, GlobalLanguage);

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool IsUnique = false;
            if (node.Attributes["is_unique"] != null)
                IsUnique = (node.Attributes["is_unique"].Value == "true");

            bool UnauthorizedCheck = false;
            if (node.Attributes["unauthorized_check"] != null)
                UnauthorizedCheck = (node.Attributes["unauthorized_check"].Value == "true");

            string Format = "";
            if (node.Attributes["format"] != null)
                Format = node.Attributes["format"].Value;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem lbx in FormData)
            {
                if (lbx.Text != Id)
                    continue;

                if ((Important && string.IsNullOrEmpty(FormData.GetValue(lbx.Text))))
                {
                    WarningFieldClass.Add(lbx.Text, "el_warning_field");
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(lbx.Text);

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass.Add(lbx.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                switch (Type)
                {
                    case "ul_string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            StringClass sc = new StringClass();
                            if (!sc.IsUlString(FormData.GetValue(lbx.Text)))
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData.GetValue(lbx.Text).Length) && Important) || ((MinCount > FormData.GetValue(lbx.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(lbx.Text))))
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(lbx.Text).Length)
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            if (((MinCount > FormData.GetValue(lbx.Text).Length) && Important) || ((MinCount > FormData.GetValue(lbx.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(lbx.Text))))
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(lbx.Text).Length)
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number":
                        {
                            int StartRange = 0;
                            if (node.Attributes["start_range"].Value != null)
                                StartRange = int.Parse(node.Attributes["start_range"].Value);

                            int EndRange = int.MaxValue;
                            if (node.Attributes["end_range"].Value != null)
                                EndRange = int.Parse(node.Attributes["end_range"].Value);

                            StringClass sc = new StringClass();
                            if (!FormData.GetValue(lbx.Text).IsNumber())
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData.GetValue(lbx.Text)))
                            {
                                WarningFieldClass.Add(lbx.Text, "el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData.GetValue(lbx.Text)))
                            {
                                WarningFieldClass.Add(lbx.Text, " el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;
                }

                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                    {
                        bool InjectionFound = true;

                        if (sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items").Contains("value=" + '"' + FormData.GetValue(lbx.Text) + '"'))
                        {
                            InjectionFound = false;
                            sd.Delete(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items");
                        }

                        if (InjectionFound)
                        {
                            WarningFieldClass.Add(lbx.Text, "el_warning_field");
                            EvaluateErrorList.Add(Language.GetLanguage("found_client_injection_attack_in_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label));

                            TrueContinue = false;
                        }
                    }
                    else
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("change_check_value_does_not_existed", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }
                break;
            }
        }

        private void EvaluateHiddenField(List<ListItem> FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            string Label = "a";
            if (node.Attributes["label"] != null)
            {
                Label = node.Attributes["label"].Value;
                Label = Language.GetAddOnsLanguage(Label, GlobalLanguage, Path);
            }
            else
                Label = Language.GetLanguage(Label, GlobalLanguage);

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool IsUnique = false;
            if (node.Attributes["is_unique"] != null)
                IsUnique = (node.Attributes["is_unique"].Value == "true");

            bool UnauthorizedCheck = false;
            if (node.Attributes["unauthorized_check"] != null)
                UnauthorizedCheck = (node.Attributes["unauthorized_check"].Value == "true");

            string Format = "";
            if (node.Attributes["format"] != null)
                Format = node.Attributes["format"].Value;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem hdn in FormData)
            {
                if (hdn.Text != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(hdn.Text);

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(hdn.Text);

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (!string.IsNullOrEmpty(Format) && !string.IsNullOrEmpty(FormData.GetValue(hdn.Text)))
                {
                    Regex re = new Regex(Format, RegexOptions.IgnoreCase);
                    string Value = FormData.GetValue(hdn.Text);

                    if (!re.IsMatch(Value))
                    {
                        string ExampleFormat = Label;
                        if (node.Attributes["format_example"] != null)
                            ExampleFormat = node.Attributes["format_example"].Value;

                        EvaluateErrorList.Add(Language.GetLanguage("please_set_value_like_asp_format_to_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp format;", ExampleFormat));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(FormData.GetValue(hdn.Text))))
                {
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                switch (Type)
                {
                    case "ul_string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            StringClass sc = new StringClass();
                            if (!sc.IsUlString(FormData.GetValue(hdn.Text)))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData.GetValue(hdn.Text).Length) && Important) || ((MinCount > FormData.GetValue(hdn.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(hdn.Text))))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(hdn.Text).Length)
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "string":
                        {
                            int MinCount = 0;
                            if (node.Attributes["min_count"].Value != null)
                                MinCount = int.Parse(node.Attributes["min_count"].Value);

                            int MaxLength = int.MaxValue;
                            if (node.Attributes["max_length"].Value != null)
                                MaxLength = int.Parse(node.Attributes["max_length"].Value);

                            if (((MinCount > FormData.GetValue(hdn.Text).Length) && Important) || ((MinCount > FormData.GetValue(hdn.Text).Length) && !Important && !string.IsNullOrEmpty(FormData.GetValue(hdn.Text))))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData.GetValue(hdn.Text).Length)
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_count;", MaxLength.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number":
                        {
                            int StartRange = 0;
                            if (node.Attributes["start_range"].Value != null)
                                StartRange = int.Parse(node.Attributes["start_range"].Value);

                            int EndRange = int.MaxValue;
                            if (node.Attributes["end_range"].Value != null)
                                EndRange = int.Parse(node.Attributes["end_range"].Value);

                            StringClass sc = new StringClass();
                            if (!FormData.GetValue(hdn.Text).IsNumber())
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData.GetValue(hdn.Text)))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData.GetValue(hdn.Text)))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                }

                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(Path.PathCustomizationForDirectoryName() + "_" + Id + "_value"))
                    {
                        bool InjectionFound = false;

                        if (FormData.GetValue(hdn.Text) != sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_value"))
                        {
                            sd.Delete(Path.PathCustomizationForDirectoryName() + "_" + Id + "_value");
                            InjectionFound = true;
                        }

                        if (InjectionFound)
                        {
                            EvaluateErrorList.Add(Language.GetLanguage("found_client_injection_attack_in_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label));
                            TrueContinue = false;
                        }
                    }
                    else
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("change_check_value_does_not_existed", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }
                break;
            }
        }

        private void EvaluateFileUpload(List<ListItem> FormData, string GlobalLanguage, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;

            string Label = "a";
            if (node.Attributes["label"] != null)
            {
                Label = node.Attributes["label"].Value;
                Label = Language.GetAddOnsLanguage(Label, GlobalLanguage, Path);
            }
            else
                Label = Language.GetLanguage(Label, GlobalLanguage);

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            string MaxFileSize = long.MaxValue.ToString();
            if (node.Attributes["max_file_size"] != null)
                MaxFileSize = node.Attributes["max_file_size"].Value;

            bool UnauthorizedCheck = false;
            if (node.Attributes["unauthorized_check"] != null)
                UnauthorizedCheck = (node.Attributes["unauthorized_check"].Value == "true");

            foreach (ListItem upd in FormData)
            {
                if (upd.Text != Id)
                    continue;

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData.GetValue(upd.Text);

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass.Add(upd.Text, "el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (Important && string.IsNullOrEmpty(FormData.GetValue(upd.Text)))
                {
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (Important && (FormData.GetValue(upd.Text).Length > long.Parse(MaxFileSize))) // ANSI Standard Encoding
                {
                    EvaluateErrorList.Add(Language.GetLanguage("file_is_biger_than_as_maximum_file_size_in_asp_field_please_select_file_less_than_asp_size", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_file_size;", MaxFileSize.ToBitSizeTuning()));
                    TrueContinue = false;
                }

                break;
            }
        }

        public List<ListItem> ImportantInputClass = new List<ListItem>();
        public List<ListItem> ImportantInputAttribute = new List<ListItem>();

        public List<ListItem> SetImportantField(List<ListItem> NameValue, bool CreateClientInjectionCheck = false, string Path = "", string Category = "")
        {
            XmlDocument ValidationDocument = new XmlDocument();
            ValidationDocument.Load(StaticObject.ServerMapPath(Path + "App_Data/validation_list/validation.xml"));

            XmlNodeList Validation = ValidationDocument.SelectSingleNode("validation_root/validation_list").ChildNodes;

            foreach (XmlNode node in Validation)
            {
                if (Category != "*")
                {
                    if (node.Attributes["category"] != null)
                    {
                        if (node.Attributes["category"].Value != Category)
                            continue;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Category))
                            continue;
                    }
                }

                string ControlName = node.Name;

                ImportantInputClass.Add(node.Attributes["id"].Value, "");
                ImportantInputAttribute.Add(node.Attributes["id"].Value, "");

                switch (ControlName)
                {
                    case "TextBox":
                        {
                            SetTextBoxImportant(NameValue, node);
                        }
                        break;

                    case "CheckBoxList":
                        {
                            SetCheckBoxListImportant(NameValue, node, CreateClientInjectionCheck, Path);
                        }
                        break;

                    case "DropDownList":
                        {
                            SetDropDownListImportant(NameValue, node, CreateClientInjectionCheck, Path);
                        }
                        break;

                    case "ListBox":
                        {
                            SetListBoxImportant(NameValue, node, CreateClientInjectionCheck, Path);
                        }
                        break;

                    case "HiddenField":
                        {
                            SetHiddenFieldImportant(NameValue, node, CreateClientInjectionCheck, Path);
                        }
                        break;

                    case "FileUpload":
                        {
                            SetFileUploadImportant(NameValue, node);
                        }
                        break;
                }
            }

            return NameValue;
        }

        private void SetTextBoxImportant(List<ListItem> NameValue, XmlNode node)
        {
            string Id = node.Attributes["id"].Value;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            foreach (ListItem tc in NameValue)
            {
                if (tc.Text != Id)
                    continue;

                if (Important)
                    ImportantInputClass = ImportantInputClass.SetValue(tc.Text, " el_warning_field");

                switch (Type)
                {
                    case "ul_string":
                        {
                            if (node.Attributes["max_length"] == null)
                                break;

                            string MaxLength = node.Attributes["max_length"].Value;
                            ImportantInputAttribute = ImportantInputAttribute.SetValue(tc.Text, tc.Value + "maxlength=" + '"' + MaxLength + '"');
                        }
                        break;

                    case "string":
                        {
                            if (node.Attributes["max_length"] == null)
                                break;

                            string MaxLength = node.Attributes["max_length"].Value;
                            ImportantInputAttribute = ImportantInputAttribute.SetValue(tc.Text, tc.Value + "maxlength=" + '"' + MaxLength + '"');
                        }
                        break;

                    case "number":
                        {
                            string StartRange = "";
                            if (node.Attributes["start_range"] != null)
                            {
                                StartRange = node.Attributes["start_range"].Value;
                                ImportantInputAttribute = ImportantInputAttribute.SetValue(tc.Text, tc.Value + "min=" + '"' + StartRange + '"');
                            }

                            string EndRange = "";
                            if (node.Attributes["end_range"] != null)
                            {
                                EndRange = node.Attributes["end_range"].Value;
                                ImportantInputAttribute = ImportantInputAttribute.SetValue(tc.Text, tc.Value + " max=" + '"' + EndRange + '"');
                            }
                        }
                        break;
                }

                break;
            }
        }

        private void SetCheckBoxListImportant(List<ListItem> NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem cbl in NameValue)
            {
                if (cbl.Text != Id)
                    continue;

                if (Important)
                    ImportantInputClass = ImportantInputClass.SetValue(cbl.Text, " el_important_field");

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items", NameValue.GetValue(cbl.Text));
                }

                break;
            }
        }

        private void SetDropDownListImportant(List<ListItem> NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem dbl in NameValue)
            {
                if (dbl.Text != Id)
                    continue;

                if (Important)
                    ImportantInputClass = ImportantInputClass.SetValue(dbl.Text, " el_warning_field");

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items", NameValue.GetValue(dbl.Text));
                }

                break;
            }
        }

        private void SetListBoxImportant(List<ListItem> NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem lbx in NameValue)
            {
                if (lbx.Text != Id)
                    continue;

                if (Important)
                    ImportantInputClass = ImportantInputClass.SetValue(lbx.Text, " el_important_field");

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items", NameValue.GetValue(lbx.Text));
                }

                break;
            }
        }

        private void SetHiddenFieldImportant(List<ListItem> NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListItem hdn in NameValue)
            {
                if (hdn.Text != Id)
                    continue;

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_value", NameValue.GetValue(hdn.Text));
                }

                break;
            }
        }

        private void SetFileUploadImportant(List<ListItem> NameValue, XmlNode node)
        {
            string Id = node.Attributes["id"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            foreach (ListItem upd in NameValue)
            {
                if (upd.Text != Id)
                    continue;

                if (Important)
                    ImportantInputClass = ImportantInputClass.SetValue(upd.Text, " el_important_field");

                break;
            }
        }
    }
}