using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace elanat
{
    public partial class SiteSearch : System.Web.UI.Page
    {
        public SiteSearchModel model = new SiteSearchModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_Search"]))
                btn_Search_Click(sender, e);


            if (!string.IsNullOrEmpty(Request.QueryString["search"]))
                SetQuerySearch();


            model.SetValue(Request.QueryString);
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            if(Request.Form["ddlst_Category"] != null)
                model.CategoryOptionListSelectedValue = Request.Form["ddlst_Category"];

            if (Request.Form["ddlst_TitleOrText"] != null)
                model.TitleOrTextOptionListSelectedValue = Request.Form["ddlst_TitleOrText"];

            if (Request.Form["txt_SearchFrom"] != null)
                model.SearchFromValue = Request.Form["txt_SearchFrom"];

            if (Request.Form["txt_SearchUntil"] != null)
                model.SearchUntilValue = Request.Form["txt_SearchUntil"];

            model.SearchValue = Request.Form["txt_Search"];

            model.Search();
        }

        private void SetQuerySearch()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["category"]))
                model.CategoryOptionListSelectedValue = Request.QueryString["category"].ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["type"]))
                model.TitleOrTextOptionListSelectedValue = Request.QueryString["type"].ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["from_date"]))
                model.SearchFromValue = Request.QueryString["from_date"].ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["until_date"]))
                model.SearchUntilValue = Request.QueryString["until_date"].ToString();

            model.SearchValue = Request.QueryString["search"].ToString();

            model.Search(true);
        }
    }
}