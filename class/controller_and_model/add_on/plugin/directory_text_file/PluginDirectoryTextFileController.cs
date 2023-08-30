using CodeBehind;

namespace Elanat
{
    public partial class PluginDirectoryTextFileController : CodeBehindController
    {
        public PluginDirectoryTextFileModel model = new PluginDirectoryTextFileModel();

        public void PageLoad(HttpContext context)
        {
            // Check Role Type Access
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.RoleDominantType != "admin")
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/401");

                IgnoreViewAndModel = true;

                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Form["btn_Return"]))
            {
                btn_Return_Click(context);
                return;
            }


            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveFile"]))
            {
                btn_SaveFile_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }

        protected void btn_Return_Click(HttpContext context)
        {
            model.DirectoryPathValue = context.Request.Form["hdn_DirectoryPath"];

            model.Return();

            View(model);
        }

        protected void btn_SaveFile_Click(HttpContext context)
        {
            model.FileTextValue = context.Request.Form["txt_FileText"];
            model.DirectoryPathValue = context.Request.Form["hdn_DirectoryPath"];
            model.FilePathValue = context.Request.Form["hdn_FilePath"];
            model.SaveFile();


            model.SuccessView();

            View(model);
        }
    }
}