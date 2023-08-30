<%@ Page Controller="Elanat.PluginShowAdminSiteDropDownListController" Model="Elanat.PluginShowAdminSiteDropDownListModel" %>
<span><%=model.SiteLanguage%></span>
<select id="ddlst_Site" name="ddlst_Site" class="el_alone_select_input" onchange="el_GoToSite(this, true)">
    <%=model.OptionListValue %>
</select>