<%@ Page Controller="Elanat.AdminLanguageController" Model="Elanat.AdminLanguageModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.LanguageLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/script/language.js"></script>
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
<body onload="el_RunAction(); el_PartPageLoad();" onchange="el_RunAction();">

    <div class="el_head">
        <%=model.LanguageLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_language" onclick="el_ShowHideSection(this, 'div_AddLanguage'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_AddHandheldLanguageVariantItem" type="button" value="<%=model.AddHandheldLanguageVariantLanguage%>" class="el_add" onclick="el_AddHandheldLanguageVariant()" />
        <input id="btn_EditHandheldLanguageVariantItem" type="button" value="<%=model.EditHandheldLanguageVariantLanguage%>" class="el_add" onclick="el_EditHandheldLanguageVariant()" />
        <input id="btn_AddLanguageVariantItem" type="button" value="<%=model.AddLanguageVariantLanguage%>" class="el_add" onclick="el_AddLanguageVariant()" />
        <input id="btn_EditLanguageVariantItem" type="button" value="<%=model.EditLanguageVariantLanguage%>" class="el_add" onclick="el_EditLanguageVariant()" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddLanguage" class="el_hidden">

        <form id="frm_AdminLanguage" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddLanguageTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddLanguageLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.LanguagePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_LanguagePath" name="upd_LanguagePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UseLanguagePath" name="cbx_UseLanguagePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseLanguagePathValue)%> /><label for="cbx_UseLanguagePath"><%=model.UseLanguagePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_LanguagePath" name="txt_LanguagePath" value="<%=model.LanguagePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_LanguageActive" name="cbx_LanguageActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.LanguageActiveValue)%> /><label for="cbx_LanguageIsActive"><%=model.LanguageActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_ShowLinkInSite" name="cbx_ShowLinkInSite" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ShowLinkInSiteValue)%> /><label for="cbx_ShowLinkInSite"><%=model.ShowLinkInSiteLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.LanguageDefaultSiteLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_LanguageDefaultSite" name="ddlst_LanguageDefaultSite" class="el_alone_select_input<%=model.LanguageDefaultSiteCssClass%>" <%=model.LanguageDefaultSiteAttribute%>><%=model.LanguageDefaultSiteOptionListValue%></select>
                </div>
                <div class="el_item">
                    <input id="btn_AddLanguage" name="btn_AddLanguage" type="submit" class="el_button_input" value="<%=model.AddLanguageLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminLanguage')" />
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