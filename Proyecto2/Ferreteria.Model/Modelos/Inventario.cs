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
    public class Inventario
    {
        [BsonId]
        public ObjectId InventarioId { get; set; }

        [BsonElement("Producto")]
        public InProducto Producto { get; set; }

        [BsonElement("Proveedor")]
        public InProveedor Proveedor { get; set; }

        [BsonElement("FechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [BsonElement("Disponibilidad")]
        public IList<InDisponibilidad> Disponibilidad { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }

    }
}
