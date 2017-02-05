using BM.Data.EF;
using BM.Data.Infrastructure;
using BM.Service.Interfaces;
using Ninject.Modules;

namespace BM.Service.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
