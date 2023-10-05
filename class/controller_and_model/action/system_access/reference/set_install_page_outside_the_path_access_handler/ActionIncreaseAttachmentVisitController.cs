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

            // Check If Database Working
            if (StaticObject.RoleNameNumber.Count > 0)
                return;


            if ((Path == "/install/") || (Path == "/install/Default.aspx"))
                context.Response.WriteAsync(PageLoader.LoadWithServer(StaticObject.SitePath + "install/Default.aspx"));

            if ((Path == "/install/script/install.js"))
            {
                context.Response.WriteAsync(PageLoader.LoadWithText(StaticObject.SitePath + "install/script/install.js"));
                context.Response.ContentType = "text/javascript";
            }

            if ((Path == "/install/style/install.css"))
            {
                context.Response.WriteAsync(PageLoader.LoadWithText(StaticObject.SitePath + "install/style/install.css"));
                context.Response.ContentType= "text/css";
            }


            Write("false");
        }
    }
}