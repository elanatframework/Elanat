<%@ Page Controller="Elanat.MemberChangeDateAndTimeController" Model="Elanat.MemberChangeDateAndTimeModel" %>
<div id="div_ChangeDateAndTimePostBack">

    <div class="el_head">
        <%=model.MemberLanguage%>
    </div>

    <form id="frm_MemberChangeDateAndTime" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/member/change_options/change_date_and_time/Default.aspx">

        <div class="el_part_row">
            <div id="div_ChangeDateAndTimeTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ChangeDateAndTimeLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.CalendarLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_Calendar" name="ddlst_Calendar" class="el_alone_select_input<%=model.CalendarCssClass%>" <%=model.CalendarAttribute%>>
                    <%=model.CalendarOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.FirstDayOfWeekLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_FirstDayOfWeek" name="ddlst_FirstDayOfWeek" class="el_alone_select_input<%=model.FirstDayOfWeekCssClass%>" <%=model.FirstDayOfWeekAttribute%>>
                    <%=model.FirstDayOfWeekOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <%=model.DateFormatLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_DateFormat" name="txt_DateFormat" type="text" value="<%=model.DateFormatValue%>" class="el_text_input el_left_to_right<%=model.DateFormatCssClass%>" <%=model.DateFormatAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeFormatLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_TimeFormat" name="txt_TimeFormat" type="text" value="<%=model.TimeFormatValue%>" class="el_text_input el_left_to_right<%=model.TimeFormatCssClass%>" <%=model.TimeFormatAttribute%> />
            </div>
            <div class="el_item">
                <%=model.DayDifferenceLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_DayDifference" name="txt_DayDifference" type="number" value="<%=model.DayDifferenceValue%>" class="el_text_input el_number_input<%=model.DayDifferenceCssClass%>" <%=model.DayDifferenceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeHoursDifferenceLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_TimeHoursDifference" name="txt_TimeHoursDifference" type="number" value="<%=model.TimeHoursDifferenceValue%>" class="el_text_input el_number_input<%=model.TimeHoursDifferenceCssClass%>" <%=model.TimeHoursDifferenceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeMinutesDifferenceLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_TimeMinutesDifference" name="txt_TimeMinutesDifference" type="number" value="<%=model.TimeMinutesDifferenceValue%>" class="el_text_input el_number_input<%=model.TimeMinutesDifferenceCssClass%>" <%=model.TimeMinutesDifferenceAttribute%> />
            </div>
            <div class="el_item">
                <%=model.TimeZoneLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_TimeZone" name="ddlst_TimeZone" class="el_alone_select_input<%=model.TimeZoneCssClass%>" <%=model.TimeZoneAttribute%>>
                    <%=model.TimeZoneOptionListValue%>
                </select>
            </div>
            <div class="el_item">
                <input id="btn_ChangeDateAndTime" name="btn_ChangeDateAndTime" type="submit" class="el_button_input" value="<%=model.ChangeDateAndTimeLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_MemberChangeDateAndTime')" />
            </div>
        </div>

    </form>
</div>