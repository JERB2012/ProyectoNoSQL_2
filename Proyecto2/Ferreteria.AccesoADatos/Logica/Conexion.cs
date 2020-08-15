using Ferreteria.Model.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.AccesoADatos
{
    public class Conexion
    {
        public IMongoDatabase ConectarBD()
        {

            var client = new MongoClient("mongodb+srv://jerb:jerb@myatlascluster-dgpr6.gcp.mongodb.net/ferreteria?retryWrites=true&w=majority");
            var database = client.GetDatabase("ferreteria");
            return database;

        }

        public IList<Cliente> ListarClientes()
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Cliente>("clientes");
            var filter = new BsonDocument();
            var elResultado = collection.Find(filter).ToList();
            return elResultado;
        }

        public IList<Cliente> ListarClientesPorNombre(string elNombreDelCliente)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Cliente>("clientes");
            var expresssionFilter = Builders<Cliente>.Filter.Regex(x => x.Nombre, elNombreDelCliente);
            var elResultado = collection.Find(expresssionFilter).ToList();
            return elResultado;
        }

        public IList<Inventario> ListarInventario()
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Inventario>("inventario");
            var filter = new BsonDocument();
            var elResultado = collection.Find(filter).ToList();
            return elResultado;
        }

        public IList<Ordenes> ListarOrdenes()
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Ordenes>("ordenes");
            var filter = new BsonDocument();
            var elResultado = collection.Find(filter).ToList();
            return elResultado;
        }

        public void InsertarCliente(Cliente elCliente)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Cliente>("clientes");
            collection.InsertOne(elCliente);
        }

        public void ActualizarNombreDeCliente(ObjectId elIdDelCliente, string elNuevoNombre)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Cliente>("clientes");
            var filter = Builders<Cliente>.Filter.Eq("_id", elIdDelCliente);
            var update = Builders<Cliente>.Update.Set("Nombre", elNuevoNombre);
            collection.UpdateOne(filter, update);
        }

    }
}
