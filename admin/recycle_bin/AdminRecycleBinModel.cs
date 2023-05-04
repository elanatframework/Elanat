using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminRecycleBinModel
    {
        public string ContentLanguage { get; set; }
        public string RecycleBinLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/recycle_bin/");
            RecycleBinLanguage = aol.GetAddOnsLanguage("recycle_bin");
            ContentLanguage = aol.GetAddOnsLanguage("content");


            // Set Recycle Bin Page List
            ActionGetTrashContentListModel lm = new ActionGetTrashContentListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }
    }
}