using AutoMapper;
using GPGVM.Nop.Access.IdentityServer.Plugin.Domain;
using GPGVM.Nop.Access.IdentityServer.Plugin.Models;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Infrastructure
{
    public static class AutoMapperConfig
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        /// <summary>
        /// Initialize mapper
        /// </summary>
        public static void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientConfigRecord, ClientConfigModel>();



                cfg.CreateMap<ClientConfigModel, ClientConfigRecord>();


            });
        }



        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
        
        
        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                return _mapperConfiguration;
            }
        }


    }
}