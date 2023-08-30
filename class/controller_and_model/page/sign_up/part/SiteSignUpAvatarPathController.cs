using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpAvatarPathController : CodeBehindController
    {
        public SiteSignUpAvatarPathModel model = new SiteSignUpAvatarPathModel();

        public void PageLoad(HttpContext context)
        {
            model.AvatarPathTextValue = context.Request.Query["avatar_path_text_value"];


            model.SetValue();

            View(model);
        }
    }
}