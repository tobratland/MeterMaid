using MeterMaid3.Contracts;
using MeterMaid3.Models;
using MeterMaid3.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Repository
{
    public class MeterDataRepository : RepositoryBase<MeterData>, IMeterDataRepository
    {
        public MeterDataRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<MeterData> MeterDataByCustomerId(string customerId)
        {
            return FindByCondition(d => d.Customer_Id.Equals(customerId)).OrderByDescending(w => w.From);

        }
        public IEnumerable<MeterData> GetAllData()
        {
            return FindAll()
                .OrderBy(d => d.From)
                .ToList();

        }

        public MeterData CreateData(MeterData data)
        {

            Create(data);
            return (data);
        }

        public MeterData GetMeterDataById(Guid id)
        {
            return FindByCondition(d => d.Id.Equals(id)).DefaultIfEmpty(new MeterData()).FirstOrDefault();
        }

        public MeterData SaveMeterData(MeterData meterData)
        {
                Create(meterData);
                return (meterData);

        }

        public IEnumerable<MeterData> GetMeterDataFromDateToDate(DateTime from, DateTime to)
        {
            return FindByCondition(d => from.ToUniversalTime() <= d.From.ToUniversalTime() && to.ToUniversalTime() >= d.To.ToUniversalTime()).OrderBy(w => w.From);
        }
    }
}
