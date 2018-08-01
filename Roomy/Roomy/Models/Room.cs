using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class Room : BaseModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Range(2, 100)]
        [Display(Name = "Capacité")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Prix")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public ICollection<RoomFile> RoomFiles { get; set; }

    }
}