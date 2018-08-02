using BLL.Interface;
using DAL.Destination.Interface;
using DAL.Source.Interface;
using System;
using System.Collections.Generic;

namespace BLL
{
    public sealed class DataTransferService : IDataTransferService
    {
        private static readonly ILogger _logger = new Logger();

        private static volatile DataTransferService _instance;

        private static readonly object _syncRoot = new object();

        DataTransferService() { }

        public static DataTransferService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataTransferService();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Transfer(IDataProvider<string> provider, IStorage<Uri> storage, IParser<Uri> parser)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (storage == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }

            IEnumerable<string> data = provider.GetAll();
            List<Uri> uris = new List<Uri>();

            foreach (var element in data)
            {
                try
                {
                    uris.Add(parser.Parse(element));
                }
                catch(ArgumentException ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
            }

            storage.Save(uris);
        }
    }
}
