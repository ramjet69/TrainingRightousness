using System;
using System.Collections.Generic;
using System.Web.Routing;
using GPGVM.Nop.Access.IdentityServer.Plugin.Data;
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
            

            #region Client Settings

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Enabled", "Enabled");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Enabled.Hint", "If this type of client is enabled.");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientName", "Client Name");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientName.Hint", "Client display name (used for logging and consent screen)");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientId", "Client ID");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientId.Hint", "Unique ID of the client");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RequireConsent", "Require Consent");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RequireConsent.Hint", "Specifies whether a consent screen is required.");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes", "Grant Types");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes.Hint", "Specifies the grant types the client is allowed to use.");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUris", "Redirect URI's");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUris.Hint", "List of the redirection URI's");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.EditClientDetails", "Edit client details");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Manage", "Manage Clients");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.SearchCategoryName", "Client Name");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AddNew", "Add new client");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.BackToList", "back to client list");

            #endregion

            #region Model Settings

            this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUriName", "Name");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUriName.Hint", "Friendly name for the uri redirection.");

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUri", "URI");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUri.Hint", "Specifies the allowed URIs to return tokens or authorization codes to.");

               
            #endregion

            #region General

                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.TabName", "Clients");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Scopes.TabName", "Scopes");
                this.AddOrUpdatePluginLocaleResource("GPGVM.NOP.IdentityServer.Users.TabName", "Users");

            #endregion

            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();


            #region Client Settings

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Enabled");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Enabled.Hint");

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientName");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientName.Hint");

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientId");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.ClientId.Hint");

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RequireConsent");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RequireConsent.Hint");

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes.Hint");

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUris");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUris.Hint");

                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.EditClientDetails");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.EditClientDetails.Hint");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.Manage");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.SearchCategoryName");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.AddNew");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.BackToList");

            #endregion

            #region Models

            this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUriName");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUriName.Hint");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUri");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.RedirectUri.Hint");

            #endregion

            #region General

            this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Clients.TabName");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Scopes.TabName");
                this.DeletePluginLocaleResource("GPGVM.NOP.IdentityServer.Users.TabName");

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
