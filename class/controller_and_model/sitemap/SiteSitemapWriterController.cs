using CodeBehind;

namespace Elanat
{
    public partial class SiteSitemapWriterController : CodeBehindController
    {
        public SiteSitemapWriterModel model = new SiteSitemapWriterModel();

        public void PageLoad(HttpContext context)
        {
            DataUse.Patch dup = new DataUse.Patch();
            string SitemapPatchId = dup.GetPatchIdByPatchName("sitemap");
            dup.FillCurrentPatch(SitemapPatchId);

            if (!dup.PatchActive.ZeroOneToBoolean())
            {
                IgnoreViewAndModel = true;
                return;
            }


            model.SetValue(context);

            View(model);
        }
    }
}