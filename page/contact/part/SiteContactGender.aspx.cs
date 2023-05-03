using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class SiteContactGender : System.Web.UI.Page
    {
        public SiteContactGenderModel model = new SiteContactGenderModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.GenderUnknownAttribute = Request.QueryString["gender_unknown_attribute"];
            model.GenderMaleAttribute = Request.QueryString["gender_male_attribute"];
            model.GenderFemaleAttribute = Request.QueryString["gender_female_attribute"];

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