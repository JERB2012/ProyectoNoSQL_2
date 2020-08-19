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

        public IList<Cliente> ListarClientesPorProvincia(string LaProv)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Cliente>("clientes");
            var expresssionFilter = Builders<Cliente>.Filter.Regex(x => x.CDireccion.Provincia, LaProv);
            var elResultado = collection.Find(expresssionFilter).ToList();
            return elResultado;
        }

        public IList<Inventario> ListarProductosPorProveedor(string Prove)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Inventario>("inventario");
            var expresssionFilter = Builders<Inventario>.Filter.Regex(x => x.Proveedor.Nombre, Prove);
            var elResultado = collection.Find(expresssionFilter).ToList();
            return elResultado;
        }

        public void BorrarCliente(string elNombreDelCliente)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Cliente>("clientes");
            var expresssionFilter = Builders<Cliente>.Filter.Regex(x => x.Nombre, elNombreDelCliente);
            collection.DeleteOne(expresssionFilter);
        }

        public IList<Inventario> ListarProductosPorLocal(string Local)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Inventario>("inventario");
            var expresssionFilter = Builders<Inventario>.Filter.Regex(x => x.Disponibilidad[0].Local, Local);
            var elResultado = collection.Find(expresssionFilter).ToList();
            return elResultado;
        }

        public IList<Inventario> ListarProductosMayoresA(string Cantidad)
        {
            var laBaseDeDatos = ConectarBD();
            var collection = laBaseDeDatos.GetCollection<Inventario>("inventario");
            var expresssionFilter = Builders<Inventario>.Filter.Gte(x => x.Producto.Cantidad, Int32.Parse(Cantidad));
            var elResultado = collection.Find(expresssionFilter).ToList();
            return elResultado;
        }
    }
}
