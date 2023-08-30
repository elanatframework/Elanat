using CodeBehind;

namespace Elanat
{
    public partial class ActionActiveMenuController : CodeBehindController
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

            DataUse.Menu dum = new DataUse.Menu();
            dum.Active(context.Request.Query["menu_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_menu", context.Request.Query["menu_id"].ToString());
        }
    }
}