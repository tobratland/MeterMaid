using MeterMaid3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Models
{
    public class MeterData: IEntity
    {
        public Guid Id { get; set; }
        public string Meter_Id { get; set; }
        public string Customer_Id { get; set; }
        public string Resolution { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
