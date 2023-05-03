<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteSignUpPostalCode.aspx.cs" Inherits="elanat.SiteSignUpPostalCode" %>
            <div id="pnl_PostalCode">
                <div class="el_item">
                    <%=model.PostalCodeLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_PostalCode" name="txt_PostalCode" type="text" value="<%=model.PostalCodeValue%>" class="el_text_input el_left_to_right<%=model.PostalCodeCssClass%>" <%=model.PostalCodeAttribute%> />
                </div>
            </div>