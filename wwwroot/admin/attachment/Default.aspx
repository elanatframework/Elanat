<%@ Page Controller="Elanat.AdminAttachmentController" Model="Elanat.AdminAttachmentModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AttachmentLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/attachment/script/attachment.js"></script>
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
        <%=model.AttachmentLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_atachment" onclick="el_ShowHideSection(this, 'div_AddAttachment'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddAttachment" class="el_hidden">

        <form id="frm_AdminAttachment" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/attachment/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AttachmentTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddAttachmentLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.AttachmentPathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_AttachmentPath" name="upd_AttachmentPath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UseAttachmentPath" name="cbx_UseAttachmentPath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAttachmentPathValue)%> /><label for="cbx_UseAttachmentPath"><%=model.UseAttachmentPathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_AttachmentPath" name="txt_AttachmentPath" value="<%=model.AttachmentPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <%=model.AttachmentNameLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_AttachmentName" name="txt_AttachmentName" type="text" value="<%=model.AttachmentNameValue%>" class="el_text_input<%=model.AttachmentNameCssClass%>" <%=model.AttachmentNameAttribute%> />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AttachmentActive" name="cbx_AttachmentActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AttachmentActiveValue)%> /><label for="cbx_AttachmentActive"><%=model.AttachmentActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.AttachmentAboutLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_AttachmentAbout" name="txt_AttachmentAbout" class="el_textarea_input<%=model.AttachmentAboutCssClass%>" <%=model.AttachmentAboutAttribute%>><%=model.AttachmentAboutValue%></textarea>
                </div>
                <div class="el_item">
                    <%=model.AttachmentPasswordLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_AttachmentPassword" name="txt_AttachmentPassword" type="password" autocomplete="off" readonly="true" onfocus="this.removeAttribute('readonly');" class="el_text_input<%=model.AttachmentPasswordCssClass%>" <%=model.AttachmentPasswordAttribute%> />
                </div>
                <div class="el_item">
                    <%=model.AttachmentContentLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_AttachmentContent" name="txt_AttachmentContent" class="el_list_number_input<%=model.AttachmentContentCssClass%>" <%=model.AttachmentContentAttribute%>><%=model.AttachmentContentValue%></textarea>
                </div>
                <div class="el_item">
                    <%=model.AttachmentAccessShowLanguage%>
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AttachmentPublicAccessShow" name="cbx_AttachmentPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AttachmentPublicAccessShowValue)%> /><label for="cbx_AttachmentPublicAccessShow"><%=model.AttachmentPublicAccessShowLanguage%></label></span>
                </div>
                <div class="el_item">
                    <%=model.AttachmentAccessShowTemplateValue%>
                </div>
                <div class="el_item">
                    <input id="btn_AddAttachment" name="btn_AddAttachment" type="submit" class="el_button_input" value="<%=model.AddAttachmentLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminAttachment')" />
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