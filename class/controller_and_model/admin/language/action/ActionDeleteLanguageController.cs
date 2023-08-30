using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteLanguageController : CodeBehindController
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
            dul.Delete(context.Request.Query["language_id"].ToString());

            Write("true");


            // Refill Value
            StaticObject.SetLanguageDocument();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_language", context.Request.Query["language_id"].ToString());
        }
    }
}