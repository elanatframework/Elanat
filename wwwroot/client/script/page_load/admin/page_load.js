function el_PageLoad()
{
	el_OpenAjaxLoading();
	
	el_ShowAddOnsGroup(document.getElementById("a_Group_" + ElanatVariant.DefaultSystem), ElanatVariant.DefaultSystem, true);
    el_SetPagePathFromQueryString();
    el_SetLeftAndRightMenuShowButton();
    el_EventListener();
    
	el_CloseAjaxLoading();
}