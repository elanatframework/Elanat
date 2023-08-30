using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Group : IDisposable
    {
        public string GroupId = "";
        public string GroupName = "";
        public string GroupActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_group", "@group_id", GroupId);
        }

        public void Inactive(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_group", "@group_id", GroupId);
        }

        public void Delete(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_group", "@group_id", GroupId);
        }

        public void DeleteRoleGroup(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_role_group", "@group_id", GroupId);
        }

        public void DeleteFootPrint(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_group_foot_print", "@group_id", GroupId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_group", new List<string>() { "@group_name", "@group_active" }, new List<string>() { GroupName, GroupActive });

            dbdr.dr.Read();

            GroupId = dbdr.dr["group_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_group", new List<string>() { "@group_name", "@group_active" }, new List<string>() { GroupName, GroupActive });

            ReturnDr.Read();

            GroupId = ReturnDr["group_id"].ToString();
        }

        public void AddRoleGroup(string GroupId, List<ListItem> RoleGroupListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem group in RoleGroupListItem)
                if (group.Selected)
                    db.SetProcedure("add_role_group", new List<string>() { "@role_id", "@group_id" }, new List<string>() { group.Value, GroupId });
        }

        // Overload
        public void AddRoleGroup(List<ListItem> RoleGroupListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem group in RoleGroupListItem)
                if (group.Selected)
                    db.SetProcedure("add_role_group", new List<string>() { "@role_id", "@group_id" }, new List<string>() { group.Value, GroupId });
        }

        public void SetGroupRole(string GroupId, List<ListItem> GroupAccessShowListGroup)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in GroupAccessShowListGroup)
                if (item.Selected)
                    db.SetProcedure("set_group_role", new List<string>() { "@group_id", "@role_id" }, new List<string>() { GroupId, item.Value });
        }

        // Overload
        public void SetGroupRole(List<ListItem> GroupAccessShowListGroup)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in GroupAccessShowListGroup)
                if (item.Selected)
                    db.SetProcedure("set_group_role", new List<string>() { "@group_id", "@role_id" }, new List<string>() { GroupId, item.Value });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_group", new List<string>() { "@group_id", "@group_name", "@group_active" }, new List<string>() { GroupId, GroupName, GroupActive });
        }

        public void FillCurrentGroup(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_group", "@group_id", GroupId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.GroupId = dbdr.dr["group_id"].ToString();
            GroupName = dbdr.dr["group_name"].ToString();
            GroupActive = dbdr.dr["group_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentGroupWithReturnDr(string GroupId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_group", "@group_id", GroupId);

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
                case "group_id": return GroupId;
                case "group_name": return GroupName;
                case "group_active": return GroupActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            GroupId = "";
            GroupName = "";
            GroupActive = "";

            ReturnDr.Close();
        }

        public string GetGroupIdByGroupName(string GroupName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_group_id_by_group_name", new List<string>() { "@group_name" }, new List<string>() { GroupName }, false);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string GroupId = dbdr.dr["group_id"].ToString();

                db.Close();

                return GroupId;
            }

            db.Close();

            return null;
        }

        public string GetDominantRoleType(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_dominant_role_type", "@group_id", GroupId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string DominantRoleType = dbdr.dr["dominant_role_type"].ToString();

            db.Close();

            return DominantRoleType;
        }

        public List<ListItem> RoleBitColumnAccess = new List<ListItem>();
        public void FillCurrentAggregationRole(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_role_aggregation", "@group_id", GroupId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }


            // Set Role Bit Column Access List Item
            ListClass.Role lcr = new ListClass.Role();
            lcr.FillRoleBitColumnAccessWithoutLanguageListItem();

            while (dbdr.dr.Read())
                foreach (ListItem li in lcr.RoleBitColumnAccessWithoutLanguageListItem)
                {
                    if (RoleBitColumnAccess.GetValue(li.Value) == null)
                        RoleBitColumnAccess.Add(li.Value, dbdr.dr[li.Value].ToString().TrueFalseToZeroOne());
                    else
                    {
                        if (RoleBitColumnAccess.GetValue(li.Value) ==  dbdr.dr[li.Value].ToString().TrueFalseToZeroOne())
                            continue;

                        RoleBitColumnAccess.ReplaceValue(li.Value, "2");
                    }
                }

            db.Close();
        }

        /// <returns>Return Three Value. Resault : If All Role Bit Aggregation Column Be True, Return 1; If All Role Bit Aggregation Column Be False, Return 0; If Role Bit Aggregation Column Be Difference Between True And False, Return 2;</returns>
        public string GetRoleBitColumnValue(string ColumnName)
        {
            return RoleBitColumnAccess.GetValue(ColumnName);
        }

        public List<ListItem> GetRoleIdAndNameByGroupId(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_role_id_and_name_by_group_id", new List<string>() { "@group_id" }, new List<string>() { GroupId } , false);

            List<ListItem> NameValue = new List<ListItem>();

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                    NameValue.Add(dbdr.dr["role_name"].ToString(), dbdr.dr["role_id"].ToString());

            db.Close();

            return NameValue;
        }

        public bool GroupActiveCheck(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("group_active_check", "@group_id", GroupId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                bool GroupActive = dbdr.dr["group_active"].ToString().TrueFalseToBoolean();

                db.Close();

                return GroupActive;
            }

            db.Close();

            return false;
        }

        public string GetGroupCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_group", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string GroupCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return GroupCount;
        }

        public string GetGroupName(string GroupId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_group_name", "@group_id", GroupId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string GroupName = dbdr.dr["group_name"].ToString();

                db.Close();

                return GroupName;
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