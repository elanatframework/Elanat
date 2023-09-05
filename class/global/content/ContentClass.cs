using System.Xml;

namespace Elanat
{
    public class ContentClass
    {
        public string CurrentCategoryId { get; private set; }
        public string CurrentContentId { get; private set; }
        public string CurrentContentTitle { get; private set; }
        public string CurrentContentUserId { get; private set; }
        public string CurrentContentUserSiteName { get; private set; }
        public string CurrentContentUserName { get; private set; }
        public string CurrentContentUserRealName { get; private set; }

        public string GetContentKeywords(string ContentId)
        {
            string ContentKeywordsTemplate = Template.GetSiteTemplate("part/content_keywords/box");
            ContentKeywordsTemplate = ContentKeywordsTemplate.Replace("$_lang content_keywords;", Language.GetLanguage("content_keywords", StaticObject.GetCurrentSiteGlobalLanguage()));
            string ContentKeywordsListItemTemplate = Template.GetSiteTemplate("part/content_keywords/list_item");
            string TmpContentKeywordsListItemTemplate = "";
            string SumContentKeywordsListItemTemplate = "";


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_keywords", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                // Set Extra Catgory Url Value
                ExtraValue evc = new ExtraValue();

                evc.SiteGlobalName = ccoc.SiteSiteGlobalName;

                while (dbdr.dr.Read())
                {
                    evc.TagName = dbdr.dr["content_keywords_text"].ToString();

                    TmpContentKeywordsListItemTemplate = ContentKeywordsListItemTemplate;

                    TmpContentKeywordsListItemTemplate = TmpContentKeywordsListItemTemplate.Replace("$_db content_keywords_text;", dbdr.dr["content_keywords_text"].ToString());
                    TmpContentKeywordsListItemTemplate = TmpContentKeywordsListItemTemplate.Replace("$_asp content_keywords_text_with_underline;", dbdr.dr["content_keywords_text"].ToString().Replace(" ", "_"));
                    TmpContentKeywordsListItemTemplate = TmpContentKeywordsListItemTemplate.Replace("$_asp extra_tag_url_value;", evc.GetTagUrlValue());

                    SumContentKeywordsListItemTemplate += TmpContentKeywordsListItemTemplate;

                }

                db.Close();

                return ContentKeywordsTemplate.Replace("$_asp item;", SumContentKeywordsListItemTemplate);
            }

            db.Close();

            return null;
        }

        public string GetAttachment(string ContentId)
        {
            string AttachmentTemplate = Template.GetSiteTemplate("part/attachment/box");
            AttachmentTemplate = AttachmentTemplate.Replace("$_lang attachment;", Language.GetLanguage("attachment", StaticObject.GetCurrentSiteGlobalLanguage()));
            string AttachmentFileTemplate = Template.GetSiteTemplate("part/attachment/list_item");
            string TmpAttachmentFileTemplate = "";
            string SumAttachmentFileTemplate = "";


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_attachment", "@content_id", ContentId);

            bool ExistAttachment = false;
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                while (dbdr.dr.Read())
                {
                    if (!dbdr.dr["attachment_active"].ToString().TrueFalseToBoolean())
                        continue;

                    ExistAttachment = true;

                    TmpAttachmentFileTemplate = AttachmentFileTemplate;

                    // If Attachment Protection By Password
                    if (!string.IsNullOrEmpty(dbdr.dr["attachment_password"].ToString()))
                        TmpAttachmentFileTemplate = Template.GetSiteGlobalTemplate("part/show_protection_attachment_by_password").Replace("$_asp attachment_id;", dbdr.dr["attachment_id"].ToString()).Replace("$_asp captcha;", Security.GetCaptchaImage());
                    else
                    {
                        for (int i = 0; i < dbdr.dr.FieldCount; i++)
                        {
                            string ColumnName = dbdr.dr.GetName(i);
                            TmpAttachmentFileTemplate = TmpAttachmentFileTemplate.Replace("$_db " + ColumnName + ";", dbdr.dr[ColumnName].ToString());
                        }

                        TmpAttachmentFileTemplate = TmpAttachmentFileTemplate.Replace("$_asp attachment_extension_icon;", Path.GetExtension(dbdr.dr["attachment_physical_name"].ToString()).Remove(0, 1));
                        TmpAttachmentFileTemplate = TmpAttachmentFileTemplate.Replace("$_asp attachment_size;", long.Parse(dbdr.dr["attachment_size"].ToString()).ToBitSizeTuning());

                    }

                    SumAttachmentFileTemplate += TmpAttachmentFileTemplate;

                }

                db.Close();

                if (ExistAttachment)
                    return AttachmentTemplate.Replace("$_asp item;", SumAttachmentFileTemplate);
            }

            db.Close();

