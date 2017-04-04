using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SCCL.Domain.Entities;

namespace SCCL.Domain.DataAccess
{
    public class ServicesAccessor
    {
        public static List<Service> RetrieveServices()
        {
            var services = new List<Service>();
            var conn = DbConnection.GetConnection();
            const string cmdText = @"sp_retrieve_services";

            using (var cmd = new SqlCommand(cmdText, conn) {CommandType = CommandType.StoredProcedure})
            {
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            var service = new Service
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            };
                            services.Add(service);
                        }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return services;

        }
    }
}