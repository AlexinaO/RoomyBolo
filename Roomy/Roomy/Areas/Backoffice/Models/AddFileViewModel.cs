using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Areas.Backoffice.Models
{
    public class AddFileViewModel
    {
        [Required]
        public int RoomID { get; set; }

        [Required]
        [Display(Name = "Fichier")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase FileUpload { get; set; }
    }
}