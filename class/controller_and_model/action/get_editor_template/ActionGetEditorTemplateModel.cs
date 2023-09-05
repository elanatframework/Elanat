using CodeBehind;


namespace Elanat
{
    public partial class ActionGetEditorTemplateModel : CodeBehindModel
    {
        public void SetValue(string EditorTemplateId, List<ListItem> QueryString)
        {
            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_editor_template", "@editor_template_id", EditorTemplateId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();


            // Check Active
            if (!dbdr.dr["editor_template_active"].ToString().TrueFalseToBoolean())
                return;


            // Set Cache Key
            string EditorTemplateCacheKey = "";
            foreach (string key in (dbdr.dr["editor_template_cache_parameters"].ToString().Split(',')))
                if (!string.IsNullOrEmpty(QueryString.GetValue(key)))
                    EditorTemplateCacheKey += ":" + QueryString.GetValue(key).ToString();

            // Get Cache
            if (cc.Exist(CacheType, "el_editor_template_" + EditorTemplateId + EditorTemplateCacheKey))
            {
                string TmpEditorTemplateValue = cc.GetValue(CacheType, "el_editor_template_" + EditorTemplateId + EditorTemplateCacheKey);

                Write(TmpEditorTemplateValue);
                return;
            }

            string EditorTemplateValue = "";
            EditorTemplateValue = PageLoader.LoadPath(StaticObject.SitePath + "add_on/editor_template/" + dbdr.dr["editor_template_physical_path"].ToString() + new HttpContextAccessor().HttpContext.Request.QueryString.ToString());


            AttributeReader ar = new AttributeReader();

            if (dbdr.dr["editor_template_use_language"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadLanguage(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());

            if (dbdr.dr["editor_template_use_elanat"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadElanat(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());

            if (dbdr.dr["editor_template_use_plugin"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadPlugin(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());

            if (dbdr.dr["editor_template_use_module"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadModule(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());

            if (dbdr.dr["editor_template_use_fetch"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadFetch(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());

            if (dbdr.dr["editor_template_use_item"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadItem(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());

            if (dbdr.dr["editor_template_use_replace_part"].ToString().TrueFalseToBoolean())
                EditorTemplateValue = ar.ReadReplacePart(EditorTemplateValue, StaticObject.GetCurrentAdminGlobalLanguage());


            Write(EditorTemplateValue);


            // Set Cache
            cc.Insert(CacheType, "el_editor_template_" + EditorTemplateId + EditorTemplateCacheKey, EditorTemplateValue, int.Parse(dbdr.dr["editor_template_cache_duration"].ToString()));


            db.Close();
        }
    }
}