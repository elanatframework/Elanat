﻿<%@ Page Controller="Elanat.ActionSetLanguageVariantController" Model="Elanat.ActionSetLanguageVariantModel" %>
<select id="lstx_LanguageVariant" name="lstx_LanguageVariant" style="direction: ltr" onchange="el_SetLanguageVariant(this)" size="<%=model.LanguageVariantCountValue%>" class="el_more_select_input"><%=model.LanguageVariantOptionListValue%></select>