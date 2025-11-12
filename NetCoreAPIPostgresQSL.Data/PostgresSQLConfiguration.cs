using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgresQSL.Data
{
    public class PostgresSQLConfiguration
    {
        public PostgresSQLConfiguration(string connectionstring) => connectionstring = connectionstring;
        public string ConnectionString { get; set; }
    }
}
