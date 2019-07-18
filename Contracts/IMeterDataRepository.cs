using MeterMaid3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Contracts
{
    public interface IMeterDataRepository
    {
        IEnumerable<MeterData> GetAllData();
        IEnumerable<MeterData> GetMeterDataFromDateToDate(DateTime from, DateTime to);
        MeterData GetMeterDataById(Guid id);
        MeterData SaveMeterData(MeterData meterData);
    }
}
