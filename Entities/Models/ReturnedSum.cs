using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Entities.Models
{
    public class ReturnedSum
    {
        public string TypeOfSum { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        
        public string Id { get; set; }
        public double Sum { get; set; }
    }
}
