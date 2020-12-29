using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Utilities
{
    public static class GenericMethod
    {
        public static bool IsStringOrIntPropertiesHasValue<T>(T entity)
        {
            if (entity is null)
            {
                return false;
            }

            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string) || property.PropertyType == typeof(int?))
                {
                    var value = entity.GetType().GetProperty(property.Name).GetValue(entity)?.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        return true;
                    }
                }

                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    var subEntity = entity.GetType().GetProperty(property.Name).GetValue(entity);
                    IsStringOrIntPropertiesHasValue(subEntity);
                }
            }

            return false;
        }
    }
}
