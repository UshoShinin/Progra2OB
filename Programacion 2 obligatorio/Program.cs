using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {                       
            int opc = 0;

            while (opc != 5)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("                     Menu");
                Console.WriteLine("1 - Listado de productos por categoria");
                Console.WriteLine("2 - Clientes registrados antes de una fecha");
                Console.WriteLine("3 - Compras realizadas entre dos fechas");
                Console.WriteLine("4 - Alta de producto");
                Console.WriteLine("5 - Salir");
                Console.WriteLine("-----------------------------------------------");

                opc = PedirNumero("Ingrese una opción entre 1 y 5", "El valor debe ser numérico y estar entre 1 y 5", 1, 5);
                switch (opc)
                {
                    case 1:
                        MostrarProductos();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        ComprasEntreFechas();
                        break;
                    case 4:
                        AltaProducto();
                        break;
                    case 5:
                        Console.WriteLine("Esta saliendo del programa...");
                        Console.WriteLine("Presione cualquier tecla para continuar (ESC para cancelar)");
                        char teclaSalida = Console.ReadKey().KeyChar;
                        int valorAsciiTecla = (int)teclaSalida;
                        if (valorAsciiTecla == 27)
                            opc = 0;
                        break;
                }

                Console.Clear();                        

            }

        }

        public static int PedirNumero(string msg, string msgError, int min, int max)
        {
            int opc;
            bool exito = false;
            do
            {
                Console.WriteLine(msg);
                string sOpc = Console.ReadLine();
                if (int.TryParse(sOpc, out opc) && (opc >= min && opc <= max))
                {
                    exito = true;
                }
                else
                {
                    Console.WriteLine(msgError);
                }

            } while (!exito);
            return opc;
        }

        public static DateTime PedirFecha(string msg, string msgError)
        {
            DateTime fecha;
            bool exito = false;
            do{
                Console.WriteLine(msg);
                string sFecha = Console.ReadLine();
                
                exito = DateTime.TryParseExact(sFecha,"dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out fecha);
                if(!exito)
                    Console.WriteLine(msgError);
            } while (!exito);
            return fecha;
        }

        public static void MostrarProductos()
        {

            Console.Clear();
            int cont = 0;
            Console.WriteLine("-Tipos de producto");
            Console.WriteLine("1.Todos");
            Console.WriteLine("2.Frescos");
            Console.WriteLine("3.Congelados");
            Console.WriteLine("4.Hogar");
            Console.WriteLine("5.Textiles");
            Console.WriteLine("6.Tecnología");
            Console.WriteLine("0.Volver");
            int opc = PedirNumero("Ingrese una opción entre 0 y 6", "El valor debe ser numérico y estar entre 0 y 6", 0, 6);

            if (opc == 1)
            {
                foreach (Producto p in Administradora.Instancia.Productos)
                {
                    Console.WriteLine(p);
                    cont++;
                }
                if (cont == 0)
                    Console.WriteLine("No hay productos registrados");
            }
            else if (opc == 0)
            {
                Console.WriteLine("Chiao");
            }
            else
            {
                foreach (Producto p in Administradora.Instancia.Productos)
                {
                    if (p.Categoria == (Producto.EnumCategoria)opc - 1)
                    {
                        Console.WriteLine(p);
                        cont++;
                    }

                }
                if (cont == 0)
                    Console.WriteLine("No hay productos de esta categoría");
            }
            Console.ReadLine();

        }

        public static void ListarClientes()

        {
            Console.Clear();
            int cont = 0;

            DateTime fecha = PedirFecha("Ingrese la fecha (dd-MM-aaaa):", "La fecha debe obedecer un formato de dd-MM-aaaa");

            foreach (Cliente c in Administradora.Instancia.Clientes)
            {

                if (c.Fecha < fecha)
                {

                    Console.WriteLine(c);
                    cont++;

                }

            }

            if (cont == 0)

                Console.WriteLine("No hay clientes registrado después de la fecha: " + fecha.ToShortDateString());

            Console.ReadLine();

        }

        public static void ComprasEntreFechas()
        {
            Console.Clear();
            Console.WriteLine("Consulta - Compras entre dos fechas");
            DateTime fechaMinima, fechaMaxima;

            fechaMinima = PedirFecha("Ingrese la fecha (dd-MM-aaaa):", "La fecha debe obedecer un formato de dd-MM-aaaa");
            fechaMaxima = PedirFecha("Ingrese la fecha (dd-MM-aaaa):", "La fecha debe obedecer un formato de dd-MM-aaaa");

            if (fechaMaxima < fechaMinima)
            {
                DateTime aux = fechaMinima;
                fechaMinima = fechaMaxima;
                fechaMaxima = aux;
            }

            foreach (Compra c in Administradora.Instancia.Compras)
            {
                if (c.Fecha >= fechaMinima && c.Fecha <= fechaMaxima)
                {
                    Console.WriteLine(c.ToString());
                }
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();

        }        

        public static void AltaProducto()
        {
            Administradora a = Administradora.Instancia;
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            if (Producto.NombreValido(nombre))
            {
                Console.WriteLine("Agregue una descripción al producto: ");
                string descripcion = Console.ReadLine();
                if (Producto.DescripcionValida(descripcion))
                {
                    Console.WriteLine("Ingrese el precio del producto: ");
                    double precio;
                    if (Double.TryParse(Console.ReadLine(), out precio))
                    {
                        if (Producto.PrecioValido(precio))
                        {
                            int opc = -1;
                            opc = PedirNumero("El producto es exclusivo? 0) No  1) Sí", "Ingrese 0 o 1", 0, 1);                           
                            bool exclusivo;
                            exclusivo = (opc == 1) ? true : false;                            

                            Console.WriteLine("1 - FRESCOS");
                            Console.WriteLine("2 - CONGELADOS");
                            Console.WriteLine("3 - HOGAR");
                            Console.WriteLine("4 - TEXTILES");
                            Console.WriteLine("5 - TECNOLOGIA");
                            opc = -1;                            
                            opc = PedirNumero("Ingrese una opción entre 1 y 5", "El valor debe ser numérico y estar entre 1 y 5", 1, 5);
                            
                            Producto.EnumCategoria categoria = Producto.EnumCategoria.FRESCOS;
                           
                            switch (opc)
                            {
                                case 1:
                                    categoria = Producto.EnumCategoria.FRESCOS;                                                                  
                                    break;
                                case 2:
                                    categoria = Producto.EnumCategoria.CONGELADOS;                                                                     
                                    break;
                                case 3:
                                    categoria = Producto.EnumCategoria.HOGAR;                                    
                                    break;
                                case 4:
                                    categoria = Producto.EnumCategoria.TEXTILES;                                    
                                    break;
                                case 5:
                                    categoria = Producto.EnumCategoria.TECNOLOGIA;                                    
                                    break;
                            }

                            Producto producto = new Producto(nombre, descripcion, exclusivo, categoria, precio);
                            a.AgregarProducto(producto);
                            Console.WriteLine("El producto ha sido dado de alta...");
                            Console.ReadKey();

                        } else
                        {
                            Console.WriteLine("El precio debe de ser mayor a 0");
                            Console.ReadKey();
                        }
                    } else
                    {
                        Console.WriteLine("Debe de ingresar un numero");
                        Console.ReadKey();
                    }
                } else
                {
                    Console.WriteLine("La descripción no puede estar vacía");
                    Console.ReadKey();
                }
            } else
            {
                Console.WriteLine("El nombre no puede estar vacío");
                Console.ReadKey();
            }
        }

    }
}
