using CodeBehind;

namespace Elanat
{
    public partial class ActionCheckComponentAccessShowController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["component_name"]))
            {
                Write("false");
                return;
            }

            string ComponentName = context.Request.Query["component_name"].ToString();

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataUse.Component duc = new DataUse.Component();
            if (duc.CheckComponentAccessShowByComponentName(ccoc.GroupId, ComponentName))
                Write("true");
        }
    }
}