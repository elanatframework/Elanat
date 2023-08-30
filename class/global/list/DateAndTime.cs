using System.Xml;

namespace Elanat.ListClass
{
    public class DateAndTime
    {
        // Get Calendar List Item
        public List<ListItem> CalendarListItem = new List<ListItem>();
        public void FillCalendarListItem(string GlobalLanguage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("calendar_root/calendar_list").ChildNodes;

            foreach (XmlNode node in NodeList)
                CalendarListItem.Add(Language.GetHandheldLanguage(node.Attributes["name"].Value, GlobalLanguage), node.Attributes["name"].Value);
        }

        // Get Day Of Weak List Item
        public List<ListItem> DayOfWeakListItem = new List<ListItem>();
        public void FillDayOfWeakListItem(string GlobalLanguage)
        {
            DayOfWeakListItem.Add(Language.GetLanguage("sunday", GlobalLanguage), "1");
            DayOfWeakListItem.Add(Language.GetLanguage("monday", GlobalLanguage), "2");
            DayOfWeakListItem.Add(Language.GetLanguage("tuesday", GlobalLanguage), "3");
            DayOfWeakListItem.Add(Language.GetLanguage("wednesday", GlobalLanguage), "4");
            DayOfWeakListItem.Add(Language.GetLanguage("thursday", GlobalLanguage), "5");
            DayOfWeakListItem.Add(Language.GetLanguage("friday", GlobalLanguage), "6");
            DayOfWeakListItem.Add(Language.GetLanguage("saturday", GlobalLanguage), "7");
        }

        // Get Persian Day Of Weak List Item
        public List<ListItem> PersianDayOfWeakListItem = new List<ListItem>();
        public void FillPersianDayOfWeakListItem(string GlobalLanguage)
        {
            PersianDayOfWeakListItem.Add(Language.GetLanguage("saturday", GlobalLanguage), "1");
            PersianDayOfWeakListItem.Add(Language.GetLanguage("sunday", GlobalLanguage), "2");
            PersianDayOfWeakListItem.Add(Language.GetLanguage("monday", GlobalLanguage), "3");
            PersianDayOfWeakListItem.Add(Language.GetLanguage("tuesday", GlobalLanguage), "4");
            PersianDayOfWeakListItem.Add(Language.GetLanguage("wednesday", GlobalLanguage), "5");
            PersianDayOfWeakListItem.Add(Language.GetLanguage("thursday", GlobalLanguage), "6");
            PersianDayOfWeakListItem.Add(Language.GetLanguage("friday", GlobalLanguage), "7");
        }

        // Get Mount List Item
        public List<ListItem> MountListItem = new List<ListItem>();
        public void FillMountListItem(string GlobalLanguage)
        {
            MountListItem.Add(Language.GetLanguage("january", GlobalLanguage), "1");
            MountListItem.Add(Language.GetLanguage("february", GlobalLanguage), "2");
            MountListItem.Add(Language.GetLanguage("march", GlobalLanguage), "3");
            MountListItem.Add(Language.GetLanguage("april", GlobalLanguage), "4");
            MountListItem.Add(Language.GetLanguage("may", GlobalLanguage), "5");
            MountListItem.Add(Language.GetLanguage("june", GlobalLanguage), "6");
            MountListItem.Add(Language.GetLanguage("july", GlobalLanguage), "7");
            MountListItem.Add(Language.GetLanguage("august", GlobalLanguage), "8");
            MountListItem.Add(Language.GetLanguage("september", GlobalLanguage), "9");
            MountListItem.Add(Language.GetLanguage("october", GlobalLanguage), "10");
            MountListItem.Add(Language.GetLanguage("november", GlobalLanguage), "11");
            MountListItem.Add(Language.GetLanguage("december", GlobalLanguage), "12");
        }

        // Get Persian Mount List Item
        public List<ListItem> PersianMountListItem = new List<ListItem>();
        public void FillPersianMountListItem(string GlobalLanguage)
        {
            PersianMountListItem.Add(Language.GetLanguage("farvardin", GlobalLanguage), "1");
            PersianMountListItem.Add(Language.GetLanguage("ordibehesht", GlobalLanguage), "2");
            PersianMountListItem.Add(Language.GetLanguage("khordad", GlobalLanguage), "3");
            PersianMountListItem.Add(Language.GetLanguage("tir", GlobalLanguage), "4");
            PersianMountListItem.Add(Language.GetLanguage("mordad", GlobalLanguage), "5");
            PersianMountListItem.Add(Language.GetLanguage("shahrivar", GlobalLanguage), "6");
            PersianMountListItem.Add(Language.GetLanguage("mehr", GlobalLanguage), "7");
            PersianMountListItem.Add(Language.GetLanguage("aban", GlobalLanguage), "8");
            PersianMountListItem.Add(Language.GetLanguage("azar", GlobalLanguage), "9");
            PersianMountListItem.Add(Language.GetLanguage("dey", GlobalLanguage), "10");
            PersianMountListItem.Add(Language.GetLanguage("bahman", GlobalLanguage), "11");
            PersianMountListItem.Add(Language.GetLanguage("esfand", GlobalLanguage), "12");
        }

