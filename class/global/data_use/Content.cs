using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Content : IDisposable
    {
        public string ContentId = "";
        public string UserId = "";
        public string CategoryId = "";
        public string ContentTitle = "";
        public string ContentText = "";
        public string ContentDateCreate = "";
        public string ContentTimeCreate = "";
        public string ContentAlwaysOnTop = "";
        public string ContentStatus = "";
        public string ContentType = "";
        public string ContentVerifyComments = "";
        public string ContentPassword = "";
        public string ContentVisit = "";
        public string ContentPublicAccessShow = "";
        public string ContentAvatar = "";
        public string ContentIcon = "";
        
        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public bool IsUserContent(string UserId, string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_content", new List<string>() { "@user_id", "@content_id" }, new List<string>() { UserId, ContentId });

            dbdr.dr.Read();

            bool IsUserContent = dbdr.dr["is_user_content"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserContent;
        }

        public string GetContentIdByCommentId(string CommentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_id_by_comment_id", "@comment_id", CommentId);

            dbdr.dr.Read();

            string ContentId = dbdr.dr["content_id"].ToString();

            db.Close();

            return ContentId;
        }

        public bool GetContentAccessShowCheck(string ContentId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("content_access_show_check_by_group_id", new List<string>() { "@content_id", "@group_id" }, new List<string>() { ContentId, ccoc.GroupId });

            dbdr.dr.Read();

            string ContentAccessShow = dbdr.dr["content_access_show"].ToString();

            db.Close();

            if (ContentAccessShow == "1")
                return true;

            return false;
        }

        public void Delete(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content", "@content_id", ContentId);
        }

        public void Restore(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("restore_content", "@content_id", ContentId);
        }

        public void ToTrash(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("content_to_trash", "@content_id", ContentId);
        }

        public void Approval(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("approval_content", "@content_id", ContentId);
        }

        public void Active(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("approval_content", "@content_id", ContentId); ;
        }

        public void Inactive(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_content", "@content_id", ContentId);
        }
        
        public void DeleteContentAccessShow(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content_access_show", "@content_id", ContentId);
        }

        public void DeleteContentSource(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content_source", "@content_id", ContentId);
        }

        public void DeleteContentKeywords(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content_keywords", "@content_id", ContentId);
        }

        public void DeleteContentAvatar(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content_avatar", "@content_id", ContentId);
        }

        public void DeleteContentIcon(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_content_icon", "@content_id", ContentId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_content", new List<string>() { "@user_id", "@category_id", "@content_title", "@content_text", "@content_date_create", "@content_time_create", "@content_always_on_top", "@content_status", "@content_type", "@content_verify_comments", "@content_password", "@content_visit", "@content_public_access_show" }, new List<string>() { UserId, CategoryId, ContentTitle, ContentText, ContentDateCreate, ContentTimeCreate, ContentAlwaysOnTop, ContentStatus, ContentType, ContentVerifyComments, ContentPassword, ContentVisit, ContentPublicAccessShow });

            dbdr.dr.Read();

            ContentId = dbdr.dr["content_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_content", new List<string>() { "@user_id", "@category_id", "@content_title", "@content_text", "@content_date_create", "@content_time_create", "@content_always_on_top", "@content_status", "@content_type", "@content_verify_comments", "@content_password", "@content_visit", "@content_public_access_show" }, new List<string>() { UserId, CategoryId, ContentTitle, ContentText, ContentDateCreate, ContentTimeCreate, ContentAlwaysOnTop, ContentStatus, ContentType, ContentVerifyComments, ContentPassword, ContentVisit, ContentPublicAccessShow });

            ReturnDr.Read();

            ContentId = ReturnDr["content_id"].ToString();
        }

        public void SetContentAccessShow(string ContentId, List<ListItem> ContentAccessShowListContent)
        {
            if (ContentAccessShowListContent == null)
                return;

            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in ContentAccessShowListContent)
                if (item.Selected)
                    db.SetProcedure("set_content_access_show", new List<string>() { "@role_id", "@content_id" }, new List<string>() { item.Value, ContentId });
        }

        // Overload
        public void SetContentAccessShow(List<ListItem> ContentAccessShowListContent)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in ContentAccessShowListContent)
                if (item.Selected)
                    db.SetProcedure("set_content_access_show", new List<string>() { "@role_id", "@content_id" }, new List<string>() { item.Value, ContentId });
        }

        public void AddContentRating(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_content_rating", "@content_id", ContentId);
        }

        public void AddContentSource(string ContentId, string[] ContentSourceList)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (string Source in ContentSourceList)
                if (!string.IsNullOrEmpty(Source))
                    db.SetProcedure("add_content_source", new List<string>() { "@content_id", "@content_source_text" }, new List<string>() { ContentId, Source });
        }

        public void AddContentKeywords(string ContentId, string[] ContentKeywordsList)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (string Keyword in ContentKeywordsList)
                if(!string.IsNullOrEmpty(Keyword))
                    db.SetProcedure("add_content_keywords", new List<string>() { "@content_id", "@content_keywords_text" }, new List<string>() { ContentId, Keyword.Trim() });
        }

        public void AddContentAvatar(string ContentId, string ContentAvatar)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_content_avatar", new List<string>() { "@content_id", "@content_avatar_physical_name" }, new List<string>() { ContentId, ContentAvatar });
        }

        public void AddContentIcon(string ContentId, string ContentIcon)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_content_icon", new List<string>() { "@content_id", "@content_icon_physical_name" }, new List<string>() { ContentId, ContentIcon + ".png" });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_content", new List<string>() { "@content_id", "@user_id", "@category_id", "@content_title", "@content_text", "@content_date_create", "@content_time_create", "@content_always_on_top", "@content_status", "@content_type", "@content_verify_comments", "@content_password", "@content_visit", "@content_public_access_show" }, new List<string>() { ContentId, UserId, CategoryId, ContentTitle, ContentText, ContentDateCreate, ContentTimeCreate, ContentAlwaysOnTop, ContentStatus, ContentType, ContentVerifyComments, ContentPassword, ContentVisit, ContentPublicAccessShow });
        }

        public void FillCurrentContent(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_content", "@content_id", ContentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ContentId = dbdr.dr["content_id"].ToString();
            UserId = dbdr.dr["user_id"].ToString();
            CategoryId = dbdr.dr["category_id"].ToString();
            ContentTitle = dbdr.dr["content_title"].ToString();
            ContentText = dbdr.dr["content_text"].ToString();
            ContentDateCreate = dbdr.dr["content_date_create"].ToString();
            ContentTimeCreate = dbdr.dr["content_time_create"].ToString();
            ContentAlwaysOnTop = dbdr.dr["content_always_on_top"].ToString().TrueFalseToZeroOne();
            ContentStatus = dbdr.dr["content_status"].ToString();
            ContentType = dbdr.dr["content_type"].ToString();
            ContentVerifyComments = dbdr.dr["content_verify_comments"].ToString().TrueFalseToZeroOne();
            ContentPassword = dbdr.dr["content_password"].ToString();
            ContentVisit = dbdr.dr["content_visit"].ToString();
            ContentPublicAccessShow = dbdr.dr["content_public_access_show"].ToString().TrueFalseToZeroOne();
            ContentIcon = dbdr.dr["content_icon_physical_name"].ToString();
            ContentAvatar = dbdr.dr["content_avatar_physical_name"].ToString();

            db.Close();
        }

        public void FillCurrentContentWithReturnDr(string ContentId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_content", "@content_id", ContentId);

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
                case "content_id": return ContentId;
                case "user_id": return UserId;
                case "category_id": return CategoryId;
                case "content_title": return ContentTitle;
                case "content_text": return ContentText;
                case "content_date_create": return ContentDateCreate;
                case "content_time_create": return ContentTimeCreate;
                case "content_always_on_top": return ContentAlwaysOnTop;
                case "content_status": return ContentStatus;
                case "content_type": return ContentType;
                case "content_verify_comments": return ContentVerifyComments;
                case "content_password": return ContentPassword;
                case "content_visit": return ContentVisit;
                case "content_public_access_show": return ContentPublicAccessShow;
                case "content_icon_physical_name": return ContentIcon;
                case "content_avatar_physical_name": return ContentAvatar;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ContentId = "";
            UserId = "";
            CategoryId = "";
            ContentTitle = "";
            ContentText = "";
            ContentDateCreate = "";
            ContentTimeCreate = "";
            ContentAlwaysOnTop = "";
            ContentStatus = "";
            ContentType = "";
            ContentVerifyComments = "";
            ContentPassword = "";
            ContentVisit = "";
            ContentPublicAccessShow = "";
            ContentAvatar = "";
            ContentIcon = "";

            ReturnDr.Close();
        }
        
        public void IncreaseVisit(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("increase_content_visit", "@content_id", ContentId);
        }

        public string GetContentCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ContentCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ContentCount;
        }

        public string GetLastContentDateCreate()
        {
            DataBaseSocket db = new DataBaseSocket();

            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_last_content_date_create");
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ContentDateCreate = dbdr.dr["content_date_create"].ToString();

                db.Close();

                return ContentDateCreate;
            }
            else
            {
                db.Close();
                return ElanatConfig.GetNode("date_and_time/site_birthday").InnerText;
            }
        }

        public int GetContentCommentCount(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_comment_count", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                int ContentCommentCount = int.Parse(dbdr.dr["content_comment_count"].ToString());

                db.Close();

                return ContentCommentCount;
            }

            db.Close();

            return 0;
        }

        public DateTime GetContentDateTimeCreate(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_date_time_create", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                DateTime ContentDateTimeCreate = Convert.ToDateTime(dbdr.dr["content_date_time_create"].ToString());

                db.Close();

                return ContentDateTimeCreate;
            }

            db.Close();

            return DateTime.Now;
        }

        public int GetContentContentReplyCount(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_content_reply_count", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                int ContentContentReplyCount = int.Parse(dbdr.dr["content_content_reply_count"].ToString());

                db.Close();

                return ContentContentReplyCount;
            }

            db.Close();

            return 0;
        }

        public DateTime GetContentDateTimeSend(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_date_time_send", "@content_id" , ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                DateTime ContentDateTimeCreate = Convert.ToDateTime(dbdr.dr["content_date_time_create"].ToString());

                db.Close();

                return ContentDateTimeCreate;
            }

            db.Close();

            return DateTime.Now;
        }

        public string GetContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_count");

            dbdr.dr.Read();

            string ContentCount = dbdr.dr["content_count"].ToString();

            db.Close();

            return ContentCount;
        }

        public string ContentCount = "";
        public string AlwaysOnTopContentCount = "";
        public void FillContentCountWithAlwaysOnTopContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("fill_content_count_with_always_on_top_content_count");

            dbdr.dr.Read();

            ContentCount = dbdr.dr["content_count"].ToString();
            AlwaysOnTopContentCount = dbdr.dr["always_on_top_content_count"].ToString();

            db.Close();
        }

        public string GetTodayNewContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_content_count", "@content_date_create", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayContentCount = dbdr.dr["today_content_count"].ToString();

            db.Close();

            return TodayContentCount;
        }

        public string GetTodayNewActiveContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_active_content_count", "@content_date_create", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayActiveContentCount = dbdr.dr["today_active_content_count"].ToString();

            db.Close();

            return TodayActiveContentCount;
        }

        public string GetTodayNewInactiveContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_today_inactive_content_count", "@content_date_create", DateAndTime.GetDate("yyyy/MM/dd"));

            dbdr.dr.Read();

            string TodayInactiveContentCount = dbdr.dr["today_inactive_content_count"].ToString();

            db.Close();

            return TodayInactiveContentCount;
        }

        public string GetActiveContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_active_content_count");

            dbdr.dr.Read();

            string ActiveContentCount = dbdr.dr["active_content_count"].ToString();

            db.Close();

            return ActiveContentCount;
        }

        public string GetInactiveContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_inactive_content_count");

            dbdr.dr.Read();

            string InactiveContentCount = dbdr.dr["inactive_content_count"].ToString();

            db.Close();

            return InactiveContentCount;
        }

        public string GetTrashContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_trash_content_count");

            dbdr.dr.Read();

            string TrashContentCount = dbdr.dr["trash_content_count"].ToString();

            db.Close();

            return TrashContentCount;
        }

        public string GetDraftContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_draft_content_count");

            dbdr.dr.Read();

            string DraftContentCount = dbdr.dr["draft_content_count"].ToString();

            db.Close();

            return DraftContentCount;
        }

        public string GetDelayContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_delay_content_count");

            dbdr.dr.Read();

            string DelayContentCount = dbdr.dr["delay_content_count"].ToString();

            db.Close();

            return DelayContentCount;
        }

        public string GetAdminNoteContentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_admin_note_content_count");

            dbdr.dr.Read();

            string AdminNoteContentCount = dbdr.dr["admin_note_content_count"].ToString();

            db.Close();

            return AdminNoteContentCount;
        }

        public int GetUserContentCount(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_content_count", "@user_id", UserId);

            dbdr.dr.Read();

            string UserContentCount = dbdr.dr["user_content_count"].ToString();

            db.Close();

            return int.Parse(UserContentCount);
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