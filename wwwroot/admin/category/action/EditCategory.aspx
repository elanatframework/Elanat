<%@ Page Controller="Elanat.ActionEditCategoryController" Model="Elanat.ActionEditCategoryModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditCategoryLanguage%></title>
    <!-- Start Client Variant -->
    <%=Elanat.AspxHtmlValue.CurrentAdminClientVariant()%>
    <!-- End Client Variant -->	
    <script src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/global.js"></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/admin/admin.js" ></script>
    <script type="text/javascript" src="<%=Elanat.AspxHtmlValue.SitePath()%>client/script/page_load/admin/page_load.js" ></script>
    <%=Elanat.AspxHtmlValue.CurrentAdminStyleTag()%>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/global.css" />
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.SitePath()%>client/style/admin_global.css" />
    <%=Elanat.AspxHtmlValue.CurrentBoxTag()%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body onload="el_PartPageLoad();">
    <form id="frm_ActionEditCategory" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/category/action/EditCategory.aspx">

        <div class="el_part_row">
            <div id="div_EditCategoryTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditCategoryLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.CategoryNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_CategoryName" name="txt_CategoryName" type="text" value="<%=model.CategoryNameValue%>" class="el_text_input<%=model.CategoryNameCssClass%>" <%=model.CategoryNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ParentCategoryLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_ParentCategory" name="ddlst_ParentCategory" class="el_alone_select_input<%=model.ParentCategoryCssClass%>" <%=model.ParentCategoryAttribute%>><%=model.ParentCategoryOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.CategorySiteLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_CategorySite" name="ddlst_CategorySite" class="el_alone_select_input<%=model.CategorySiteCssClass%>" <%=model.CategorySiteAttribute%>><%=model.CategorySiteOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultStyleLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultStyle" name="ddlst_DefaultStyle" class="el_alone_select_input<%=model.DefaultStyleCssClass%>" <%=model.DefaultStyleAttribute%>><%=model.DefaultStyleOptionListValue%></select>
            </div>
            <div class="el_item">
                <%=model.DefaultTemplateLanguage%>
            </div>
            <div class="el_item">
                <select id="ddlst_DefaultTemplate" name="ddlst_DefaultTemplate" class="el_alone_select_input<%=model.DefaultTemplateCssClass%>" <%=model.DefaultTemplateAttribute%>><%=model.DefaultTemplateOptionListValue%></select>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CategoryActive" name="cbx_CategoryActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CategoryActiveValue)%> /><label for="cbx_CategoryActive"><%=model.CategoryActiveLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CategoryRequireApproval" name="cbx_CategoryRequireApproval" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CategoryRequireApprovalValue)%> /><label for="cbx_CategoryRequireApproval"><%=model.CategoryRequireApprovalLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.CategoryAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_CategoryPublicAccessShow" name="cbx_CategoryPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.CategoryPublicAccessShowValue)%> /><label for="cbx_CategoryPublicAccessShow"><%=model.CategoryPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.CategoryAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveCategory" name="btn_SaveCategory" type="submit" class="el_button_input" value="<%=model.SaveCategoryLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditCategory')" />
            </div>
        </div>

        <input id="hdn_CategoryId" name="hdn_CategoryId" type="hidden" value="<%=model.CategoryIdValue%>" />

    </form>
</body>
</html>