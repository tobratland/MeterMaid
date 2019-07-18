using MeterMaid3.Contracts;
using MeterMaid3.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        private readonly AppDbContext _appDbContext;
        private IMeterDataRepository _meterData;
        private IMeterValueRepository _meterValue;
        public IMeterDataRepository MeterData
        {
            get
            {
                if (_meterData == null)
                {
                    _meterData = new MeterDataRepository(_appDbContext);
                }
                return _meterData;
            }
        }
        public IMeterValueRepository MeterValue
        {
            get
            {
                if (_meterValue == null)
                {
                    _meterValue = new MeterValueRepository(_appDbContext);
                }
                return _meterValue;
            }
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
