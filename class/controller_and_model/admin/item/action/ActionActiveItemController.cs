using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveItemController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["item_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["item_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Item dui = new DataUse.Item();
            dui.Active(context.Request.Query["item_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_item", context.Request.Query["item_id"].ToString());
        }
    }
}