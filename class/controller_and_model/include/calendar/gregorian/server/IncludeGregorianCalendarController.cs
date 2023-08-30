using CodeBehind;

namespace Elanat
{
    public partial class IncludeGregorianCalendarController : CodeBehindController
    {
        public IncludeGregorianCalendarModel model = new IncludeGregorianCalendarModel();

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