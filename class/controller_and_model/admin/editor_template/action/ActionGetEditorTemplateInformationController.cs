using CodeBehind;

namespace Elanat
{
    public partial class ActionGetEditorTemplateInformationController : CodeBehindController
    {
		public ActionGetEditorTemplateInformationModel model = new ActionGetEditorTemplateInformationModel();
		
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["editor_template_directory_path"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + context.Request.Query["editor_template_directory_path"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["editor_template_directory_path"]));

            View(model);
        }
    }
}