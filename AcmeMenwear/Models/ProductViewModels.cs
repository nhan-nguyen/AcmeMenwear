using AcmeMenwear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeMenwear.Models
{
    public class ProductViewModels
    {
        public IEnumerable<AcmeMenwear.Models.Product> Products { get; set; }
        public IEnumerable<AcmeMenwear.Models.Category> Categories { get; set; }
    }
}