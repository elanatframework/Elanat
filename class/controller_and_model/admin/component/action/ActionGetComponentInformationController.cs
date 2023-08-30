using CodeBehind;

namespace Elanat
{
    public partial class ActionGetComponentInformationController : CodeBehindController
    {
		public ActionGetComponentInformationModel model = new ActionGetComponentInformationModel();
		
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["component_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.AdminPath + "/" + context.Request.Query["component_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["component_directory_path"]));

            View(model);
        }
    }
}