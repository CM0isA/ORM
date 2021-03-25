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

        public void LogHours(string name, DateTime dateTime, float price, string projectName, int hours)
        {
            if (hours > 0 && hours <= 8)
            {
                var freelancers = _dbContext.freelancers.FirstOrDefault(x => x.freelancer == name);
                if (freelancers != null)
                {
                    var logged = _dbContext.times.Where(x => x.FreelancerID.freelancerID == freelancers.freelancerID).ToList();
                    if (logged != null)
                    {
                        exist = false;
                        foreach (var a in logged)
                        {
                            if (a.workday == dateTime)
                                exist = true;
                        }
                        if (exist)
                        {
                            throw new SystemException("The hours are already logged");
                        }
                        else
                        {
                            //get the price id
                            var priceid = _dbContext.Prices.FirstOrDefault(x => x.price == price);
                            //get the project id
                            var project = _dbContext.projects.FirstOrDefault(x => x.ProjectName == projectName);
                            //log the hours
                            Time time = new Time();
                            time.FreelancerID.freelancerID = freelancers.freelancerID;
                            time.workday = dateTime;
                            time.hours = hours;
                            time.project.projectID = project.projectID;

                            _dbContext.times.Add(time);
                            _dbContext.SaveChanges();

                        }

                    }
                }
                else
                    throw new System.Exception("Missing Argument");

            }
            else throw new Exception("The number of hours must be in between 0 and 8 per day.");



        }

        public string Workload(string project)
        {


            var proj = _dbContext.projects.FirstOrDefault(x => x.ProjectName.Equals(project));

            if (proj != null)
            {
                var logged = _dbContext.times.Where(x => x.project.projectID == proj.projectID).ToList();

                if (logged != null)
                {
                    int total = 0;
                    foreach (var a in logged)
                    {
                        total += a.hours;
                    }

                    if (total / 8 < proj.estimation)
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
            var customer = _dbContext.Customers.FirstOrDefault(x => x.customer == customerName);

            var projects = _dbContext.projects.Where(x => x.customer.customerID == customer.customerID);
            foreach( var a in projects)
            {
                var months = _dbContext.times.Where(x => x.project.projectID == a.projectID && x.workday.Year == date.Year && x.workday.Month == date.Month);
                foreach(Time b in months)
                {
                    var pret = _dbContext.Prices.FirstOrDefault(x => x.priceID == b.price.priceID);
                    cost += b.hours * pret.price;
                }
            }
            return cost;
        }
    }
}
