<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.PluginShowLanguageDropDownList" %>
<select id="ddlst_Language" name="ddlst_Language" class="el_alone_select_input" onchange="el_GoToLanguage(this, false)">
    <%=model.OptionListValue %>
</select>