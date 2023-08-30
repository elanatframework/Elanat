<%@ Page Controller="Elanat.ActionSearchController" Model="Elanat.ActionSearchModel" %>
<div class="el_item">
    <%=model.SearchTermLanguage%>
</div>
<div class="el_item">
    <b>
        <%=model.SearchTermValue%>
    </b>
</div>
<div class="el_item">
    <%=model.ResultsLanguage%>
</div>
<div class="el_item">
    <%=model.ContentValue%>
</div>