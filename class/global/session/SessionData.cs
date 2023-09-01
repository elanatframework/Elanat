
namespace Elanat
{
	public class SessionData
    {
        public void Set(string Name, string Value)
        {
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
                File.Create(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")).Close();


            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"));

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

            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"), Lines);
        }

        public void SetListItemCollection(string Name, List<ListItem> Value)
        {
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
                File.Create(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")).Close();

            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"));

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

            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"), Lines);
        }

        public bool HasSessionData = true;
        public string Get(string Name)
        {
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
            {
                HasSessionData = false;
                return "";
            }

            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"));

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        return Lines[i].GetTextAfterValue("=");
            }

            HasSessionData = false;
            return "";
        }

        public List<ListItem> GetListItemCollection(string Name)
        {
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
            {
                HasSessionData = false;
                return null;
            }

            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"));
            string Value = "";

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        Value = Lines[i].GetTextAfterValue("=");
            }

            List<ListItem> lic = new List<ListItem>();

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
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
                return false;

            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"));

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
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp")))
                return;

            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"));

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Length > Name.Length + 1)
                    if (Lines[i].GetTextBeforeValue("=") == Name)
                        Lines = Lines.Delete(i);
            }

            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/" + StaticObject.GetSessionId() + ".ini.tmp"), Lines);
        }
    }
}