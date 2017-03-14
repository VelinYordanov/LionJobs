using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models
{
    public class Employee : ApplicationUser
    {
        public Employee()
        {
            this.JobHistory = new HashSet<Job>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Cv { get; set; }

        public virtual ICollection<Job> JobHistory { get; set; }
    }
}
