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
    public class InProveedor
    {
        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Direccion")]
        public string Direccion { get; set; }

        [BsonElement("Telefono")]
        public string Telefono { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Contacto")]
        public string Contacto { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }
    }
}
