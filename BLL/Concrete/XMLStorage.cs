using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class XMLStorage : IStorage<Uri>
    {
        private readonly FileInfo _file;

        public XMLStorage(FileInfo file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));
        }

        public void Save(IEnumerable<Uri> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            XDocument xDoc = new XDocument(
                new XElement("urlAddresses",
                    entities.Select(e =>
                        new XElement("urlAddress",
                        new XElement("host",
                            new XAttribute("name", e.Host)),
                            new XElement("uri",
                                e.Segments.Select(s =>
                                    new XElement("segment", s.ToString()))
                            )))
                    ));

            xDoc.Save(_file.FullName);
        }
    }
}
