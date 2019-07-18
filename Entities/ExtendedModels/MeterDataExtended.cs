using MeterMaid3.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Entities.ExtendedModels
{
    public class MeterDataExtended: IEntity
    {
        public Guid Id { get; set; }
        public string Meter_Id { get; set; }
        public string Customer_Id { get; set; }
        public string Resolution { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ArrayList Values { get; set; }
        public MeterDataExtended()
        {
        }

        public MeterDataExtended(MeterData data)
        {
            Id = data.Id;
            Meter_Id = data.Meter_Id;
            Customer_Id = data.Customer_Id;
            Resolution = data.Resolution;
            From = data.From;
            To = data.To;

        }
    }

}
