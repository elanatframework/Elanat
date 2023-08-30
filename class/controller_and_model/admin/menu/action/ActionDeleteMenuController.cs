using CodeBehind;

namespace Elanat
{
    public partial class ActionDeleteMenuController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["menu_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["menu_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            ProtectionClass pc = new ProtectionClass();
            if (pc.IsProtected(context.Request.Query["menu_id"].ToString(), StaticObject.AdminPath + "/menu/"))
            {
                Write("false");
                return;
            }

            DataUse.Menu dum = new DataUse.Menu();
            dum.Delete(context.Request.Query["menu_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_menu", context.Request.Query["menu_id"].ToString());
        }
    }
}