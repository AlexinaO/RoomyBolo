using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class User
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        [Display(Name = "email", ResourceType = typeof(Resources.ResourceRoomy))]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public DateTime BithDate { get; set; }       
    }
}