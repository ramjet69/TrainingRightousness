using GPGVM.Nop.Access.IdentityServer.Plugin.Domain;
using GPGVM.Nop.Access.IdentityServer.Plugin.Models;


namespace GPGVM.Nop.Access.IdentityServer.Plugin.Infrastructure
{
    public static class MappingExtensions
    {

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfig.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfig.Mapper.Map(source, destination);
        }

        #region Client

            public static ClientConfigModel ToModel(this ClientConfigRecord entity)
            {
                return entity.MapTo<ClientConfigRecord, ClientConfigModel>();
            }

            public static ClientConfigRecord ToEntity(this ClientConfigModel model)
            {
                return model.MapTo<ClientConfigModel, ClientConfigRecord>();
            }

            public static ClientConfigRecord ToEntity(this ClientConfigModel model, ClientConfigRecord destination)
            {
                return model.MapTo(destination);
            }

        #endregion

    }
}