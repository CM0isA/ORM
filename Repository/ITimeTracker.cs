using ORM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM2.Repository
{
    public interface ITimeTracker
    {
        public void LogHours(string name, DateTime dateTime, float price, string projectName, int hours);

        public string Workload(string project);

        public float CostPerMonth(string customerName, DateTime date);

        public List<Price> GetAll();
    }
}
