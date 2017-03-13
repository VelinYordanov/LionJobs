using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string TagText { get; set; }
    }
}
