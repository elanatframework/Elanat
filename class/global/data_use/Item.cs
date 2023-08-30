using System.Data.SqlClient;

namespace Elanat.DataUse
{
    public class Item : IDisposable
    {
        public string ItemId = "";
        public string ItemName = "";
        public string ItemValue = "";
        public string ItemCacheDuration = "";
        public string ItemSortIndex = "";
        public string ItemPublicAccessShow = "";
        public string ItemUseBox = "";
        public string ItemUseLanguage = "";
        public string ItemUseModule = "";
        public string ItemUsePlugin = "";
        public string ItemUseReplacePart = "";
        public string ItemUseFetch = "";
        public string ItemUseItem = "";
        public string ItemUseElanat = "";
        public string ItemActive = "";

        public DataBaseSocket ReturnDb;
        public SqlDataReader ReturnDr;

        public void Active(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("active_item", "@item_id", ItemId);
        }

        public void Inactive(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("inactive_item", "@item_id", ItemId);
        }

        public void Delete(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_item", "@item_id", ItemId);
        }

        public void DeleteMenuItem(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_menu_item", "@item_id", ItemId);
        }

        public void DeleteItemAccessShow(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("delete_item_access_show", "@item_id", ItemId);
        }

        public void Add()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("add_item", new List<string>() { "@item_name", "@item_value", "@item_cache_duration", "@item_sort_index", "@item_public_access_show", "@item_use_box", "@item_use_language", "@item_use_module", "@item_use_plugin", "@item_use_replace_part", "@item_use_fetch", "@item_use_item", "@item_use_elanat", "@item_active" }, new List<string>() { ItemName, ItemValue, ItemCacheDuration, ItemSortIndex, ItemPublicAccessShow, ItemUseBox, ItemUseLanguage, ItemUseModule, ItemUsePlugin, ItemUseReplacePart, ItemUseFetch, ItemUseItem, ItemUseElanat, ItemActive });

            dbdr.dr.Read();

            ItemId = dbdr.dr["item_id"].ToString();

            db.Close();
        }

        public void AddWithFillReturnDr()
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("add_item", new List<string>() { "@item_name", "@item_value", "@item_cache_duration", "@item_sort_index", "@item_public_access_show", "@item_use_box", "@item_use_language", "@item_use_module", "@item_use_plugin", "@item_use_replace_part", "@item_use_fetch", "@item_use_item", "@item_use_elanat", "@item_active" }, new List<string>() { ItemName, ItemValue, ItemCacheDuration, ItemSortIndex, ItemPublicAccessShow, ItemUseBox, ItemUseLanguage, ItemUseModule, ItemUsePlugin, ItemUseReplacePart, ItemUseFetch, ItemUseItem, ItemUseElanat, ItemActive });

            ReturnDr.Read();

