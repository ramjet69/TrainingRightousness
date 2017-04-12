using GPGVM.Nop.Access.IdentityServer.Plugin.Domain;
using Nop.Core;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Service
{
    public interface IClientService
    {
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="clientName">Client name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>ClientConfigRecords</returns>
        IPagedList<ClientConfigRecord> GetAllClients(string clientName = "", int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}