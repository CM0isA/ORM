using System;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;
using Persistence.Repository;

namespace ORM2.Controllers
{
    [Route("api/comands")]
    [ApiController]
    public class TimeController : ControllerBase
    {

        private readonly ITimeTracker _timeTracker;

        public TimeController(ITimeTracker tracker)
        {
            _timeTracker = tracker;

        }

        [Route("LogHours")]
        [HttpPost]
        public IActionResult LogHours(string name,
                                      DateTime dateTime,
                                      float price,
                                      string projectName,
                                      int hours)
        {
            string result;
            try
            {
                result = _timeTracker.LogHours(name, dateTime, price, projectName, hours);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(result);

        }

        [Route("Workload")]
        [HttpGet]
        public IActionResult Workload(string project)
        {
            string result;
            if (project == null)
                return BadRequest();
            else
                try
                {
                    result = _timeTracker.Workload(project);
                }
                catch (Exception)
                {
                    throw;
                }
            
            return Ok(result);
        }

        [Route("cost")]
        [HttpGet]
        public IActionResult CostperMonth(string customerName, DateTime date)
        {
            float result;
            if (customerName == null)
                return BadRequest();
            if (date == null)
                return BadRequest();
            try
            {
                result = _timeTracker.CostPerMonth(customerName, date);
            }
            catch (Exception)
            {
                throw;

            }
            return Ok(result);
        }


    }
}
