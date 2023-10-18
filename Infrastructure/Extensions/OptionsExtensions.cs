using ExampleInject.Infrastructure.Implements;
using ExampleInject.Infrastructure.Interfaces;
using Autofac;

namespace ExampleInject.Infrastructure.Extensions
{
    public static class OptionsExtensions
    {
        public static ContainerBuilder AddOptions<T>(this ContainerBuilder builder, string keyPrefix)
        {
            builder.RegisterInstance(new Options<T>(keyPrefix)).As<IOptions<T>>().SingleInstance();
            return builder;
        }
    }
}