<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteSignUpStateOrProvince.aspx.cs" Inherits="elanat.SiteSignUpStateOrProvince" %>
            <div id="pnl_StateOrProvince">
                <div class="el_item">
                    <%=model.StateOrProvinceLanguage%>
                </div>
                <div class="el_item">
                    <input id="txt_StateOrProvince" name="txt_StateOrProvince" type="text" value="<%=model.StateOrProvinceValue%>" class="el_text_input<%=model.StateOrProvinceCssClass%>" <%=model.StateOrProvinceAttribute%> />
                </div>
            </div>