using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
	public class SessionData
    {
        public void Set(string Name, string Value)
        {
            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"));

            bool ExistName = false;
            int i;
            for (i = 0; i <Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                    {
                        ExistName = true;
                        break;
                    }
            }


            // Set Value
            string NameValue = Name + "=" + Value;

            if (ExistName)
                Lines[i] = NameValue;
            else
                Lines = Lines.Add(NameValue);

            System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"), Lines);
        }

        public void SetListItemCollection(string Name, ListItemCollection Value)
        {
            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"));

            bool ExistName = false;
            int i;
            for (i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                    {
                        ExistName = true;
                        break;
                    }
            }


            // Set Value
            var TmpText = "$text$";
            var TmpValue = "$value$";
            var TmpSelected = "$selected$";
            foreach (ListItem li in Value)
            {
                TmpText += li.Text + "$";
                TmpValue += li.Value + "$";
                TmpSelected += li.Selected.BooleanToZeroOne() + "$";
            }

            string NameValue = TmpText + TmpValue + TmpSelected;

            if (ExistName)
                Lines[i] = NameValue;
            else
                Lines = Lines.Add(NameValue);

            System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"), Lines);
        }

        public bool HasSessionData = true;
        public string Get(string Name)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp")))
            {
                HasSessionData = false;
                return "";
            }

            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"));

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        return Lines[i].GetTextAfterValue("=");
            }

            HasSessionData = false;
            return "";
        }

        public ListItemCollection GetListItemCollection(string Name)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp")))
            {
                HasSessionData = false;
                return null;
            }

            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"));
            string Value = "";

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        Value = Lines[i].GetTextAfterValue("=");
            }

            ListItemCollection lic = new ListItemCollection();

            string TmpText = Value.GetTextAfterValue("$text$").GetTextBeforeValue("$value$");
            string TmpValue = Value.GetTextAfterValue("$value$").GetTextBeforeValue("$selected$");
            string TmpSelected = Value.GetTextAfterValue("$selected$");

            if (TmpText.Length > 0)
                if (TmpText[TmpText.Length - 1] == '$')
                    TmpText = TmpText.Remove(TmpText.Length - 1,1);

            if (TmpValue.Length > 0)
                if (TmpValue[TmpValue.Length - 1] == '$')
                    TmpValue = TmpValue.Remove(TmpValue.Length - 1, 1);

            if (TmpSelected.Length > 0)
                if (TmpSelected[TmpSelected.Length - 1] == '$')
                    TmpSelected = TmpSelected.Remove(TmpSelected.Length - 1, 1);

            string[] TmpTextList = TmpText.Split('$');
            string[] TmpValueList = TmpValue.Split('$');
            string[] TmpSelectedList = TmpSelected.Split('$');


            for (int i = 0; i < TmpValueList.Length; i++)
            {
                ListItem li = new ListItem();
                li.Text = TmpTextList[i];
                li.Value = TmpValueList[i];
                li.Selected = TmpSelectedList[i].ZeroOneToBoolean();

                lic.Add(li);
            }

            return lic;
        }

        public bool Exist(string Name)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp")))
                return false;

            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"));

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        return true;
            }

            return false;
        }

        public void Delete(string Name)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp")))
                return;

            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"));

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        Lines = Lines.Delete(i);
            }

            System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + HttpContext.Current.Session.SessionID + ".ini.tmp"), Lines);
        }
    }
}