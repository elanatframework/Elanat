<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartSiteSearchCategory.aspx.cs" Inherits="elanat.PartSiteSearchCategory" %>
            <div id="pnl_Category">
                <div class="el_item">
                    <%=model.CategoryLanguage%>
                </div>
                <div class="el_item">
                    <select id="ddlst_Category" name="ddlst_Category" class="el_alone_select_input">
                        <%=model.OptionListValue%>
                    </select>
                </div>
            </div>