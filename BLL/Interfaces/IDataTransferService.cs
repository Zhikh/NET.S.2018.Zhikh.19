using DAL.Destination.Interface;
using DAL.Source.Interface;
using System;

namespace BLL.Interface
{
    public interface IDataTransferService
    {
        /// <summary>
        /// Transfers data from one storage to another
        /// </summary>
        void Transfer();
    }
}
