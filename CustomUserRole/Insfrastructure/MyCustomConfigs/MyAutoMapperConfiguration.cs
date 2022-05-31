using AutoMapper;
using CustomUserRole.Insfrastructure.MyAutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomUserRole.Insfrastructure.MyCustomConfigs
{
    public class MyAutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config => config.AddProfile(new MyMapperProfile()));
        }
    }
}