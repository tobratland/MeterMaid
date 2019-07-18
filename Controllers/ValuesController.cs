using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeterMaid3.Contracts;
using MeterMaid3.Entities;
using MeterMaid3.Entities.ExtendedModels;
using MeterMaid3.Entities.Models;
using MeterMaid3.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MeterMaid3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public ValuesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var returnedArray = new ArrayList();
                var returnedMeterData = _repository.MeterData.GetAllData();
                foreach (var rmd in returnedMeterData)
                {
                    var id = rmd.Id;
                    var returnedMeterValuesByMeterId = _repository.MeterValue.GetMeterValuesByMeterDataId(id);
                    var arr = new ArrayList();
                    foreach (var rmv in returnedMeterValuesByMeterId)
                    {
                        var meterReturnedValue = new MeterValueReturned
                        {
                            Hour = rmv.Hour,
                            Value = rmv.Value
                        };
                        arr.Add(meterReturnedValue);
                    }
                    var meterDataExtended = new MeterDataExtended
                    {
                        Id = rmd.Id,
                        Meter_Id = rmd.Meter_Id,
                        Customer_Id = rmd.Customer_Id,
                        Resolution = rmd.Resolution,
                        From = rmd.From,
                        To = rmd.To,
                        Values = arr
                    };
                    returnedArray.Add(meterDataExtended);

                }

                return Ok(returnedArray);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name ="MeterDataById")]
        public IActionResult GetMeterDataById(Guid id)
        {
            try
            {
                var arr = new ArrayList();
                var meterData = _repository.MeterData.GetMeterDataById(id);
                var meterValue = _repository.MeterValue.GetMeterValuesByMeterDataId(meterData.Id);
                foreach(var v in meterValue)
                {
                    var returnedValue = new MeterValueReturned
                    {
                        Hour = v.Hour,
                        Value = v.Value
                    };
                    arr.Add(returnedValue);
                }
                var meterDataExtended = new MeterDataExtended
                {
                    Id = meterData.Id,
                    Meter_Id = meterData.Meter_Id,
                    Customer_Id = meterData.Customer_Id,
                    Resolution = meterData.Resolution,
                    From = meterData.From,
                    To = meterData.To,
                    Values = arr
                };
                return Ok(meterDataExtended);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("customer/{id}", Name = "MeterValuesByCustomerId")]
        public IActionResult GetMeterDataById(string id)
        {
            try
            {
                return Ok(_repository.MeterValue.MeterValueByCustomerId(id));
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{fromDateTime}/{toDateTime}/customer:{id}")]
        public IActionResult GetSumOfUsageByDateAndCustomerId(DateTime fromDateTime, DateTime toDateTime, string id)
        {
            try
            {
                var returnedData = new ReturnedSum
                {
                    TypeOfSum = "All usage for all meters for customer, in given period, summed ",
                    From = fromDateTime.ToUniversalTime(),
                    To = toDateTime.ToUniversalTime(),
                    Id = id,
                    Sum = 0.0
                };
                var ReturnedMeterValues = _repository.MeterValue.GetMeterValueFromDateToDateByUserId(fromDateTime.ToUniversalTime(), toDateTime.ToUniversalTime(), id);
                
                foreach(var v in ReturnedMeterValues)
                {
                    returnedData.Sum += v.Value;

                }
                return Ok(returnedData);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{fromDateTime}/{toDateTime}/meter:{id}")]
        public IActionResult GetSumOfUsageByDateAndMeterId(DateTime fromDateTime, DateTime toDateTime, string id)
        {
            try
            {
                var returnedData = new ReturnedSum
                {
                    TypeOfSum = "All values for meter, in given period, summed ",
                    From = fromDateTime.ToUniversalTime(),
                    To = toDateTime.ToUniversalTime(),
                    Id = id,
                    Sum = 0.0
                };
                var ReturnedMeterValues = _repository.MeterValue.GetMeterValueFromDateToDateMeterId(fromDateTime.ToUniversalTime(), toDateTime.ToUniversalTime(), id);

                foreach (var v in ReturnedMeterValues)
                {
                    returnedData.Sum += v.Value;

                }
                return Ok(returnedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{fromDateTime}/{toDateTime}")]
        public IActionResult GetMeterDataByDate(DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {
                var returnedArray = new ArrayList();
                var returnedMeterData = _repository.MeterData.GetMeterDataFromDateToDate(fromDateTime.ToUniversalTime(), toDateTime.ToUniversalTime());
                foreach(var rmd in returnedMeterData)
                {
                    var id = rmd.Id;
                    var returnedMeterValuesByMeterId = _repository.MeterValue.GetMeterValuesByMeterDataId(id);
                    var arr = new ArrayList();
                    foreach(var rmv in returnedMeterValuesByMeterId)
                    {
                        var meterReturnedValue = new MeterValueReturned
                        {
                            Hour = rmv.Hour,
                            Value = rmv.Value
                        };
                        arr.Add(meterReturnedValue);
                    }
                    var meterDataExtended = new MeterDataExtended
                    {
                        Id = rmd.Id,
                        Meter_Id = rmd.Meter_Id,
                        Customer_Id = rmd.Customer_Id,
                        Resolution = rmd.Resolution,
                        From = rmd.From,
                        To = rmd.To,
                        Values = arr
                    };
                    returnedArray.Add(meterDataExtended);
                    
                }
                return Ok(returnedArray);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {

            
            MeterData mdata = new MeterData
            {
                Id = Guid.NewGuid(),
                Meter_Id = data["meter_id"].ToString(),
                Customer_Id = data["customer_id"].ToString(),
                Resolution = data["resolution"].ToString(),
                From = DateTime.Parse(data["from"].ToString()),
                To = DateTime.Parse(data["to"].ToString()),
            };
            var savedMData  = _repository.MeterData.SaveMeterData(mdata);
            _repository.Save();

            ArrayList arr = new ArrayList();
            var jobj = JObject.Parse(data.ToString());
            var values = jobj["values"];
            var dict = JsonConvert.DeserializeObject<Dictionary<DateTime, double>>
                          (values.ToString());


            foreach (var item in dict)
            {
                var meterValue = new MeterValue
                {
                    Id = Guid.NewGuid(),
                    MeterDataId = mdata.Id,
                    Meter_Id = mdata.Meter_Id,
                    Custormer_Id = mdata.Customer_Id,
                    Hour = item.Key,
                    Value = item.Value

                };
                var returnedMeterValue = new MeterValueReturned
                {
                    Hour = item.Key,
                    Value = item.Value
                };
                _repository.MeterValue.SaveMeterValue(meterValue);
                arr.Add(returnedMeterValue);
                _repository.Save();
            }

            MeterDataExtended returnedMeterData = new MeterDataExtended
            {
                Id = savedMData.Id,
                Meter_Id = savedMData.Meter_Id,
                Customer_Id = savedMData.Customer_Id,
                Resolution = savedMData.Resolution,
                From = savedMData.From,
                To = savedMData.To,
                Values = arr
            };

                return Ok(returnedMeterData);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

    }
}
