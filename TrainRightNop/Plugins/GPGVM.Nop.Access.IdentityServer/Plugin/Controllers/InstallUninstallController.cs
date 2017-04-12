using System.Web.Mvc;
using Nop.Web.Framework.Controllers;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Controllers
{
    public class InstallUninstallController : BasePluginController
    {





        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
            //    return Content("Access denied");

            ////load settings for a chosen store scope
            //var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            //var facebookExternalAuthSettings = _settingService.LoadSetting<FacebookExternalAuthSettings>(storeScope);

            //var model = new ConfigurationModel();
            //model.ClientKeyIdentifier = facebookExternalAuthSettings.ClientKeyIdentifier;
            //model.ClientSecret = facebookExternalAuthSettings.ClientSecret;

            //model.ActiveStoreScopeConfiguration = storeScope;
            //if (storeScope > 0)
            //{
            //    model.ClientKeyIdentifier_OverrideForStore = _settingService.SettingExists(facebookExternalAuthSettings, x => x.ClientKeyIdentifier, storeScope);
            //    model.ClientSecret_OverrideForStore = _settingService.SettingExists(facebookExternalAuthSettings, x => x.ClientSecret, storeScope);
            //}

            //return View("~/Plugins/ExternalAuth.Facebook/Views/ExternalAuthFacebook/Configure.cshtml", model);
            return null;
        }

        //[HttpPost]
        //[AdminAuthorize]
        //[ChildActionOnly]
        //public ActionResult Configure(ClientConfigurationModel model)
        //{
        //    //if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
        //    //    return Content("Access denied");

        //    //if (!ModelState.IsValid)
        //    //    return Configure();

        //    ////load settings for a chosen store scope
        //    //var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
        //    //var facebookExternalAuthSettings = _settingService.LoadSetting<FacebookExternalAuthSettings>(storeScope);

        //    ////save settings
        //    //facebookExternalAuthSettings.ClientKeyIdentifier = model.ClientKeyIdentifier;
        //    //facebookExternalAuthSettings.ClientSecret = model.ClientSecret;

        //    ///* We do not clear cache after each setting update.
        //    // * This behavior can increase performance because cached settings will not be cleared 
        //    // * and loaded from database after each update */
        //    //_settingService.SaveSettingOverridablePerStore(facebookExternalAuthSettings, x => x.ClientKeyIdentifier, model.ClientKeyIdentifier_OverrideForStore, storeScope, false);
        //    //_settingService.SaveSettingOverridablePerStore(facebookExternalAuthSettings, x => x.ClientSecret, model.ClientSecret_OverrideForStore, storeScope, false);

        //    ////now clear settings cache
        //    //_settingService.ClearCache();

        //    //SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

        //    //return Configure();
        //    return null;
        //}



    }
}
