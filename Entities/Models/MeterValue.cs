using MeterMaid3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Models
{
    public class MeterValue: IEntity
    {
        public Guid Id { get; set; }
        public Guid MeterDataId { get; set; }
        public string Meter_Id { get; set; }
        public string Custormer_Id { get; set; }
        public DateTime Hour { get; set; }
        public double Value { get; set; }
    }
}
