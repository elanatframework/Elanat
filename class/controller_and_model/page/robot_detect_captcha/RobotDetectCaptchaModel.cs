using CodeBehind;

namespace Elanat
{
    public partial class RobotDetectCaptchaModel : CodeBehindModel
    {
        public string RobotDetectCaptchaLanguage { get; set; }
        public string SetCaptchaLanguage { get; set; }
        public string YouHaveALotOfRequestsToTheServerInAShortTimeLanguage { get; set; }
        public string PleaseFillCaptchaImageAndClickSetCaptchaButtonLanguage { get; set; }
        public string RequestRemainingLanguage { get; set; }

        public string CaptchaTextValue { get; set; }
        public string RequestRemainingValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/robot_detect_captcha/");
            RobotDetectCaptchaLanguage = aol.GetAddOnsLanguage("robot_detect_captcha");
            YouHaveALotOfRequestsToTheServerInAShortTimeLanguage = aol.GetAddOnsLanguage("you_have_a_lot_of_requests_to_the_server_in_a_short_time");
            PleaseFillCaptchaImageAndClickSetCaptchaButtonLanguage = aol.GetAddOnsLanguage("please_fill_captcha_image_field_and_click_set_captcha_button");
            SetCaptchaLanguage = aol.GetAddOnsLanguage("set_captcha");
            RequestRemainingLanguage = aol.GetAddOnsLanguage("request_remaining");

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            RequestRemainingValue = ccoc.RobotDetectionRequestAfterShowCaptchaCount.ToString();
        }

        public void SetCaptcha()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set Robot Detection Request Count
            switch (ccoc.RoleDominantType)
            {
                case "admin":
                    ccoc.RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_admin_request", 0, "count").ToNumber();
                    ccoc.RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_admin_request", 0, "after_show_captcha_count").ToNumber();
                    break;

                case "member":
                    ccoc.RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_member_request", 0, "count").ToNumber();
                    ccoc.RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_member_request", 0, "after_show_captcha_count").ToNumber();
                    break;

                case "guest":
                    ccoc.RobotDetectionRequestCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "count").ToNumber();
                    ccoc.RobotDetectionRequestAfterShowCaptchaCount = ElanatConfig.GetElanatConfig("security/robot_detection_guest_request", 0, "after_show_captcha_count").ToNumber();
                    break;
            }
            ccoc.RobotDetectionDateTimeLong = DateAndTime.GetDateAndTimeLong();


            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath);
        }

        public void CaptchaIncorrectErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("the_captcha_you_entered_is_incorrect", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/robot_detect_captcha/"), "problem");
        }
    }
}