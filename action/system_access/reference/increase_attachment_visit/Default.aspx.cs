using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionIncreaseAttachmentVisit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["path"]))
                return;

            string Path = Request.QueryString["path"].ToString();

            Path = Path.GetTextAfterValue("/upload/attachment/");

            if (string.IsNullOrEmpty(Path))
                return;

            string AttachmentDirectoryPath = Path.GetTextBeforeLastValue("/");

            string AttachmentPhysicalName = Path.GetTextAfterLastValue("/");

            DataUse.Attachment dua = new DataUse.Attachment();

            string AttachmentId = dua.GetAttachmentIdByAttachmentPhysicalPath(AttachmentDirectoryPath, AttachmentPhysicalName);

            if (string.IsNullOrEmpty(AttachmentId))
                return;

            dua.IncreaseVisit(AttachmentId);
        }
    }
}