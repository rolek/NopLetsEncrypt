#region Copyright
// Copyright (c) 2018, Roland Baranowski. All rights reserved.
// Date: 2018-06-16
// File: RB.Plugin.Security.LetsEncrypt / RouteProvider.cs
#endregion

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace RB.Plugin.Security.LetsEncrypt
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("RB.Plugin.Security.LetsEncrypt", ".well-known/acme-challenge/{id}",
                new { controller = "LetsEncryptController", action = "LetsEncrypt", id = "" });
        }
        public int Priority => -1;
    }
}