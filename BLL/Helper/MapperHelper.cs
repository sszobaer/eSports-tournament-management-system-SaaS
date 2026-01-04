using AutoMapper;
using BLL.DTOs;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helper
{
    public class MapperHelper
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
    }
}
