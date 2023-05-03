using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContentReplyBirthday : System.Web.UI.Page
    {
        public SiteContentReplyBirthdayModel model = new SiteContentReplyBirthdayModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.BirthdayYearOptionListSelectedValue = Request.QueryString["birthday_year_value"];
            model.BirthdayMountOptionListSelectedValue = Request.QueryString["birthday_mount_value"];
            model.BirthdayDayOptionListSelectedValue = Request.QueryString["birthday_day_value"];

            model.BirthdayYearCssClass = Request.QueryString["birthday_year_css_class"];
            model.BirthdayMountCssClass = Request.QueryString["birthday_mount_css_class"];
            model.BirthdayDayCssClass = Request.QueryString["birthday_day_css_class"];

            model.BirthdayYearAttribute = Request.QueryString["birthday_year_attribute"];
            model.BirthdayMountAttribute = Request.QueryString["birthday_mount_attribute"];
            model.BirthdayDayAttribute = Request.QueryString["birthday_day_attribute"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}