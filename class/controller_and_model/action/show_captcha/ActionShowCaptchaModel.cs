using CodeBehind;

namespace Elanat
{
    public partial class ActionShowCaptchaModel : CodeBehindModel
    {      
        public void SetValue()
        {
            Write(Security.GetCaptchaImage());
        }
    }
}