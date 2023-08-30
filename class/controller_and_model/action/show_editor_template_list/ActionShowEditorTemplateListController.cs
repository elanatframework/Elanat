using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionShowEditorTemplateListController : CodeBehindController
    {
        public ActionShowEditorTemplateListModel model = new ActionShowEditorTemplateListModel();

        public void PageLoad(HttpContext context)
        {
            // Editor Template Component Access Check
            DataUse.Component duc = new DataUse.Component();
            string EditorTemplateComponentId = duc.GetComponentIdByComponentName("editor_template");
            duc.FillComponentRoleAccess(EditorTemplateComponentId);

            if (!duc.ComponentAccessShow)
            {
                context.Response.Redirect(StaticObject.SitePath + "page/error/401");

                IgnoreViewAndModel = true;

                return;
            }

            model.SetValue();

            View(model);
        }
    }
}