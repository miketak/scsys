using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCCL.Domain.Entities;

namespace SCCL.Web.ViewModels
{
    public class SolutionServiceViewModel
    {
        public IEnumerable<Service> Services { get; set; }

        public IEnumerable<Solution> Solutions { get; set; }
    }
}