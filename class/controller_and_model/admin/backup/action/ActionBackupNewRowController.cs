using CodeBehind;

namespace Elanat
{
    public partial class ActionBackupNewRowController : CodeBehindController
    {
        public ActionBackupNewRowModel model = new ActionBackupNewRowModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["backup_physical_name"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.BackupPhysicalNameValue = context.Request.Query["backup_physical_name"].ToString();


            model.SetValue();

            View(model);
        }
    }
}