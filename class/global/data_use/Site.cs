using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Site : IDisposable
    {
        public string SiteId = "";
        public string LanguageId = "";
        public string SiteTitle = "";
        public string SiteName = "";
        public string SiteGlobalName = "";
        public string SiteVisit = "";
        public string PageId = "";
        public string SiteSloganName = "";
        public string SiteDateCreate = "";
        public string SiteTimeCreate = "";
        public string SiteSiteActivities = "";
        public string SiteAddress = "";
        public string SitePhoneNumber = "";
        public string SiteEmail = "";
        public string SiteOtherInfo = "";
        public string AdminStyleId = "";
        public string SiteStyleId = "";
        public string AdminTemplateId = "";
        public string SiteTemplateId = "";
        public string SiteActive = "";
        public string SiteStaticHead = "";
        public string SiteUseDescriptionMeta = "";
        public string SiteUseRevisitAfterMeta = "";
        public string SiteUseRightsMeta = "";
        public string SiteUseClassificationMeta = "";
        public string SiteUseKeywordsMeta = "";
        public string SiteDescriptionMeta = "";
        public string SiteRevisitAfterMeta = "";
        public string SiteRightsMeta = "";
        public string SiteClassificationMeta = "";
        public string SiteKeywordsMeta = "";
        public string SiteShowLinkInSite = "";
        public string SiteCalendar = "";
        public string SiteFirstDayOfWeek = "";
        public string SiteTimeZone = "";
        public string SiteDateFormat = "";
        public string SiteTimeFormat = "";
        public string SitePublicAccessShow = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_site", "@site_id", SiteId);
        }

        public void Inactive(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_site", "@site_id", SiteId);
        }

        public void Delete(string SiteId)
        {
            DataUse.Site dus = new DataUse.Site();
            dus.FillCurrentSite(SiteId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_site", "@site_id", SiteId);

            // Delete Physical File
            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/image/site_logo/" + dus.SiteGlobalName + ".png"));
        }

        public bool GetSiteAccessShowCheck(string SiteId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("site_access_show_check_by_group_id", new List<string>() { "@site_id", "@group_id" }, new List<string>() { SiteId, ccoc.GroupId });

            dbdr.dr.Read();

            string SiteAccessShow = dbdr.dr["site_access_show"].ToString();

            db.Close();

            return (SiteAccessShow == "1");
        }

        public void DeleteSiteAccessShow(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_site_access_show", "@site_id", SiteId);
        }
        
        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_site", new List<string>() { "@language_id", "@site_title", "@site_name", "@site_global_name", "@site_visit", "@page_id", "@site_slogan_name", "@site_date_create", "@site_time_create", "@site_site_activities", "@site_address", "@site_phone_number", "@site_email", "@site_other_info", "@site_style_id", "@site_template_id", "@admin_style_id", "@admin_template_id", "@site_active", "@site_static_head", "@site_use_description_meta", "@site_use_revisit_after_meta", "@site_use_rights_meta", "@site_use_keywords_meta", "@site_use_classification_meta", "@site_description_meta", "@site_revisit_after_meta", "@site_rights_meta", "@site_classification_meta", "@site_keywords_meta", "@site_show_link_in_site", "@site_calendar", "@site_first_day_of_week", "@site_time_zone", "@site_date_format", "@site_time_format", "@site_public_access_show" }, new List<string>() { LanguageId, SiteTitle, SiteName, SiteGlobalName, SiteVisit, PageId, SiteSloganName, SiteDateCreate, SiteTimeCreate, SiteSiteActivities, SiteAddress, SitePhoneNumber, SiteEmail, SiteOtherInfo, SiteStyleId, SiteTemplateId, AdminStyleId, AdminTemplateId, SiteActive, SiteStaticHead, SiteUseDescriptionMeta, SiteUseRevisitAfterMeta, SiteUseRightsMeta, SiteUseKeywordsMeta, SiteUseClassificationMeta, SiteDescriptionMeta, SiteRevisitAfterMeta, SiteRightsMeta, SiteClassificationMeta, SiteKeywordsMeta, SiteShowLinkInSite, SiteCalendar, SiteFirstDayOfWeek, SiteTimeZone, SiteDateFormat, SiteTimeFormat, SitePublicAccessShow });

            dbdr.dr.Read();

            SiteId = dbdr.dr["site_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_site", new List<string>() { "@language_id", "@site_title", "@site_name", "@site_global_name", "@site_visit", "@page_id", "@site_slogan_name", "@site_date_create", "@site_time_create", "@site_site_activities", "@site_address", "@site_phone_number", "@site_email", "@site_other_info", "@site_style_id", "@site_template_id", "@admin_style_id", "@admin_template_id", "@site_active", "@site_static_head", "@site_use_description_meta", "@site_use_revisit_after_meta", "@site_use_rights_meta", "@site_use_keywords_meta", "@site_use_classification_meta", "@site_description_meta", "@site_revisit_after_meta", "@site_rights_meta", "@site_classification_meta", "@site_keywords_meta", "@site_show_link_in_site", "@site_calendar", "@site_first_day_of_week", "@site_time_zone", "@site_date_format", "@site_time_format", "@site_public_access_show" }, new List<string>() { LanguageId, SiteTitle, SiteName, SiteGlobalName, SiteVisit, PageId, SiteSloganName, SiteDateCreate, SiteTimeCreate, SiteSiteActivities, SiteAddress, SitePhoneNumber, SiteEmail, SiteOtherInfo, SiteStyleId, SiteTemplateId, AdminStyleId, AdminTemplateId, SiteActive, SiteStaticHead, SiteUseDescriptionMeta, SiteUseRevisitAfterMeta, SiteUseRightsMeta, SiteUseKeywordsMeta, SiteUseClassificationMeta, SiteDescriptionMeta, SiteRevisitAfterMeta, SiteRightsMeta, SiteClassificationMeta, SiteKeywordsMeta, SiteShowLinkInSite, SiteCalendar, SiteFirstDayOfWeek, SiteTimeZone, SiteDateFormat, SiteTimeFormat, SitePublicAccessShow });

            ReturnDr.Read();

            SiteId = ReturnDr["site_id"].ToString();
        }

        public void SetSiteAccessShow(string SiteId, List<ListItem> SiteAccessShowListSite)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in SiteAccessShowListSite)
                if (item.Selected)
                    db.SetProcedure("set_site_access_show", new List<string>() { "@role_id", "@site_id" }, new List<string>() { item.Value, SiteId });
        }

        // Overload
        public void SetSiteAccessShow(List<ListItem> SiteAccessShowListSite)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in SiteAccessShowListSite)
                if (item.Selected)
                    db.SetProcedure("set_site_access_show", new List<string>() { "@role_id", "@site_id" }, new List<string>() { item.Value, SiteId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_site", new List<string>() { "@site_id", "@language_id", "@site_title", "@site_name", "@site_global_name", "@site_visit", "@page_id", "@site_slogan_name", "@site_date_create", "@site_time_create", "@site_site_activities", "@site_address", "@site_phone_number", "@site_email", "@site_other_info", "@site_style_id", "@site_template_id", "@admin_style_id", "@admin_template_id", "@site_active", "@site_static_head", "@site_use_description_meta", "@site_use_revisit_after_meta", "@site_use_rights_meta", "@site_use_keywords_meta", "@site_use_classification_meta", "@site_description_meta", "@site_revisit_after_meta", "@site_rights_meta", "@site_classification_meta", "@site_keywords_meta", "@site_show_link_in_site", "@site_calendar", "@site_first_day_of_week", "@site_time_zone", "@site_date_format", "@site_time_format", "@site_public_access_show" }, new List<string>() { SiteId , LanguageId, SiteTitle, SiteName, SiteGlobalName, SiteVisit, PageId, SiteSloganName, SiteDateCreate, SiteTimeCreate, SiteSiteActivities, SiteAddress, SitePhoneNumber, SiteEmail, SiteOtherInfo, SiteStyleId, SiteTemplateId, AdminStyleId, AdminTemplateId, SiteActive, SiteStaticHead, SiteUseDescriptionMeta, SiteUseRevisitAfterMeta, SiteUseRightsMeta, SiteUseKeywordsMeta, SiteUseClassificationMeta, SiteDescriptionMeta, SiteRevisitAfterMeta, SiteRightsMeta, SiteClassificationMeta, SiteKeywordsMeta, SiteShowLinkInSite, SiteCalendar, SiteFirstDayOfWeek, SiteTimeZone, SiteDateFormat, SiteTimeFormat, SitePublicAccessShow });
        }
        
        public void FillCurrentSite(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_site", "@site_id", SiteId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.SiteId = dbdr.dr["site_id"].ToString();
            LanguageId = dbdr.dr["language_id"].ToString();
            SiteTitle = dbdr.dr["site_title"].ToString();
            SiteName = dbdr.dr["site_name"].ToString();
            SiteGlobalName = dbdr.dr["site_global_name"].ToString();
            SiteVisit = dbdr.dr["site_visit"].ToString();
            PageId = dbdr.dr["page_id"].ToString();
            SiteSloganName = dbdr.dr["site_slogan_name"].ToString();
            SiteDateCreate = dbdr.dr["site_date_create"].ToString();
            SiteTimeCreate = dbdr.dr["site_time_create"].ToString();
            SiteSiteActivities = dbdr.dr["site_site_activities"].ToString();
            SiteAddress = dbdr.dr["site_address"].ToString();
            SitePhoneNumber = dbdr.dr["site_phone_number"].ToString();
            SiteEmail = dbdr.dr["site_email"].ToString();
            SiteOtherInfo = dbdr.dr["site_other_info"].ToString();
            AdminStyleId = dbdr.dr["admin_style_id"].ToString();
            SiteStyleId = dbdr.dr["site_style_id"].ToString();
            AdminTemplateId = dbdr.dr["admin_template_id"].ToString();
            SiteTemplateId = dbdr.dr["site_template_id"].ToString();
            SiteActive = dbdr.dr["site_active"].ToString().TrueFalseToZeroOne();
            SiteStaticHead = dbdr.dr["site_static_head"].ToString();
            SiteUseDescriptionMeta = dbdr.dr["site_use_description_meta"].ToString().TrueFalseToZeroOne();
            SiteUseRevisitAfterMeta = dbdr.dr["site_use_revisit_after_meta"].ToString().TrueFalseToZeroOne();
            SiteUseRightsMeta = dbdr.dr["site_use_rights_meta"].ToString().TrueFalseToZeroOne();
            SiteUseClassificationMeta = dbdr.dr["site_use_classification_meta"].ToString().TrueFalseToZeroOne();
            SiteUseKeywordsMeta = dbdr.dr["site_use_keywords_meta"].ToString().TrueFalseToZeroOne();
            SiteDescriptionMeta = dbdr.dr["site_description_meta"].ToString();
            SiteRevisitAfterMeta = dbdr.dr["site_revisit_after_meta"].ToString();
            SiteRightsMeta = dbdr.dr["site_rights_meta"].ToString();
            SiteClassificationMeta = dbdr.dr["site_classification_meta"].ToString();
            SiteKeywordsMeta = dbdr.dr["site_keywords_meta"].ToString();
            SiteShowLinkInSite = dbdr.dr["site_show_link_in_site"].ToString().TrueFalseToZeroOne();
            SiteCalendar = dbdr.dr["site_calendar"].ToString();
            SiteFirstDayOfWeek = dbdr.dr["site_first_day_of_week"].ToString();
            SiteTimeZone = dbdr.dr["site_time_zone"].ToString();
            SiteDateFormat = dbdr.dr["site_date_format"].ToString();
            SiteTimeFormat = dbdr.dr["site_time_format"].ToString();
            SitePublicAccessShow = dbdr.dr["site_public_access_show"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentSiteWithReturnDr(string SiteId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_site", "@site_id", SiteId);

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
                case "site_id": return SiteId;
                case "language_id": return LanguageId;
                case "site_title": return SiteTitle;
                case "site_name": return SiteName;
                case "site_global_name": return SiteGlobalName;
                case "site_visit": return SiteVisit;
                case "page_id": return PageId;
                case "site_slogan_name": return SiteSloganName;
                case "site_date_create": return SiteDateCreate;
                case "site_time_create": return SiteTimeCreate;
                case "site_site_activities": return SiteSiteActivities;
                case "site_address": return SiteAddress;
                case "site_phone_number": return SitePhoneNumber;
                case "site_email": return SiteEmail;
                case "site_other_info": return SiteOtherInfo;
                case "admin_style_id": return AdminStyleId;
                case "site_style_id": return SiteStyleId;
                case "admin_template_id": return AdminTemplateId;
                case "site_template_id": return SiteTemplateId;
                case "site_active": return SiteActive;
                case "site_static_head": return SiteStaticHead;
                case "site_use_description_meta": return SiteUseDescriptionMeta;
                case "site_use_revisit_after_meta": return SiteUseRevisitAfterMeta;
                case "site_use_rights_meta": return SiteUseRightsMeta;
                case "site_use_classification_meta": return SiteUseClassificationMeta;
                case "site_use_keywords_meta": return SiteUseKeywordsMeta;
                case "site_description_meta": return SiteDescriptionMeta;
                case "site_revisit_after_meta": return SiteRevisitAfterMeta;
                case "site_rights_meta": return SiteRightsMeta;
                case "site_classification_meta": return SiteClassificationMeta;
                case "site_keywords_meta": return SiteKeywordsMeta;
                case "site_show_link_in_site": return SiteShowLinkInSite;
                case "site_calendar": return SiteCalendar;
                case "site_first_day_of_week": return SiteFirstDayOfWeek;
                case "site_time_zone": return SiteTimeZone;
                case "site_date_format": return SiteDateFormat;
                case "site_time_format": return SiteTimeFormat;
                case "site_public_access_show": return SitePublicAccessShow;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            SiteId = "";
            LanguageId = "";
            SiteTitle = "";
            SiteName = "";
            SiteGlobalName = "";
            SiteVisit = "";
            PageId = "";
            SiteSloganName = "";
            SiteDateCreate = "";
            SiteTimeCreate = "";
            SiteSiteActivities = "";
            SiteAddress = "";
            SitePhoneNumber = "";
            SiteEmail = "";
            SiteOtherInfo = "";
            AdminStyleId = "";
            SiteStyleId = "";
            AdminTemplateId = "";
            SiteTemplateId = "";
            SiteActive = "";
            SiteStaticHead = "";
            SiteUseDescriptionMeta = "";
            SiteUseRevisitAfterMeta = "";
            SiteUseRightsMeta = "";
            SiteUseClassificationMeta = "";
            SiteUseKeywordsMeta = "";
            SiteDescriptionMeta = "";
            SiteRevisitAfterMeta = "";
            SiteRightsMeta = "";
            SiteClassificationMeta = "";
            SiteKeywordsMeta = "";
            SiteShowLinkInSite = "";
            SiteCalendar = "";
            SiteFirstDayOfWeek = "";
            SiteTimeZone = "";
            SiteDateFormat = "";
            SiteTimeFormat = "";
            SitePublicAccessShow = "";

            ReturnDr.Close();
        }

        public string GetSiteIdBySiteGlobalName(string SiteGlobalName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_id_by_site_global_name", "@site_global_name", SiteGlobalName);
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string SiteId = dbdr.dr["site_id"].ToString();

                db.Close();

                return SiteId;
            }

            db.Close();

            return null;
        }

        public string GetSiteNameBySiteId(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_name_by_site_id","@site_id", SiteId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string SiteName = dbdr.dr["site_name"].ToString();

            db.Close();

            return SiteName;
        }

        public string GetSiteDefaultPage(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_default_page", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string PageId = dbdr.dr["page_id"].ToString();

                db.Close();

                return PageId;
            }

            db.Close();

            return null;
        }

        public void IncreaseVisit(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("increase_site_visit", "@site_id", SiteId);
        }

        public void InstallSite()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("set_install_site", new List<string>() { "@site_time_zone", "@site_name", "@language_id", "@site_email", "@site_title", "@site_date_create", "@site_time_create" }, new List<string>() { SiteTimeZone, SiteName, LanguageId, SiteEmail, SiteTitle, SiteDateCreate, SiteTimeCreate });
        }

        public string GetSiteDateCreate(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_date_create", "@site_id", SiteId);

            dbdr.dr.Read();

            string SiteDateCreate = dbdr.dr["site_date_create"].ToString();

            db.Close();

            return SiteDateCreate;
        }

        public string GetSiteCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string SiteCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return SiteCount;
        }

        public string GetLastContentDateTimeCreateFromSiteId(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_last_content_date_time_create_by_site_id", "@site_id", SiteId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string LastContentDateTimeCreate = dbdr.dr["last_content_date_time_create"].ToString();

            db.Close();

            return LastContentDateTimeCreate;
        }

        public string GetSiteName(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_name", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string SiteName = dbdr.dr["site_name"].ToString();

                db.Close();

                return SiteName;
            }

            db.Close();

            return null;
        }

        public string GetSiteGlobalName(string SiteId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_site_global_name", "@site_id", SiteId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string SiteGlobalName = dbdr.dr["site_global_name"].ToString();

                db.Close();

                return SiteGlobalName;
            }

            db.Close();

            return null;
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