using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Attachment : IDisposable
    {
        public string AttachmentId = "";
        public string AttachmentName = "";
        public string UserId = "";
        public string AttachmentDirectoryPath = "";
        public string AttachmentPhysicalName = "";
        public string AttachmentAbout = "";
        public string AttachmentSize = "";
        public string AttachmentPassword = "";
        public string AttachmentNumberOfVisit = "";
        public string AttachmentActive = "";
        public string AttachmentPublicAccessShow = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public bool IsUserAttachment(string UserId, string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("is_user_attachment", new List<string>() { "@user_id", "@attachment_id" }, new List<string>() { UserId, AttachmentId });

            dbdr.dr.Read();

            bool IsUserAttachment = dbdr.dr["is_user_attachment"].ToString().TrueFalseToBoolean();

            db.Close();

            return IsUserAttachment;
        }

        public void Active(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_attachment", "@attachment_id", AttachmentId);
        }

        public void Inactive(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_attachment", "@attachment_id", AttachmentId);
        }

        public void Delete(string AttachmentId)
        {
            DataUse.Attachment dua = new Attachment();
            dua.FillCurrentAttachment(AttachmentId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_attachment", "@attachment_id", AttachmentId);

            db.SetProcedure("delete_attachment_content", "@attachment_id", AttachmentId);

            // Delete Physical File
            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + dua.AttachmentDirectoryPath + "/" + dua.AttachmentPhysicalName));

            // If File Is Image, Delete Thumpbinal Image
            if (ElanatConfig.GetNode("file_and_directory/auto_create_thumbnail_image").Attributes["active"].Value == "true")
            {
                string FileExtension = Path.GetExtension(dua.AttachmentPhysicalName);

                if (FileAndDirectory.IsImageExtension(FileExtension))
                {
                    if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + dua.AttachmentDirectoryPath + "/thumb/" + dua.AttachmentPhysicalName)))
                        File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/attachment/" + dua.AttachmentDirectoryPath + "/thumb/" + dua.AttachmentPhysicalName));
                }
            }            
        }

        public bool GetAttachmentAccessShowCheck(string AttachmentId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("attachment_access_show_check_by_group_id", new List<string>() { "@attachment_id", "@group_id" }, new List<string>() { AttachmentId, ccoc.GroupId });

            dbdr.dr.Read();

            string AttachmentAccessShow = dbdr.dr["attachment_access_show"].ToString();

            db.Close();

            return (AttachmentAccessShow == "1");
        }

        public void DeleteAttachmentAccessShow(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_attachment_access_show", "@attachment_id", AttachmentId);
        }

        public void DeleteAttachmentContent(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_attachment_content", "@attachment_id", AttachmentId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_attachment", new List<string>() { "@attachment_name", "@user_id", "@attachment_directory_path", "@attachment_physical_name", "@attachment_about", "@attachment_size", "@attachment_password", "@attachment_number_of_visit", "@attachment_active", "@attachment_public_access_show" }, new List<string>() { AttachmentName, UserId, AttachmentDirectoryPath, AttachmentPhysicalName, AttachmentAbout, AttachmentSize, AttachmentPassword, AttachmentNumberOfVisit, AttachmentActive, AttachmentPublicAccessShow });

            dbdr.dr.Read();

            AttachmentId = dbdr.dr["attachment_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_attachment", new List<string>() { "@attachment_name", "@user_id", "@attachment_directory_path", "@attachment_physical_name", "@attachment_about", "@attachment_size", "@attachment_password", "@attachment_number_of_visit", "@attachment_active", "@attachment_public_access_show" }, new List<string>() { AttachmentName, UserId, AttachmentDirectoryPath, AttachmentPhysicalName, AttachmentAbout, AttachmentSize, AttachmentPassword, AttachmentNumberOfVisit, AttachmentActive, AttachmentPublicAccessShow });

            ReturnDr.Read();

            AttachmentId = ReturnDr["attachment_id"].ToString();
        }

        public void SetAttachmentAccessShow(string AttachmentId, List<ListItem> AttachmentAccessShowListAttachment)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in AttachmentAccessShowListAttachment)
                if (item.Selected)
                    db.SetProcedure("set_attachment_access_show", new List<string>() { "@role_id", "@attachment_id" }, new List<string>() { item.Value, AttachmentId });
        }

        // Overload
        public void SetAttachmentAccessShow(List<ListItem> AttachmentAccessShowListAttachment)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in AttachmentAccessShowListAttachment)
                if (item.Selected)
                    db.SetProcedure("set_attachment_access_show", new List<string>() { "@role_id", "@attachment_id" }, new List<string>() { item.Value, AttachmentId });
        }

        public void AddAttachmentContent(string AttachmentId, string[] ContentIdList)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (string ContentId in ContentIdList)
                if (!string.IsNullOrEmpty(ContentId))
                    db.SetProcedure("add_attachment_content", new List<string>() { "@attachment_id", "@content_id" }, new List<string>() { AttachmentId, ContentId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_attachment", new List<string>() { "@attachment_id", "@attachment_name", "@attachment_about", "@attachment_password", "@attachment_active", "@attachment_public_access_show" }, new List<string>() { AttachmentId, AttachmentName, AttachmentAbout, AttachmentPassword, AttachmentActive, AttachmentPublicAccessShow });
        }

        public void FillCurrentAttachment(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_attachment", "@attachment_id", AttachmentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.AttachmentId = dbdr.dr["attachment_id"].ToString();
            AttachmentName = dbdr.dr["attachment_name"].ToString();
            UserId = dbdr.dr["user_id"].ToString();
            AttachmentDirectoryPath = dbdr.dr["attachment_directory_path"].ToString();
            AttachmentPhysicalName = dbdr.dr["attachment_physical_name"].ToString();
            AttachmentAbout = dbdr.dr["attachment_about"].ToString();
            AttachmentSize = dbdr.dr["attachment_size"].ToString();
            AttachmentPassword = dbdr.dr["attachment_password"].ToString();
            AttachmentNumberOfVisit = dbdr.dr["attachment_number_of_visit"].ToString();
            AttachmentActive = dbdr.dr["attachment_active"].ToString().TrueFalseToZeroOne();
            AttachmentPublicAccessShow = dbdr.dr["attachment_public_access_show"].ToString().TrueFalseToZeroOne();


            db.Close();
        }

        public void FillCurrentAttachmentWithReturnDr(string AttachmentId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_attachment", "@attachment_id",  AttachmentId);

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
                case "attachment_id": return AttachmentId;
                case "attachment_name": return AttachmentName;
                case "user_id": return UserId;
                case "attachment_directory_path": return AttachmentDirectoryPath;
                case "attachment_physical_name": return AttachmentPhysicalName;
                case "attachment_about": return AttachmentAbout;
                case "attachment_size": return AttachmentSize;
                case "attachment_password": return AttachmentPassword;
                case "attachment_number_of_visit": return AttachmentNumberOfVisit;
                case "attachment_active": return AttachmentActive;
                case "attachment_public_access_show": return AttachmentPublicAccessShow;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            AttachmentId = "";
            AttachmentName = "";
            UserId = "";
            AttachmentDirectoryPath = "";
            AttachmentPhysicalName = "";
            AttachmentAbout = "";
            AttachmentSize = "";
            AttachmentPassword = "";
            AttachmentNumberOfVisit = "";
            AttachmentActive = "";
            AttachmentPublicAccessShow = "";

            ReturnDr.Close();
        }

        public string GetAttachmentCount()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_attachment_count");

            dbdr.dr.Read();

            string AttachmentCount = dbdr.dr["attachment_count"].ToString();

            db.Close();

            return AttachmentCount;
        }

        public string GetAttachmentCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_attachment", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string AttachmentCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return AttachmentCount;
        }

        public void IncreaseVisit(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("increase_attachment_visit", "attachment_id", AttachmentId);
        }

        public string GetAttachmentIdByAttachmentPhysicalPath(string AttachmentDirectoryPath, string AttachmentPhysicalName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_attachment_id_by_attachment_physical_path", new List<string>() { "@attachment_directory_path", "@attachment_physical_name" }, new List<string>() { AttachmentDirectoryPath, AttachmentPhysicalName });

            dbdr.dr.Read();

            string AttachmentId = dbdr.dr["attachment_id"].ToString();

            db.Close();

            return AttachmentId;
        }

        public int GetUserAttachmentCount(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_attachment_count", "@user_id", UserId);

            dbdr.dr.Read();

            string UserAttachmentCount = dbdr.dr["user_attachment_count"].ToString();

            db.Close();

            return int.Parse(UserAttachmentCount);
        }

        public float GetUserAttachmentSize(string UserId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_attachment_size_list", "@user_id", UserId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return 0;
            }

            float UserAttachmentSize = 0;

            while (dbdr.dr.Read())
                UserAttachmentSize += (float.Parse(dbdr.dr["attachment_size"].ToString()) / 1024);

            db.Close();

            return UserAttachmentSize;
        }

        public bool AttachmentIsActive(string AttachmentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("attachment_is_active", "@attachment_id", AttachmentId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return false;
            }

            dbdr.dr.Read();

            bool AttachmentActive = dbdr.dr["attachment_active"].ToString().TrueFalseToBoolean();

            db.Close();

            return AttachmentActive;
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