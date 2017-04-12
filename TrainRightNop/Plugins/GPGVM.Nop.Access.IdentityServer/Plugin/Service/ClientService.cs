using System;
using System.Linq;
using GPGVM.Nop.Access.IdentityServer.Plugin.Domain;
using Nop.Core;
using Nop.Core.Data;
using Nop.Web.Framework.Kendoui;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Service
{
    public class ClientService : IClientService
    {
        private readonly IRepository<ClientConfigRecord> _clientConfigRecord;

        public ClientService(IRepository<ClientConfigRecord> clientConfigRecord)
        {
            _clientConfigRecord = clientConfigRecord;
            
        }



        public IPagedList<ClientConfigRecord> GetAllClients(string clientName = "", int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _clientConfigRecord.Table;

            if (query.Any())
            {
                if (!String.IsNullOrWhiteSpace(clientName))
                    query = query.Where(c => c.ClientName.Contains(clientName));
                query = query.Where(c => !c.isDeleted);
                query = query.OrderBy(c => c.ClientRecordId); 
            }

            
            var clients = query.ToList();


            //paging
            return new PagedList<ClientConfigRecord>(clients, pageIndex, pageSize);
        }
    }
}