        // Get Persian Mount List Item
        public List<ListItem> PersianMountListItemByCalendarLanguage = new List<ListItem>();
        public void FillPersianMountListItemByCalendarLanguage(string GlobalLanguage)
        {
            AddOnsLanguage aol = new AddOnsLanguage(GlobalLanguage, StaticObject.SitePath + "include/calendar/persian/");

            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("farvardin"), "1");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("ordibehesht"), "2");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("khordad"), "3");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("tir"), "4");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("mordad"), "5");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("shahrivar"), "6");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("mehr"), "7");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("aban"), "8");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("azar"), "9");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("dey"), "10");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("bahman"), "11");
            PersianMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("esfand"), "12");
        }

        // Get Persian Mount List Item
        public List<ListItem> HijriMountListItemByCalendarLanguage = new List<ListItem>();
        public void FillHijriMountListItemByCalendarLanguage(string GlobalLanguage)
        {
            AddOnsLanguage aol = new AddOnsLanguage(GlobalLanguage, StaticObject.SitePath + "include/calendar/hijri/");

            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("muharram"), "1");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("safar"), "2");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("rabi_al_awwal"), "3");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("rabi_ath_thani"), "4");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("jumada_al_awwal"), "5");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("jumada_ath_thaniyah"), "6");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("rajab"), "7");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("shaban"), "8");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("ramadan"), "9");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("shawwal"), "10");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("zu_al_qadah"), "11");
            HijriMountListItemByCalendarLanguage.Add(aol.GetAddOnsLanguage("zu_al_hijjah"), "12");
        }

        // Get Time Zone List Item
        public List<ListItem> TimeZoneListItem = new List<ListItem>();
        public void FillTimeZoneListItem(string GlobalLanguage)
        {
            TimeZoneListItem.Add("GMT +13", "13");
            TimeZoneListItem.Add("GMT +12", "12");
            TimeZoneListItem.Add("GMT +11", "11");
            TimeZoneListItem.Add("GMT +10", "10");
            TimeZoneListItem.Add("GMT +9.5", "9.5");
            TimeZoneListItem.Add("GMT +9", "9");
            TimeZoneListItem.Add("GMT +8", "8");
            TimeZoneListItem.Add("GMT +7", "7");
            TimeZoneListItem.Add("GMT +6.5", "6.5");
            TimeZoneListItem.Add("GMT +6", "6");
            TimeZoneListItem.Add("GMT +5.5", "5.5");
            TimeZoneListItem.Add("GMT +5", "5");
            TimeZoneListItem.Add("GMT +4.5", "4.5");
            TimeZoneListItem.Add("GMT +4", "4");
            TimeZoneListItem.Add("GMT +3.5", "3.5");
            TimeZoneListItem.Add("GMT +3", "3");
            TimeZoneListItem.Add("GMT +2", "2");
            TimeZoneListItem.Add("GMT +1", "1");
            TimeZoneListItem.Add("GMT", "0");
            TimeZoneListItem.Add("GMT -1", "-1");
            TimeZoneListItem.Add("GMT -2", "-2");
            TimeZoneListItem.Add("GMT -3", "-3");
            TimeZoneListItem.Add("GMT -3.5", "-3.5");
            TimeZoneListItem.Add("GMT -4", "-4");
            TimeZoneListItem.Add("GMT -5", "-5");
            TimeZoneListItem.Add("GMT -6", "-6");
            TimeZoneListItem.Add("GMT -7", "-7");
            TimeZoneListItem.Add("GMT -8", "-8");
            TimeZoneListItem.Add("GMT -9", "-9");
            TimeZoneListItem.Add("GMT -10", "-10");
            TimeZoneListItem.Add("GMT -11", "-11");
            TimeZoneListItem.Add("GMT -12", "-12");
        }

        // Get Birthday List Item
        public List<ListItem> BirthdayDayListItem = new List<ListItem>();
        public List<ListItem> BirthdayMountListItem = new List<ListItem>();
        public List<ListItem> BirthdayYearListItem = new List<ListItem>();
        public void FillBirthdayListItem(string GlobalLanguage)
        {
            for (int i = 0; i < 31; i++)
                BirthdayDayListItem.Add((i + 1).ToString("00"), (i + 1).ToString("00"));

            for (int i = 0; i < 12; i++)
                BirthdayMountListItem.Add((i + 1).ToString("00"), (i + 1).ToString("00"));

            int CurrentYear = DateTime.Now.Year;

            for (int i = 1900; i <= CurrentYear; i++)
                BirthdayYearListItem.Add(i.ToString(), i.ToString());
        }
    }
}