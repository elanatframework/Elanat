using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperSiteLogo : System.Web.UI.Page
    {
        public ExtraHelperSiteLogoModel model = new ExtraHelperSiteLogoModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);


            model.SetValue();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.UseLogoPathValue = Request.Form["cbx_UseLogoPath"] == "on";
            model.LogoPathTextValue = Request.Form["txt_LogoPath"];
            model.LogoPathUploadValue = Request.Files["upd_LogoPath"];
            model.SiteOptionListSelectedValue = Request.Form["ddlst_Site"];
            model.StartUpload();
        }
    }
}