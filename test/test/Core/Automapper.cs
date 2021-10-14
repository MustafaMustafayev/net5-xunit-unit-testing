using System;
using AutoMapper;
using test.DTOs;
using test.Models;

namespace test.Core
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<RoleToAddDTO, Role>();
            CreateMap<Role, RoleToListDTO>();
        }
    }
}
