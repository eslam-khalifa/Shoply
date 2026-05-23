using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Entities
{
    public class ProductType : BaseEntity
    {
        // to store the property "Name" in the database as "name" instead of "Name", we can use the BsonElement attribute to specify the name of the field in the database
        // [BsonElement("name")]
        public string Name { get; set; }
    }
}
