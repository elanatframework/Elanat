using CodeBehind;

namespace Elanat
{
    public partial class IncludePersianCalendarController : CodeBehindController
    {
        public IncludePersianCalendarModel model = new IncludePersianCalendarModel();

        public void PageLoad(HttpContext context)
        {
            string CurrentDate = "";

            if (!string.IsNullOrEmpty(context.Request.Query["current_date"]))
                CurrentDate = context.Request.Query["current_date"];

            model.SetValue(CurrentDate);

            View(model);
        }
    }
}