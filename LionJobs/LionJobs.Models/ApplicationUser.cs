using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using LionJobs.Models;

namespace LionJobs.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.JobHistory = new HashSet<Job>();
            this.ListedJobs = new HashSet<Job>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public byte[] Cv { get; set; }

        public virtual ICollection<Job> ListedJobs { get; set; }

        public virtual ICollection<Job> JobHistory { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
