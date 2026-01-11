using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class PlayerDTO: BaseDTO
    {

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string InGameName { get; set; }

    }
}
