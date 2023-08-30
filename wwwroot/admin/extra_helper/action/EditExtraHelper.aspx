<%@ Page Controller="Elanat.ActionEditExtraHelperController" Model="Elanat.ActionEditExtraHelperModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditExtraHelperLanguage%></title>
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
    <form id="frm_ActionEditExtraHelper" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/extra_helper/action/EditExtraHelper.aspx">

        <div class="el_part_row">
            <div id="div_EditExtraHelperTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditExtraHelperLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ExtraHelperCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ExtraHelperCategory" name="txt_ExtraHelperCategory" type="text" value="<%=model.ExtraHelperCategoryValue%>" class="el_text_input<%=model.ExtraHelperCategoryCssClass%>" <%=model.ExtraHelperCategoryAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperActive" name="cbx_ExtraHelperActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperActiveValue)%> /><label for="cbx_ExtraHelperActive"><%=model.ExtraHelperActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUseLanguage" name="cbx_ExtraHelperUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseLanguageValue)%> /><label for="cbx_ExtraHelperUseLanguage"><%=model.ExtraHelperUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUseModule" name="cbx_ExtraHelperUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseModuleValue)%> /><label for="cbx_ExtraHelperUseModule"><%=model.ExtraHelperUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUsePlugin" name="cbx_ExtraHelperUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUsePluginValue)%> /><label for="cbx_ExtraHelperUsePlugin"><%=model.ExtraHelperUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUseReplacePart" name="cbx_ExtraHelperUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseReplacePartValue)%> /><label for="cbx_ExtraHelperUseReplacePart"><%=model.ExtraHelperUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUseFetch" name="cbx_ExtraHelperUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseFetchValue)%> /><label for="cbx_ExtraHelperUseFetch"><%=model.ExtraHelperUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUseItem" name="cbx_ExtraHelperUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseItemValue)%> /><label for="cbx_ExtraHelperUseItem"><%=model.ExtraHelperUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperUseElanat" name="cbx_ExtraHelperUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperUseElanatValue)%> /><label for="cbx_ExtraHelperUseElanat"><%=model.ExtraHelperUseElanatLanguage%></label></span>
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
                <span class="el_checkbox_input"><input id="cbx_ExtraHelperPublicAccessShow" name="cbx_ExtraHelperPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ExtraHelperPublicAccessShowValue)%> /><label for="cbx_ExtraHelperPublicAccessShow"><%=model.ExtraHelperPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ExtraHelperAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveExtraHelper" name="btn_SaveExtraHelper" type="submit" class="el_button_input" value="<%=model.SaveExtraHelperLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditExtraHelper')" />
            </div>
        </div>

        <input id="hdn_ExtraHelperId" name="hdn_ExtraHelperId" type="hidden" value="<%=model.ExtraHelperIdValue%>" />

    </form>
</body>
</html>