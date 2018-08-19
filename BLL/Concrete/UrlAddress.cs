using System.Collections.Generic;

namespace BLL.Concrete
{
    public sealed class UrlAddress
    {
        public string HostName;
        
        public List<string> Segments;

        public string ParametrValue;

        public string ParametrKey;
    }
}
