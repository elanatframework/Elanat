using CodeBehind;

namespace Elanat
{
    public partial class ActionSetRatingController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Query["content_id"]) && !string.IsNullOrEmpty(context.Request.Query["rate"]))
                if (context.Request.Query["content_id"].ToString() .IsNumber() && context.Request.Query["rate"].ToString().IsNumber())
                {
                    if (int.Parse(context.Request.Query["rate"].ToString()) <= 5)
                    {
                        DataUse.Rating dur = new DataUse.Rating();
                        dur.Set(context.Request.Query["content_id"].ToString(), context.Request.Query["rate"].ToString());
                        Write("true");
                    }
                }
                else
                    Write("false");
        }
    }
}