<%@ Page Controller="Elanat.ActionEditComponentController" Model="Elanat.ActionEditComponentModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditComponentLanguage%></title>
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
    <form id="frm_ActionEditComponent" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/component/action/EditComponent.aspx">

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
                <span class="el_checkbox_input"><input id="cbx_ComponentActive" name="cbx_ComponentActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentActiveValue)%> /><label for="cbx_ComponentActive"><%=model.ComponentActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseLanguage" name="cbx_ComponentUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseLanguageValue)%> /><label for="cbx_ComponentUseLanguage"><%=model.ComponentUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseModule" name="cbx_ComponentUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseModuleValue)%> /><label for="cbx_ComponentUseModule"><%=model.ComponentUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUsePlugin" name="cbx_ComponentUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUsePluginValue)%> /><label for="cbx_ComponentUsePlugin"><%=model.ComponentUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseReplacePart" name="cbx_ComponentUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseReplacePartValue)%> /><label for="cbx_ComponentUseReplacePart"><%=model.ComponentUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseFetch" name="cbx_ComponentUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseFetchValue)%> /><label for="cbx_ComponentUseFetch"><%=model.ComponentUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseItem" name="cbx_ComponentUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseItemValue)%> /><label for="cbx_ComponentUseItem"><%=model.ComponentUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentUseElanat" name="cbx_ComponentUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentUseElanatValue)%> /><label for="cbx_ComponentUseElanat"><%=model.ComponentUseElanatLanguage%></label></span>
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
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessShow" name="cbx_ComponentPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessShowValue)%> /><label for="cbx_ComponentPublicAccessShow"><%=model.ComponentPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessAddLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessAdd" name="cbx_ComponentPublicAccessAdd" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessAddValue)%> /><label for="cbx_ComponentPublicAccessAdd"><%=model.ComponentPublicAccessAddLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessAddTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessEditOwn" name="cbx_ComponentPublicAccessEditOwn" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessEditOwnValue)%> /><label for="cbx_ComponentPublicAccessEditOwn"><%=model.ComponentPublicAccessEditOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteOwnLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessDeleteOwn" name="cbx_ComponentPublicAccessDeleteOwn" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessDeleteOwnValue)%> /><label for="cbx_ComponentPublicAccessDeleteOwn"><%=model.ComponentPublicAccessDeleteOwnLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteOwnTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessEditAll" name="cbx_ComponentPublicAccessEditAll" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessEditAllValue)%> /><label for="cbx_ComponentPublicAccessEditAll"><%=model.ComponentPublicAccessEditAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessEditAllTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteAllLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ComponentPublicAccessDeleteAll" name="cbx_ComponentPublicAccessDeleteAll" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ComponentPublicAccessDeleteAllValue)%> /><label for="cbx_ComponentPublicAccessDeleteAll"><%=model.ComponentPublicAccessDeleteAllLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ComponentAccessDeleteAllTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveComponent" name="btn_SaveComponent" type="submit" class="el_button_input" value="<%=model.SaveComponentLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditComponent')" />
            </div>
        </div>

        <input id="hdn_ComponentId" name="hdn_ComponentId" type="hidden" value="<%=model.ComponentIdValue%>" />

    </form>

</body>
</html>