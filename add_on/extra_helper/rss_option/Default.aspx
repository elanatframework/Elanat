<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.ExtraHelperRssOption" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.RssOptionLanguage%></title>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_variant"></script>
    <script type="text/javascript" src="<%=elanat.AspxHtmlValue.SitePath()%>action/text_creator/admin_client_language_variant/"></script>
    <script src="<%=elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
</head>
<body onload="el_PartPageLoad();">

    <div class="el_head">
        <%=model.RssOptionLanguage%>
    </div>

    <form id="frm_ExtraHelperRssOption" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>add_on/extra_helper/rss_option/Default.aspx">

        <div class="el_part_row">
            <div class="el_item">
                <%=model.FeedCountLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_FeedCount" name="txt_FeedCount" type="number" value="<%=model.FeedCountValue%>" class="el_text_input<%=model.FeedCountCssClass%>" <%=model.FeedCountAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ContentTextLengthLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ContentTextLength" name="txt_ContentTextLength" type="number" value="<%=model.ContentTextLengthValue%>" class="el_text_input<%=model.ContentTextLengthCssClass%>" <%=model.ContentTextLengthAttribute%> />
            </div>
            <div class="el_item">
                <%=model.RssCacheLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_RssCache" name="txt_RssCache" type="number" value="<%=model.RssCacheValue%>" class="el_text_input<%=model.RssCacheCssClass%>" <%=model.RssCacheAttribute%> />
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_UseRemoveHtmlTag" name="cbx_UseRemoveHtmlTag" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.UseRemoveHtmlTagValue)%> /><label for="cbx_UseRemoveHtmlTag"><%=model.UseRemoveHtmlTagLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveAuthorFeed" name="cbx_ActiveAuthorFeed" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveAuthorFeedValue)%> /><label for="cbx_ActiveAuthorFeed"><%=model.ActiveAuthorFeedLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveCategoryFeed" name="cbx_ActiveCategoryFeed" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveCategoryFeedValue)%> /><label for="cbx_ActiveCategoryFeed"><%=model.ActiveCategoryFeedLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ActiveContentTypeFeed" name="cbx_ActiveContentTypeFeed" type="checkbox" <%=elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ActiveContentTypeFeedValue)%> /><label for="cbx_ActiveContentTypeFeed"><%=model.ActiveContentTypeFeedLanguage%></label></span>
            </div>
            <div class="el_item">
                <input id="btn_SaveRssOption" name="btn_SaveRssOption" type="submit" class="el_button_input" value="<%=model.SaveRssOptionLanguage%>" onclick="el_AjaxPostBack(this, false, 'frm_ExtraHelperRssOption')" />
            </div>
        </div>

    </form>
</body>
</html>