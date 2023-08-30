using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteItemController : CodeBehindController
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

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["item_id"].ToString(), StaticObject.AdminPath + "/item/"))
            {
                Write("false");
                return;
            }

            DataUse.Item dui = new DataUse.Item();
            dui.Delete(context.Request.Query["item_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_item", context.Request.Query["item_id"].ToString());
        }
    }
}