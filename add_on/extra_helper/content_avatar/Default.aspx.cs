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
    public partial class ExtraHelperContentAvatar : System.Web.UI.Page
    {
        public ExtraHelperContentAvatarModel model = new ExtraHelperContentAvatarModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_CreateDirectory"]))
                btn_CreateDirectory_Click(sender, e);


            model.PathValue = "";

            if (!string.IsNullOrEmpty(Request.QueryString["path"]))
                model.PathValue = Request.QueryString["path"].ToString();


            model.SetValue();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.UseAvatarPathValue = Request.Form["cbx_UseAvatarPath"] == "on";
            model.PathValue = Request.Form["hdn_ContentAvatarPath"];
            model.AvatarPathTextValue = Request.Form["txt_AvatarPath"];
            model.AvatarPathUploadValue = Request.Files["upd_AvatarPathUpload"];
            model.StartUpload();
        }

        protected void btn_CreateDirectory_Click(object sender, EventArgs e)
        {
            model.PathValue = Request.Form["hdn_CreateDirectoryPathPath"];
            model.DirectoryNameValue = Request.Form["txt_DirectoryName"];
            model.CreateDirectory();
        }
    }
}