using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Source.Interface;

namespace DAL.Source
{
    public sealed class DataProvider : IDataProvider<string>
    {
        public IEnumerable<string> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
