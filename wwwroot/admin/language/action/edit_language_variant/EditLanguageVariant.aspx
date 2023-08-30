<%@ Page Controller="Elanat.ActionEditLanguageVariantController" Model="Elanat.ActionEditLanguageVariantModel" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="<%=Elanat.AspxHtmlValue.CurrentAdminLanguageDirection()%>">
<head>
    <title><%=model.EditLanguageVariantLanguage%></title>
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
<body onload="el_ListBoxAutoSizeByListBoxId('lstx_LanguageVariant'); el_PartPageLoad();">
    <form id="frm_ActionEditLanguageVariant" method="post" action="<%=Elanat.AspxHtmlValue.AdminPath()%>/language/action/edit_language_variant/EditLanguageVariant.aspx" >

        <div class="el_part_row">
            <div id="div_EditLanguage" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                <%=model.EditLanguageVariantLanguage%>
                <div class="el_dash"></div>
            </div>
            <div class="el_item">
                <%=model.AlphabetButtonLanguage%>
            </div>
            <div class="el_button_box">
                <input id="btn_ShowOtherCharacter" name="btn_ShowOtherCharacter" type="submit" class="el_charachter_button_input" value="@" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowACharacter" name="btn_ShowACharacter" type="submit" class="el_charachter_button_input" value="A" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowBCharacter" name="btn_ShowBCharacter" type="submit" class="el_charachter_button_input" value="B" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowCCharacter" name="btn_ShowCCharacter" type="submit" class="el_charachter_button_input" value="C" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowDCharacter" name="btn_ShowDCharacter" type="submit" class="el_charachter_button_input" value="D" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowECharacter" name="btn_ShowECharacter" type="submit" class="el_charachter_button_input" value="E" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowFCharacter" name="btn_ShowFCharacter" type="submit" class="el_charachter_button_input" value="F" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowGCharacter" name="btn_ShowGCharacter" type="submit" class="el_charachter_button_input" value="G" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowHCharacter" name="btn_ShowHCharacter" type="submit" class="el_charachter_button_input" value="H" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowICharacter" name="btn_ShowICharacter" type="submit" class="el_charachter_button_input" value="I" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowJCharacter" name="btn_ShowJCharacter" type="submit" class="el_charachter_button_input" value="J" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowKCharacter" name="btn_ShowKCharacter" type="submit" class="el_charachter_button_input" value="K" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowLCharacter" name="btn_ShowLCharacter" type="submit" class="el_charachter_button_input" value="L" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowMCharacter" name="btn_ShowMCharacter" type="submit" class="el_charachter_button_input" value="M" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowNCharacter" name="btn_ShowNCharacter" type="submit" class="el_charachter_button_input" value="N" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowOCharacter" name="btn_ShowOCharacter" type="submit" class="el_charachter_button_input" value="O" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowPCharacter" name="btn_ShowPCharacter" type="submit" class="el_charachter_button_input" value="P" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowQCharacter" name="btn_ShowQCharacter" type="submit" class="el_charachter_button_input" value="Q" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowRCharacter" name="btn_ShowRCharacter" type="submit" class="el_charachter_button_input" value="R" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowSCharacter" name="btn_ShowSCharacter" type="submit" class="el_charachter_button_input" value="S" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowTCharacter" name="btn_ShowTCharacter" type="submit" class="el_charachter_button_input" value="T" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowUCharacter" name="btn_ShowUCharacter" type="submit" class="el_charachter_button_input" value="U" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowVCharacter" name="btn_ShowVCharacter" type="submit" class="el_charachter_button_input" value="V" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowWCharacter" name="btn_ShowWCharacter" type="submit" class="el_charachter_button_input" value="W" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowXCharacter" name="btn_ShowXCharacter" type="submit" class="el_charachter_button_input" value="X" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowYCharacter" name="btn_ShowYCharacter" type="submit" class="el_charachter_button_input" value="Y" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
                <input id="btn_ShowZCharacter" name="btn_ShowZCharacter" type="submit" class="el_charachter_button_input" value="Z" onclick="el_CleanLanguageVariantList(); el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
            </div>
            <div class="el_item">
                <div id="div_LanguageVariantList"></div>
            </div>
            <div class="el_item">
                <input id="btn_DeleteLanguageVariant" name="btn_DeleteLanguageVariant" type="submit" class="el_button_input" value="<%=model.DeleteLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
            </div>
            <div class="el_item">
                <div id="div_LanguageVariant"></div>
            </div>
            <div class="el_item">
                <input id="btn_SaveLanguageVariant" name="btn_SaveLanguageVariant" type="submit" class="el_button_input" value="<%=model.SaveLanguageVariantLanguage%>" onclick="el_AjaxPostBack(this, true, 'frm_ActionEditLanguageVariant')" />
            </div>
        </div>

    </form>
</body>
</html>