using System.Web.Mvc;
using GPGVM.Nop.Access.IdentityServer.Plugin.Domain;
using Nop.Core.Data;
using Nop.Web.Framework.Controllers;
using GPGVM.Nop.Access.IdentityServer.Plugin.Models;
using GPGVM.Nop.Access.IdentityServer.Plugin.Service;
using Nop.Services.Security;
using Nop.Web.Framework.Kendoui;
using System.Linq;
using GPGVM.Nop.Access.IdentityServer.Plugin.Infrastructure;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Controllers
{
    [AdminAuthorize]
    public class ClientConfigurationController : GPGVMBaseController
    {

        private IRepository<ClientConfigRecord> _clientConfigRecord;
        private IRepository<RedirectUriRecord> _redirectUriRecord;

        private readonly IPermissionService _permissionService;
        private readonly IClientService _clientService;


        public ClientConfigurationController(IRepository<ClientConfigRecord> clientConfigRecord, IRepository<RedirectUriRecord> redirectUriRecord, IPermissionService permissionService, IClientService clientService)
        {
            _clientConfigRecord = clientConfigRecord;
            _redirectUriRecord = redirectUriRecord;
            _permissionService = permissionService;
            _clientService = clientService;
        }


        public ActionResult LoadClients()
        {
            return View("ClientConfig");
        }


        [HttpPost]
        public ActionResult List(DataSourceRequest command, ClientConfigRecordList model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            var clients = _clientService.GetAllClients(model.SearchCategoryName, model.SearchStoreId, command.Page - 1, command.PageSize);
            var gridModel = new DataSourceResult
            {
                Data = clients,
                Total = clients.TotalCount
            };
            
            return Json(gridModel);
        }


        public ActionResult Create()
        {
            var x = new ClientConfigModel();
            x.RedirectUris.Add(new RedirectUriModel());

            x.RedirectUris.Add(new RedirectUriModel { ClientRecordId = 789, Uri = "Fox", UriName = "News" } );
            x.RedirectUris.Add(new RedirectUriModel { ClientRecordId  = 111, Uri = "Google", UriName = "Search" } );

            return View("Create", x);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(ClientConfigModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var client = model.ToEntity();

                if (continueEditing)
                {
                    //selected tab
                    //SaveSelectedTabName();

                    return RedirectToAction("Edit", new {id = client.Id});
                }
                return RedirectToAction("List");

            }

            return View("Create", model);

        }
    }
}