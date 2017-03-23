using LionJobs.Web.ViewModels;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionJobs.Web.App_Start.NinjectModules
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeListViewModel>().To<EmployeesListViewModel>().InRequestScope();
        }
    }
}