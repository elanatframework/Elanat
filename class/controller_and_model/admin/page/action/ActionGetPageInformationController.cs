using CodeBehind;

namespace Elanat
{
    public partial class ActionGetPageInformationController : CodeBehindController
    {
		public ActionGetPageInformationModel model = new ActionGetPageInformationModel();
		
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["page_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "page/" + context.Request.Query["page_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["page_directory_path"]));

            View(model);
        }
    }
}