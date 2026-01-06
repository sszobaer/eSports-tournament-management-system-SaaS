using DAL.Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class TeamDTO: BaseDTO
    {
       
        public int OrganizationId { get; set; }

        public int GameId { get; set; }
        public string Name { get; set; }
        public string? LogoUrl { get; set; }
        
        public IFormFile Logo { get; set; }
    }
}
