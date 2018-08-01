using BLL.Interface;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using DAL.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public sealed class DataTransferService : IDataTransferService<string, UrlAddress>
    {
        public void Transfer(IDataProvider<string> provider, IStorage<UrlAddress> storage)
        {
            throw new NotImplementedException();
        }
    }
}
