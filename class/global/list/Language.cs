namespace Elanat.ListClass
{
    public class LanguageList
    {
        // Get Language List Item
        public List<ListItem> LanguageListItem = new List<ListItem>();
        public void FillLanguageListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    LanguageListItem.Add(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_id"].ToString());

            db.Close();
        }

        // Get Language List Item
        public List<ListItem> ActiveLanguageListItem = new List<ListItem>();
        public void FillActiveLanguageListItem(string GlobalLanguage)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_active_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ActiveLanguageListItem.Add(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_id"].ToString());

            db.Close();
        }

        // Get Language Name List Item
        public List<ListItem> LanguageNameListItem = new List<ListItem>();
        public void FillLanguageNameListItem(string GlobalLanguage)
        {
            // Get Language Name And Language Global Name

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    LanguageNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_global_name"].ToString());

            db.Close();
        }

        // Get Language Name List Item
        public List<ListItem> ActiveLanguageNameListItem = new List<ListItem>();
        public void FillActiveLanguageNameListItem(string GlobalLanguage)
        {
            // Get Language Name And Language Global Name

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_active_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    ActiveLanguageNameListItem.Add(Language.GetHandheldLanguage(dbdr.dr["language_name"].ToString(), GlobalLanguage) + "(" + dbdr.dr["language_global_name"].ToString() + ")", dbdr.dr["language_global_name"].ToString());

            db.Close();
        }

        public static List<string> GetLanguageNameList()
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    list.Add(dbdr.dr["language_name"].ToString() + "(" + dbdr.dr["language_global_name"].ToString() + ")");

            db.Close();

            return list;
        }

        public static List<string> GetLanguageGlobalNameList()
        {
            List<string> list = new List<string>();
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_language_list");

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    list.Add(dbdr.dr["language_global_name"].ToString());

            db.Close();

            return list;
        }
    }
}