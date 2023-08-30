namespace Elanat.DataUse
{
    public class Common
    {
        public bool ExistValueToColumnCheck(string TableName, string ColumnName, string ColumnValue, string BreakValue = "")
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("exist_value_to_column_check", new List<string>() { "@table_name", "@column_name", "@column_value", "@breack_value" }, new List<string>() { TableName, ColumnName, ColumnValue, BreakValue });

            dbdr.dr.Read();

            string RowCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return (RowCount == "1");
        }

        public string GetVisitCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_visit_count");

            dbdr.dr.Read();

            string VisitCount = dbdr.dr["visit_count"].ToString();

            db.Close();

            return VisitCount;
        }

        public string GetTodayVisitCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_visit_count", "@visit_statistics_date_visit", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayVisitCount = dbdr.dr["today_visit_count"].ToString();

            db.Close();

            return TodayVisitCount;
        }
    }
}