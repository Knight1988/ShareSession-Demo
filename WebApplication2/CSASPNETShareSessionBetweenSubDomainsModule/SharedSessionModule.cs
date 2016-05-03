using System;
using System.Web;
using System.Reflection;
using System.Configuration;

namespace CSASPNETShareSessionBetweenSubDomainsModule
{
    public class SharedSessionModule : IHttpModule
    {
        protected static string applicationName = ConfigurationManager.AppSettings["ApplicationName"];
        protected static string rootDomain = ConfigurationManager.AppSettings["RootDomain"];

        public void Init(HttpApplication context)
        {
            FieldInfo runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            HttpRuntime theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
            FieldInfo appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
            appNameInfo.SetValue(theRuntime, applicationName);
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;
            HttpCookie cookie = context.Response.Cookies["ASP.NET_SessionId"];

            if (context.Session != null &&
                !string.IsNullOrEmpty(context.Session.SessionID))
            {
                cookie.Value = context.Session.SessionID;
                if (rootDomain != "localhost")
                {
                    cookie.Domain = rootDomain;
                }
                cookie.Path = "/";
            }
        }

        public void Dispose() { }
    }
}