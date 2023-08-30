<%@ Page Controller="Elanat.AdminModuleController" Model="Elanat.AdminModuleModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ModuleLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/module/script/module.js"></script>
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
        <%=model.ModuleLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_module" onclick="el_ShowHideSection(this, 'div_AddModule'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddModule" class="el_hidden">

        <form id="frm_AdminModule" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/module/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddModuleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddModuleLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.ModulePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_ModulePath" name="upd_ModulePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UseModulePath" name="cbx_UseModulePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseModulePathValue)%> /><label for="cbx_UseModulePath"><%=model.UseModulePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_ModulePath" name="txt_ModulePath" value="<%=model.ModulePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_PriorityForModule" name="cbx_PriorityForModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PriorityForModuleValue)%> /><label for="cbx_PriorityForModule"><%=model.PriorityForModuleLanguage%></label></span>
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
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleActive" name="cbx_ModuleActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleActiveValue)%> /><label for="cbx_ModuleActive"><%=model.ModuleActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUseLanguage" name="cbx_ModuleUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseLanguageValue)%> /><label for="cbx_ModuleUseLanguage"><%=model.ModuleUseLanguageLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUseModule" name="cbx_ModuleUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseModuleValue)%> /><label for="cbx_ModuleUseModule"><%=model.ModuleUseModuleLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUsePlugin" name="cbx_ModuleUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUsePluginValue)%> /><label for="cbx_ModuleUsePlugin"><%=model.ModuleUsePluginLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUseReplacePart" name="cbx_ModuleUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseReplacePartValue)%> /><label for="cbx_ModuleUseReplacePart"><%=model.ModuleUseReplacePartLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUseFetch" name="cbx_ModuleUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseFetchValue)%> /><label for="cbx_ModuleUseFetch"><%=model.ModuleUseFetchLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUseItem" name="cbx_ModuleUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseItemValue)%> /><label for="cbx_ModuleUseItem"><%=model.ModuleUseItemLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModuleUseElanat" name="cbx_ModuleUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModuleUseElanatValue)%> /><label for="cbx_ModuleUseElanat"><%=model.ModuleUseElanatLanguage%></label></span>
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
                    <div id="div_ModuleMenuQueryStringValue"></div>
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
                    <span class="el_checkbox_input">
                        <input id="cbx_ModulePublicAccessShow" name="cbx_ModulePublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessShowValue)%> /><label for="cbx_ModulePublicAccessShow"><%=model.ModulePublicAccessShowLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessShowTemplateValue%>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessAddLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModulePublicAccessAdd" name="cbx_ModulePublicAccessAdd" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessAddValue)%> /><label for="cbx_ModulePublicAccessAdd"><%=model.ModulePublicAccessAddLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessAddTemplateValue%>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessEditOwnLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModulePublicAccessEditOwn" name="cbx_ModulePublicAccessEditOwn" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessEditOwnValue)%> /><label for="cbx_ModulePublicAccessEditOwn"><%=model.ModulePublicAccessEditOwnLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessEditOwnTemplateValue%>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessDeleteOwnLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModulePublicAccessDeleteOwn" name="cbx_ModulePublicAccessDeleteOwn" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessDeleteOwnValue)%> /><label for="cbx_ModulePublicAccessDeleteOwn"><%=model.ModulePublicAccessDeleteOwnLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessDeleteOwnTemplateValue%>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessEditAllLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModulePublicAccessEditAll" name="cbx_ModulePublicAccessEditAll" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessEditAllValue)%> /><label for="cbx_ModulePublicAccessEditAll"><%=model.ModulePublicAccessEditAllLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessEditAllTemplateValue%>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessDeleteAllLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ModulePublicAccessDeleteAll" name="cbx_ModulePublicAccessDeleteAll" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ModulePublicAccessDeleteAllValue)%> /><label for="cbx_ModulePublicAccessDeleteAll"><%=model.ModulePublicAccessDeleteAllLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ModuleAccessDeleteAllTemplateValue%>
                </div>
                <div class="el_item">
                    <input id="btn_AddModule" name="btn_AddModule" type="submit" class="el_button_input" value="<%=model.AddModuleLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminModule')" />
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