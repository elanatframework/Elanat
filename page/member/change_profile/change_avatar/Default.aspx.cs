using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class MemberChangeAvatar : System.Web.UI.Page
    {
        public MemberChangeAvatarModel model = new MemberChangeAvatarModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_ChangeAvatar"]))
                btn_ChangeAvatar_Click(sender, e);


            model.SetValue();
        }

        protected void btn_ChangeAvatar_Click(object sender, EventArgs e)
        {
            model.UseAvatarPathValue = Request.Form["cbx_UseAvatarPath"] == "on";
            model.AvatarPathTextValue = Request.Form["txt_AvatarPath"];
            model.AvatarPathUploadValue = Request.Files["upd_AvatarPath"];
            model.ChangeAvatar();
        }
    }
}