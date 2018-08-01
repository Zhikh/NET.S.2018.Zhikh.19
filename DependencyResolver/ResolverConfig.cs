using DAL.Destination;
using DAL.Destination.Interface;
using DAL.Destination.Interface.Entities;
using DAL.Source;
using DAL.Source.Interface;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IDataProvider<string>>().To<DataProvider>();
            kernel.Bind<IStorage<UrlAddress>>().To<XMLStorage>();
        }
    }
}
