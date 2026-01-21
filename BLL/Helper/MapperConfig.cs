using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Match;
using BLL.DTOs.Organization;
using BLL.DTOs.User;
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
                cfg.CreateMap<Player, PlayerDTO>().ReverseMap();
                cfg.CreateMap<Role, RoleDTO>().ReverseMap();
                cfg.CreateMap<Organization, OrganizationCreateDTO>().ReverseMap();
                cfg.CreateMap<Organization, OrganizationGetDTO>().ReverseMap()
                .ForMember(
                    dest => dest.Users,
                    src => src.MapFrom(c => c.Users)
                    );
                cfg.CreateMap<Organization, OrganizationUpdateDTO>().ReverseMap();
                cfg.CreateMap<OrganizationUser, OrganizationUserDTO>().ReverseMap();
                cfg.CreateMap<Organization, OrganizationInfoDTO>().ReverseMap();
                cfg.CreateMap<User, UserRegisterDTO>().ReverseMap();
                cfg.CreateMap<User, UserGetDTO>().ReverseMap();
                cfg.CreateMap<User, UserLoginDTO>().ReverseMap();
                cfg.CreateMap<MatchTeamResult, MatchTeamResultGetDTO>()
                    .ForMember(dest => dest.Players,
                        src => src.MapFrom(x => x.PlayerStats));
                cfg.CreateMap<MatchPlayerStat, PlayerStatGetDTO>().ReverseMap();

            });
            return new Mapper(config);
        }
    }
}
