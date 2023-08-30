<%@ Page Controller="Elanat.AdminAdminTemplateController" Model="Elanat.AdminAdminTemplateModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AdminTemplateLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/admin_template/script/admin_template.js"></script>
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
        <%=model.AdminTemplateLanguage%>
    </div>


    <div class="el_button_box">
        <input id="btn_AddItem" type="button" value="<%=model.AddLanguage%>" class="el_add" el_action="add_admin_template" onclick="el_ShowHideSection(this, 'div_AddAdminTemplate'); el_SetIframeAutoHeight(); el_SaveAction(this, event)" />
        <input id="btn_Refresh" type="button" value="<%=model.RefreshLanguage%>" onclick="el_Refresh()" />
    </div>

    <div id="div_AddAdminTemplate" class="el_hidden">

        <form id="frm_AdminAdminTemplate" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/admin_template/Default.aspx" enctype="multipart/form-data">

            <div class="el_part_row">
                <div id="div_AddAdminTemplateTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.AddAdminTemplateLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <%=model.AdminTemplatePathLanguage%>
                </div>
                <div class="el_item">
                    <input id="upd_AdminTemplatePath" name="upd_AdminTemplatePath" type="file" class="el_file_input" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_UseAdminTemplatePath" name="cbx_UseAdminTemplatePath" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseAdminTemplatePathValue)%> /><label for="cbx_UseAdminTemplatePath"><%=model.UseAdminTemplatePathLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="txt_AdminTemplatePath" name="txt_AdminTemplatePath" value="<%=model.AdminTemplatePathTextValue%>" type="text" class="el_long_text_input el_foreign_path" />
                </div>
                <div class="el_item">
                    <span class="el_checkbox_input"><input id="cbx_AdminTemplateActive" name="cbx_AdminTemplateActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.AdminTemplateActiveValue)%> /><label for="cbx_AdminTemplateActive"><%=model.AdminTemplateActiveLanguage%></label></span>
                </div>
                <div class="el_item">
                    <input id="btn_AddAdminTemplate" name="btn_AddAdminTemplate" type="submit" class="el_button_input" value="<%=model.AddAdminTemplateLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminAdminTemplate')" />
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