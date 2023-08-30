using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class ContentReply : IDisposable
    {
        public string ContentReplyId = "";
        public string ContentId = "";
        public string UserId = "";
        public string ContentReplyGuestName = "";
        public string ContentReplyGuestRealName = "";
        public string ContentReplyGuestRealLastName = "";
        public string ContentReplyGuestEmail = "";
        public string ContentReplyText = "";
        public string ContentReplyDateSend = "";
        public string ContentReplyTimeSend = "";
        public string ContentReplyActive = "";
        public string ContentReplyIpAddress = "";
        public string ContentReplyType = "";
        public string ContentReplyGuestPhoneNumber = "";
        public string ContentReplyGuestAddress = "";
        public string ContentReplyGuestPostalCode = "";
        public string ContentReplyGuestAbout = "";
        public string ContentReplyGuestBirthday = "";
        public string ContentReplyGuestGender = "";
        public string ContentReplyGuestPublicEmail = "";
        public string ContentReplyGuestMobileNumber = "";
        public string ContentReplyGuestZipCode = "";
        public string ContentReplyGuestCountry = "";
        public string ContentReplyGuestStateOrProvince = "";
        public string ContentReplyGuestCity = "";
        public string ContentReplyGuestWebsite = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public bool IsUserContentReply(string UserId, string ContentReplyId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_content_reply", new List<string>() { "@user_id", "@content_reply_id" }, new List<string>() { UserId, ContentReplyId });

            dbdr.dr.Read();

            bool IsUserContentReply = dbdr.dr["is_user_content_reply"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserContentReply;
        }

        public void Active(string ContentReplyId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_content_reply", "@content_reply_id", ContentReplyId);
        }

        public void Delete(string ContentReplyId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content_reply", "@content_reply_id", ContentReplyId);
        }

        public void Inactive(string ContentReplyId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_content_reply", "@content_reply_id", ContentReplyId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_content_reply", new List<string>() { "@content_id", "@user_id", "@content_reply_guest_name", "@content_reply_guest_real_name", "@content_reply_guest_real_last_name", "@content_reply_guest_email", "@content_reply_text", "@content_reply_date_send", "@content_reply_time_send", "@content_reply_active", "@content_reply_ip_address", "@content_reply_type", "@content_reply_guest_phone_number", "@content_reply_guest_address", "@content_reply_guest_postal_code", "@content_reply_guest_about", "@content_reply_guest_birthday", "@content_reply_guest_gender", "@content_reply_guest_public_email", "@content_reply_guest_mobile_number", "@content_reply_guest_zip_code", "@content_reply_guest_country", "@content_reply_guest_state_or_province", "@content_reply_guest_city", "@content_reply_guest_website" }, new List<string>() { ContentId, UserId, ContentReplyGuestName, ContentReplyGuestRealName, ContentReplyGuestRealLastName, ContentReplyGuestEmail, ContentReplyText, ContentReplyDateSend, ContentReplyTimeSend, ContentReplyActive, ContentReplyIpAddress, ContentReplyType, ContentReplyGuestPhoneNumber, ContentReplyGuestAddress, ContentReplyGuestPostalCode, ContentReplyGuestAbout, ContentReplyGuestBirthday, ContentReplyGuestGender, ContentReplyGuestPublicEmail, ContentReplyGuestMobileNumber, ContentReplyGuestZipCode, ContentReplyGuestCountry, ContentReplyGuestStateOrProvince, ContentReplyGuestCity, ContentReplyGuestWebsite });

            dbdr.dr.Read();

            ContentReplyId = dbdr.dr["content_reply_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_content_reply", new List<string>() { "@content_id", "@user_id", "@content_reply_guest_name", "@content_reply_guest_real_name", "@content_reply_guest_real_last_name", "@content_reply_guest_email", "@content_reply_text", "@content_reply_date_send", "@content_reply_time_send", "@content_reply_active", "@content_reply_ip_address", "@content_reply_type", "@content_reply_guest_phone_number", "@content_reply_guest_address", "@content_reply_guest_postal_code", "@content_reply_guest_about", "@content_reply_guest_birthday", "@content_reply_guest_gender", "@content_reply_guest_public_email", "@content_reply_guest_mobile_number", "@content_reply_guest_zip_code", "@content_reply_guest_country", "@content_reply_guest_state_or_province", "@content_reply_guest_city", "@content_reply_guest_website" }, new List<string>() { ContentId, UserId, ContentReplyGuestName, ContentReplyGuestRealName, ContentReplyGuestRealLastName, ContentReplyGuestEmail, ContentReplyText, ContentReplyDateSend, ContentReplyTimeSend, ContentReplyActive, ContentReplyIpAddress, ContentReplyType, ContentReplyGuestPhoneNumber, ContentReplyGuestAddress, ContentReplyGuestPostalCode, ContentReplyGuestAbout, ContentReplyGuestBirthday, ContentReplyGuestGender, ContentReplyGuestPublicEmail, ContentReplyGuestMobileNumber, ContentReplyGuestZipCode, ContentReplyGuestCountry, ContentReplyGuestStateOrProvince, ContentReplyGuestCity, ContentReplyGuestWebsite });

            ReturnDr.Read();

            ContentReplyId = ReturnDr["content_reply_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_content_reply", new List<string>() { "@content_reply_id", "@content_id", "@user_id", "@content_reply_guest_name", "@content_reply_guest_real_name", "@content_reply_guest_real_last_name", "@content_reply_guest_email", "@content_reply_text", "@content_reply_date_send", "@content_reply_time_send", "@content_reply_active", "@content_reply_ip_address", "@content_reply_type", "@content_reply_guest_phone_number", "@content_reply_guest_address", "@content_reply_guest_postal_code", "@content_reply_guest_about", "@content_reply_guest_birthday", "@content_reply_guest_gender", "@content_reply_guest_public_email", "@content_reply_guest_mobile_number", "@content_reply_guest_zip_code", "@content_reply_guest_country", "@content_reply_guest_state_or_province", "@content_reply_guest_city", "@content_reply_guest_website" }, new List<string>() { ContentReplyId, ContentId, UserId, ContentReplyGuestName, ContentReplyGuestRealName, ContentReplyGuestRealLastName, ContentReplyGuestEmail, ContentReplyText, ContentReplyDateSend, ContentReplyTimeSend, ContentReplyActive, ContentReplyIpAddress, ContentReplyType, ContentReplyGuestPhoneNumber, ContentReplyGuestAddress, ContentReplyGuestPostalCode, ContentReplyGuestAbout, ContentReplyGuestBirthday, ContentReplyGuestGender, ContentReplyGuestPublicEmail, ContentReplyGuestMobileNumber, ContentReplyGuestZipCode, ContentReplyGuestCountry, ContentReplyGuestStateOrProvince, ContentReplyGuestCity, ContentReplyGuestWebsite });
        }

        public void FillCurrentContentReply(string ContentReplyId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_content_reply", "@content_reply_id", ContentReplyId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ContentReplyId = dbdr.dr["content_reply_id"].ToString();
            ContentId = dbdr.dr["content_id"].ToString();
            UserId = dbdr.dr["user_id"].ToString();
            ContentReplyGuestName = dbdr.dr["content_reply_guest_name"].ToString();
            ContentReplyGuestRealName = dbdr.dr["content_reply_guest_real_name"].ToString();
            ContentReplyGuestRealLastName = dbdr.dr["content_reply_guest_real_last_name"].ToString();
            ContentReplyGuestEmail = dbdr.dr["content_reply_guest_email"].ToString();
            ContentReplyText = dbdr.dr["content_reply_text"].ToString();
            ContentReplyDateSend = dbdr.dr["content_reply_date_send"].ToString();
            ContentReplyTimeSend = dbdr.dr["content_reply_time_send"].ToString();
            ContentReplyActive = dbdr.dr["content_reply_active"].ToString().TrueFalseToZeroOne();
            ContentReplyIpAddress = dbdr.dr["content_reply_ip_address"].ToString();
            ContentReplyType = dbdr.dr["content_reply_type"].ToString();
            ContentReplyGuestPhoneNumber = dbdr.dr["content_reply_guest_phone_number"].ToString();
            ContentReplyGuestAddress = dbdr.dr["content_reply_guest_address"].ToString();
            ContentReplyGuestPostalCode = dbdr.dr["content_reply_guest_postal_code"].ToString();
            ContentReplyGuestAbout = dbdr.dr["content_reply_guest_about"].ToString();
            ContentReplyGuestBirthday = dbdr.dr["content_reply_guest_birthday"].ToString();
            ContentReplyGuestGender = dbdr.dr["content_reply_guest_gender"].ToString();
            ContentReplyGuestPublicEmail = dbdr.dr["content_reply_guest_public_email"].ToString().TrueFalseToZeroOne();
            ContentReplyGuestMobileNumber = dbdr.dr["content_reply_guest_mobile_number"].ToString();
            ContentReplyGuestZipCode = dbdr.dr["content_reply_guest_zip_code"].ToString();
            ContentReplyGuestCountry = dbdr.dr["content_reply_guest_country"].ToString();
            ContentReplyGuestStateOrProvince = dbdr.dr["content_reply_guest_state_or_province"].ToString();
            ContentReplyGuestCity = dbdr.dr["content_reply_guest_city"].ToString();
            ContentReplyGuestWebsite = dbdr.dr["content_reply_guest_website"].ToString();

            db.Close();
        }

        public void FillCurrentContentReplyWithReturnDr(string ContentReplyId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_content_reply", "@content_reply_id", ContentReplyId);

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
                case "content_reply_id": return ContentReplyId;
                case "content_id": return ContentId;
                case "user_id": return UserId;
                case "content_reply_guest_name": return ContentReplyGuestName;
                case "content_reply_guest_real_name": return ContentReplyGuestRealName;
                case "content_reply_guest_real_last_name": return ContentReplyGuestRealLastName;
                case "content_reply_guest_email": return ContentReplyGuestEmail;
                case "content_reply_text": return ContentReplyText;
                case "content_reply_date_send": return ContentReplyDateSend;
                case "content_reply_time_send": return ContentReplyTimeSend;
                case "content_reply_active": return ContentReplyActive;
                case "content_reply_ip_address": return ContentReplyIpAddress;
                case "content_reply_type": return ContentReplyType;
                case "content_reply_guest_phone_number": return ContentReplyGuestPhoneNumber;
                case "content_reply_guest_address": return ContentReplyGuestAddress;
                case "content_reply_guest_postal_code": return ContentReplyGuestPostalCode;
                case "link_id": return ContentReplyGuestAbout;
                case "content_reply_guest_about": return ContentReplyGuestBirthday;
                case "content_reply_guest_birthday": return ContentReplyGuestGender;
                case "content_reply_guest_gender": return ContentReplyGuestPublicEmail;
                case "content_reply_guest_public_email": return ContentReplyGuestMobileNumber;
                case "content_reply_guest_mobile_number": return ContentReplyGuestZipCode;
                case "content_reply_guest_zip_code": return ContentReplyGuestCountry;
                case "content_reply_guest_country": return ContentReplyGuestStateOrProvince;
                case "content_reply_guest_state_or_province": return ContentReplyGuestCity;
                case "content_reply_guest_city": return ContentReplyGuestWebsite;
                case "content_reply_guest_website": return ContentReplyGuestWebsite;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ContentReplyId = "";
            ContentId = "";
            UserId = "";
            ContentReplyGuestName = "";
            ContentReplyGuestRealName = "";
            ContentReplyGuestRealLastName = "";
            ContentReplyGuestEmail = "";
            ContentReplyText = "";
            ContentReplyDateSend = "";
            ContentReplyTimeSend = "";
            ContentReplyActive = "";
            ContentReplyIpAddress = "";
            ContentReplyType = "";
            ContentReplyGuestPhoneNumber = "";
            ContentReplyGuestAddress = "";
            ContentReplyGuestPostalCode = "";
            ContentReplyGuestAbout = "";
            ContentReplyGuestBirthday = "";
            ContentReplyGuestGender = "";
            ContentReplyGuestPublicEmail = "";
            ContentReplyGuestMobileNumber = "";
            ContentReplyGuestZipCode = "";
            ContentReplyGuestCountry = "";
            ContentReplyGuestStateOrProvince = "";
            ContentReplyGuestCity = "";
            ContentReplyGuestWebsite = "";

            ReturnDr.Close();
        }

        public string GetContentReplyCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_reply", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ContentReplyCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ContentReplyCount;
        }

        public int GetUserContentReplyCount(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_content_reply_count", "@user_id", UserId);

            dbdr.dr.Read();

            string UserContentReplyCount = dbdr.dr["user_content_reply_count"].ToString();

            db.Close();

            return int.Parse(UserContentReplyCount);
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