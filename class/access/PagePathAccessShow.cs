using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace elanat
{
    public class PagePathAccessShow
    {
        public string CurrentPageId { get; private set; }

        public string GetPageIdByPageDirectoryPath(string PageDirectoryPath)
        {
            DataUse.Page dup = new DataUse.Page();
            string PageId = dup.GetPageIdByPageDirectoryPath(PageDirectoryPath);

            return PageId;
        }

        public string GetPageDirectoryPathFromPath(string Path)
        {
            FileAndDirectory fad = new FileAndDirectory();

            string PageDirectoryPath = "";
            PageDirectoryPath = fad.GetCleanDirectoryPathFromPath(Path);

            string[] PageDirectoryPathArray = PageDirectoryPath.Split('/');

            int PageDirectoryPathArrayLength = PageDirectoryPathArray.Length;

            for (int i = 0; i < PageDirectoryPathArrayLength; i++)
            {
                PageDirectoryPath = string.Join("/", PageDirectoryPathArray);

                if (File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "page/" + string.Join("/", PageDirectoryPathArray) + "/catalog.xml")))
                    return PageDirectoryPath;

                // Delete Last Item From Array
                PageDirectoryPathArray = PageDirectoryPathArray.Take(PageDirectoryPathArray.Count() - 1).ToArray();
            }

            return "";
        }

        public bool PathAccessToPage(string Path)
        {
            string PageDirectoryPath = GetPageDirectoryPathFromPath(Path);

            if (string.IsNullOrEmpty(PageDirectoryPath))
                return false;

            string PageId = GetPageIdByPageDirectoryPath(PageDirectoryPath);

            CurrentPageId = PageId;

            if (string.IsNullOrEmpty(PageId))
                return false;

            DataUse.Page dup = new DataUse.Page();

            return dup.GetPageAccessShowCheck(PageId);
        }
    }
}