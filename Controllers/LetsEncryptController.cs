#region Copyright

// Copyright (c) 2018, Roland Baranowski. All rights reserved.
// Date: 2018-06-16
// File: RB.Plugin.Security.LetsEncrypt / LetsEncryptController.cs

#endregion

#region Usings

using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;

#endregion

namespace RB.Plugin.Security.LetsEncrypt.Controllers
{
    [AllowAnonymous]
    public class LetsEncryptController: BasePluginController
    {
        private readonly IHostingEnvironment _environment;

        public LetsEncryptController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        [Route(".well-known/acme-challenge/{id}")]
        public ActionResult LetsEncrypt(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new EmptyResult();
            }
            
            string file = Path.Combine(_environment.WebRootPath, ".well-known", "acme-challenge", id);
            if (System.IO.File.Exists(file))
            {
                return new PhysicalFileResult(file, "text/plain");
            }

            file = Path.Combine(_environment.ContentRootPath, ".well-known", "acme-challenge", id);

            if (System.IO.File.Exists(file))
            {
                return new PhysicalFileResult(file, "text/plain");
            }

            return new EmptyResult();
        }
    }
}