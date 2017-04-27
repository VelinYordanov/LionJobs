using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LionJobs.Models
{
    public class Job
    {
        private bool isDeleted = false;
        private ICollection<Employee> employeeHistory;
        private ICollection<Employee> jobApplicants;
        private ICollection<Tag> tags;

        public Job()
        {
            this.Id = Guid.NewGuid();
            this.tags = new HashSet<Tag>();
            this.employeeHistory = new HashSet<Employee>();
            this.jobApplicants = new HashSet<Employee>();
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

        public bool IsDeleted
        {
            get { return this.isDeleted; }
            set { this.isDeleted = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> JobApplicants
        {
            get { return this.jobApplicants; }
            set { this.jobApplicants = value; }
        }

        public virtual ICollection<Employee> EmployeeHistory
        {
            get { return this.employeeHistory; }
            set { this.employeeHistory = value; }
        }
    }
}