            return null;
        }

        public string GetContent(string GroupId, string Where = null, int PageNumber = 0)
        {
            string Count = StaticObject.NumberOfContentInMainPage.ToString();
            List<string> ParametersNameList = new List<string>() { "@inner_attach", "@count" };
            List<string> ParametersValueList = new List<string>() { Where, Count };

            string TmpWhere = "";

            if (PageNumber > 0)
            {
                Count = StaticObject.NumberOfContentPerPage.ToString();

                int PostPerPage = StaticObject.NumberOfContentPerPage;
                int FromNumberRow = ((PageNumber - 1) * PostPerPage) + 1;
                int UntilNumberRow = (FromNumberRow + PostPerPage) - 1;

                ParametersNameList.Add("@from_number_row");
                ParametersNameList.Add("@until_number_row");
                ParametersValueList.Add(FromNumberRow.ToString());
                ParametersValueList.Add(UntilNumberRow.ToString());
            }

            TmpWhere += "order by tmp.content_always_on_top desc, tmp.content_date_create desc, tmp.content_time_create desc";
            ParametersNameList.Add("@outer_attach");
            ParametersValueList.Add(TmpWhere);

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content", ParametersNameList, ParametersValueList);


            string ReadMoreTemplate = Template.GetSiteTemplate("part/read_more");
            string ReadMoreTextTemplate = Template.GetSiteTemplate("part/read_more_text");
            string ReadMoreSaveContentTemplate = Template.GetSiteTemplate("box_load/read_more_save_content");
            string RatingTemplate = Template.GetSiteTemplate("part/rating");
            string ContentAvatarTemplate = Template.GetSiteTemplate("part/content_avatar");
            string ContentIconTemplate = Template.GetSiteTemplate("part/content_icon");

            string Content = "";
            string[] separator = new string[] { "[Read_More]" };
            string ReadMore = "";
            string SumContent = "";

            MenuClass mc = new MenuClass();

            string BeforeContent = mc.GetSiteMenu("before_content", GroupId, StaticObject.GetCurrentSiteGlobalLanguage());
            string AfterContent = mc.GetSiteMenu("after_content", GroupId, StaticObject.GetCurrentSiteGlobalLanguage());

            XmlNode node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/view/main_page");

            bool ShowContentKeywordsInContent = (node["show_content_keywords_in_content"].Attributes["active"].Value == "true");
            bool ShowAttachmentInContent = (node["show_attachment_in_content"].Attributes["active"].Value == "true");
            bool ShowCommentInContent = (node["show_comment_in_content"].Attributes["active"].Value == "true");
            bool ShowAddCommentInContent = (node["show_add_comment_in_content"].Attributes["active"].Value == "true");
            string LoadWith = node["show_add_comment_in_content"].Attributes["load_with"].InnerText;
            bool ShowContentReplyInContent = (node["show_content_reply_in_content"].Attributes["active"].Value == "true");
            bool ShowAuthorNameInContent = (node["show_author_name_in_content"].Attributes["active"].Value == "true");
            bool ShowCategoryNameInContent = (node["show_category_name_in_content"].Attributes["active"].Value == "true");
            bool ShowTitleInContent = (node["show_title_in_content"].Attributes["active"].Value == "true");
            bool ShowDateInContent = (node["show_date_in_content"].Attributes["active"].Value == "true");
            bool ShowTimeInContent = (node["show_time_in_content"].Attributes["active"].Value == "true");
            bool ShowVisitInContent = (node["show_visit_in_content"].Attributes["active"].Value == "true");

            bool UseNameForAuthorName = (node["show_author_name_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForCategoryName = (node["show_category_name_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForDate = (node["show_date_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForTime = (node["show_time_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForVisit = (node["show_visit_in_content"].Attributes["use_name"].Value == "true");
            string AuthorLanguage = (ShowAuthorNameInContent && UseNameForAuthorName) ? Language.GetLanguage("author", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string CategoryLanguage = (ShowCategoryNameInContent && UseNameForCategoryName) ? Language.GetLanguage("category", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string DateLanguage = (ShowDateInContent && UseNameForDate) ? Language.GetLanguage("date", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string TimeLanguage = (ShowTimeInContent && UseNameForTime) ? Language.GetLanguage("time", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string VisitLanguage = (ShowVisitInContent && UseNameForVisit) ? Language.GetLanguage("visit", StaticObject.GetCurrentSiteGlobalLanguage()) : "";


            bool UseReadMore = (ElanatConfig.GetNode("properties/use_read_more").Attributes["active"].Value == "true");
            bool UseAjaxForReadMore = (ElanatConfig.GetNode("properties/use_read_more").Attributes["load_type"].Value == "ajax");
            bool SaveReadMoreToContent = (ElanatConfig.GetNode("properties/use_read_more").Attributes["load_type"].Value == "save");


            DataUse.Content duc = new DataUse.Content();
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                while (dbdr.dr.Read())
                {
                    string AccessNeedContentText = "";

                    // Check Content Access Show
                    if (!dbdr.dr["content_public_access_show"].ToString().TrueFalseToBoolean())
                        if (!duc.GetContentAccessShowCheck(dbdr.dr["content_id"].ToString()))
                            AccessNeedContentText = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_content", StaticObject.GetCurrentSiteGlobalLanguage()));

                    DataUse.Category duc2 = new DataUse.Category();

                    duc2.FillCurrentCategory(dbdr.dr["category_id"].ToString());


                    // Check Category Access Show
                    if (!duc2.GetCategoryAccessShowCheck(dbdr.dr["category_id"].ToString()))
                        AccessNeedContentText = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("you_do_not_access_to_category", StaticObject.GetCurrentSiteGlobalLanguage()));


                    // Set Extra Content Url Value
                    ExtraValue evc = new ExtraValue();

                    evc.SiteGlobalName = dbdr.dr["site_global_name"].ToString();
                    evc.SiteName = dbdr.dr["site_name"].ToString();
                    evc.ContentId = dbdr.dr["content_id"].ToString();
                    evc.ContentTitle = dbdr.dr["content_title"].ToString();
                    evc.CategoryId = dbdr.dr["category_id"].ToString();

                    CategoryClass cc = new CategoryClass();
                    evc.ParrentCategory = cc.GetParentCategory(dbdr.dr["site_global_name"].ToString(), dbdr.dr["category_id"].ToString());
                    evc.CategoryName = cc.CategoryName;


                    // Set Content Type
                    bool UseNameValue = false;
                    string ContentType = dbdr.dr["content_type"].ToString();
                    string ContentTemplate = "";
                    if (Template.GetXmlNodeFromSiteTemplate("content/" + ContentType) == null)
                    {
                        if (Template.GetXmlNodeFromGlobalTemplate("content/" + ContentType) == null)
                        {
                            ContentTemplate = Template.GetSiteTemplate("content/post");

                            if (Template.GetXmlNodeFromSiteTemplate("content/post").Attributes["use_name_value"] != null)
                                if (Template.GetXmlNodeFromSiteTemplate("content/post").Attributes["use_name_value"].Value == "true")
                                    UseNameValue = true;
                        }
                        else
                        {
                            ContentTemplate = Template.GetGlobalTemplate("content/" + ContentType, StaticObject.GetCurrentSiteGlobalLanguage());

                            if (Template.GetXmlNodeFromGlobalTemplate("content/" + ContentType).Attributes["use_name_value"] != null)
                                if (Template.GetXmlNodeFromGlobalTemplate("content/" + ContentType).Attributes["use_name_value"].Value == "true")
                                    UseNameValue = true;
                        }
                    }
                    else
                    {
                        ContentTemplate = Template.GetSiteTemplate("content/" + ContentType);

                        if (Template.GetXmlNodeFromSiteTemplate("content/" + ContentType).Attributes["use_name_value"] != null)
                            if (Template.GetXmlNodeFromSiteTemplate("content/" + ContentType).Attributes["use_name_value"].Value == "true")
                                UseNameValue = true;
                    }


                    Content = ContentTemplate;


                    int ContentId = int.Parse(dbdr.dr["content_id"].ToString());
                    string ContentText = (string.IsNullOrEmpty(AccessNeedContentText)) ? dbdr.dr["content_text"].ToString() : AccessNeedContentText;

                    if (UseReadMore && ContentText.Contains("<hr class=\"el_read_more\">"))
                    {

                        ReadMore = ReadMoreTemplate;
                        ReadMore = ReadMore.Replace("$_db content_id;", ContentId.ToString());
                        ReadMore = ReadMore.Replace("$_db content_title;", dbdr.dr["content_title"].ToString());
                        ReadMore = ReadMore.Replace("$_lang read_more;", Language.GetLanguage("read_more", StaticObject.GetCurrentSiteGlobalLanguage()));
                        ReadMore = ReadMore.Replace("$_asp use_ajax;", (UseAjaxForReadMore) ? "true" : "false");

                        ReadMore = ReadMore.Replace("$_asp extra_content_url_value;", evc.GetContentUrlValue());


                        string UseLink = "true";

                        if (SaveReadMoreToContent)
                        {
                            string ReadMoreSaveContent = ReadMoreSaveContentTemplate;
                            UseLink = "false";

                            if (UseAjaxForReadMore)
                            {
                                ReadMoreSaveContent = ReadMoreSaveContent.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                                ReadMoreSaveContent = ReadMoreSaveContent.Replace("$_db content_title;", dbdr.dr["content_title"].ToString());
                                ReadMoreSaveContent = ReadMoreSaveContent.Replace("$_db content_text;", null);
                            }
                            else
                            {
                                ReadMoreSaveContent = ReadMoreSaveContent.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                                ReadMoreSaveContent = ReadMoreSaveContent.Replace("$_db content_title;", dbdr.dr["content_title"].ToString());
                                ReadMoreSaveContent = ReadMoreSaveContent.Replace("$_db content_text;", ContentText.Replace("<hr class=\"el_read_more\">", null).Replace("&gt;", ">").Replace("&lt;", "<"));
                            }
                            ReadMore += ReadMoreSaveContent;
                        }
                        ContentText = ContentText.Remove(ContentText.LastIndexOf("<hr class=\"el_read_more\">"));
                        ContentText += ReadMoreTextTemplate;
                        ReadMore = ReadMore.Replace("$_asp use_link;", UseLink);
                    }
                    else
                    {
                        ContentText = ContentText.Replace("<hr class=\"el_read_more\">", null);
                        if (StaticObject.ContentTextCharacterLength > 0)
                            ContentText = ContentText.Substring(0, StaticObject.ContentTextCharacterLength);
                    }


                    // If Use Name Value
                    if (UseNameValue)
                    {
                        string[] NameValueList = ContentText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string NameValue in NameValueList)
                        {
                            string Name = NameValue.GetTextBeforeValue("=");
                            string Value = NameValue.GetTextAfterValue("=");
                            Value = Value.Replace("$_asp new_line;", "<br>");

                            Content = Content.Replace("$_nv " + Name + ";", Value);
                        }

                    }


                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    Content = Content.Replace("$_db user_id;", dbdr.dr["user_id"].ToString());

                    string TmpContentIconTemplate = (string.IsNullOrEmpty(dbdr.dr["content_icon_physical_name"].ToString())) ? "" : ContentIconTemplate.Replace("$_db content_icon_physical_name;", dbdr.dr["content_icon_physical_name"].ToString());
                    Content = Content.Replace("$_asp content_icon;", TmpContentIconTemplate);

                    string TmpContentAvatarTemplate = (string.IsNullOrEmpty(dbdr.dr["content_avatar_physical_name"].ToString())) ? "" : ContentAvatarTemplate.Replace("$_db content_avatar_physical_name;", dbdr.dr["content_avatar_physical_name"].ToString());
                    Content = Content.Replace("$_asp content_avatar;", TmpContentAvatarTemplate);

                    Content = (ShowAuthorNameInContent) ? Content.Replace("$_db user_site_name;", dbdr.dr["user_site_name"].ToString()) : Content.Replace("$_db user_site_name;", null);
                    Content = (ShowTimeInContent) ? Content.Replace("$_db content_time_create;", ccoc.GetCurrentClientTime(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString())) : Content.Replace("$_db content_time_create;", null);
                    Content = (ShowDateInContent) ? Content.Replace("$_db content_date_create;", ccoc.GetCurrentClientDate(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString())) : Content.Replace("$_db content_date_create;", null);
                    Content = Content.Replace("$_asp content_date_and_time_create;", ccoc.GetCurrentClientDateAndTime(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString()));
                    Content = Content.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                    Content = (ShowTitleInContent) ? Content.Replace("$_db content_title;", dbdr.dr["content_title"].ToString()) : Content.Replace("$_db content_title;", null);
                    Content = (ShowCategoryNameInContent) ? Content.Replace("$_asp category_local_name;", Language.GetHandheldLanguageWithoutNullLanguageSuffix(dbdr.dr["category_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage())) : Content.Replace("$_db category_name;", null);
                    Content = (ShowCategoryNameInContent) ? Content.Replace("$_db category_name;", dbdr.dr["category_name"].ToString()) : Content.Replace("$_db category_name;", null);

                    Content = Content.Replace("$_asp_lang author;", AuthorLanguage);
                    Content = Content.Replace("$_asp_lang category;", CategoryLanguage);
                    Content = Content.Replace("$_asp_lang date;", DateLanguage);
                    Content = Content.Replace("$_asp_lang time;", TimeLanguage);
                    Content = Content.Replace("$_asp_lang visit;", VisitLanguage);

                    // If Content Protection By Password
                    Content = (string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? Content.Replace("$_db content_text;", ContentText.Replace("&gt;", ">").Replace("&lt;", "<")) : Content.Replace("$_db content_text;", Template.GetSiteTemplate("part/password_protection/protection_content_by_password"));

                    Content = Content.Replace("$_db comment_count;", dbdr.dr["comment_count"].ToString());
                    Content = (ShowVisitInContent) ? Content.Replace("$_db content_visit;", dbdr.dr["content_visit"].ToString()) : Content.Replace("$_db content_visit;", null);

                    // Set Read More
                    Content = Content.Replace("$_asp read_more;", ReadMore);

                    // Set Content Keywords
                    Content = (ShowContentKeywordsInContent && string.IsNullOrEmpty(AccessNeedContentText) && string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? Content.Replace("$_asp content_keywords;", GetContentKeywords(ContentId.ToString())) : Content.Replace("$_asp content_keywords;", null);

                    // Set Attachment
                    Content = (ShowAttachmentInContent && string.IsNullOrEmpty(AccessNeedContentText) && string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? Content.Replace("$_asp attachment;", GetAttachment(ContentId.ToString())) : Content.Replace("$_asp attachment;", null);

                    // Set Comment
                    Content = (ShowCommentInContent && string.IsNullOrEmpty(AccessNeedContentText) && string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? Content.Replace("$_asp comment;", GetContentComment(ContentId.ToString())) : Content.Replace("$_asp comment;", null);

                    // Set Content Reply
                    Content = (ShowContentReplyInContent && string.IsNullOrEmpty(AccessNeedContentText) && string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? Content.Replace("$_asp content_reply;", GetContentReply(ContentId.ToString())) : Content.Replace("$_asp content_reply;", null);


                    Content = Content.Replace("$_asp extra_content_url_value;", evc.GetContentUrlValue());


                    if (!string.IsNullOrEmpty(dbdr.dr["content_rating_rating"].ToString()))
                    {
                        double Rating = int.Parse(dbdr.dr["content_rating_rating"].ToString());
                        double NumberOfVoted = int.Parse(dbdr.dr["content_rating_number_of_voted"].ToString());
                        string RatingAverage = (Math.Round(Rating / NumberOfVoted * 4) * 5).ToString();
                        Content = Content.Replace("$_asp rating;", RatingTemplate.Replace("$_asp content_id;", ContentId.ToString()).Replace("$_asp number_of_voted;", dbdr.dr["content_rating_number_of_voted"].ToString()).Replace("$_asp rating;", dbdr.dr["content_rating_rating"].ToString()).Replace("$_asp rating_average;", RatingAverage));
                    }
                    else
                        Content = Content.Replace("$_asp rating;", null);

                    Content += (ShowAddCommentInContent) ? PageLoader.LoadPage(LoadWith, StaticObject.SitePath + "page/comment/Default.aspx?content_id=" + dbdr.dr["content_id"].ToString(), false) : null;

                    ReadMore = "";
                    SumContent += BeforeContent + Content + AfterContent;

                    // Set Value
                    CurrentCategoryId = dbdr.dr["category_id"].ToString();
                }
            }
            else
                SumContent = Template.GetSiteTemplate("part/role_access/view").Replace("$_asp inaccess_reason;", Language.GetLanguage("there_is_no_content_at_this_time", StaticObject.GetCurrentSiteGlobalLanguage()));

            db.Close();

            return SumContent;
        }

        public string GetContentReply(string ContentId)
        {
            string ContentReplyTemplate = Template.GetSiteTemplate("part/content_reply/box");
            string ContentReplyItemTemplate = Template.GetSiteTemplate("part/content_reply/list_item");
            string TmpContentReplyItemTemplate = "";

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_content_reply", "@content_id", ContentId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                while (dbdr.dr.Read())
                {
                    if (!dbdr.dr["content_reply_active"].ToString().TrueFalseToBoolean())
                        continue;

                    TmpContentReplyItemTemplate += ContentReplyItemTemplate.Replace("$_asp content_reply_text;", dbdr.dr["content_reply_text"].ToString());
                }

                db.Close();

                return ContentReplyTemplate.Replace("$_asp item;", TmpContentReplyItemTemplate);
            }

            db.Close();

            return null;
        }

        public string GetContentComment(string ContentId, string ParentId = "0", int ParentCount = 0)
        {
            string CommentTemplate = Template.GetSiteTemplate("part/comment/box");

            string ReturnValue = GetContentCommentListItem(ContentId, ParentId, ParentCount, StaticObject.NumberOfCommentInContent);

            CommentTemplate = CommentTemplate.Replace("$_asp item;", ReturnValue);

            return CommentTemplate;
        }

        public string GetContentCommentListItem(string ContentId, string ParentId = "0", int ParentCount = 0, int Count = 0)
        {
            string CommentItemTemplate = Template.GetSiteTemplate("part/comment/list_item");
            string TmpCommentItemTemplate = "";
            string SumCommentItemTemplate = "";

            CommentItemTemplate = CommentItemTemplate.Replace("$_asp parent_count;", ParentCount.ToString());

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_comment_by_parent_comment", new List<string>() { "@content_id", "@parent_id", "@count" }, new List<string>() { ContentId, ParentId, Count.ToString()});
            
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                while (dbdr.dr.Read())
                {
                    if (!dbdr.dr["comment_active"].ToString().TrueFalseToBoolean())
                        continue;

                    TmpCommentItemTemplate = CommentItemTemplate;

                    if (dbdr.dr["parent_comment"].ToString() == "0")
                        ParentCount = 0;

                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp content_id;", dbdr.dr["content_id"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp parent_comment;", dbdr.dr["parent_comment"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp comment_id;", dbdr.dr["comment_id"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp user_guest_id;", dbdr.dr["user_guest_id"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp comment_title;", dbdr.dr["comment_title"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp comment_user_guest_name;", dbdr.dr["comment_user_guest_name"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp comment_date_and_time_send;", dbdr.dr["comment_date_and_time_send"].ToString());
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp comment_text;", dbdr.dr["comment_text"].ToString());


                    // Set Recursive
                    TmpCommentItemTemplate = TmpCommentItemTemplate.Replace("$_asp comment_reply;", GetContentCommentListItem(ContentId, dbdr.dr["comment_id"].ToString(), ++ParentCount, StaticObject.NumberOfCommentReplyInContent));


                    SumCommentItemTemplate += TmpCommentItemTemplate;
                }
                db.Close();

                return SumCommentItemTemplate;
            }

            db.Close();

            return null;
        }

        public string GetContentTitle(string ContentId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_content_title", "@content_id", ContentId);
            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                return dbdr.dr["title"].ToString();
            }

            db.Close();

            return null;
        }

        public string GetCurrentContent(string ContentId, string GroupId)
        {
            string Count = StaticObject.NumberOfContentInMainPage.ToString();


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_content", "@content_id", ContentId);

            string RatingTemplate = Template.GetSiteTemplate("part/rating");
            string ContentAvatarTemplate = Template.GetSiteTemplate("part/content_avatar");
            string ContentIconTemplate = Template.GetSiteTemplate("part/content_icon");

            string Content = "";

            MenuClass mc = new MenuClass();

            string BeforeContent = mc.GetSiteMenu("before_content", GroupId, StaticObject.GetCurrentSiteGlobalLanguage());
            string AfterContent = mc.GetSiteMenu("after_content", GroupId, StaticObject.GetCurrentSiteGlobalLanguage());

            XmlNode node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/view/content_page");

            bool ShowContentKeywordsInContent = (node["show_content_keywords_in_content"].Attributes["active"].Value == "true");
		    bool ShowAttachmentInContent = (node["show_attachment_in_content"].Attributes["active"].Value == "true");
            bool ShowCommentInContent = (node["show_comment_in_content"].Attributes["active"].Value == "true");
            bool ShowAddCommentInContent = (node["show_add_comment_in_content"].Attributes["active"].Value == "true");
            string LoadWith = node["show_add_comment_in_content"].Attributes["load_with"].InnerText;
            bool ShowContentReplyInContent = (node["show_content_reply_in_content"].Attributes["active"].Value == "true");
            bool ShowAuthorNameInContent = (node["show_author_name_in_content"].Attributes["active"].Value == "true");
            bool ShowCategoryNameInContent = (node["show_category_name_in_content"].Attributes["active"].Value == "true");
            bool ShowTitleInContent = (node["show_title_in_content"].Attributes["active"].Value == "true");
            bool ShowDateInContent = (node["show_date_in_content"].Attributes["active"].Value == "true");
            bool ShowTimeInContent = (node["show_time_in_content"].Attributes["active"].Value == "true");
            bool ShowVisitInContent = (node["show_visit_in_content"].Attributes["active"].Value == "true");

            bool UseNameForAuthorName = (node["show_author_name_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForCategoryName = (node["show_category_name_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForDate = (node["show_date_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForTime = (node["show_time_in_content"].Attributes["use_name"].Value == "true");
            bool UseNameForVisit = (node["show_visit_in_content"].Attributes["use_name"].Value == "true");
            string AuthorLanguage = (ShowAuthorNameInContent && UseNameForAuthorName) ? Language.GetLanguage("author", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string CategoryLanguage = (ShowCategoryNameInContent && UseNameForCategoryName) ? Language.GetLanguage("category", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string DateLanguage = (ShowDateInContent && UseNameForDate) ? Language.GetLanguage("date", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string TimeLanguage = (ShowTimeInContent && UseNameForTime) ? Language.GetLanguage("time", StaticObject.GetCurrentSiteGlobalLanguage()) : "";
            string VisitLanguage = (ShowVisitInContent && UseNameForVisit) ? Language.GetLanguage("visit", StaticObject.GetCurrentSiteGlobalLanguage()) : "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                // Set Content Type
                bool UseNameValue = false;
                string ContentType = dbdr.dr["content_type"].ToString();
                string ContentTemplate = "";
                if (Template.GetXmlNodeFromSiteTemplate("content/alone_" + ContentType) == null)
                {
                    if (Template.GetXmlNodeFromGlobalTemplate("content/alone_" + ContentType) == null)
                    {
                        ContentTemplate = Template.GetSiteTemplate("content/alone_post");

                        if (Template.GetXmlNodeFromSiteTemplate("content/alone_post").Attributes["use_name_value"] != null)
                            if (Template.GetXmlNodeFromSiteTemplate("content/alone_post").Attributes["use_name_value"].Value == "true")
                                UseNameValue = true;
                    }
                    else
                    {
                        ContentTemplate = Template.GetGlobalTemplate("content/alone_" + ContentType, StaticObject.GetCurrentSiteGlobalLanguage());

                        if (Template.GetXmlNodeFromGlobalTemplate("content/alone_" + ContentType).Attributes["use_name_value"] != null)
                            if (Template.GetXmlNodeFromGlobalTemplate("content/alone_" + ContentType).Attributes["use_name_value"].Value == "true")
                                UseNameValue = true;
                    }
                }
                else
                {
                    ContentTemplate = Template.GetSiteTemplate("content/alone_" + ContentType);

                    if (Template.GetXmlNodeFromSiteTemplate("content/alone_" + ContentType).Attributes["use_name_value"] != null)
                        if (Template.GetXmlNodeFromSiteTemplate("content/alone_" + ContentType).Attributes["use_name_value"].Value == "true")
                            UseNameValue = true;
                }


                Content = ContentTemplate;


                // If Use Name Value
                if (UseNameValue)
                {
                    string[] NameValueList = dbdr.dr["content_text"].ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string NameValue in NameValueList)
                    {
                        string Name = NameValue.GetTextBeforeValue("=");
                        string Value = NameValue.GetTextAfterValue("=");
                        Value = Value.Replace("$_asp new_line;", "<br>");

                        Content = Content.Replace("$_nv " + Name + ";", Value);
                    }

                }


                CurrentClientObjectClass ccoc = new CurrentClientObjectClass();


                Content = Content.Replace("$_asp read_more;",null);

                Content = Content.Replace("$_db user_id;", dbdr.dr["user_id"].ToString());

                ContentIconTemplate = (string.IsNullOrEmpty(dbdr.dr["content_icon_physical_name"].ToString())) ? "" : ContentIconTemplate.Replace("$_db content_icon_physical_name;", dbdr.dr["content_icon_physical_name"].ToString());
                Content = Content.Replace("$_asp content_icon;", ContentIconTemplate);

                ContentAvatarTemplate = (string.IsNullOrEmpty(dbdr.dr["content_avatar_physical_name"].ToString())) ? "" : ContentAvatarTemplate.Replace("$_db content_avatar_physical_name;", dbdr.dr["content_avatar_physical_name"].ToString());
                Content = Content.Replace("$_asp content_avatar;", ContentAvatarTemplate);

                Content = (ShowAuthorNameInContent) ? Content.Replace("$_db user_site_name;", dbdr.dr["user_site_name"].ToString()) : Content.Replace("$_db user_site_name;", null);
                Content = (ShowTimeInContent) ? Content.Replace("$_db content_time_create;", ccoc.GetCurrentClientTime(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString())) : Content.Replace("$_db content_time_create;", null);
                Content = (ShowDateInContent) ? Content.Replace("$_db content_date_create;", ccoc.GetCurrentClientDate(dbdr.dr["content_date_create"].ToString() + " " + dbdr.dr["content_time_create"].ToString())) : Content.Replace("$_db content_date_create;", null);
                Content = Content.Replace("$_db content_id;", dbdr.dr["content_id"].ToString());
                Content = (ShowTitleInContent) ? Content.Replace("$_db content_title;", dbdr.dr["content_title"].ToString()) : Content.Replace("$_db content_title;", null);
                Content = (ShowCategoryNameInContent) ? Content.Replace("$_asp category_local_name;", Language.GetHandheldLanguageWithoutNullLanguageSuffix(dbdr.dr["category_name"].ToString(), StaticObject.GetCurrentSiteGlobalLanguage())) : Content.Replace("$_db category_name;", null);
                Content = (ShowCategoryNameInContent) ? Content.Replace("$_db category_name;", dbdr.dr["category_name"].ToString()) : Content.Replace("$_db category_name;", null);

                Content = Content.Replace("$_asp_lang author;", AuthorLanguage);
                Content = Content.Replace("$_asp_lang category;", CategoryLanguage);
                Content = Content.Replace("$_asp_lang date;", DateLanguage);
                Content = Content.Replace("$_asp_lang time;", TimeLanguage);
                Content = Content.Replace("$_asp_lang visit;", VisitLanguage);

                // If Content Protection By Password
                Content = (string.IsNullOrEmpty(dbdr.dr["content_password"].ToString())) ? Content.Replace("$_db content_text;", dbdr.dr["content_text"].ToString().Replace("<hr class=\"el_read_more\">", null).Replace("&gt;", ">").Replace("&lt;", "<")) : Content.Replace("$_db content_text;", Template.GetSiteGlobalTemplate("part/show_protection_content_by_password").Replace("$_asp content_id;", dbdr.dr["content_id"].ToString()).Replace("$_asp captcha;", Security.GetCaptchaImage()));
                
                Content = Content.Replace("$_db comment_count;", dbdr.dr["comment_count"].ToString());
                Content = (ShowVisitInContent)? Content.Replace("$_db content_visit;", dbdr.dr["content_visit"].ToString()) : Content.Replace("$_db content_visit;", null);

                // Set Content Keywords
                Content = (ShowContentKeywordsInContent)? Content.Replace("$_asp content_keywords;", GetContentKeywords(ContentId.ToString())) : Content.Replace("$_asp content_keywords;", null);

                // Set Attachment
                Content = (ShowAttachmentInContent)? Content.Replace("$_asp attachment;", GetAttachment(ContentId.ToString())) : Content.Replace("$_asp attachment;", null);

                // Set Comment
                Content = (ShowCommentInContent)? Content.Replace("$_asp comment;", GetContentComment(ContentId.ToString())) : Content.Replace("$_asp comment;", null);

                // Set Content Reply
                Content = (ShowContentReplyInContent)? Content.Replace("$_asp content_reply;", GetContentReply(ContentId.ToString())) : Content.Replace("$_asp content_reply;", null);

                // Set Extra Content Url Value
                ExtraValue evc = new ExtraValue();

                evc.SiteGlobalName = dbdr.dr["site_global_name"].ToString();
                evc.SiteName = dbdr.dr["site_name"].ToString();
                evc.ContentId = dbdr.dr["content_id"].ToString();
                evc.ContentTitle = dbdr.dr["content_title"].ToString();
                evc.CategoryId = dbdr.dr["category_id"].ToString();

                CategoryClass cc = new CategoryClass();
                evc.ParrentCategory = cc.GetParentCategory(dbdr.dr["site_global_name"].ToString(), dbdr.dr["category_id"].ToString());
                evc.CategoryName = cc.CategoryName;

                Content = Content.Replace("$_asp extra_content_url_value;", evc.GetContentUrlValue());


                if (!string.IsNullOrEmpty(dbdr.dr["content_rating_rating"].ToString()))
                {
                    double Rating = int.Parse(dbdr.dr["content_rating_rating"].ToString());
                    double NumberOfVoted = int.Parse(dbdr.dr["content_rating_number_of_voted"].ToString());
                    string RatingAverage = (Math.Round(Rating / NumberOfVoted * 4) * 5).ToString();
                    Content = Content.Replace("$_asp rating;", RatingTemplate.Replace("$_asp content_id;", ContentId.ToString()).Replace("$_asp number_of_voted;", dbdr.dr["content_rating_number_of_voted"].ToString()).Replace("$_asp rating;", dbdr.dr["content_rating_rating"].ToString()).Replace("$_asp rating_average;", RatingAverage));
                }
                else
                    Content = Content.Replace("$_asp rating;", null);

                Content += (ShowAddCommentInContent) ? PageLoader.LoadPage(LoadWith,  StaticObject.SitePath + "page/comment/Default.aspx?content_id=" + dbdr.dr["content_id"].ToString(), false) : null;
            
                // Set Value
                CurrentCategoryId = dbdr.dr["category_id"].ToString();
                CurrentContentId = dbdr.dr["content_id"].ToString();
                CurrentContentTitle = dbdr.dr["content_title"].ToString();
                CurrentContentUserId = dbdr.dr["user_id"].ToString();
                CurrentContentUserSiteName = dbdr.dr["user_site_name"].ToString();
                CurrentContentUserName = dbdr.dr["user_name"].ToString();
                CurrentContentUserRealName = dbdr.dr["user_real_name"].ToString();
            }

            db.Close();

            return BeforeContent + Content + AfterContent;
        }

        public string GetProtectionContentText(string ContentId, string ContentPassword)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_protection_content", new List<string>() { "@content_id", "@content_password" }, new List<string>() { ContentId, ContentPassword });

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();
                string StringContentText = dbdr.dr["content_text"].ToString();
                db.Close();

                StringContentText = StringContentText.Replace("<hr class=\"el_read_more\">", "");

                return StringContentText;
            }

            db.Close();

            return null;
        }

        public string GetCurrentProtectionAttachment(string AttachmentId, string AttachmentPassword)
        {
            string AttachmentFileTemplate = Template.GetSiteTemplate("part/attachment/list_item");

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_protection_attachment", new List<string>() { "@attachment_id", "@attachment_password" }, new List<string>() { AttachmentId, AttachmentPassword });

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                for (int i = 0; i < dbdr.dr.FieldCount; i++)
                {
                    string ColumnName = dbdr.dr.GetName(i);
                    AttachmentFileTemplate = AttachmentFileTemplate.Replace("$_db " + ColumnName + ";", dbdr.dr[ColumnName].ToString());
                }


                AttachmentFileTemplate = AttachmentFileTemplate.Replace("$_asp attachment_extension_icon;", Path.GetExtension(dbdr.dr["attachment_physical_name"].ToString()).Remove(0, 1));
                AttachmentFileTemplate = AttachmentFileTemplate.Replace("$_asp attachment_size;", long.Parse(dbdr.dr["attachment_size"].ToString()).ToBitSizeTuning());
                    
                db.Close();
                return AttachmentFileTemplate;
            }

            db.Close();

            return null;
        }
    }
}