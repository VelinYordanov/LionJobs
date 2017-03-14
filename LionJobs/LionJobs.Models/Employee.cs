using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage ="First name is required.")]
        [MinLength(2,ErrorMessage ="First name cannot be less than 2 symbols long.")]
        [MaxLength(15,ErrorMessage ="First name cannot me longer than 30 symbols.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name cannot be less than 2 symbols long.")]
        [MaxLength(15, ErrorMessage = "Last name cannot me longer than 30 symbols.")]
        public string LastName { get; set; }

        public byte[] Cv { get; set; }

        public virtual ICollection<Job> JobHistory { get; set; }
    }
}
