using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserFootPrintController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["foot_print_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["foot_print_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string FootPrintId = context.Request.Query["foot_print_id"].ToString();

            DataUse.FootPrint dufp = new DataUse.FootPrint();

            if (dufp.IsUserFootPrint(ccoc.UserId, FootPrintId))
                Write("true");
            else
                Write("false");
        }
    }
}