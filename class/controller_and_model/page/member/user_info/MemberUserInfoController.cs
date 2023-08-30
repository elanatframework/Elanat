using CodeBehind;

namespace Elanat
{
    public partial class MemberUserInfoController : CodeBehindController
    {
        public MemberUserInfoModel model = new MemberUserInfoModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}