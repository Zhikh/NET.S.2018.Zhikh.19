using DAL.Destination.Interface;
using DAL.Source.Interface;
using System;

namespace BLL.Interface
{
    public interface IDataTransferService
    {
        void Transfer(IDataProvider<string> provider, IStorage<Uri> storage, IParser<Uri> parser);
    }
}
