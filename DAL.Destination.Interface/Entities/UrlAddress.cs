using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Destination.Interface.Entities
{
    public sealed class UrlAddress
    {
        public string HostName { get; set; }

        public IEnumerable<string> Segments { get; set; } 

        public string ParametrValue { get; set; }

        public string ParametrKey { get; set; }
    }
}
