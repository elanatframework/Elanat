<%@ Page Controller="Elanat.MemberUserContentController" Model="Elanat.MemberUserContentModel" %>
    <div class="el_head">
        <%=model.UserContentLanguage%>
    </div>
    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>