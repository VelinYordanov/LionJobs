using System;
using System.Collections.Generic;

namespace LionJobs.Models
{
    public class Job
    {
        public Job()
        {
            this.Id = Guid.NewGuid();
            this.Tags = new HashSet<Tag>();
            this.JobApplicants = new HashSet<ApplicationUser>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Company Company { get; set; }

        public virtual ICollection<ApplicationUser> JobApplicants { get; set; }
    }
}
