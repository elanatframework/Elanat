﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elanat.DataUse
{
    public class ChangeUser
    {
        public string UserId;
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
            db.SetProcedure("edit_user_profile", new List<string>() { "@user_id", "@user_real_name", "@user_real_last_name", "@user_phone_number", "@user_address", "@user_postal_code", "@user_about", "@User_birthday", "@user_gender", "@user_public_email", "@user_mobile_number", "@user_zip_code", "@user_other_info", "@user_country", "@user_state_or_province", "@user_city", "@user_website" }, new List<string>() { UserId, UserRealName, UserRealLastName, UserPhoneNumber, UserAddress, UserPostalCode, UserAbout, UserBirthday, UserGender, UserPublicEmail, UserMobileNumber, UserZipCode, UserOtherInfo, UserCountry, UserStateOrProvince, UserCity, UserWebsite });
        }
    }
}