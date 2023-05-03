<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteContentReplyAddress.aspx.cs" Inherits="elanat.SiteContentReplyAddress" %>
            <div id="pnl_Address">
                <div class="el_item">
                    <%=model.AddressLanguage%>
                </div>
                <div class="el_item">
                    <textarea id="txt_Address" name="txt_Address" class="el_textarea_input<%=model.AddressCssClass%>" <%=model.AddressAttribute%>><%=model.AddressValue%></textarea>
                </div>
            </div>