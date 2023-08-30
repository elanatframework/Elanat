<%@ Page Controller="Elanat.ActionEditItemController" Model="Elanat.ActionEditItemModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditItemLanguage%></title>
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
    <form id="frm_ActionEditItem" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/item/action/EditItem.aspx">

        <div class="el_part_row">
            <div id="div_EditItemTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditItemLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.ItemNameLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ItemName" name="txt_ItemName" type="text" value="<%=model.ItemNameValue%>" class="el_text_input<%=model.ItemNameCssClass%>" <%=model.ItemNameAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ItemValueLanguage%>
            </div>
            <div class="el_item">
                <textarea id="txt_ItemValue" name="txt_ItemValue" class="el_textarea_input<%=model.ItemValueCssClass%>" <%=model.ItemValueAttribute%>><%=model.ItemValueValue%></textarea>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseBox" name="cbx_ItemUseBox" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseBoxValue)%> /><label for="cbx_ItemUseBox"><%=model.ItemUseBoxLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseLanguage" name="cbx_ItemUseLanguage" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseLanguageValue)%> /><label for="cbx_ItemUseLanguage"><%=model.ItemUseLanguageLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseModule" name="cbx_ItemUseModule" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseModuleValue)%> /><label for="cbx_ItemUseModule"><%=model.ItemUseModuleLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUsePlugin" name="cbx_ItemUsePlugin" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUsePluginValue)%> /><label for="cbx_ItemUsePlugin"><%=model.ItemUsePluginLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseReplacePart" name="cbx_ItemUseReplacePart" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseReplacePartValue)%> /><label for="cbx_ItemUseReplacePart"><%=model.ItemUseReplacePartLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseFetch" name="cbx_ItemUseFetch" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseFetchValue)%> /><label for="cbx_ItemUseFetch"><%=model.ItemUseFetchLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseItem" name="cbx_ItemUseItem" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseItemValue)%> /><label for="cbx_ItemUseItem"><%=model.ItemUseItemLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemUseElanat" name="cbx_ItemUseElanat" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemUseElanatValue)%> /><label for="cbx_ItemUseElanat"><%=model.ItemUseElanatLanguage%></label></span>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemActive" name="cbx_ItemActive" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemActiveValue)%> /><label for="cbx_ItemActive"><%=model.ItemActiveLanguage%></label></span>
            </div>
            <div class="el_item">
	            <%=model.ItemCacheDurationLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ItemCacheDuration" name="txt_ItemCacheDuration" type="number" value="<%=model.ItemCacheDurationValue%>" class="el_text_input<%=model.ItemCacheDurationCssClass%>" <%=model.ItemCacheDurationAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ItemSortIndexLanguage%>
            </div>
            <div class="el_item">
                <input id="txt_ItemSortIndex" name="txt_ItemSortIndex" type="number" value="<%=model.ItemSortIndexValue%>" class="el_text_input<%=model.ItemSortIndexCssClass%>" <%=model.ItemSortIndexAttribute%> />
            </div>
            <div class="el_item">
                <%=model.ItemMenuLanguage%>
            </div>
            <div class="el_item">
                <%=model.ItemMenuTemplateValue%>
            </div>
            <div class="el_item">
                <%=model.ItemAccessShowLanguage%>
            </div>
            <div class="el_item">
                <span class="el_checkbox_input"><input id="cbx_ItemPublicAccessShow" name="cbx_ItemPublicAccessShow" type="checkbox" <%=Elanat.AspxHtmlValue.BooleanToCheckedHtmlAttribute(model.ItemPublicAccessShowValue)%> /><label for="cbx_ItemPublicAccessShow"><%=model.ItemPublicAccessShowLanguage%></label></span>
            </div>
            <div class="el_item">
                <%=model.ItemAccessShowTemplateValue%>
            </div>
            <div class="el_item">
                <input id="btn_SaveItem" name="btn_SaveItem" type="submit" class="el_button_input" value="<%=model.SaveItemLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditItem')" />
            </div>
        </div>

        <input id="hdn_ItemId" name="hdn_ItemId" type="hidden" value="<%=model.ItemIdValue%>" />

    </form>
</body>
</html>
