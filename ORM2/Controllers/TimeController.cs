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

            _timeTracker.LogHours(name, dateTime, price, projectName, hours);
            return Ok();

        }

        [Route("Workload")]
        [HttpGet]
        public IActionResult Workload(string project)
        {
            var result = _timeTracker.Workload(project);
            return Ok(result);
        }

        [Route("cost")]
        [HttpGet]
        public IActionResult CostperMonth(string customerName, DateTime date)
        {
            float result = 0;
            result = _timeTracker.CostPerMonth(customerName, date);
            //try
            //{
                
            //}
            //catch (Exception e)
            //{
                
                
            //}
            
            return Ok(result);
        }


    }
}
