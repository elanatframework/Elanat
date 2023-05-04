using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminSiteTemplate : System.Web.UI.Page
    {
        public AdminSiteTemplateModel model = new AdminSiteTemplateModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddSiteTemplate"]))
                btn_AddSiteTemplate_Click(sender, e);


            model.SetValue(Request.QueryString);
        }

        protected void btn_AddSiteTemplate_Click(object sender, EventArgs e)
        {
            model.SiteTemplatePathUploadValue = Request.Files["upd_SiteTemplatePath"];
            model.UseSiteTemplatePathValue = Request.Form["cbx_UseSiteTemplatePath"] == "on";
            model.SiteTemplatePathTextValue = Request.Form["txt_SiteTemplatePath"];
            model.SiteTemplateActiveValue = Request.Form["cbx_SiteTemplateActive"] == "on";


            model.AddSiteTemplate();
        }
    }
}