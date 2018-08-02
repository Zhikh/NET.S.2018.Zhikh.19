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
using System.IO;
using System.Configuration;
using DAL.Source;
using DAL.Destination;

namespace UI.Console
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            var txtFile = new FileInfo(ConfigurationManager.AppSettings["txtPath"]);
            var xmlFile = new FileInfo(ConfigurationManager.AppSettings["xmlPath"]);

            resolver = new StandardKernel();
            resolver.ConfigurateResolver(txtFile, xmlFile);
        }

        static void Main(string[] args)
        {
            var service = DataTransferService.Instance;
            
            service.Transfer(resolver.Get<IDataProvider<string>>(),
                resolver.Get<IStorage<Uri>>(), resolver.Get<IParser<Uri>>());

            System.Console.WriteLine(resolver.Get<IStorage<Uri>>().GetContent());

            System.Console.ReadKey();
        }
    }
}
