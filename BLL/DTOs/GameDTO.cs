using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class GameDTO : BaseDTO
    {
        
        public string GameCode { get; set; }   // PUBGM, VALORANT
        public string Name { get; set; }
        public int TeamSize { get; set; }

    }
}
