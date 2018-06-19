using System;
using Nop.Core.Plugins;
using Nop.Services.Common;

namespace RB.Plugin.Security.LetsEncrypt
{
    public class LetsEncryptSupport : IMiscPlugin
    {
        public string GetConfigurationPageUrl()
        {
            return "";
        }

        public PluginDescriptor PluginDescriptor { get; set; }
        public void Install()
        {
        }

        public void Uninstall()
        {
        }
    }
}
