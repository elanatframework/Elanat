using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserPageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["page_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["page_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string PageId = context.Request.Query["page_id"].ToString();

            DataUse.Page dua = new DataUse.Page();

            if(dua.IsUserPage(ccoc.UserId ,PageId))
                Write("true");
            else
                Write("false");
        }
    }
}