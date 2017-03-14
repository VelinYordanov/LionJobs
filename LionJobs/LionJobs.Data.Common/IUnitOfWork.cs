using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Data.Common
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
