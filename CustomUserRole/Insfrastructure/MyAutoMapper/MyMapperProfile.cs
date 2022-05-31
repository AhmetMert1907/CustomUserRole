using AutoMapper;
using CustomUserRole.Models.Entities;
using CustomUserRole.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomUserRole.Insfrastructure.MyAutoMapper
{
    public class MyMapperProfile : Profile
    {
        public MyMapperProfile()
        {
            CreateMap<User, RegisterViewModel>().ReverseMap();
        }
    }
}