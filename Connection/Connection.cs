using System;
using Microsoft.Extensions.Configuration;

namespace Fishare.Connection
{
    public class Connection
    {
        public readonly string Context;

        public readonly string ConnectionString;

        public Connection(IConfiguration Config)
        {
            this.Context = Config.GetSection("Database")["Type"];
            this.ConnectionString = Config.GetSection("ConnectionStrings")[Context];
        }
    }
}
