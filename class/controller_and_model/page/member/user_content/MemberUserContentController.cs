using CodeBehind;

namespace Elanat
{
    public partial class MemberUserContentController : CodeBehindController
    {
        public MemberUserContentModel model = new MemberUserContentModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}