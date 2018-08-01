using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyResolver;
using BLL;
using DAL.Source.Interface;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using BLL.Interface;

namespace UI.Console
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            var service = new DataTransferService(resolver.Get<IDataProvider<string>>(), 
                resolver.Get<IStorage<UrlAddress>>(), resolver.Get<IParser<Uri>>());

            service.Transfer();

            System.Console.WriteLine(resolver.Get<IStorage<UrlAddress>>().GetContent());

            System.Console.ReadKey();
        }
    }
}
