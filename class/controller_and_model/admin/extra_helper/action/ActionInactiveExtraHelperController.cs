using CodeBehind;

namespace Elanat
{
    public partial class ActionInactiveExtraHelperController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["extra_helper_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["extra_helper_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.ExtraHelper duex = new DataUse.ExtraHelper();
            duex.Inactive(context.Request.Query["extra_helper_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_extra_helper", context.Request.Query["extra_helper_id"].ToString());
        }
    }
}