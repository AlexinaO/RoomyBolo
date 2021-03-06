﻿using Roomy.Utils.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    //[Table("Utilisateur", Schema = "roomy")]
    public class User: BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("UserID", TypeName = "")]
        //public int ID { get; set; }

        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        //public bool IsMail { get; set; }

        [Required(ErrorMessageResourceName = "champ_obligatoire",
            ErrorMessageResourceType = typeof(Resources.ResourceRoomy))]
        [StringLength(150, MinimumLength = 10,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères.")]
        [Display(Name = "email", ResourceType = typeof(Resources.ResourceRoomy))]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "L'adresse n'est pas au bon format")]
        //[Check("IsMail", ErrorMessage ="erreur....")]
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
        [NotMapped]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessageResourceName = "champ_obligatoire",
            ErrorMessageResourceType = typeof(Resources.ResourceRoomy))]
        [Display(Name = "Date de naisance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        [Major(18, Pays = "France", ErrorMessage = "Vous devez avoir plus de {1} ans en {2}.")]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }       
    }
}