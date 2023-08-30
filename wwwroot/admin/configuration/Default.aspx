<%@ Page Controller="Elanat.AdminConfigurationController" Model="Elanat.AdminConfigurationModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.ConfigurationLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/configuration/script/configuration.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.AdminPath()%>/configuration/style/configuration.css" />
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

    <!-- Start Code Highlighter -->	
    <link rel="stylesheet" href="/include/code_highlighter/codemirror-5.4/lib/codemirror.css" />
    <script src="/include/code_highlighter/codemirror-5.4/lib/codemirror.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/javascript/javascript.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/htmlembedded/htmlembedded.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/xml/xml.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/css/css.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/mode/htmlmixed/htmlmixed.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/comment/comment.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/comment/continuecomment.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/mode/multiplex.js"></script>
    <script src="/include/code_highlighter/codemirror-5.4/addon/edit/matchbrackets.js"></script>
    <!-- End Code Highlighter -->
</head>
<body onload="el_SetConfigCodeMirror('<%=model.ShowConfigLanguage%>'); el_RunAction(); el_PartPageLoad();">

    <div class="el_head">
        <%=model.ConfigurationLanguage%>
    </div>

    <form id="frm_AdminConfiguration" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/configuration/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <ul class="el_horizontal_item">
                    <li>
                        <input id="btn_ShowAdminDynamicHead" name="btn_ShowAdminDynamicHead" type="button" class="el_long_button" value="<%=model.ShowAdminDynamicHeadLanguage%>" onclick="el_SetCodeMirror(this, 'admin_dynamic_head', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowAdminGlobalLocation" name="btn_ShowAdminGlobalLocation" type="button" class="el_long_button" value="<%=model.ShowAdminGlobalLocationLanguage%>" onclick="el_SetCodeMirror(this, 'admin_global_location', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowAdminGlobalStyle" name="btn_ShowAdminGlobalStyle" type="button" class="el_long_button" value="<%=model.ShowAdminGlobalStyleLanguage%>" onclick="el_SetCodeMirror(this, 'admin_global_style', 'text/css')" />
                    </li>
                    <li>
                        <input id="btn_ShowAdminGlobalTemplate" name="btn_ShowAdminGlobalTemplate" type="button" class="el_long_button" value="<%=model.ShowAdminGlobalTemplateLanguage%>" onclick="el_SetCodeMirror(this, 'admin_global_template', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowAdminPageLoad" name="btn_ShowAdminPageLoad" type="button" class="el_long_button" value="<%=model.ShowAdminPageLoadLanguage%>" onclick="el_SetCodeMirror(this, 'admin_page_load', 'text/javascript')" />
                    </li>
                    <li>
                        <input id="btn_ShowAdminScript" name="btn_ShowAdminScript" type="button" class="el_long_button" value="<%=model.ShowAdminScriptLanguage%>" onclick="el_SetCodeMirror(this, 'admin_script', 'text/javascript')" />
                    </li>
                    <li>
                        <input id="btn_ShowAdminStaticHead" name="btn_ShowAdminStaticHead" type="button" class="el_long_button" value="<%=model.ShowAdminStaticHeadLanguage%>" onclick="el_SetCodeMirror(this, 'admin_static_head', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowAfterLoadPathReference" name="btn_ShowAfterLoadPathReference" type="button" class="el_long_button" value="<%=model.ShowAfterLoadPathRefrenceLanguage%>" onclick="el_SetCodeMirror(this, 'after_load_path_reference', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowAuthorizedExtension" name="btn_ShowAuthorizedExtension" type="button" class="el_long_button" value="<%=model.ShowAuthorizedExtensionLanguage%>" onclick="el_SetCodeMirror(this, 'authorized_extension', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowBeforeLoadPathReference" name="btn_ShowBeforeLoadPathReference" type="button" class="el_long_button" value="<%=model.ShowBeforeLoadPathRefrenceLanguage%>" onclick="el_SetCodeMirror(this, 'before_load_path_reference', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowBox" name="btn_ShowBox" type="button" class="el_long_button" value="<%=model.ShowBoxLanguage%>" onclick="el_SetCodeMirror(this, 'box', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowCalendar" name="btn_ShowCalendar" type="button" class="el_long_button" value="<%=model.ShowCalendarLanguage%>" onclick="el_SetCodeMirror(this, 'calendar', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowCaptcha" name="btn_ShowCaptcha" type="button" class="el_long_button" value="<%=model.ShowCaptchaLanguage%>" onclick="el_SetCodeMirror(this, 'captcha', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowClientFileExtensions" name="btn_ShowClientFileExtensions" type="button" class="el_long_button" value="<%=model.ShowClientFileExtensionsLanguage%>" onclick="el_SetCodeMirror(this, 'client_file_extensions', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowConfig" name="btn_ShowConfig" type="button" class="el_long_button" value="<%=model.ShowConfigLanguage%>" onclick="el_SetCodeMirror(this, 'config', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowContentIcon" name="btn_ShowContentIcon" type="button" class="el_long_button" value="<%=model.ShowContentIconLanguage%>" onclick="el_SetCodeMirror(this, 'content_icon', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowDefaultPage" name="btn_ShowDefaultPage" type="button" class="el_long_button" value="<%=model.ShowDefaultPageLanguage%>" onclick="el_SetCodeMirror(this, 'default_page', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowDynamicExtension" name="btn_ShowDynamicExtension" type="button" class="el_long_button" value="<%=model.ShowDynamicExtensionLanguage%>" onclick="el_SetCodeMirror(this, 'dynamic_extension', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowEventReference" name="btn_ShowEventReference" type="button" class="el_long_button" value="<%=model.ShowEventReferenceLanguage%>" onclick="el_SetCodeMirror(this, 'event_reference', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowFileExtensions" name="btn_ShowFileExtensions" type="button" class="el_long_button" value="<%=model.ShowFileExtensionsLanguage%>" onclick="el_SetCodeMirror(this, 'file_extensions', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowFileViewer" name="btn_ShowFileViewer" type="button" class="el_long_button" value="<%=model.ShowFileViewerLanguage%>" onclick="el_SetCodeMirror(this, 'file_viewer', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowForeignKey" name="btn_ShowForeignKey" type="button" class="el_long_button" value="<%=model.ShowForeignKeyLanguage%>" onclick="el_SetCodeMirror(this, 'foreign_key', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowGlobalScript" name="btn_ShowGlobalScript" type="button" class="el_long_button" value="<%=model.ShowGlobalScriptLanguage%>" onclick="el_SetCodeMirror(this, 'global_script', 'text/javascript')" />
                    </li>
                    <li>
                        <input id="btn_ShowGlobalStyle" name="btn_ShowGlobalStyle" type="button" class="el_long_button" value="<%=model.ShowGlobalStyleLanguage%>" onclick="el_SetCodeMirror(this, 'global_style', 'text/css')" />
                    </li>
                    <li>
                        <input id="btn_ShowGlobalTemplate" name="btn_ShowGlobalTemplate" type="button" class="el_long_button" value="<%=model.ShowGlobalTemplateLanguage%>" onclick="el_SetCodeMirror(this, 'global_template', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowLinkProtocol" name="btn_ShowLinkProtocol" type="button" class="el_long_button" value="<%=model.ShowLinkProtocolLanguage%>" onclick="el_SetCodeMirror(this, 'link_protocol', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowPageLocation" name="btn_ShowPageLocation" type="button" class="el_long_button" value="<%=model.ShowPageLocationLanguage%>" onclick="el_SetCodeMirror(this, 'page_location', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowReplacePart" name="btn_ShowReplacePart" type="button" class="el_long_button" value="<%=model.ShowReplacePartLanguage%>" onclick="el_SetCodeMirror(this, 'replace_part', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowRobots" name="btn_ShowRobots" type="button" class="el_long_button" value="<%=model.ShowRobotsLanguage%>" onclick="el_SetCodeMirror(this, 'robots', 'text/plain')" />
                    </li>
                    <li>
                        <input id="btn_ShowRoleBitColumnAccess" name="btn_ShowRoleBitColumnAccess" type="button" class="el_long_button" value="<%=model.ShowRoleBitColumnAccessLanguage%>" onclick="el_SetCodeMirror(this, 'role_bit_column_access', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowScheduledTasks" name="btn_ShowScheduledTasks" type="button" class="el_long_button" value="<%=model.ShowScheduledTasksLanguage%>" onclick="el_SetCodeMirror(this, 'scheduled_tasks', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowSecurity" name="btn_ShowSecurity" type="button" class="el_long_button" value="<%=model.ShowSecurityLanguage%>" onclick="el_SetCodeMirror(this, 'security', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowSiteDynamicHead" name="btn_ShowSiteDynamicHead" type="button" class="el_long_button" value="<%=model.ShowSiteDynamicHeadLanguage%>" onclick="el_SetCodeMirror(this, 'site_dynamic_head', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowSiteGlobalLocation" name="btn_ShowSiteGlobalLocation" type="button" class="el_long_button" value="<%=model.ShowSiteGlobalLocationLanguage%>" onclick="el_SetCodeMirror(this, 'site_global_location', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowSiteGlobalStyle" name="btn_ShowSiteGlobalStyle" type="button" class="el_long_button" value="<%=model.ShowSiteGlobalStyleLanguage%>" onclick="el_SetCodeMirror(this, 'site_global_style', 'text/css')" />
                    </li>
                    <li>
                        <input id="btn_ShowSiteGlobalTemplate" name="btn_ShowSiteGlobalTemplate" type="button" class="el_long_button" value="<%=model.ShowSiteGlobalTemplateLanguage%>" onclick="el_SetCodeMirror(this, 'site_global_template', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowSitePageLoad" name="btn_ShowSitePageLoad" type="button" class="el_long_button" value="<%=model.ShowSitePageLoadLanguage%>" onclick="el_SetCodeMirror(this, 'site_page_load', 'text/javascript')" />
                    </li>
                    <li>
                        <input id="btn_ShowSiteScript" name="btn_ShowSiteScript" type="button" class="el_long_button" value="<%=model.ShowSiteScriptLanguage%>" onclick="el_SetCodeMirror(this, 'site_script', 'text/javascript')" />
                    </li>
                    <li>
                        <input id="btn_ShowSiteStaticHead" name="btn_ShowSiteStaticHead" type="button" class="el_long_button" value="<%=model.ShowSiteStaticHeadLanguage%>" onclick="el_SetCodeMirror(this, 'site_static_head', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowStartUp" name="btn_ShowStartUp" type="button" class="el_long_button" value="<%=model.ShowStartUpLanguage%>" onclick="el_SetCodeMirror(this, 'start_up', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowStruct" name="btn_ShowStruct" type="button" class="el_long_button" value="<%=model.ShowStructLanguage%>" onclick="el_SetCodeMirror(this, 'struct', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowSystem" name="btn_ShowSystem" type="button" class="el_long_button" value="<%=model.ShowSystemLanguage%>" onclick="el_SetCodeMirror(this, 'system', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowType" name="btn_ShowType" type="button" class="el_long_button" value="<%=model.ShowTypeLanguage%>" onclick="el_SetCodeMirror(this, 'type', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowUrlRedirect" name="btn_ShowUrlRedirect" type="button" class="el_long_button" value="<%=model.ShowUrlRedirectLanguage%>" onclick="el_SetCodeMirror(this, 'url_redirect', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowUrlRewrite" name="btn_ShowUrlRewrite" type="button" class="el_long_button" value="<%=model.ShowUrlRewriteLanguage%>" onclick="el_SetCodeMirror(this, 'url_rewrite', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowWebConfig" name="btn_ShowWebConfig" type="button" class="el_long_button" value="<%=model.ShowWebConfigLanguage%>" onclick="el_SetCodeMirror(this, 'web_config', 'text/xml')" />
                    </li>
                    <li>
                        <input id="btn_ShowWysiwyg" name="btn_ShowWysiwyg" type="button" class="el_long_button" value="<%=model.ShowWysiwygLanguage%>" onclick="el_SetCodeMirror(this, 'wysiwyg', 'text/xml')" />
                    </li>
                </ul>
            </div>
        </div>
        <div class="el_part_row">
            <div id="div_ConfigurationTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <div id="div_ConfigName"></div>
                <div class="el_dash"></div>
            </div>
            <div class="el_item el_left_to_right">
                <div id="div_ConfigBox">
                    <textarea id="txt_Config" name="txt_Config" class="el_textarea_input el_left_to_right"></textarea>
                </div>
            </div>

            <div class="el_item">
                <input id="btn_SaveConfig" name="btn_SaveConfig" type="submit" class="el_button_input" value="<%=model.SaveConfigLanguage%>" onclick="el_CodeMirrorIssues(); el_AjaxPostBack(this, false, 'frm_AdminConfiguration')" />
            </div>

        </div>

    </form>

    <script>
       var editor;
    </script>

</body>
</html>