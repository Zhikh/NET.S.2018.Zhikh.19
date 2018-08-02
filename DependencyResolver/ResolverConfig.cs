using BLL;
using BLL.Interface;
using DAL.Destination;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using DAL.Source;
using DAL.Source.Interface;
using Ninject;
using System;
using System.IO;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel, FileInfo providerFile, FileInfo storageFile)
        {
            kernel.Bind<IDataProvider<string>>().To<DataProvider>().WithConstructorArgument(providerFile);
            kernel.Bind<IStorage<Uri>>().To<XMLStorage>().WithConstructorArgument(storageFile);
            kernel.Bind<IParser<Uri>>().To<Parser>();
        }
    }
}
