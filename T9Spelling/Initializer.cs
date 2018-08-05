using System.Reflection;
using Autofac;
using T9Spelling.Business.Interfaces;

namespace T9Spelling
{
    public class Initializer
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();

            // Scan an assembly for components
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICodesService)))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

           return builder.Build();
        }
    }
}