using CodeBehind;

namespace Elanat
{
    public partial class ActionIsUserEditContentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["hdn_ContentId"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["hdn_ContentId"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string ContentId = context.Request.Query["hdn_ContentId"].ToString();

            DataUse.Content duc = new DataUse.Content();

            if(duc.IsUserContent(ccoc.UserId ,ContentId))
                Write("true");
            else
                Write("false");
        }
    }
}