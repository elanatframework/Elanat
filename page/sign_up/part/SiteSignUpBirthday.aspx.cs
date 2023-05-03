using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpBirthday : System.Web.UI.Page
    {
        public SiteSignUpBirthdayModel model = new SiteSignUpBirthdayModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.BirthdayYearOptionListSelectedValue = Request.QueryString["birthday_year_value"];
            model.BirthdayMountOptionListSelectedValue = Request.QueryString["birthday_mount_value"];
            model.BirthdayDayOptionListSelectedValue = Request.QueryString["birthday_day_value"];

            model.BirthdayYearCssClass = Request.QueryString["birthday_year_css_class"];
            model.BirthdayMountCssClass = Request.QueryString["birthday_mount_css_class"];
            model.BirthdayDayCssClass = Request.QueryString["birthday_day_css_class"];


            model.SetValue();


            model.SetImportantField();
        }
    }
}