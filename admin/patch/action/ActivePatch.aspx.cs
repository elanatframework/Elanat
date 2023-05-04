using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionActivePatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["patch_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["patch_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }


            DataUse.Patch dup = new DataUse.Patch();
            dup.FillCurrentPatch(Request.QueryString["patch_id"].ToString());


            // Run Install Page
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/patch/" + dup.PatchDirectoryPath + "/catalog.xml"));
            XmlNode PatchCatalog = CatalogDocument.SelectSingleNode("/patch_catalog_root");

            if (!string.IsNullOrEmpty(PatchCatalog["patch_install_path"].Attributes["value"].Value))
                PageLoader.LoadWithServer("/add_on/patch/" + dup.PatchDirectoryPath + "/" + PatchCatalog["patch_install_path"].Attributes["value"].Value);


            dup.Active(Request.QueryString["patch_id"].ToString());
            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_patch", Request.QueryString["patch_id"].ToString());
        }
    }
}