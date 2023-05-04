using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionShowProtectionAttachmentModel
    {
        public void SetValue(string AttachmentId, string AttachmentPassword)
        {
            ContentClass cc = new ContentClass();
            HttpContext.Current.Response.Write(cc.GetCurrentProtectionAttachment(AttachmentId, AttachmentPassword));
        }
    }
}