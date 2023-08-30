<%@ Page Controller="Elanat.AdminRefreshController" Model="Elanat.AdminRefreshModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.RefreshLanguage%></title>
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
        <%=model.RefreshLanguage%>
    </div>

    <form id="frm_AdminRefreshRefresh" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/refresh/Default.aspx">

        <div class="el_part_row">
            <div id="div_RefreshTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.RefreshLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ApplicationStartLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_ApplicationStart" name="btn_ApplicationStart" type="submit" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshRefresh')" />
            </div>
            <div class="el_item">
                <%=model.LockLoginLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_LockLogin" name="btn_LockLogin" type="submit" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshRefresh')" />
            </div>
            <div class="el_item">
                <%=model.CacheLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_Cache" name="btn_Cache" type="submit" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshRefresh')" />
            </div>
            <div class="el_item">
                <%=model.SessionLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_Session" name="btn_Session" type="submit" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshRefresh')" />
            </div>
            <div class="el_item">
                <%=model.CookieLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_Cookie" name="btn_Cookie" type="submit" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshRefresh')" />
            </div>
            <div class="el_item">
                <%=model.LoginIpBlackListLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_LoginIpBlackList" name="btn_LoginIpBlackList" type="submit" class="el_button_input" value="<%=model.RefreshLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshRefresh')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminRefreshReCreat" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/refresh/Default.aspx">

        <div class="el_part_row">
            <div id="div_ReCreateTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.ReCreateLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.SiteCategoryLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_SiteCategory" name="btn_SiteCategory" type="submit" class="el_button_input" value="<%=model.ReCreateLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshReCreat')" />
            </div>
            <div class="el_item">
                <%=model.UploadFileListLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_UploadFileList" name="btn_UploadFileList" type="submit" class="el_button_input" value="<%=model.ReCreateLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshReCreat')" />
            </div>
        </div>

    </form>

    <form id="frm_AdminRefreshDelete" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/refresh/Default.aspx">

        <div class="el_part_row">
            <div id="div_DeleteTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.DeleteLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.DiskCacheDirectoryLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_DiskCacheDirectory" name="btn_DiskCacheDirectory" type="submit" class="el_button_input" value="<%=model.DeleteLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshDelete')" />
            </div>
            <div class="el_item">
                <%=model.TmpDirectoryLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_TmpDirectory" name="btn_TmpDirectory" type="submit" class="el_button_input" value="<%=model.DeleteLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshDelete')" />
            </div>
            <div class="el_item">
                <%=model.LogsDirectoryLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_LogsDirectory" name="btn_LogsDirectory" type="submit" class="el_button_input" value="<%=model.DeleteLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshDelete')" />
            </div>
            <div class="el_item">
                <%=model.FoorPrintLanguage%>
            </div>
            <div class="el_item">
                <input id="btn_FoorPrint" name="btn_FoorPrint" type="submit" class="el_button_input" value="<%=model.DeleteLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_AdminRefreshDelete')" />
            </div>
        </div>

    </form>

</body>
</html>