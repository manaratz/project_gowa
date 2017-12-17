using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gowa.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }
        public virtual ICollection<Car> Car { get; set; }
    }
}