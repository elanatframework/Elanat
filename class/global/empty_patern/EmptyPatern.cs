using System.Xml;

namespace Elanat.EmptyPatern
{
    public class PageCatalog
    {
        private XmlDocument doc = new XmlDocument();

        public string PageName = "";
        public string PagePhysicalName = "";
        public string PagePhysicalPath = "";
        public string PageAuthor = "";
        public string PageBestLoadStatus = "";
        public string PageVersion = "";
        public string PageReleaseDate = "";
        public string PageInfo = "";
        public string PageTitle = "";
        public string PageLicense = "";
        public string PageStaticHead = "";
        public string PageLoadTag = "";

        public void Load()
        {
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/page/catalog.xml"));

            doc.SelectSingleNode("page_name").Attributes["value"].Value = PageName;
            doc.SelectSingleNode("page_physical_name").Attributes["value"].Value = PagePhysicalName;
            doc.SelectSingleNode("page_physical_path").Attributes["value"].Value = PagePhysicalPath;
            doc.SelectSingleNode("page_author").Attributes["value"].Value = PageAuthor;
            doc.SelectSingleNode("page_best_load_status").Attributes["value"].Value = PageBestLoadStatus;
            doc.SelectSingleNode("page_version").Attributes["value"].Value = PageVersion;
            doc.SelectSingleNode("page_release_date").Attributes["value"].Value = PageReleaseDate;

            doc.SelectSingleNode("page_info").InnerText = PageInfo;
            doc.SelectSingleNode("page_title").InnerText = PageTitle;
            doc.SelectSingleNode("page_license").InnerText = PageLicense;
            doc.SelectSingleNode("page_static_head").InnerText = PageStaticHead;
            doc.SelectSingleNode("page_load_tag").InnerText = PageLoadTag;
        }

        public void Save(string Path)
        {
            doc.Save(Path);
        }
    }
}