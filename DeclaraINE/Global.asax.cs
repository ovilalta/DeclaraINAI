using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace DeclaraINE
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("es-MX");
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("Server");
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            CultureInfo newCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentCulture = newCulture;

            try { Response.Headers.Remove("X-Powered-By"); } catch { }
            try { Response.Headers.Remove("X-AspNet-Version"); } catch { }
            try { Response.Headers.Remove("X-AspNetMvc-Version"); } catch { }
            try { Response.Headers.Remove("Server"); } catch { }

            Response.AppendHeader("X-Frame-Options", "DENY");
            Response.AppendHeader("X-XSS-Protection", "1");
            Response.AppendHeader("X-Content-Type-Options", "nosniff");
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate");

        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            try
            {
                if (Request.IsSecureConnection == true)
                    foreach (string s in Response.Cookies.AllKeys)
                    {
                        Response.Cookies[s].Secure = true;
                    }
            }
            catch (Exception)
            {
            }
        }

    }
}