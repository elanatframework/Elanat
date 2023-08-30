<%@ Page Controller="Elanat.AdminPatchController" Model="Elanat.AdminPatchModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.PatchLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/patch/script/patch.js"></script>
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
        <%=model.PatchLanguage%>
    </div>

    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_patch" onclick="el_ShowHideSection(this, 'div_AddPatch'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddPatch" class="el_hidden">

        <form id="frm_AdminPatch" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/patch/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddPatchTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddPatchLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.PatchPathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_PatchPath" name="upd_PatchPath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_UsePatchPath" name="cbx_UsePatchPath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UsePatchPathValue)%> /><label for="cbx_UsePatchPath"><%=model.UsePatchPathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_PatchPath" name="txt_PatchPath" value="<%=model.PatchPathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input">
                        <input id="cbx_PatchActive" name="cbx_PatchActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.PatchActiveValue)%> /><label for="cbx_PatchActive"><%=model.PatchActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddPatch" name="btn_AddPatch" type="submit" class="el_button_input" value="<%=model.AddPatchLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminPatch')" />
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