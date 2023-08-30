<%@ Page Controller="Elanat.PluginShowLanguageDropDownListController" Model="Elanat.PluginShowLanguageDropDownListModel" %>
<select id="ddlst_Language" name="ddlst_Language" class="el_alone_select_input" onchange="el_GoToLanguage(this, false)">
    <%=model.OptionListValue %>
</select>