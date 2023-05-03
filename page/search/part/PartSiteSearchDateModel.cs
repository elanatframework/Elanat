﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PartSiteSearchDateModel
    {
        public string SearchFromLanguage { get; set; }
        public string SearchUntilLanguage { get; set; }

        public string SearchFromValue { get; set; }
        public string SearchUntilValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/search/");
            SearchFromLanguage = aol.GetAddOnsLanguage("search_from");
            SearchUntilLanguage = aol.GetAddOnsLanguage("search_until");


            // Set From Date Search Item
            SearchFromValue = ElanatConfig.GetNode("date_and_time/site_birthday").InnerText;

            // Set Until Date Search Item
            DataUse.Content duc = new DataUse.Content();
            SearchUntilValue = duc.GetLastContentDateCreate();
        }
    }
}