using System;
using Fishare.DAL.Interface;
using Fishare.DAL.Memory;

namespace Fishare.Repository
{
    public class AccountRepository
    {
        private string context;

        public AccountRepository(string _context)
        {
            context = _context;
        }

        public IAccountContext Context()
        {
           switch (this.context)
           {
                //case "MSSQL": return new AccountSQLContext(this.ConnectionString);
                case "MEMORY": return new AccountMemoryContext();
                default: throw new NotImplementedException();
           }
        }
    }
}
