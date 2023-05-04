using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionEditModule : System.Web.UI.Page
    {
        public ActionEditModuleModel model = new ActionEditModuleModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveModule"]))
                btn_SaveModule_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ModuleId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["module_id"]))
                    return;

                if (!Request.QueryString["module_id"].ToString().IsNumber())
                    return;

                model.ModuleIdValue = Request.QueryString["module_id"].ToString();
            }


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveModule_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.ModuleCategoryValue = Request.Form["txt_ModuleCategory"];
            model.ModuleLoadTypeOptionListSelectedValue = Request.Form["ddlst_ModuleLoadType"];
            model.ModuleActiveValue = Request.Form["cbx_ModuleActive"] == "on";
            model.ModuleUseLanguageValue = Request.Form["cbx_ModuleUseLanguage"] == "on";
            model.ModuleUseModuleValue = Request.Form["cbx_ModuleUseModule"] == "on";
            model.ModuleUsePluginValue = Request.Form["cbx_ModuleUsePlugin"] == "on";
            model.ModuleUseReplacePartValue = Request.Form["cbx_ModuleUseReplacePart"] == "on";
            model.ModuleUseFetchValue = Request.Form["cbx_ModuleUseFetch"] == "on";
            model.ModuleUseItemValue = Request.Form["cbx_ModuleUseItem"] == "on";
            model.ModuleUseElanatValue = Request.Form["cbx_ModuleUseElanat"] == "on";
            model.ModuleCacheDurationValue = Request.Form["txt_ModuleCacheDuration"];
            model.ModuleCacheParametersValue = Request.Form["txt_ModuleCacheParameters"];
            model.ModuleSortIndexValue = Request.Form["txt_ModuleSortIndex"];
            model.ModulePublicAccessShowValue = Request.Form["cbx_ModulePublicAccessShow"] == "on";
            model.ModulePublicAccessAddValue = Request.Form["cbx_ModulePublicAccessAdd"] == "on";
            model.ModulePublicAccessDeleteOwnValue = Request.Form["cbx_ModulePublicAccessDeleteOwn"] == "on";
            model.ModulePublicAccessEditOwnValue = Request.Form["cbx_ModulePublicAccessEditOwn"] == "on";
            model.ModulePublicAccessDeleteAllValue = Request.Form["cbx_ModulePublicAccessDeleteAll"] == "on";
            model.ModulePublicAccessEditAllValue = Request.Form["cbx_ModulePublicAccessEditAll"] == "on";
            model.ModuleIdValue = Request.Form["hdn_ModuleId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleMenu$"))
                {
                    ListItem ModuleMenu = new ListItem();

                    ModuleMenu.Value = Request.Form[name];
                    ModuleMenu.Selected = true;

                    model.ModuleMenuListItem.Add(ModuleMenu);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleAccessShow$"))
                {
                    ListItem ModuleAccessShow = new ListItem();

                    ModuleAccessShow.Value = Request.Form[name];
                    ModuleAccessShow.Selected = true;

                    model.ModuleAccessShowListItem.Add(ModuleAccessShow);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleAccessAdd$"))
                {
                    ListItem ModuleAccessAdd = new ListItem();

                    ModuleAccessAdd.Value = Request.Form[name];
                    ModuleAccessAdd.Selected = true;

                    model.ModuleAccessAddListItem.Add(ModuleAccessAdd);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleAccessDeleteOwn$"))
                {
                    ListItem ModuleAccessDeleteOwn = new ListItem();

                    ModuleAccessDeleteOwn.Value = Request.Form[name];
                    ModuleAccessDeleteOwn.Selected = true;

                    model.ModuleAccessDeleteOwnListItem.Add(ModuleAccessDeleteOwn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleAccessEditOwn$"))
                {
                    ListItem ModuleAccessEditOwn = new ListItem();

                    ModuleAccessEditOwn.Value = Request.Form[name];
                    ModuleAccessEditOwn.Selected = true;

                    model.ModuleAccessEditOwnListItem.Add(ModuleAccessEditOwn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleAccessDeleteAll$"))
                {
                    ListItem ModuleAccessDeleteAll = new ListItem();

                    ModuleAccessDeleteAll.Value = Request.Form[name];
                    ModuleAccessDeleteAll.Selected = true;

                    model.ModuleAccessDeleteAllListItem.Add(ModuleAccessDeleteAll);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ModuleAccessEditAll$"))
                {
                    ListItem ModuleAccessEditAll = new ListItem();

                    ModuleAccessEditAll.Value = Request.Form[name];
                    ModuleAccessEditAll.Selected = true;

                    model.ModuleAccessEditAllListItem.Add(ModuleAccessEditAll);
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


            model.SaveModule();

            model.SuccessView();
        }
    }
}