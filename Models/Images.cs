using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImageUploadEF.Models
{
    [Table("Images")]
    public class Images
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(20), Required]
        public string Name { get; set; }
        public string ImageFileName { get; set; }
        [NotMapped]
        public HttpPostedFileBase FileBase { get; set; }

    }
}