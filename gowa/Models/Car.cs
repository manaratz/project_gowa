using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gowa.Models
{
    public class Car
    {
        public int ID { get; set; }
        public int BrandID { get; set; }
        public int WorkShopID { get; set; }
        public int ModelID { get; set; }
        public int HorsePower { get; set; }

        public virtual Workshop Workshop { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
    }
}