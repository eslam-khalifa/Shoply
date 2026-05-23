using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Entities
{
    public class BaseEntity
    {
        // this tells mongodb that this property is the primary key (_id field)
        [BsonId]
        // this tells mongodb even though the property is a string, it should be stored as an ObjectId in the database
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        // in mongodb, the id "_id" is represented as an ObjectId "the type"
        public string Id { get; set; }
    }
}
