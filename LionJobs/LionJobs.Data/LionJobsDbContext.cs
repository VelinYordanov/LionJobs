using LionJobs.Models;
using System.Data.Entity;

namespace LionJobs.Data
{
    public class LionJobsDbContext :DbContext
    {
        public LionJobsDbContext():base("LionJobsDb")
        {
            
        }

        public IDbSet<Job> Jobs { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Company> Companies { get; set; }
    }
}
