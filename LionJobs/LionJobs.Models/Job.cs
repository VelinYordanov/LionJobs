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
            this.JobApplicants = new HashSet<Employee>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Company Company { get; set; }

        public virtual ICollection<Employee> JobApplicants { get; set; }
    }
}
