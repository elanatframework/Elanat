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
    public partial class AdminAdminStyle : System.Web.UI.Page
    {
        public AdminAdminStyleModel model = new AdminAdminStyleModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddAdminStyle"]))
                btn_AddAdminStyle_Click(sender, e);


            model.SetValue(Request.QueryString);
        }

        protected void btn_AddAdminStyle_Click(object sender, EventArgs e)
        {
            model.AdminStylePathUploadValue = Request.Files["upd_AdminStylePath"];
            model.UseAdminStylePathValue = Request.Form["cbx_UseAdminStylePath"] == "on";
            model.AdminStylePathTextValue = Request.Form["txt_AdminStylePath"];
            model.AdminStyleActiveValue = Request.Form["cbx_AdminStyleActive"] == "on";


            model.AddAdminStyle();
        }
    }
}