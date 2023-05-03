<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetResponse.aspx.cs" Inherits="elanat.ActionSiteGetResponse" %>
<div class="el_item">
    <div class="el_down_details el_green_text">
		<div class="el_details_item">
			<%=model.ContactResponseTextLanguage%>
		</div>
	</div>
</div>
<div class="el_item">
    <%=model.ContactResponseValue%>
</div>