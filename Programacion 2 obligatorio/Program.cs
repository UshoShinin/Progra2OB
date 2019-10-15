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
                Console.WriteLine("2 - Clientes registrados a partir de una fecha");
                Console.WriteLine("3 - Compras realizadas entre dos fechas");
                Console.WriteLine("4 - Alta de producto");
                Console.WriteLine("5 - Salir");
                Console.WriteLine("-----------------------------------------------");

                opc = PedirNumero("Ingrese una opcion entre ", "El valor debe ser numérico y estar entre", 1, 5);
                switch (opc)
                {
                    case 1:
                        MostrarProductos();
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 3:
                        ComprasEntreFechas();
                        break;
                    case 4:
                        AltaProducto();
                        break;
                    case 5:
                        Console.WriteLine("Esta saliendo del programa");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();

                        ListarClientes();
            }

        }

        public static int PedirNumero(string msg, string msgError, int min, int max)
        {
            int opc;
            bool exito = false;
            do
            {
                Console.WriteLine(msg + min + " y " + max);
                string sOpc = Console.ReadLine();
                if (int.TryParse(sOpc, out opc) && (opc >= min && opc <= max))
                {
                    exito = true;
                }
                else
                {
                    Console.WriteLine(msgError + min + " y " + max);
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
                exito = DateTime.TryParseExact(sFecha,"dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha);
                if(!exito)
                    Console.WriteLine(msgError);
            } while (!exito);
            return fecha;
        }

        public static void MostrarProductos()
        {
            int cont = 0;
            Console.WriteLine("-Tipos de producto");
            Console.WriteLine("1.Todos");
            Console.WriteLine("2.Frescos");
            Console.WriteLine("3.Congelados");
            Console.WriteLine("4.Hogar");
            Console.WriteLine("5.Textiles");
            Console.WriteLine("6.Tecnología");
            Console.WriteLine("0.Volver");
            int opc = PedirNumero("Ingrese una opcion entre ", "El valor debe ser numérico y estar entre ", 0, 6);

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
            int cont = 0;
            DateTime fecha = PedirFecha("Ingrese la fecha", "La fecha debe obedecer un formato de dd/MM/aaaa");
            foreach (Cliente c in Administradora.Instancia.Clientes)
            {
                if (c.Fecha < fecha)
                {
                    Console.WriteLine(c);
                    cont++;
                }
            }
            if (cont == 0)
                Console.WriteLine("No hay clientes registrado antes de la fecha: " + fecha);
            Console.ReadLine();
        }
        public static void ComprasEntreFechas()
        {
            Console.Clear();
            Console.WriteLine("Consulta - Compras entre dos fechas");
            DateTime fechaMinima, fechaMaxima;

            fechaMinima = PideFecha("Ingrese la primera fecha: ");
            fechaMaxima = PideFecha("Ingrese la segunda fecha: ");

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

        public static DateTime PideFecha(string mensaje)
        {
            bool exito;
            DateTime fecha;

            do
            {
                Console.WriteLine(mensaje);
                string aux = Console.ReadLine();
                exito = DateTime.TryParse(aux, out fecha);
                if (!exito)
                    Console.WriteLine("Error, ingrese la fecha nuevamente");
            } while (exito == false);

            return fecha;
        }

        public static void AltaProducto()
        {
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
                            while (opc != 1 && opc != 0)
                            {
                                Console.WriteLine("El producto es exclusivo? 0) No  1) Sí");
                                Int32.TryParse(Console.ReadLine(), out opc);
                            }

                            bool exclusivo;
                            exclusivo = (opc == 1) ? true : false;
                            Console.WriteLine(exclusivo);


                            Console.WriteLine("1 - FRESCOS");
                            Console.WriteLine("2 - CONGELADOS");
                            Console.WriteLine("3 - HOGAR");
                            Console.WriteLine("4 - TEXTILES");
                            Console.WriteLine("5 - TECNOLOGIA");

                            opc = -1;

                            while (opc < 1 || opc > 5)
                            {
                                Console.WriteLine("Elija la categoria del producto: ");
                                Int32.TryParse(Console.ReadLine(), out opc);
                            }                           

                            switch (opc)
                            {
                                case 1:
                                    Producto producto = new Producto(nombre, descripcion, exclusivo, Producto.EnumCategoria.FRESCOS, precio);
                                    Administradora.Instancia.AgregarProducto(producto);
                                    break;
                                case 2:
                                    producto = new Producto(nombre, descripcion, exclusivo, Producto.EnumCategoria.CONGELADOS, precio);
                                    Administradora.Instancia.AgregarProducto(producto);
                                    break;
                                case 3:
                                    producto = new Producto(nombre, descripcion, exclusivo, Producto.EnumCategoria.HOGAR, precio);
                                    Administradora.Instancia.AgregarProducto(producto);
                                    break;
                                case 4:
                                    producto = new Producto(nombre, descripcion, exclusivo, Producto.EnumCategoria.TEXTILES, precio);
                                    Administradora.Instancia.AgregarProducto(producto);
                                    break;
                                case 5:
                                    producto = new Producto(nombre, descripcion, exclusivo, Producto.EnumCategoria.TECNOLOGIA, precio);
                                    Administradora.Instancia.AgregarProducto(producto);
                                    break;
                            }
                            
                            Console.WriteLine("El producto ha sido dado de alta...");
                            Console.ReadKey();

                        }
                    }
                }
            }
        }

    }
}
