<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteCommentCity.aspx.cs" Inherits="elanat.SiteCommentCity" %>
            <div id="pnl_City">
                <div class="el_item">
                    <%=model.CityLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_City" name="txt_City" type="text" value="<%=model.CityValue%>" class="el_text_input<%=model.CityCssClass%>" <%=model.CityAttribute%> />
                </div>
            </div>