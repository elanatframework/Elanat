<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteContactTitle.aspx.cs" Inherits="elanat.SiteContactTitle" %>
            <div id="pnl_Title">
                <div class="el_item">
                    <%=model.TitleLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_Title" name="txt_Title" type="text" value="<%=model.TitleValue%>" class="el_long_text_input<%=model.TitleCssClass%>" <%=model.TitleAttribute%> />
                </div>
            </div>