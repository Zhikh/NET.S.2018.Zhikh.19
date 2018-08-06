using BLL.Interface;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using DAL.Source.Interface;
using System;
using System.Collections.Generic;

namespace BLL
{
    public sealed class DataTransferService : IDataTransferService
    {
        private static readonly ILogger _logger = new Logger();

        private IDataProvider<string> _provider;
        private IStorage<Uri> _storage;
        private IParser<Uri> _parser;

        public DataTransferService(IDataProvider<string> provider, IStorage<Uri> storage, IParser<Uri> parser)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public void Transfer()
        {
            IEnumerable<string> data = _provider.GetAll();
            List<Uri> uris = new List<Uri>();

            foreach (var element in data)
            {
                try
                {
                    uris.Add(_parser.Parse(element));
                }
                catch(ArgumentException ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
            }

            _storage.Save(uris);
        }
    }
}