            ItemId = ReturnDr["item_id"].ToString();
        }

        public void AddMenuItem(string ItemId, List<ListItem> MenuItemListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuItemListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_item", new List<string>() { "@menu_id", "@item_id" }, new List<string>() { item.Value, ItemId });
        }

        // Overload
        public void AddMenuItem(List<ListItem> MenuItemListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in MenuItemListItem)
                if (item.Selected)
                    db.SetProcedure("add_menu_item", new List<string>() { "@menu_id", "@item_id" }, new List<string>() { item.Value, ItemId });
        }

        public void SetItemAccessShow(string ItemId, List<ListItem> ItemAccessShowListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in ItemAccessShowListItem)
                if (item.Selected)
                    db.SetProcedure("set_item_access_show", new List<string>() { "@role_id", "@item_id" }, new List<string>() { item.Value, ItemId });
        }

        // Overload
        public void SetItemAccessShow(List<ListItem> ItemAccessShowListItem)
        {
            DataBaseSocket db = new DataBaseSocket();
            foreach (ListItem item in ItemAccessShowListItem)
                if (item.Selected)
                    db.SetProcedure("set_item_access_show", new List<string>() { "@role_id", "@item_id" }, new List<string>() { item.Value, ItemId });
        }

        public void Edit()
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("edit_item", new List<string>() { "@item_id", "@item_name", "@item_value", "@item_cache_duration", "@item_sort_index", "@item_public_access_show", "@item_use_box", "@item_use_language", "@item_use_module", "@item_use_plugin", "@item_use_replace_part", "@item_use_fetch", "@item_use_item", "@item_use_elanat", "@item_active" }, new List<string>() { ItemId, ItemName, ItemValue, ItemCacheDuration, ItemSortIndex, ItemPublicAccessShow, ItemUseBox, ItemUseLanguage, ItemUseModule, ItemUsePlugin, ItemUseReplacePart, ItemUseFetch, ItemUseItem, ItemUseElanat, ItemActive });
        }

        public void FillCurrentItem(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_item", "@item_id", ItemId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            this.ItemId = dbdr.dr["item_id"].ToString();
            ItemName = dbdr.dr["item_name"].ToString();
            ItemValue = dbdr.dr["item_value"].ToString();
            ItemCacheDuration = dbdr.dr["item_cache_duration"].ToString();
            ItemSortIndex = dbdr.dr["item_sort_index"].ToString();
            ItemPublicAccessShow = dbdr.dr["item_public_access_show"].ToString().TrueFalseToZeroOne();
            ItemUseBox = dbdr.dr["item_use_box"].ToString().TrueFalseToZeroOne();
            ItemUseLanguage = dbdr.dr["item_use_language"].ToString().TrueFalseToZeroOne();
            ItemUseModule = dbdr.dr["item_use_module"].ToString().TrueFalseToZeroOne();
            ItemUsePlugin = dbdr.dr["item_use_plugin"].ToString().TrueFalseToZeroOne();
            ItemUseReplacePart = dbdr.dr["item_use_replace_part"].ToString().TrueFalseToZeroOne();
            ItemUseFetch = dbdr.dr["item_use_fetch"].ToString().TrueFalseToZeroOne();
            ItemUseItem = dbdr.dr["item_use_item"].ToString().TrueFalseToZeroOne();
            ItemUseElanat = dbdr.dr["item_use_elanat"].ToString().TrueFalseToZeroOne();
            ItemActive = dbdr.dr["item_active"].ToString().TrueFalseToZeroOne();

            db.Close();
        }

        public void FillCurrentItemWithReturnDr(string ItemId)
        {
            ReturnDb = new DataBaseSocket();
            ReturnDr = ReturnDb.GetProcedure("get_current_item", "@item_id", ItemId);

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
                case "item_id": return ItemId;
                case "item_name": return ItemName;
                case "item_value": return ItemValue;
                case "item_cache_duration": return ItemCacheDuration;
                case "item_sort_index": return ItemSortIndex;
                case "item_public_access_show": return ItemPublicAccessShow;
                case "item_use_box": return ItemUseBox;
                case "item_use_language": return ItemUseLanguage;
                case "item_use_module": return ItemUseModule;
                case "item_use_plugin": return ItemUsePlugin;
                case "item_use_replace_part": return ItemUseReplacePart;
                case "item_use_fetch": return ItemUseFetch;
                case "item_use_item": return ItemUseItem;
                case "item_use_elanat": return ItemUseElanat;
                case "item_active": return ItemActive;
            }

            return "";
        }

        public string GetReturnDrColumnValue(string ColumnName)
        {
            return ReturnDr[ColumnName].ToString();
        }

        public void Refresh()
        {
            ItemId = "";
            ItemName = "";
            ItemValue = "";
            ItemCacheDuration = "";
            ItemSortIndex = "";
            ItemPublicAccessShow = "";
            ItemUseBox = "";
            ItemUseLanguage = "";
            ItemUseModule = "";
            ItemUsePlugin = "";
            ItemUseReplacePart = "";
            ItemUseFetch = "";
            ItemUseItem = "";
            ItemUseElanat = "";
            ItemActive = "";

            ReturnDr.Close();
        }

        public string GetItemCountByAttach(string InnerAttach = null, string OuterAttach = null)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_item", new List<string>() { "@inner_attach", "@outer_attach" }, new List<string>() { InnerAttach, OuterAttach });

            dbdr.dr.NextResult();

            dbdr.dr.Read();

            string ItemCount = dbdr.dr["row_count"].ToString();

            db.Close();

            return ItemCount;
        }

        public string GetItemName(string ItemId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_item_name", "@item_id", ItemId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ItemName = dbdr.dr["item_name"].ToString();

                db.Close();

                return ItemName;
            }

            db.Close();

            return null;
        }

        public string GetItemIdByItemName(string ItemName)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_item_id_by_item_name", "@item_name", ItemName);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();

                string ItemId = dbdr.dr["item_id"].ToString();

                db.Close();

                return ItemId;
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