using CodeBehind;

namespace Elanat
{
    public partial class ActionGetModuleInformationController : CodeBehindController
    {
        public ActionGetModuleInformationModel model = new ActionGetModuleInformationModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["module_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + context.Request.Query["module_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["module_directory_path"]));

            View(model);
        }
    }
}