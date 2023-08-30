using CodeBehind;

namespace Elanat
{
    public partial class ActionGetFetchInformationController : CodeBehindController
    {
		public ActionGetFetchInformationModel model = new ActionGetFetchInformationModel();
		
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["fetch_name"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            // Check File Exist
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + context.Request.Query["fetch_name"] + "/catalog.xml")))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }


            Write(model.GetInformation(context.Request.Query["fetch_name"]));

            View(model);
        }
    }
}