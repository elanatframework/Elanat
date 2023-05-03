<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elanat.MemberUserFootPrint" %>
    <div class="el_head">
        <%=model.UserFootPrintLanguage%>
    </div>
    <div class="el_part_row">
        <div id="div_TableBox" class="el_item">
            <%=model.ContentValue%>
        </div>
    </div>