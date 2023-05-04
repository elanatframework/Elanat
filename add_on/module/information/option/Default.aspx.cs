using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleInformationOption : System.Web.UI.Page
    {
        public ModuleInformationOptionModel model = new ModuleInformationOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveInformationOption"]))
                btn_SaveInformationOption_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveInformationOption_Click(object sender, EventArgs e)
        {
            model.ActiveFootPrintValue = Request.Form["cbx_ActiveFootPrint"] == "on";
            model.ActiveVisitValue = Request.Form["cbx_ActiveVisit"] == "on";
            model.ActiveUserValue = Request.Form["cbx_ActiveUser"] == "on";
            model.ActiveContactValue = Request.Form["cbx_ActiveContact"] == "on";
            model.ActiveCommentValue = Request.Form["cbx_ActiveComment"] == "on";
            model.ActiveContentValue = Request.Form["cbx_ActiveContent"] == "on";
            model.ActiveActiveContentValue = Request.Form["cbx_ActiveActiveContent"] == "on";
            model.ActiveInactiveContentValue = Request.Form["cbx_ActiveInactiveContent"] == "on";
            model.ActiveTrashContentValue = Request.Form["cbx_ActiveTrashContent"] == "on";
            model.ActiveDraftContentValue = Request.Form["cbx_ActiveDraftContent"] == "on";
            model.ActiveDelayContentValue = Request.Form["cbx_ActiveDelayContent"] == "on";
            model.ActiveAdminNoteContentValue = Request.Form["cbx_ActiveAdminNoteContent"] == "on";
            model.ActiveAttachmentValue = Request.Form["cbx_ActiveAttachment"] == "on";
            model.ActiveLogErrorValue = Request.Form["cbx_ActiveLogError"] == "on";
            model.ActiveUploadSizeValue = Request.Form["cbx_ActiveUploadSize"] == "on";
            model.ActiveTmpSizeValue = Request.Form["cbx_ActiveTmpSize"] == "on";
            model.SaveInformationOption();
        }
    }
}