using System.Collections.Generic;

namespace SCCL.Domain.Entities
{
    public class Solution
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Service> SolServices { get; set; }

    }
}