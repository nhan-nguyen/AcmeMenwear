using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcmeMenwear.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}