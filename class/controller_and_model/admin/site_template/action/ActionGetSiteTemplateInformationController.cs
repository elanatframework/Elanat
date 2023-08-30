using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSiteTemplateInformationController : CodeBehindController
    {
        public ActionGetSiteTemplateInformationModel model = new ActionGetSiteTemplateInformationModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["site_template_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "template/site/" + context.Request.Query["site_template_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["site_template_directory_path"]));

            View(model);
        }
    }
}