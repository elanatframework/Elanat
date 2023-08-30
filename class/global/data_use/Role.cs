using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Role : IDisposable
    {
        public string RoleId = "";
        public string RoleName = "";
        public string RoleType = "";
        public string RoleActive = "";
        public List<ListItem> RoleBitColumnAccess = new List<ListItem>();

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string RoleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_role", "@role_id", RoleId);
        }

        public void Inactive(string RoleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_role", "@role_id", RoleId);
        }

        public void Delete(string RoleId)
        {
            DataUse.Role dur = new DataUse.Role();
            dur.FillCurrentRole(RoleId);

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_role", "@role_id", RoleId);

            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/role_data/" + dur.RoleName + "/"), true);
        }

        public void Add()
        {
            List<string> ParametersNameList = new List<string>();
            List<string> ParametersValueList = new List<string>();

            ParametersNameList.Add("role_name");
            ParametersValueList.Add("N'" + RoleName + "'");

            ParametersNameList.Add("role_type");
            ParametersValueList.Add("'" + RoleType + "'");

            ParametersNameList.Add("role_active");
            ParametersValueList.Add(RoleActive);

            // Set Role Bit Column Access List Item
            ListClass.Role lcr = new ListClass.Role();
            lcr.FillRoleBitColumnAccessListItem();

            foreach (ListItem li in lcr.RoleBitColumnAccessListItem)
            {
                string RoleBitColumnValue = (RoleBitColumnAccess.FindByValue(li.Value) != null) ? "1" : "0";

                ParametersNameList.Add(li.Value);
                ParametersValueList.Add(RoleBitColumnValue);
            }

            string TmpParametersNameList = string.Join(", ", ParametersNameList.ToArray());
            string TmpParametersValueList = string.Join(", ", ParametersValueList.ToArray());

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_role", new List<string>() { "@column_name", "@column_value" }, new List<string>() { TmpParametersNameList, TmpParametersValueList });

            dbdr.dr.Read();

            RoleId = dbdr.dr["role_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            List<string> ParametersNameList = new List<string>();
            List<string> ParametersValueList = new List<string>();

            ParametersNameList.Add("role_name");
            ParametersValueList.Add("N'" + RoleName + "'");

            ParametersNameList.Add("role_type");
            ParametersValueList.Add("'" + RoleType + "'");

            ParametersNameList.Add("role_active");
            ParametersValueList.Add(RoleActive);

            // Set Role Bit Column Access List Item
            ListClass.Role lcr = new ListClass.Role();
            lcr.FillRoleBitColumnAccessListItem();

            foreach (ListItem li in lcr.RoleBitColumnAccessListItem)
            {
                string RoleBitColumnValue = (RoleBitColumnAccess.FindByValue(li.Value) != null) ? "1" : "0";

                ParametersNameList.Add(li.Value);
                ParametersValueList.Add(RoleBitColumnValue);
            }

            string TmpParametersNameList = string.Join(", ", ParametersNameList.ToArray());
            string TmpParametersValueList = string.Join(", ", ParametersValueList.ToArray());

            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_role", new List<string>() { "@column_name", "@column_value" }, new List<string>() { TmpParametersNameList, TmpParametersValueList });

            ReturnDr.Read();

            RoleId = ReturnDr["role_id"].ToString();
        }

        public void Edit()
        {
            string ParametersNameValueList = "";

            // Set Role Bit Column Access List Item
            ListClass.Role lcr = new ListClass.Role();
            lcr.FillRoleBitColumnAccessListItem();

            foreach (ListItem li in lcr.RoleBitColumnAccessListItem)
            {
                string RoleBitColumnValue = (RoleBitColumnAccess.FindByValue(li.Value) != null) ? "1" : "0";

                ParametersNameValueList += li.Value + " = " + RoleBitColumnValue + ", ";
            }

            ParametersNameValueList += "role_name = N'" + RoleName + "', ";

            ParametersNameValueList += "role_type = '" + RoleType + "', ";

            ParametersNameValueList += "role_active = " + RoleActive;

            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_role", new List<string>() { "@role_id", "@parameters_name_value" }, new List<string>() { RoleId, ParametersNameValueList });
        }

        public void FillCurrentRole(string RoleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_role", "@role_id", RoleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.RoleId = dbdr.dr["role_id"].ToString();
            RoleName = dbdr.dr["role_name"].ToString();
            RoleType = dbdr.dr["role_type"].ToString();
            RoleActive = dbdr.dr["role_active"].ToString().TrueFalseToZeroOne();

            // Set Role Bit Column Access List Item
            ListClass.Role lcr = new ListClass.Role();
            lcr.FillRoleBitColumnAccessListItem();

            foreach (ListItem li in lcr.RoleBitColumnAccessListItem)
            {
                li.Selected = dbdr.dr[li.Value].ToString().TrueFalseToBoolean();
                RoleBitColumnAccess.Add(li);
            }
            

            db.Close();
        }

        public void FillCurrentRoleWithReturnDr(string RoleId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_role", "@role_id", RoleId);

            if (ReturnDr == null || !ReturnDr.HasRows)
            {
                ReturnDb.Close();
                return;
            }

            ReturnDr.Read();
        }

        public string GetColumnValue(string ColumnName)
        {
            switch (ColumnName)
            {
                case "role_id": return RoleId;
                case "role_name": return RoleName;
                case "role_type": return RoleType;
                case "role_active": return RoleActive;
            }

            return RoleBitColumnAccess.FindByValue(ColumnName).Selected.BooleanToZeroOne();
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            RoleId = "";
            RoleName = "";
            RoleType = "";
            RoleActive = "";
            List<ListItem> RoleBitColumnAccess = new List<ListItem>();

            ReturnDr.Close();
        }

        public string GetRoleIdByRoleName(string RoleName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_role_id_by_role_name", "@role_name", RoleName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string RoleId = dbdr.dr["role_id"].ToString();

                db.Close();

                return RoleId;
            }

            db.Close();

            return null;
        }

        public bool RoleActiveCheckByGroupId(string GroupId)
        {
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("role_active_check_by_group_id", "@group_id", GroupId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                bool RoleActive = dbdr.dr["role_active"].ToString().TrueFalseToBoolean();

                db.Close();

                return RoleActive;
            }

            db.Close();

            return false;
        }

        public string GetRoleCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_role", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string RoleCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return RoleCount;
        }

        public string GetRoleName(string RoleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_role_name", "@role_id", RoleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string RoleName = dbdr.dr["role_name"].ToString();

                db.Close();

                return RoleName;
            }

            db.Close();

            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Refresh();
                ReturnDb.Close();
                ReturnDb.Dispose();
            }
        }
    }
}