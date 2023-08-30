<%@ Page Controller="Elanat.AdminExtraHelperController" Model="Elanat.AdminExtraHelperModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ExtraHelperLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/extra_helper/script/extra_helper.js"></script>
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
        <%=model.ExtraHelperLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_extra_helper" onclick="el_ShowHideSection(this, 'div_AddExtraHelper'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddExtraHelper" class="el_hidden">

        <form id="frm_AdminExtraHelper" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/extra_helper/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddExtraHelperTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddExtraHelperLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperPathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_ExtraHelperPath" name="upd_ExtraHelperPath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UseExtraHelperPath" name="cbx_UseExtraHelperPath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseExtraHelperPathValue)%> /><label for="cbx_UseExtraHelperPath"><%=model.UseExtraHelperPathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_ExtraHelperPath" name="txt_ExtraHelperPath" value="<%=model.ExtraHelperPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_PriorityForExtraHelper" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PriorityForExtraHelperValue)%>="" name="cbx_PriorityForExtraHelper" type="checkbox" /><label for="cbx_PriorityForExtraHelper"><%=model.PriorityForExtraHelperLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperCategoryLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ExtraHelperCategory" name="txt_ExtraHelperCategory" type="text" value="<%=model.ExtraHelperCategoryValue%>" class="el_text_input<%=model.ExtraHelperCategoryCssClass%>" <%=model.ExtraHelperCategoryAttribute%> />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperActive" name="cbx_ExtraHelperActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperActiveValue)%> /><label for="cbx_ExtraHelperActive"><%=model.ExtraHelperActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUseLanguage" name="cbx_ExtraHelperUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseLanguageValue)%> /><label for="cbx_ExtraHelperUseLanguage"><%=model.ExtraHelperUseLanguageLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUseModule" name="cbx_ExtraHelperUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseModuleValue)%> /><label for="cbx_ExtraHelperUseModule"><%=model.ExtraHelperUseModuleLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUsePlugin" name="cbx_ExtraHelperUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUsePluginValue)%> /><label for="cbx_ExtraHelperUsePlugin"><%=model.ExtraHelperUsePluginLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUseReplacePart" name="cbx_ExtraHelperUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseReplacePartValue)%> /><label for="cbx_ExtraHelperUseReplacePart"><%=model.ExtraHelperUseReplacePartLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUseFetch" name="cbx_ExtraHelperUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseFetchValue)%> /><label for="cbx_ExtraHelperUseFetch"><%=model.ExtraHelperUseFetchLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUseItem" name="cbx_ExtraHelperUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseItemValue)%> /><label for="cbx_ExtraHelperUseItem"><%=model.ExtraHelperUseItemLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperUseElanat" name="cbx_ExtraHelperUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseElanatValue)%> /><label for="cbx_ExtraHelperUseElanat"><%=model.ExtraHelperUseElanatLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperCacheDurationLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ExtraHelperCacheDuration" name="txt_ExtraHelperCacheDuration" type="number" value="<%=model.ExtraHelperCacheDurationValue%>" class="el_text_input<%=model.ExtraHelperCacheDurationCssClass%>" <%=model.ExtraHelperCacheDurationAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperCacheParametersLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ExtraHelperCacheParameters" name="txt_ExtraHelperCacheParameters" type="text" value="<%=model.ExtraHelperCacheParametersValue%>" class="el_long_text_input el_left_to_right<%=model.ExtraHelperCacheParametersCssClass%>" <%=model.ExtraHelperCacheParametersAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperSortIndexLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ExtraHelperSortIndex" name="txt_ExtraHelperSortIndex" type="number" value="<%=model.ExtraHelperSortIndexValue%>" class="el_text_input<%=model.ExtraHelperSortIndexCssClass%>" <%=model.ExtraHelperSortIndexAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperAccessShowLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ExtraHelperPublicAccessShow" name="cbx_ExtraHelperPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperPublicAccessShowValue)%> /><label for="cbx_ExtraHelperPublicAccessShow"><%=model.ExtraHelperPublicAccessShowLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.ExtraHelperAccessShowTemplateValue%>
                </div>
                <div class="el_item">
                    <input id="btn_AddExtraHelper" name="btn_AddExtraHelper" type="submit" class="el_button_input" value="<%=model.AddExtraHelperLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminExtraHelper')" />
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
