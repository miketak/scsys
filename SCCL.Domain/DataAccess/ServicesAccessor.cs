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

        public static bool CreateService(Service service)
        {
            var rowsAffected = 0;

            var conn = DbConnection.GetConnection();
            var cmdText = @"sp_create_service";

            using (var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Name", service.Name);
                cmd.Parameters.AddWithValue("@Description", service.Description);

                try
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return rowsAffected == 1;
        }

        public static bool UpdateSolution(Service oldService, Service newService)
        {
            var rowsAffected = 0;

            var conn = DbConnection.GetConnection();
            var cmdText = @"sp_update_service";

            using (var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Id", oldService.Id);

                cmd.Parameters.AddWithValue("@OldName", oldService.Name);
                cmd.Parameters.AddWithValue("@OldDescription", oldService.Description);

                cmd.Parameters.AddWithValue("@NewName", newService.Name);
                cmd.Parameters.AddWithValue("@NewDescription", newService.Description);

                try
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return rowsAffected == 1;
        }

        public static bool DeleteService(int id)
        {
            var rowsAffected = 0;

            var conn = DbConnection.GetConnection();
            var cmdText = @"sp_delete_service";

            using (var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return rowsAffected == 1;
        }
    }
}