using System;

namespace Fishare.Repository.Interface
{
    public interface IRepository
    {
        bool create();
        
        bool Read();
        
        bool Update();
        
        bool Delete();
    }
}
