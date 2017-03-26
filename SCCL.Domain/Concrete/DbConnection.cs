using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCCL.Domain.Concrete
{
    class DbConnection
    {
        internal static SqlConnection GetConnection()
        {
            const string connString = @"Data Source=localhost;Initial Catalog=SCSYSDB;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
