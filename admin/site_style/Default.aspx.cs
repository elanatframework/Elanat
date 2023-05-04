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
    public partial class AdminSiteStyle : System.Web.UI.Page
    {
        public AdminSiteStyleModel model = new AdminSiteStyleModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddSiteStyle"]))
                btn_AddSiteStyle_Click(sender, e);


            model.SetValue(Request.QueryString);
        }

        protected void btn_AddSiteStyle_Click(object sender, EventArgs e)
        {
            model.SiteStylePathUploadValue = Request.Files["upd_SiteStylePath"];
            model.UseSiteStylePathValue = Request.Form["cbx_UseSiteStylePath"] == "on";
            model.SiteStylePathTextValue = Request.Form["txt_SiteStylePath"];
            model.SiteStyleActiveValue = Request.Form["cbx_SiteStyleActive"] == "on";


            model.AddSiteStyle();
        }
    }
}