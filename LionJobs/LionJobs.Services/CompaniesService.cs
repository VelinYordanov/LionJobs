using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using System;
using System.Linq;

namespace LionJobs.Services
{
    public class CompaniesService : ICompanyService
    {
        private const int ItemsPerPage = 3;

        private IEfRepository<Company> repository;
        private IImageService imageService;

        public CompaniesService(IEfRepository<Company> repository, IImageService imageService)
        {
            if (repository == null)
            {
                throw new ArgumentException("IEfRepository in company service is null.");
            }

            if (imageService == null)
            {
                throw new ArgumentException("imageservice");
            }

            this.repository = repository;
            this.imageService = imageService;
        }

        public IQueryable<Company> GetCompanies()
        {
            return this.repository.GetAllQueryable;
        }

        public PagedCompanyViewModelList GetPagedCompanies(int page)
        {
            var maxPages = (int)Math.Ceiling(this.GetCompanies().Count() / (double)ItemsPerPage);
            var companies = this.GetCompanies().Select(x => new CompanyViewModel
            {
                CompanyName = x.CompanyName,
                Description = x.Description,
                UserImage = x.UserImage
            })
            .OrderBy(x => x.CompanyName.ToLower())
            .Skip((page - 1) * ItemsPerPage)
            .Take(ItemsPerPage).ToList();

            foreach (var company in companies)
            {
                company.UserImageUrl = this.imageService.ByteArrayToImageUrl(company.UserImage);
            }

            return new PagedCompanyViewModelList
            {
                CurrentPage = page,
                TotalPages = maxPages,
                Companies = companies
            };
        }
    }
}
