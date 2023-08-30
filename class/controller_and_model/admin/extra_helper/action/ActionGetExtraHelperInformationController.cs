using CodeBehind;

namespace Elanat
{
    public partial class ActionGetExtraHelperInformationController : CodeBehindController
    {
		public ActionGetExtraHelperInformationModel model = new ActionGetExtraHelperInformationModel();
		
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["extra_helper_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + context.Request.Query["extra_helper_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["extra_helper_directory_path"]));

            View(model);
        }
    }
}