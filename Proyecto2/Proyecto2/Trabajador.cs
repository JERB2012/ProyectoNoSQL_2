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
    }
}
