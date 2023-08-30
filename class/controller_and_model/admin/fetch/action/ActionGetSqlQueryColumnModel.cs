using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetSqlQueryColumnModel : CodeBehindModel
    {
        public string FetchSqlQueryValue { get; set; }

        public bool SqlQueryUseLanguageValue { get; set; } = false;
        public bool SqlQueryUseModuleValue { get; set; } = false;
        public bool SqlQueryUsePluginValue { get; set; } = false;
        public bool SqlQueryUseReplacePartValue { get; set; } = false;
        public bool SqlQueryUseFetchValue { get; set; } = false;
        public bool SqlQueryUseItemValue { get; set; } = false;
        public bool SqlQueryUseElanatValue { get; set; } = false;

        public string FetchListItemValue { get; set; }

        public void SetValue()
        {
            AttributeReader ar = new AttributeReader();
            string SqlQuery = FetchSqlQueryValue;

            if (SqlQueryUseLanguageValue)
                SqlQuery = ar.ReadLanguage(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseModuleValue)
                SqlQuery = ar.ReadModule(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUsePluginValue)
                SqlQuery = ar.ReadPlugin(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseReplacePartValue)
                SqlQuery = ar.ReadReplacePart(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseFetchValue)
                SqlQuery = ar.ReadFetch(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseItemValue)
                SqlQuery = ar.ReadItem(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (SqlQueryUseElanatValue)
                SqlQuery = ar.ReadElanat(SqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetCommand(SqlQuery);

            XmlDocument FetchDocument = new XmlDocument();
            FetchDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/fetch/fetch.xml"));

            string ListItemTemplate = FetchDocument.SelectSingleNode("fetch_root/list_item").InnerText;
            string SumSqlQueryColumn = "";

            for (int i = 0; i < dbdr.dr.FieldCount; i++)
                SumSqlQueryColumn += "$_db " + dbdr.dr.GetName(i) + ";";

            db.Close();

            FetchListItemValue = ListItemTemplate.Replace("$_asp item;", SumSqlQueryColumn);
        }
    }
}