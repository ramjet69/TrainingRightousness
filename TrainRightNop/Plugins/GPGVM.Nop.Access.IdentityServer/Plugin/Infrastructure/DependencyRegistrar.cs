using Autofac;
using Autofac.Core;
using GPGVM.Nop.Access.IdentityServer.Plugin.Data;
using GPGVM.Nop.Access.IdentityServer.Plugin.Domain;
using GPGVM.Nop.Access.IdentityServer.Plugin.Service;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Mvc;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "";
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            this.RegisterPluginDataContext<GPGVMIdentityContext>(builder, CONTEXT_NAME);

            builder.RegisterType<EfRepository<ClientConfigRecord>>()
                .As<IRepository<ClientConfigRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<RedirectUriRecord>>()
                .As<IRepository<RedirectUriRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<ClientService>().As<IClientService>().InstancePerLifetimeScope();


        }
    }
}
