using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionChangeFilePermissions : System.Web.UI.Page
    {
        public ActionChangeFilePermissionsModel model = new ActionChangeFilePermissionsModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveFilePermissions"]))
                btn_SaveFilePermissions_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_FileName"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["file_path"]))
                    return;

                if (string.IsNullOrEmpty(Request.QueryString["file_name"]))
                    return;

                model.FilePathValue = Request.QueryString["file_path"].ToString();

                model.FileNameValue = Request.QueryString["file_name"].ToString();
            }


            model.SetValue();
        }

        protected void btn_SaveFilePermissions_Click(object sender, EventArgs e)
        {
            model.FilePathValue = Request.Form["hdn_FilePath"];
            model.FileNameValue = Request.Form["hdn_FileName"];
            model.FullControlValue = Request.Form["cbx_FullControl"] == "on";
            model.ReadValue = Request.Form["cbx_Read"] == "on";
            model.WriteValue = Request.Form["cbx_Write"] == "on";
            model.AppendDataValue = Request.Form["cbx_AppendData"] == "on";
            model.ChangePermissionsValue = Request.Form["cbx_ChangePermissions"] == "on";
            model.DeleteValue = Request.Form["cbx_Delete"] == "on";
            model.ExecuteFileValue = Request.Form["cbx_ExecuteFile"] == "on";
            model.ModifyValue = Request.Form["cbx_Modify"] == "on";
            model.ReadAndExecuteValue = Request.Form["cbx_ReadAndExecute"] == "on";
            model.ReadAttributesValue = Request.Form["cbx_ReadAttributes"] == "on";
            model.ReadDataValue = Request.Form["cbx_ReadData"] == "on";
            model.ReadExtendedAttributesValue = Request.Form["cbx_ReadExtendedAttributes"] == "on";
            model.ReadPermissionsValue = Request.Form["cbx_ReadPermissions"] == "on";
            model.TakeOwnershipValue = Request.Form["cbx_TakeOwnership"] == "on";
            model.WriteAttributesValue = Request.Form["cbx_WriteAttributes"] == "on";
            model.WriteDataValue = Request.Form["cbx_WriteData"] == "on";
            model.WriteExtendedAttributesValue = Request.Form["cbx_WriteExtendedAttributes"] == "on";
            model.SaveFilePermissions();


            model.SaveFilePermissions();

            model.SuccessView();
        }
    }
}