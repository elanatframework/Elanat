using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveLanguageController : CodeBehindController
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["language_id"].ToString(), StaticObject.AdminPath + "/language/"))
            {
                Write("false");
                return;
            }

            DataUse.Language dul = new DataUse.Language();
            dul.Inactive(context.Request.Query["language_id"].ToString());
            Write("true");


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_language", context.Request.Query["language_id"].ToString());
        }
    }
}