using System;
using System.Collections;
using TestConsoleTrabajo.Models;

namespace TestConsoleTrabajo
{
    class Program
    {
        static void Main(string[] args)
        {

            Cliente cliente = new Cliente();
            string telefono;
            ArrayList tel = new ArrayList();
            Console.WriteLine("DATOS CLIENTE\n");
            Console.WriteLine("Ingrese Nombres:");
            cliente.nombres = Console.ReadLine();
            Console.WriteLine("Ingrese Apellidos:");
            cliente.apellidos = Console.ReadLine();
            Console.WriteLine("Ingrese Direccion Particular:");
            cliente.direccion = Console.ReadLine();
            do {
                Console.WriteLine("telefonos de contacto, para terminar ingrese 0:");
                telefono = Console.ReadLine();
               tel.Add(telefono);
            } while (telefono != "0");
            cliente.telefono = tel;
            Console.WriteLine("Fecha ingreso como cliente (dd/mm/aaaa):");
            cliente.fechaIngreso = Console.ReadLine();
            Console.WriteLine("Antiguedad:");
            cliente.antiguedad = Console.ReadLine();
            Console.WriteLine("Categoria Cliente, ingrese numero: (1) Brass, (2) Silver, (3) Gold:");
            cliente.categoriaCliente = Console.ReadLine();
            Console.WriteLine("\nVENTAS CLIENTE\n");
            Console.WriteLine("Total de Ventas Mensuales del último años:");
            cliente.ventas.TotalVentasMensuales = Console.ReadLine();
            Console.WriteLine("Total anual:");
            cliente.ventas.TotalAnual = Console.ReadLine();

        }
    }
}
