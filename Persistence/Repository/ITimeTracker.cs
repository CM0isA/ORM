using Persistence.Models;
using System;
using System.Collections.Generic;

namespace Persistence.Repository
{
    public interface ITimeTracker
    {
        public string LogHours(string name, DateTime dateTime, float price, string projectName, int hours);

        public string Workload(string project);

        public float CostPerMonth(string customerName, DateTime date);

    }
}
