using CodeBehind;

namespace Elanat
{
    public partial class MemberUserStatisticsModel : CodeBehindModel
    {
        public string UserStatisticsHeadLanguage  { get; set; }
        public string UserStatisticsTitleLanguage { get; set; }
        public string NumberOfAttachmentLanguage { get; set; }
        public string NumberOfCommentLanguage { get; set; }
        public string NumberOfCommentReplyLanguage { get; set; }
        public string NumberOfContentLanguage { get; set; }
        public string NumberOfContentReplyLanguage { get; set; }
        public string PercentOfAttachmentLanguage { get; set; }
        public string PercentOfContentLanguage { get; set; }
        public string PercentOfContentReplyLanguage { get; set; }
        public string PercentOfCommentLanguage { get; set; }
        public string PercentOfCommentReplyLanguage { get; set; }

        public string NumberOfAttachmentValue { get; set; }
        public string NumberOfCommentValue { get; set; }
        public string NumberOfCommentReplyValue { get; set; }
        public string NumberOfContentValue { get; set; }
        public string NumberOfContentReplyValue { get; set; }
        public string PercentOfAttachmentValue { get; set; }
        public string PercentOfContentValue { get; set; }
        public string PercentOfContentReplyValue { get; set; }
        public string PercentOfCommentValue { get; set; }
        public string PercentOfCommentReplyValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/member/user_statistics/");
            UserStatisticsHeadLanguage = aol.GetAddOnsLanguage("user_statistics");
			UserStatisticsTitleLanguage = aol.GetAddOnsLanguage("user_statistics");
            NumberOfAttachmentLanguage = aol.GetAddOnsLanguage("number_of_attachment");
            NumberOfCommentLanguage = aol.GetAddOnsLanguage("number_of_comment");
            NumberOfCommentReplyLanguage = aol.GetAddOnsLanguage("number_of_comment_reply");
            NumberOfContentLanguage = aol.GetAddOnsLanguage("number_of_content");
            NumberOfContentReplyLanguage = aol.GetAddOnsLanguage("number_of_content_reply");
            PercentOfAttachmentLanguage = aol.GetAddOnsLanguage("percent_of_attachment");
            PercentOfContentLanguage = aol.GetAddOnsLanguage("percent_of_content");
            PercentOfContentReplyLanguage = aol.GetAddOnsLanguage("percent_of_content_reply");
            PercentOfCommentLanguage = aol.GetAddOnsLanguage("percent_of_comment");
            PercentOfCommentReplyLanguage = aol.GetAddOnsLanguage("percent_of_comment_reply");

		
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_user_statistics", "@user_id", ccoc.UserId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            NumberOfAttachmentValue = dbdr.dr["number_of_user_attachment"].ToString();
            NumberOfCommentValue = dbdr.dr["number_of_user_comment"].ToString();
            NumberOfCommentReplyValue = dbdr.dr["number_of_user_comment_reply"].ToString();
            NumberOfContentValue = dbdr.dr["number_of_user_content"].ToString();
            NumberOfContentReplyValue = dbdr.dr["number_of_user_content_reply"].ToString();

            PercentOfAttachmentValue = string.Format("{0:0.##}", float.Parse(dbdr.dr["percent_of_user_attachment"].ToString()));
            PercentOfContentValue = string.Format("{0:0.##}", float.Parse(dbdr.dr["percent_of_user_content"].ToString().ToString()));
            PercentOfContentReplyValue = string.Format("{0:0.##}", float.Parse(dbdr.dr["percent_of_user_content_reply"].ToString()));
            PercentOfCommentValue = string.Format("{0:0.##}", float.Parse(dbdr.dr["percent_of_user_comment"].ToString()));
            PercentOfCommentReplyValue = string.Format("{0:0.##}", float.Parse(dbdr.dr["percent_of_user_comment_reply"].ToString()));

            db.Close();
        }
    }
}