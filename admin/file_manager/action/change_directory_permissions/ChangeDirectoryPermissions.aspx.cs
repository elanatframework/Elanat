using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionChangeDirectoryPermissions : System.Web.UI.Page
    {
        public ActionChangeDirectoryPermissionsModel model = new ActionChangeDirectoryPermissionsModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveDirectoryPermissions"]))
                btn_SaveDirectoryPermissions_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_DirectoryName"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["directory_path"]))
                    return;

                if (string.IsNullOrEmpty(Request.QueryString["directory_name"]))
                    return;

                model.DirectoryPathValue = Request.QueryString["directory_path"].ToString();

                model.DirectoryNameValue = Request.QueryString["directory_name"].ToString();
            }


            model.SetValue();
        }

        protected void btn_SaveDirectoryPermissions_Click(object sender, EventArgs e)
        {
            model.DirectoryPathValue = Request.Form["hdn_DirectoryPath"];
            model.DirectoryNameValue = Request.Form["hdn_DirectoryName"];
            model.FullControlValue = Request.Form["cbx_FullControl"] == "on";
            model.ReadValue = Request.Form["cbx_Read"] == "on";
            model.WriteValue = Request.Form["cbx_Write"] == "on";
            model.CreateDirectoriesValue = Request.Form["cbx_CreateDirectories"] == "on";
            model.CreateFilesValue = Request.Form["cbx_CreateFiles"] == "on";
            model.ChangePermissionsValue = Request.Form["cbx_ChangePermissions"] == "on";
            model.DeleteValue = Request.Form["cbx_Delete"] == "on";
            model.DeleteSubdirectoriesAndFilesValue = Request.Form["cbx_DeleteSubdirectoriesAndFiles"] == "on";
            model.ListDirectoryValue = Request.Form["cbx_ListDirectory"] == "on";
            model.ModifyValue = Request.Form["cbx_Modify"] == "on";
            model.ReadAttributesValue = Request.Form["cbx_ReadAttributes"] == "on";
            model.ReadExtendedAttributesValue = Request.Form["cbx_ReadExtendedAttributes"] == "on";
            model.ReadPermissionsValue = Request.Form["cbx_ReadPermissions"] == "on";
            model.TakeOwnershipValue = Request.Form["cbx_TakeOwnership"] == "on";
            model.TraverseValue = Request.Form["cbx_Traverse"] == "on";
            model.WriteAttributesValue = Request.Form["cbx_WriteAttributes"] == "on";
            model.WriteExtendedAttributesValue = Request.Form["cbx_WriteExtendedAttributes"] == "on";
            model.SaveDirectoryPermissions();


            model.SaveDirectoryPermissions();

            model.SuccessView();
        }
    }
}