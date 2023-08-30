using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Contact : IDisposable
    {
        public string ContactId = "";
        public string UserId = "";
        public string ContactGuestName = "";
        public string ContactGuestRealName = "";
        public string ContactGuestRealLastName = "";
        public string ContactGuestEmail = "";
        public string ContactTitle = "";
        public string ContactText = "";
        public string ContactDateSend = "";
        public string ContactTimeSend = "";
        public string ContactIpAddress = "";
        public string ContactFileDirectoryPath = "";
        public string ContactFilePhysicalName = "";
        public string ContactType = "";
        public string ContactGuestPhoneNumber = "";
        public string ContactGuestAddress = "";
        public string ContactGuestPostalCode = "";
        public string ContactGuestAbout = "";
        public string ContactGuestBirthday = "";
        public string ContactGuestGender = "";
        public string ContactGuestPublicEmail = "";
        public string ContactGuestMobileNumber = "";
        public string ContactGuestZipCode = "";
        public string ContactGuestCountry = "";
        public string ContactGuestStateOrProvince = "";
        public string ContactGuestCity = "";
        public string ContactGuestWebsite = "";
        public string ContactResponseCode = "";
        public string ContactResponseText = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public bool IsUserContact(string UserId, string ContactId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_contact", new List<string>() { "@user_id", "@contact_id" }, new List<string>() { UserId, ContactId });

            dbdr.dr.Read();

            bool IsUserContact = dbdr.dr["is_user_contact"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserContact;
        }

        public void Delete(string ContactId)
        {
            DataUse.Contact duc = new Contact();
            duc.FillCurrentContact(ContactId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_contact", "@contact_id", ContactId);

            // Delete Physical File
            if (!string.IsNullOrEmpty(duc.ContactFilePhysicalName))
                File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + duc.ContactFileDirectoryPath + "/" + duc.ContactFilePhysicalName));

            // If File Is Image, Delete Thumpbinal Image
            if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
            {
                string FileExtension = Path.GetExtension(duc.ContactFilePhysicalName);

                if (FileAndDirectory.IsImageExtension(FileExtension))
                {
                    if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + duc.ContactFileDirectoryPath + "/thumb/" + duc.ContactFilePhysicalName)))
                        File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/contact/" + duc.ContactFileDirectoryPath + "/thumb/" + duc.ContactFilePhysicalName));
                }
            }
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_contact", new List<string>() { "@user_id", "@contact_guest_name", "@contact_guest_real_name", "@contact_guest_real_last_name", "@contact_guest_email", "@contact_title", "@contact_text", "@contact_date_send", "@contact_time_send", "@contact_ip_address", "@contact_file_directory_path", "@contact_file_physical_name", "@contact_type", "@contact_guest_phone_number", "@contact_guest_address", "@contact_guest_postal_code", "@contact_guest_about", "@contact_guest_birthday", "@contact_guest_gender", "@contact_guest_public_email", "@contact_guest_mobile_number", "@contact_guest_zip_code", "@contact_guest_country", "@contact_guest_state_or_province", "@contact_guest_city", "@contact_guest_website", "@contact_response_code" }, new List<string>() { UserId, ContactGuestName, ContactGuestRealName, ContactGuestRealLastName, ContactGuestEmail, ContactTitle, ContactText, ContactDateSend, ContactTimeSend, ContactIpAddress, ContactFileDirectoryPath, ContactFilePhysicalName, ContactType, ContactGuestPhoneNumber, ContactGuestAddress, ContactGuestPostalCode, ContactGuestAbout, ContactGuestBirthday, ContactGuestGender, ContactGuestPublicEmail, ContactGuestMobileNumber, ContactGuestZipCode, ContactGuestCountry, ContactGuestStateOrProvince, ContactGuestCity, ContactGuestWebsite, ContactResponseCode });

            dbdr.dr.Read();

            ContactId = dbdr.dr["contact_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_contact", new List<string>() { "@user_id", "@contact_guest_name", "@contact_guest_real_name", "@contact_guest_real_last_name", "@contact_guest_email", "@contact_title", "@contact_text", "@contact_date_send", "@contact_time_send", "@contact_ip_address", "@contact_file_directory_path", "@contact_file_physical_name", "@contact_type", "@contact_guest_phone_number", "@contact_guest_address", "@contact_guest_postal_code", "@contact_guest_about", "@contact_guest_birthday", "@contact_guest_gender", "@contact_guest_public_email", "@contact_guest_mobile_number", "@contact_guest_zip_code", "@contact_guest_country", "@contact_guest_state_or_province", "@contact_guest_city", "@contact_guest_website", "@contact_response_code" }, new List<string>() { UserId, ContactGuestName, ContactGuestRealName, ContactGuestRealLastName, ContactGuestEmail, ContactTitle, ContactText, ContactDateSend, ContactTimeSend, ContactIpAddress, ContactFileDirectoryPath, ContactFilePhysicalName, ContactType, ContactGuestPhoneNumber, ContactGuestAddress, ContactGuestPostalCode, ContactGuestAbout, ContactGuestBirthday, ContactGuestGender, ContactGuestPublicEmail, ContactGuestMobileNumber, ContactGuestZipCode, ContactGuestCountry, ContactGuestStateOrProvince, ContactGuestCity, ContactGuestWebsite, ContactResponseCode });

            ReturnDr.Read();

            ContactId = ReturnDr["contact_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_contact", new List<string>() { "@contact_id", "@user_id", "@contact_guest_name", "@contact_guest_real_name", "@contact_guest_real_last_name", "@contact_guest_email", "@contact_title", "@contact_text", "@contact_date_send", "@contact_time_send", "@contact_ip_address", "@contact_file_directory_path", "@contact_file_physical_name", "@contact_type", "@contact_guest_phone_number", "@contact_guest_address", "@contact_guest_postal_code", "@contact_guest_about", "@contact_guest_birthday", "@contact_guest_gender", "@contact_guest_public_email", "@contact_guest_mobile_number", "@contact_guest_zip_code", "@contact_guest_country", "@contact_guest_state_or_province", "@contact_guest_city", "@contact_guest_website" }, new List<string>() { ContactId, UserId, ContactGuestName, ContactGuestRealName, ContactGuestRealLastName, ContactGuestEmail, ContactTitle, ContactText, ContactDateSend, ContactTimeSend, ContactIpAddress, ContactFileDirectoryPath, ContactFilePhysicalName, ContactType, ContactGuestPhoneNumber, ContactGuestAddress, ContactGuestPostalCode, ContactGuestAbout, ContactGuestBirthday, ContactGuestGender, ContactGuestPublicEmail, ContactGuestMobileNumber, ContactGuestZipCode, ContactGuestCountry, ContactGuestStateOrProvince, ContactGuestCity, ContactGuestWebsite });
        }

        public void FillCurrentContact(string ContactId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_contact", "@contact_id", ContactId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ContactId = dbdr.dr["contact_id"].ToString();
            UserId = dbdr.dr["user_id"].ToString();
            ContactGuestName = dbdr.dr["contact_guest_name"].ToString();
            ContactGuestRealName = dbdr.dr["contact_guest_real_name"].ToString();
            ContactGuestRealLastName = dbdr.dr["contact_guest_real_last_name"].ToString();
            ContactGuestEmail = dbdr.dr["contact_guest_email"].ToString();
            ContactTitle = dbdr.dr["contact_title"].ToString();
            ContactText = dbdr.dr["contact_text"].ToString();
            ContactDateSend = dbdr.dr["contact_date_send"].ToString();
            ContactTimeSend = dbdr.dr["contact_time_send"].ToString();
            ContactIpAddress = dbdr.dr["contact_ip_address"].ToString();
            ContactFileDirectoryPath = dbdr.dr["contact_file_directory_path"].ToString();
            ContactFilePhysicalName = dbdr.dr["contact_file_physical_name"].ToString();
            ContactType = dbdr.dr["contact_type"].ToString();
            ContactGuestPhoneNumber = dbdr.dr["contact_guest_phone_number"].ToString();
            ContactGuestAddress = dbdr.dr["contact_guest_address"].ToString();
            ContactGuestPostalCode = dbdr.dr["contact_guest_postal_code"].ToString();
            ContactGuestAbout = dbdr.dr["contact_guest_about"].ToString();
            ContactGuestBirthday = dbdr.dr["contact_guest_birthday"].ToString();
            ContactGuestGender = dbdr.dr["contact_guest_gender"].ToString();
            ContactGuestPublicEmail = dbdr.dr["contact_guest_public_email"].ToString().TrueFalseToZeroOne();
            ContactGuestMobileNumber = dbdr.dr["contact_guest_mobile_number"].ToString();
            ContactGuestZipCode = dbdr.dr["contact_guest_zip_code"].ToString();
            ContactGuestCountry = dbdr.dr["contact_guest_country"].ToString();
            ContactGuestStateOrProvince = dbdr.dr["contact_guest_state_or_province"].ToString();
            ContactGuestCity = dbdr.dr["contact_guest_city"].ToString();
            ContactGuestWebsite = dbdr.dr["contact_guest_website"].ToString();
            ContactResponseCode = dbdr.dr["contact_response_code"].ToString();
            ContactResponseText = dbdr.dr["contact_response_text"].ToString();

            db.Close();
        }

        public void FillCurrentContactWithReturnDr(string ContactId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_contact", "@contact_id", ContactId);

            if (ReturnDr == null || !ReturnDr.HasRows)
            {
                ReturnDb.Close();
                return;
            }

            ReturnDr.Read();
        }

        public string GetColumnValue(string ColumnName)
        {
            switch (ColumnName)
            {
                case "contact_id": return ContactId;
                case "user_id": return UserId;
                case "contact_guest_name": return ContactGuestName;
                case "contact_guest_real_name": return ContactGuestRealName;
                case "contact_guest_real_last_name": return ContactGuestRealLastName;
                case "contact_guest_email": return ContactGuestEmail;
                case "contact_title": return ContactTitle;
                case "contact_text": return ContactText;
                case "contact_date_send": return ContactDateSend;
                case "contact_time_send": return ContactTimeSend;
                case "contact_ip_address": return ContactIpAddress;
                case "contact_file_directory_path": return ContactFileDirectoryPath;
                case "contact_file_physical_name": return ContactFilePhysicalName;
                case "contact_type": return ContactType;
                case "contact_guest_phone_number": return ContactGuestPhoneNumber;
                case "contact_guest_address": return ContactGuestAddress;
                case "contact_guest_postal_code": return ContactGuestPostalCode;
                case "contact_guest_about": return ContactGuestAbout;
                case "contact_guest_birthday": return ContactGuestBirthday;
                case "contact_guest_gender": return ContactGuestGender;
                case "contact_guest_public_email": return ContactGuestPublicEmail;
                case "contact_guest_mobile_number": return ContactGuestMobileNumber;
                case "contact_guest_zip_code": return ContactGuestZipCode;
                case "contact_guest_country": return ContactGuestCountry;
                case "contact_guest_state_or_province": return ContactGuestStateOrProvince;
                case "contact_guest_city": return ContactGuestCity;
                case "contact_guest_website": return ContactGuestWebsite;
                case "contact_response_code": return ContactResponseCode;
                case "contact_response_text": return ContactResponseText;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ContactId = "";
            UserId = "";
            ContactGuestName = "";
            ContactGuestRealName = "";
            ContactGuestRealLastName = "";
            ContactGuestEmail = "";
            ContactTitle = "";
            ContactText = "";
            ContactDateSend = "";
            ContactTimeSend = "";
            ContactIpAddress = "";
            ContactFileDirectoryPath = "";
            ContactFilePhysicalName = "";
            ContactType = "";
            ContactGuestPhoneNumber = "";
            ContactGuestAddress = "";
            ContactGuestPostalCode = "";
            ContactGuestAbout = "";
            ContactGuestBirthday = "";
            ContactGuestGender = "";
            ContactGuestPublicEmail = "";
            ContactGuestMobileNumber = "";
            ContactGuestZipCode = "";
            ContactGuestCountry = "";
            ContactGuestStateOrProvince = "";
            ContactGuestCity = "";
            ContactGuestWebsite = "";
            ContactResponseCode = "";
            ContactResponseText = "";

            ReturnDr.Close();
        }

        public string GetContactCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_contact_count");

            dbdr.dr.Read();

            string ContactCount = dbdr.dr["contact_count"].ToString();

            db.Close();

            return ContactCount;
        }

        public string GetTodayNewContactCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_contact_count", "@contact_date_send", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayContactCount = dbdr.dr["today_contact_count"].ToString();

            db.Close();

            return TodayContactCount;
        }

        public string GetContactCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_contact", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ContactCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ContactCount;
        }

        public int GetUserContactCount(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_contact_count", "@user_id", UserId);

            dbdr.dr.Read();

            string UserContactCount = dbdr.dr["user_contact_count"].ToString();

            db.Close();

            return int.Parse(UserContactCount);
        }

        public void AddContactResponseCode(string ContactId, string ResponseCode)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_contact_response_code", new List<string>() { "@contact_id", "@contact_response_code" }, new List<string>() { ContactId, ResponseCode });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Refresh();
                ReturnDb.Close();
                ReturnDb.Dispose();
            }
        }
    }
}