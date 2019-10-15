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

                opc = PedirNumero("Ingrese una opcion entre ", "El valor debe ser numérico y estar entre ", 1, 5);
                switch (opc)
                {
                    case 1:
                        MostrarProductos();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                    case 4:
                        Console.WriteLine("4");
                        break;
                    case 5:
                        Console.WriteLine("Acaba de salir del programa");
                        break;
                }

                Console.Clear();
            }
        }
        public static int PedirNumero(string msg, string msgError, int min, int max){
            int opc;
            bool exito = false;
            do
            {
                Console.WriteLine(msg + min +" y " + max);
                string sOpc = Console.ReadLine();
                if (int.TryParse(sOpc, out opc) && (opc >= min && opc <= max)){
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
            int cont=0;
            Console.WriteLine("-Tipos de producto");
            Console.WriteLine("1.Todos");
            Console.WriteLine("2.Frescos");
            Console.WriteLine("3.Congelados");
            Console.WriteLine("4.Hogar");
            Console.WriteLine("5.Textiles");
            Console.WriteLine("6.Tecnología");
            Console.WriteLine("0.Volver");
            int opc = PedirNumero("Ingrese una opcion entre ", "El valor debe ser numérico y estar entre ", 0, 6);

            if (opc == 1){
                foreach (Producto p in Administradora.Instancia.Productos)
                {
                    Console.WriteLine(p);
                    cont++;
                }
                if(cont==0)
                    Console.WriteLine("No hay productos registrados");
            }else if(opc == 0){
                Console.WriteLine("Chiao");
            }
            else{
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
    }
}
