using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Comment : IDisposable
    {
        public string CommentId = "";
        public string ContentId = "";
        public string UserId = "";
        public string ParentComment = "";
        public string CommentGuestName = "";
        public string CommentGuestRealName = "";
        public string CommentGuestRealLastName = "";
        public string CommentGuestEmail = "";
        public string CommentTitle = "";
        public string CommentText = "";
        public string CommentDateSend = "";
        public string CommentTimeSend = "";
        public string CommentActive = "";
        public string CommentIpAddress = "";
        public string CommentFileDirectoryPath = "";
        public string CommentFilePhysicalName = "";
        public string CommentType = "";
        public string CommentGuestPhoneNumber = "";
        public string CommentGuestAddress = "";
        public string CommentGuestPostalCode = "";
        public string CommentGuestAbout = "";
        public string CommentGuestBirthday = "";
        public string CommentGuestGender = "";
        public string CommentGuestPublicEmail = "";
        public string CommentGuestMobileNumber = "";
        public string CommentGuestZipCode = "";
        public string CommentGuestCountry = "";
        public string CommentGuestStateOrProvince = "";
        public string CommentGuestCity = "";
        public string CommentGuestWebsite = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public bool IsUserComment(string UserId, string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_comment", new List<string>() { "@user_id", "@comment_id" }, new List<string>() { UserId, CommentId });

            dbdr.dr.Read();

            bool IsUserComment = dbdr.dr["is_user_comment"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserComment;
        }

        public void Approval(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("approval_comment", "@comment_id", CommentId);
        }

        public void Delete(string CommentId)
        {
            DataUse.Comment duc = new DataUse.Comment();
            duc.FillCurrentComment(CommentId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_comment", "@comment_id", CommentId);

            // Delete Physical File
            if (!string.IsNullOrEmpty(duc.CommentFilePhysicalName))
                File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + duc.CommentFileDirectoryPath + "/" + duc.CommentFilePhysicalName));

            // If File Is Image, Delete Thumpbinal Image
            if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
            {
                string FileExtension = Path.GetExtension(duc.CommentFilePhysicalName);

                if (FileAndDirectory.IsImageExtension(FileExtension))
                {
                    if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + duc.CommentFileDirectoryPath + "/thumb/" + duc.CommentFilePhysicalName)))
                        File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/comment/" + duc.CommentFileDirectoryPath + "/thumb/" + duc.CommentFilePhysicalName));
                }
            } 
        }

        public void Inactive(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_comment", "@comment_id", CommentId);
        }
        
        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_comment", new List<string>() { "@content_id", "@user_id", "@parent_comment", "@comment_guest_name", "@comment_guest_real_name", "@comment_guest_real_last_name", "@comment_guest_email", "@comment_title", "@comment_text", "@comment_date_send", "@comment_time_send", "@comment_active", "@comment_ip_address", "@comment_file_directory_path", "@comment_file_physical_name", "@comment_type", "@comment_guest_phone_number", "@comment_guest_address", "@comment_guest_postal_code", "@comment_guest_about", "@comment_guest_birthday", "@comment_guest_gender", "@comment_guest_public_email", "@comment_guest_mobile_number", "@comment_guest_zip_code", "@comment_guest_country", "@comment_guest_state_or_province", "@comment_guest_city", "@comment_guest_website" }, new List<string>() { ContentId, UserId, ParentComment, CommentGuestName, CommentGuestRealName, CommentGuestRealLastName, CommentGuestEmail, CommentTitle, CommentText, CommentDateSend, CommentTimeSend, CommentActive, CommentIpAddress, CommentFileDirectoryPath, CommentFilePhysicalName, CommentType, CommentGuestPhoneNumber, CommentGuestAddress, CommentGuestPostalCode, CommentGuestAbout, CommentGuestBirthday, CommentGuestGender, CommentGuestPublicEmail, CommentGuestMobileNumber, CommentGuestZipCode, CommentGuestCountry, CommentGuestStateOrProvince, CommentGuestCity, CommentGuestWebsite });

            dbdr.dr.Read();

            CommentId = dbdr.dr["comment_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_comment", new List<string>() { "@content_id", "@user_id", "@parent_comment", "@comment_guest_name", "@comment_guest_real_name", "@comment_guest_real_last_name", "@comment_guest_email", "@comment_title", "@comment_text", "@comment_date_send", "@comment_time_send", "@comment_active", "@comment_ip_address", "@comment_file_directory_path", "@comment_file_physical_name", "@comment_type", "@comment_guest_phone_number", "@comment_guest_address", "@comment_guest_postal_code", "@comment_guest_about", "@comment_guest_birthday", "@comment_guest_gender", "@comment_guest_public_email", "@comment_guest_mobile_number", "@comment_guest_zip_code", "@comment_guest_country", "@comment_guest_state_or_province", "@comment_guest_city", "@comment_guest_website" }, new List<string>() { ContentId, UserId, ParentComment, CommentGuestName, CommentGuestRealName, CommentGuestRealLastName, CommentGuestEmail, CommentTitle, CommentText, CommentDateSend, CommentTimeSend, CommentActive, CommentIpAddress, CommentFileDirectoryPath, CommentFilePhysicalName, CommentType, CommentGuestPhoneNumber, CommentGuestAddress, CommentGuestPostalCode, CommentGuestAbout, CommentGuestBirthday, CommentGuestGender, CommentGuestPublicEmail, CommentGuestMobileNumber, CommentGuestZipCode, CommentGuestCountry, CommentGuestStateOrProvince, CommentGuestCity, CommentGuestWebsite });

            ReturnDr.Read();

            CommentId = ReturnDr["comment_id"].ToString();
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_comment", new List<string>() { "@comment_id", "@content_id", "@user_id", "@parent_comment", "@comment_guest_name", "@comment_guest_real_name", "@comment_guest_real_last_name", "@comment_guest_email", "@comment_title", "@comment_text", "@comment_date_send", "@comment_time_send", "@comment_active", "@comment_ip_address", "@comment_file_directory_path", "@comment_file_physical_name", "@comment_type", "@comment_guest_phone_number", "@comment_guest_address", "@comment_guest_postal_code", "@comment_guest_about", "@comment_guest_birthday", "@comment_guest_gender", "@comment_guest_public_email", "@comment_guest_mobile_number", "@comment_guest_zip_code", "@comment_guest_country", "@comment_guest_state_or_province", "@comment_guest_city", "@comment_guest_website" }, new List<string>() { CommentId, ContentId, UserId, ParentComment, CommentGuestName, CommentGuestRealName, CommentGuestRealLastName, CommentGuestEmail, CommentTitle, CommentText, CommentDateSend, CommentTimeSend, CommentActive, CommentIpAddress, CommentFileDirectoryPath, CommentFilePhysicalName, CommentType, CommentGuestPhoneNumber, CommentGuestAddress, CommentGuestPostalCode, CommentGuestAbout, CommentGuestBirthday, CommentGuestGender, CommentGuestPublicEmail, CommentGuestMobileNumber, CommentGuestZipCode, CommentGuestCountry, CommentGuestStateOrProvince, CommentGuestCity, CommentGuestWebsite });
        }
        
        public void FillCurrentComment(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_comment", "@comment_id", CommentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.CommentId = dbdr.dr["comment_id"].ToString();
            ContentId = dbdr.dr["content_id"].ToString();
            UserId = dbdr.dr["user_id"].ToString();
            ParentComment = dbdr.dr["parent_comment"].ToString();
            CommentGuestName = dbdr.dr["comment_guest_name"].ToString();
            CommentGuestRealName = dbdr.dr["comment_guest_real_name"].ToString();
            CommentGuestRealLastName = dbdr.dr["comment_guest_real_last_name"].ToString();
            CommentGuestEmail = dbdr.dr["comment_guest_email"].ToString();
            CommentTitle = dbdr.dr["comment_title"].ToString();
            CommentText = dbdr.dr["comment_text"].ToString();
            CommentDateSend = dbdr.dr["comment_date_send"].ToString();
            CommentTimeSend = dbdr.dr["comment_time_send"].ToString();
            CommentActive = dbdr.dr["comment_active"].ToString().TrueFalseToZeroOne();
            CommentIpAddress = dbdr.dr["comment_ip_address"].ToString();
            CommentFileDirectoryPath = dbdr.dr["comment_file_directory_path"].ToString();
            CommentFilePhysicalName = dbdr.dr["comment_file_physical_name"].ToString();
            CommentType = dbdr.dr["comment_type"].ToString();
            CommentGuestPhoneNumber = dbdr.dr["comment_guest_phone_number"].ToString();
            CommentGuestAddress = dbdr.dr["comment_guest_address"].ToString();
            CommentGuestPostalCode = dbdr.dr["comment_guest_postal_code"].ToString();
            CommentGuestAbout = dbdr.dr["comment_guest_about"].ToString();
            CommentGuestBirthday = dbdr.dr["comment_guest_birthday"].ToString();
            CommentGuestGender = dbdr.dr["comment_guest_gender"].ToString();
            CommentGuestPublicEmail = dbdr.dr["comment_guest_public_email"].ToString().TrueFalseToZeroOne();
            CommentGuestMobileNumber = dbdr.dr["comment_guest_mobile_number"].ToString();
            CommentGuestZipCode = dbdr.dr["comment_guest_zip_code"].ToString();
            CommentGuestCountry = dbdr.dr["comment_guest_country"].ToString();
            CommentGuestStateOrProvince = dbdr.dr["comment_guest_state_or_province"].ToString();
            CommentGuestCity = dbdr.dr["comment_guest_city"].ToString();
            CommentGuestWebsite = dbdr.dr["comment_guest_website"].ToString();

            db.Close();
        }

        public void FillCurrentCommentWithReturnDr(string CommentId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_comment", "@comment_id", CommentId);

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
                case "comment_id": return CommentId;
                case "content_id": return ContentId;
                case "user_id": return UserId;
                case "parent_comment": return ParentComment;
                case "comment_guest_name": return CommentGuestName;
                case "comment_guest_real_name": return CommentGuestRealName;
                case "comment_guest_real_last_name": return CommentGuestRealLastName;
                case "comment_guest_email": return CommentGuestEmail;
                case "comment_title": return CommentTitle;
                case "comment_text": return CommentText;
                case "comment_date_send": return CommentDateSend;
                case "comment_time_send": return CommentTimeSend;
                case "comment_active": return CommentActive;
                case "comment_ip_address": return CommentIpAddress;
                case "comment_file_directory_path": return CommentFileDirectoryPath;
                case "comment_file_physical_name": return CommentFilePhysicalName;
                case "comment_type": return CommentType;
                case "comment_guest_phone_number": return CommentGuestPhoneNumber;
                case "comment_guest_address": return CommentGuestAddress;
                case "comment_guest_postal_code": return CommentGuestPostalCode;
                case "comment_guest_about": return CommentGuestAbout;
                case "comment_guest_birthday": return CommentGuestBirthday;
                case "comment_guest_gender": return CommentGuestGender;
                case "comment_guest_public_email": return CommentGuestPublicEmail;
                case "comment_guest_mobile_number": return CommentGuestMobileNumber;
                case "comment_guest_zip_code": return CommentGuestZipCode;
                case "comment_guest_country": return CommentGuestCountry;
                case "comment_guest_state_or_province": return CommentGuestStateOrProvince;
                case "comment_guest_city": return CommentGuestCity;
                case "comment_guest_website": return CommentGuestWebsite;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            CommentId = "";
            ContentId = "";
            UserId = "";
            ParentComment = "";
            CommentGuestName = "";
            CommentGuestRealName = "";
            CommentGuestRealLastName = "";
            CommentGuestEmail = "";
            CommentTitle = "";
            CommentText = "";
            CommentDateSend = "";
            CommentTimeSend = "";
            CommentActive = "";
            CommentIpAddress = "";
            CommentFileDirectoryPath = "";
            CommentFilePhysicalName = "";
            CommentType = "";
            CommentGuestPhoneNumber = "";
            CommentGuestAddress = "";
            CommentGuestPostalCode = "";
            CommentGuestAbout = "";
            CommentGuestBirthday = "";
            CommentGuestGender = "";
            CommentGuestPublicEmail = "";
            CommentGuestMobileNumber = "";
            CommentGuestZipCode = "";
            CommentGuestCountry = "";
            CommentGuestStateOrProvince = "";
            CommentGuestCity = "";
            CommentGuestWebsite = "";

            ReturnDr.Close();
        }

        public bool GetContentVerifyCommentsByContentId(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_verify_comments_by_content_id", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                bool ContentVerifyComments = dbdr.dr["content_verify_comments"].ToString().TrueFalseToBoolean();

                db.Close();

                return ContentVerifyComments;
            }

            db.Close();

            return false;
        }

        public bool GetContentVerifyCommentsByCommentId(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_verify_comments_by_comment_id", "@comment_id", CommentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                bool ContentVerifyComments = dbdr.dr["content_verify_comments"].ToString().TrueFalseToBoolean();

                db.Close();

                return ContentVerifyComments;
            }

            db.Close();

            return false;
        }

        public bool CheckUserCommentSendWithoutApprovalByGroupId(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("check_user_comment_sent_without_approval_by_group_id", "@group_id", GroupId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                bool RoleAddFreeCommentContent = dbdr.dr["role_add_free_comment_content"].ToString().TrueFalseToBoolean();

                db.Close();

                return RoleAddFreeCommentContent;
            }

            db.Close();

            return false;
        }

        public DateTime GetCommentDateTimeCreate(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_comment_date_time_create", "@comment_id", CommentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                DateTime CommentDateTimeCreate = Convert.ToDateTime(dbdr.dr["comment_date_time_create"].ToString());

                db.Close();

                return CommentDateTimeCreate;
            }

            db.Close();

            return DateTime.Now;
        }

        public int GetCommentCommentReplyCount(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_comment_comment_reply_count", "@comment_id", CommentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                int CommentCommentReplyCount = int.Parse(dbdr.dr["comment_comment_reply_count"].ToString());

                return CommentCommentReplyCount;
            }

            db.Close();

            return 0;
        }

        public DateTime GetCommentDateTimeSend(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_comment_date_time_send", "@comment_id", CommentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                DateTime CommentDateTimeSend = Convert.ToDateTime(dbdr.dr["comment_date_time_send"].ToString());

                db.Close();

                return CommentDateTimeSend;
            }

            db.Close();

            return DateTime.Now;
        }

        public string GetCommentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_comment_count");

            dbdr.dr.Read();

            string CommentCount = dbdr.dr["comment_count"].ToString();

            db.Close();

            return CommentCount;
        }

        public string GetTodayNewCommentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_comment_count", "@comment_date_send", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayCommentCount = dbdr.dr["today_comment_count"].ToString();

            db.Close();

            return TodayCommentCount;
        }

        public string GetInactiveCommentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_inactive_comment_count");

            dbdr.dr.Read();

            string InactiveCommentCount = dbdr.dr["inactive_comment_count"].ToString();

            db.Close();

            return InactiveCommentCount;
        }

        public string GetCommentCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_comment", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string CommentCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return CommentCount;
        }

        public int GetUserCommentCount(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_comment_count", "@user_id", UserId);

            dbdr.dr.Read();

            string UserCommentCount = dbdr.dr["user_comment_count"].ToString();

            db.Close();

            return int.Parse(UserCommentCount);
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