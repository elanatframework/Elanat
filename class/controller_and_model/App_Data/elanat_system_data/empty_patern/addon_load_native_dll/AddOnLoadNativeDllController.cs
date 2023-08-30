using CodeBehind;

namespace Elanat
{
    public partial class AddOnLoadNativeDllController : CodeBehindController
    {
       public void PageLoad(HttpContext context)
        {
            string FormString = context.Request.Form.ToString();
            string QueryString = context.Request.QueryString.ToString();

            Write(NativeDll.NativeMethods.Main(StaticObject.ServerMapPath("main.dll"), FormString, QueryString));
        }
    }
}