using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crimson.DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetAt(int id);
        void Create(T item);
        void Update(T item);
        void DeleteAt(int index);
    }
}
