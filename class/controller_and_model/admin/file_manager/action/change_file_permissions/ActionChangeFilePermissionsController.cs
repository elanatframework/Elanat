using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeFilePermissionsController : CodeBehindController
    {
        public ActionChangeFilePermissionsModel model = new ActionChangeFilePermissionsModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveFilePermissions"]))
            {
                btn_SaveFilePermissions_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_FileName"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["file_path"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (string.IsNullOrEmpty(context.Request.Query["file_name"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.FilePathValue = context.Request.Query["file_path"].ToString();

                model.FileNameValue = context.Request.Query["file_name"].ToString();
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveFilePermissions_Click(HttpContext context)
        {
            model.FilePathValue = context.Request.Form["hdn_FilePath"];
            model.FileNameValue = context.Request.Form["hdn_FileName"];
            model.FullControlValue = context.Request.Form["cbx_FullControl"] == "on";
            model.ReadValue = context.Request.Form["cbx_Read"] == "on";
            model.WriteValue = context.Request.Form["cbx_Write"] == "on";
            model.AppendDataValue = context.Request.Form["cbx_AppendData"] == "on";
            model.ChangePermissionsValue = context.Request.Form["cbx_ChangePermissions"] == "on";
            model.DeleteValue = context.Request.Form["cbx_Delete"] == "on";
            model.ExecuteFileValue = context.Request.Form["cbx_ExecuteFile"] == "on";
            model.ModifyValue = context.Request.Form["cbx_Modify"] == "on";
            model.ReadAndExecuteValue = context.Request.Form["cbx_ReadAndExecute"] == "on";
            model.ReadAttributesValue = context.Request.Form["cbx_ReadAttributes"] == "on";
            model.ReadDataValue = context.Request.Form["cbx_ReadData"] == "on";
            model.ReadExtendedAttributesValue = context.Request.Form["cbx_ReadExtendedAttributes"] == "on";
            model.ReadPermissionsValue = context.Request.Form["cbx_ReadPermissions"] == "on";
            model.TakeOwnershipValue = context.Request.Form["cbx_TakeOwnership"] == "on";
            model.WriteAttributesValue = context.Request.Form["cbx_WriteAttributes"] == "on";
            model.WriteDataValue = context.Request.Form["cbx_WriteData"] == "on";
            model.WriteExtendedAttributesValue = context.Request.Form["cbx_WriteExtendedAttributes"] == "on";


            model.SaveFilePermissions();

            model.SuccessView();

            View(model);
        }
    }
}