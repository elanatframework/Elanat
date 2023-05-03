<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteContactPublicEmail.aspx.cs" Inherits="elanat.SiteContactPublicEmail" %>
            <div id="pnl_PublicEmail">
                <div class="el_item">
                    <%=model.PublicEmailLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_PublicEmail" name="txt_PublicEmail" type="text" value="<%=model.PublicEmailValue%>" class="el_text_input el_left_to_right<%=model.PublicEmailCssClass%>" <%=model.PublicEmailAttribute%> />
                </div>
            </div>