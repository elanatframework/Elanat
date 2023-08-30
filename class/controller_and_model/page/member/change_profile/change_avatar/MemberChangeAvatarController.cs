using CodeBehind;

namespace Elanat
{
    public partial class MemberChangeAvatarController : CodeBehindController
    {
        public MemberChangeAvatarModel model = new MemberChangeAvatarModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_ChangeAvatar"]))
            {
                btn_ChangeAvatar_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_ChangeAvatar_Click(HttpContext context)
        {
            model.UseAvatarPathValue = context.Request.Form["cbx_UseAvatarPath"] == "on";
            model.AvatarPathTextValue = context.Request.Form["txt_AvatarPath"];
            model.AvatarPathUploadValue = context.Request.Form.Files["upd_AvatarPath"];

            model.ChangeAvatar();

            View(model);
        }
    }
}