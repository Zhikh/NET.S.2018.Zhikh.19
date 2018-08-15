﻿using System.Collections.Generic;

namespace DAL.Source.Interface
{
    public interface IDataProvider<out T>
    {
        /// <summary>
        /// Gets whole data from storage
        /// </summary>
        /// <returns> Collection of elemenents of type T </returns>
        IEnumerable<T> GetAll();
    }
}
