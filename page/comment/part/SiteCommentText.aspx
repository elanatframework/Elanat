﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteCommentText.aspx.cs" Inherits="elanat.SiteCommentText" %>
            <div id="pnl_Text">
                <div class="el_item">
                    <%=model.TextLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_Text" name="txt_Text" class="el_textarea_input<%=model.TextCssClass%>" <%=model.TextAttribute%>><%=model.TextValue%></textarea>
                </div>
            </div>