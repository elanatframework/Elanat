using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionViewModuleOptionModel : CodeBehindModel
    {
        public string ViewModuleOption(string ModuleId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_module", "@module_id", ModuleId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            XmlDocument ModuleOptionDocument = new XmlDocument();
            ModuleOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + dbdr.dr["module_directory_path"].ToString() + "/catalog.xml"));

            XmlNode node = ModuleOptionDocument.SelectSingleNode("module_catalog_root");

            string ModuleOptionPath = node["module_option_path"].Attributes["value"].Value;
            string ModuleDirectoryPath = dbdr.dr["module_directory_path"].ToString();

            db.Close();

            return PageLoader.LoadWithIframe(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/" + ModuleDirectoryPath + "/" + ModuleOptionPath), true); ;
        }
    }
}