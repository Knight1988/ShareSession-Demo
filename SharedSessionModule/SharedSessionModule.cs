using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Web;

namespace SharedSessionModule
{
    public class SharedSessionModule : IHttpModule
    {
        protected static string ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
        protected static string RootDomain = ConfigurationManager.AppSettings["RootDomain"];

        public void Init(HttpApplication context)
        {
            var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            Debug.Assert(runtimeInfo != null, "runtimeInfo != null");
            var theRuntime = (HttpRuntime) runtimeInfo.GetValue(null);
            var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Debug.Assert(appNameInfo != null, "appNameInfo != null");
            appNameInfo.SetValue(theRuntime, ApplicationName);
            context.PostRequestHandlerExecute += ContextOnPostRequestHandlerExecute;
        }

        public void Dispose()
        {
        }

        private static void ContextOnPostRequestHandlerExecute(object sender, EventArgs e)
        {
            var context = (HttpApplication) sender;
            var cookie = context.Response.Cookies["ASP.NET_SessionId"];

            if (string.IsNullOrEmpty(context.Session.SessionID)) return;

            Debug.Assert(cookie != null, "cookie != null");
            cookie.Value = context.Session.SessionID;
            if (RootDomain != "localhost")
                cookie.Domain = RootDomain;
            cookie.Path = "/";
        }
    }
}