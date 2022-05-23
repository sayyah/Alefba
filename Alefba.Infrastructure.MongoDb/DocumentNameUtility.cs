using Alefba.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure.MongoDb
{
    public static class DocumentNameUtility
    {
        public static string GetDocumentName(this BaseDomainEntity baseDomain)
        {
            // Get instance of the attribute.
            Type attributeType = typeof(DocumentName);
            var attribute =
            (DocumentName)Attribute.GetCustomAttribute(baseDomain.GetType(), attributeType);

            if (attribute == null)
                throw new Exception($"{baseDomain} doesn't have any 'DocumentName' attribute");

            return attribute.Name;
        }
    }
}
