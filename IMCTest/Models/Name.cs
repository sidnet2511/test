using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAppMVC.Models
{
    public class Name
    {

            [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
            [Required]
            [StringLength(40)]
            public string LastName { get; set; }
       
    }
}