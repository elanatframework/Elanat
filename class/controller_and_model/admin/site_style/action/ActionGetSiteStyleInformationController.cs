using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteStyleInformationController : CodeBehindController
    {
        public ActionGetSiteStyleInformationModel model = new ActionGetSiteStyleInformationModel();

        public void PageLoad(HttpContext context)
        {			
            if (string.IsNullOrEmpty(context.Request.Query["site_style_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + context.Request.Query["site_style_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["site_style_directory_path"]));

            View(model);
        }
    }
}