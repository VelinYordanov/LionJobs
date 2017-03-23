using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services
{
    public class CompaniesService : ICompanyService
    {
        private IEfRepository<Company> repository;
        public CompaniesService(IEfRepository<Company> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Company> GetCompanies()
        {
            return this.repository.GetAll();
        }
    }
}
