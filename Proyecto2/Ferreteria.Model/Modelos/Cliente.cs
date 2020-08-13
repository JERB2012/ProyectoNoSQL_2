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
    public class Cliente
    {
        [BsonId]
        public ObjectId ClienteId { get; set; }
        
        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        /*Importa donde se pone de acuerdo a la BD?*/
        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }

        [BsonElement("Direccion")]
        public CDireccion CDireccion { get; set; }

        //[BsonExtraElements]
        //public BsonDocument Metadata { get; set; }

        [BsonElement("Telefono")]
        //public ContactoTelefonico[] LosContactos { get; set; }
        public IList<CTelefono> Contactos { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
       
        
        
    }
}
