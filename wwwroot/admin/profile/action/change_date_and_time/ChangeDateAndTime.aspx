<%@ Page Controller="Elanat.ActionChangeDateAndTimeController" Model="Elanat.ActionChangeDateAndTimeModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.DateAndTimeLanguage%></title>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.DateAndTimeLanguage%>
    </div>

    <form id="frm_ActionChangeDateAndTime" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/profile/action/change_date_and_time/ChangeDateAndTime.aspx">

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
                <input id="btn_ChangeDateAndTime" name="btn_ChangeDateAndTime" type="submit" class="el_button_input" value="<%=model.ChangeDateAndTimeLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionChangeDateAndTime')" />
            </div>
        </div>

    </form>

</body>
</html>