using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class PluginSiteShowCategoryDropDownListModel
    {
        public void SetValue()
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string SiteId = ccoc.SiteId;

            string DropDownListCategoryBoxTemplate = Template.GetSiteTemplate("view/drop_down_list_category/box");
            string DropDownListCategoryListItemTemplate = Template.GetSiteTemplate("view/drop_down_list_category/list_item");

            string TmpDropDownListCategoryListItemTemplate = "";
            string SumDropDownListCategoryListItemTemplate = "";

            // Set Category Item
            ListClass lc = new ListClass();
            lc.FillCategoryListItemTree(StaticObject.GetCurrentSiteSiteId(), "-");

            foreach (ListItem list in lc.CategoryListItemTree)
            {
                // Set Extra Catgory Url Value
                ExtraValue evc = new ExtraValue();

                evc.SiteGlobalName = list.Text;
                evc.SiteName = StaticObject.GetCurrentSiteSiteId();
                evc.CategoryId = list.Value;

                CategoryClass cc = new CategoryClass();
                evc.ParrentCategory = cc.GetParentCategory(ccoc.SiteSiteGlobalName, list.Value);
                evc.CategoryName = cc.CategoryName;

                TmpDropDownListCategoryListItemTemplate = DropDownListCategoryListItemTemplate;

                TmpDropDownListCategoryListItemTemplate = TmpDropDownListCategoryListItemTemplate.Replace("$_asp category_name;", list.Text);
                TmpDropDownListCategoryListItemTemplate = TmpDropDownListCategoryListItemTemplate.Replace("$_asp category_id;", list.Value);
                TmpDropDownListCategoryListItemTemplate = TmpDropDownListCategoryListItemTemplate.Replace("$_asp extra_category_url_value;", evc.GetCategoryUrlValue());

                SumDropDownListCategoryListItemTemplate += TmpDropDownListCategoryListItemTemplate;
            }

            HttpContext.Current.Response.Write(DropDownListCategoryBoxTemplate.Replace("$_asp item;", SumDropDownListCategoryListItemTemplate));
        }
    }
}