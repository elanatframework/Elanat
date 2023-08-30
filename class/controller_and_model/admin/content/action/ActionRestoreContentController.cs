﻿using CodeBehind;

namespace Elanat
{
    public partial class ActionRestoreContentController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["content_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }

            DataUse.Content duc = new DataUse.Content();
            duc.Restore(context.Request.Query["content_id"].ToString());
            Write("true");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("restore_content", context.Request.Query["content_id"].ToString());
        }
    }
}