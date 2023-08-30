using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveLanguageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["language_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["language_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Language dul = new DataUse.Language();
            dul.Active(context.Request.Query["language_id"].ToString());
            Write("true");


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_language", context.Request.Query["language_id"].ToString());
        }
    }
}