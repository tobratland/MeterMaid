using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Entities.Models
{
    public class MeterValueReturned
    {
        public DateTime Hour { get; set; }
        public double Value { get; set; }
    }
}
