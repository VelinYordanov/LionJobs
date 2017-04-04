using LionJobs.Models;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Interfaces
{
    public interface ICompanyService
    {
        IQueryable<Company> GetCompanies();

        PagedCompanyViewModelList GetPagedCompanies(int page);
    }
}
