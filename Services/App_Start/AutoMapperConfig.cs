using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AutoMapper;
using ClassLibrary;

namespace Services.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IDataRecord, Customer>()
                .ForMember(source => source.CustomerID, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("CustomerID"))))
                .ForMember(dest => dest.FirstName, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("FirstName"))))
                .ForMember(dest => dest.LastName, source => source.MapFrom(s => s.GetValue(s.GetOrdinal("LastName"))));

                cfg.CreateMap<Customer, Client>();

                //cfg.CreateMap<IDataRecord, Client>();


            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}