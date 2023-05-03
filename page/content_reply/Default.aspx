<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.SiteContentReply" ValidateRequest="false" %>
<div id="div_ContentReplyPostBack">
    <form id="frm_SiteContentReply" method="post" action="<%=elanat.AspxHtmlValue.SitePath()%>page/content_reply/Default.aspx">

        <div class="el_head">
            <%=model.ContentReplyLanguage%>
        </div>

        <%=model.ContentReplyBoxPartValue%>

        <input id="hdn_ContentId" name="hdn_ContentId" type="hidden" value="<%=model.ContentIdValue%>" />

    </form>

    <script>
	    el_CreateWysiwyg();
    </script>
</div>