using Alefba.Domain;
using Pluralize.NET.Core;

namespace Alefba.Infrastructure.MongoDb.Utilities
{
    internal static class TypeExtensions
    {
        public static string GetName(this Type typeOfEntity)
        {
            string entityName;

            if (Attribute.GetCustomAttribute(typeOfEntity, typeof(DocumentName)) is not DocumentName attribute)
            {
                var pluralize = new Pluralizer();

                entityName = pluralize.Pluralize($"{typeOfEntity.Name}");
            }
            else
                entityName = attribute.Name;

            return entityName;
        }
    }
}
