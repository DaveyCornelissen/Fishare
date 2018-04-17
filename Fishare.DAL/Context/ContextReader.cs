using System;
using Microsoft.Extensions.Configuration;

namespace Fishare.DAL
{
    public class ContextReader
    {
        public string Context { get; private set; }

        public string ConnectionString { get; private set; }

        public ContextReader(IConfiguration config)
        {
            Context = config.GetSection("Database")["Type"];
            ConnectionString = config.GetSection("ConnectionStrings")[Context];
        }
    }
}
