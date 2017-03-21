using LionJobs.Services;
using LionJobs.Services.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionJobs.Web.App_Start.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeesService>().InRequestScope();
        }
    }
}