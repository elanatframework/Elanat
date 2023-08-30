using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPluginInformationController : CodeBehindController
    {
		public ActionGetPluginInformationModel model = new ActionGetPluginInformationModel();
		
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["plugin_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/plugin/" + context.Request.Query["plugin_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["plugin_directory_path"]));

            View(model);
        }
    }
}