using System;
using Microsoft.Extensions.Configuration;

namespace Fishare.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool create(TEntity entity);
        
        TEntity Read(string email);
        
        bool Update();
        
        bool Delete();
    }
}
