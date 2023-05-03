using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteRssWriter : System.Web.UI.Page
    {
        public SiteRssWriterModel model = new SiteRssWriterModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataUse.Patch dup = new DataUse.Patch();
            string RssPatchId = dup.GetPatchIdByPatchName("rss");
            dup.FillCurrentPatch(RssPatchId);

            if (!dup.PatchActive.ZeroOneToBoolean())
                return;


            model.SetValue(Request.QueryString);
        }
    }
}