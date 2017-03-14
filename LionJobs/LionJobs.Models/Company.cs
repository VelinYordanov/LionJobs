using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models
{
    public class Company : ApplicationUser
    {
        public string CompanyName { get; set; }        

        public virtual ICollection<Job> ListedJobs { get; set; }
    }
}
