using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCCL.Domain.Abstract;
using SCCL.Domain.Entities;

namespace SCCL.Domain.Concrete
{
    public class SCSYSRepository : ISolutionRepository, IServiceRepository
    {
       
        public IEnumerable<Solution> Solutions
        {
            get
            {
                List<Solution> solutions = new List<Solution>();
                var conn = DbConnection.GetConnection();
                const string cmdText = @"sp_retrieve_solutions";
                var cmd = new SqlCommand(cmdText, conn) {CommandType = CommandType.StoredProcedure};

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Solution solution = new Solution
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            };
                            solutions.Add(solution);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return solutions;
            }
        }

        public IEnumerable<Service> Services
        {
            get
            {
                List<Service> services = new List<Service>();
                var conn = DbConnection.GetConnection();
                const string cmdText = @"sp_retrieve_services";
                var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure };

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Service service = new Service
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            };
                            services.Add(service);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return services;
            }
        }
    }
}
