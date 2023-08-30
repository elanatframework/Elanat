<%@ Page Controller="Elanat.ActionEditPluginController" Model="Elanat.ActionEditPluginModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditPluginLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/plugin/script/plugin.js"></script>
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
    <form id="frm_ActionEditPlugin" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/plugin/action/EditPlugin.aspx">

        <div class="el_part_row">
            <div id="div_EditPluginTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditPluginLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.PluginCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PluginCategory" name="txt_PluginCategory" type="text" value="<%=model.PluginCategoryValue%>" class="el_text_input<%=model.PluginCategoryCssClass%>" <%=model.PluginCategoryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PluginLoadTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_PluginLoadType" name="ddlst_PluginLoadType" class="el_alone_select_input<%=model.PluginLoadTypeCssClass%>" <%=model.PluginLoadTypeAttribute%>><%=model.PluginLoadTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginActive" name="cbx_PluginActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginActiveValue)%> /><label for="cbx_PluginActive"><%=model.PluginActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUseLanguage" name="cbx_PluginUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUseLanguageValue)%> /><label for="cbx_PluginUseLanguage"><%=model.PluginUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUseModule" name="cbx_PluginUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUseModuleValue)%> /><label for="cbx_PluginUseModule"><%=model.PluginUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUsePlugin" name="cbx_PluginUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUsePluginValue)%> /><label for="cbx_PluginUsePlugin"><%=model.PluginUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUseReplacePart" name="cbx_PluginUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUseReplacePartValue)%> /><label for="cbx_PluginUseReplacePart"><%=model.PluginUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUseFetch" name="cbx_PluginUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUseFetchValue)%> /><label for="cbx_PluginUseFetch"><%=model.PluginUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUseItem" name="cbx_PluginUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUseItemValue)%> /><label for="cbx_PluginUseItem"><%=model.PluginUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginUseElanat" name="cbx_PluginUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginUseElanatValue)%> /><label for="cbx_PluginUseElanat"><%=model.PluginUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PluginCacheDuration" name="txt_PluginCacheDuration" type="number" value="<%=model.PluginCacheDurationValue%>" class="el_text_input<%=model.PluginCacheDurationCssClass%>" <%=model.PluginCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PluginCacheParametersLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PluginCacheParameters" name="txt_PluginCacheParameters" type="text" value="<%=model.PluginCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.PluginCacheParametersCssClass%>" <%=model.PluginCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PluginMenuLanguage%>
            </div>
            <div class="el_item">
                <%=model.PluginMenuTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.PluginMenuQueryStringLanguage%>
            </div>
            <div class="el_item">
                <div id="div_PluginMenuQueryStringValue"><%=model.PluginMenuQueryStringValue%></div>
            </div>
            <div class="el_item">
                <%=model.PluginSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_PluginSortIndex" name="txt_PluginSortIndex" type="number" value="<%=model.PluginSortIndexValue%>" class="el_text_input<%=model.PluginSortIndexCssClass%>" <%=model.PluginSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.PluginAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginPublicAccessShow" name="cbx_PluginPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginPublicAccessShowValue)%> /><label for="cbx_PluginPublicAccessShow"><%=model.PluginPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.PluginAccessAddLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginPublicAccessAdd" name="cbx_PluginPublicAccessAdd" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginPublicAccessAddValue)%> /><label for="cbx_PluginPublicAccessAdd"><%=model.PluginPublicAccessAddLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginAccessAddTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.PluginAccessEditOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginPublicAccessEditOwn" name="cbx_PluginPublicAccessEditOwn" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginPublicAccessEditOwnValue)%> /><label for="cbx_PluginPublicAccessEditOwn"><%=model.PluginPublicAccessEditOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginAccessEditOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.PluginAccessDeleteOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginPublicAccessDeleteOwn" name="cbx_PluginPublicAccessDeleteOwn" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginPublicAccessDeleteOwnValue)%> /><label for="cbx_PluginPublicAccessDeleteOwn"><%=model.PluginPublicAccessDeleteOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginAccessDeleteOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.PluginAccessEditAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginPublicAccessEditAll" name="cbx_PluginPublicAccessEditAll" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginPublicAccessEditAllValue)%> /><label for="cbx_PluginPublicAccessEditAll"><%=model.PluginPublicAccessEditAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginAccessEditAllTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.PluginAccessDeleteAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_PluginPublicAccessDeleteAll" name="cbx_PluginPublicAccessDeleteAll" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PluginPublicAccessDeleteAllValue)%> /><label for="cbx_PluginPublicAccessDeleteAll"><%=model.PluginPublicAccessDeleteAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.PluginAccessDeleteAllTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SavePlugin" name="btn_SavePlugin" type="submit" class="el_button_input" value="<%=model.SavePluginLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditPlugin')" />
            </div>
        </div>

        <input id="hdn_PluginId" name="hdn_PluginId" type="hidden" value="<%=model.PluginIdValue%>" />

    </form>

</body>
</html>