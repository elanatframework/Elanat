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
    public partial class AdminPatch : System.Web.UI.Page
    {
        public AdminPatchModel model = new AdminPatchModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddPatch"]))
                btn_AddPatch_Click(sender, e);


            model.SetValue(Request.QueryString);
        }

        protected void btn_AddPatch_Click(object sender, EventArgs e)
        {
            model.PatchPathUploadValue = Request.Files["upd_PatchPath"];
            model.UsePatchPathValue = Request.Form["cbx_UsePatchPath"] == "on";
            model.PatchPathTextValue = Request.Form["txt_PatchPath"];
            model.PatchActiveValue = Request.Form["cbx_PatchActive"] == "on";


            model.AddPatch();
        }
    }
}