﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Odata_101.Models;
namespace Odata_101
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

           // config.SuppressDefaultHostAuthentication();

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Note>("Notes");
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

           

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
