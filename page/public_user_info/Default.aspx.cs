using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SitePublicUserInfo : System.Web.UI.Page
    {
        public SitePublicUserInfoModel model = new SitePublicUserInfoModel();

        private void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["user_id"]) && string.IsNullOrEmpty(Request.QueryString["user_site_name"]))
                return;

            string UserId = "";
            if (!string.IsNullOrEmpty(Request.QueryString["user_id"]))
            {
                if (!Request.QueryString["user_id"].ToString().IsNumber())
                    return;

                UserId = Request.QueryString["user_id"].ToString();
            }
            else
            {
                DataUse.User duu = new DataUse.User();
                string UserSiteName = Request.QueryString["user_site_name"].ToString();

                UserId = duu.GetUserIdByUserSiteName(UserSiteName);

                if (string.IsNullOrEmpty(UserId))
                    return;

                if (!UserId.IsNumber())
                    return;
            }

            model.SetValue(UserId);
        }
    }
}