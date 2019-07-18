using MeterMaid3.Contracts;
using MeterMaid3.Entities.Models;
using MeterMaid3.Models;
using MeterMaid3.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Repository
{
    public class MeterValueRepository : RepositoryBase<MeterValue>, IMeterValueRepository
    {
        public MeterValueRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<MeterValue> GetMeterValueFromDateToDateByUserId(DateTime from, DateTime to, string Id)
        {
            return FindByCondition(d => from.ToUniversalTime() <= d.Hour.ToUniversalTime() && to.ToUniversalTime() >= d.Hour.ToUniversalTime() && d.Custormer_Id.Equals((Id))).OrderBy(w => w.Hour);
        }

        public IEnumerable<MeterValue> GetMeterValueFromDateToDateMeterId(DateTime from, DateTime to, string Id)
        {
            return FindByCondition(d => from.ToUniversalTime() <= d.Hour.ToUniversalTime() && to.ToUniversalTime() >= d.Hour.ToUniversalTime() && d.Meter_Id.Equals((Id))).OrderBy(w => w.Hour);
        }

        public IEnumerable<MeterValue> GetMeterValuesByMeterDataId(Guid id)
        {
            return FindByCondition(d => d.MeterDataId.Equals(id)).OrderBy(w => w.Hour);
            
            
        }

        public IEnumerable<MeterValue> MeterValueByCustomerId(string id)
        {
            return FindByCondition(d => d.Custormer_Id.Equals(id)).OrderBy(w => w.Hour);

        }

        public IEnumerable<MeterValue> MeterValueByDates(DateTime from, DateTime to)
        {
            return FindByCondition(d => d.Hour.ToUniversalTime() > from.ToUniversalTime() && d.Hour.ToUniversalTime() < to.ToUniversalTime()).OrderBy(w => w.Hour);
        }

        public IEnumerable<MeterValue> MeterValueByMeterId(string id)
        {
            return FindByCondition(d => d.Meter_Id.Equals(id)).OrderByDescending(w => w.Hour);

        }

        public MeterValue SaveMeterValue(MeterValue meterValue)
        {
            Create(meterValue);
            return (meterValue);
        }
    }
}
