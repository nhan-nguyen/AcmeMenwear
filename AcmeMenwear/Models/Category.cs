using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeMenwear.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Product> Product { get; set; }
    }
}