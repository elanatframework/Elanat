namespace Elanat.DataUse
{
    public class FootPrint
    {
        public bool IsUserFootPrint(string UserId, string FootPrintId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_foot_print", new List<string>() { "@user_id", "@foot_print_id" }, new List<string>() { UserId, FootPrintId });

            dbdr.dr.Read();

            bool IsUserFootPrint = dbdr.dr["is_user_foot_print"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserFootPrint;
        }

        public void Delete(string FootPrintId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_foot_print", "@foot_print_id", FootPrintId);
        }

        public void DeleteAll()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_all_foot_print");
        }

        public void DeleteUserFootPrint(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_user_foot_print", "@user_id", UserId);
        }

        public string GetFootPrintCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_foot_print_count");

            dbdr.dr.Read();

            string TodayFootPrintCount = dbdr.dr["foot_print_count"].ToString();

            db.Close();

            return TodayFootPrintCount;
        }

        public string GetTodayFootPrintCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_foot_print_count", "@foot_print_date_action", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayFootPrintCount = dbdr.dr["today_foot_print_count"].ToString();

            db.Close();

            return TodayFootPrintCount;
        }

        public string GetFootPrintCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_foot_print", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string FootPrintCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return FootPrintCount;
        }
    }
}