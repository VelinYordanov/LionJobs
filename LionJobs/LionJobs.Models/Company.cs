using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models
{
    public class Company :IdentityUser
    {
        public string CompanyName { get; set; }

        public byte[] UserImage { get; set; }

        public virtual ICollection<Job> ListedJobs { get; set; }
    }
}
