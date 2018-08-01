using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Destination
{
    public sealed class XMLStorage : IStorage<UrlAddress>
    {
        public void Save(IEnumerable<UrlAddress> entities)
        {
            throw new NotImplementedException();
        }
    }
}
