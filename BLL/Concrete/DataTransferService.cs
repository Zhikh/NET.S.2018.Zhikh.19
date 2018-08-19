using System;
using System.Collections.Generic;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class DataTransferService : IDataTransferService
    {
        #region Fields
        private static readonly ILogger _logger = new Logger();

        private IDataProvider<string> _provider;
        private IStorage<Uri> _storage;
        private IParser<Uri> _parser;
        #endregion

        #region Public API
        // <summary>
        /// Initializes a new instance of the <see cref="DataTransferService"/>
        /// </summary>
        /// <param name="provider"> Data provider from a file </param>
        /// <param name="storage"> Database storage </param>
        /// <param name="parser"> Data parser </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="provider" /> is null.
        ///     <paramref name="storage" /> is null.
        ///     <paramref name="parser" /> is null.
        /// </exception>
        public DataTransferService(IDataProvider<string> provider, IStorage<Uri> storage, IParser<Uri> parser)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        /// <summary>
        /// Transfers data from one storage to another
        /// </summary>
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
        #endregion
    }
}
