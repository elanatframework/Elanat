<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.AdminAbout" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.AboutLanguage%></title>
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
        <%=model.AboutLanguage%>
    </div>
    <div class="el_part_row">
        <div id="div_AboutElanatTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
            <%=model.AboutElanatLanguage%>
            <div class="el_dash"></div>
        </div>
        <div class="el_column_left">
            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.VersionLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <div class="el_label">
                            <%=model.VersionValue%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.LicenceLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.LicenceValue%>
                    </div>
                </div>
            </div>
            <div class="el_item">
                <div class="el_extra_label">
                    <div class="el_extra_title">
                        <%=model.ElanatSiteLanguage%>
                    </div>
                    <div class="el_extra_value">
                        <%=model.ElanatSiteValue%>
                    </div>
                </div>
            </div>
            <div class="el_item">
                <p>
                    <%=model.AboutElanatLanguageValue%>
                </p>
            </div>
        </div>

        <div class="el_column_right">
            <%=model.ElanatNewsValue%>
        </div>

    </div>

    <form id="frm_AdminAbout" method="post" action="<%=elanat.AspxHtmlValue.AdminPath()%>/about/Default.aspx">

        <div class="el_part_row">
            <div id="div_CheckNewUpdateTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.CheckNewUpdateLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <input id="btn_CheckNewUpdate" name="btn_CheckNewUpdate" type="submit" class="el_button_input" value="<%=model.CheckNewUpdateLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_AdminAbout')" />
            </div>
            <div class="el_item">
                <div id="div_Update"></div>
            </div>
        </div>

    </form>
</body>
</html>