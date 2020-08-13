using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Model.Modelos
{
    [BsonIgnoreExtraElements]
    public class InDisponibilidad
    {
        [BsonElement("Local")]
        public string Local { get; set; }

        /*Es necesario?*/
        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }
    }
}
