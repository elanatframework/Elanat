﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartSiteSearchTitleOrText.aspx.cs" Inherits="elanat.PartSiteSearchTitleOrText" %>
            <div id="pnl_TitleOrText">
                <div class="el_item">
                    <%=model.TitleSearchOrTextSearchLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_TitleOrText" name="ddlst_TitleOrText" class="el_alone_select_input">
                        <%=model.OptionListValue%>
                    </select>
                </div>
            </div>