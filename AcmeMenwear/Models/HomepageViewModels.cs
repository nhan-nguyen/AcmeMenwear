using AcmeMenwear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeMenwear.Models
{
    public class HomepageViewModels
    {
        public IEnumerable<AcmeMenwear.Models.Product> Products { get; set; }
        public IEnumerable<AcmeMenwear.Models.Slide> Slides { get; set; }
    }
}