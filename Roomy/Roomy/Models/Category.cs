using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class Category : BaseModel
    {

        [Required]
        [StringLength(150)]
        [Display(Name = "Nom de la catégorie")]
        public string Name { get; set; }

    }
}