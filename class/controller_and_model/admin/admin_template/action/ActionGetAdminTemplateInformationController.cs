using CodeBehind;

namespace Elanat
{
    public partial class ActionGetAdminTemplateInformationController : CodeBehindController
    {
		public ActionGetAdminTemplateInformationModel model = new ActionGetAdminTemplateInformationModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["admin_template_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + context.Request.Query["admin_template_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["admin_template_directory_path"]));

            View(model);
        }
    }
}