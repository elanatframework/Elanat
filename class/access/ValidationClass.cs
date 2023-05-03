using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ValidationClass
    {
        public bool TrueContinue = true;
        public List<string> EvaluateErrorList = new List<string>();

        public System.Web.UI.Page EvaluateField(System.Web.UI.Page Page, string GlobalLanguage, bool ReadClientInjectionCheck = true, string Category = null, string Path = "")
        {
            XmlDocument ValidationDocument = new XmlDocument();
            ValidationDocument.Load(HttpContext.Current.Server.MapPath(Path + "App_Data/validation_list/validation.xml"));

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
                            Page = EvaluateTextBox(Page, GlobalLanguage, node, Path);
                        } break;

                    case "CheckBoxList":
                        {
                            Page = EvaluateCheckBoxList(Page, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "DropDownList":
                        {
                            Page = EvaluateDropDownList(Page, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "ListBox":
                        {
                            Page = EvaluateListBox(Page, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "HiddenField":
                        {
                            Page = EvaluateHiddenField(Page, GlobalLanguage, node, ReadClientInjectionCheck, Path);
                        } break;

                    case "FileUpload":
                        {
                            Page = EvaluateFileUpload(Page, GlobalLanguage, node, Path);
                        }
                        break;
                }
            }

            return Page;
        }


        public NameValueCollection WarningFieldClass = new NameValueCollection();

        // Overload
        public void EvaluateField(NameValueCollection FormData, string GlobalLanguage, bool ReadClientInjectionCheck = true, string Category = null, string Path = "")
        {
            XmlDocument ValidationDocument = new XmlDocument();
            ValidationDocument.Load(HttpContext.Current.Server.MapPath(Path + "App_Data/validation_list/validation.xml"));

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

                WarningFieldClass.Add(ControlName, "");

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

                    string Id = node.Attributes["id"].Value;
                    string ControlName = node.Name;
                }
        }

        private System.Web.UI.Page EvaluateTextBox(System.Web.UI.Page Page, string  GlobalLanguage, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (TextBox tc in ExtensionMethodsClass.AllControls(Page).OfType<TextBox>())
            {
                if (tc.ID != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = tc.Text;

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = tc.Text;

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (!string.IsNullOrEmpty(Format) && !string.IsNullOrEmpty(tc.Text))
                {
                    Regex re = new Regex(Format, RegexOptions.IgnoreCase);
                    string Value = tc.Text;

                    if (!re.IsMatch(Value))
                    {
                        string ExampleFormat = Label;
                        if (node.Attributes["format_example"] != null)
                            ExampleFormat = node.Attributes["format_example"].Value;

                        tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_value_like_asp_format_to_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp format;", ExampleFormat));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(tc.Text)))
                {
                    tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
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
                            if (!sc.IsUlString(tc.Text))
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > tc.Text.Length) && Important) || ((MinCount > tc.Text.Length) && !Important && !string.IsNullOrEmpty(tc.Text)))
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < tc.Text.Length)
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
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

                            if (((MinCount > tc.Text.Length) && Important) || ((MinCount > tc.Text.Length) && !Important && !string.IsNullOrEmpty(tc.Text)))
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < tc.Text.Length)
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
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
                            if (!tc.Text.IsNumber())
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(tc.Text))
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(tc.Text))
                            {
                                tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number_list":
                        {
                            foreach(string text in tc.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                int StartRange = 0;
                                if (node.Attributes["start_range"].Value != null)
                                    StartRange = int.Parse(node.Attributes["start_range"].Value);

                                int EndRange = int.MaxValue;
                                if (node.Attributes["end_range"].Value != null)
                                    EndRange = int.Parse(node.Attributes["end_range"].Value);

                                StringClass sc = new StringClass();
                                if (!tc.Text.IsNumber())
                                {
                                    tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (StartRange > int.Parse(tc.Text))
                                {
                                    tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                    TrueContinue = false;
                                }

                                if (EndRange < int.Parse(tc.Text))
                                {
                                    tc.CssClass = tc.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                    TrueContinue = false;
                                }

                            }
                        }; break;
                }

                break;
            }
            return Page;
        }

        // Overload
        private void EvaluateTextBox(NameValueCollection FormData, string GlobalLanguage, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (string tc in FormData)
            {
                if (tc != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[tc];

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        WarningFieldClass[tc] = " el_warning_field";
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[tc];

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass[tc] = " el_warning_field";
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (!string.IsNullOrEmpty(Format) && !string.IsNullOrEmpty(FormData[tc]))
                {
                    Regex re = new Regex(Format, RegexOptions.IgnoreCase);
                    string Value = FormData[tc];

                    if (!re.IsMatch(Value))
                    {
                        string ExampleFormat = Label;
                        if (node.Attributes["format_example"] != null)
                            ExampleFormat = node.Attributes["format_example"].Value;

                        WarningFieldClass[tc] = " el_warning_field";
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_value_like_asp_format_to_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp format;", ExampleFormat));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(FormData[tc])))
                {
                    WarningFieldClass[tc] = " el_warning_field";
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
                            if (!sc.IsUlString(FormData[tc]))
                            {
                                WarningFieldClass[tc] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData[tc].Length) && Important) || ((MinCount > FormData[tc].Length) && !Important && !string.IsNullOrEmpty(FormData[tc])))
                            {
                                WarningFieldClass[tc] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[tc].Length)
                            {
                                WarningFieldClass[tc] = " el_warning_field";
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

                            if (((MinCount > FormData[tc].Length) && Important) || ((MinCount > FormData[tc].Length) && !Important && !string.IsNullOrEmpty(FormData[tc])))
                            {
                                WarningFieldClass[tc] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[tc].Length)
                            {
                                WarningFieldClass[tc] = " el_warning_field";
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
                            if (!FormData[tc].IsNumber())
                            {
                                WarningFieldClass[tc] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData[tc]))
                            {
                                WarningFieldClass[tc] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData[tc]))
                            {
                                WarningFieldClass[tc] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                    case "number_list":
                        {
                            foreach (string text in FormData[tc].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                int StartRange = 0;
                                if (node.Attributes["start_range"].Value != null)
                                    StartRange = int.Parse(node.Attributes["start_range"].Value);

                                int EndRange = int.MaxValue;
                                if (node.Attributes["end_range"].Value != null)
                                    EndRange = int.Parse(node.Attributes["end_range"].Value);

                                StringClass sc = new StringClass();
                                if (!FormData[tc].IsNumber())
                                {
                                    WarningFieldClass[tc] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (StartRange > int.Parse(FormData[tc]))
                                {
                                    WarningFieldClass[tc] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                    TrueContinue = false;
                                }

                                if (EndRange < int.Parse(FormData[tc]))
                                {
                                    WarningFieldClass[tc] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                    TrueContinue = false;
                                }

                            }
                        }; break;
                }

                break;
            }
        }

        private System.Web.UI.Page EvaluateCheckBoxList(System.Web.UI.Page Page, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (CheckBoxList cbl in ExtensionMethodsClass.AllControls(Page).OfType<CheckBoxList>())
            {
                if (cbl.ID != Id)
                    continue;

                if (Important && (cbl.Items.Count > 0))
                {
                    bool ImportantListFillChecker = false;

                    foreach (ListItem item in cbl.Items)
                    {
                        if (item.Selected == true)
                        {
                            ImportantListFillChecker = true;
                            break;
                        }
                    }

                    if (!ImportantListFillChecker)
                    {
                        cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;

                    foreach (ListItem item in cbl.Items)
                    {
                        if (item.Selected != true)
                            continue;

                        string Value = item.Value;

                        if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                        {
                            cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                            EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                            TrueContinue = false;
                            break;
                        }
                    }
                }

                foreach (ListItem item in cbl.Items)
                {
                    if (item.Selected != true)
                        continue;

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
                                if (!sc.IsUlString(item.Value))
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (((MinCount > item.Value.Length) && Important) || ((MinCount > item.Value.Length) && !Important && !string.IsNullOrEmpty(item.Value)))
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                    TrueContinue = false;
                                }

                                if (MaxLength < item.Value.Length)
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
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

                                if (((MinCount > item.Value.Length) && Important) || ((MinCount > item.Value.Length) && !Important && !string.IsNullOrEmpty(item.Value)))
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                    TrueContinue = false;
                                }

                                if (MaxLength < item.Value.Length)
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
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
                                if (!item.Value.IsNumber())
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (StartRange > int.Parse(item.Value))
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                    TrueContinue = false;
                                }

                                if (EndRange < int.Parse(item.Value))
                                {
                                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
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

                    if (sd.Exist(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                    {
                        bool InjectionFound = false;
                        int i = 0;

                        foreach (ListItem lic in sd.GetListItemCollection(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                            if (cbl.Items[i++].Value != lic.Value)
                            {
                                InjectionFound = true;
                                sd.Delete(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items");

                                break;
                            }

                        if (InjectionFound)
                        {
                            cbl.CssClass = cbl.CssClass.AddHtmlClass("el_warning_field");
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

            return Page;
        }

        // Overload
        private void EvaluateCheckBoxList(NameValueCollection FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (string cbl in FormData)
            {
                if (cbl != Id)
                    continue;

                if (Important && (FormData[cbl].Split('$').ToList().Count > 0))
                {
                    bool ImportantListFillChecker = false;

                    foreach (string item in FormData[cbl].Split('$').ToList())
                    {
                        ImportantListFillChecker = true;
                        break;
                    }

                    if (!ImportantListFillChecker)
                    {
                        WarningFieldClass[cbl] = " el_warning_field";
                        EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;

                    foreach (string item in FormData[cbl].Split('$').ToList())
                    {
                        string Value = item;

                        if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                        {
                            WarningFieldClass[cbl] = " el_warning_field";
                            EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                            TrueContinue = false;
                            break;
                        }
                    }
                }

                foreach (string item in FormData[cbl].Split('$').ToList())
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
                                    WarningFieldClass[cbl] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (((MinCount > item.Length) && Important) || ((MinCount > item.Length) && !Important && !string.IsNullOrEmpty(item)))
                                {
                                    WarningFieldClass[cbl] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                    TrueContinue = false;
                                }

                                if (MaxLength < item.Length)
                                {
                                    WarningFieldClass[cbl] = " el_warning_field";
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
                                    WarningFieldClass[cbl] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                    TrueContinue = false;
                                }

                                if (MaxLength < item.Length)
                                {
                                    WarningFieldClass[cbl] = " el_warning_field";
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
                                    WarningFieldClass[cbl] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                    TrueContinue = false;
                                }

                                if (StartRange > int.Parse(item))
                                {
                                    WarningFieldClass[cbl] = " el_warning_field";
                                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                    TrueContinue = false;
                                }

                                if (EndRange < int.Parse(item))
                                {
                                    WarningFieldClass[cbl] = " el_warning_field";
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

                        if (sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items").Contains("value=" + '"' + FormData[cbl] + '"'))
                            InjectionFound = false;

                        if (InjectionFound)
                        {
                            WarningFieldClass[cbl] = " el_warning_field";
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

        private System.Web.UI.Page EvaluateDropDownList(System.Web.UI.Page Page, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (CheckBoxList dbl in ExtensionMethodsClass.AllControls(Page).OfType<CheckBoxList>())
            {
                if (dbl.ID != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = dbl.SelectedValue;

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(dbl.SelectedValue)))
                {
                    dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = dbl.SelectedValue;

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
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
                            if (!sc.IsUlString(dbl.SelectedValue))
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > dbl.SelectedValue.Length) && Important) || ((MinCount > dbl.SelectedValue.Length) && !Important && !string.IsNullOrEmpty(dbl.SelectedValue)))
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < dbl.SelectedValue.Length)
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
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

                            if (((MinCount > dbl.SelectedValue.Length) && Important) || ((MinCount > dbl.SelectedValue.Length) && !Important && !string.IsNullOrEmpty(dbl.SelectedValue)))
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < dbl.SelectedValue.Length)
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
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
                            if (!dbl.SelectedValue.IsNumber())
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(dbl.SelectedValue))
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(dbl.SelectedValue))
                            {
                                dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                }

                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                    {
                        bool InjectionFound = true;

                        foreach (ListItem lic in sd.GetListItemCollection(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                            if (dbl.SelectedValue == lic.Value)
                            {
                                InjectionFound = false;
                                sd.Delete(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items");

                                break;
                            }

                        if (InjectionFound)
                        {
                            dbl.CssClass = dbl.CssClass.AddHtmlClass("el_warning_field");
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

            return Page;
        }

        // Overload
        private void EvaluateDropDownList(NameValueCollection FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (string dbl in FormData)
            {
                if (dbl != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[dbl];

                    if (common.ExistValueToColumnCheck(TableName, ColumnName, Value))
                    {
                        WarningFieldClass[dbl] = " el_warning_field";
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(FormData[dbl])))
                {
                    WarningFieldClass[dbl] = " el_warning_field";
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[dbl];

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass[dbl] = " el_warning_field";
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
                            if (!sc.IsUlString(FormData[dbl]))
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData[dbl].Length) && Important) || ((MinCount > FormData[dbl].Length) && !Important && !string.IsNullOrEmpty(FormData[dbl])))
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[dbl].Length)
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
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

                            if (((MinCount > FormData[dbl].Length) && Important) || ((MinCount > FormData[dbl].Length) && !Important && !string.IsNullOrEmpty(FormData[dbl])))
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[dbl].Length)
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
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
                            if (!FormData[dbl].IsNumber())
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData[dbl]))
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData[dbl]))
                            {
                                WarningFieldClass[dbl] = " el_warning_field";
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

                        if (sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items").Contains("value=" + '"' + FormData[dbl] + '"'))
                            InjectionFound = false;

                        if (InjectionFound)
                        {
                            WarningFieldClass[dbl] = " el_warning_field";
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

        private System.Web.UI.Page EvaluateListBox(System.Web.UI.Page Page, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (ListBox lbx in ExtensionMethodsClass.AllControls(Page).OfType<ListBox>())
            {
                if (lbx.ID != Id)
                    continue;

                if ((Important && string.IsNullOrEmpty(lbx.SelectedValue)))
                {
                    lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = lbx.SelectedValue;

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
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
                            if (!sc.IsUlString(lbx.SelectedValue))
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > lbx.SelectedValue.Length) && Important) || ((MinCount > lbx.SelectedValue.Length) && !Important && !string.IsNullOrEmpty(lbx.SelectedValue)))
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < lbx.SelectedValue.Length)
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
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

                            if (((MinCount > lbx.SelectedValue.Length) && Important) || ((MinCount > lbx.SelectedValue.Length) && !Important && !string.IsNullOrEmpty(lbx.SelectedValue)))
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < lbx.SelectedValue.Length)
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
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
                            if (!lbx.SelectedValue.IsNumber())
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(lbx.SelectedValue))
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(lbx.SelectedValue))
                            {
                                lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;
                }

                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                    {
                        bool InjectionFound = true;

                        foreach (ListItem lic in sd.GetListItemCollection(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items"))
                            if (lbx.SelectedValue == lic.Value)
                            {
                                InjectionFound = false;
                                sd.Delete(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items");

                                break;
                            }

                        if (InjectionFound)
                        {
                            lbx.CssClass = lbx.CssClass.AddHtmlClass("el_warning_field");
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

            return Page;
        }

        // Overload
        private void EvaluateListBox(NameValueCollection FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (string lbx in FormData)
            {
                if (lbx != Id)
                    continue;

                if ((Important && string.IsNullOrEmpty(FormData[lbx])))
                {
                    WarningFieldClass[lbx] = " el_warning_field";
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[lbx];

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass[lbx] = " el_warning_field";
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
                            if (!sc.IsUlString(FormData[lbx]))
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData[lbx].Length) && Important) || ((MinCount > FormData[lbx].Length) && !Important && !string.IsNullOrEmpty(FormData[lbx])))
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[lbx].Length)
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
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

                            if (((MinCount > FormData[lbx].Length) && Important) || ((MinCount > FormData[lbx].Length) && !Important && !string.IsNullOrEmpty(FormData[lbx])))
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[lbx].Length)
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
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
                            if (!FormData[lbx].IsNumber())
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData[lbx]))
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData[lbx]))
                            {
                                WarningFieldClass[lbx] = " el_warning_field";
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

                        if (sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items").Contains("value=" + '"' + FormData[lbx] + '"'))
                        {
                            InjectionFound = false;
                            sd.Delete(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items");
                        }

                        if (InjectionFound)
                        {
                            WarningFieldClass[lbx] = " el_warning_field";
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

        private System.Web.UI.Page EvaluateHiddenField(System.Web.UI.Page Page, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (HiddenField hdn in ExtensionMethodsClass.AllControls(Page).OfType<HiddenField>())
            {
                if (hdn.ID != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = hdn.Value;

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
                    string Value = hdn.Value;

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (!string.IsNullOrEmpty(Format) && !string.IsNullOrEmpty(hdn.Value))
                {
                    Regex re = new Regex(Format, RegexOptions.IgnoreCase);
                    string Value = hdn.Value;

                    if (!re.IsMatch(Value))
                    {
                        string ExampleFormat = Label;
                        if (node.Attributes["format_example"] != null)
                            ExampleFormat = node.Attributes["format_example"].Value;

                        EvaluateErrorList.Add(Language.GetLanguage("please_set_value_like_asp_format_to_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp format;", ExampleFormat));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(hdn.Value)))
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
                            if (!sc.IsUlString(hdn.Value))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > hdn.Value.Length) && Important) || ((MinCount > hdn.Value.Length) && !Important && !string.IsNullOrEmpty(hdn.Value)))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < hdn.Value.Length)
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

                            if (((MinCount > hdn.Value.Length) && Important) || ((MinCount > hdn.Value.Length) && !Important && !string.IsNullOrEmpty(hdn.Value)))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < hdn.Value.Length)
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
                            if (!hdn.Value.IsNumber())
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(hdn.Value))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(hdn.Value))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_less_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp end_range;", EndRange.ToString()));
                                TrueContinue = false;
                            }

                        }; break;

                }

                if (ReadClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();

                    if (sd.Exist(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_value"))
                    {
                        bool InjectionFound = false;

                        if (hdn.Value != sd.Get(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_value"))
                        {
                            sd.Delete(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_value");
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
            return Page;
        }

        // Overload
        private void EvaluateHiddenField(NameValueCollection FormData, string GlobalLanguage, XmlNode node, bool ReadClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (string hdn in FormData)
            {
                if (hdn != Id)
                    continue;

                if (IsUnique)
                {
                    DataUse.Common common = new DataUse.Common();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[hdn];

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
                    string Value = FormData[hdn];

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (!string.IsNullOrEmpty(Format) && !string.IsNullOrEmpty(FormData[hdn]))
                {
                    Regex re = new Regex(Format, RegexOptions.IgnoreCase);
                    string Value = FormData[hdn];

                    if (!re.IsMatch(Value))
                    {
                        string ExampleFormat = Label;
                        if (node.Attributes["format_example"] != null)
                            ExampleFormat = node.Attributes["format_example"].Value;

                        EvaluateErrorList.Add(Language.GetLanguage("please_set_value_like_asp_format_to_asp_field", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp format;", ExampleFormat));
                        TrueContinue = false;
                    }
                }

                if ((Important && string.IsNullOrEmpty(FormData[hdn])))
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
                            if (!sc.IsUlString(FormData[hdn]))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_continuous_text", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (((MinCount > FormData[hdn].Length) && Important) || ((MinCount > FormData[hdn].Length) && !Important && !string.IsNullOrEmpty(FormData[hdn])))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[hdn].Length)
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

                            if (((MinCount > FormData[hdn].Length) && Important) || ((MinCount > FormData[hdn].Length) && !Important && !string.IsNullOrEmpty(FormData[hdn])))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_count", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp minimum_count;", MinCount.ToString()));
                                TrueContinue = false;
                            }

                            if (MaxLength < FormData[hdn].Length)
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
                            if (!FormData[hdn].IsNumber())
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_number", GlobalLanguage).Replace("$_asp field_name;", Label));
                                TrueContinue = false;
                            }

                            if (StartRange > int.Parse(FormData[hdn]))
                            {
                                EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_by_more_than_asp_number", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp start_range;", StartRange.ToString()));
                                TrueContinue = false;
                            }

                            if (EndRange < int.Parse(FormData[hdn]))
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

                        if (FormData[hdn] != sd.Get(Path.PathCustomizationForDirectoryName() + "_" + Id + "_value"))
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

        private System.Web.UI.Page EvaluateFileUpload(System.Web.UI.Page Page, string GlobalLanguage, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (FileUpload upd in ExtensionMethodsClass.AllControls(Page).OfType<FileUpload>())
            {
                if (upd.ID != Id)
                    continue;

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = upd.FileName;

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        upd.CssClass = upd.CssClass.AddHtmlClass("el_warning_field");
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (Important && !upd.HasFile)
                {
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (Important && (upd.PostedFile.ContentLength > long.Parse(MaxFileSize)))
                {
                    EvaluateErrorList.Add(Language.GetLanguage("file_is_biger_than_as_maximum_file_size_in_asp_field_please_select_file_less_than_asp_size", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_file_size;", MaxFileSize.ToBitSizeTuning()));
                    TrueContinue = false;
                }

                break;
            }
            return Page;
        }

        // Overload
        private void EvaluateFileUpload(NameValueCollection FormData, string GlobalLanguage, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

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

            foreach (string upd in FormData)
            {
                if (upd != Id)
                    continue;

                if (UnauthorizedCheck)
                {
                    Security sc = new Security();

                    string TableName = node.Attributes["table_name"].Value;
                    string ColumnName = node.Attributes["column_name"].Value;
                    string Value = FormData[upd];

                    if (sc.IsUnauthorizedValue(TableName, ColumnName, Value, Path))
                    {
                        WarningFieldClass[upd] = " el_warning_field";
                        EvaluateErrorList.Add(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_unauthorized", GlobalLanguage).Replace("$_asp field_name;", Label));
                        TrueContinue = false;
                    }
                }

                if (Important && string.IsNullOrEmpty(FormData[upd]))
                {
                    EvaluateErrorList.Add(Language.GetLanguage("please_fill_asp_field_because_this_is_necessary", GlobalLanguage).Replace("$_asp field_name;", Label));
                    TrueContinue = false;
                }

                if (Important && (FormData[upd].Length > long.Parse(MaxFileSize))) // ANSI Standard Encoding
                {
                    EvaluateErrorList.Add(Language.GetLanguage("file_is_biger_than_as_maximum_file_size_in_asp_field_please_select_file_less_than_asp_size", GlobalLanguage).Replace("$_asp field_name;", Label).Replace("$_asp maximum_file_size;", MaxFileSize.ToBitSizeTuning()));
                    TrueContinue = false;
                }

                break;
            }
        }

        public System.Web.UI.Page SetImportantField(System.Web.UI.Page Page, bool CreateClientInjectionCheck = false, string Path = "", string Category = "", List<string> ControlList = null)
        {
            XmlDocument ValidationDocument = new XmlDocument();
            ValidationDocument.Load(HttpContext.Current.Server.MapPath(Path + "App_Data/validation_list/validation.xml"));

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

                switch (ControlName)
                {
                    case "TextBox":
                        {
                            Page = SetTextBoxImportant(Page, node);
                        } break;

                    case "CheckBoxList":
                        {
                            Page = SetCheckBoxListImportant(Page, node, CreateClientInjectionCheck);
                        } break;

                    case "DropDownList":
                        {
                            Page = SetDropDownListImportant(Page, node, CreateClientInjectionCheck);
                        } break;

                    case "ListBox":
                        {
                            Page = SetListBoxImportant(Page, node, CreateClientInjectionCheck);
                        } break;

                    case "HiddenField":
                        {
                            Page = SetHiddenFieldImportant(Page, node, CreateClientInjectionCheck);
                        } break;

                    case "FileUpload":
                        {
                            Page = SetFileUploadImportant(Page, node);
                        } break;
                }
            }

            return Page;
        }


        public NameValueCollection ImportantInputClass = new NameValueCollection();
        public NameValueCollection ImportantInputAttribute = new NameValueCollection();

        // Overload
        public NameValueCollection SetImportantField(NameValueCollection NameValue, bool CreateClientInjectionCheck = false, string Path = "", string Category = "")
        {
            XmlDocument ValidationDocument = new XmlDocument();
            ValidationDocument.Load(HttpContext.Current.Server.MapPath(Path + "App_Data/validation_list/validation.xml"));

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

                ImportantInputClass.Add(ControlName, "");
                ImportantInputAttribute.Add(ControlName, "");

                switch (ControlName)
                {
                    case "TextBox":
                        {
                            SetTextBoxImportant(NameValue, node, Path);
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

        private System.Web.UI.Page SetTextBoxImportant(System.Web.UI.Page Page, XmlNode node)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            foreach (TextBox tc in ExtensionMethodsClass.AllControls(Page).OfType<TextBox>())
            {
                if (tc.ID != Id)
                    continue;

                if (Important)
                    tc.CssClass = tc.CssClass.AddHtmlClass("el_important_field");

                switch (Type)
                {
                    case "ul_string":
                        {
                            if (node.Attributes["max_length"] == null)
                                break;

                            string MaxLength = node.Attributes["max_length"].Value;
                            tc.Attributes.Add("maxlength", MaxLength);
                        } break;

                    case "string":
                        {
                            if (node.Attributes["max_length"] == null)
                                break;

                            string MaxLength = node.Attributes["max_length"].Value;
                            tc.Attributes.Add("maxlength", MaxLength);
                        } break;

                    case "number":
                        {
                            string StartRange = "";
                            if (node.Attributes["start_range"] != null)
                            {
                                StartRange = node.Attributes["start_range"].Value;
                                tc.Attributes.Add("min", StartRange);
                            }

                            string EndRange = "";
                            if (node.Attributes["end_range"] != null)
                            {
                                EndRange = node.Attributes["end_range"].Value;
                                tc.Attributes.Add("max", EndRange);
                            }
                        } break;
                }

                break;
            }

            return Page;
        }

        // Overload
        private void SetTextBoxImportant(NameValueCollection NameValue, XmlNode node, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            foreach (string tc in NameValue)
            {
                if (tc != Id)
                    continue;

                if (Important)
                    ImportantInputClass[tc] = " el_important_field";

                switch (Type)
                {
                    case "ul_string":
                        {
                            if (node.Attributes["max_length"] == null)
                                break;

                            string MaxLength = node.Attributes["max_length"].Value;
                            ImportantInputAttribute[tc] += "maxlength=" + '"' + MaxLength + '"';
                        }
                        break;

                    case "string":
                        {
                            if (node.Attributes["max_length"] == null)
                                break;

                            string MaxLength = node.Attributes["max_length"].Value;
                            ImportantInputAttribute[tc] += "maxlength=" + '"' + MaxLength + '"';
                        }
                        break;

                    case "number":
                        {
                            string StartRange = "";
                            if (node.Attributes["start_range"] != null)
                            {
                                StartRange = node.Attributes["start_range"].Value;
                                ImportantInputAttribute[tc] += "min=" + '"' + StartRange + '"';
                            }

                            string EndRange = "";
                            if (node.Attributes["end_range"] != null)
                            {
                                EndRange = node.Attributes["end_range"].Value;
                                ImportantInputAttribute[tc] += " max=" + '"' + EndRange + '"';
                            }
                        }
                        break;
                }

                break;
            }
        }

        private System.Web.UI.Page SetCheckBoxListImportant(System.Web.UI.Page Page, XmlNode node, bool CreateClientInjectionCheck)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (CheckBoxList cbl in ExtensionMethodsClass.AllControls(Page).OfType<CheckBoxList>())
            {
                if (cbl.ID != Id)
                    continue;

                if (Important)
                    cbl.CssClass = cbl.CssClass.AddHtmlClass("el_important_field");

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.SetListItemCollection(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items", cbl.Items);
                }

                break;
            }

            return Page;
        }

        // Overload
        private void SetCheckBoxListImportant(NameValueCollection NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (string cbl in NameValue)
            {
                if (cbl != Id)
                    continue;

                if (Important)
                    ImportantInputClass[cbl] = " el_important_field";

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items", NameValue[cbl]);
                }

                break;
            }
        }

        private System.Web.UI.Page SetDropDownListImportant(System.Web.UI.Page Page, XmlNode node, bool CreateClientInjectionCheck)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (DropDownList dbl in ExtensionMethodsClass.AllControls(Page).OfType<DropDownList>())
            {
                if (dbl.ID != Id)
                    continue;

                if (Important)
                    dbl.CssClass = dbl.CssClass.AddHtmlClass("el_important_field");

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.SetListItemCollection(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items", dbl.Items);
                }

                break;
            }

            return Page;
        }

        // Overload
        private void SetDropDownListImportant(NameValueCollection NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (string dbl in NameValue)
            {
                if (dbl != Id)
                    continue;

                if (Important)
                    ImportantInputClass[dbl] = " el_important_field";

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items", NameValue[dbl]);
                }

                break;
            }
        }

        private System.Web.UI.Page SetListBoxImportant(System.Web.UI.Page Page, XmlNode node, bool CreateClientInjectionCheck)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (ListBox lbx in ExtensionMethodsClass.AllControls(Page).OfType<ListBox>())
            {
                if (lbx.ID != Id)
                    continue;

                if (Important)
                    lbx.CssClass = lbx.CssClass.AddHtmlClass("el_important_field");

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.SetListItemCollection(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_items", lbx.Items);
                }

                break;
            }

            return Page;
        }

        // Overload
        private void SetListBoxImportant(NameValueCollection NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            string Type = "string";
            if (node.Attributes["type"] != null)
                Type = node.Attributes["type"].Value;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (string lbx in NameValue)
            {
                if (lbx != Id)
                    continue;

                if (Important)
                    ImportantInputClass[lbx] = " el_important_field";

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_items", NameValue[lbx]);
                }

                break;
            }
        }

        private System.Web.UI.Page SetHiddenFieldImportant(System.Web.UI.Page Page, XmlNode node, bool CreateClientInjectionCheck)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (HiddenField hdn in ExtensionMethodsClass.AllControls(Page).OfType<HiddenField>())
            {
                if (hdn.ID != Id)
                    continue;

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(System.IO.Path.GetDirectoryName(Page.AppRelativeVirtualPath).Remove(0, 2).PathCustomizationForDirectoryName() + "_" + Id + "_value", hdn.Value);
                }

                break;
            }

            return Page;
        }

        // Overload
        private void SetHiddenFieldImportant(NameValueCollection NameValue, XmlNode node, bool CreateClientInjectionCheck, string Path)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            bool ClientInjectionCheck = false;
            if (node.Attributes["client_injection_check"] != null)
                ClientInjectionCheck = (node.Attributes["client_injection_check"].Value == "true");

            foreach (string hdn in NameValue)
            {
                if (hdn != Id)
                    continue;

                if (CreateClientInjectionCheck && ClientInjectionCheck)
                {
                    SessionData sd = new SessionData();
                    sd.Set(Path.PathCustomizationForDirectoryName() + "_" + Id + "_value", NameValue[hdn]);
                }

                break;
            }
        }

        private System.Web.UI.Page SetFileUploadImportant(System.Web.UI.Page Page, XmlNode node)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            foreach (FileUpload upd in ExtensionMethodsClass.AllControls(Page).OfType<FileUpload>())
            {
                if (upd.ID != Id)
                    continue;

                if (Important)
                    upd.CssClass = upd.CssClass.AddHtmlClass("el_important_field");

                break;
            }

            return Page;
        }

        // Overload
        private void SetFileUploadImportant(NameValueCollection NameValue, XmlNode node)
        {
            string Id = node.Attributes["id"].Value;
            string ControlName = node.Name;

            bool Important = false;
            if (node.Attributes["important"] != null)
                Important = (node.Attributes["important"].Value == "true");

            foreach (string upd in NameValue)
            {
                if (upd != Id)
                    continue;

                if (Important)
                    ImportantInputClass[upd] = " el_important_field";

                break;
            }
        }
    }
}