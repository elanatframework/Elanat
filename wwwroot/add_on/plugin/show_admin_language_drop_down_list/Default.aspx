<%@ Page Controller="Elanat.PluginShowAdminLanguageDropDownListController" Model="Elanat.PluginShowAdminLanguageDropDownListModel" %>
<span><%=model.LanguageLanguage%></span>
<select id="ddlst_Language" name="ddlst_Language" class="el_alone_select_input" onchange="el_GoToLanguage(this, true)">
    <%=model.OptionListValue %>
</select>
