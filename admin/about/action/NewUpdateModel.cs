using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionNewUpdateModel
    {
        public string BreakSupportCheckLanguage { get; set; }
        public string UpdateLanguage { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/");
            UpdateLanguage = aol.GetAddOnsLanguage("update");
            BreakSupportCheckLanguage = aol.GetAddOnsLanguage("break_support_check");
        }
    }
}