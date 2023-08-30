﻿using CodeBehind;

namespace Elanat
{
    public partial class SiteContentReplyRealLastNameController : CodeBehindController
    {
        public SiteContentReplyRealLastNameModel model = new SiteContentReplyRealLastNameModel();

        public void PageLoad(HttpContext context)
        {
            model.RealLastNameValue = context.Request.Query["real_last_name_value"];
            model.RealLastNameCssClass = context.Request.Query["real_last_name_css_class"];
            model.RealLastNameAttribute = context.Request.Query["real_last_name_attribute"];


            model.SetValue();


            model.SetImportantField();

            View(model);
        }
    }
}