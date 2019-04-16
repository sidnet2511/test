using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebAppMVC.Models
{
    public class Location
    {
        [Required]
        [StringLength(128)]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(128)]
        public string Unit  { get; set; }
        [Required]
        [StringLength(32)]
        public string City { get; set; }
        [Required]
        [StringLength(32)]
        public string Province { get; set; }
    }
}