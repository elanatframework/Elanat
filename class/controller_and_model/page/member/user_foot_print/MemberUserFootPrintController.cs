using CodeBehind;

namespace Elanat
{
    public partial class MemberUserFootPrintController : CodeBehindController
    {
        public MemberUserFootPrintModel model = new MemberUserFootPrintModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}