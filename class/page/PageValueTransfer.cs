using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PageValueTransfer
    {
        public void Delete()
        {
            HttpContext.Current.Session["el_value_transfer:head"] = null;
            HttpContext.Current.Session["el_value_transfer:load_tag"] = null;
        }

        // Head
        public string Head
        {
            get { return (HttpContext.Current.Session["el_value_transfer:head"] != null) ? HttpContext.Current.Session["el_value_transfer:head"].ToString() : null; }
            set { HttpContext.Current.Session.Add("el_value_transfer:head", value); }
        }

        // Load Tag
        public string LoadTag
        {
            get { return (HttpContext.Current.Session["el_value_transfer:load_tag"] != null) ? HttpContext.Current.Session["el_value_transfer:load_tag"].ToString() : null; }
            set { HttpContext.Current.Session.Add("el_value_transfer:load_tag", value); }
        }
    }
}