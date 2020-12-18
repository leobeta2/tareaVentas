using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TestConsoleTrabajo.Models;

namespace TestConsoleTrabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            //var datosPersonales = DatosPersonalesCliente(cliente);

            DatosVentasCliente();

        }

        public static Cliente DatosPersonalesCliente(Cliente cliente) {
            
            string telefono;
            ArrayList tel = new ArrayList();
            Console.WriteLine("DATOS CLIENTE\n");
            Console.WriteLine("Ingrese Nombres:");
            cliente.nombres = Console.ReadLine();
            Console.WriteLine("Ingrese Apellidos:");
            cliente.apellidos = Console.ReadLine();
            Console.WriteLine("Ingrese Direccion Particular:");
            cliente.direccion = Console.ReadLine();
            do
            {
                Console.WriteLine("telefonos de contacto, para terminar ingrese 0:");
                telefono = Console.ReadLine();
                if (telefono != "0") {
                    tel.Add(telefono);
                }
            } while (telefono != "0");
            cliente.telefono = tel;
            Console.WriteLine("Fecha ingreso como cliente (dd/mm/aaaa):");
            cliente.fechaIngreso = Console.ReadLine();
            Console.WriteLine("Antiguedad:");
            cliente.antiguedad = Console.ReadLine();
            Console.WriteLine("Categoria Cliente: Brass, Silver, Gold:");
            cliente.categoriaCliente = Console.ReadLine();
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "DatosCliente.txt")))
            {
                outputFile.WriteLine(cliente.nombres);
                outputFile.WriteLine(cliente.apellidos);
                outputFile.WriteLine(cliente.direccion);
                foreach (var item in cliente.telefono)
                {
                    outputFile.WriteLine(item);
                }
                
                outputFile.WriteLine(cliente.fechaIngreso);
                outputFile.WriteLine(cliente.antiguedad);
                outputFile.WriteLine(cliente.categoriaCliente);
            }

            using (StreamReader file = new StreamReader(Path.Combine(docPath, "DatosCliente.txt")))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                   
                }

                file.Close();

            }

            return cliente;
        }

        public static void DatosVentasCliente()
        {
            Ventas ventas = new Ventas();
            //Dictionary<int, int> mesVenta = new Dictionary<int, int>();
            ArrayList mesVenta = new ArrayList();
            int ventasMes;
            string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine("\nVENTAS CLIENTE\n");
            Console.WriteLine("Cuantos años desea ingresar:");
            int cantAnos = Convert.ToInt32(Console.ReadLine());
            string ano;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "VentasCliente.txt")))
            {
                for (int i = 0; i < cantAnos; i++)
                {
                Console.WriteLine("Ingrese año:");
                ano = Console.ReadLine();
                for (int j = 0; j < 12; j++)
                {
                    Console.WriteLine($"Ingrese venta total del mes {j + 1}:");
                    ventasMes = Convert.ToInt32(Console.ReadLine());
                    mesVenta.Add(ventasMes);
                }
                
                
                    outputFile.WriteLine(ano);
                    foreach (var item  in mesVenta)
                        outputFile.WriteLine(item);
                
                mesVenta.Clear();
                }
            }

            using (StreamReader file = new StreamReader(Path.Combine(docPath, "VentasCliente.txt")))
            {
                int counter = 0;
                string ln;
                int TotalVentasAno = 0;
                int mesMayorVenta = 0;
                int mesMenorVenta = 0;
                int MayorVenta = 0;
                int MenorVenta = 0;
                bool band = true;
                bool band2 = true;
                String a="";
                while ((ln = file.ReadLine()) != null)
                {
                    if (band2) {
                        a = ln;
                        band2 = false;
                        Console.WriteLine("Año: " + a);
                        continue;
                    }
                    Console.WriteLine(ln);
                    counter++;
                    TotalVentasAno = TotalVentasAno + Convert.ToInt32(ln);
                    if (band) {
                        MayorVenta = Convert.ToInt32(ln);
                        MenorVenta = Convert.ToInt32(ln);
                        band = false;
                    }
                    
                    if (MayorVenta < Convert.ToInt32(ln))
                    {
                        MayorVenta = Convert.ToInt32(ln);
                        mesMayorVenta = counter + 1;
                    }
                    if (MenorVenta > Convert.ToInt32(ln))
                    {
                        MenorVenta = Convert.ToInt32(ln);
                        mesMenorVenta = counter + 1;
                    }
                    if (counter >= 12) {
                        Console.WriteLine($"\nTotal anual año {a}: " + TotalVentasAno);
                        Console.WriteLine("Mes mayor venta: " + mesMayorVenta);
                        Console.WriteLine("Mes menor venta: " + mesMenorVenta);
                        counter = 0;
                            TotalVentasAno = 0;
                            mesMayorVenta = 0;
                            mesMenorVenta = 0;
                            MayorVenta = 0;
                            MenorVenta = 0;
                            band = true;
                            band2 = true;
                        
                    }
                }
                

                file.Close();
                Console.WriteLine($"File has {counter} lines.");


            }
        }
    }
}
