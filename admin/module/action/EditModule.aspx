<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditModule.aspx.cs" Inherits="elanat.ActionEditModule" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditModuleLanguage%></title>
    <script src="<%=elanat.AspxHtmlValue.AdminPath()%>/module/script/module.js"></script>
    <!-- Start Client Variant -->
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant"></script>
    <!-- End Client Variant -->	
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=elanat.AspxHtmlValue.CurrentBoxTag()%>
</head>
<body onload="el_PartPageLoad();">
    <form id="frm_ActionEditModule" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/module/action/EditModule.aspx">

        <div class="el_part_row">
            <div id="div_EditModuleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditModuleLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ModuleCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ModuleCategory" name="txt_ModuleCategory" type="text" value="<%=model.ModuleCategoryValue%>" class="el_text_input<%=model.ModuleCategoryCssClass%>" <%=model.ModuleCategoryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ModuleLoadTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ModuleLoadType" name="ddlst_ModuleLoadType" class="el_alone_select_input<%=model.ModuleLoadTypeCssClass%>" <%=model.ModuleLoadTypeAttribute%>><%=model.ModuleLoadTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleActive" name="cbx_ModuleActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleActiveValue)%> /><label for="cbx_ModuleActive"><%=model.ModuleActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUseLanguage" name="cbx_ModuleUseLanguage" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseLanguageValue)%> /><label for="cbx_ModuleUseLanguage"><%=model.ModuleUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUseModule" name="cbx_ModuleUseModule" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseModuleValue)%> /><label for="cbx_ModuleUseModule"><%=model.ModuleUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUsePlugin" name="cbx_ModuleUsePlugin" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUsePluginValue)%> /><label for="cbx_ModuleUsePlugin"><%=model.ModuleUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUseReplacePart" name="cbx_ModuleUseReplacePart" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseReplacePartValue)%> /><label for="cbx_ModuleUseReplacePart"><%=model.ModuleUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUseFetch" name="cbx_ModuleUseFetch" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseFetchValue)%> /><label for="cbx_ModuleUseFetch"><%=model.ModuleUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUseItem" name="cbx_ModuleUseItem" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseItemValue)%> /><label for="cbx_ModuleUseItem"><%=model.ModuleUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModuleUseElanat" name="cbx_ModuleUseElanat" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseElanatValue)%> /><label for="cbx_ModuleUseElanat"><%=model.ModuleUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ModuleCacheDuration" name="txt_ModuleCacheDuration" type="number" value="<%=model.ModuleCacheDurationValue%>" class="el_text_input<%=model.ModuleCacheDurationCssClass%>" <%=model.ModuleCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ModuleCacheParametersLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ModuleCacheParameters" name="txt_ModuleCacheParameters" type="text" value="<%=model.ModuleCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.ModuleCacheParametersCssClass%>" <%=model.ModuleCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ModuleMenuLanguage%>
            </div>
            <div class="el_item">
                <%=model.ModuleMenuTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ModuleMenuQueryStringLanguage%>
            </div>
            <div class="el_item">
                <div id="div_ModuleMenuQueryStringValue"><%=model.ModuleMenuQueryStringValue%></div>
            </div>
            <div class="el_item">
                <%=model.ModuleSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ModuleSortIndex" name="txt_ModuleSortIndex" type="number" value="<%=model.ModuleSortIndexValue%>" class="el_text_input<%=model.ModuleSortIndexCssClass%>" <%=model.ModuleSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ModuleAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModulePublicAccessShow" name="cbx_ModulePublicAccessShow" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessShowValue)%> /><label for="cbx_ModulePublicAccessShow"><%=model.ModulePublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessAddLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModulePublicAccessAdd" name="cbx_ModulePublicAccessAdd" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessAddValue)%> /><label for="cbx_ModulePublicAccessAdd"><%=model.ModulePublicAccessAddLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessAddTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessEditOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModulePublicAccessEditOwn" name="cbx_ModulePublicAccessEditOwn" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessEditOwnValue)%> /><label for="cbx_ModulePublicAccessEditOwn"><%=model.ModulePublicAccessEditOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessEditOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessDeleteOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModulePublicAccessDeleteOwn" name="cbx_ModulePublicAccessDeleteOwn" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessDeleteOwnValue)%> /><label for="cbx_ModulePublicAccessDeleteOwn"><%=model.ModulePublicAccessDeleteOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessDeleteOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessEditAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModulePublicAccessEditAll" name="cbx_ModulePublicAccessEditAll" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessEditAllValue)%> /><label for="cbx_ModulePublicAccessEditAll"><%=model.ModulePublicAccessEditAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessEditAllTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessDeleteAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ModulePublicAccessDeleteAll" name="cbx_ModulePublicAccessDeleteAll" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessDeleteAllValue)%> /><label for="cbx_ModulePublicAccessDeleteAll"><%=model.ModulePublicAccessDeleteAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ModuleAccessDeleteAllTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveModule" name="btn_SaveModule" type="submit" class="el_button_input" value="<%=model.SaveModuleLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionEditModule')" />
            </div>
        </div>

        <input id="hdn_ModuleId" name="hdn_ModuleId" type="hidden" value="<%=model.ModuleIdValue%>" />

    </form>

</body>
</html>