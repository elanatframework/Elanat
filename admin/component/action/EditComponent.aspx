<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditComponent.aspx.cs" Inherits="elanat.ActionEditComponent" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditComponentLanguage%></title>
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
    <form id="frm_ActionEditComponent" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/component/action/EditComponent.aspx">

        <div class="el_part_row">
            <div id="div_EditComponentTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditComponentLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ComponentCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ComponentCategory" name="txt_ComponentCategory" type="text" value="<%=model.ComponentCategoryValue%>" class="el_text_input<%=model.ComponentCategoryCssClass%>" <%=model.ComponentCategoryAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ComponentLoadTypeLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ComponentLoadType" name="ddlst_ComponentLoadType" class="el_alone_select_input<%=model.ComponentLoadTypeCssClass%>" <%=model.ComponentLoadTypeAttribute%>><%=model.ComponentLoadTypeOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentActive" name="cbx_ComponentActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentActiveValue)%> /><label for="cbx_ComponentActive"><%=model.ComponentActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseLanguage" name="cbx_ComponentUseLanguage" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseLanguageValue)%> /><label for="cbx_ComponentUseLanguage"><%=model.ComponentUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseModule" name="cbx_ComponentUseModule" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseModuleValue)%> /><label for="cbx_ComponentUseModule"><%=model.ComponentUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUsePlugin" name="cbx_ComponentUsePlugin" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUsePluginValue)%> /><label for="cbx_ComponentUsePlugin"><%=model.ComponentUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseReplacePart" name="cbx_ComponentUseReplacePart" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseReplacePartValue)%> /><label for="cbx_ComponentUseReplacePart"><%=model.ComponentUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseFetch" name="cbx_ComponentUseFetch" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseFetchValue)%> /><label for="cbx_ComponentUseFetch"><%=model.ComponentUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseItem" name="cbx_ComponentUseItem" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseItemValue)%> /><label for="cbx_ComponentUseItem"><%=model.ComponentUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseElanat" name="cbx_ComponentUseElanat" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseElanatValue)%> /><label for="cbx_ComponentUseElanat"><%=model.ComponentUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ComponentCacheDuration" name="txt_ComponentCacheDuration" type="number" value="<%=model.ComponentCacheDurationValue%>" class="el_text_input<%=model.ComponentCacheDurationCssClass%>" <%=model.ComponentCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ComponentCacheParametersLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ComponentCacheParameters" name="txt_ComponentCacheParameters" type="text" value="<%=model.ComponentCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.ComponentCacheParametersCssClass%>" <%=model.ComponentCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ComponentSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ComponentSortIndex" name="txt_ComponentSortIndex" type="number" value="<%=model.ComponentSortIndexValue%>" class="el_text_input<%=model.ComponentSortIndexCssClass%>" <%=model.ComponentSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ComponentAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessShow" name="cbx_ComponentPublicAccessShow" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessShowValue)%> /><label for="cbx_ComponentPublicAccessShow"><%=model.ComponentPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessAddLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessAdd" name="cbx_ComponentPublicAccessAdd" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessAddValue)%> /><label for="cbx_ComponentPublicAccessAdd"><%=model.ComponentPublicAccessAddLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessAddTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessEditOwn" name="cbx_ComponentPublicAccessEditOwn" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessEditOwnValue)%> /><label for="cbx_ComponentPublicAccessEditOwn"><%=model.ComponentPublicAccessEditOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessDeleteOwn" name="cbx_ComponentPublicAccessDeleteOwn" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessDeleteOwnValue)%> /><label for="cbx_ComponentPublicAccessDeleteOwn"><%=model.ComponentPublicAccessDeleteOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessEditAll" name="cbx_ComponentPublicAccessEditAll" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessEditAllValue)%> /><label for="cbx_ComponentPublicAccessEditAll"><%=model.ComponentPublicAccessEditAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditAllTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessDeleteAll" name="cbx_ComponentPublicAccessDeleteAll" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessDeleteAllValue)%> /><label for="cbx_ComponentPublicAccessDeleteAll"><%=model.ComponentPublicAccessDeleteAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteAllTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveComponent" name="btn_SaveComponent" type="submit" class="el_button_input" value="<%=model.SaveComponentLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ActionEditComponent')" />
            </div>
        </div>

        <input id="hdn_ComponentId" name="hdn_ComponentId" type="hidden" value="<%=model.ComponentIdValue%>" />

    </form>

</body>
</html>