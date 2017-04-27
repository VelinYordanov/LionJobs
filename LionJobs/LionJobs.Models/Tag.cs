using System;
using System.Collections.Generic;

namespace LionJobs.Models
{
    public class Tag
    {
        private ICollection<Job> jobs;

        public Tag()
        {
            this.Id = Guid.NewGuid();
            this.jobs = new HashSet<Job>();
        }

        public Guid Id { get; set; }

        public TagType TagText { get; set; }

        public virtual ICollection<Job> Jobs
        {
            get { return this.jobs; }
            set { this.jobs = value; }
        }
    }
}
