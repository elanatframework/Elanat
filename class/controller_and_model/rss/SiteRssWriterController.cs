using CodeBehind;

namespace Elanat
{
    public partial class SiteRssWriterController : CodeBehindController
    {
        public SiteRssWriterModel model = new SiteRssWriterModel();

        public void PageLoad(HttpContext context)
        {
            DataUse.Patch dup = new DataUse.Patch();
            string RssPatchId = dup.GetPatchIdByPatchName("rss");
            dup.FillCurrentPatch(RssPatchId);

            if (!dup.PatchActive.ZeroOneToBoolean())
            {
                IgnoreViewAndModel = true;
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }
    }
}