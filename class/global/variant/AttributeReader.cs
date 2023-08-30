using Microsoft.Extensions.Caching.Memory;
using System.Xml;

namespace Elanat
{
    public class AttributeReader
    {

        public string ReadAllAttribute(XmlNode node, string GlobalLanguage)
        {
            return node.InnerTextAfterSetNodeVariant(GlobalLanguage);
        }

        public string GetModule(string ModuleIdVariant, string GlobalLanguage)
        {
            string QueryString = "";
            string ModuleId = "";

            if (ModuleIdVariant.ToString().Contains("{"))
            {
                ModuleId = ModuleIdVariant.Substring(0, ModuleIdVariant.IndexOf("{"));
                QueryString += "?" + ModuleIdVariant.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
            }
            else
                ModuleId = ModuleIdVariant;

            DataUse.Module dum = new DataUse.Module();

            if (!ModuleId.IsNumber())
                ModuleId = dum.GetModuleIdByModuleName(ModuleId);


            // Set Name Value
            List<ListItem> QueryStringCollection = new List<ListItem>();

            if (!string.IsNullOrEmpty(QueryString))
            {
                string TmpQueryString = QueryString.GetTextAfterValue("?");

                if (!string.IsNullOrEmpty(TmpQueryString))
                    foreach (string NameValue in TmpQueryString.Split('&'))
                        if (NameValue.Contains("="))
                            QueryStringCollection.Add(NameValue.GetTextBeforeValue("="), NameValue.GetTextAfterValue("="));
            }

            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_module", "@module_id", ModuleId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();


                // Check Active
                if (!dbdr.dr["module_active"].ToString().TrueFalseToBoolean())
                    return "";


                // Set Cache Key
                string ModuleCacheKey = "";
                foreach (string key in (dbdr.dr["module_cache_parameters"].ToString().Split(',')))
                    if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                        ModuleCacheKey += ":" + QueryStringCollection.GetValue(key);

                // Get Cache
                if (cc.Exist(CacheType, "el_module_" + ModuleId + ModuleCacheKey))
                {
                    // Set Module Value Transfer
                    dum.SetModuleValueTransfer(dbdr.dr["module_directory_path"].ToString(), ModuleCacheKey, int.Parse(dbdr.dr["module_cache_duration"].ToString()));


                    string TmpModuleValue = cc.GetValue(CacheType, "el_module_" + ModuleId + ModuleCacheKey);
                    return TmpModuleValue;
                }


                // Set Variant Note
                string StartVariantNote = "";
                string EndVariantNote = "";
                if (StaticObject.AddModuleVariantNote)
                {
                    StartVariantNote = Template.GetGlobalTemplate("variant_note/module/start", GlobalLanguage).Replace("$_asp module_id;", ModuleId);
                    EndVariantNote = Template.GetGlobalTemplate("variant_note/module/end", GlobalLanguage).Replace("$_asp module_id;", ModuleId);
                }


                string ItemValue = PageLoader.LoadPage(dbdr.dr["module_load_type"].ToString(), StaticObject.SitePath + "add_on/module/" + dbdr.dr["module_physical_path"].ToString() + QueryString);


                if (dbdr.dr["module_load_type"].ToString() != "iframe" && dbdr.dr["module_load_type"].ToString() != "ajax")
                {
                    if (dbdr.dr["module_use_elanat"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadElanat(ItemValue, GlobalLanguage);

                    if (dbdr.dr["module_use_language"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadLanguage(ItemValue, GlobalLanguage);

                    if (dbdr.dr["module_use_plugin"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadPlugin(ItemValue, GlobalLanguage);

                    if (dbdr.dr["module_use_module"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadModule(ItemValue, GlobalLanguage);

                    if (dbdr.dr["module_use_fetch"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadFetch(ItemValue, GlobalLanguage);

                    if (dbdr.dr["module_use_item"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadItem(ItemValue, GlobalLanguage);

                    if (dbdr.dr["module_use_replace_part"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadReplacePart(ItemValue, GlobalLanguage);


                    // Set Module Value Transfer
                    dum.SetModuleValueTransfer(dbdr.dr["module_directory_path"].ToString(), ModuleCacheKey, int.Parse(dbdr.dr["module_cache_duration"].ToString()));


                    // Set Cache
                    cc.Insert(CacheType, "el_module_" + ModuleId + ModuleCacheKey, StartVariantNote + ItemValue + EndVariantNote, int.Parse(dbdr.dr["module_cache_duration"].ToString()));
                }

                db.Close();

                return StartVariantNote + ItemValue + EndVariantNote;
            }
            else
            {
                db.Close();

                new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("module_asp_is_not_existed", GlobalLanguage).Replace("$_asp module_id;", ModuleIdVariant), GlobalLanguage, "problem"));
                return "";
            }
        }

        public string ReadModule(string Content, string GlobalLanguage)
        {
            while (Content.Contains("$_module_id "))
            {
                string Variable = Content.Split(new string[] { "$_module_id " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_module_id " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_module_id " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_module_id " + Variable + ";", GetModule(Variable, GlobalLanguage));
            }

            while (Content.Contains("$_module_name "))
            {
                string Variable = Content.Split(new string[] { "$_module_name " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_module_name " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_module_name " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_module_name " + Variable + ";", GetModule(Variable, GlobalLanguage));
            }

            return Content;
        }

        public string GetPlugin(string PluginIdVariant, string GlobalLanguage)
        {
            string QueryString = "";
            string PluginId = "";

            if (PluginIdVariant.ToString().Contains("{"))
            {
                PluginId = PluginIdVariant.Substring(0, PluginIdVariant.IndexOf("{"));
                QueryString += "?" + PluginIdVariant.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
            }
            else
                PluginId = PluginIdVariant;

            DataUse.Plugin dup = new DataUse.Plugin();

            if (!PluginId.IsNumber())
                PluginId = dup.GetPluginIdByPluginName(PluginId);


            // Set Name Value
            List<ListItem> QueryStringCollection = new List<ListItem>();

            if (!string.IsNullOrEmpty(QueryString))
            {
                string TmpQueryString = QueryString.GetTextAfterValue("?");

                if (!string.IsNullOrEmpty(TmpQueryString))
                    foreach (string NameValue in TmpQueryString.Split('&'))
                        if (NameValue.Contains("="))
                            QueryStringCollection.Add(NameValue.GetTextBeforeValue("="), NameValue.GetTextAfterValue("="));
            }

            // Set Cache Type
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_plugin", "@plugin_id", PluginId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();


                // Check Active
                if (!dbdr.dr["plugin_active"].ToString().TrueFalseToBoolean())
                    return "";


                // Set Cache Key
                string PluginCacheKey = "";
                foreach (string key in (dbdr.dr["plugin_cache_parameters"].ToString().Split(',')))
                    if (!string.IsNullOrEmpty(QueryStringCollection.GetValue(key)))
                        PluginCacheKey += ":" + QueryStringCollection.GetValue(key);

                // Get Cache
                if (cc.Exist(CacheType, "el_plugin_" + PluginId + PluginCacheKey))
                {
                    // Set Plugin Value Transfer
                    dup.SetPluginValueTransfer(dbdr.dr["plugin_directory_path"].ToString(), PluginCacheKey, int.Parse(dbdr.dr["plugin_cache_duration"].ToString()));


                    string TmpPluginValue = cc.GetValue(CacheType, "el_plugin_" + PluginId + PluginCacheKey);
                    return TmpPluginValue;
                }


                // Set Variant Note
                string StartVariantNote = "";
                string EndVariantNote = "";
                if (StaticObject.AddPluginVariantNote)
                {
                    StartVariantNote = Template.GetGlobalTemplate("variant_note/plugin/start", GlobalLanguage).Replace("$_asp plugin_id;", PluginId);
                    EndVariantNote = Template.GetGlobalTemplate("variant_note/plugin/end", GlobalLanguage).Replace("$_asp plugin_id;", PluginId);
                }


                string ItemValue = PageLoader.LoadPage(dbdr.dr["plugin_load_type"].ToString(), StaticObject.SitePath + "add_on/plugin/" + dbdr.dr["plugin_physical_path"].ToString() + QueryString);


                if (dbdr.dr["plugin_load_type"].ToString() != "iframe" && dbdr.dr["plugin_load_type"].ToString() != "ajax")
                {
                    if (dbdr.dr["plugin_use_elanat"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadElanat(ItemValue, GlobalLanguage);

                    if (dbdr.dr["plugin_use_language"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadLanguage(ItemValue, GlobalLanguage);

                    if (dbdr.dr["plugin_use_plugin"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadPlugin(ItemValue, GlobalLanguage);

                    if (dbdr.dr["plugin_use_module"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadModule(ItemValue, GlobalLanguage);

                    if (dbdr.dr["plugin_use_fetch"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadFetch(ItemValue, GlobalLanguage);

                    if (dbdr.dr["plugin_use_item"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadItem(ItemValue, GlobalLanguage);

                    if (dbdr.dr["plugin_use_replace_part"].ToString().TrueFalseToBoolean())
                        ItemValue = ReadReplacePart(ItemValue, GlobalLanguage);


                    // Set Plugin Value Transfer
                    dup.SetPluginValueTransfer(dbdr.dr["plugin_directory_path"].ToString(), PluginCacheKey, int.Parse(dbdr.dr["plugin_cache_duration"].ToString()));


                    // Set Cache
                    cc.Insert(CacheType, "el_plugin_" + PluginId + PluginCacheKey, StartVariantNote + ItemValue + EndVariantNote, int.Parse(dbdr.dr["plugin_cache_duration"].ToString()));
                }
                
                db.Close();

                return StartVariantNote + ItemValue + EndVariantNote;
            }
            else
            {
                db.Close();

                new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("plugin_asp_is_not_existed", GlobalLanguage).Replace("$_asp plugin_id;", PluginIdVariant), GlobalLanguage, "problem"));
                return "";
            }
        }

        public string ReadPlugin(string Content, string GlobalLanguage)
        {
            while (Content.Contains("$_plugin_id "))
            {
                string Variable = Content.Split(new string[] { "$_plugin_id " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_plugin_id " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_plugin_id " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_plugin_id " + Variable + ";", GetPlugin(Variable, GlobalLanguage));
            }

            while (Content.Contains("$_plugin_name "))
            {
                string Variable = Content.Split(new string[] { "$_plugin_name " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_plugin_name " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_plugin_name " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_plugin_name " + Variable + ";", GetPlugin(Variable, GlobalLanguage));
            }

            return Content;
        }

        public string GetFetch(string FetchName, string GlobalLanguage)
        {
            // File Exist Check
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchName + "/fetch.xml")))
            {
                new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("fetch_asp_is_not_existed", GlobalLanguage).Replace("$_asp fetch_name;", FetchName), GlobalLanguage, "problem"));
                return "";
            }


            DataUse.Fetch duf = new DataUse.Fetch();
            duf.FillCurrentFetchByFetchName(FetchName);


            // Check Active
            if (!duf.FetchActive.ZeroOneToBoolean())
                return "";


            // Check Access Show
            if (!duf.FetchPublicAccessShow.ZeroOneToBoolean())
            {
                if (!duf.GetFetchAccessShowCheck(duf.FetchId))
                    return "";
            }


            // Set Cache Key
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);

            // Get Cache
            if (cc.Exist(CacheType, "el_fetch_" + FetchName))
            {
                // Set Fetch Value Transfer
                duf.SetFetchValueTransfer(FetchName, int.Parse(duf.FetchCacheDuration));


                string TmpFetchValue = cc.GetValue(CacheType, "el_fetch_" + FetchName);
                return TmpFetchValue;
            }


            // Set Fetch Template
            XmlDocument FetchDocument = new XmlDocument();
            FetchDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/fetch/" + FetchName + "/fetch.xml"));

            string FetchSqlQuery = FetchDocument.SelectSingleNode("fetch_root/sql_query").InnerText;

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_language"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_language"].Value == "true")
                    FetchSqlQuery = ReadLanguage(FetchSqlQuery, StaticObject.GetCurrentAdminGlobalLanguage());

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_module"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_module"].Value == "true")
                    FetchSqlQuery = ReadModule(FetchSqlQuery, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_plugin"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_plugin"].Value == "true")
                    FetchSqlQuery = ReadPlugin(FetchSqlQuery, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_replace_part"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_replace_part"].Value == "true")
                    FetchSqlQuery = ReadReplacePart(FetchSqlQuery, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_fetch"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_fetch"].Value == "true")
                    FetchSqlQuery = ReadFetch(FetchSqlQuery, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_item"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_item"].Value == "true")
                    FetchSqlQuery = ReadItem(FetchSqlQuery, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_elanat"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/sql_query").Attributes["use_elanat"].Value == "true")
                    FetchSqlQuery = ReadElanat(FetchSqlQuery, GlobalLanguage);

            string FetchBox = FetchDocument.SelectSingleNode("fetch_root/box").InnerText;

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_language"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_language"].Value == "true")
                    FetchBox = ReadLanguage(FetchBox, StaticObject.GetCurrentAdminGlobalLanguage());

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_module"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_module"].Value == "true")
                    FetchBox = ReadModule(FetchBox, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_plugin"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_plugin"].Value == "true")
                    FetchBox = ReadPlugin(FetchBox, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_replace_part"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_replace_part"].Value == "true")
                    FetchBox = ReadReplacePart(FetchBox, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_fetch"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_fetch"].Value == "true")
                    FetchBox = ReadFetch(FetchBox, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_item"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_item"].Value == "true")
                    FetchBox = ReadItem(FetchBox, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_elanat"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/box").Attributes["use_elanat"].Value == "true")
                    FetchBox = ReadElanat(FetchBox, GlobalLanguage);

            string FetchListItem = FetchDocument.SelectSingleNode("fetch_root/list_item").InnerText;

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_language"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_language"].Value == "true")
                    FetchListItem = ReadLanguage(FetchListItem, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_module"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_module"].Value == "true")
                    FetchListItem = ReadModule(FetchListItem, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_plugin"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_plugin"].Value == "true")
                    FetchListItem = ReadPlugin(FetchListItem, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_replace_part"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_replace_part"].Value == "true")
                    FetchListItem = ReadReplacePart(FetchListItem, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_fetch"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_fetch"].Value == "true")
                    FetchListItem = ReadFetch(FetchListItem, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_item"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_item"].Value == "true")
                    FetchListItem = ReadItem(FetchListItem, GlobalLanguage);

            if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_elanat"] != null)
                if (FetchDocument.SelectSingleNode("fetch_root/list_item").Attributes["use_elanat"].Value == "true")
                    FetchListItem = ReadElanat(FetchListItem, GlobalLanguage);

            AttributeReader ar = new AttributeReader();

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetCommand(FetchSqlQuery);

            string TmpFetchListItem = "";
            string SumFetchListItem = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    TmpFetchListItem = FetchListItem;

                    foreach (XmlNode node in FetchDocument.SelectSingleNode("fetch_root/item").ChildNodes)
                    {
                        string ColumnTemplate = node.InnerText.Replace("$_db " + node.Name + ";", dbdr.dr[node.Name].ToString());

                        TmpFetchListItem = TmpFetchListItem.Replace("$_db " + node.Name + ";", ColumnTemplate);
                    }

                    SumFetchListItem += TmpFetchListItem;
                }

            string FetchValue = FetchBox.Replace("$_asp item;", SumFetchListItem);


            // Set Variant Note
            string StartVariantNote = "";
            string EndVariantNote = "";
            if (StaticObject.AddFetchVariantNote)
            {
                StartVariantNote = Template.GetGlobalTemplate("variant_note/fetch/start", GlobalLanguage).Replace("$_asp fetch_name;", FetchName);
                EndVariantNote = Template.GetGlobalTemplate("variant_note/fetch/end", GlobalLanguage).Replace("$_asp fetch_name;", FetchName);
            }


            // Set Fetch Value Transfer
            duf.SetFetchValueTransfer(FetchName, int.Parse(duf.FetchCacheDuration));


            // Set Cache
            cc.Insert(CacheType, "el_fetch_" + FetchName, StartVariantNote + FetchValue + EndVariantNote, int.Parse(duf.FetchCacheDuration));

            db.Close();


            return StartVariantNote + FetchValue + EndVariantNote;
        }

        public string ReadFetch(string Content, string GlobalLanguage)
        {
            while (Content.Contains("$_fetch_name "))
            {
                string Variable = Content.Split(new string[] { "$_fetch_name " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_fetch_name " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_fetch_name " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_fetch_name " + Variable + ";", GetFetch(Variable, GlobalLanguage));
            }

            return Content;
        }

        public string GetElanat(string ElanatVariant, string GlobalLanguage)
        {
            HttpContext context = new HttpContextAccessor().HttpContext;

            // Set Elanat Variant Format
            string TmpElanatVariant = ElanatVariant;
            string ElanatVariantFormat = "";
            if (ElanatVariant.Contains("{"))
            {
                ElanatVariantFormat = ElanatVariant.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();

                int ValueIndex = ElanatVariant.IndexOf("{");
                ElanatVariant = ElanatVariant.Remove(ValueIndex);
            }


            // Set Second Elanat Variant
            string SecondElanatVariant = ElanatVariant.Split(new string[] { "::" }, StringSplitOptions.None)[1].Split(' ')[0].Trim();

            if (string.IsNullOrEmpty(SecondElanatVariant))
            {
                new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("elanat_variable_asp_is_not_existed", GlobalLanguage).Replace("$_asp elanat_variable_name;", ElanatVariant), GlobalLanguage, "problem"));
                return "";
            }

            switch (SecondElanatVariant)
            {
                case "session": return StaticObject.GetSession(ElanatVariant.Remove(0, 10));
                case "site_template":
                    {
                        string TagPath = null;
                        int Item = 0;
                        string Attr = null;

                        List<string> ListValue = StringClass.ExtractFromString(ElanatVariant, "::");
                        TagPath = ListValue[0].Remove(0, 16);
                        Item = int.Parse(ListValue[1].Remove(0, 7));
                        if (ListValue.Count == 3)
                            Attr = ListValue[2].Remove(0, 7);


                        return Template.GetSiteTemplate(TagPath, Item, Attr);
                    };

                case "admin_template":
                    {
                        string TagPath = null;
                        int Item = 0;
                        string Attr = null;

                        List<string> ListValue = StringClass.ExtractFromString(ElanatVariant, "::");
                        TagPath = ListValue[0].Remove(0, 17);
                        Item = int.Parse(ListValue[1].Remove(0, 7));
                        if (ListValue.Count == 3)
                            Attr = ListValue[2].Remove(0, 7);


                        return Template.GetAdminTemplate(TagPath, Item, Attr);
                    };
                

                case "global_template":
                    {
                        string TagPath = null;
                        int Item = 0;
                        string Attr = null;

                        List<string> ListValue = StringClass.ExtractFromString(ElanatVariant, "::");
                        TagPath = ListValue[0].Remove(0, 18);
                        Item = int.Parse(ListValue[1].Remove(0, 7));
                        if (ListValue.Count == 3)
                            Attr = ListValue[2].Remove(0, 7);


                        return Template.GetGlobalTemplate(TagPath, GlobalLanguage, Item, Attr);
                    };

                case "config":
                    {
                        string TagPath = null;
                        int Item = 0;
                        string Attr = null;

                        List<string> ListValue = StringClass.ExtractFromString(ElanatVariant, "::");
                        TagPath = ListValue[0].Remove(0, 9);
                        Item = int.Parse(ListValue[1].Remove(0, 7));
                        if (ListValue.Count == 3)
                            Attr = ListValue[2].Remove(0, 7);


                        return ElanatConfig.GetElanatConfig(TagPath, Item, Attr);
                    };

                case "cache":
                    {
                        IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
                        return memoryCache.Get(ElanatVariant.Remove(0, 8)).ToString();
                    };

                case "server_variable": return context.GetServerVariable(ElanatVariant.Remove(0, 18));

                case "system":
                    {
                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
                        Random rand = new Random();

                        switch (ElanatVariant.Remove(0, 9))
                        {
                            case "random": return rand.Next(int.MaxValue).ToString();
                            case "site_path": return StaticObject.SitePath;
                            case "admin_directory_path": return StaticObject.AdminPath;
                            case "direction": return (ccoc.SiteLanguageIsRightToLeft.ZeroOneToBoolean())? "rtl" : "ltr";
                            case "mini_header": return Template.GetSiteTemplate("part/mini_header");
                            case "mini_footer": return Template.GetSiteTemplate("part/mini_footer");
                            case "site_main_url": return GlobalClass.GetSiteMainUrl();
                            case "refresh_meta": return (!ccoc.JavaScriptIsActive) ? Struct.GetNode("meta/refresh").InnerText : "";
                            case "date": return DateAndTime.GetDate();
                            case "time": return DateAndTime.GetTime();
                            case "local_date":
                                {
                                    DateAndTime dat = new DateAndTime();
                                    return dat.GetLocalDate(ccoc.Calendar, DateAndTime.GetDate());
                                };

                            default:
                                {
                                    new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("elanat_variable_asp_is_not_existed", GlobalLanguage).Replace("$_asp elanat_variable_name;", ElanatVariant), GlobalLanguage, "problem"));
                                    return "";
                                }
                        }
                    }

                case "site":
                    {
                        DataUse.Site dus = new DataUse.Site();
                        dus.FillCurrentSiteWithReturnDr(StaticObject.GetCurrentSiteSiteId());

                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                        switch (ElanatVariant.Remove(0, 7))
                        {
                            case "host": return context.Request.Host.Value + "/";
                            case "site_host": return context.Request.Host.Value + "/site/" + ccoc.SiteSiteGlobalName;
                            case "host_site_path": return context.Request.Host.Value + StaticObject.SitePath;
                            case "site_first_year":
                                {
                                    string SiteDateCreate = dus.ReturnDr["site_date_create"].ToString().Substring(0, 4);

                                    try { dus.ReturnDb.Close(); } catch (Exception) { }

                                    return SiteDateCreate;
                                }
                            case "site_date_year": return DateAndTime.GetDate("yyyy");
                            case "site_global_name": return ccoc.SiteSiteGlobalName;
                            case "site_global_local_name": return Language.GetHandheldLanguage(ccoc.SiteSiteGlobalName, GlobalLanguage);
                        }

                        if (dus.ReturnDr.HasColumn(ElanatVariant.Remove(0, 7)))
                        {
                            string TmpVariant = dus.ReturnDr[ElanatVariant.Remove(0, 7)].ToString();

                            try { dus.ReturnDb.Close(); } catch (Exception) { }

                            return TmpVariant;
                        }
                        else
                        {
                            new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("elanat_variable_asp_is_not_existed", GlobalLanguage).Replace("$_asp elanat_variable_name;", ElanatVariant), GlobalLanguage, "problem"));

                            try { dus.ReturnDb.Close(); } catch (Exception) { }
                            return "";
                        }
                    }

                case "user":
                    {
                        CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                        switch (ElanatVariant.Remove(0, 7))
                        {
                            case "admin_language_global_name": return ccoc.AdminLanguageGlobalName;
                            case "admin_language_id": return ccoc.AdminLanguageId;
                            case "admin_language_is_right_to_left": return ccoc.AdminLanguageIsRightToLeft;
                            case "admin_style_id": return ccoc.AdminStyleId;
                            case "admin_style_physical_path": return ccoc.AdminStylePhysicalPath;
                            case "admin_template_id": return ccoc.AdminTemplateId;
                            case "admin_template_physical_path": return ccoc.AdminTemplatePhysicalPath;
                            case "calendar": return ccoc.Calendar;
                            case "date_format": return ccoc.DateFormat;
                            case "day_difference": return ccoc.DayDifference;
                            case "first_day_of_week": return ccoc.FirstDayOfWeek;
                            case "rile_id_list": return ccoc.GetRoleIdList().ToString();
                            case "group_id": return ccoc.GroupId;
                            case "group_name": return ccoc.GroupName;
                            case "java_script_is_active": return ccoc.JavaScriptIsActive.BooleanToTrueFalse();
                            case "role_dominant_type": return ccoc.RoleDominantType;
                            case "site_id": return ccoc.SiteId;
                            case "site_language_global_name": return ccoc.SiteLanguageGlobalName;
                            case "site_language_id": return ccoc.SiteLanguageId;
                            case "site_language_is_right_to_left": return ccoc.SiteLanguageIsRightToLeft;
                            case "site_site_global_name": return ccoc.SiteSiteGlobalName;
                            case "site_style_id": return ccoc.SiteStyleId;
                            case "site_style_physical_path": return ccoc.SiteStylePhysicalPath;
                            case "site_template_id": return ccoc.SiteTemplateId;
                            case "site_template_physical_path": return ccoc.SiteTemplatePhysicalPath;
                            case "time_format": return ccoc.TimeFormat;
                            case "time_hours_difference": return ccoc.TimeHoursDifference;
                            case "time_minutes_difference": return ccoc.TimeMinutesDifference;
                            case "time_zine": return ccoc.TimeZone;
                            case "user_id": return ccoc.UserId;
                            case "user_name": return ccoc.UserName;
                            case "user_site_name": return ccoc.UserSiteName;

                            default:
                                {
                                    new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("elanat_variable_asp_is_not_existed", GlobalLanguage).Replace("$_asp elanat_variable_name;", ElanatVariant), GlobalLanguage, "problem"));
                                    return "";
                                }
                        }
                    }

                default:
                    {
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("elanat_variable_asp_is_not_existed", GlobalLanguage).Replace("$_asp elanat_variable_name;", ElanatVariant), GlobalLanguage, "problem"));
                        return "";
                    }
            }
        }
        
        public string ReadElanat(string Content, string GlobalLanguage)
        {
            while (Content.Contains("$_elanat "))
            {
                string Variable = Content.Split(new string[] { "$_elanat " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_elanat " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_elanat " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_elanat " + Variable + ";", GetElanat(Variable, GlobalLanguage));
            }

            return Content;
        }

        public string GetLanguage(string Word, string GlobalLanguage)
        {
            return Language.GetHandheldLanguage(Word, GlobalLanguage);
        }

        public string ReadLanguage(string Content, string GlobalLanguage, bool BreakLanguage = false)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/handheld.xml"));

            string Variable;
            while (Content.Contains("$_lang "))
            {
                Variable = Content.Split(new string[] { "$_lang " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                XmlNode node = doc.SelectSingleNode("language_root/lang_" + Variable[0] + "/" + Variable);

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_lang " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_lang " + Variable + ";"), GlobalLanguage, "problem"));

                Content = (node != null) ? Content.Replace("$_lang " + Variable + ";", node.InnerText) : (BreakLanguage) ? Content.Replace("$_lang " + Variable + ";", "$_tmp_lang " + Variable + ";") : Content.Replace("$_lang " + Variable + ";", Variable + StaticObject.NullLanguageSuffix);
            }

            if (BreakLanguage)
                Content = Content.Replace("$_tmp_lang ", "$_lang ");

            return Content;
        }

        public string GetReplacePart(string ReplacePartName, string GlobalLanguage)
        {
            // Set Cache Key
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);

            // Get Cache
            if (cc.Exist(CacheType, "replace_part_" + ReplacePartName))
            {
                string TmpReplacePartValue = cc.GetValue(CacheType, "replace_part_" + ReplacePartName);
                return TmpReplacePartValue;
            }

            XmlNodeList ReplacePartList = StaticObject.UrlRedirectNodeList;

           
            foreach (XmlNode node in ReplacePartList)
                if (node.Attributes["name"].Value == ReplacePartName)
                {
                    // Check Active
                    if (node.Attributes["active"] != null)
                        if (!node.Attributes["active"].Value.TrueFalseToBoolean())
                            return "";


                    string ReplacePartValue = node.InnerTextAfterSetNodeVariant(GlobalLanguage);

                    // Set Cache
                    int CacheDuration = 0;
                    if (node.Attributes["cache_duration"] != null)
                        if (node.Attributes["cache_duration"].Value.IsNumber())
                        {
                            CacheDuration = int.Parse(node.Attributes["cache_duration"].Value);
                            cc.Insert(CacheType, "replace_part_" + ReplacePartName, ReplacePartValue, CacheDuration);
                        }

                    return ReplacePartValue;
                }


            new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("replace_part_asp_is_not_exist", GlobalLanguage).Replace("$_asp replace_part_name;", ReplacePartName), GlobalLanguage, "problem"));
            return "";
        }

        public string ReadReplacePart(string Content, string GlobalLanguage)
        {
            while (Content.Contains("$_replace "))
            {
                string Variable = Content.Split(new string[] { "$_replace " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_replace " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_replace " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_replace " + Variable + ";", GetReplacePart(Variable, GlobalLanguage));
            }

            return Content;
        }

        public string GetItem(string ItemIdVariant, string GlobalLanguage)
        {
            string ItemId = ItemIdVariant;

            if (!ItemId.IsNumber())
            {
                DataUse.Item dui = new DataUse.Item();
                ItemId = dui.GetItemIdByItemName(ItemId);
            }

            // Set Cache Key
            CacheClass cc = new CacheClass();
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            string CacheType = StaticObject.GetCurrentCacheType(ccoc.RoleDominantType);


            // Get Cache
            if (cc.Exist(CacheType, "el_item_" + ItemId))
            {
                string TmpItemValue = cc.GetValue(CacheType, "el_item_" + ItemId);
                return TmpItemValue;
            }

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_item", "@item_id", ItemId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
            {
                dbdr.dr.Read();


                // Check Active
                if (!dbdr.dr["item_active"].ToString().TrueFalseToBoolean())
                    return "";


                string ItemValue = dbdr.dr["item_value"].ToString();

                if (dbdr.dr["item_use_elanat"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadElanat(ItemValue, GlobalLanguage);

                if (dbdr.dr["item_use_language"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadLanguage(ItemValue, GlobalLanguage);

                if (dbdr.dr["item_use_plugin"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadPlugin(ItemValue, GlobalLanguage);

                if (dbdr.dr["item_use_module"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadModule(ItemValue, GlobalLanguage);

                if (dbdr.dr["item_use_fetch"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadFetch(ItemValue, GlobalLanguage);

                if (dbdr.dr["item_use_item"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadItem(ItemValue, GlobalLanguage);

                if (dbdr.dr["item_use_replace_part"].ToString().TrueFalseToBoolean())
                    ItemValue = ReadReplacePart(ItemValue, GlobalLanguage);


                // Set Variant Note
                string StartVariantNote = "";
                string EndVariantNote = "";
                if (StaticObject.AddItemVariantNote)
                {
                    StartVariantNote = Template.GetGlobalTemplate("variant_note/item/start", GlobalLanguage).Replace("$_asp item_id;", ItemId);
                    EndVariantNote = Template.GetGlobalTemplate("variant_note/item/end", GlobalLanguage).Replace("$_asp item_id;", ItemId);
                }


                // Set Cache
                cc.Insert(CacheType, "el_item_" + ItemId, StartVariantNote + ItemValue + EndVariantNote, int.Parse(dbdr.dr["item_cache_duration"].ToString()));


                db.Close();


                return StartVariantNote + ItemValue + EndVariantNote;
            }

            db.Close();

            GlobalClass.Alert(Language.GetLanguage("item_asp_is_not_existed", GlobalLanguage).Replace("$_asp item_id;", ItemId), GlobalLanguage, "problem");
            return "";
        }

        public string ReadItem(string Content, string GlobalLanguage)
        {
            while (Content.Contains("$_item_id "))
            {
                string Variable = Content.Split(new string[] { "$_item_id " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_item_id " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_item_id " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_item_id " + Variable + ";", GetItem(Variable, GlobalLanguage));
            }

            while (Content.Contains("$_item_name "))
            {
                string Variable = Content.Split(new string[] { "$_item_name " }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                if (StaticObject.UseVariantDebug)
                    if (!Content.Contains("$_item_name " + Variable + ";"))
                        new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", "$_item_name " + Variable + ";"), GlobalLanguage, "problem"));

                Content = Content.Replace("$_item_name " + Variable + ";", GetItem(Variable, GlobalLanguage));
            }

            return Content;
        }
    }
}