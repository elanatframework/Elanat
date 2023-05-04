using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionGetExtraHelperModel
    {
        public void SetValue(string ExtraHelperId, NameValueCollection QueryString)
        {
            // Set Name Value
            NameValueCollection QueryStringCollection = new NameValueCollection();

            foreach (string NameValue in QueryString)
                QueryStringCollection.Add(NameValue, QueryString[NameValue].ToString());


            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_extra_helper", "@extra_helper_id", ExtraHelperId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();


            // Check Active
            if (!dbdr.dr["extra_helper_active"].ToString().TrueFalseToBoolean())
                return;


            // Set Cache Key
            string ExtraHelperCacheKey = "";
            foreach (string key in (dbdr.dr["extra_helper_cache_parameters"].ToString().Split(',')))
                if (!string.IsNullOrEmpty(QueryStringCollection[key]))
                    ExtraHelperCacheKey += ":" + QueryStringCollection[key].ToString();

            // Get Cache
            if (cc.Exist(CacheType, "el_extra_helper_" + ExtraHelperId + ExtraHelperCacheKey))
            {
                string TmpExtraHelperValue = cc.GetValue(CacheType, "el_extra_helper_" + ExtraHelperId + ExtraHelperCacheKey);

                HttpContext.Current.Response.Write(TmpExtraHelperValue);
                return;
            }


            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/extra_helper/" + dbdr.dr["extra_helper_directory_path"].ToString() + "/catalog.xml"));

            string ExtraHelperValue = "";
            string ExtraHelperLoadType = CatalogDocument.SelectSingleNode("extra_helper_catalog_root/extra_helper_load_type").Attributes["value"].Value;
            ExtraHelperValue = PageLoader.LoadPage(ExtraHelperLoadType, StaticObject.SitePath + "add_on/extra_helper/" + dbdr.dr["extra_helper_physical_path"].ToString() + "?" + QueryString.ToString());


            if (ExtraHelperLoadType != "iframe" && ExtraHelperLoadType != "ajax")
            {
                AttributeReader ar = new AttributeReader();

                if (dbdr.dr["extra_helper_use_language"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadLanguage(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());

                if (dbdr.dr["extra_helper_use_elanat"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadElanat(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());

                if (dbdr.dr["extra_helper_use_plugin"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadPlugin(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());

                if (dbdr.dr["extra_helper_use_module"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadModule(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());

                if (dbdr.dr["extra_helper_use_fetch"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadFetch(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());

                if (dbdr.dr["extra_helper_use_item"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadItem(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());

                if (dbdr.dr["extra_helper_use_replace_part"].ToString().TrueFalseToBoolean())
                    ExtraHelperValue = ar.ReadReplacePart(ExtraHelperValue, StaticObject.GetCurrentAdminGlobalLanguage());


                // Set Cache
                cc.Insert(CacheType, "el_extra_helper_" + ExtraHelperId + ExtraHelperCacheKey, ExtraHelperValue, int.Parse(dbdr.dr["extra_helper_cache_duration"].ToString()));
            }

            db.Close();

            HttpContext.Current.Response.Write(ExtraHelperValue);
        }
    }
}