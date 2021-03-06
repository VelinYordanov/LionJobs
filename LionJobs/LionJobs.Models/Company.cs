﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models
{
    public class Company : ApplicationUser
    {
        private ICollection<Job> listedJobs;

        public Company()
        {
            this.listedJobs = new HashSet<Job>();
        }

        [Required]
        [MinLength(5, ErrorMessage = "Company name must be at least 5 symbols long.")]
        [MaxLength(30, ErrorMessage = "Company name cannot be more than 30 symbols long.")]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(30, ErrorMessage = "Company description must be at least 30 symbols long.")]
        [MaxLength(300, ErrorMessage = "Company description cannot be more than 300 symbols long.")]
        public string Description { get; set; }

        public virtual ICollection<Job> ListedJobs
        {
            get { return this.listedJobs; }
            set { this.listedJobs = value; }
        }
    }
}
