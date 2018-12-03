using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Select();
        void Create(T model);
        void Update(T model);
        void Remove(T model);
    }
}
