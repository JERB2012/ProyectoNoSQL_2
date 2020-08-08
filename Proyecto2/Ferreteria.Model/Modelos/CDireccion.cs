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
    public class CDireccion
    {
        [BsonElement("Provincia")]
        public string Provincia { get; set; }

        [BsonElement("Canton")]
        public string Canton { get; set; }

        [BsonElement("Distrito")]
        public string Distrito { get; set; }

        /*Es necesario?*/
        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }
    }
}
