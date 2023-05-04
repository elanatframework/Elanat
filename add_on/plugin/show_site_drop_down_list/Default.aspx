<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.PluginShowSiteDropDownList" %>
<select id="ddlst_Site" name="ddlst_Site" class="el_alone_select_input" onchange="el_GoToSite(this, false)">
    <%=model.OptionListValue %>
</select>