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
    public static class ExtensionMethodsClass
    {
        public static bool MatchByCaptcha(this string Value)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.CaptchaReleaseCount > 0)
            {
                ccoc.CaptchaReleaseCount--;
                return true;
            }

            if (HttpContext.Current.Session["el_captcha"] == null)
                return false;

            string CaptchaValue = HttpContext.Current.Session["el_captcha"].ToString();


            // Refresh Captcha Value
            Random rand = new Random();
            HttpContext.Current.Session["el_captcha"] = rand.Next(999999999).ToString();


            bool CaptchaSensitivityCase = (ElanatConfig.GetNode("security/use_sensitivity_case_captcha").Attributes["active"].Value == "true");

            if (CaptchaSensitivityCase)
            {
                if (CaptchaValue == Value)
                    return true;
            }
            else
            {
                if (CaptchaValue.ToLower() == Value.ToLower())
                    return true;
            }

            return false;
        }

        public static string InsertVariant(this string Text, NameValueCollection NameValue, string GlobalLanguage)
        {
            InsertVariant iv = new InsertVariant();
            return iv.Insert(Text, NameValue, GlobalLanguage);
        }

        public static string DeleteHtmlClass(this string ClassText, string ClassName)
        {
            if (string.IsNullOrEmpty(ClassText) || string.IsNullOrEmpty(ClassName))
                return null;

                int ClassNameIndex = ClassText.IndexOf(ClassName);

                string Space = (ClassNameIndex == 0) ? "" : " ";

                ClassText = ClassText.Replace(Space + ClassName, null);

                if (!string.IsNullOrEmpty(ClassText))
                    if (ClassText[0] == ' ')
                        ClassText = ClassText.Remove(0, 1);

                return ClassText;
        }

        public static int ToNumber(this string Text)
        {
            if (Text.IsNumber())
                return int.Parse(Text);

                return 0;
        }

        public static string[] Add(this string[] TextList, string NewText)
        {
            string[] NewTextList = new string[TextList.Length + 1];

            for (int i = 0; i < TextList.Length; i++)
            {
                NewTextList[i] = TextList[i];
            }

            NewTextList[TextList.Length] = NewText;

            return NewTextList;
        }

        public static string[] Delete(this string[] TextList, int Index)
        {
            string[] NewTextList = new string[TextList.Length - 1];

            int AfterIndex = 0;
            for (int i = 0; i < TextList.Length; i++)
            {
                if (i == Index)
                {
                    AfterIndex = 1;
                    continue;
                }

                NewTextList[i - AfterIndex] = TextList[i];
            }

            return NewTextList;
        }

        public static string AddHtmlClass(this string ClassText, string ClassName)
        {
            if (string.IsNullOrEmpty(ClassText) || string.IsNullOrEmpty(ClassName))
                return ClassName;

            if (ClassText.Contains(ClassName))
                return ClassText;

            return ClassText + " " + ClassName;
        }

        public static string DllNativeReplace(this string Text, string OldText, string NewText)
        {
            NativeDllReplace.NativeMethods ndr = new NativeDllReplace.NativeMethods();
            return ndr.NativeReplace(Text, OldText, NewText);
        }

        public static string ProtectSqlInjection(this string Text, bool UseLikeSearchProtections = false)
        {
            if (string.IsNullOrEmpty(Text))
                return null;

            Security sc = new Security();

            return sc.ProtectSqlInjection(Text, UseLikeSearchProtections);
        }

        public static string ProtectXssInjection(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return null;

            Security sc = new Security();

            return sc.ProtectXssInjection(Text);
        }


        public static bool ExistXssInjection(this string Text)
        {
            Security sc = new Security();

            return sc.ExistXssInjection(Text);
        }

        public static bool ExistHtml(this string Text)
        {
            Security sc = new Security();

            return sc.ExistHtml(Text);
        }

        public static bool IsNumber(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            Security sc = new Security();

            return sc.IsNumber(Text);
        }

        public static bool IsEmail(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            Regex re = new Regex(Text, RegexOptions.IgnoreCase);

            if (re.IsMatch(@"^(("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))((\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
                return true;

            return false;
        }

        public static bool ZeroOneToBoolean(this int Value)
        {
            return ((Value == 1) ? true : false);
        }

        public static bool ZeroOneToBoolean(this string Value)
        {
            return ((Value == "1")? true : false);
        }

        public static string ZeroOneToTrueFalse(this int Value)
        {
            return ((Value == 1) ? "true" : "false");
        }

        public static string ZeroOneToTrueFalse(this string Value)
        {
            return ((Value == "1") ? "true" : "false");
        }

        public static string BooleanToZeroOne(this bool Value)
        {
            return ((Value) ? "1" : "0");
        }

        public static string BooleanToTrueFalse(this bool Value)
        {
            return ((Value) ? "true" : "false");
        }

        public static string BooleanToCheckedHtmlAttribute(this bool Value)
        {
            return ((Value) ? "checked=" + '"' + "checked" + '"' : "");
        }

        public static string TrueFalseToZeroOne(this string Value)
        {
            switch (Value)
            {
                case "true": return "1";
                case "True": return "1";
                case "TRUE": return "1";
            }
            return "0";
        }

        public static bool TrueFalseToBoolean(this string Value)
        {
            switch (Value)
            {
                case "true": return true;
                case "True": return true;
                case "TRUE": return true;
            }
            return false;
        }

        public static string ToBitSizeTuning(this string Value)
        {
            decimal TmpValue = decimal.Parse(Value);

            if (TmpValue < 1024)
                return TmpValue + " B";

            if (TmpValue < 1048576)
                return (TmpValue / 1024).ToString("#.##") + " KB";

            if (TmpValue < 1073741824)
                return (TmpValue / 1048576).ToString("#.##") + " MB";

            if (TmpValue < 1099511627776)
                return (TmpValue / 1073741824).ToString("#.##") + " GB";

            return ">TB";
        }

        public static string ToBitSizeTuning(this long Value)
        {
            return Value.ToString().ToBitSizeTuning();
        }

        public static string ToDateAndTimeTuning(this DateTime Value, string GlobalLanguage)
        {
            DateTime DateTimeNow = DateTime.Now;

            TimeSpan ts = DateTimeNow - Value;

            if (ts.TotalDays > 10)
                return Value.ToShortDateString();

            if (ts.TotalDays > 1)
                return Language.GetLanguage("total_days_ago", GlobalLanguage).Replace("$_asp days;", ts.TotalDays.ToString());

            if (ts.TotalHours > 1)
                return Language.GetLanguage("total_hours_ago", GlobalLanguage).Replace("$_asp hours;", ts.TotalHours.ToString());

            if (ts.TotalMinutes > 1)
                return Language.GetLanguage("total_minutes_ago", GlobalLanguage).Replace("$_asp minutes;", ts.TotalMinutes.ToString());

            return Language.GetLanguage("now", GlobalLanguage);
        }

        public static bool HasTuning(this DateTime Value)
        {
            DateTime DateTimeNow = DateTime.Now;

            TimeSpan ts = DateTimeNow - Value;

            return (ts.TotalDays > 10) ? false : true;
        }

        /// <param name="Section">date, time</param>
        public static string ToDateAndTimeTuning(this DateTime Value, string GlobalLanguage, string Section)
        {
            DateTime DateTimeNow = DateTime.Now;

            TimeSpan ts = DateTimeNow - Value;

            if (ts.TotalDays > 10 && Section == "date")
                return Value.ToShortDateString();

            if (ts.TotalDays > 1 && Section == "date")
                return Language.GetLanguage("total_days_ago", GlobalLanguage).Replace("$_asp days;", ts.TotalDays.ToString().GetTextBeforeLastValue("."));

            if (ts.TotalHours > 1 && Section == "time")
                return Language.GetLanguage("total_hours_ago", GlobalLanguage).Replace("$_asp hours;", ts.TotalHours.ToString().GetTextBeforeLastValue("."));

            if (ts.TotalMinutes > 1 && Section == "time")
                return Language.GetLanguage("total_minutes_ago", GlobalLanguage).Replace("$_asp minutes;", ts.TotalMinutes.ToString().GetTextBeforeLastValue("."));

            return (Section == "date") ? Language.GetLanguage("today", GlobalLanguage) : Language.GetLanguage("now", GlobalLanguage);
        }

        /// <summary>
        /// Do Not Use This Method For Static Xml, Because XmlNode Will Change Permanently. You Can Use InnerTextAfterSetNodeVariant Method For Static Xml
        /// </summary>
        public static XmlNode SetNodeVariant(this XmlNode Value, string GlobalLanguage, bool BreakLanguage = false)
        {
            AttributeReader ar = new AttributeReader();

            if (Value.Attributes["use_language"] != null)
                Value.InnerText = ar.ReadLanguage(Value.InnerText, GlobalLanguage, BreakLanguage);

            if (Value.Attributes["use_replace_part"] != null)
                Value.InnerText = ar.ReadReplacePart(Value.InnerText, GlobalLanguage);

            if (Value.Attributes["use_elanat"] != null)
                Value.InnerText = ar.ReadElanat(Value.InnerText, GlobalLanguage);

            if (Value.Attributes["use_module"] != null)
                Value.InnerText = ar.ReadModule(Value.InnerText, GlobalLanguage);

            if (Value.Attributes["use_plugin"] != null)
                Value.InnerText = ar.ReadPlugin(Value.InnerText, GlobalLanguage);

            if (Value.Attributes["use_fetch"] != null)
                Value.InnerText = ar.ReadFetch(Value.InnerText, GlobalLanguage);

            if (Value.Attributes["use_item"] != null)
                Value.InnerText = ar.ReadItem(Value.InnerText, GlobalLanguage); 
            
            return Value;
        }

        public static string InnerTextAfterSetNodeVariant(this XmlNode Value, string GlobalLanguage, bool BreakLanguage = false)
        {
            AttributeReader ar = new AttributeReader();
            string InnerText = Value.InnerText;

            if (Value.Attributes["use_language"] != null)
                InnerText = ar.ReadLanguage(InnerText, GlobalLanguage, BreakLanguage);

            if (Value.Attributes["use_replace_part"] != null)
                InnerText = ar.ReadReplacePart(InnerText, GlobalLanguage);

            if (Value.Attributes["use_elanat"] != null)
                InnerText = ar.ReadElanat(InnerText, GlobalLanguage);

            if (Value.Attributes["use_module"] != null)
                InnerText = ar.ReadModule(InnerText, GlobalLanguage);

            if (Value.Attributes["use_plugin"] != null)
                InnerText = ar.ReadPlugin(InnerText, GlobalLanguage);

            if (Value.Attributes["use_fetch"] != null)
                InnerText = ar.ReadFetch(InnerText, GlobalLanguage);

            if (Value.Attributes["use_item"] != null)
                InnerText = ar.ReadItem(InnerText, GlobalLanguage);

            return InnerText;
        }

        public static string GetTextAfterValue(this string Text, string Value)
        {
            if (Text.Length < Value.Length)
                return Text;

            if (!Text.Contains(Value))
                return Text;

            return Text.Substring(Text.IndexOf(Value) + Value.Length);
        }

        public static string GetTextAfterLastValue(this string Text, string Value)
        {
            if (Text.Length < Value.Length)
                return Text;

            if (!Text.Contains(Value))
                return Text;

            return Text.Substring(Text.LastIndexOf(Value) + Value.Length);
        }

        public static string GetTextBeforeValue(this string Text, string Value)
        {
            if (Text.Length < Value.Length)
                return Text;

            if (!Text.Contains(Value))
                return Text;

            return Text.Substring(0, Text.IndexOf(Value));
        }

        public static string GetTextBeforeLastValue(this string Text, string Value)
        {
            if (Text.Length < Value.Length)
                return Text;

            if (!Text.Contains(Value))
                return Text;

            return Text.Substring(0, Text.LastIndexOf(Value));
        }

        public static bool TextStartMathByValueCheck(this string Text, string Value)
        {
            if (Text.Length < Value.Length)
                return false;

            if (!Text.Contains(Value))
                return false;

            return (Text.Substring(0, Value.Length) == Value);
        }

        public static bool TextEndMathByValueCheck(this string Text, string Value)
        {
            if (Text.Length < Value.Length)
                return false;

            if (!Text.Contains(Value))
                return false;

            return (Text.Substring(Text.IndexOf(Value)) == Value);
        }

        public static string PathCustomizationForDirectoryName(this string Text)
        {
            Text = Text.Replace(@"\", "_");
            Text = Text.Replace(@"/", "_");
            Text = Text.Replace(":", "");

            return Text;
        }

        public static string ToFileNameClean(this string Text, string Value = "_")
        {
            Text = Text.Replace("&", Value);
            Text = Text.Replace(@"\", Value);
            Text = Text.Replace("/", Value);
            Text = Text.Replace(":", Value);
            Text = Text.Replace("*", Value);
            Text = Text.Replace("?", Value);
            Text = Text.Replace("\"", Value);
            Text = Text.Replace("'", Value);
            Text = Text.Replace("<", Value);
            Text = Text.Replace(">", Value);
            Text = Text.Replace("|", Value);
            Text = Text.Replace("#", Value);
            Text = Text.Replace("%", Value);
            Text = Text.Replace("&", Value);
            Text = Text.Replace("{", Value);
            Text = Text.Replace("}", Value);
            Text = Text.Replace("$", Value);
            Text = Text.Replace("!", Value);
            Text = Text.Replace(";", Value);
            Text = Text.Replace("@", Value);
            Text = Text.Replace("+", Value);
            Text = Text.Replace("`", Value);
            Text = Text.Replace("=", Value);
            Text = Text.Replace("^", Value);
            Text = Text.Replace("[", Value);
            Text = Text.Replace("]", Value);
            Text = Text.Replace("(", Value);
            Text = Text.Replace(")", Value);

            return Text;
        }

        public static string ToFileNameEncode(this string Text)
        {
            Text = Text.Replace("&", "$_asp ampersand;");
            Text = Text.Replace(@"\", "$_asp backslash;");
            Text = Text.Replace("/", "$_asp slash;");
            Text = Text.Replace(":", "$_asp colon;");
            Text = Text.Replace("*", "$_asp asterisk;");
            Text = Text.Replace("?", "$_asp question_mark;");
            Text = Text.Replace("\"", "$_asp quotation_mark;");
            Text = Text.Replace("'", "$_asp quote;");
            Text = Text.Replace("<", "$_asp less_than_sign;");
            Text = Text.Replace(">", "$_asp greater_than_sign;");
            Text = Text.Replace("|", "$_asp vertical_bar;");

            return Text;
        }

        public static string ToFileNameDecode(this string Text)
        {
            Text = Text.Replace("$_asp ampersand;", "&");
            Text = Text.Replace("$_asp backslash;", @"\");
            Text = Text.Replace("$_asp slash;", "/");
            Text = Text.Replace("$_asp colon;", ":");
            Text = Text.Replace("$_asp asterisk;", "*");
            Text = Text.Replace("$_asp question_mark;", "?");
            Text = Text.Replace("$_asp quotation_mark;", "\"");
            Text = Text.Replace("$_asp quote;", "'");
            Text = Text.Replace("$_asp less_than_sign;", "<");
            Text = Text.Replace("$_asp greater_than_sign;", ">");
            Text = Text.Replace("$_asp vertical_bar;", "|");

            return Text;
        }

        //[Obsolete("Just Use This Method After Set All Value To Fields")]
        public static System.Web.UI.Page SetImportantField(this System.Web.UI.Page Page, bool CreateClientInjectionCheck = false, string Path = "", string Category = "", List<string> ControlList = null)
        {
            ValidationClass vc = new ValidationClass();
            return vc.SetImportantField(Page, CreateClientInjectionCheck, Path, Category, ControlList);
        }

        public static IEnumerable<System.Web.UI.Control> AllControls(System.Web.UI.Control container)
        {
            foreach (System.Web.UI.Control control in container.Controls)
            {
                yield return control;

                foreach (var innerControl in AllControls(control))
                    yield return innerControl;
            }
        }

        public static System.Web.UI.WebControls.CheckBoxList SetSelectedValue(this System.Web.UI.WebControls.CheckBoxList CheckBoxList, ListItem[] Value)
        {
            foreach (ListItem CheckBoxItem in CheckBoxList.Items)
            {
                foreach (ListItem item in Value)
                    if (CheckBoxItem.Value == item.Value)
                    {
                        CheckBoxItem.Selected = item.Selected;
                        break;
                    }
            }

            return CheckBoxList;
        }

        public static System.Web.UI.WebControls.DropDownList SetSelectedValue(this System.Web.UI.WebControls.DropDownList DropDownList, ListItem[] Value)
        {
            foreach (ListItem DropDownItem in DropDownList.Items)
                foreach (ListItem item in Value)
                    if (DropDownItem.Value == item.Value)
                    {
                        DropDownItem.Selected = true;
                        return DropDownList;
                    }

            return DropDownList;
        }

        public static string ValueToString(this ListItem[] ListItem, string Separator)
        {
            string ReturnValue = "";

            foreach (ListItem item in ListItem)
                ReturnValue += Separator + item.Value;

            if (!string.IsNullOrEmpty(ReturnValue))
                ReturnValue = ReturnValue.Remove(0, 1);

            return ReturnValue;
        }

        public static string ToUpperFirstChar(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            return Text.First().ToString().ToUpper() + Text.Substring(1);
        }

        public static string SpaceToUnderline(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            return Text.Replace(" ", "_");
        }

        public static string AddParentHiddenTag(this string Text)
        {
            string ParentHiddenTagTemplate = Template.GetXmlNodeFromGlobalTemplate("part/parent_hidden_tag").InnerText;

            ParentHiddenTagTemplate = ParentHiddenTagTemplate.Replace("$_asp item;", Text);

            return ParentHiddenTagTemplate;
        }

        public static bool ExistFileInPath(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            if (!Text.Contains("/"))
                return false;

            string Value = Text.GetTextAfterLastValue("/");

            if (string.IsNullOrEmpty(Value))
                return false;

            if (Value.Contains(".") && Value[Value.Length - 1] != '.')
                return true;

            return false;
        }

        public static bool HasColumn(this System.Data.IDataRecord dr, string ColumnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
                if (dr.GetName(i).Equals(ColumnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                return false;
        }

        public static bool IsScriptExtension(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            if (Text[0] == '.')
                Text = Text.Remove(0, 1);

            foreach (XmlNode node in StaticObject.ScriptExtensionNodeList)
            {
                if (node.Attributes["extension"].Value == Text)
                    return true;
            }

            return false;
        }

        #region Html Input

        public static List<string> HtmlInputGetNamesFromMultiSelectString(this string Text)
        {
            List<string> Names = new List<string>();

            if (string.IsNullOrEmpty(Text))
                return Names;

            List<string> NameAndValue = Text.Split('$').ToList();

            foreach (string Item in NameAndValue)
                Names.Add(Item.GetTextBeforeValue("="));

            return Names;
        }

        public static NameValueCollection HtmlInputGetNameValueFromMultiSelectString(this string Text)
        {
            NameValueCollection NameValue = new NameValueCollection();

            if (string.IsNullOrEmpty(Text))
                return NameValue;

            List<string> NameAndValue = Text.Split('$').ToList();

            foreach (string Item in NameAndValue)
                NameValue.Add(Item.GetTextBeforeValue("="), Item.GetTextAfterValue("="));

            return NameValue;
        }

        public static List<string> HtmlInputGetNamesFromSingleSelectString(this string Text)
        {
            List<string> Names = new List<string>();

            if (string.IsNullOrEmpty(Text))
                return Names;

            Text = Text.Replace("=select", "");

            Names = Text.Split('$').ToList();

            return Names;
        }

        public static NameValueCollection HtmlInputGetNameValueFromSingleSelectString(this string Text)
        {
            NameValueCollection NameValue = new NameValueCollection();

            if (string.IsNullOrEmpty(Text))
                return NameValue;

            List<string> NameAndValue = Text.Split('$').ToList();

            foreach (string Item in NameAndValue)
                if (Item.Contains("=select"))
                    NameValue.Add(Item.GetTextBeforeValue("=select"), "true");
                else
                    NameValue.Add(Item, "false");

            return NameValue;
        }

        public static string HtmlInputGetSelectedValueFromSingleSelectString(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return null;

            List<string> NameAndValue = Text.Split('$').ToList();

            foreach (string Item in NameAndValue)
                if (Item.Contains("=select"))
                    return Item.GetTextBeforeValue("=select");

            return null;
        }

        public static bool HtmlInputExistValueFromSingleSelectStringCheck(this string Text, string Name)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            bool ReturnValue = Text.Contains(">" + Name + "</option>");

            return ReturnValue;
        }

        public static string HtmlInputToOptionTag(this ListItem[] ListItem, bool SetFirstEmptyOption = false)
        {
            string ReturnValue = "";

            if (SetFirstEmptyOption)
                ReturnValue = "<option value=" + '"' + '"' + "></option>";

            foreach (ListItem item in ListItem)
                ReturnValue += "<option value=" + '"' + item.Value + '"' + ">" + item.Text + "</option>";

            return ReturnValue;
        }

        // Overload
        public static string HtmlInputToOptionTag(this ListItem[] ListItem, string SelectValue)
        {
            string ReturnValue = "";

            foreach (ListItem item in ListItem)
            {
                if (item.Value == SelectValue)
                    ReturnValue += "<option value=" + '"' + item.Value + '"' + " selected" + ">" + item.Text + "</option>";
                else
                    ReturnValue += "<option value=" + '"' + item.Value + '"' + ">" + item.Text + "</option>";
            }

            return ReturnValue;
        }

        // Overload
        public static string HtmlInputToOptionTag(this ListItem[] ListItem, string SelectValue, bool SetFirstEmptyOption = false)
        {
            string ReturnValue = "";

            if (SetFirstEmptyOption)
                ReturnValue = "<option value=" + '"' + ((string.IsNullOrEmpty(SelectValue))? " seselected" : "" ) + '"' + "></option>";

            foreach (ListItem item in ListItem)
            {
                if (item.Value == SelectValue)
                    ReturnValue += "<option value=" + '"' + item.Value + '"' + " selected" + ">" + item.Text + "</option>";
                else
                    ReturnValue += "<option value=" + '"' + item.Value + '"' + ">" + item.Text + "</option>";
            }

            return ReturnValue;
        }

        public static string HtmlInputSetSelectValue(this string OptinListValue, string SelectedValue)
        {
            OptinListValue = OptinListValue.Replace('"' + " selected" + ">", '"' + ">");

            OptinListValue = OptinListValue.Replace("value=" + '"' + SelectedValue + '"', "value=" + '"' + SelectedValue + '"' + " selected");

            return OptinListValue;
        }

        public static string HtmlInputAddOptionTag(this string Text, string Name, string Value)
        {
            string ReturnValue = "<option value=" + '"' + Value + '"' + ">" + Name + "</option>";

            return Text + ReturnValue;
        }

        public static string HtmlInputDeleteOptionTag(this string Text, string Value)
        {
            string Name = Text.Split(new string[] { "<option value=" + '"' + Value + '"' + ">" }, StringSplitOptions.None)[1].Split('<')[0].Trim();

            string OptionTagValue = "<option value=" + '"' + Value + '"' + ">" + Name + "</option>";

            return Text.Replace(OptionTagValue, "");
        }

        public static string HtmlInputSetCheckBoxListValue(this string CheckBoxListTemplate, ListItem[] Value)
        {
            if (Value != null)
                foreach (ListItem item in Value)
                {
                    if (item.Selected)
                        CheckBoxListTemplate = CheckBoxListTemplate.Replace("value=" + '"' + item.Value + '"', "value=" + '"' + item.Value + '"' + " " + item.Selected.BooleanToCheckedHtmlAttribute());
                }

            return CheckBoxListTemplate;
        }

        // Overload
        public static string HtmlInputSetCheckBoxListValue(this string CheckBoxListTemplate, ListItemCollection Value)
        {
            if (Value != null)
                foreach (ListItem item in Value)
                {
                    if (item.Selected)
                        CheckBoxListTemplate = CheckBoxListTemplate.Replace("value=" + '"' + item.Value + '"', "value=" + '"' + item.Value + '"' + " " + item.Selected.BooleanToCheckedHtmlAttribute());
                }

            return CheckBoxListTemplate;
        }

        public static bool HtmlInputHasFile(this HttpPostedFile PostedFile)
        {
            return ((PostedFile != null) && (PostedFile.ContentLength > 0));
        }

        #endregion
    }
}