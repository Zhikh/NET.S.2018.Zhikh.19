using BLL.Interface;
using BLL.Mappers;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using DAL.Source.Interface;
using System;
using System.Collections.Generic;

namespace BLL
{
    public sealed class DataTransferService : IDataTransferService
    {
        private IDataProvider<string> _provider;
        private IStorage<UrlAddress> _storage;
        private IParser<Uri> _parser;

        public DataTransferService(IDataProvider<string> provider, IStorage<UrlAddress> storage, IParser<Uri> parser)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public void Transfer()
        {
            IEnumerable<string> data = _provider.GetAll();

            IEnumerable<Uri> uris = _parser.Parse(data);

            _storage.Save(uris.ToUrlAddress());
        }
    }
}
