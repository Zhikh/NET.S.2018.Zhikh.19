using BLL;
using BLL.Interface;
using DAL.Destination;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using DAL.Source;
using DAL.Source.Interface;
using Ninject;
using System;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IDataProvider<string>>().To<DataProvider>();
            kernel.Bind<IStorage<UrlAddress>>().To<XMLStorage>();
            kernel.Bind<IParser<Uri>>().To<Parser>();
        }
    }
}
