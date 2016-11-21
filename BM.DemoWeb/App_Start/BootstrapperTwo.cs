namespace BM.DemoWeb.App_Start
{
    //public class BootstrapperTwo
    //{
    //    public static void Run()
    //    {
    //        SetAutofacContainer();
    //        //AutoMapperConfiguration.Configure();
    //    }

    //    private static void SetAutofacContainer()
    //    {
    //        var builder = new ContainerBuilder();
    //        builder.RegisterControllers(Assembly.GetExecutingAssembly());
    //        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    //        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
    //        builder.RegisterType<BirthdaysContext>().As<IBirthdaysContext>().InstancePerRequest();

    //        // Repositories
    //        builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
    //            .Where(t => t.Name.EndsWith("Repository"))
    //            .AsImplementedInterfaces().InstancePerRequest();
    //        // Services
    //        builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
    //           .Where(t => t.Name.EndsWith("Service"))
    //           .AsImplementedInterfaces().InstancePerRequest();

    //        IContainer container = builder.Build();
    //        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    //        GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    //    }
    //}
}