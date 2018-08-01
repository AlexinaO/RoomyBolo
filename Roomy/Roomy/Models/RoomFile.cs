using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class RoomFile : BaseModel
    {
        [Required]
        [StringLength(254)]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Content type")]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

    }

    
}