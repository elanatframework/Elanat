using CodeBehind;

namespace Elanat
{
    public partial class PluginSiteShowCategoryDropDownListModel : CodeBehindModel
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
            ListClass.Category lcc = new ListClass.Category();
            lcc.FillCategoryListItemTree(StaticObject.GetCurrentSiteSiteId(), "-");

            foreach (ListItem list in lcc.CategoryListItemTree)
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

            Write(DropDownListCategoryBoxTemplate.Replace("$_asp item;", SumDropDownListCategoryListItemTemplate));
        }
    }
}