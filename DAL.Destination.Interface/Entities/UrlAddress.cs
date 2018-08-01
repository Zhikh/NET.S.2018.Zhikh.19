using System.Collections.Generic;

namespace DAL.Destination.Interface.Entities
{
    public sealed class UrlAddress
    {
        public string HostName;
        
        public List<string> Segments;

        public string ParametrValue;

        public string ParametrKey;
    }
}
