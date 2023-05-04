using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditComponent : System.Web.UI.Page
    {
        public ActionEditComponentModel model = new ActionEditComponentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveComponent"]))
                btn_SaveComponent_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ComponentId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["component_id"]))
                    return;

                if (!Request.QueryString["component_id"].ToString().IsNumber())
                    return;

                model.ComponentIdValue = Request.QueryString["component_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveComponent_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.ComponentPathUploadValue = Request.Files["upd_ComponentPath"];
            model.UseComponentPathValue = Request.Form["cbx_UseComponentPath"] == "on";
            model.ComponentPathTextValue = Request.Form["txt_ComponentPath"];
            model.ComponentCategoryValue = Request.Form["txt_ComponentCategory"];
            model.ComponentLoadTypeOptionListSelectedValue = Request.Form["ddlst_ComponentLoadType"];
            model.ComponentActiveValue = Request.Form["cbx_ComponentActive"] == "on";
            model.ComponentUseLanguageValue = Request.Form["cbx_ComponentUseLanguage"] == "on";
            model.ComponentUseModuleValue = Request.Form["cbx_ComponentUseModule"] == "on";
            model.ComponentUsePluginValue = Request.Form["cbx_ComponentUsePlugin"] == "on";
            model.ComponentUseReplacePartValue = Request.Form["cbx_ComponentUseReplacePart"] == "on";
            model.ComponentUseFetchValue = Request.Form["cbx_ComponentUseFetch"] == "on";
            model.ComponentUseItemValue = Request.Form["cbx_ComponentUseItem"] == "on";
            model.ComponentUseElanatValue = Request.Form["cbx_ComponentUseElanat"] == "on";
            model.ComponentCacheDurationValue = Request.Form["txt_ComponentCacheDuration"];
            model.ComponentCacheParametersValue = Request.Form["txt_ComponentCacheParameters"];
            model.ComponentSortIndexValue = Request.Form["txt_ComponentSortIndex"];
            model.ComponentPublicAccessShowValue = Request.Form["cbx_ComponentPublicAccessShow"] == "on";
            model.ComponentPublicAccessAddValue = Request.Form["cbx_ComponentPublicAccessAdd"] == "on";
            model.ComponentPublicAccessDeleteOwnValue = Request.Form["cbx_ComponentPublicAccessDeleteOwn"] == "on";
            model.ComponentPublicAccessEditOwnValue = Request.Form["cbx_ComponentPublicAccessEditOwn"] == "on";
            model.ComponentPublicAccessDeleteAllValue = Request.Form["cbx_ComponentPublicAccessDeleteAll"] == "on";
            model.ComponentPublicAccessEditAllValue = Request.Form["cbx_ComponentPublicAccessEditAll"] == "on";
            model.ComponentIdValue = Request.Form["hdn_ComponentId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ComponentAccessShow$"))
                {
                    ListItem ComponentAccessShow = new ListItem();

                    ComponentAccessShow.Value = Request.Form[name];
                    ComponentAccessShow.Selected = true;

                    model.ComponentAccessShowListItem.Add(ComponentAccessShow);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ComponentAccessAdd$"))
                {
                    ListItem ComponentAccessAdd = new ListItem();

                    ComponentAccessAdd.Value = Request.Form[name];
                    ComponentAccessAdd.Selected = true;

                    model.ComponentAccessAddListItem.Add(ComponentAccessAdd);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ComponentAccessDeleteOwn$"))
                {
                    ListItem ComponentAccessDeleteOwn = new ListItem();

                    ComponentAccessDeleteOwn.Value = Request.Form[name];
                    ComponentAccessDeleteOwn.Selected = true;

                    model.ComponentAccessDeleteOwnListItem.Add(ComponentAccessDeleteOwn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ComponentAccessEditOwn$"))
                {
                    ListItem ComponentAccessEditOwn = new ListItem();

                    ComponentAccessEditOwn.Value = Request.Form[name];
                    ComponentAccessEditOwn.Selected = true;

                    model.ComponentAccessEditOwnListItem.Add(ComponentAccessEditOwn);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ComponentAccessDeleteAll$"))
                {
                    ListItem ComponentAccessDeleteAll = new ListItem();

                    ComponentAccessDeleteAll.Value = Request.Form[name];
                    ComponentAccessDeleteAll.Selected = true;

                    model.ComponentAccessDeleteAllListItem.Add(ComponentAccessDeleteAll);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ComponentAccessEditAll$"))
                {
                    ListItem ComponentAccessEditAll = new ListItem();

                    ComponentAccessEditAll.Value = Request.Form[name];
                    ComponentAccessEditAll.Selected = true;

                    model.ComponentAccessEditAllListItem.Add(ComponentAccessEditAll);
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


            model.SaveComponent();

            model.SuccessView();
        }
    }
}