using System.Data;
using AutoMapper;
using ServiceContracts;
using ServiceContracts.Contracts;

namespace Services
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IDataRecord, Customer>()
                .ForMember(source => source.CustomerId, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("CustomerID"))))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("FirstName"))))
                .ForMember(dest => dest.LastName, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("LastName"))));

                //cfg.CreateMap<Customer, Client>();

                //cfg.CreateMap<IDataRecord, Client>();


            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}