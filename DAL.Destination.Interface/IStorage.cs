using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Destination.Interface
{
    public interface IStorage<in TEntity>
    {
        void Save(IEnumerable<TEntity> entities);
    }
}
