using System;

namespace Fishare.DAL.Interface
{
    public interface IContext
    {
        bool create();

        bool Read();

        bool Update();

        bool Delete();
    }
}
