<%@ Page Controller="Elanat.SiteSearchController" Model="Elanat.SiteSearchModel" %>
<div id="div_SearchPostBack">
    <form id="frm_SiteSearch" method="post" action="<%=Elanat.AspxHtmlValue.SitePath()%>page/search/Default.aspx">
        
        <div class="el_head">
             <%=model.SearchLanguage%>
        </div>
        <div class="el_part_row">
            <div id="div_SearchTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.SearchLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.WordLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_Search" name="txt_Search" type="text" value="<%=model.SearchValue%>" class="el_text_input" />
            </div>

            <%=model.TitleOrTextPartValue%>

            <%=model.DatePartValue%>

            <%=model.CategoryPartValue%>

            <div class="el_item">
                <input id="btn_Search" name="btn_Search" type="submit" class="el_button_input" value="<%=model.SearchLanguage%>" onclick="el_AjaxPostBack(this, false, 'div_SearchValue', true)" />
            </div>
            <div id="div_SearchValue" class="el_item">
                <%=model.ContentValue%>
            </div>
        </div>

    </form>
</div>