using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TestConsoleTrabajo.Models;
using System.Linq;

namespace TestConsoleTrabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            var datosPersonales = DatosPersonalesCliente(cliente);

            DatosVentasCliente();

        }

        public static void DatosPersonalesCliente(Cliente cliente) {
            
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
            Console.Clear();
            using (StreamReader file = new StreamReader(Path.Combine(docPath, "DatosCliente.txt")))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                   
                }

                file.Close();

            }
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
            Console.Clear();
            using (StreamReader file = new StreamReader(Path.Combine(docPath, "VentasCliente.txt")))
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "CalculosVentasAnualesTotales.txt")))
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
                decimal[] xs = new decimal[12]; 
                while ((ln = file.ReadLine()) != null)
                {
                    if (band2) {
                        a = ln;
                        band2 = false;
                        Console.WriteLine("Año: " + a);
                        continue;
                    }
                    xs[counter] = Convert.ToInt32(ln);
                    
                   
                    TotalVentasAno = TotalVentasAno + Convert.ToInt32(ln);
                    if (band) {
                        MayorVenta = Convert.ToInt32(ln);
                        mesMayorVenta = 1;
                        MenorVenta = Convert.ToInt32(ln);
                        mesMenorVenta = 1;
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
                    counter++;
                    if (counter >= 12) {
                        float prom = TotalVentasAno / 12;
                        decimal mediana = Median(xs);
                        

                                    outputFile.WriteLine(TotalVentasAno);
                                    outputFile.WriteLine(mesMayorVenta);
                                    outputFile.WriteLine(mesMenorVenta);
                                    outputFile.WriteLine(prom);
                                    outputFile.WriteLine(mediana);


                        
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
                }

            }
            using (StreamReader file = new StreamReader(Path.Combine(docPath, "CalculosVentasAnualesTotales.txt")))
            {
                string ln2;
                string[] texto = new string[] { "\nTotal ventas del año", "Mes mayor venta", "Mes menor Venta", "Promedio Ventas", "Mediana Ventas" };
                int cont = 0;
                ArrayList calculosVentas = new ArrayList();
                Console.WriteLine("Leyendo desde archivo: CalculosVentasAnualesTotales.txt\n");
                while ((ln2 = file.ReadLine()) != null)
                {
                    calculosVentas.Add(ln2);
                    
                }
                foreach (var item in calculosVentas) {
                    Console.WriteLine($"{texto[cont]} : {item}");
                    if (cont >= 4)
                    {
                        cont = 0;
                    }
                    else {
                        cont++;
                    }
                }

            }
        }

        public static decimal Median(decimal[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
        }
    }
}
