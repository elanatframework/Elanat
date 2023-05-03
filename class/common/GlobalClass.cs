using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace elanat
{
    public class GlobalClass
    {
        /// <param name="Priority">warning, problem, help, success, none</param>
        public static void Alert(string Text, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Text);
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            System.Web.HttpContext.Current.Response.Write(AlertTemplate);
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static string AlertReturn(string Text, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Text);
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            return AlertTemplate;
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static void AlertWithReplace(string Text, string OldString, string NewString, string Priority = "none")
        {
            Alert(Text.Replace(OldString, NewString), Priority);
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static void AlertStoredLanguageVariant(string Text, string GlobalLanguage, string Priority = "none") 
        {
            System.Web.HttpContext.Current.Response.Write(Template.GetGlobalTemplate("part/alert", GlobalLanguage).Replace("$_asp priority;", Priority).Replace("$_asp alert_text;", Language.GetLanguage(Text, GlobalLanguage)));
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static void AlertAddOnsLanguageVariant(string Text, string GlobalLanguage, string Priority = "none", string Path = null)
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Language.GetAddOnsLanguage(Text, GlobalLanguage, Path));
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            System.Web.HttpContext.Current.Response.Write(AlertTemplate);
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static void AlertLanguageVariant(string Text, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Language.GetLanguage(Text, GlobalLanguage));
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            System.Web.HttpContext.Current.Response.Write(AlertTemplate);
        }

        /// <param name="Priority">warning, problem, help, success, none</param>
        public static void AlertLanguageVariantWithReplace(string Text, string OldString, string NewString, string GlobalLanguage, string Priority = "none")
        {
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);
            AlertTemplate = AlertTemplate.Replace("$_asp alert_text;", Language.GetLanguage(Text, GlobalLanguage).Replace(OldString, NewString));
            AlertTemplate = AlertTemplate.Replace("$_asp priority;", Priority);

            System.Web.HttpContext.Current.Response.Write(AlertTemplate);
        }

        public static void Confirm(string Text, string ClientOnClickFunction)
        {
            System.Web.HttpContext.Current.Response.Write(ElanatConfig.GetNode("part/confirm").InnerText.Replace("$_asp alert_text;", Text));
        }

        public static void ConfirmStoredText(string Text, string ClientOnClickFunction)
        {
            System.Web.HttpContext.Current.Response.Write(ElanatConfig.GetNode("part/confirm").InnerText.Replace("$_asp alert_text;", Language.GetLanguage(Text, StaticObject.GetCurrentAdminGlobalLanguage())));
        }

        public static string GetSitePath()
        {
            string SitePathTemplate = ElanatConfig.GetNode("properties/site_path").InnerText;

            return SitePathTemplate;
        }

        public static string GetSiteMainUrl()
        {
            return HttpContext.Current.Request.Url.Scheme + @"://" + HttpContext.Current.Request.Url.Authority;
        }

        public static List<string> GetSearchedItemList(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);

            XmlNodeList NodeList = doc.SelectNodes("item_view_root/item_search_list/column");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText);

            return list;
        }

        public static string GetSearchedItemListWhereQuery(string Path, string SearchedItem, bool IsAnd = false)
        {
            List<string> ColumnItemList = GetSearchedItemList(Path);

            if (ColumnItemList.Count == 0)
                return "";

            string Where = (IsAnd)? " and (" : "where (";

            foreach (string column in ColumnItemList)
                Where += column + " like '%" + SearchedItem + "%' or ";

            // Remove Last Or
            Where = Where.Remove(Where.Length - 4, 3) + ")";

            return Where;
        }

        public static List<string> GetItemViewList(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNodeList NodeList = doc.SelectNodes("item_view_root/item_view_list/view_table/column");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText);
            
            return list;
        }

        public static List<string> GetItemViewMoreList(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(Path + "App_Data/item_view/item_view.xml"));
            XmlNodeList NodeList = doc.SelectNodes("item_view_root/item_view_list/view_more/column");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText); GlobalClass dc = new GlobalClass();

            return list;
        }
    }
}