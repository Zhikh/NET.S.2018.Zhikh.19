using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Source.Interface
{
    public interface IDataProvider<out T>
    {
        IEnumerable<T> GetAll();
    }
}
