<%@ Page Controller="Elanat.ExtraHelperSitemapOptionController" Model="Elanat.ExtraHelperSitemapOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.SitemapOptionLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.SitemapOptionLanguage%>
    </div>

    <form id="frm_ExtraHelperSitemapOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/sitemap_option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveLanguage" name="cbx_ActiveLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveLanguageValue)%> /><label for="cbx_ActiveLanguage"><%=model.ActiveLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveSite" name="cbx_ActiveSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveSiteValue)%> /><label for="cbx_ActiveSite"><%=model.ActiveSiteLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActivePage" name="cbx_ActivePage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActivePageValue)%> /><label for="cbx_ActivePage"><%=model.ActivePageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContentType" name="cbx_ActiveContentType" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContentTypeValue)%> /><label for="cbx_ActiveContentType"><%=model.ActiveContentTypeLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveCategory" name="cbx_ActiveCategory" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCategoryValue)%> /><label for="cbx_ActiveCategory"><%=model.ActiveCategoryLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveLink" name="cbx_ActiveLink" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveLinkValue)%> /><label for="cbx_ActiveLink"><%=model.ActiveLinkLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveSitemapOption" name="btn_SaveSitemapOption" type="submit" class="el_button_input" value="<%=model.SaveSitemapOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ExtraHelperSitemapOption')" />
            </div>
        </div>

    </form>
</body>
</html>