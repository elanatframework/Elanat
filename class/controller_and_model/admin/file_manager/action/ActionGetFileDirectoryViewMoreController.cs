using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFileDirectoryViewMoreController : CodeBehindController
    {
        public ActionGetFileDirectoryViewMoreModel model = new ActionGetFileDirectoryViewMoreModel();
        
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["file_directory_path"]))
            {
                Write("false");
                IgnoreViewAndModel = true;
            }


            Write(model.GetViewMore(StaticObject.ServerMapPath(StaticObject.SitePath + context.Request.Query["file_directory_path"].ToString())));
            
            View(model);
        }
    }
}