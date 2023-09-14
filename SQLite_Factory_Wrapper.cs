using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_14_09
{
    internal class SQLite_Factory_Wrapper : I_Provider_Factory_Wrapper
    {
        private readonly DbProviderFactory factory;

        public SQLite_Factory_Wrapper()
        {
            factory = DbProviderFactories.GetFactory("System.Data.SQLite");
        }

        public async Task<DbConnection> CreateConnection()
        {
            var connection = factory.CreateConnection();
            connection.ConnectionString = Connection_string;
            await connection.OpenAsync();
            return connection;
        }

        public string Connection_string { get; set; }
    }
}
