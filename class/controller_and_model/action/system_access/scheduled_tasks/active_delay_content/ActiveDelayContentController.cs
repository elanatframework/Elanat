using CodeBehind;

namespace Elanat
{
    public partial class ActiveDelayContentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_delay_content", new List<string>() { "@current_date", "@current_time" }, new List<string>() { DateAndTime.GetDate("yyyy/MM/dd"), DateAndTime.GetTime("HH:mm:ss") });
        }
    }
}