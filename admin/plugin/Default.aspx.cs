using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminPlugin : System.Web.UI.Page
    {
        public AdminPluginModel model = new AdminPluginModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddPlugin"]))
                btn_AddPlugin_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddPlugin_Click(object sender, EventArgs e)
        {
            model.PluginPathUploadValue = Request.Files["upd_PluginPath"];
            model.UsePluginPathValue = Request.Form["cbx_UsePluginPath"] == "on";
            model.PluginPathTextValue = Request.Form["txt_PluginPath"];
            model.PriorityForPluginValue = Request.Form["cbx_PriorityForPlugin"] == "on";
            model.PluginNameValue = Request.Form["txt_PluginName"];
            model.PluginCategoryValue = Request.Form["txt_PluginCategory"];
            model.PluginLoadTypeOptionListSelectedValue = Request.Form["ddlst_PluginLoadType"];
            model.PluginActiveValue = Request.Form["cbx_PluginActive"] == "on";
            model.PluginUseLanguageValue = Request.Form["cbx_PluginUseLanguage"] == "on";
            model.PluginUsePluginValue = Request.Form["cbx_PluginUsePlugin"] == "on";
            model.PluginUseModuleValue = Request.Form["cbx_PluginUseModule"] == "on";
            model.PluginUseReplacePartValue = Request.Form["cbx_PluginUseReplacePart"] == "on";
            model.PluginUseFetchValue = Request.Form["cbx_PluginUseFetch"] == "on";
            model.PluginUseItemValue = Request.Form["cbx_PluginUseItem"] == "on";
            model.PluginUseElanatValue = Request.Form["cbx_PluginUseElanat"] == "on";
            model.PluginCacheDurationValue = Request.Form["txt_PluginCacheDuration"];
            model.PluginCacheParametersValue = Request.Form["txt_PluginCacheParameters"];
            model.PluginSortIndexValue = Request.Form["txt_PluginSortIndex"];
            model.PluginPublicAccessShowValue = Request.Form["cbx_PluginPublicAccessShow"] == "on";
            model.PluginPublicAccessAddValue = Request.Form["cbx_PluginPublicAccessAdd"] == "on";
            model.PluginPublicAccessDeleteOwnValue = Request.Form["cbx_PluginPublicAccessDeleteOwn"] == "on";
            model.PluginPublicAccessEditOwnValue = Request.Form["cbx_PluginPublicAccessEditOwn"] == "on";
            model.PluginPublicAccessDeleteAllValue = Request.Form["cbx_PluginPublicAccessDeleteAll"] == "on";
            model.PluginPublicAccessEditAllValue = Request.Form["cbx_PluginPublicAccessEditAll"] == "on";

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginMenu$"))
                {
                    ListItem PluginMenu = new ListItem();

                    PluginMenu.Value = Request.Form[name];
                    PluginMenu.Selected = true;

                    model.PluginMenuListItem.Add(PluginMenu);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginAccessShow$"))
                {
                    ListItem PluginAccessShow = new ListItem();

                    PluginAccessShow.Value = Request.Form[name];
                    PluginAccessShow.Selected = true;

                    model.PluginAccessShowListItem.Add(PluginAccessShow);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginAccessAdd$"))
                {
                    ListItem PluginAccessAdd = new ListItem();

                    PluginAccessAdd.Value = Request.Form[name];
                    PluginAccessAdd.Selected = true;

                    model.PluginAccessAddListItem.Add(PluginAccessAdd);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginAccessDeleteOwn$"))
                {
                    ListItem PluginAccessDeleteOwn = new ListItem();

                    PluginAccessDeleteOwn.Value = Request.Form[name];
                    PluginAccessDeleteOwn.Selected = true;

                    model.PluginAccessDeleteOwnListItem.Add(PluginAccessDeleteOwn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginAccessEditOwn$"))
                {
                    ListItem PluginAccessEditOwn = new ListItem();

                    PluginAccessEditOwn.Value = Request.Form[name];
                    PluginAccessEditOwn.Selected = true;

                    model.PluginAccessEditOwnListItem.Add(PluginAccessEditOwn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginAccessDeleteAll$"))
                {
                    ListItem PluginAccessDeleteAll = new ListItem();

                    PluginAccessDeleteAll.Value = Request.Form[name];
                    PluginAccessDeleteAll.Selected = true;

                    model.PluginAccessDeleteAllListItem.Add(PluginAccessDeleteAll);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_PluginAccessEditAll$"))
                {
                    ListItem PluginAccessEditAll = new ListItem();

                    PluginAccessEditAll.Value = Request.Form[name];
                    PluginAccessEditAll.Selected = true;

                    model.PluginAccessEditAllListItem.Add(PluginAccessEditAll);
                }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddPlugin();
        }
    }
}