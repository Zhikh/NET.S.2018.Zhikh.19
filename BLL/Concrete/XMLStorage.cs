using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class XMLStorage : IStorage<UrlAddress>
    {
        private readonly FileInfo _file;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLStorage"/>.
        /// </summary>
        /// <param name="fileInfo"> Database connection string. </param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="fileInfo"> is null or empty. </paramref>
        /// </exception>
        public XMLStorage(FileInfo fileInfo)
        {
            _file = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));
        }

        /// <summary>
        /// Saves data to XML-file
        /// </summary>
        /// <param name="entities"> Collection of the <see cref="Uri"/> elements. </param>
        public void Save(IEnumerable<UrlAddress> entities)
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
                            new XAttribute("name", e.HostName)),
                            new XElement("uri",
                                e.Segments.Select(s =>
                                    new XElement("segment", s.ToString()))
                            )))
                    ));


            xDoc.Save(_file.FullName);
        }
    }
}
