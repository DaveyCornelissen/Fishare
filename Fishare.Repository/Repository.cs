﻿using System;
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
        public readonly IRepository<TEntity> _context;

        public Repository(IRepository<TEntity> context)
        {
            _context = context;
        }

        public bool Create(TEntity entity)
        {
            return _context.Create(entity);
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public TEntity Read(int id)
        {
            return _context.Read(id);
        }

        public bool Update(TEntity entity)
        {
            return _context.Update(entity);
        }
    }
}
