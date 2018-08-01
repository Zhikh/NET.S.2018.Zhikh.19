using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Destination.Interface.Entities
{
    class UrlAddresses
    {
        [XmlArray("urlAddresses")]
        public List<UrlAddress> Addresses = new List<UrlAddress>();
    }
}
