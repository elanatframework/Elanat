<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ExtraHelperXmlSitemapOption" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.XmlSitemapOptionLanguage%></title>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant/"></script>
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.XmlSitemapOptionLanguage%>
    </div>

    <form id="frm_ExtraHelperXmlSitemapOption" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/xml_sitemap_option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <%=model.XmlSitemapCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_XmlSitemapCount" name="txt_XmlSitemapCount" type="number" value="<%=model.XmlSitemapCountValue%>" class="el_text_input<%=model.XmlSitemapCountCssClass%>" <%=model.XmlSitemapCountAttribute%> />
            </div>
            <div class="el_item">
                <%=model.XmlSitemapCacheLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_XmlSitemapCache" name="txt_XmlSitemapCache" type="number" value="<%=model.XmlSitemapCacheValue%>" class="el_text_input<%=model.XmlSitemapCacheCssClass%>" <%=model.XmlSitemapCacheAttribute%> />
            </div>
            <div class="el_item">
                <input id="btn_SaveXmlSitemapOption" name="btn_SaveXmlSitemapOption" type="submit" class="el_button_input" value="<%=model.SaveXmlSitemapOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ExtraHelperXmlSitemapOption')" />
            </div>
        </div>

    </form>
</body>
</html>