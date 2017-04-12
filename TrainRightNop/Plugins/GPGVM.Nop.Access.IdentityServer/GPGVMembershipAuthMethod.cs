using System;
using System.Collections.Generic;
using System.Web.Routing;
using GPGVM.Nop.Access.IdentityServer.Data;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Menu;

namespace GPGVM.Nop.Access.IdentityServer
{
    public class GPGVMembershipAuthMethod : BasePlugin, IExternalAuthenticationMethod, IAdminMenuPlugin
    {


        #region Fields

            private readonly ISettingService _settingService;
            private GPGVMIdentityContext _context;

        #endregion

        #region Ctor

            public GPGVMembershipAuthMethod(ISettingService settingService, GPGVMIdentityContext context)
            {
                _settingService = settingService;
                _context = context;
            }

        #endregion



        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "ExternalAuthFacebook";
            routeValues = new RouteValueDictionary { { "Namespaces", "Nop.Plugin.ExternalAuth.Facebook.Controllers" }, { "area", null } };
        }

        public void GetPublicInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            _context.Install();
            


            //settings
            var settings = new GPGVMembershipAuthSettings
            {
                //ClientKeyIdentifier = "",
                //ClientSecret = "",
            };
            _settingService.SaveSetting(settings);

            #region Client Settings

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Enabled", "If this type of client is enabled.");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientName", "Client display name (used for logging and consent screen)");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientId", "Unique ID of the client");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RequireConsent", "Specifies whether a consent screen is required.");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes", "Specifies the grant types the client is allowed to use.");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUris", "Specifies the allowed URIs to return tokens or authorization codes to");

            #endregion


            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();


            //settings
            _settingService.DeleteSetting<GPGVMembershipAuthSettings>();

            #region Client Settings

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Enabled");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientName");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientId");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RequireConsent");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUris");
            
            #endregion

            base.Uninstall();
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {

            //Children first
            var children = new List<SiteMapNode>();
            children.Add(
                new SiteMapNode
                {
                    Visible = true,
                    Title = "Manage Clients",
                    Url = "/IdentityEdit/LoadIdentityEdit/1"

                });

            children.Add(
                new SiteMapNode
                {
                    Visible = true,
                    Title = "Manage Scopes",
                    Url = "/IdentityEdit/LoadIdentityEdit/2"
                });

            children.Add(
                new SiteMapNode
                {
                    Visible = true,
                    Title = "Manage Users",
                    Url = "/IdentityEdit/LoadIdentityEdit/3"
                });
            



            rootNode.ChildNodes.Add(
                new SiteMapNode
                {
                    Visible = true,
                    Title = "Manage Identities",
                    Url = "", //blank so this acts as a navigational parent node
                    ChildNodes = children

                    
                    
                });

        }
    }
}
