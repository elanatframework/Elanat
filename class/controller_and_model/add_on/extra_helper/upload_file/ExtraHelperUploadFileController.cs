using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperUploadFileController : CodeBehindController
    {
        public ExtraHelperUploadFileModel model = new ExtraHelperUploadFileModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_StartUpload_Click(HttpContext context)
        {
            model.UseFilePathValue = context.Request.Form["cbx_UseFilePath"] == "on";
            model.FilePathUploadValue = context.Request.Form.Files["upd_FilePath"];
            model.FilePathTextValue = context.Request.Form["txt_FilePath"];

            model.StartUpload();

            View(model);
        }
    }
}