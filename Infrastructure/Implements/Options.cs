using ExampleInject.Infrastructure.Interfaces;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace ExampleInject.Infrastructure.Implements
{
    public class Options<T> : IOptions<T>
    {
        public readonly string KeyPrefix;
        public readonly T Model;
        public Options(string keyPrefix)
        {
            KeyPrefix = keyPrefix;
            Model = Activator.CreateInstance<T>();

            var propertyNames = ConfigurationManager.AppSettings
                .AllKeys
                .Where(k => k.StartsWith(KeyPrefix))
                .ToDictionary(k => k, v => v.Split('.').Last());

            var properties = Model.GetType().GetProperties();

            foreach (var propertyName in propertyNames)
            {
                var property = properties.FirstOrDefault(p => p.Name.Equals(propertyName.Value, StringComparison.InvariantCultureIgnoreCase));
                if (property == null)
                    continue;

                var value = Convert.ChangeType(ConfigurationManager.AppSettings.Get(propertyName.Key), property.PropertyType);
                var backingFieldInfo = Model.GetType().GetField($"<{property.Name}>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
                if (backingFieldInfo == null)
                    continue;

                backingFieldInfo.SetValue(Model, value);
            }
        }

        public T Value => Model;
    }
}