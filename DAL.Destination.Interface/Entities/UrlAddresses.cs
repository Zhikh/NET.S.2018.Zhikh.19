using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Destination.Interface.Entities
{
    public sealed class UrlAddresses
    {
        [XmlArray("urlAddresses")]
        public IEnumerable<UrlAddress> Addresses = new List<UrlAddress>();
    }
}
