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
    public partial class AdminAdminTemplate : System.Web.UI.Page
    {
        public AdminAdminTemplateModel model = new AdminAdminTemplateModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddAdminTemplate"]))
                btn_AddAdminTemplate_Click(sender, e);


            model.SetValue(Request.QueryString);
        }

        protected void btn_AddAdminTemplate_Click(object sender, EventArgs e)
        {
            model.AdminTemplatePathUploadValue = Request.Files["upd_AdminTemplatePath"];
            model.UseAdminTemplatePathValue = Request.Form["cbx_UseAdminTemplatePath"] == "on";
            model.AdminTemplatePathTextValue = Request.Form["txt_AdminTemplatePath"];
            model.AdminTemplateActiveValue = Request.Form["cbx_AdminTemplateActive"] == "on";


            model.AddAdminTemplate();
        }
    }
}