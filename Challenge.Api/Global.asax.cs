using Challenge.Api.Controllers;
using Challenge.CrossCutting.IoC;
using Microsoft.Practices.Unity;
using System;
using System.Web;
using System.Web.Http;

namespace Challenge.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var unity = new UnityContainer();

            unity.RegisterType<CatalogController>();

            GlobalConfiguration.Configuration.DependencyResolver = new IoCContainer(unity);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");
        }
    }
}
