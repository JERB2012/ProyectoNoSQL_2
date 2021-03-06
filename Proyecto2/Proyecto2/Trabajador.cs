﻿using Ferreteria.Model.Modelos;
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
                foreach (var cliente in ListaCliente)
                {
                    Console.WriteLine(string.Format(
                        "Id: {2}; Nombre: {0}; Direccion: {1};", 
                        cliente.Nombre, cliente.CDireccion.Provincia, cliente.ClienteId.ToString() 
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

        
    }
}
