using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeDirectoryPermissionsController : CodeBehindController
    {
        public ActionChangeDirectoryPermissionsModel model = new ActionChangeDirectoryPermissionsModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveDirectoryPermissions"]))
            {
                btn_SaveDirectoryPermissions_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_DirectoryName"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["directory_path"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (string.IsNullOrEmpty(context.Request.Query["directory_name"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.DirectoryPathValue = context.Request.Query["directory_path"].ToString();

                model.DirectoryNameValue = context.Request.Query["directory_name"].ToString();
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveDirectoryPermissions_Click(HttpContext context)
        {
            model.DirectoryPathValue = context.Request.Form["hdn_DirectoryPath"];
            model.DirectoryNameValue = context.Request.Form["hdn_DirectoryName"];
            model.FullControlValue = context.Request.Form["cbx_FullControl"] == "on";
            model.ReadValue = context.Request.Form["cbx_Read"] == "on";
            model.WriteValue = context.Request.Form["cbx_Write"] == "on";
            model.CreateDirectoriesValue = context.Request.Form["cbx_CreateDirectories"] == "on";
            model.CreateFilesValue = context.Request.Form["cbx_CreateFiles"] == "on";
            model.ChangePermissionsValue = context.Request.Form["cbx_ChangePermissions"] == "on";
            model.DeleteValue = context.Request.Form["cbx_Delete"] == "on";
            model.DeleteSubdirectoriesAndFilesValue = context.Request.Form["cbx_DeleteSubdirectoriesAndFiles"] == "on";
            model.ListDirectoryValue = context.Request.Form["cbx_ListDirectory"] == "on";
            model.ModifyValue = context.Request.Form["cbx_Modify"] == "on";
            model.ReadAttributesValue = context.Request.Form["cbx_ReadAttributes"] == "on";
            model.ReadExtendedAttributesValue = context.Request.Form["cbx_ReadExtendedAttributes"] == "on";
            model.ReadPermissionsValue = context.Request.Form["cbx_ReadPermissions"] == "on";
            model.TakeOwnershipValue = context.Request.Form["cbx_TakeOwnership"] == "on";
            model.TraverseValue = context.Request.Form["cbx_Traverse"] == "on";
            model.WriteAttributesValue = context.Request.Form["cbx_WriteAttributes"] == "on";
            model.WriteExtendedAttributesValue = context.Request.Form["cbx_WriteExtendedAttributes"] == "on";


            model.SaveDirectoryPermissions();

            model.SuccessView();

            View(model);
        }
    }
}