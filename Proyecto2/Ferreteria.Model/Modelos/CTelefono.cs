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
    public class CTelefono
    {
        [BsonElement("Casa")]
        public string Casa { get; set; }

        [BsonElement("Celular")]
        public string Celular { get; set; }

        /*Es necesario?*/
        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }

    }
}
