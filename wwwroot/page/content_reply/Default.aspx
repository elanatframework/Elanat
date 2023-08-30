<%@ Page Controller="Elanat.SiteContentReplyController" Model="Elanat.SiteContentReplyModel" %>
<div id="div_ContentReplyPostBack">
    <form id="frm_SiteContentReply" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/content_reply/Default.aspx">

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