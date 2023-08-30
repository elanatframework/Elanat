using CodeBehind;

namespace Elanat
{
    public partial class AdminPatchController : CodeBehindController
    {
        public AdminPatchModel model = new AdminPatchModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddPatch"]))
            {
                btn_AddPatch_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());

            View(model);
        }

        protected void btn_AddPatch_Click(HttpContext context)
        {
            model.PatchPathUploadValue = context.Request.Form.Files["upd_PatchPath"];
            model.UsePatchPathValue = context.Request.Form["cbx_UsePatchPath"] == "on";
            model.PatchPathTextValue = context.Request.Form["txt_PatchPath"];
            model.PatchActiveValue = context.Request.Form["cbx_PatchActive"] == "on";


            model.AddPatch();

            View(model);
        }
    }
}