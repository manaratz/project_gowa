using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gowa.Models;

namespace gowa.ViewModels
{
    public class WorkshopIndexData
    {
        public IEnumerable<Workshop> Workshops { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}