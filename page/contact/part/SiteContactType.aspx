﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteContactType.aspx.cs" Inherits="elanat.SiteContactType" %>
            <div id="pnl_Type">
                <div class="el_item">
                    <%=model.TypeLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_Type" name="ddlst_Type" class="el_alone_select_input<%=model.TypeCssClass%>" <%=model.TypeAttribute%>><%=model.TypeOptionListValue%></select>
                </div>
            </div>