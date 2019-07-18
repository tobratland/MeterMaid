using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Contracts
{
    public interface IRepositoryWrapper
    {
        IMeterDataRepository MeterData { get; }
        IMeterValueRepository MeterValue { get; }
        void Save();
    }
}
