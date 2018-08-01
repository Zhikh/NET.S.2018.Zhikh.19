using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL.Destination
{
    public sealed class XMLStorage : IStorage<UrlAddress>
    {
        private readonly FileInfo _file;

        public XMLStorage(FileInfo file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));
        }

        public XDocument GetContent()
        {
            return XDocument.Load(_file.Name);
        }

        public void Save(IEnumerable<UrlAddress> entities)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UrlAddresses));

            UrlAddresses urlAddresses = new UrlAddresses
            {
                Addresses = entities
            };

            using (Stream stream = _file.OpenWrite())
            {
                serializer.Serialize(stream, urlAddresses);
            }
        }
    }
}
