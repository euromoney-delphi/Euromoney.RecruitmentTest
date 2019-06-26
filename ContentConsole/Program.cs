using Autofac;
using ContentConsole.AppInterfaces;
using ContentConsole.AppServices;

namespace ContentConsole
{
    public static class Program
    {
        private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AdminInteraction>().As<IAdminInteraction>();
            builder.RegisterType<AdminMenuSelection>().As<IAdminMenuSelection>();
            builder.RegisterType<ConsoleInteraction>().As<IConsoleInteraction>();
            builder.RegisterType<NegativeWordStore>().As<INegativeWordStore>().InstancePerLifetimeScope(); // For shared instance
            builder.RegisterType<UserInteraction>().As<IUserInteraction>();
            builder.RegisterType<UserMenuSelection>().As<IUserMenuSelection>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ContentConsole>().AsSelf();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var contentConsole = scope.Resolve<ContentConsole>();
                contentConsole.Start();
            }
        }
    }
}
