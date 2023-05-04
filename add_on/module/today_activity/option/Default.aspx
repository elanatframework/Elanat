<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ModuleTodayActivityOption" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.TodayActivityOptionLanguage%></title>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant/"></script>
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.TodayActivityOptionLanguage%>
    </div>

    <form id="frm_ModuleTodayActivityOption" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/module/today_activity/option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveFootPrint" name="cbx_ActiveFootPrint" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveFootPrintValue)%> /><label for="cbx_ActiveFootPrint"><%=model.ActiveFootPrintLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveVisit" name="cbx_ActiveVisit" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveVisitValue)%> /><label for="cbx_ActiveVisit"><%=model.ActiveVisitLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveNewUser" name="cbx_ActiveNewUser" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveNewUserValue)%> /><label for="cbx_ActiveNewUser"><%=model.ActiveNewUserLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContact" name="cbx_ActiveContact" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContactValue)%> /><label for="cbx_ActiveContact"><%=model.ActiveContactLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveComment" name="cbx_ActiveComment" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCommentValue)%> /><label for="cbx_ActiveComment"><%=model.ActiveCommentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContent" name="cbx_ActiveContent" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContentValue)%> /><label for="cbx_ActiveContent"><%=model.ActiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveActiveContent" name="cbx_ActiveActiveContent" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveActiveContentValue)%> /><label for="cbx_ActiveActiveContent"><%=model.ActiveActiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveInactiveContent" name="cbx_ActiveInactiveContent" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveInactiveContentValue)%> /><label for="cbx_ActiveInactiveContent"><%=model.ActiveInactiveContentLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveTodayActivityOption" name="btn_SaveTodayActivityOption" type="submit" class="el_button_input" value="<%=model.SaveTodayActivityOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ModuleTodayActivityOption')" />
            </div>
        </div>

    </form>
</body>
</html>