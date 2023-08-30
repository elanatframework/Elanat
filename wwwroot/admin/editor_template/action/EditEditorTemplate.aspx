<%@ Page Controller="Elanat.ActionEditEditorTemplateController" Model="Elanat.ActionEditEditorTemplateModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditEditorTemplateLanguage%></title>
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
    <form id="frm_ActionEditEditorTemplate" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/editor_template/action/EditEditorTemplate.aspx">

        <div class="el_part_row">
            <div id="div_EditEditorTemplateTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditEditorTemplateLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.EditorTemplateCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_EditorTemplateCategory" name="txt_EditorTemplateCategory" type="text" value="<%=model.EditorTemplateCategoryValue%>" class="el_text_input<%=model.EditorTemplateCategoryCssClass%>" <%=model.EditorTemplateCategoryAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateActive" name="cbx_EditorTemplateActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateActiveValue)%> /><label for="cbx_EditorTemplateActive"><%=model.EditorTemplateActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUseLanguage" name="cbx_EditorTemplateUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseLanguageValue)%> /><label for="cbx_EditorTemplateUseLanguage"><%=model.EditorTemplateUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUseModule" name="cbx_EditorTemplateUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseModuleValue)%> /><label for="cbx_EditorTemplateUseModule"><%=model.EditorTemplateUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUsePlugin" name="cbx_EditorTemplateUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUsePluginValue)%> /><label for="cbx_EditorTemplateUsePlugin"><%=model.EditorTemplateUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUseReplacePart" name="cbx_EditorTemplateUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseReplacePartValue)%> /><label for="cbx_EditorTemplateUseReplacePart"><%=model.EditorTemplateUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUseFetch" name="cbx_EditorTemplateUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseFetchValue)%> /><label for="cbx_EditorTemplateUseFetch"><%=model.EditorTemplateUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUseItem" name="cbx_EditorTemplateUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseItemValue)%> /><label for="cbx_EditorTemplateUseItem"><%=model.EditorTemplateUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplateUseElanat" name="cbx_EditorTemplateUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseElanatValue)%> /><label for="cbx_EditorTemplateUseElanat"><%=model.EditorTemplateUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.EditorTemplateCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_EditorTemplateCacheDuration" name="txt_EditorTemplateCacheDuration" type="number" value="<%=model.EditorTemplateCacheDurationValue%>" class="el_text_input<%=model.EditorTemplateCacheDurationCssClass%>" <%=model.EditorTemplateCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EditorTemplateCacheParametersLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_EditorTemplateCacheParameters" name="txt_EditorTemplateCacheParameters" type="text" value="<%=model.EditorTemplateCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.EditorTemplateCacheParametersCssClass%>" <%=model.EditorTemplateCacheParametersAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EditorTemplateSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_EditorTemplateSortIndex" name="txt_EditorTemplateSortIndex" type="number" value="<%=model.EditorTemplateSortIndexValue%>" class="el_text_input<%=model.EditorTemplateSortIndexCssClass%>" <%=model.EditorTemplateSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.EditorTemplateAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_EditorTemplatePublicAccessShow" name="cbx_EditorTemplatePublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplatePublicAccessShowValue)%> /><label for="cbx_EditorTemplatePublicAccessShow"><%=model.EditorTemplatePublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.EditorTemplateAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveEditorTemplate" name="btn_SaveEditorTemplate" type="submit" class="el_button_input" value="<%=model.SaveEditorTemplateLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditEditorTemplate')" />
            </div>
        </div>

        <input id="hdn_EditorTemplateId" name="hdn_EditorTemplateId" type="hidden" value="<%=model.EditorTemplateIdValue%>" />

    </form>
</body>
</html>