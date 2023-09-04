﻿using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionInactivePatchController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["patch_id"]))
            {
                Write("false");
                return;
            }

            if (!context.Request.Query["patch_id"].ToString().IsNumber())
            {
                Write("false");
                return;
            }


            DataUse.Patch dup = new DataUse.Patch();
            dup.FillCurrentPatch(context.Request.Query["patch_id"].ToString());


            // Run Uninstall Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + dup.PatchDirectoryPath + "/catalog.xml"));
            XmlNode PatchCatalog = CatalogDocument.SelectSingleNode("/patch_catalog_root");

            if (!string.IsNullOrEmpty(PatchCatalog["patch_uninstall_path"].Attributes["value"].Value))
                PageLoader.LoadWithServer(StaticObject.SitePath + "add_on/patch/" + dup.PatchDirectoryPath + "/" + PatchCatalog["patch_uninstall_path"].Attributes["value"].Value);


            dup.Inactive(context.Request.Query["patch_id"].ToString());
            Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_patch", context.Request.Query["patch_id"].ToString());
        }
    }
}