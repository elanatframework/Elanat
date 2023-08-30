using CodeBehind;

namespace Elanat
{
    public partial class ModuleInformationOptionController : CodeBehindController
    {
        public ModuleInformationOptionModel model = new ModuleInformationOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveInformationOption"]))
            {
                btn_SaveInformationOption_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveInformationOption_Click(HttpContext context)
        {
            model.ActiveFootPrintValue = context.Request.Form["cbx_ActiveFootPrint"] == "on";
            model.ActiveVisitValue = context.Request.Form["cbx_ActiveVisit"] == "on";
            model.ActiveUserValue = context.Request.Form["cbx_ActiveUser"] == "on";
            model.ActiveContactValue = context.Request.Form["cbx_ActiveContact"] == "on";
            model.ActiveCommentValue = context.Request.Form["cbx_ActiveComment"] == "on";
            model.ActiveContentValue = context.Request.Form["cbx_ActiveContent"] == "on";
            model.ActiveActiveContentValue = context.Request.Form["cbx_ActiveActiveContent"] == "on";
            model.ActiveInactiveContentValue = context.Request.Form["cbx_ActiveInactiveContent"] == "on";
            model.ActiveTrashContentValue = context.Request.Form["cbx_ActiveTrashContent"] == "on";
            model.ActiveDraftContentValue = context.Request.Form["cbx_ActiveDraftContent"] == "on";
            model.ActiveDelayContentValue = context.Request.Form["cbx_ActiveDelayContent"] == "on";
            model.ActiveAdminNoteContentValue = context.Request.Form["cbx_ActiveAdminNoteContent"] == "on";
            model.ActiveAttachmentValue = context.Request.Form["cbx_ActiveAttachment"] == "on";
            model.ActiveLogErrorValue = context.Request.Form["cbx_ActiveLogError"] == "on";
            model.ActiveUploadSizeValue = context.Request.Form["cbx_ActiveUploadSize"] == "on";
            model.ActiveTmpSizeValue = context.Request.Form["cbx_ActiveTmpSize"] == "on";

            model.SaveInformationOption();

            View(model);
        }
    }
}