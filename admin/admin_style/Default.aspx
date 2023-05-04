<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.AdminAdminStyle" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AdminStyleLanguage%></title>
    <script src="<%=elanat.AspxHtmlValue.AdminPath()%>/admin_style/script/admin_style.js"></script>
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
<body onload="el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.AdminStyleLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_admin_style" onclick="el_ShowHideSection(this, 'div_AddAdminStyle'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddAdminStyle" class="el_hidden">

        <form id="frm_AdminAdminStyle" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/admin_style/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddAdminStyleTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddAdminStyleLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.AdminStylePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_AdminStylePath" name="upd_AdminStylePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UseAdminStylePath" name="cbx_UseAdminStylePath" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAdminStylePathValue)%> /><label for="cbx_UseAdminStylePath"><%=model.UseAdminStylePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_AdminStylePath" name="txt_AdminStylePath" value="<%=model.AdminStylePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AdminStyleActive" name="cbx_AdminStyleActive" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AdminStyleActiveValue)%> /><label for="cbx_AdminStyleActive"><%=model.AdminStyleActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddAdminStyle" name="btn_AddAdminStyle" type="submit" class="el_button_input" value="<%=model.AddAdminStyleLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminAdminStyle')" />
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