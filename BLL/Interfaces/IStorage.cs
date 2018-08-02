using System.Collections.Generic;
using System.Xml.Linq;

namespace DAL.Destination.Interface
{
    public interface IStorage<in TEntity>
    {
        void Save(IEnumerable<TEntity> entities);

        XDocument GetContent();
    }
}
