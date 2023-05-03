using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteSignUpGender : System.Web.UI.Page
    {
        public SiteSignUpGenderModel model = new SiteSignUpGenderModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["gender_checked"])
            {
                case "unknown": model.GenderUnknownValue = true; break;
                case "male": model.GenderMaleValue = true; break;
                case "female": model.GenderFemaleValue = true; break;

                default: model.GenderUnknownValue = true; break;
            }


            model.SetValue();
        }
    }
}