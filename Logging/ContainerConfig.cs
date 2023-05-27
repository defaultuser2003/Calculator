using Autofac;

namespace Logging
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new FileLogger("log.txt")).As<ILogger>();

            return builder.Build();
        }
    }
}
