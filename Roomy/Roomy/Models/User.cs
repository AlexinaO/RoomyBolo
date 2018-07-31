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

        [Required(ErrorMessageResourceName = "champ_obligatoire",
            ErrorMessageResourceType = typeof(Resources.ResourceRoomy))]
        [StringLength(150, MinimumLength = 10,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères.")]
        [Display(Name = "email", ResourceType = typeof(Resources.ResourceRoomy))]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "L'adresse n'est pas au bon format")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "champ_obligatoire",
            ErrorMessageResourceType = typeof(Resources.ResourceRoomy))]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Format incorrect")]
        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation est incorecte")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessageResourceName = "champ_obligatoire",
            ErrorMessageResourceType = typeof(Resources.ResourceRoomy))]
        [Display(Name = "Date de naisance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime BirthDate { get; set; }       
    }
}