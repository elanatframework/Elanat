<%@ Page Controller="Elanat.MemberUserStatisticsController" Model="Elanat.MemberUserStatisticsModel" %>

        <div class="el_head">
            <%=model.UserStatisticsHeadLanguage%>
        </div>
        
        <div class="el_part_row">
            <div id="div_UserStatisticsTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.UserStatisticsTitleLanguage%>
                <div class="el_dash"></div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.NumberOfAttachmentLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.NumberOfAttachmentValue%>
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.PercentOfAttachmentLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.PercentOfAttachmentValue%>%
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.NumberOfContentLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.NumberOfContentValue%>
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.PercentOfContentLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.PercentOfContentValue%>%
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.NumberOfContentReplyLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.NumberOfContentReplyValue%>
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.PercentOfContentReplyLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.PercentOfContentReplyValue%>%
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.NumberOfCommentLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.NumberOfCommentValue%>
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.PercentOfCommentLanguage%>
                    </div>
                    <div class="el_extra_value">
                       <%=model.PercentOfCommentValue%>%
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.NumberOfCommentReplyLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.NumberOfCommentReplyValue%>
                    </div>
                </div>
            </div>

            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.PercentOfCommentReplyLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.PercentOfCommentReplyValue%>%
                    </div>
                </div>
            </div>

        </div>
