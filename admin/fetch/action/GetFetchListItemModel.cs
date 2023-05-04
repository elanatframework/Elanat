using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionGetFetchListItemModel
    {
        public string FetchSqlQueryValue { get; set; }

        public bool SqlQueryUseLanguageValue { get; set; } = false;
        public bool SqlQueryUseModuleValue { get; set; } = false;
        public bool SqlQueryUsePluginValue { get; set; } = false;
        public bool SqlQueryUseReplacePartValue { get; set; } = false;
        public bool SqlQueryUseFetchValue { get; set; } = false;
        public bool SqlQueryUseItemValue { get; set; } = false;
        public bool SqlQueryUseElanatValue { get; set; } = false;

        public ListItemCollection SqlQueryColumnListItem = new ListItemCollection();
        public string SqlQueryColumnListValue { get; set; }
        public string SqlQueryColumnTemplateValue { get; set; }

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

            SqlQueryColumnListItem = new ListItemCollection();

            for (int i = 0; i < dbdr.dr.FieldCount; i++)
            {
                SqlQueryColumnListItem.Add(dbdr.dr.GetName(i));
                SqlQueryColumnListItem[i].Selected = true;
            }

            db.Close();


            // Set Sql Query Column
            HtmlCheckBoxList HtmlCheckBoxListSqlQueryColumn = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/fetch/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_SqlQueryColumn");
            HtmlCheckBoxListSqlQueryColumn.AddRange(SqlQueryColumnListItem);
            SqlQueryColumnTemplateValue = HtmlCheckBoxListSqlQueryColumn.GetValue();
            SqlQueryColumnListValue = HtmlCheckBoxListSqlQueryColumn.GetList();
            SqlQueryColumnTemplateValue = SqlQueryColumnTemplateValue.Replace("$_asp attribute;", "");
            SqlQueryColumnTemplateValue = SqlQueryColumnTemplateValue.Replace("$_asp css_class;", "");
            SqlQueryColumnTemplateValue = SqlQueryColumnTemplateValue.HtmlInputSetCheckBoxListValue(SqlQueryColumnListItem);

            HttpContext.Current.Response.Write(SqlQueryColumnTemplateValue);
        }
    }
}