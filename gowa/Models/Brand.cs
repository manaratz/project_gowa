using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gowa.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}