<%@ Page Controller="Elanat.ActionEditHandheldLanguageVariantController" Model="Elanat.ActionEditHandheldLanguageVariantModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditHandheldLanguageVariantLanguage%></title>
    <script src="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/script/language.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/style/language.css" />
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
<body onload="el_ListBoxAutoSizeByListBoxId('lstx_HandheldLanguageVariant'); el_PartPageLoad();">
    <form id="frm_ActionEditHandheldLanguageVariant" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/action/edit_handheld_language_variant/EditHandheldLanguageVariant.aspx" >

        <div class="el_part_row">
            <div id="div_EditHandheldLanguage" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditHandheldLanguageVariantLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.HandheldAlphabetButtonLanguage%>
            </div>
            <div class="el_button_box">
                <input id="btn_ShowOtherHandheldCharacter" name="btn_ShowOtherHandheldCharacter" type="submit" class="el_charachter_button_input" value="@" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowAHandheldCharacter" name="btn_ShowAHandheldCharacter" type="submit" class="el_charachter_button_input" value="A" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowBHandheldCharacter" name="btn_ShowBHandheldCharacter" type="submit" class="el_charachter_button_input" value="B" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowCHandheldCharacter" name="btn_ShowCHandheldCharacter" type="submit" class="el_charachter_button_input" value="C" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowDHandheldCharacter" name="btn_ShowDHandheldCharacter" type="submit" class="el_charachter_button_input" value="D" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowEHandheldCharacter" name="btn_ShowEHandheldCharacter" type="submit" class="el_charachter_button_input" value="E" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowFHandheldCharacter" name="btn_ShowFHandheldCharacter" type="submit" class="el_charachter_button_input" value="F" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowGHandheldCharacter" name="btn_ShowGHandheldCharacter" type="submit" class="el_charachter_button_input" value="G" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowHHandheldCharacter" name="btn_ShowHHandheldCharacter" type="submit" class="el_charachter_button_input" value="H" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowIHandheldCharacter" name="btn_ShowIHandheldCharacter" type="submit" class="el_charachter_button_input" value="I" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowJHandheldCharacter" name="btn_ShowJHandheldCharacter" type="submit" class="el_charachter_button_input" value="J" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowKHandheldCharacter" name="btn_ShowKHandheldCharacter" type="submit" class="el_charachter_button_input" value="K" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowLHandheldCharacter" name="btn_ShowLHandheldCharacter" type="submit" class="el_charachter_button_input" value="L" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowMHandheldCharacter" name="btn_ShowMHandheldCharacter" type="submit" class="el_charachter_button_input" value="M" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowNHandheldCharacter" name="btn_ShowNHandheldCharacter" type="submit" class="el_charachter_button_input" value="N" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowOHandheldCharacter" name="btn_ShowOHandheldCharacter" type="submit" class="el_charachter_button_input" value="O" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowPHandheldCharacter" name="btn_ShowPHandheldCharacter" type="submit" class="el_charachter_button_input" value="P" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowQHandheldCharacter" name="btn_ShowQHandheldCharacter" type="submit" class="el_charachter_button_input" value="Q" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowRHandheldCharacter" name="btn_ShowRHandheldCharacter" type="submit" class="el_charachter_button_input" value="R" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowSHandheldCharacter" name="btn_ShowSHandheldCharacter" type="submit" class="el_charachter_button_input" value="S" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowTHandheldCharacter" name="btn_ShowTHandheldCharacter" type="submit" class="el_charachter_button_input" value="T" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowUHandheldCharacter" name="btn_ShowUHandheldCharacter" type="submit" class="el_charachter_button_input" value="U" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowVHandheldCharacter" name="btn_ShowVHandheldCharacter" type="submit" class="el_charachter_button_input" value="V" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowWHandheldCharacter" name="btn_ShowWHandheldCharacter" type="submit" class="el_charachter_button_input" value="W" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowXHandheldCharacter" name="btn_ShowXHandheldCharacter" type="submit" class="el_charachter_button_input" value="X" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowYHandheldCharacter" name="btn_ShowYHandheldCharacter" type="submit" class="el_charachter_button_input" value="Y" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
                <input id="btn_ShowZHandheldCharacter" name="btn_ShowZHandheldCharacter" type="submit" class="el_charachter_button_input" value="Z" onclick="el_CleanHandheldLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
            </div>
            <div class="el_item">
                <div id="div_HandheldLanguageVariantList"></div>
            </div>
            <div class="el_item">
                <input id="btn_DeleteHandheldLanguageVariant" name="btn_DeleteHandheldLanguageVariant" type="submit" class="el_button_input" value="<%=model.DeleteHandheldLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
            </div>
            <div class="el_item">
                <div id="div_HandheldLanguageVariant"></div>
            </div>
            <div class="el_item">
                <input id="btn_SaveHandheldLanguageVariant" name="btn_SaveHandheldLanguageVariant" type="submit" class="el_button_input" value="<%=model.SaveHandheldLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditHandheldLanguageVariant')" />
            </div>
        </div>

    </form>
</body>
</html>