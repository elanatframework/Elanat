using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSitemapWriter : System.Web.UI.Page
    {
        public SiteSitemapWriterModel model = new SiteSitemapWriterModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataUse.Patch dup = new DataUse.Patch();
            string SitemapPatchId = dup.GetPatchIdByPatchName("sitemap");
            dup.FillCurrentPatch(SitemapPatchId);

            if (!dup.PatchActive.ZeroOneToBoolean())
                return;


            model.SetValue(Request.QueryString);
        }
    }
}