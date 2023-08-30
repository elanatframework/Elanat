using CodeBehind;

namespace Elanat
{
    public partial class SitePublicUserInfoController : CodeBehindController
    {
        public SitePublicUserInfoModel model = new SitePublicUserInfoModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["user_id"]) && string.IsNullOrEmpty(context.Request.Query["user_site_name"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            string UserId = "";
            if (!string.IsNullOrEmpty(context.Request.Query["user_id"]))
            {
                if (!context.Request.Query["user_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                UserId = context.Request.Query["user_id"].ToString();
            }
            else
            {
                DataUse.User duu = new DataUse.User();
                string UserSiteName = context.Request.Query["user_site_name"].ToString();

                UserId = duu.GetUserIdByUserSiteName(UserSiteName);

                if (string.IsNullOrEmpty(UserId))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!UserId.IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }
            }


            model.SetValue(UserId);

            View(model);
        }
    }
}