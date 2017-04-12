using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nop.Web.Framework;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Models
{
    public partial class ClientConfigRecordList : BaseNopModel
    {

        public ClientConfigRecordList()
        {
            AvailableStores = new List<SelectListItem>();
        }


        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.SearchCategoryName")]
        [AllowHtml]
        public string SearchCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Categories.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }



    }
}
