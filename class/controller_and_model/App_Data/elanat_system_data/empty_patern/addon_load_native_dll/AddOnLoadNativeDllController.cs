using CodeBehind;

namespace Elanat
{
    public partial class AddOnLoadNativeDllController : CodeBehindController
    {
       public void PageLoad(HttpContext context)
        {
            string FormString = context.Request.Form.GetString();
            string QueryString = context.Request.QueryString.ToString();

            if (!string.IsNullOrEmpty(QueryString))
                if (QueryString[0] == '?')
                    QueryString = QueryString.Remove(0, 1);

            Write(NativeDll.NativeMethods.Main(StaticObject.ServerMapPath("main.dll"), FormString, QueryString));
        }
    }
}