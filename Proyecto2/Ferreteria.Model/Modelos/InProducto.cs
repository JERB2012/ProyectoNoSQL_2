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
    public class InProducto
    {
        [BsonElement("Codigo")]
        public string Codigo { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Medida")]
        public string Medida { get; set; }

        [BsonElement("PesoKg")]
        public double PesoKg { get; set; }

        [BsonElement("Color")]
        public string Color { get; set; }

        [BsonElement("Precio")]
        public int Precio { get; set; }

        [BsonElement("Cantidad")]
        public int Cantidad { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }
    }
}
