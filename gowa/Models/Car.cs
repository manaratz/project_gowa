using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gowa.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Display(Name ="Workshop")]
        public int WorkShopID { get; set; }
        [Display(Name ="Model")]
        public int ModelID { get; set; }
        [Display(Name = "Horse Power"),Range(1,1000,ErrorMessage = "Please enter a value bigger than {1}")]
        public int HorsePower { get; set; }

        public virtual Workshop Workshop { get; set; }
        public virtual Model Model { get; set; }
    }
}