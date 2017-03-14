using System;
using System.Collections.Generic;

namespace LionJobs.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Id = Guid.NewGuid();
            this.Jobs = new HashSet<Job>();
        }

        public Guid Id { get; set; }

        public TagType TagText { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
