namespace Elanat.DataUse
{
    public class VisitStatistics
    {
        public void IncreaseVisit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("increase_visit_statistics", new List<string>() { "@date_visit" }, new List<string>() { DateAndTime.GetDate("yyyy/MM/dd") }, false);
        }

        public string GetNumberOfAllVisitStatistics()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_number_of_all_visit_statistics");

            string NumberOfAllVisitStatistics = "0";

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                NumberOfAllVisitStatistics = dbdr.dr["number_of_all_visit_statistics"].ToString();
            }

            db.Close();

            return NumberOfAllVisitStatistics;
        }

        public string GetNumberOfVisitStatisticsByDate(string Date)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_number_of_date_visit_statistics", "@date", Date);

            string NumberOfDateVisitStatistics = "0";

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                NumberOfDateVisitStatistics = dbdr.dr["number_of_date_visit_statistics"].ToString();
            }

            db.Close();

            return NumberOfDateVisitStatistics;
        }
    }
}