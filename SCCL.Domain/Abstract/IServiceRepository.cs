using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCCL.Domain.Entities;

namespace SCCL.Domain.Abstract
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Services { get; } 
    }
}
