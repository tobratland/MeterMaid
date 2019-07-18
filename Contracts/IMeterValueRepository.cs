using MeterMaid3.Entities.Models;
using MeterMaid3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Contracts
{
    public interface IMeterValueRepository
    {
        IEnumerable<MeterValue> MeterValueByCustomerId(string id);
        IEnumerable<MeterValue> GetMeterValuesByMeterDataId(Guid id);
        IEnumerable<MeterValue> MeterValueByDates(DateTime from, DateTime to);
        IEnumerable<MeterValue> GetMeterValueFromDateToDateByUserId(DateTime from, DateTime to, string Id);
        IEnumerable<MeterValue> GetMeterValueFromDateToDateMeterId(DateTime from, DateTime to, string Id);
        MeterValue SaveMeterValue(MeterValue meterValue);
    }
}
