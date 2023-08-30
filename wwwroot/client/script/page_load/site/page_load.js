function el_PageLoad()
{
	el_OpenAjaxLoading();

    el_CheckPreviewForResizeWindow();
    el_EventListener();
    el_LoadCaptcha();

	el_CloseAjaxLoading();
}