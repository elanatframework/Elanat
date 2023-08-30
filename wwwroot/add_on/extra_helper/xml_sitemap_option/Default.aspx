<%@ Page Controller="Elanat.ExtraHelperXmlSitemapOptionController" Model="Elanat.ExtraHelperXmlSitemapOptionModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.XmlSitemapOptionLanguage%></title>
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.XmlSitemapOptionLanguage%>
    </div>

    <form id="frm_ExtraHelperXmlSitemapOption" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/xml_sitemap_option/Default.aspx">

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