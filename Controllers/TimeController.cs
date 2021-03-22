using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORM2.Models;
using ORM2.Repository;

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
        public async Task<IActionResult> LogHours(string name,
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
        public async Task<IActionResult> Workload(string project)
        {
            var result = _timeTracker.Workload(project);
            return Ok(result);
        }
        [Route("cost")]
        [HttpGet]
        public async Task<IActionResult> CostperMonth(string customerName, DateTime date)
        {
            var result = _timeTracker.CostPerMonth(customerName, date);
            return Ok(result);
        }


    }
}
