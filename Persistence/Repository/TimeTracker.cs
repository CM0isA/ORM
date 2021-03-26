using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System;
using System.Linq;


namespace Persistence.Repository
{
    public class TimeTracker : ITimeTracker
    {
        bool exist;
        private readonly ApplicationDbContext _dbContext;

        public TimeTracker(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        
        public string LogHours(string name, DateTime dateTime, float price, string projectName, int hours)
        {
            if (hours > 0 && hours <= 8)
            {
                var freelancer = _dbContext.Freelancers.FirstOrDefault(x => x.FreelancerName == name);
                if (freelancer != null)
                {
                    var logged = _dbContext.Times.Where(x => x.Freelancers.FreelancerID == freelancer.FreelancerID).ToList();
                    if (logged != null)
                    {
                        exist = false;
                        foreach (var a in logged)
                        {
                            if (a.Workday == dateTime)
                                exist = true;
                        }
                        if (exist)
                        {
                            return "The hours are already logged";
                        }
                        else
                        {
                            string result = Log(price, projectName, dateTime, hours, freelancer);
                            return result;
                        }
                    }
                    else
                    {
                        string result =  Log(price, projectName, dateTime, hours, freelancer);
                        return result;
                    }
                    
                }
                else
                    return "The freelancer is not in the database.";

            }
            else return  "The number of hours must be in between 0 and 8 per day.";
        }
        
        public string Workload(string project)
        {
            var proj = _dbContext.Projects.FirstOrDefault(x => x.ProjectName.Equals(project));//check if the given name exists in databaase

            if (proj != null)
            {
                var logged = _dbContext.Times.Include(s=> s.Price).Where(x => x.Project.ProjectID == proj.ProjectID).ToList();

                if (logged != null)
                {
                    int total = 0;
                    foreach (var a in logged)
                    {
                        total += a.Hours;
                    }

                    if (total / 8 < proj.Estimation)
                        return "Not enough workload";
                    else
                        return "Enough workload";
                }
            }
            else
                return "The name of the project doesn't exist in the given context";

            return "No answer!";
        }

        public float CostPerMonth(string customerName, DateTime date)
        {
            float cost = 0;
            var customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerName == customerName);
            if (customer == null)
                return 0;

            var projects = _dbContext.Projects.Where(x => x.Customer.CustomerID == customer.CustomerID).ToList();
            foreach( var a in projects)
            {
                var months = _dbContext.Times.Include(s=> s.Price).Where(x => x.Project.ProjectID == a.ProjectID && x.Workday.Year == date.Year && x.Workday.Month == date.Month).ToList();
                foreach(Time b in months)
                {
                    var pret = _dbContext.Prices.FirstOrDefault(x => x.PriceID == b.Price.PriceID);
                    cost += b.Hours * pret.Value;
                }
            }
            return cost;
        }

        public string Log(float price, string projectName, DateTime dateTime, int hours, Freelancer freelancer)
        {
            //get the price id
            var priceid = _dbContext.Prices.FirstOrDefault(x => x.Value == price);
            //get the project id
            var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectName == projectName);
            //log the hours
            Time time = new Time
            {
                Freelancers = freelancer,
                Workday = dateTime,
                Hours = hours,
                Project = project,
                Price = priceid
            };

            _dbContext.Times.Add(time);
            _dbContext.SaveChanges();
            return "Succcesfully!";
        }
    }
}
