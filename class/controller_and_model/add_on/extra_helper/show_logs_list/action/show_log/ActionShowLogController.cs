using CodeBehind;

namespace Elanat
{
    public partial class ActionShowLogController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["log_name"]))
                return;

            string Path = StaticObject.SitePath + "App_Data/logs/" + context.Request.Query["log_name"];
            var Lines = File.OpenText(StaticObject.ServerMapPath(Path));

            string SumLine = "";
            string TmpLine = "";


            while ((TmpLine = Lines.ReadLine()) != null)
            {
                SumLine += TmpLine + "<br/>";
            }

            Write(SumLine);

            Lines.Close();
        }
    }
}