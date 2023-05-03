using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class Global : HttpApplication
    {
        public Global()
        {

        }

        public void Application_Start(object sender, EventArgs e)
        {
            // Set Static Object

            // Set Config Value
            StaticObject.SetConfigValue();

            // Set Code Value
            StaticObject.SetCodeValue();

            // Set Ip Session Indexe Value
            StaticObject.SetIpSessionIndexerValue();

            // Set Static File Data Value
            StaticObject.SetAfterReferenceDocument();
            StaticObject.SetBeforeReferenceDocument();
            StaticObject.SetEventReferenceDocument();
            StaticObject.SetUrlRedirectDocument();
            StaticObject.SetDefaultPageDocument();
            StaticObject.SetDynamicExtensionDocument();
            StaticObject.SetReplacePartDocument();
            StaticObject.SetScriptExtensionDocument();
            StaticObject.SetRoleBitColumnAccessDocument();
            StaticObject.SetUrlRewriteDocument();
            StaticObject.SetStartUpDocument();
            StaticObject.SetScheduledTaskDocument();
            StaticObject.SetStructDocument();
            StaticObject.SetGlobalTemplatesDocument();
            StaticObject.SetSiteTemplate();
            StaticObject.SetAdminTemplate();
            StaticObject.SetLanguageDocument();

            // Set Role Value
            StaticObject.SetRoleValue();

            // Run Script Start Command
            StaticObject.RunScriptStartCommand();

            // Set Scheduled Tasks Value
            StaticObject.ScheduledTasksHasABeenImplemented = false;
            StaticObject.StartUpHasABeenImplemented = false;
        }

        void Application_End(object sender, EventArgs e)
        {
            // Clean Disk Cache File
            FileAndDirectory fad = new FileAndDirectory();

            try
            {
                fad.DeleteAllFileAndSubDirectoryInDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/"));
                fad.DeleteAllFileAndSubDirectoryInDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/session_data/"));
            }
            catch (Exception) {}
        }

        void Application_Error(object sender, EventArgs e)
        {

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Increase Online Guest
            StaticObject.OnlineGuest++;

            try
            {
                // Run Start Up Page
                if (!StaticObject.StartUpHasABeenImplemented)
                {
                    StartUpClass suc = new StartUpClass();
                    suc.Start();

                    StaticObject.StartUpHasABeenImplemented = true;
                }


                // Set Ip Session Indexer
                Security sc = new Security();
                sc.AddIpSessionIndexer();
            }
            catch (Exception) { }
        }

        void Session_End(object sender, EventArgs e)
        {
            // Decrease Online Guest
            StaticObject.OnlineGuest--;
        }
    }
}