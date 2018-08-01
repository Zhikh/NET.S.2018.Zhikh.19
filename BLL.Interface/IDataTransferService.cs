using DAL.Destination.Interface;
using DAL.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDataTransferService<ProviderOut, StorageIn>
    {
        void Transfer(IDataProvider<ProviderOut> provider, IStorage<StorageIn> storage);
    }
}
