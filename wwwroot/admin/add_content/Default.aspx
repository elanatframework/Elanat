<%@ Page Controller="Elanat.AdminAddContentController" Model="Elanat.AdminAddContentModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AddContentLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/add_content/script/add_content.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.AdminPath()%>/add_content/style/add_content.css" />
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
<body onload="<%=model.ContentTypeScriptFunctionValue%> el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.AddContentLanguage%>
    </div>

    <form id="frm_AdminAddContent" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/add_content/Default.aspx">

        <div class="el_add_content">
            <div class="el_part_row">
                <div id="div_AddNewContent" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddNewContentLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.ContentTitleLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_ContentTitle" name="txt_ContentTitle" type="text" value="<%=model.ContentTitleValue%>" class="el_long_text_input<%=model.ContentTitleCssClass%>" <%=model.ContentTitleAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.ContentTextLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_ContentText" name="txt_ContentText" class="el_text_input el_load_wysiwyg el_load_content_type_value<%=model.ContentTextCssClass%>" <%=model.ContentTextAttribute%>><%=model.ContentTextValue%></textarea>
                </div>
                <div class="el_item">
                    <input id="btn_AddContent" name="btn_AddContent" type="submit" class="el_button_input<%=model.AddContentCssClass%>" value="<%=model.AddContentLanguage%>" onclick="el_TinyMceIssues(); el_AjaxPostBack(this, true, 'frm_AdminAddContent')" />
                    <input id="btn_SaveContent" name="btn_SaveContent" type="submit" class="el_button_input<%=model.SaveContentCssClass%>" value="<%=model.SaveContentLanguage%>" onclick="el_TinyMceIssues(); el_AjaxPostBack(this, true, 'frm_AdminAddContent')" />
                    <input id="btn_DraftContent" name="btn_DraftContent" type="submit" class="el_button_input<%=model.DraftContentCssClass%>" value="<%=model.DraftContentLanguage%>" onclick="el_TinyMceIssues(); el_AjaxPostBack(this, true, 'frm_AdminAddContent')" />
                    <input id="btn_EditorTemplate" type="button" class="el_button_input" value="<%=model.EditorTemplateLanguage%>" onclick="el_ViewEditorTemplateList()" />
                    <input id="btn_AddReadMore" type="button" class="el_button_input" value="<%=model.AddReadMoreLanguage%>" onclick="el_AddReadMoreToWysiwyg()" />
                </div>
            </div>
        </div>

        <div class="el_content_right_menu">
            <div class="el_part_row">
                <div id="div_StatusTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.StatusLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div id="pnl_Status" class="<%=model.StatusCssClass%>">
                    <div class="el_item">
                        <%=model.ContentStatusLanguage%>
                    </div>
                    <div class="el_item">
                        <select id="ddlst_ContentStatus" name="ddlst_ContentStatus" class="el_alone_select_input<%=model.ContentStatusCssClass%>" <%=model.ContentStatusAttribute%>><%=model.ContentStatusOptionListValue%></select>
                    </div>
                    <div class="el_item">
                        <%=model.ContentTypeLanguage%>
                    </div>
                    <div class="el_item">
                        <select id="ddlst_ContentType" name="ddlst_ContentType" onchange="el_ChangeContentType(this)" class="el_alone_select_input<%=model.ContentTypeCssClass%>" <%=model.ContentTypeAttribute%>><%=model.ContentTypeOptionListValue%></select>
                    </div>
                    <div class="el_item">
                        <span class="el_checkbox_input"><input id="cbx_ContentFreeComments" name="cbx_ContentFreeComments" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ContentFreeCommentsValue)%> /><label for="cbx_ContentFreeComments"><%=model.ContentFreeCommentsLanguage%></label></span>
                    </div>
                    <div class="el_item">
                        <span class="el_checkbox_input"><input id="cbx_ContentAlwaysOnTop" name="cbx_ContentAlwaysOnTop" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ContentAlwaysOnTopValue)%> /><label for="cbx_ContentAlwaysOnTopSearch"><%=model.ContentAlwaysOnTopLanguage%></label></span>
                    </div>
                </div>
            </div>

            <div class="el_part_row">
                <div id="div_CategoryTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.CategoryLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <%=model.CategoryLanguage%>
                </div>
                <div class="el_item el_hide">
                    <select id="ddlst_Category" name="ddlst_Category" class="el_alone_select_input<%=model.CategoryCssClass%>" <%=model.CategoryAttribute%>><%=model.CategoryOptionListValue%></select>
                </div>
            </div>

            <div class="el_part_row">
                <div id="div_MetaTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.MetaLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <%=model.MetaKeywordsLanguage%>
                </div>
                <div class="el_item el_hide">
                    <textarea id="txt_MetaKeywords" name="txt_MetaKeywords" class="el_textarea_input<%=model.MetaKeywordsCssClass%>" <%=model.MetaKeywordsAttribute%>><%=model.MetaKeywordsValue%></textarea>
                </div>
            </div>

            <div class="el_part_row">
                <div id="div_SourceTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.SourceLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <%=model.SourceLanguage%>
                </div>
                <div class="el_item el_hide">
                    <textarea id="txt_ContentSource" name="txt_ContentSource" class="el_textarea_input<%=model.ContentSourceCssClass%>" <%=model.ContentSourceAttribute%>><%=model.ContentSourceValue%></textarea>
                </div>
            </div>

            <div class="el_part_row">
                <div id="div_PasswordTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.PasswordLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <%=model.ContentPasswordLanguage%>
                </div>
                <div class="el_item el_hide">
                    <input id="txt_ContentPassword" name="txt_ContentPassword" type="password" value="" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" class="el_text_input<%=model.ContentPasswordCssClass%>" <%=model.ContentPasswordAttribute%> />
                </div>
            </div>

            <div class="el_part_row">
                <div id="div_DateAndTimeTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.DateAndTimeLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <span class="el_checkbox_input"><input id="cbx_UseDelayPublish" name="cbx_UseDelayPublish" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseDelayPublishValue)%> /><label for="cbx_UseDelayPublish"><%=model.UseDelayPublishLanguage%></label></span>
                </div>
                <div class="el_item el_hide">
                    <%=model.DatePublishLanguage%>
                </div>
                <div class="el_item el_hide">
                    <input id="txt_DatePublish" name="txt_DatePublish" type="text" value="<%=model.DatePublishValue%>" class="el_text_input el_left_to_right<%=model.DatePublishCssClass%>" <%=model.DatePublishAttribute%> />
                </div>
                <div class="el_item el_hide">
                    <%=model.TimePublishLanguage%>
                </div>
                <div class="el_item el_hide">
                    <input id="txt_TimePublish" name="txt_TimePublish" type="text" value="<%=model.TimePublishValue%>" class="el_text_input el_left_to_right<%=model.TimePublishCssClass%>" <%=model.TimePublishAttribute%> />
                </div>
            </div>

            <div class="el_part_row">
                <div id="div_AvatarAndIconTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.AvatarAndIconLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <select id="ddlst_ContentIcon" name="ddlst_ContentIcon" class="el_alone_select_input<%=model.ContentIconCssClass%>" <%=model.ContentIconAttribute%> onchange="el_GetContentIcon()" oncuechange="el_GetContentIcon()"><%=model.ContentIconOptionListValue%></select>
                    <div class="el_content_icon_box">
                        <img id="img_ContentIcon" src="<%=model.ContentIconPath%>" alt="" />
                    </div>
                </div>
                <div class="el_item el_hide">
                    <div id="div_ContentAvatar" style="background-image: url('<%=model.ContentAvatarPath%>');"></div>
                </div>
                <div class="el_item el_hide">
                    <input id="btn_SelectAvatar" type="button" class="el_button_input" value="<%=model.SelectAvatarLanguage%>" onclick="el_ViewContentAvatarList('')" />
                </div>
                <input id="hdn_ContentAvatar" name="hdn_ContentAvatar" type="hidden" value="<%=model.ContentAvatarValue%>" />
            </div>

            <div class="el_part_row">
                <div id="div_AccessTitle" class="el_title" onclick="el_ShowPart(this); el_SetIframeAutoHeight(); el_SaveAction(this, event)">
                    <%=model.AccessLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item el_hide">
                    <%=model.ContentAccessShowLanguage%>
                </div>
                <div class="el_item el_hide">
                    <span class="el_checkbox_input"><input id="cbx_ContentPublicAccessShow" name="cbx_ContentPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ContentPublicAccessShowValue)%> /><label for="cbx_ContentPublicAccessShow"><%=model.ContentPublicAccessShowLanguage%></label></span>
                </div>
                <div class="el_item el_hide">
                    <%=model.ContentAccessShowTemplateValue%>
                </div>
            </div>
        </div>

        <input id="hdn_ContentId" name="hdn_ContentId" type="hidden" value="<%=model.ContentIdValue%>" />

    </form>
</body>
</html>