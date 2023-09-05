using Microsoft.AspNetCore.Http.Extensions;
using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
    public class ReferenceClass
    {
        public ReferenceClass()
        {
            // Initialization
            AllowAccessPath = true;
            DenyAccessReason = "";
        }

        public void StartEvent(string Event, string Value)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            // Add Foot Print
            FootPrintClass fpc = new FootPrintClass();
            fpc.Add(Event, Value);

            XmlNodeList NodeList = StaticObject.EventReferenceNodeList;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string QueryString = "";
            QueryString += "user_id=" + ccoc.UserId;
            QueryString += "&event=" + Event;
            QueryString += "&value=" + Value;
            QueryString += "&path=" + context.Request.GetDisplayUrl();

            if (!string.IsNullOrEmpty(context.Request.QueryString.ToString()))
            {
                string TmpQueryString = context.Request.QueryString.ToString();
                if (TmpQueryString[0] == '?')
                    TmpQueryString = TmpQueryString.Remove(0, 1);

                QueryString += "&" + TmpQueryString;
            }

            foreach (XmlNode node in NodeList)
                if (node.Attributes["event"].Value == Event && node.Attributes["active"].Value == "true")
                {
                    string LoadValue = node["load_value"].InnerText;
                    char FirstCharacter = (LoadValue.Contains('?')) ? '&' : '?';
                    string CheckType = node.Attributes["check_type"].Value;

                    if (CheckType == "page")
                    {
                        Security.UseSystemAccess();
                        PageLoader.LoadPath(LoadValue + FirstCharacter + QueryString + "&el_system_access_code=" + StaticObject.SystemAccessCode, false);
                    }

                    if (CheckType == "method")
                    {
                        string DllType = node.Attributes["dll_type"].Value;
                        string DllMethod = node.Attributes["dll_method"].Value;

                        bool IsNonPublic = false;
                        if (node.Attributes["is_non_public"] != null)
                            IsNonPublic = (node.Attributes["is_non_public"].Value == "true");

                        int ParameterListCount = 0;

                        if(node["parameter_list"] != null)
                        {
                            ParameterListCount = node["parameter_list"].ChildNodes.Count;
                        }

                        object[] ObjectParameters = new object[ParameterListCount];

                        int i = 0;
                        foreach(XmlNode Parameter in node["parameter_list"].ChildNodes)
                        {
                            ObjectParameters[i] = Parameter.InnerText;
                            i++;
                        }

                        MethodLoader ml = new MethodLoader();
                        ml.StartWithoutReturn(StaticObject.ServerMapPath(LoadValue), DllType, DllMethod, ObjectParameters, IsNonPublic);
                    }
                }
        }

        public void StartAfterLoadPath(string Path, string FormValue)
        {
            StartLoadPath(Path, FormValue, "after");
        }

        public void StartBeforeLoadPath(string Path, string FormValue)
        {
            StartLoadPath(Path, FormValue, "before");
        }

        private void StartLoadPath(string Path, string FormValue, string AfterOrBefore)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            XmlNodeList NodeList;
            NodeList = (AfterOrBefore == "after") ? StaticObject.AfterLoadPathReferenceNodeList : StaticObject.BeforeLoadPathReferenceNodeList;

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string QueryString = "";
            QueryString += "user_id=" + ccoc.UserId;
            QueryString += "&path=" + Path.GetTextBeforeValue("?");

            if (Path.Contains("?"))
                QueryString += "&" + Path.GetTextAfterValue("?");

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
                            goto StartLoadValue;

                if (node.Attributes["start_by"] != null)
                    if (node.Attributes["start_by"].Value == "true")
                        if (CheckValue.TextStartMathByValueCheck(node["path_value"].InnerText))
                            goto StartLoadValue;

                if (node.Attributes["end_by"] != null)
                    if (node.Attributes["end_by"].Value == "true")
                        if (node["path_value"].InnerText.Length <= CheckValue.Length)
                        {
                            string TmpCheckValue = CheckValue;

                            TmpCheckValue = TmpCheckValue.GetTextBeforeValue("?");

                            if (TmpCheckValue.TextEndMathByValueCheck(node["path_value"].InnerText))
                                goto StartLoadValue;
                        }

                if (node.Attributes["regex_match"] != null)
                    if (node.Attributes["regex_match"].Value == "true")
                    {
                        Regex re = new Regex(node["path_value"].InnerText, RegexOptions.IgnoreCase);

                        if (re.IsMatch(CheckValue))
                            goto StartLoadValue;
                    }


                continue;

                StartLoadValue:

                    string LoadValue = node["load_value"].InnerText;
                    char FirstCharacter = (LoadValue.Contains('?')) ? '&' : '?';
                    string CheckType = node.Attributes["check_type"].Value;

                    if (CheckType == "page")
                        if (AfterOrBefore == "after")
                        {
                            Security.UseSystemAccess();
                            PageLoader.LoadPath(LoadValue + FirstCharacter + QueryString + "&el_system_access_code=" + StaticObject.SystemAccessCode, false);
                        }
                        else
                        {
                            Security.UseSystemAccess();
                            string ReturnValue = PageLoader.LoadPath(LoadValue + FirstCharacter + QueryString + "&el_system_access_code=" + StaticObject.SystemAccessCode, false);
                            if (ReturnValue == "false")
                            {
                                AllowAccessPath = false;
                                DenyAccessReason = node.Attributes["reason"].Value;
                            }
                        }

                    if (CheckType == "method")
                    {
                        string DllType = node.Attributes["dll_type"].Value;
                        string DllMethod = node.Attributes["dll_method"].Value;

                        bool IsNonPublic = false;
                        if (node.Attributes["is_non_public"] != null)
                            IsNonPublic = (node.Attributes["is_non_public"].Value == "true");

                        int ParameterListCount = 0;

                        if (node["parameter_list"] != null)
                            ParameterListCount = node["parameter_list"].ChildNodes.Count;

                        object[] ObjectParameters = new object[ParameterListCount];

                        int i = 0;
                        foreach (XmlNode Parameter in node["parameter_list"].ChildNodes)
                        {
                            ObjectParameters[i] = Parameter.InnerText;
                            i++;
                        }

                        MethodLoader ml = new MethodLoader();

                        if (AfterOrBefore == "after")
                        {
                            ml.StartWithoutReturn(StaticObject.ServerMapPath(LoadValue), DllType, DllMethod, ObjectParameters, IsNonPublic);
                        }
                        else
                        {
                            string ReturnValue = ml.Start(StaticObject.ServerMapPath(LoadValue), DllType, DllMethod, ObjectParameters, IsNonPublic);
                            if (ReturnValue == "false")
                            {
                                AllowAccessPath = false;
                                DenyAccessReason = node.Attributes["reason"].Value;
                            }
                        }
                    }
            }
        }
        public bool AllowAccessPath { get; private set; }
        public string DenyAccessReason { get; private set; }
    }
}