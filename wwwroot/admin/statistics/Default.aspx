<%@ Page Controller="Elanat.AdminStatisticsController" Model="Elanat.AdminStatisticsModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.StatisticsLanguage%></title>
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
        <%=model.StatisticsLanguage%>
    </div>
        
    <div class="el_part_row">
        <div id="div_System" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
            <%=model.SystemLanguage%>
            <div class="el_dash"></div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.MachineNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.MachineNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserDomainNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserDomainNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserInteractiveLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserInteractiveValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.UserNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.UserNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.OsVersionLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.OsVersionValue%>
                </div>
            </div>
        </div>

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
                    <%=model.OsPlatformLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.OsPlatformValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.Is64BitOperatingSystemLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.Is64BitOperatingSystemValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.TickCountLanguage%>
                </div>
                <div class="el_extra_value">
                    <div class="el_label">
                        <%=model.TickCountValue%>
                    </div>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.WorkingSetLanguage%>
                </div>
                <div class="el_extra_value">
                    <div class="el_label">
                        <%=model.WorkingSetValue%>
                    </div>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.SystemPageSizeLanguage%>
                </div>
                <div class="el_extra_value">
                    <div class="el_label">
                        <%=model.SystemPageSizeValue%>
                    </div>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.ProcessorCountLanguage%>
                </div>
                <div class="el_extra_value">
                    <div class="el_label">
                        <%=model.ProcessorCountValue%>
                    </div>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.Is64BitProcessLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.Is64BitProcessValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.CurrentDirectoryLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.CurrentDirectoryValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.WebServerNameLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.WebServerNameValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.LogicalDrivesLanguage%>
                </div>
                <div class="el_extra_value">
                    <%=model.LogicalDrivesValue%>
                </div>
            </div>
        </div>

        <div class="el_item">
            <div class="el_extra_label">
                <div class="el_extra_title">
                    <%=model.BrowserAndOsInfoLanguage%>
                </div>
                <div class="el_extra_value">
                    <script>
                        document.write("[" + navigator.appName + "] [" + navigator.platform + "] " + navigator.userAgent);
                    </script>
                </div>
            </div>
        </div>

    </div>

</body>
</html>