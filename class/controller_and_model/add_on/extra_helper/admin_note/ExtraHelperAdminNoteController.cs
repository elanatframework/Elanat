using CodeBehind;

namespace Elanat
{
    public partial class ExtraHelperAdminNoteController : CodeBehindController
    {
        public ExtraHelperAdminNoteModel model = new ExtraHelperAdminNoteModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}