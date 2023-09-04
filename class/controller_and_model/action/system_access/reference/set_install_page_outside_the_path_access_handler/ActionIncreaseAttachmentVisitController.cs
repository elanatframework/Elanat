using CodeBehind;

namespace Elanat
{
    public partial class ActionSetInstallPageOutsideThePathAccessHandlerController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["path"]))
                return;

            string Path = context.Request.Query["path"].ToString();

            if ((Path != "/install/") && (Path != "/install/Default.aspx"))
                return;

            // Check If Database Working
            if (StaticObject.RoleNameNumber.Count > 0)
                return;

            context.Response.WriteAsync(PageLoader.LoadWithServer(StaticObject.SitePath + "install/Default.aspx"));

            Write("false");
        }
    }
}