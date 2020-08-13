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
    public class Ordenes
    {
        [BsonId]
        public ObjectId OrdenesId { get; set; }

        [BsonElement("IdOrden")]
        public int IdOrden { get; set; }

        [BsonElement("FechaCompra")]
        public DateTime FechaCompra { get; set; }

        //ObjectId
        [BsonElement("IdInventario")]
        public ObjectId IdInventario { get; set; }

        //ObjectId
        [BsonElement("IdCliente")]
        public ObjectId IdCliente { get; set; }

        [BsonElement("Cantidad")]
        public int Cantidad { get; set; }

        [BsonElement("Descuento")]
        public int Descuento { get; set; }

        [BsonElement("Total")]
        public int Total { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }

    }
}
