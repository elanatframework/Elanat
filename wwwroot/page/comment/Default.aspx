<%@ Page Controller="Elanat.SiteCommentController" Model="Elanat.SiteCommentModel"%>
<div id="div_CommentPostBack">
    <form id="frm_SiteComment" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/comment/Default.aspx" enctype="multipart/form-data">

        <div class="el_head">
            <%=model.CommentLanguage%>
        </div>

        <%=model.LastCommentPartValue%>

        <%=model.InaccessReasonPartValue%>

        <%=model.CommentBoxPartValue%>

        <input id="hdn_ParentComment" name="hdn_ParentComment" type="hidden" value="<%=model.ParentCommentValue%>" />
        <input id="hdn_ContentId" name="hdn_ContentId" type="hidden" value="<%=model.ContentIdValue%>" />

    </form>

    <script>
	    el_CreateWysiwyg();
    </script>
</div>