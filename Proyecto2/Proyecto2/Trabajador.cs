using Ferreteria.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class Trabajador
    {
        public void Trabajo01()
        {
            var laOpcion = string.Empty;
            while (laOpcion != "X")
            {
                DesplegarMenu();
                laOpcion = LeaLaOpcion();
                switch (laOpcion)
                {
                    case "1":
                        ListarClientes();
                        break;
                    case "2":
                        ListarInventario();
                        break;
                    case "3":
                        ListarOrdenes();
                        break;
                    case "4":
                        InsertarCliente();
                        break;
                    case "5":
                        CambiarNombreCliente();
                        break;
                    case "6":
                        EliminarCliente();
                        break;
                    case "7":
                        ListeClientePorProvincia();
                        break;
                    case "8":
                        ListeProductoPorProveedor();
                        break;
                    case "9":
                        ListarProductosPorLocal();
                        break;
                    case "10":
                        ListarProductosMayoresA();
                        break;
                    default:
                        break;
                }
            }

        }



        private void DesplegarMenu()
        {
            Console.WriteLine("Menu Principal del Proyecto 2:");
            Console.WriteLine("1.Listar Clientes.");
            Console.WriteLine("2.Listar Inventario.");
            Console.WriteLine("3.Listar Ordenes.");
            Console.WriteLine("4.Insertar Cliente.");
            Console.WriteLine("5.Cambiar Nombre Cliente.");
            Console.WriteLine("6.Eliminar Un Cliente."); 
            Console.WriteLine("7.Listar Direccion de Cliente Por Provincia. ");
            Console.WriteLine("8.Listar Producto Por Proveedor. ");
            Console.WriteLine("9.Listar Productos Por Local.");
            Console.WriteLine("10.Listar Productos con Cantidades superior a.");
            Console.WriteLine("X.Salir");
        }

        private string LeaLaOpcion()
        {
            string elResultado = Console.ReadLine();
            return elResultado;
        }

        private void ListarClientes()
        {
            var client = new Ferreteria.AccesoADatos.Conexion();
            var ListaClientes = client.ListarClientes();
            ImprimirListadoDeClientes(ListaClientes);
        }

        private void ImprimirListadoDeClientes(IList<Cliente> ListaCliente)
        {
            if (ListaCliente.Count > 0)
            {
                Console.WriteLine("Lista de todos los Clientes:");
                var contador = 0;
                foreach (var cliente in ListaCliente)
                {
                    Console.WriteLine(string.Format(
                        "Cliente número: {3}; Id: {2}; Nombre: {0}; Direccion: {1};", 
                        cliente.Nombre, cliente.CDireccion.Provincia, cliente.ClienteId.ToString(), contador++.ToString()
                        /*cliente.Contactos.ToString().Join*/));/*****<------Cambiar por se array***/
                }
            }
            else
                Console.WriteLine("No se encontró ningún Cliente.");
        }

        private void ListarInventario()
        {
            var client = new Ferreteria.AccesoADatos.Conexion();
            var ListaInventario = client.ListarInventario();
            ImprimirInventario(ListaInventario);
        }

        private void ImprimirInventario(IList<Inventario> ListaInventario)
        {
            if (ListaInventario.Count > 0)
            {
                Console.WriteLine("Listado del Inventario:");
                foreach (var inv in ListaInventario)
                {
                    Console.WriteLine(string.Format(
                        "Id: {0}; Nombre: {1}; Precio: {2}; Proveedor: {3};",
                        inv.InventarioId.ToString(), 
                        inv.Producto.Nombre, 
                        inv.Producto.Precio,
                        inv.Proveedor.Nombre
                        /*inv.Disponibilidad*/));/*****<------ Cambiar por se array***/
                }
            }
            else
                Console.WriteLine("No hay datos en el Inventario.");
        }

        private void ListarOrdenes()
        {
            var client = new Ferreteria.AccesoADatos.Conexion();
            var ListaOrdenes = client.ListarOrdenes();
            ImprimirOrdenes(ListaOrdenes);
        }

        private void ImprimirOrdenes(IList<Ordenes> ListaOrdenes)
        {
            if (ListaOrdenes.Count > 0)
            {
                Console.WriteLine("Listado de las Ordenes:");
                foreach (var ord in ListaOrdenes)
                {
                    Console.WriteLine(string.Format(
                        "IdOrden: {0}; Cantidad: {1}; Descuento: {2}; Total: {3};",
                        ord.IdOrden,
                        ord.Cantidad,
                        ord.Descuento,
                        ord.Total));
                }
            }
            else
                Console.WriteLine("No hay Ordenes.");
        }

        private void InsertarCliente()
        {
            Console.Write("Digite el nombre del cliente: ");
            var elNombre = Console.ReadLine();
            Console.Write("Digite la Provincia del cliente: ");
            var laProvincia = Console.ReadLine();
            Console.Write("Digite el canton del cliente: ");
            var elCanton = Console.ReadLine();
            Console.Write("Digite el distrito del cliente: ");
            var elDistrito = Console.ReadLine();
            Console.Write("Digite el telefono de casa: ");
            var elTelefonoCasa = Console.ReadLine();
            Console.Write("Digite el celular: ");
            var elTelefonoCelular = Console.ReadLine();
            Console.Write("Digite el correo del cliente: ");
            var elCorreo = Console.ReadLine();


            var elCliente = new Cliente();
            elCliente.Nombre = elNombre;
            elCliente.CDireccion = new CDireccion();
            elCliente.CDireccion.Provincia = laProvincia;
            elCliente.CDireccion.Canton = elCanton;
            elCliente.CDireccion.Distrito = elDistrito;
            elCliente.CTelefono = new CTelefono();
            elCliente.CTelefono.Casa = elTelefonoCasa;
            elCliente.CTelefono.Celular = elTelefonoCelular;
            elCliente.Email = elCorreo;
            var client = new Ferreteria.AccesoADatos.Conexion();
            client.InsertarCliente(elCliente);

        }


        private void CambiarNombreCliente()
        {
            Console.Write("Digite el nombre del Cliente: ");
            var elNombreDelCliente = Console.ReadLine();
            var client = new Ferreteria.AccesoADatos.Conexion();
            var laListaDeClientes = client.ListarClientesPorNombre(elNombreDelCliente);
            ImprimirListadoDeClientes(laListaDeClientes);
            Console.Write("Seleccione el número del clientes cuyo nombre desea cambiar: ");
            var elClienteSeleccionado = Console.ReadLine();
            var elNumeroDeCliente = 0;
            if (int.TryParse(elClienteSeleccionado, out elNumeroDeCliente))
            {
                if (elNumeroDeCliente >= 0 && elNumeroDeCliente < laListaDeClientes.Count)
                {
                    var elRegistroDeClientes = laListaDeClientes[elNumeroDeCliente];
                    Console.Write(string.Format("El nombre actual del cliente es [{0}]. Digite el nuevo nombre: ", elRegistroDeClientes.Nombre));
                    var elNuevoNombreDelCliente = Console.ReadLine();
                    client.ActualizarNombreDeCliente(elRegistroDeClientes.ClienteId, elNuevoNombreDelCliente);
                }
            }
        }

        private void ListeClientePorProvincia()
        {
            Console.Write("Digite la Provincia a Consultar: ");
            var LaProvincia = Console.ReadLine();
            var client = new Ferreteria.AccesoADatos.Conexion();
            var laListaDeClientes = client.ListarClientesPorProvincia(LaProvincia);
            ImprimirListadoDireccion(laListaDeClientes);
        }

        private void ImprimirListadoDireccion(IList<Cliente> ListaCliente)
        {
            if (ListaCliente.Count > 0)
            {
                Console.WriteLine("Lista de los Clientes:");
                var contador = 0;
                foreach (var cliente in ListaCliente)
                {
                    Console.WriteLine(string.Format(
                        "Cliente número: {0};Nombre: {1}; Canton: {2}; Distrito: {3};",
                        contador++.ToString(),cliente.Nombre, 
                        cliente.CDireccion.Canton, cliente.CDireccion.Distrito
                        ));

                }
            }
            else
                Console.WriteLine("No se encontró ningún Cliente.");
        }

        private void ImprimirListadoInventario(IList<Inventario> ListaInventario)
        {
            if (ListaInventario.Count > 0)
            {
                Console.WriteLine("Lista de Inventario:");
                var contador = 0;
                foreach (var inventario in ListaInventario)
                {
                    Console.WriteLine(string.Format(
                        "Producto Numero: {0};Producto: {1}; Proveedor: {2}; Cantidad: {3}",
                        contador++.ToString(), inventario.Producto.Nombre,
                        inventario.Proveedor.Contacto, inventario.Producto.Cantidad
                        ));

                }
            }
            else
                Console.WriteLine("No se encontró ningún producto con disponibilidad.");
        }
        private void ListeProductoPorProveedor()
        {
            Console.Write("Digite el Proveedor a Consultar: ");
            var ElProveedor = Console.ReadLine();
            var client = new Ferreteria.AccesoADatos.Conexion();
            var laListaDeProductos = client.ListarProductosPorProveedor(ElProveedor);
            ImprimirListadoProductosPorProv(laListaDeProductos);
        }

        private void ImprimirListadoProductosPorProv(IList<Inventario> laListaDeProductos)
        {
            if (laListaDeProductos.Count > 0)
            {
                Console.WriteLine("Lista de los Productos:");
                var contador = 0;
                foreach (var prod in laListaDeProductos)
                {
                    Console.WriteLine(string.Format(
                        "Codigo: {0};Nombre: {1}; Medida: {2}; Precio: {3}; Cantidad: {4};",
                        prod.Producto.Codigo, prod.Producto.Nombre,
                        prod.Producto.Medida , prod.Producto.Precio,
                        prod.Producto.Cantidad
                        ));

                }
            }
            else
                Console.WriteLine("No se encontró ningún Cliente.");
        }
        private void EliminarCliente()
        {
            Console.Clear();
            Console.Write("Digite el nombre del Cliente: ");
            var elNombreDelCliente = Console.ReadLine();
            var client = new Ferreteria.AccesoADatos.Conexion();

            var laListaDeClientes = client.ListarClientesPorNombre(elNombreDelCliente);
            ImprimirListadoDeClientes(laListaDeClientes);

            Console.Write("Seleccione el número del cliente cuyo nombre desea cambiar: ");
            var elClienteSeleccionado = Console.ReadLine();
            var elNumeroDeCliente = 0;

            if (int.TryParse(elClienteSeleccionado, out elNumeroDeCliente))
            {
                if (elNumeroDeCliente >= 0 && elNumeroDeCliente < laListaDeClientes.Count)
                {
                    var elRegistroDeClientes = laListaDeClientes[elNumeroDeCliente];
                    Console.Write(string.Format("Seguro que desea eliminar el usuario [{0},{1}] Si o No.", elRegistroDeClientes.Nombre, elRegistroDeClientes.Email));
                    var confirmacion = Console.ReadLine().ToUpper();
                    if (confirmacion=="SI")
                    {
                        client.BorrarCliente(elRegistroDeClientes.ClienteId.ToString());
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.Write("La operacion de borrado ha sido cancelada");
                        Console.WriteLine("\n");

                    }
                    Console.WriteLine("\n");
                    Console.Write("-----Fin de la Operacion------ Presione cualquier tecla para salir");
                    Console.ReadKey();
                    Console.Clear();
                   
                }
            }
        }

        private void ListarProductosPorLocal()
        {
            Console.Write("Ingrese el local que desea consultar: ");
            var Local = Console.ReadLine();
            var client = new Ferreteria.AccesoADatos.Conexion();
            var laListaDeInventario = client.ListarProductosPorLocal(Local);
            ImprimirListadoInventario(laListaDeInventario);
        }

        private void ListarProductosMayoresA()
        {
            Console.Clear();
            Console.Write("Digite la cantidad de producto en inventario:  ");
            Console.Write("\n");
            var Cantidad = Console.ReadLine();
            var client = new Ferreteria.AccesoADatos.Conexion();
            var laListaDeInventario = client.ListarProductosMayoresA(Cantidad);
            Console.Write("\n");
            ImprimirListadoInventario(laListaDeInventario);
            Console.WriteLine("\n");
            Console.Write("-----Fin de la Operacion------ Presione cualquier tecla para salir");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
