using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using Fishare.DAL.Interface;
using Fishare.DAL.Memory;
using Fishare.DAL.SQL;
using Fishare.Logic;

namespace Fishare.Factory
{
    public class Factory
    {
        private readonly string ConnectionString;

        private readonly string Context;

        public Factory(IConfiguration Config)
        {
            this.Context = Config.GetSection("Database")["Type"];
            this.ConnectionString = Config.GetSection("ConnectionStrings")[Context];
        }

        private IAccountContext CreateContext()
        {
            switch (this.Context)
            {
                //case "MSSQL": return new AccountSQLContext(this.ConnectionString);
                case "MEMORY": return new AccountMemoryContext();
                default: throw new NotImplementedException();
            }
        }

        public AccountLogic AccountInfo() => new AccountLogic(this.CreateContext());
    }
}
