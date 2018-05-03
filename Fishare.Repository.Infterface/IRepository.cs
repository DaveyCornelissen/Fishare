using System;
using Microsoft.Extensions.Configuration;

namespace Fishare.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Create(TEntity entity);
        
        TEntity Read(int Id);
        
        bool Update(TEntity entity);
        
        bool Delete();
    }
}
