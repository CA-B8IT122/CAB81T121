using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Q2_2018.Models
{
    public class BuildingCodes
    {
        [Required]
        public int BuildingID { get; set; }
        [Required]
        public string BuildingHouse { get; set; }
        [Required]
        public string BuildingCode { get; set; }

    }
}