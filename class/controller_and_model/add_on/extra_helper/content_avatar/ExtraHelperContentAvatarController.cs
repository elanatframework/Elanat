using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperContentAvatarController : CodeBehindController
    {
        public ExtraHelperContentAvatarModel model = new ExtraHelperContentAvatarModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_CreateDirectory"]))
            {
                btn_CreateDirectory_Click(context);
                return;
            }


            model.PathValue = "";

            if (!string.IsNullOrEmpty(context.Request.Query["path"]))
                model.PathValue = context.Request.Query["path"].ToString();


            model.SetValue();

            View(model);
        }

        protected void btn_StartUpload_Click(HttpContext context)
        {
            model.UseAvatarPathValue = context.Request.Form["cbx_UseAvatarPath"] == "on";
            model.PathValue = context.Request.Form["hdn_ContentAvatarPath"];
            model.AvatarPathTextValue = context.Request.Form["txt_AvatarPath"];
            model.AvatarPathUploadValue = context.Request.Form.Files["upd_AvatarPathUpload"];

            model.StartUpload();

            View(model);
        }

        protected void btn_CreateDirectory_Click(HttpContext context)
        {
            model.PathValue = context.Request.Form["hdn_CreateDirectoryPathPath"];
            model.DirectoryNameValue = context.Request.Form["txt_DirectoryName"];

            model.CreateDirectory();

            View(model);
        }
    }
}