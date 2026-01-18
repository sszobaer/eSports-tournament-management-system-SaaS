using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Organization;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helper
{
    public class MapperConfig
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>().ReverseMap();
                cfg.CreateMap<Team, TeamDTO>().ReverseMap();
                cfg.CreateMap<Role, RoleDTO>().ReverseMap();
                cfg.CreateMap<Organization, OrganizationCreateDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
    }
}
