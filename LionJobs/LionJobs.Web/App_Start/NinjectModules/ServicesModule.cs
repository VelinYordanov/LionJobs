﻿using LionJobs.Services;
using LionJobs.Services.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;

namespace LionJobs.Web.App_Start.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeesService>().InRequestScope();
            Bind<IImageService>().To<ImageService>().InRequestScope();
            Bind<ICompanyService>().To<CompaniesService>().InRequestScope();
        }
    }
}