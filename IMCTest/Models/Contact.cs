using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebAppMVC.Models
{
    public class Contact
    {
        [Required]
        [StringLength(128)]
        public string Email { get; set; }
    }
}