<%@ Page Controller="Elanat.ExtraHelperSearchOptionController" Model="Elanat.ExtraHelperSearchOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.SearchOptionLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.SearchOptionLanguage%>
    </div>

    <form id="frm_ExtraHelperSearchOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/search_option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveTitleTextSearch" name="cbx_ActiveTitleTextSearch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveTitleTextSearchValue)%> /><label for="cbx_ActiveTitleTextSearch"><%=model.ActiveTitleTextSearchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveDateSearch" name="cbx_ActiveDateSearch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveDateSearchValue)%> /><label for="cbx_ActiveDateSearch"><%=model.ActiveDateSearchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveCategorySearch" name="cbx_ActiveCategorySearch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCategorySearchValue)%> /><label for="cbx_ActiveCategorySearch"><%=model.ActiveCategorySearchLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.MinimumSearchCharacterLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_MinimumSearchCharacter" name="txt_MinimumSearchCharacter" type="number" value="<%=model.MinimumSearchCharacterValue%>" class="el_text_input<%=model.MinimumSearchCharacterCssClass%>" <%=model.MinimumSearchCharacterAttribute%> />
            </div>
            <div class="el_item">
                <%=model.SearchedPerPageLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_SearchedPerPage" name="txt_SearchedPerPage" type="number" value="<%=model.SearchedPerPageValue%>" class="el_text_input<%=model.SearchedPerPageCssClass%>" <%=model.SearchedPerPageAttribute%> />
            </div>
            <div class="el_item">
                <%=model.NextSearchDelayLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_NextSearchDelay" name="txt_NextSearchDelay" type="number" value="<%=model.NextSearchDelayValue%>" class="el_text_input<%=model.NextSearchDelayhCssClass%>" <%=model.NextSearchDelayAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SaveSearchedTextToFootPrint" name="cbx_SaveSearchedTextToFootPrint" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SaveSearchedTextToFootPrintValue)%> /><label for="cbx_SaveSearchedTextToFootPrint"><%=model.SaveSearchedTextToFootPrintLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveSearchOption" name="btn_SaveSearchOption" type="submit" class="el_button_input" value="<%=model.SaveSearchOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ExtraHelperSearchOption')" />
            </div>
        </div>

    </form>
</body>
</html>