using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class PersonContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        
        public string Province { get; set; }
        public string Email { get; set; }

    }
}