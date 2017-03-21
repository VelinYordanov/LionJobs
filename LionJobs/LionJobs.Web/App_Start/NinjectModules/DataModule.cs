using LionJobs.Data;
using LionJobs.Data.Common;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LionJobs.Web.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();
            Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>)).InRequestScope();
            Bind<IUnitOfWork>().To<EfUnitOfWork>().InRequestScope();
        }
    }
}