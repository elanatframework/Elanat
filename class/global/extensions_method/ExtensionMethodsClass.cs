using Microsoft.SqlServer.Server;
using System.Net;
using System.Net.Mail;
using System.Xml;

namespace Elanat
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

            if (string.IsNullOrEmpty(StaticObject.GetSession("el_captcha")))
                return false;

            string CaptchaValue = StaticObject.GetSession("el_captcha");


            // Refresh Captcha Value
            Random rand = new Random();
            StaticObject.SetSession("el_captcha", rand.Next(999999999).ToString());


            bool CaptchaSensitivityCase = (ElanatConfig.GetNode("security/use_sensitivity_case_captcha").Attributes["active"].Value == "true");

            if (string.IsNullOrEmpty(Value))
                return false;

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

        public static string InsertVariant(this string Text, List<ListItem> NameValue, string GlobalLanguage)
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

        public static bool IsUlString(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            StringClass sc = new StringClass();

            return sc.IsUlString(Text);
        }

        public static bool IsEmail(this string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;

            try
            {
                MailAddress mail = new MailAddress(Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
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
            Text = Text.Replace("&", "_asp_ampersand_");
            Text = Text.Replace(@"\", "_asp_backslash_");
            Text = Text.Replace("/", "_asp_slash_");
            Text = Text.Replace(":", "_asp_colon_");
            Text = Text.Replace("*", "_asp_asterisk_");
            Text = Text.Replace("?", "_asp_question_mark_");
            Text = Text.Replace("\"", "_asp_quotation_mark_");
            Text = Text.Replace("'", "_asp_quote_");
            Text = Text.Replace("<", "_asp_less_than_sign_");
            Text = Text.Replace(">", "_asp_greater_than_sign_");
            Text = Text.Replace("|", "_asp_vertical_bar_");
            Text = Text.Replace("$", "_asp_dollar_sign_");
            Text = Text.Replace("=", "_asp_equal_sign_");

            return Text;
        }

        public static string ToFileNameDecode(this string Text)
        {
            Text = Text.Replace("_asp_ampersand_", "&");
            Text = Text.Replace("_asp_backslash_", @"\");
            Text = Text.Replace("_asp_slash_", "/");
            Text = Text.Replace("_asp_colon_", ":");
            Text = Text.Replace("_asp_asterisk_", "*");
            Text = Text.Replace("_asp_question_mark_", "?");
            Text = Text.Replace("_asp_quotation_mark_", "\"");
            Text = Text.Replace("_asp_quote_", "'");
            Text = Text.Replace("_asp_less_than_sign_", "<");
            Text = Text.Replace("_asp_greater_than_sign_", ">");
            Text = Text.Replace("_asp_vertical_bar_", "|");
            Text = Text.Replace("_asp_dollar_sign_", "$");
            Text = Text.Replace("_asp_equal_sign_", "=");

            return Text;
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

        public static bool IsExecuteExtension(this string Text)
        {
            if (Text == ".aspx")
                return true;

            return IsScriptExtension(Text);
        }

        public static List<ListItem> ToListItems(this QueryString QueryString)
        {
            List<ListItem> TmplistItems = new List<ListItem>();
            string TmpQueryString = QueryString.ToString();

            if (TmpQueryString.Length > 0)
                if (TmpQueryString[0] == '?')
                    TmpQueryString = TmpQueryString.Remove(0, 1);

            string[] queryElements = TmpQueryString.Split('&');
            foreach (string element in queryElements)
            {
                string[] NameValue = element.Split('=');

                if (NameValue.Length > 1)
                    TmplistItems.Add(WebUtility.UrlDecode(NameValue[0]), WebUtility.UrlDecode(NameValue[1]));
                else
                    TmplistItems.Add(WebUtility.UrlDecode(NameValue[0]), "");
            }

            return TmplistItems;
        }

        public static List<ListItem> Add(this List<ListItem> ListItem, string Name, string Value)
        {
            ListItem.Add(new ListItem(Name, Value));

            return ListItem;
        }

        public static string GetValue(this List<ListItem> ListItemCollection, string Text)
        {
            foreach (ListItem li in ListItemCollection.ToList())
            {
                if (li.Text == Text)
                    return li.Value;
            }

            return null;
        }

        public static List<ListItem> SetValue(this List<ListItem> ListItemCollection, string Text, string Value)
        {
            int i = 0;
            foreach (ListItem li in ListItemCollection.ToList())
            {
                if (li.Text == Text)
                    ListItemCollection[i] = new ListItem(Text, Value);

                i++;
            }

            return ListItemCollection;
        }

        public static List<ListItem> ReplaceValue(this List<ListItem> ListItemCollection, string Value, string NewValue)
        {
            int i = 0;
            foreach (ListItem li in ListItemCollection.ToList())
            {
                if (li.Value == Value)
                    ListItemCollection[i].Value = NewValue;

                i++;
            }

            return ListItemCollection;
        }

        public static string ToQueryString(this List<ListItem> ListItemCollection)
        {
            string ReturnValue = "";
            foreach (ListItem li in ListItemCollection.ToList())
            {
                ReturnValue += li.Text + "=" + li.Value + '&';
            }

            if (ReturnValue.Length > 0)
                if (ReturnValue[ReturnValue.Length - 1] == '&')
                    ReturnValue.Remove(ReturnValue.Length - 1, 1);

            return ReturnValue;
        }

        public static bool HasText(this List<ListItem> ListItemCollection, string Text)
        {
            foreach (ListItem li in ListItemCollection.ToList())
            {
                if (li.Text == Text)
                    return true;
            }

            return false;
        }

        public static void RemoveByTextName(this List<ListItem> ListItemCollection, string Text)
        {
            for (int i = 0; i < ListItemCollection.Count; i++)
                if (ListItemCollection[i].Text == Text)
                    ListItemCollection.RemoveAt(i);
        }

        public static string GetValueByText(this List<ListItem> ListItemCollection, string Text)
        {
            foreach (ListItem li in ListItemCollection.ToList())
            {
                if (li.Text == Text)
                    return li.Value;
            }

            return null;
        }

        public static ListItem FindByValue(this List<ListItem> ListItemCollection, string Value)
        {
            foreach (ListItem li in ListItemCollection.ToList())
            {
                if (li.Value == Value)
                    return li;
            }

            return null;
        }

        public static void SaveAs(this IFormFile PostedFile, string FilePath)
        {
            using (Stream TmpFileStream = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                PostedFile.CopyTo(TmpFileStream);
            }
        }

        public async static void DownloadFile(this HttpClient client, string RequestUrl, string FilePath)
        {
            Stream DataValue = client.GetStreamAsync(RequestUrl).Result;

            using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
            {
                DataValue.CopyToAsync(fileStream).Wait();
            }
        }

        public static string GetString(this IFormCollection FormData)
        {
            string TmpFormData = "";

            foreach (string key in FormData.Keys)
                TmpFormData += key + "=" + FormData[key] + "&";

            if (TmpFormData.Length > 0)
                TmpFormData = TmpFormData.Remove(TmpFormData.Length - 1, 1);

            return TmpFormData;
        }

        public static string GetString(this ISession SessionData)
        {
            string TmpSessionData = "";

            foreach (string key in SessionData.Keys)
                TmpSessionData += key + "=" + SessionData.GetString(key) + "&";

            if (TmpSessionData.Length > 0)
                TmpSessionData = TmpSessionData.Remove(TmpSessionData.Length - 1, 1);

            return TmpSessionData;
        }

        public static string GetString(this IRequestCookieCollection CookieData)
        {
            string TmpCookieData = "";

            foreach (string key in CookieData.Keys)
                TmpCookieData += key + "=" + CookieData[key] + "&";

            if (TmpCookieData.Length > 0)
                TmpCookieData = TmpCookieData.Remove(TmpCookieData.Length - 1, 1);

            return TmpCookieData;
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

        public static List<ListItem> HtmlInputGetNameValueFromMultiSelectString(this string Text)
        {
            List<ListItem> NameValue = new List<ListItem>();

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

        public static List<ListItem> HtmlInputGetNameValueFromSingleSelectString(this string Text)
        {
            List<ListItem> NameValue = new List<ListItem>();

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

        public static string HtmlInputToOptionTag(this List<ListItem> ListItem, bool SetFirstEmptyOption = false)
        {
            string ReturnValue = "";

            if (SetFirstEmptyOption)
                ReturnValue = "<option value=" + '"' + '"' + "></option>";

            foreach (ListItem item in ListItem)
                ReturnValue += "<option value=" + '"' + item.Value + '"' + ">" + item.Text + "</option>";

            return ReturnValue;
        }

        // Overload
        public static string HtmlInputToOptionTag(this List<ListItem> ListItem, string SelectValue)
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
        public static string HtmlInputToOptionTag(this List<ListItem> ListItem, string SelectValue, bool SetFirstEmptyOption = false)
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

        public static string SplitText(this List<ListItem> ListItemCollection, string SplitText)
        {
            string TmpListItemCollection = "";
            int i = 0;
            foreach (ListItem li in ListItemCollection.ToList())
            {
                TmpListItemCollection += li.Text;

                if ((i + 1) < ListItemCollection.Count)
                    TmpListItemCollection += SplitText;

                i++;
            }

            return TmpListItemCollection;
        }

        public static string SplitValue(this List<ListItem> ListItemCollection, string SplitText)
        {
            string TmpListItemCollection = "";
            int i = 0;
            foreach (ListItem li in ListItemCollection.ToList())
            {
                TmpListItemCollection += li.Value;

                if ((i + 1) < ListItemCollection.Count)
                    TmpListItemCollection += SplitText;

                i++;
            }

            return TmpListItemCollection;
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

        public static string HtmlInputSetCheckBoxListValue(this string CheckBoxListTemplate, List<ListItem> Value)
        {
            if (Value != null)
                foreach (ListItem item in Value)
                {
                    if (item.Selected)
                        CheckBoxListTemplate = CheckBoxListTemplate.Replace("value=" + '"' + item.Value + '"', "value=" + '"' + item.Value + '"' + " " + item.Selected.BooleanToCheckedHtmlAttribute());
                }

            return CheckBoxListTemplate;
        }

        public static bool HtmlInputHasFile(this IFormFile PostedFile)
        {
            return ((PostedFile != null) && (PostedFile.Length > 0));
        }

        #endregion
    }
}