using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IStorage<in TEntity>
    {
        /// <summary>
        /// Saves data to storage
        /// </summary>
        /// <param name="entities"> Data for saving </param>
        void Save(IEnumerable<TEntity> entities);
    }
}
