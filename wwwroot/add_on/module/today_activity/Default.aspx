<%@ Page Controller="Elanat.ModuleTodayActivityController" Model="Elanat.ModuleTodayActivityModel" %>
        <div class="el_part_row">
            <div id="div_TodayActivityTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.TodayActivityLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">

                <%=model.FootPrintValue%>

                <%=model.VisitValue%>

                <%=model.NewUserValue%>

                <%=model.NewContactValue%>

                <%=model.NewCommentValue%>

                <%=model.NewContentValue%>

                <%=model.NewActiveContentValue%>

                <%=model.NewInactiveContentValue%>

            </div>
        </div>