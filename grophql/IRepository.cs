using grophql.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grophql
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        
    }
}
