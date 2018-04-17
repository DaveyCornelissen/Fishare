using System;
using System.Collections.Generic;
using System.Text;
using Fishare.DAL;
using Fishare.DAL.Memory;
using Fishare.DAL.SQL;
using Fishare.Model;
using Fishare.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace Fishare.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        public bool create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public TEntity Read(string email)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
