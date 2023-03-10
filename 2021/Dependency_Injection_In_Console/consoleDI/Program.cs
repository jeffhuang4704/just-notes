using Microsoft.Extensions.DependencyInjection;
using System;

namespace consoleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ContainerConfiguration.Configure();

            var task = serviceProvider.GetService<SchedulerTasks>();
            task.Run();
        }
    }

    internal static class ContainerConfiguration
    {
        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IMailNotification, Notification>();
            serviceCollection.AddTransient<ITrace, Trace>();
            serviceCollection.AddSingleton<SchedulerTasks>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
