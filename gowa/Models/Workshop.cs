using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gowa.Models
{
    public class Workshop
    {
        public int WorkshopID { get; set; }
        public int Location { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Car> Car { get; set; }
    }
}