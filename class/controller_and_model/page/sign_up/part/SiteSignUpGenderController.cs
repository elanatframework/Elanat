using CodeBehind;

namespace Elanat
{
    public partial class SiteSignUpGenderController : CodeBehindController
    {
        public SiteSignUpGenderModel model = new SiteSignUpGenderModel();

        public void PageLoad(HttpContext context)
        {
            switch (context.Request.Query["gender_checked"])
            {
                case "unknown": model.GenderUnknownValue = true; break;
                case "male": model.GenderMaleValue = true; break;
                case "female": model.GenderFemaleValue = true; break;

                default: model.GenderUnknownValue = true; break;
            }


            model.SetValue();

            View(model);
        }
    }
}