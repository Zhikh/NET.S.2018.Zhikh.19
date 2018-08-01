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
    public sealed class DataTransferService : IDataTransferService
    {
        private IDataProvider<string> _provider;
        private IStorage<UrlAddress> _storage;

        public DataTransferService(IDataProvider<string> provider, IStorage<UrlAddress> storage)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }
    }
}
