using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcmeMenwear.Models
{
    public class Slide
    {
        public int SlideId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Link cannot be longer than 100 characters.")]
        public string SlideLink { get; set; }

        public string SlideDescription { get; set; }

        public virtual ICollection<SlideImg> SlideImg { get; set; }
    }
}