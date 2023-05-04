using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionContentAvatarNewContentAvatar : System.Web.UI.Page
    {
        public ActionContentAvatarNewContentAvatarModel model = new ActionContentAvatarNewContentAvatarModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["content_avatar_name"]))
                return;

            if (string.IsNullOrEmpty(Request.QueryString["parent_directory_path"]))
                return;

            model.ContentAvatarNameValue = Request.QueryString["content_avatar_name"].ToString();
            model.ParentDirectoryPathValue = Request.QueryString["parent_directory_path"].ToString();


            model.SetValue();
        }
    }
}