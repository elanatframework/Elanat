using CodeBehind;

namespace Elanat
{
    public partial class SiteContactGenderController : CodeBehindController
    {
        public SiteContactGenderModel model = new SiteContactGenderModel();

        public void PageLoad(HttpContext context)
        {
            model.GenderUnknownAttribute = context.Request.Query["gender_unknown_attribute"];
            model.GenderMaleAttribute = context.Request.Query["gender_male_attribute"];
            model.GenderFemaleAttribute = context.Request.Query["gender_female_attribute"];

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