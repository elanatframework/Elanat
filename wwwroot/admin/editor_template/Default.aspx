<%@ Page Controller="Elanat.AdminEditorTemplateController" Model="Elanat.AdminEditorTemplateModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditorTemplateLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/editor_template/script/editor_template.js"></script>
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
        <%=model.EditorTemplateLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_editor_template" onclick="el_ShowHideSection(this, 'div_AddEditorTemplate'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddEditorTemplate" class="el_hidden">

        <form id="frm_AdminEditorTemplate" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/editor_template/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddEditorTemplateTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddEditorTemplateLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.EditorTemplatePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_EditorTemplatePath" name="upd_EditorTemplatePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UseEditorTemplatePath" name="cbx_UseEditorTemplatePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseEditorTemplatePathValue)%> /><label for="cbx_UseEditorTemplatePath"><%=model.UseEditorTemplatePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_EditorTemplatePath" name="txt_EditorTemplatePath" value="<%=model.EditorTemplatePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_PriorityForEditorTemplate" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PriorityForEditorTemplateValue)%>="" name="cbx_PriorityForEditorTemplate" type="checkbox" /><label for="cbx_PriorityForEditorTemplate"><%=model.PriorityForEditorTemplateLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.EditorTemplateCategoryLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_EditorTemplateCategory" name="txt_EditorTemplateCategory" type="text" value="<%=model.EditorTemplateCategoryValue%>" class="el_text_input<%=model.EditorTemplateCategoryCssClass%>" <%=model.EditorTemplateCategoryAttribute%> />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateActive" name="cbx_EditorTemplateActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateActiveValue)%> /><label for="cbx_EditorTemplateActive"><%=model.EditorTemplateActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUseLanguage" name="cbx_EditorTemplateUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseLanguageValue)%> /><label for="cbx_EditorTemplateUseLanguage"><%=model.EditorTemplateUseLanguageLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUseModule" name="cbx_EditorTemplateUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseModuleValue)%> /><label for="cbx_EditorTemplateUseModule"><%=model.EditorTemplateUseModuleLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUsePlugin" name="cbx_EditorTemplateUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUsePluginValue)%> /><label for="cbx_EditorTemplateUsePlugin"><%=model.EditorTemplateUsePluginLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUseReplacePart" name="cbx_EditorTemplateUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseReplacePartValue)%> /><label for="cbx_EditorTemplateUseReplacePart"><%=model.EditorTemplateUseReplacePartLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUseFetch" name="cbx_EditorTemplateUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseFetchValue)%> /><label for="cbx_EditorTemplateUseFetch"><%=model.EditorTemplateUseFetchLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUseItem" name="cbx_EditorTemplateUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseItemValue)%> /><label for="cbx_EditorTemplateUseItem"><%=model.EditorTemplateUseItemLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplateUseElanat" name="cbx_EditorTemplateUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplateUseElanatValue)%> /><label for="cbx_EditorTemplateUseElanat"><%=model.EditorTemplateUseElanatLanguage%></label></span>
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
                    <span class="el_checkbox_input">
                        <input id="cbx_EditorTemplatePublicAccessShow" name="cbx_EditorTemplatePublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.EditorTemplatePublicAccessShowValue)%> /><label for="cbx_EditorTemplatePublicAccessShow"><%=model.EditorTemplatePublicAccessShowLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.EditorTemplateAccessShowTemplateValue%>
                </div>
                <div class="el_item">
                    <input id="btn_AddEditorTemplate" name="btn_AddEditorTemplate" type="submit" class="el_button_input" value="<%=model.AddEditorTemplateLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminEditorTemplate')" />
                </div>
            </div>

        </form>

    </div>

    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>

</body>
</html>