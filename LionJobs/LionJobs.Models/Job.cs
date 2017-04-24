using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LionJobs.Models
{
    public class Job
    {
        public Job()
        {
            this.Id = Guid.NewGuid();
            this.Tags = new HashSet<Tag>();
            this.JobApplicants = new HashSet<Employee>();
            this.EmployeeHistory = EmployeeHistory;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage ="Job title is required.")]
        [MinLength(5,ErrorMessage ="Job title cannot be less than 5 symbols long.")]
        [MaxLength(30,ErrorMessage ="Job title cannot be longer than 30 symbols.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Job description is required.")]
        [MinLength(10,ErrorMessage ="Job description cannot be shorter than 10 symbols.")]
        [MaxLength(100,ErrorMessage ="Job description cannot be longer than 100 symbols.")]
        public string Description { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> JobApplicants { get; set; }

        public virtual ICollection<Employee> EmployeeHistory { get; set; }
    }
}
