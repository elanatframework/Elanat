namespace Elanat.DataUse
{
    public class ChangeAdminUser
    {
        public string UserId;
        public string UserName;
        public string UserSiteName;
        public string UserRealName;
        public string UserRealLastName;
        public string UserPhoneNumber;
        public string UserAddress;
        public string UserPostalCode;
        public string UserAbout;
        public string UserBirthday;
        public string UserGender;
        public string UserPublicEmail;
        public string UserMobileNumber;
        public string UserZipCode;
        public string UserOtherInfo;
        public string UserCountry;
        public string UserStateOrProvince;
        public string UserCity;
        public string UserWebsite;

        public void Start()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_admin_user_profile", new List<string>() { "@user_id", "@user_name", "@user_site_name", "@user_real_name", "@user_real_last_name", "@user_phone_number", "@user_address", "@user_postal_code", "@user_about", "@User_birthday", "@user_gender", "@user_public_email", "@user_mobile_number", "@user_zip_code", "@user_other_info", "@user_country", "@user_state_or_province", "@user_city", "@user_website" }, new List<string>() { UserId, UserName, UserSiteName, UserRealName, UserRealLastName, UserPhoneNumber, UserAddress, UserPostalCode, UserAbout, UserBirthday, UserGender, UserPublicEmail, UserMobileNumber, UserZipCode, UserOtherInfo, UserCountry, UserStateOrProvince, UserCity, UserWebsite });
        }
    }
}