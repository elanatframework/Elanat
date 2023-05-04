using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionDeleteAvatar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["avatar_path"]))
            {
                string AvatarPath = Request.QueryString["avatar_path"].ToString();

                System.IO.File.Delete(Server.MapPath(StaticObject.SitePath + "client/image/content_avatar/" + AvatarPath));

                string AvatarDirectoriesPath = AvatarPath.GetTextBeforeLastValue("/");
                string AvatarFileName = AvatarPath.GetTextAfterLastValue("/");

                if (AvatarDirectoriesPath.GetTextAfterLastValue("/") != "thumb")
                    System.IO.File.Delete(Server.MapPath(StaticObject.SitePath + "client/image/content_avatar/" + AvatarDirectoriesPath + "/thumb/" + AvatarFileName));


                Response.Write("true");
            }
            else
                Response.Write("false");
        }
    }
}