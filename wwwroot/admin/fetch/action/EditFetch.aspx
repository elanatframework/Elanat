<%@ Page Controller="Elanat.ActionEditFetchController" Model="Elanat.ActionEditFetchModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditFetchLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/fetch/script/fetch.js"></script>
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
<body onload="el_PartPageLoad();">
    <form id="frm_ActionEditFetch" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/fetch/action/EditFetch.aspx">

        <div class="el_part_row">
            <div id="div_EditFetchTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditFetchLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.FetchNameLanguage%>
            </div>
            <div class="el_item">
                <%=model.FetchNameValue%>
            </div>
            <div class="el_item">
                <%=model.FetchCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_FetchCategory" name="txt_FetchCategory" type="text" value="<%=model.FetchCategoryValue%>" class="el_text_input<%=model.FetchCategoryCssClass%>" <%=model.FetchCategoryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.FetchSqlQueryLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_FetchSqlQuery" name="txt_FetchSqlQuery" class="el_textarea_input el_left_to_right<%=model.FetchSqlQueryCssClass%>" <%=model.FetchSqlQueryAttribute%>><%=model.FetchSqlQueryValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUseLanguage" name="cbx_SqlQueryUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUseLanguageValue)%> /><label for="cbx_SqlQueryUseLanguage"><%=model.SqlQueryUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUseModule" name="cbx_SqlQueryUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUseModuleValue)%> /><label for="cbx_SqlQueryUseModule"><%=model.SqlQueryUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUsePlugin" name="cbx_SqlQueryUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUsePluginValue)%> /><label for="cbx_SqlQueryUsePlugin"><%=model.SqlQueryUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUseReplacePart" name="cbx_SqlQueryUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUseReplacePartValue)%> /><label for="cbx_SqlQueryUseReplacePart"><%=model.SqlQueryUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUseFetch" name="cbx_SqlQueryUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUseFetchValue)%> /><label for="cbx_SqlQueryUseFetch"><%=model.SqlQueryUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUseItem" name="cbx_SqlQueryUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUseItemValue)%> /><label for="cbx_SqlQueryUseItem"><%=model.SqlQueryUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_SqlQueryUseElanat" name="cbx_SqlQueryUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.SqlQueryUseElanatValue)%> /><label for="cbx_SqlQueryUseElanat"><%=model.SqlQueryUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_GetSqlQueryColumn" name="btn_GetSqlQueryColumn" type="submit" class="el_button_input" value="<%=model.GetSqlQueryColumnLanguage%>" onclick="el_CleanSqlQuery();el_AjaxPostBack(this, true, 'frm_ActionEditFetch')" />
            </div>
            <div class="el_item">
                <%=model.SqlQueryColumnLanguage%>
            </div>
            <div class="el_item">
                <div id="div_SqlQueryColumnTemplate">
                    <%=model.SqlQueryColumnTemplateValue%>
                </div>
            </div>
            <div class="el_item">
                <%=model.FetchBoxLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_FetchBox" name="txt_FetchBox" class="el_textarea_input el_left_to_right<%=model.FetchBoxCssClass%>" <%=model.FetchBoxAttribute%>><%=model.FetchBoxValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUseLanguage" name="cbx_BoxUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUseLanguageValue)%> /><label for="cbx_BoxUseLanguage"><%=model.BoxUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUseModule" name="cbx_BoxUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUseModuleValue)%> /><label for="cbx_BoxUseModule"><%=model.BoxUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUsePlugin" name="cbx_BoxUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUsePluginValue)%> /><label for="cbx_BoxUsePlugin"><%=model.BoxUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUseReplacePart" name="cbx_BoxUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUseReplacePartValue)%> /><label for="cbx_BoxUseReplacePart"><%=model.BoxUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUseFetch" name="cbx_BoxUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUseFetchValue)%> /><label for="cbx_BoxUseFetch"><%=model.BoxUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUseItem" name="cbx_BoxUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUseItemValue)%> /><label for="cbx_BoxUseItem"><%=model.BoxUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_BoxUseElanat" name="cbx_BoxUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.BoxUseElanatValue)%> /><label for="cbx_BoxUseElanat"><%=model.BoxUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.FetchListItemLanguage%>
            </div>
            <div class="el_item">
                <div id="div_FetchListItemBox">
                    <textarea id="txt_FetchListItem" name="txt_FetchListItem" class="el_textarea_input el_left_to_right<%=model.FetchListItemCssClass%>" <%=model.FetchListItemAttribute%>><%=model.FetchListItemValue%></textarea>
                </div>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUseLanguage" name="cbx_ListItemUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUseLanguageValue)%> /><label for="cbx_ListItemUseLanguage"><%=model.ListItemUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUseModule" name="cbx_ListItemUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUseModuleValue)%> /><label for="cbx_ListItemUseModule"><%=model.ListItemUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUsePlugin" name="cbx_ListItemUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUsePluginValue)%> /><label for="cbx_ListItemUsePlugin"><%=model.ListItemUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUseReplacePart" name="cbx_ListItemUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUseReplacePartValue)%> /><label for="cbx_ListItemUseReplacePart"><%=model.ListItemUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUseFetch" name="cbx_ListItemUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUseFetchValue)%> /><label for="cbx_ListItemUseFetch"><%=model.ListItemUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUseItem" name="cbx_ListItemUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUseItemValue)%> /><label for="cbx_ListItemUseItem"><%=model.ListItemUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ListItemUseElanat" name="cbx_ListItemUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ListItemUseElanatValue)%> /><label for="cbx_ListItemUseElanat"><%=model.ListItemUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_FetchActive" name="cbx_FetchActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.FetchActiveValue)%> /><label for="cbx_FetchActive"><%=model.FetchActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.FetchCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_FetchCacheDuration" name="txt_FetchCacheDuration" type="number" value="<%=model.FetchCacheDurationValue%>" class="el_text_input<%=model.FetchCacheDurationCssClass%>" <%=model.FetchCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.FetchSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_FetchSortIndex" name="txt_FetchSortIndex" type="number" value="<%=model.FetchSortIndexValue%>" class="el_text_input<%=model.FetchSortIndexCssClass%>" <%=model.FetchSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.FetchMenuLanguage%>
            </div>
            <div class="el_item">
                <%=model.FetchMenuTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.FetchStaticHeadLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_FetchStaticHead" name="txt_FetchStaticHead" class="el_textarea_input el_left_to_right<%=model.FetchStaticHeadCssClass%>" <%=model.FetchStaticHeadAttribute%>><%=model.FetchStaticHeadValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.FetchLoadTagLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_FetchLoadTag" name="txt_FetchLoadTag" class="el_textarea_input el_left_to_right<%=model.FetchLoadTagCssClass%>" <%=model.FetchLoadTagAttribute%>><%=model.FetchLoadTagValue%></textarea>
            </div>
            <div class="el_item">
                <%=model.FetchAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_FetchPublicAccessShow" name="cbx_FetchPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.FetchPublicAccessShowValue)%> /><label for="cbx_FetchPublicAccessShow"><%=model.FetchPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.FetchAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveFetch" name="btn_SaveFetch" type="submit" class="el_button_input" value="<%=model.SaveFetchLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditFetch')" />
            </div>
        </div>

        <input id="hdn_FetchId" name="hdn_FetchId" type="hidden" value="<%=model.FetchIdValue%>" />
        <input id="hdn_FetchName" name="hdn_FetchName" type="hidden" value="<%=model.FetchNameValue%>" />

    </form>
</body>
</html>
