<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteContactPhoneNumber.aspx.cs" Inherits="elanat.SiteContactPhoneNumber" %>
            <div id="pnl_PhoneNumber">
                <div class="el_item">
                    <%=model.PhoneNumberLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_PhoneNumber" name="txt_PhoneNumber" type="text" value="<%=model.PhoneNumberValue%>" class="el_text_input el_left_to_right<%=model.PhoneNumberCssClass%>" <%=model.PhoneNumberAttribute%> />
                </div>
            </div>